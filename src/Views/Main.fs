module View.Main

open Fable.Import.Browser
open Fable.Core.JsInterop
open Fable.Helpers.React.Props
open Fable.Helpers.React

open Model
open View.LandingPage
open View.DietaryRequirements

let style = importAll<obj> "../styles/main.scss" 
let anim = importAll<obj> "../styles/animation.scss" 
let map = importDefault<Element -> unit> "./GoogleMaps.js" 

let view2 (model: Model) dispatch =
  let viewContent =
    match model with
    | LandingPage lpm ->
      LandingPageView lpm dispatch
    | DietaryRequirements dr ->
      DietaryRequirementsPageView dr dispatch
    | _ ->
       [ div [] [ str "no-view" ] ]

  match model with
  | LandingPage lp ->
    if lp.Ticks < 3 then
      window.setTimeout((fun _ -> dispatch NextTick), 1000, []) |> ignore
    else if lp.Ticks < 5 then
      window.setTimeout((fun _ -> dispatch NextTick), 500, []) |> ignore
    else if lp.Ticks > 5 then
      window.setTimeout((fun _ -> dispatch GoToDietaryRequirements), 1000, []) |> ignore
    else 
      ()    
  | _ -> ()

  let shouldFadeIn =
    match model with
    | LandingPage lp  -> lp.Ticks > 1
    | _               -> true

  div [ classList [ (string style?background, true) ] ]

      [ div [ classList [ (string style?side, true) ;
                          (string anim?fadeInLeft, shouldFadeIn) ]]
            viewContent ]



let view (model: Model) dispatch =
  div [ Ref (fun elem -> map(elem)) ; ClassName <| string style?map] []
  // div []
  //     [ Buttons.CarFerry
  //       Buttons.PassengerFerry
  //       Buttons.Rest
  //       Buttons.Rings
  //       Buttons.Wine
  //     ]