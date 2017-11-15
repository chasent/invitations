module View.DietaryRequirements

open Fable.Import.Browser
open Fable.Import.React
open Fable.Core.JsInterop
open Fable.Helpers.React.Props
open Fable.Helpers.React
open Model
open CheckBox
open ServerModel

let style = importAll<obj> "../styles/DietaryRequirements.scss" 
let anim = importAll<obj> "../styles/animation.scss" 


let makeDietaryForm dispatch invitee =
  div [] [
    h3 [] [ str invitee.Name ]

    CheckBox "Vegetarian" invitee.Vegetarian  (fun _ -> dispatch <| Vegetarian (invitee.Name, not invitee.Vegetarian))
    CheckBox "GlutenFree" invitee.GlutenFree  (fun _ -> dispatch <| GlutenFree (invitee.Name, not invitee.GlutenFree))
    CheckBox "DairyFree" invitee.DairyFree    (fun _ -> dispatch <| DairyFree (invitee.Name, not invitee.DairyFree))

    div [ ClassName <| string style?CheckBoxContainer ] [
      div [ ClassName <| string style?formMargin ] [
        div [] [ str "Any other Dietary requirements:" ] 
        input [ Type "text" ; Value invitee.Other ; OnChange (fun e -> dispatch <| OtherDiet (invitee.Name, string e.currentTarget?value)) ]
      ]
    ]
  ]

let isAttending invitee =
  match invitee.Attending with
  | Some x -> x
  | _ -> false


let DietaryRequirementsPageView (model: Model) dispatch =
  let nextMessage =
    match model.isLoading with
    | true -> "Saving your response"
    | false -> "Next"

  [
    div [ ClassName <| string style?main ] [
        h2 [] [ str ( "Please tell us about any dietary requirements.") ]

        div [ ClassName <| string style?form ] <| List.map (makeDietaryForm dispatch) (List.filter isAttending model.Invitees)

        
        div [ ClassName <| string style?next ] [ Buttons.Black (fun _ -> dispatch <| StartSavingDiet) nextMessage ]
        div [ ClassName <| string style?notAttending; OnClick (fun _ -> dispatch <| GoTo RSVP) ][ 
          span [] [ str "Click here to amend RSVP." ]
        ]
    ]
  ]