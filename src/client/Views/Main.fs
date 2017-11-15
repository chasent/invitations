module View.Main

open Fable.Import.Browser
open Fable.Core.JsInterop
open Fable.Helpers.React

open Model
open LandingPage
open DietaryRequirements
open WeddingDetails
open PlanningDetails
open RSVP
open Done

let style = importAll<obj> "../styles/main.scss" 
let anim = importAll<obj> "../styles/animation.scss" 


let view (model: Model) dispatch =
  let viewContent =
    match model.Page with
    | LandingPage ->
      LandingPageView model dispatch
    | DietaryRequirements ->
      DietaryRequirementsPageView model dispatch
    | RSVP ->
      RSVPPageView model dispatch      
    | Done ->
      DonePageView model dispatch    
    | _ ->
       [ div [] [ str "no-view" ] ]

  match model.Page with
  | LandingPage ->
    if model.Ticks < 3 then
      window.setTimeout((fun _ -> dispatch NextTick), 1000, []) |> ignore
    else if model.Ticks < 5 then
      window.setTimeout((fun _ -> dispatch NextTick), 500, []) |> ignore
    else if model.Ticks > 5 then
      window.setTimeout((fun _ -> dispatch <| GoTo DietaryRequirements), 1000, []) |> ignore
    else 
      ()    
  | _ -> ()

  let shouldFadeIn =
    match model.Page with
    | LandingPage -> model.Ticks > 1
    | _               -> true

  match model.Page with
  | WeddingDetails   -> WeddingDetails dispatch
  | PlanningDetails  -> PlanningDetails dispatch
  | Loading          -> div [ Props.Id "LoadingText" ] [ str "Loading visitor details" ]
  | _ ->    
    div [ classList [ (string style?background, true) ] ]

        [ div [ classList [ (string style?side, true) ;
                            (string anim?fadeInLeft, shouldFadeIn) ]]
              viewContent ]