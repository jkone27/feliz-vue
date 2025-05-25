namespace Feliz.Vue

open Fable.Core
open Fable.Core.JsInterop
open Feliz.ViewEngine
open System

[<Erase>]
type VNode = obj

/// VueApp type for createApp return
[<Erase>]
type VueApp =
    abstract mount: string -> unit

[<Erase>]
type IVueComponent =
    abstract render: unit -> VNode

[<Erase>]
type VueElement = ReactElement

[<Erase>]
type IVueProperty = IReactProperty

/// This module provides bindings for Vue.js 3.x using Feliz and JSX.
[<Erase>]
module Vue =
    
    let h (tag: string, props: obj, children: obj) : VNode =
        importMember "vue"

    let defineComponent (options: obj) : ReactElement =
        importMember "vue"

    let createApp (app: obj) : VueApp =
        importMember "vue"


/// Provides bindings for Vue.js 3.x Composition API.=
module Composition =
    type Ref<'T> = { mutable value: 'T }

    let reactive (initial: 'T) : 'T = importMember "vue"
    let ref (value: 'T) : Ref<'T> = importMember "vue"
    let onMounted (fn: unit -> unit) : unit = importMember "vue"
    let onUnmounted (fn: unit -> unit) : unit = importMember "vue"
    let watch (source: obj) (callback: obj -> unit) : unit = importMember "vue"

module H =

    open Feliz.ViewEngine
    open Feliz.ViewEngine.prop

    let getChildrenFromEl (el: ReactElement) : ReactElement list =
        match el with
        | VoidElement(_, props) -> 
            props |> List.collect (function | Feliz.ViewEngine.Children children -> children | _ -> [ ])
        | TextElement _ -> []
        | Element(_, props) -> 
            props |> List.collect (function | Feliz.ViewEngine.Children children -> children | _ -> [])
        | ReactElement.Elements(elements) -> 
            elements |> Seq.toList

    let rec Render (el: ReactElement) : VNode =
        
        let reactChildren = getChildrenFromEl el
        let vueChildren = reactChildren |> List.map Render

        printfn $"rendering element {el}"

        match el with
        | VoidElement(tag, props) ->
            Vue.h(tag, props, vueChildren)
        | TextElement text -> unbox text
        | Element(tag, props) ->
            Vue.h(tag, props, vueChildren)
        | ReactElement.Elements(elements) ->
            elements |> Seq.map Render :?> VNode
            

