module View.LandingPage

open Fable.Import.Browser
open Fable.Core.JsInterop
open Fable.Helpers.React.Props
open Fable.Helpers.React
open Model

let style = importAll<obj> "../styles/LandingPage.scss" 
let anim = importAll<obj> "../styles/animation.scss" 


let LandingPageView model dispatch =
  [ div [ classList [ (string style?TitleSection, true)                             ;
                      (string anim?invisible,   model.Ticks > 0)                    ;
                      (string anim?fadeInAndUp, model.Ticks > 2 && model.Ticks < 5) ;
                      (string anim?visible,     model.Ticks > 4 && model.Ticks < 6)   ]]

        [ h1 [] [ str "Erin and Marc are getting married." ] ]

    div [ classList [ (string style?LocationSection, true)                        ;
                      (string anim?invisible,   model.Ticks > 0)                    ;
                      (string anim?fadeInAndUp, model.Ticks > 3 && model.Ticks < 5) ;
                      (string anim?visible,     model.Ticks > 4 && model.Ticks < 6)   ]]
        [
            h2 [] [ str "10th February 2018, Waiheke Island" ]
            h3 [] [ str "2:30pm, Ceremony at Newton Reserve" ]
            h3 [] [ str "5:30pm, Reception at Casita Miro" ]
        ]

    div [ classList [ (string style?DetailsSection, true)                     ;
                      (string anim?invisible,   model.Ticks > 0)                    ;
                      (string anim?fadeInAndUp, model.Ticks > 4 && model.Ticks < 5) ;
                      (string anim?visible,     model.Ticks > 4 && model.Ticks < 6)   ]]
        [
            h2 [] [ str "More details about:" ]
            div [] [
                 Buttons.Black (fun _ -> dispatch <| GoTo WeddingDetails) "The Wedding"
                 Buttons.Black (fun _ -> dispatch <| GoTo PlanningDetails) "Planning your Trip"
            ]
         ]

    div [ classList [ (string style?BreifSection, true)                        ;
                      (string anim?invisible,   model.Ticks > 0)                    ;
                      (string anim?fadeInAndUp, model.Ticks > 3 && model.Ticks < 5) ;
                      (string anim?visible,     model.Ticks > 4 && model.Ticks < 6)   ]]
        [ p [] [ str "Please RSVP by 1st January, 2018." ] ]        

    div [ classList [ (string style?RSVPSection, true)                        ;
                      (string anim?invisible,   model.Ticks > 0)                    ;
                      (string anim?fadeInAndUp, model.Ticks > 3 && model.Ticks < 5) ;
                      (string anim?visible,     model.Ticks > 4 && model.Ticks < 6)   ]]
        [
            Buttons.Black (fun _ -> dispatch <| GoTo RSVP) "RSVP"
        ]    

    div [ classList [ (string style?FooterSection, true)                            ;
                      (string anim?invisible,   model.Ticks > 0)                    ;
                      (string anim?fadeInAndUp, model.Ticks > 4 && model.Ticks < 5) ;
                      (string anim?visible,     model.Ticks > 4 && model.Ticks < 6)   ]]
        [
            p [ ] [ str "Due to restrictions at our venue, children are not invited." ]   
        ]]



        // [ Buttons.Black (fun _ -> dispatch <| Attending []) "Yes, we will be attending"

        //   div [ ClassName <| string style?oneAttending ]
        //       [ span [ OnClick (fun _ -> dispatch <| Attending []) ] [ str "Only X will be attending" ]
        //         span [ OnClick (fun _ -> dispatch <| Attending []) ] [ str "Only Y will be attending" ] ]
            
        //   div [ ClassName <| string style?notAttending ]
        //       [ span [OnClick (fun _ -> dispatch <| Attending [])] [ str "We can no longer attend" ] ] ] ]          