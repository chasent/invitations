module App

open Fable.Import.Browser
open Elmish
open Elmish.React
open Elmish.Debug
open Model
open Reducer

open ServerClient

let getVisitorData () =
  async {
      let idPart = window.location.href.Split ('#') |> Array.last
      let id = idPart.Substring(1, idPart.Length)
      let! result = server.getVisitorData id
      return result
  }

let init () =
  {
      Page        = Loading
      Ticks       = 0
      Invitees    = [] 
      isLoading   = true
  }, Cmd.ofAsync getVisitorData () AddServerState (fun _ -> GoTo LandingPage)


// App
Program.mkProgram init update View.Main.view
|> Program.withConsoleTrace
|> Program.withReact "elmish-app"
#if DEBUG
//|> Program.withHMR
|> Program.withDebugger
#endif
|> Program.run