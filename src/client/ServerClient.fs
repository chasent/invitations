module ServerClient

open Fable.Remoting.Client
open ServerModel

let routeBuilder typeName methodName = 
    sprintf "/api/%s" methodName

let server = Proxy.createWithBuilder<IServer> routeBuilder
