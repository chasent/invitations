module View.DietaryRequirements

open Fable.Import.Browser
open Fable.Core.JsInterop
open Fable.Helpers.React.Props
open Fable.Helpers.React
open Model

let style = importAll<obj> "../styles/DietaryRequirements.scss" 
let anim = importAll<obj> "../styles/animation.scss" 



let DietaryRequirementsPageView (model: PageState) dispatch =
  [ div [ ClassName <| string style?main ] [ 
        h1 [] [ str "We look forward to seeing you!" ]
        div [] [ str "Please tell us about any dietary requirements" ]

        div [ ClassName <| string style?CheckBoxContainer ] [
          div  [ ClassName <| string style?CheckBox ] [
            input [ Type "checkbox" ; Value "None" ; Id "Vegetarian" ; Name "check" ; Checked model.Vegetarian ]
            label [ HtmlFor "Vegetarian" ; OnClick (fun _ -> dispatch <| Vegetarian (not model.Vegetarian))  ] [] ]
          div [ ClassName <| string style?CheckBoxLabel ; OnClick (fun _ -> dispatch <| Vegetarian (not model.Vegetarian)) ] [ str "Vegetarian" ] ]

        div [ ClassName <| string style?CheckBoxContainer ] [
          div  [ ClassName <| string style?CheckBox ] [
            input [ Type "checkbox" ; Value "None" ; Id "GlutenFree" ; Name "check" ; Checked model.GlutenFree ]
            label [ HtmlFor "GlutenFree" ; OnClick (fun _ -> dispatch <| GlutenFree (not model.GlutenFree)) ] [] ]
          div [ ClassName <| string style?CheckBoxLabel ; OnClick (fun _ -> dispatch <| GlutenFree (not model.GlutenFree)) ] [ str "Gluten Free" ] ]

        div [ ClassName <| string style?CheckBoxContainer ] [
          div  [ ClassName <| string style?CheckBox ] [
            input [ Type "checkbox" ; Value "None" ; Id "DairyFree" ; Name "check" ; Checked model.DairyFree ]
            label [ HtmlFor "DairyFree" ; OnClick (fun _ -> dispatch <| DairyFree (not model.DairyFree)) ] [] ]
          div [ ClassName <| string style?CheckBoxLabel ; OnClick (fun _ -> dispatch <| DairyFree (not model.DairyFree)) ] [ str "Dairy Free" ] ]
        
        div [ ClassName <| string style?CheckBoxContainer ] [
          div [ ClassName <| string style?formMargin ] [
            div [] [ str "Other Dietary requirements, please specify:" ] 
            input [ Type "text" ; Value model.OtherDiet ; OnChange (fun e -> dispatch <| OtherDiet ( string e.currentTarget?value)) ]
          ] ]
        ] ]