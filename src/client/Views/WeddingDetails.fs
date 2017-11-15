module View.WeddingDetails

open Model
open Fable.Helpers.React
open Props
open Fable.Import.Browser
open Fable.Core.JsInterop

let ceremonyLink = "https://www.google.co.nz/maps/@-36.7808043,175.0211399,3a,75y,34.74h,84.09t/data=!3m7!1e1!3m5!1s2eiiMvj37ihBQnd3nE_9Bg!2e0!6s%2F%2Fgeo2.ggpht.com%2Fcbk%3Fpanoid%3D2eiiMvj37ihBQnd3nE_9Bg%26output%3Dthumbnail%26cb_client%3Dmaps_sv.tactile.gps%26thumb%3D2%26w%3D203%26h%3D100%26yaw%3D85.96855%26pitch%3D0%26thumbfov%3D100!7i13312!8i6656"
let map = importDefault<Element -> unit> "./GoogleMaps.js" 
let style = importAll<obj> "../styles/main.scss" 
let anim = importAll<obj> "../styles/animation.scss" 


let WeddingDetails dispatch =
  div [ ClassName <| string style?mapContainer] [
    div [ ClassName <| string style?mapKey ] [
      h1 [] [ str "10th February 2018" ]
      div [ ClassName <| string style?details ] [
        div [] [
          Buttons.Rings [ Width "60px" ]
          div [] [
            h2 [] [ strong [] [ str "2:30pm" ] ; str "Ceremony at Newton Rd Picnic Area"]
            div [] [ a [ Target "_blank" ; Href ceremonyLink] [  str "26 Newton Road, Oneroa, Waiheke Island" ] ]
          ]
        ]
        div [] [
          Buttons.Bus [ Width "40px" ]
          div [] [
            h2 [] [ strong [] [ str "3:30pm" ] ; str "We’ll provide shuttles to Onetangi Beach"]
          ]
        ]
        div [] [
          Buttons.Rest [ Width "60px" ]
          div [] [
            h2 [] [ strong [] [ str "4:00pm" ] ; str "Your own time to chill out at Onetangi Beach"]
            div [] [ str "" ]
          ]
        ]
        div [] [
          Buttons.Bus [ Width "40px" ; Transform "scaleX(-1)" ]
          div [] [
            h2 [] [ strong [] [ str "5:15pm" ] ; str "We’ll provide shuttles to Casita Miro"]
            div [] [ str "" ]
          ]
        ]
        div [] [
          Buttons.Wine [ Width "60px" ]
          div [] [
            h2 [] [ strong [] [ str "5:30pm" ] ; str "Reception at Casita Miro"]
            div [] [ a [ Target "_blank" ; Href "https://goo.gl/maps/MXhZ2sXmQWB2" ] [ str "3 Brown Rd, Onetangi, Waiheke Island." ] ]
            div [ Style [ MarginLeft "10px" ] ] [ strong [ Style [ Display "inline-block" ; Width "80px" ] ] [ str "5:30pm" ] ; str "Drinks" ]
            div [ Style [ MarginLeft "10px" ] ] [ strong [ Style [ Display "inline-block" ; Width "80px" ] ] [ str "6:40pm" ] ; str "Dinner" ]
            div [ Style [ MarginLeft "10px" ] ] [ strong [ Style [ Display "inline-block" ; Width "80px" ] ] [ str "9:30pm" ] ; str "Dancing" ]
            div [ Style [ MarginLeft "10px" ] ] [ strong [ Style [ Display "inline-block" ; Width "80px" ] ] [ str "11:00pm" ] ; str "Bedtime" ]
          ]
        ]
      ]
      h1 [ ClassName <| string style?BackButton ; OnClick (fun _ -> dispatch GoToLandingOrDone )] [ str "Click here to go back." ]
    ]

    div [ Ref (fun elem -> map(elem)) ; ClassName <| string style?map] []
  ]
