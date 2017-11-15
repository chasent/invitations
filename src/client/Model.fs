module Model

open ServerModel

type Page =
| LandingPage
| DietaryRequirements
| WeddingDetails
| PlanningDetails
| RSVP
| Done
| Loading

type Model = {
    Page     : Page
    Invitees : List<Invitee>
    Ticks    : int
    isLoading: bool
}

type Msg =
| NextTick
| GoToLandingOrDone
| GoTo              of Page
| Attending         of string
| NotAttending      of string
| DairyFree         of string * bool
| GlutenFree        of string * bool
| Vegetarian        of string * bool
| OtherDiet         of string * string
| AddServerState    of ServerModel.Visitor option
| StartSavingDiet
| StartSavingAttending