module Yak.Main

open Elmish
open Bolero
open Bolero.Html
open Bolero.Templating.Client

type Model =
    {
        x: string
    }

let initModel =
    {
        x = ""
    }

type Message =
    | Ping
    | Trigger of string

let update message model =
    match message with
    | Ping -> model
    | Trigger s -> { model with x = s }

type Main = Template<"wwwroot/main.html">

let view model dispatch =
    Main()
        .Title($"Title'd be: {model.x}")
        .Trigger(fun _ -> dispatch (Trigger "triggered!"))
        .Elt()

type MyApp() =
    inherit ProgramComponent<Model, Message>()

    override this.Program =
        Program.mkSimple (fun _ -> initModel) update view
#if DEBUG
        |> Program.withHotReload
#endif
