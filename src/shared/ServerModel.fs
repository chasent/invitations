module ServerModel

type Invitee = {
    Id         : System.Guid
    Name       : string
    Attending  : bool option
    DairyFree  : bool
    GlutenFree : bool
    Vegetarian : bool
    Other      : string
}

type Visitor = {
    Page       : string option
    Invitees   : Invitee array
}

type IServer = {
    getVisitorData : string -> Async<Visitor option>
    saveDiet: (string * (string * bool * bool * bool * string) array)  -> Async<bool>
    saveAttending: (string * (string * bool) array) -> Async<bool>
}

