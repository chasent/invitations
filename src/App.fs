module App

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Import.Browser
open Elmish
open Elmish.React
open Elmish.Debug
open Model
open Reducer
open Elmish.HMR


let init () =
  let storage =
    try
      string <| window.localStorage.getItem "app" |> ofJson<Option<Model>>
    with
    | _ -> None

  match storage with
  // | Some exisitingStorage ->
  //   console.log "Using exisiing state"
  //   exisitingStorage
  | _ -> PlanningDetails {
        Ticks         = 0     ;
        Attending     = []    ;
        DairyFree     = false ;
        GlutenFree    = false ;
        Vegetarian    = false ;
        OtherDiet     = ""    ;
      }

let wrappedUpdate (msg:Msg) (model:Model) =
  let newState = update msg model
  window.localStorage.setItem("app", newState |> toJson)
  newState


open Elmish.React


// App
Program.mkSimple init wrappedUpdate View.Main.view
|> Program.withConsoleTrace
|> Program.withReact "elmish-app"
#if DEBUG
//|> Program.withHMR
|> Program.withDebugger
#endif
|> Program.run
