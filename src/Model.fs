module Model

type PageState = {
    Ticks       : int           ;
    Attending   : List<string>  ;
    DairyFree   : bool          ;
    GlutenFree  : bool          ;
    Vegetarian  : bool          ;
    OtherDiet   : string        ;
}

type Model =
| LandingPage           of PageState
| DietaryRequirements   of PageState
| WeddingDetails        of PageState
| PlanningDetails       of PageState

type Msg =
| NextTick
| GoToDietaryRequirements
| Attending     of List<string>
| DairyFree     of bool
| GlutenFree    of bool
| Vegetarian    of bool
| OtherDiet     of string