module View.CheckBox

open Fable.Import.Browser
open Fable.Import.React
open Fable.Core.JsInterop
open Fable.Helpers.React.Props
open Fable.Helpers.React
open Model


let style = importAll<obj> "../styles/CheckBox.scss" 


let CheckBox checkboxLabel chkd action =
    div [ ClassName <| string style?CheckBoxContainer ] [
      div  [ ClassName <| string style?CheckBox ] [
        input [ Type "checkbox" ; Value "None" ; Id "GlutenFree" ; Name "check" ; Checked chkd ]
        label [ HtmlFor "GlutenFree" ; OnClick (fun _ -> action ()) ] [] ]
      div [ ClassName <| string style?CheckBoxLabel ; OnClick (fun _ -> action()) ] [ str checkboxLabel ] ]
