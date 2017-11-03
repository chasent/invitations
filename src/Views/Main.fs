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


let PlanningDetails (model: PageState) dispatch =
  div [ ClassName <| string style?DetailsContainer] [
    div [ ClassName <| string style?ColumnOne ] [
      div [] [
        h1 [] [ str "Accommodation" ]
        h2 [] [ str "If you haven't already, please book yourself accommodation soon. Waiheke gets busy and we’d love you to join us!" ]
        div [ ClassName <| string style?EqualColumn ] [
          div [] [
            h3 [] [ str "Baches / Holiday Homes" ]
            Buttons.Bach [ Width "80px" ; Height "80px"]
            br []
            a [] [ str "bookabach.co.nz" ]
            br []
            a [] [ str "airbnb.com" ]
            br []
          ]
          div [] [
            h3 [] [ str "Hostel / Backpackers" ]
            Buttons.Hostel [ Width "80px" ; Height "80px"]
          ]
          div [] [
            h3 [] [ str "Camping" ]
            Buttons.Camping [ Width "80px" ; Height "80px"]
          ]
        ]
      ]
      div [] [
        h1 [] [ str "Getting home from the reception" ]
        h2 [] [ str "You may wish to pre-book a taxi to take you home after the reception at 11pm." ]
      ]
      div [] [
        h1 [] [ str "Ideas for Sunday" ]
        h2 [] [ str "There are lots of cool things to do if you want to explore the Island on Sunday." ]
      ]
    ]
    div [ ClassName <| string style?ColumnTwo ] [
      div [] [
        h1 [] [ str "Getting to the Ceremony" ]
        h2 [] [ str "" ]
        div [ ClassName <| string style?EqualColumn ] [
            div [] [
              h3 [] [ str "Public Transport" ]
              p [] [ str "Get a bus" ]
            ]
            div [] [
              h3 [] [ str "With a Car" ]
              p [] [ str "Just drive there"]
            ]
          ]
      ]
      div [] [
        h1 [] [ str "Getting to the Reception" ]
        h2 [] [ str "" ]
        div [ ClassName <| string style?EqualColumn ] [
            div [] [
              h3 [] [ str "Public Transport" ]
              p [] [ str "Get a bus" ]
            ]
            div [] [
              h3 [] [ str "With a Car" ]
              p [] [ str "Just drive there"]
            ]
          ]
      ]
      div [] [
        h1 [] [ str "Getting to Waiheke Island" ]
        h2 [] [ str "" ]
        div [ ClassName <| string style?EqualColumn ] [
          div [] [
            h3 [] [ str "If you are not bringing a Car" ]
            p [] [ str "Get the car ferry" ]
          ]
          div [] [
            h3 [] [ str "If you are not bringing a Car" ]
            p [] [ str "Get the other ferry"]
          ]
        ]
      ]
    ]
  ]

let WeddingDetails (model: PageState) dispatch =
  div [ ClassName <| string style?mapContainer] [
    div [ ClassName <| string style?mapKey ] [
      h1 [] [ str "10th February 2018" ]
      div [ ClassName <| string style?details ] [
        div [] [
          Buttons.CarFerry
          div [] [
            h2 [] [ strong [] [ str "2:30pm: " ] ; str "Ceremony"]
            div [] [ str "Newton  Reserve - 26 Newton Rd" ]
          ]
        ]
        div [] [
          Buttons.Bus []
          div [] [
            h2 [] [ strong [] [ str "3:30pm: " ] ; str "We’ll provide shuttles to Onetangi Beach"]
          ]
        ]
        div [] [
          Buttons.Rest
          div [] [
            h2 [] [ strong [] [ str "4pm: " ] ; str "Your own time to chill out at Onetangi Beach"]
            div [] [ str "" ]
          ]
        ]
        div [] [
          Buttons.Bus [ Transform "scaleX(-1)" ]
          div [] [
            h2 [] [ strong [] [ str "5:15pm: " ] ; str "We’ll provide shuttles to Casita Miro"]
            div [] [ str "" ]
          ]
        ]
        div [] [
          Buttons.Wine
          div [] [
            h2 [] [ strong [] [ str "5:30pm: " ] ; str "Reception at Casita Miro"]
            div [] [ strong [] [ str "5:30pm: " ] ; str "5:30pm Drinks on the mosaic terrace" ]
            div [] [ strong [] [ str "6:40pm: " ] ; str "6:40pm Dinner + Speeches" ]
            div [] [ strong [] [ str "9:30pm: " ] ; str "9:30pm Music + Dancing" ]
            div [] [ strong [] [ str "11:00pm: " ] ; str "11:00pm Bedtime zzz" ]
          ]
        ]
      ]
      div [ OnClick (fun _ -> dispatch GoToLandingPage)] [ str "Back" ]
    ]

    div [ Ref (fun elem -> map(elem)) ; ClassName <| string style?map] []
  ]

let view (model: Model) dispatch =
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

  match model with
  | WeddingDetails wd   -> WeddingDetails wd dispatch
  | PlanningDetails pd  -> PlanningDetails pd dispatch
  | _ ->    
    div [ classList [ (string style?background, true) ] ]

        [ div [ classList [ (string style?side, true) ;
                            (string anim?fadeInLeft, shouldFadeIn) ]]
              viewContent ]




  // div []
  //     [ Buttons.CarFerry
  //       Buttons.PassengerFerry
  //       Buttons.Rest
  //       Buttons.Rings
  //       Buttons.Wine
  //     ]