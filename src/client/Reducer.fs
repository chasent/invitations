module Reducer

open Model
open ServerModel
open Fable.Import.Browser
open Elmish
open ServerModel
open Elmish.Browser
open ServerModel

open ServerClient

let getPageId =
  let idPart = window.location.href.Split ('#') |> Array.last
  idPart.Substring(1, idPart.Length)

let hasNone invitee =
  match invitee.Attending with
  | Some _ -> false
  | None _ -> true

let saveAttending (model: Model) =
  async {
    let turnIntoDTO invitee =
      let attending =
        match invitee.Attending with
        | Some x -> x
        | None -> false
      (invitee.Id.ToString(), attending)

    let data = List.map turnIntoDTO model.Invitees |> List.toArray

    let! result = server.saveAttending (getPageId, data)
    ()
  }

let saveDiet (model: Model) =
  async {
    let turnIntoDTO invitee =
      (invitee.Id.ToString(), invitee.DairyFree, invitee.GlutenFree, invitee.Vegetarian, invitee.Other)

    let data = List.map turnIntoDTO model.Invitees |> List.toArray

    let! result = server.saveDiet (getPageId, data)
    ()
  }


let update (msg: Msg) (model: Model) =
  match msg with
  | NextTick ->
    { model with Ticks = model.Ticks + 1 }, Cmd.none

  | GoTo page ->
    { model with Page = page ; isLoading = false }, Cmd.none
 
  | GoToLandingOrDone ->
    if List.exists hasNone model.Invitees then
      { model with Page = LandingPage }, Cmd.none
    else
      { model with Page = Done }, Cmd.none

  | Attending name ->
    { model with Invitees = List.map (fun x -> if x.Name = name then { x with Attending = Some true } else x) model.Invitees }, Cmd.none

  | NotAttending name ->
    { model with Invitees = List.map (fun x -> if x.Name = name then { x with Attending = Some false } else x) model.Invitees }, Cmd.none

  | DairyFree (name, df) ->
    { model with Invitees = List.map (fun x -> if x.Name = name then { x with DairyFree = df } else x) model.Invitees }, Cmd.none

  | GlutenFree (name, gf) ->
    { model with Invitees = List.map (fun x -> if x.Name = name then { x with GlutenFree = gf } else x) model.Invitees }, Cmd.none

  | Vegetarian (name, v) ->
    { model with Invitees = List.map (fun x -> if x.Name = name then { x with Vegetarian = v } else x) model.Invitees }, Cmd.none

  | OtherDiet (name, diet) ->
    { model with Invitees = List.map (fun x -> if x.Name = name then { x with Other = diet } else x) model.Invitees }, Cmd.none

  | StartSavingDiet ->
    { model with isLoading = true }, Cmd.ofAsync saveDiet model (fun _ -> GoTo Done) (fun _ -> GoTo DietaryRequirements)

  | StartSavingAttending ->
    { model with isLoading = true }, Cmd.ofAsync saveAttending model (fun _ -> GoTo DietaryRequirements) (fun _ -> GoTo RSVP)

  | AddServerState someVisitor ->
    match someVisitor with
    | Some visitor ->
      let mapPage (page: string) =
        match page with
        | "LandingPage" -> LandingPage
        | "DietaryRequirements" -> DietaryRequirements
        | "WeddingDetails" -> WeddingDetails
        | "PlanningDetails" -> PlanningDetails
        | "RSVP" -> RSVP
        | "Done" -> Done
        | "Loading" -> Loading
        | _ -> LandingPage

      match visitor.Page with
      | Some page ->
        { model with Invitees = visitor.Invitees |> Array.toList ; Page = mapPage page ; isLoading = false }, Cmd.none
      | None ->
        { model with Invitees = visitor.Invitees |> Array.toList ; Page = LandingPage ; isLoading = false }, Cmd.none
 
    | None ->
      model, Cmd.none