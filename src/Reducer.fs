module Reducer

open Model

let updateLandingPage (msg: Msg) (state: PageState) =
  match msg with
  | NextTick ->
    LandingPage { state with Ticks = state.Ticks + 1 }
  | Attending attendees ->
    LandingPage { state with Attending = attendees ; Ticks = state.Ticks + 1 }
  | GoToDietaryRequirements ->
    DietaryRequirements { state with Ticks = 0 }
  | DairyFree df ->
    DietaryRequirements { state with DairyFree = df }
  | GlutenFree gf ->
    DietaryRequirements { state with GlutenFree = gf }
  | Vegetarian v ->
    DietaryRequirements { state with Vegetarian = v }
  | OtherDiet od ->
    DietaryRequirements { state with OtherDiet = od }

let update (msg: Msg) (model: Model) =
  match model with
  | LandingPage lp  -> updateLandingPage msg lp
  | DietaryRequirements lp  -> updateLandingPage msg lp
  | _               -> model