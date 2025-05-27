namespace Feliz.Vue

open Fable.Core
open Fable.Core.JsInterop
open Feliz.ViewEngine
open System

type VNode = obj
type VProp = obj
type VComponent = obj

/// VueApp type for createApp return
type VueApp =
    abstract mount: string -> unit

type VAttrs = obj
type VSlots = obj
type EmitType = (string * obj array) -> unit

type VueContext = {
    attrs: VAttrs
    slots: VSlots
    emit: EmitType option
    expose: obj option
    exposeTo: string option
}
with static member Create(?attrs: obj, ?slots: obj, ?emit: (string * obj array) -> unit, ?expose: obj, ?exposeTo: string) : VueContext =
        { attrs = attrs; slots = slots; emit = emit; expose = expose; exposeTo = exposeTo }

type VProps = obj

type VueSetupArgs = {
    props: VProps
    ctx: VueContext option
}
with static member Create(?props: VProps, ?ctx: VueContext) : VueSetupArgs =
        { props = props ; ctx = ctx  }

type VueComponent = {
    setup: VueSetupArgs -> (unit -> VNode)
}
with 
    static member ToJs(c: VueComponent) : VComponent = 
        createObj [ "setup" ==> c.setup ]
    static member Create(nodeFunc: unit -> VNode, ?setup: VueSetupArgs) : VComponent = 
        match setup with
        | Some s -> 
            { setup = fun s -> nodeFunc } 
        | None -> 
            { setup = fun _ -> nodeFunc }
        |> VueComponent.ToJs


type VueElement = ReactElement
type IVueProperty = IReactProperty