// Server code
// ============
open Suave
open Fable.Remoting.Suave

// model what your server does, this will be shared
type IServer = { 
  getLength : string -> Async<int>
}

// provide an implementation/instance
let server : IServer = {
  getLength = fun input -> async { return input.Length }
}

// create routes from the implementation
// webApp : WebPart
let webApp = FableSuaveAdapter.webPartFor server
// Run server
startWebServer defaultConfig webApp