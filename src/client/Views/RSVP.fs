module View.RSVP

open Fable.Import.Browser
open Fable.Import.React
open Fable.Core.JsInterop
open Fable.Helpers.React.Props
open Fable.Helpers.React
open Model

open CheckBox
open Buttons
open ServerModel

let style = importAll<obj> "../styles/RSVP.scss" 
let anim = importAll<obj> "../styles/animation.scss" 

let makeRadioBoxes (dispatch: Msg -> unit) model =
  let attendingAction () = dispatch <| Attending model.Name
  let notAttendingAction () = dispatch <| NotAttending model.Name

  let attending =
    match model.Attending with
    | Some x -> x
    | _ -> false

  let notAttending =
    match model.Attending with
    | Some x -> x
    | _ -> true
  
  div [ ClassName <| string style?nameLayout ] [
    h3 [] [ str model.Name ]
    div [] [
      CheckBox "Attending" attending attendingAction
      CheckBox "Not Attending" (not notAttending) notAttendingAction
    ]
  ]

let isNone invitee =
  match invitee.Attending with
  | Some _ ->
    console.log("isSome")
    false
  | None ->
    console.log("isNone")
    true

let RSVPPageView (model: Model) dispatch =
  let nameList = List.map (makeRadioBoxes dispatch) model.Invitees

  let action () =
    if List.exists isNone model.Invitees then ()
    else dispatch <| StartSavingAttending

  let message =
    if List.exists isNone model.Invitees then "Please tell us who is coming"
    else
      match model.isLoading with
      | true -> "Saving your response"
      | false -> "Next"

  [
    div [ ClassName <| string style?Container ] [
      h1 [] [ str "Who will be comming?" ]
      h2 [] [ str "Please mark down your intentions below." ; br [] ; str "If you RSVP, there will be a seat at a table with your name-tag on it!" ]

      div [] nameList

      div [ ClassName <| string style?button ] [ 
        Buttons.Black (fun _ -> action()) message
      ]
    ]
  ]