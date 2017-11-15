module View.Done

open Fable.Import.Browser
open Fable.Import.React
open Fable.Core.JsInterop
open Fable.Helpers.React.Props
open Fable.Helpers.React
open Model

open CheckBox
open Buttons
open ServerModel

let drstyle = importAll<obj> "../styles/DietaryRequirements.scss" 
let lpstyle = importAll<obj> "../styles/LandingPage.scss" 
let style = importAll<obj> "../styles/Done.scss" 
let anim = importAll<obj> "../styles/animation.scss" 

let isAttending invitee =
  match invitee.Attending with
  | Some x -> x
  | _ -> false

let DonePageView (model: Model) dispatch =
  let attendingGuests     = List.filter isAttending model.Invitees          
  let notAttendingGuests  = List.filter (isAttending >> not) model.Invitees

  let attending =
    if attendingGuests.Length > 0 then
      let attendingNames = attendingGuests |> List.map (fun x -> x.Name) |> String.concat " and "
      [ h1 [] [ str <| attendingNames + ", we look forward to seeing you!" ] ]
    else
     []
  
  let notAttending =
    if notAttendingGuests.Length > 0 then
      let notAttendingNames = notAttendingGuests |> List.map (fun x -> x.Name) |> String.concat " and "
      [ h2 [] [ str <| "We are sorry to hear " + notAttendingNames + " cannot attend." ] ]
    else
     []

  
  

  [
    div [ ClassName <| string style?container ] <| List.concat [
      attending
      notAttending
      [

        div [ classList [ (string <| lpstyle?DetailsSection, true) ; (string <| style?DetailsSection, true) ] ]
          [
              h2 [] [ str "More details about:" ]
              div [] [
                   Black (fun _ -> dispatch <| GoTo WeddingDetails) "The Wedding"
                   Black (fun _ -> dispatch <| GoTo PlanningDetails) "Planning your Trip"
              ]
           ]

        div [ ClassName <| string drstyle?notAttending; OnClick (fun _ -> dispatch <| GoTo RSVP) ][ 
          span [] [ str "Click here to amend RSVP and/or Dietary requirements." ]
        ]

        div [ ClassName <| string lpstyle?FooterSection]
          [
              p [ ] [ str "Due to restrictions at our venue, children are not invited." ]   
          ]         
      ]
    ]
  ]