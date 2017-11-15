module Server

open Suave
open Fable.Remoting.Suave
open ServerModel
open System
open Dapper
open System.Data.SqlClient
open System.Text
open ServerModel

let connectionString = Environment.GetEnvironmentVariable "DBConnectionString"

let extractValue (x:obj) =
   match x with
   | null -> null
   | _ -> match x.GetType().GetProperty("Value") with
          | null -> x
          | prop -> prop.GetValue(x)

let (+>) (map:Map<string, obj>) (key,value) = map.Add(key, extractValue value)
let singleParam (key, value) = (Map.empty) +> (key,value)

type OptionHandler<'T>() =
    inherit SqlMapper.TypeHandler<option<'T>>()

    override __.SetValue(param, value) = 
        let valueOrNull = 
            match value with
            | Some x -> box x
            | None -> null

        param.Value <- valueOrNull    

    override __.Parse value =
        if isNull value || value = box DBNull.Value 
        then None
        else Some (value :?> 'T)

let registerTypeHandlers() =
    SqlMapper.AddTypeHandler (OptionHandler<bool>())
    SqlMapper.AddTypeHandler (OptionHandler<Guid>())
    SqlMapper.AddTypeHandler (OptionHandler<string>())

let safeSqlConnection string =
    registerTypeHandlers()
    new SqlConnection(string)

let query = "
SELECT v.[Page] FROM Visitor AS v WHERE Id = @Id
SELECT i.[Id], i.[Name], i.[Attending], i.[DairyFree], i.[GlutenFree], i.[Vegetarian], i.[Other]
FROM Visitor AS v
LEFT JOIN Invitee AS i ON i.Id = v.InviteeId1 OR  i.Id = v.InviteeId2
WHERE v.Id = @Id"

type QueryArg = { Id : string }

let getVisitorData id =
    async {
        use connection = safeSqlConnection connectionString
        let q = { Id = id }
        let! mrs = connection.QueryMultipleAsync (query, q) |> Async.AwaitTask
        let! a = mrs.ReadAsync<string option>() |> Async.AwaitTask
        let! b = mrs.ReadAsync<Invitee>() |> Async.AwaitTask
        
        let visitor = Seq.tryHead a
        
        let res = Option.map (fun x -> { Page = x ; Invitees = Seq.toArray b}) visitor
        return res 
    }

let updatePageQuery = "
UPDATE Visitor SET
Page = @Page
Where Id = @Id
"
let updateAttendingQuery = "
UPDATE Invitee SET
Attending = @Attending
WHERE Id = @Id"

let updateDietQuery = "
UPDATE Invitee SET
DairyFree = @DairyFree,
GlutenFree = @GlutenFree,
Vegetarian = @Vegetarian,
Other = @Other
WHERE Id = @Id"

type PageUpdateArgs = {
    Id          : string
    Page        : string
}

type AttendingUpdateArgs = {
    Id          : Guid
    Attending   : bool
}

type DietUpdateArgs = {
    Id          : Guid
    DairyFree   : bool
    GlutenFree  : bool
    Vegetarian  : bool
    Other       : string
}

let saveAttending (visitorId: string, invitees: (string * bool) array) =
    async {
        use connection = safeSqlConnection connectionString
        let upqp = { Id = visitorId ; Page = "DietaryRequirements" }

        let! res = connection.ExecuteAsync (updatePageQuery, upqp) |> Async.AwaitTask

        for (inviteeId, idAttending) in invitees do
            let uaqp = { Id = Guid.Parse inviteeId ; Attending = idAttending }
            let! result = connection.ExecuteAsync (updateAttendingQuery, uaqp) |> Async.AwaitTask
            ()

        return res > 0
    }

let saveDiet (visitorId: string, invitees: (string * bool * bool * bool * string) array) =
    async {
        use connection = safeSqlConnection connectionString
        let upqp = { Id = visitorId ; Page = "Done" }

        let! res = connection.ExecuteAsync (updatePageQuery, upqp) |> Async.AwaitTask

        for (inviteeId, dairyFree, glutenFree, vegetarian, otherDiet) in invitees do
            let udrqp = {
                Id = Guid.Parse inviteeId 
                DairyFree = dairyFree 
                GlutenFree = glutenFree 
                Vegetarian = vegetarian 
                Other = otherDiet
            }
            let! result = connection.ExecuteAsync (updateDietQuery, udrqp) |> Async.AwaitTask
            ()

        return res > 0
    }
let server : IServer = {
    getVisitorData = getVisitorData
    saveDiet = saveDiet
    saveAttending = saveAttending
}



let routeBuilder typeName methodName = 
    sprintf "/api/%s" methodName

// enable logging to console
FableSuaveAdapter.logger <- Some Console.WriteLine
// create the webpart with route builder

let webApp = FableSuaveAdapter.webPartWithBuilderFor server routeBuilder 

// start the web server

let config = { defaultConfig with bindings = [ HttpBinding.createSimple HTTP "127.0.0.1" 9000 ] }

startWebServer config webApp
// wait for a key press to exit
Console.ReadKey() |> ignore