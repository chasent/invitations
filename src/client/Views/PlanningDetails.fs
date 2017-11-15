module View.PlanningDetails

open Model
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import.Browser
open Fable.Core.JsInterop

let ceremonyLink = "https://www.google.co.nz/maps/@-36.7808043,175.0211399,3a,75y,34.74h,84.09t/data=!3m7!1e1!3m5!1s2eiiMvj37ihBQnd3nE_9Bg!2e0!6s%2F%2Fgeo2.ggpht.com%2Fcbk%3Fpanoid%3D2eiiMvj37ihBQnd3nE_9Bg%26output%3Dthumbnail%26cb_client%3Dmaps_sv.tactile.gps%26thumb%3D2%26w%3D203%26h%3D100%26yaw%3D85.96855%26pitch%3D0%26thumbfov%3D100!7i13312!8i6656"

let style = importAll<obj> "../styles/main.scss" 
let anim = importAll<obj> "../styles/animation.scss" 

let PlanningDetails dispatch =
  div [ ClassName <| string style?DetailsContainer] [
    div [ ClassName <| string style?ColumnOne ] [
      div [] [
        h1 [] [ str "Accommodation" ]
        h2 [] [ str "If you haven't already, please book yourself accommodation soon. Waiheke gets busy and we’d love you to join us!" ]
        div [ ClassName <| string style?EqualColumn ] [
          div [] [
            h3 [] [ str "Baches / Holiday Homes" ]
            div [ ClassName <| string style?SideBySide ] [
              Buttons.Bach [ Width "80px" ; Height "80px"]
              ul [] [
                li [] [ a [ Target "_blank" ; Href "https://www.bookabach.co.nz/" ] [ str "bookabach.co.nz" ] ]
                li [] [ a [ Target "_blank" ; Href "https://www.airbnb.co.nz/"] [ str "Airbnb" ] ]
              ]
            ]            
          ]
          div [] [
            h3 [] [ str "Hostel / Backpackers" ]
            div [ ClassName <| string style?SideBySide ] [
              Buttons.Hostel [ Width "80px" ; Height "80px"]
              ul [] [
                li [] [ a [ Target "_blank" ; Href "http://temp.aucklandcouncil.govt.nz/EN/parksfacilities/accommodationandbookings/Pages/waihekebackpackershostel.aspx" ] [ str "Waiheke Backpacker Hostel" ] ]
                li [] [ a [ Target "_blank" ; Href "http://www.hekerualodge.co.nz/" ] [ str "Hekerua Lodge Hostel" ] ]
              ]
            ]
          ]
          div [] [
            h3 [] [ str "Auckland" ]
            div [ ClassName <| string style?SideBySide ] [
              ul [] [
                li [] [ str "The Reception finishes at 11pm and the last ferry is at 12:30am, so accomodation in Auckland is possible!" ]
              ]
            ]
          ]
        ]
      ]
      div [] [
        h1 [] [ str "Things to do on Sunday" ]
        h2 [] [ str "There are lots of cool things to do if you want to explore the Island on Sunday." ]
        div [ ClassName <| string style?EqualColumn ] [
          div [] [
            h3 [] [ str "Vineyards" ]
            div [ ClassName <| string style?SideBySide ] [
              Buttons.Vineyard [ Width "80px" ; Height "80px"]
              ul [] [
                li [] [ str "Mudbrick" ]
                li [] [ str "Cable Bay" ]
                li [] [ str "Stony Ridge" ]
              ]
            ]            
          ]
          div [] [
            h3 [] [ str "Visit Oneroa" ]
            div [ ClassName <| string style?SideBySide ] [
              Buttons.Oneroa [ Width "80px" ; Height "80px"]
              ul [] [
                li [] [ str "Art Galleries" ]
                li [] [ str "Oneroa Beach" ]
                li [] [ str "Cafes" ]
              ]
            ]
          ]
          div [] [
            h3 [] [ str "Rock Climbing" ]
            div [ ClassName <| string style?SideBySide ] [
              Buttons.RockClimbing [ Width "80px" ; Height "80px"]
              ul [] [
                li [] [ a [ Target "_blank" ; Href "https://static1.squarespace.com/static/546bcdaae4b0f37a26076ff2/t/54bca3cfe4b0276f663dc1d0/1421648847054/Waiheke_Boulder_guide_V1.pdf" ] [ str "Bouldering" ] ]
                li [] [ str "Car required! It is a long drive." ]
              ]
            ]
          ]
        ]
      ]
      div [] [
        h1 [] [ str "Getting home from the reception" ]
        h2 [] [ str "You may wish to pre-book a taxi to take you home after the reception at 11pm." ]
        div [ ClassName <| string style?EqualColumn ] [
          div [] [
            h3 [] [ str "Waiheke Express Taxis" ]
            span [] [ str "0800 700 789" ]
          ]
          div [] [
            h3 [] [ str "Island Taxis" ]
            span [] [ str "09 372 4111" ]
          ]
          div [] [
            h3 [] [ str "Dial-a-driver" ]
            span [] [ str "027 572 6673" ]
          ]
        ]
        div [ ClassName <| string style?GoBack ] [
          h1 [ OnClick (fun _ -> dispatch GoToLandingOrDone )] [ str "Click here to go back." ]
        ]
      ]
    ]
    div [ ClassName <| string style?ColumnTwo ] [
      div [] [
        h1 [] [ str "Getting to the Ceremony" ]
        h2 [] [ a [ Target "_blank" ; Href ceremonyLink] [ str "Newton Road Picnic Area, 26 Newton Road, Oneroa, Waiheke Island." ] ]
        div [ ClassName <| string style?EqualColumn ] [
            div [] [
              h3 [] [ str "Public Transport" ]
              ul [] [
                li [] [
                  str "Catch the "
                  a [ Target "_blank" ; Href "https://www.fullers.co.nz/services/waiheke-bus-company/" ] [ str " No. 2 bus" ]
                  str " to the corner of Queens Dr + Hekerua Rd" ]
                li [] [ str "Walk down Queens Dr + turn onto Newton Rd" ]
                li [] [ str "Walk to the end of Newton Rd" ]
                li [] [ str "Follow the signs along a 50m forest walk to the Newton Reserve" ]
              ]
            ]
            div [] [
              h3 [] [ str "By Car or Taxi" ]
              ul [] [
                li [] [ str "Drive/ taxi to the end of Newton Rd" ]
                li [] [ str "Follow the signs along a 50m forest walk to the Newton Reserve" ]
              ]
            ]
          ]
      ]
      div [] [
        h1 [] [ str "Getting to the Reception" ]
        h2 [] [ a [ Target "_blank" ; Href "https://goo.gl/maps/MXhZ2sXmQWB2" ] [ str "Casita Miro, 3 Brown Rd, Onetangi, Waiheke Island." ] ]
        div [ ClassName <| string style?EqualColumn ] [
            div [] [
              h3 [] [ str "If you are not bringing a Car" ]
              p [] [ str "We will provide shuttles from the ceremony to Onetangi beach, then to Casita Miro." ]
            ]
            div [] [
              h3 [] [ str "If you are bringing a Car" ]
              p [] [ str "You are welcome to make your own way to the reception. The doors open at 5:30pm."]
            ]
          ]
      ]
      div [] [
        h1 [] [ str "Getting to Waiheke Island" ]
        h2 [] [ str "" ]
        div [ ClassName <| string style?EqualColumn ] [
          div [] [
            h3 [] [ str "If you are not bringing a Car" ]
            ul [] [
              li [] [ str "The Fullers passenger ferry leaves from Princes Wharf, Auckland." ]
              li [] [ 
                str "Tickets can be purchased at the ferry terminal and "
                a [ Target "_blank" ; Href "https://www.fullers.co.nz/destinations/waiheke-island/" ] [ str "fullers.co.nz" ]
              ]
              li [] [ str " Approx $36 return, 40 minute sailing" ]
            ]
          ]
          div [] [
            h3 [] [ str "If you are bringing a Car" ]
            ul [] [
              li [] [ str "The Sealink car ferry leaves from Half Moon Bay, Auckland." ]
              li [] [ 
                str "Pre-book tickets online "
                a [ Target "_blank" ; Href "http://www.sealink.co.nz/" ] [ str "sealink.co.nz" ]
              ]              
              li [] [ str " Approx. $170 per car + $36.50 per adult return, 45-60 minute sailing" ] ]
          ]
        ]
      ]
    ]
  ]
