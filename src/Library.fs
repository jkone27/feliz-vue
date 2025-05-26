namespace Feliz.Vue

open Fable.Core
open Fable.Core.JsInterop
open Feliz.ViewEngine
open System

type VNode = obj
type VProp = obj

/// VueApp type for createApp return
type VueApp =
    abstract mount: string -> unit

type VueComponent = {
        render: unit -> VNode
    }
    with 
        static member ToJs(c: VueComponent) : obj = 
            createObj [ "render" ==> c.render ]
        static member Create(node: VNode) : obj = 
            { render = fun () -> node } 
            |> VueComponent.ToJs
        


type VueElement = ReactElement
type IVueProperty = IReactProperty

/// This module provides bindings for Vue.js 3.x using Feliz and JSX.
module Vue =
    
    let h (tag: string, props: VProp, children: VNode array) : VNode =
        importMember "vue"

    let defineComponent (options: obj) : ReactElement =
        importMember "vue"

    let private createApp (app: obj) : VueApp =
        importMember "vue"

    let createAppFromVNode(node: VNode) : VueApp =
        createApp (VueComponent.Create(node))

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

    // create a fable js literal object from a list of properties
    let inline propsToVObj (props: IReactProperty list) : VProp =
        props
        |> List.collect (fun prop ->
            match prop with
            | IReactProperty.Text _ -> 
                [] // Do not add text as a prop attribute
            | IReactProperty.Children children -> 
                [] // do not map children here, they will be handled separately
            | IReactProperty.KeyValue (k,v) -> 
                [ k,v ]
        )
        |> createObj

    let getChildrenFromEl (el: ReactElement) : ReactElement array =
        match el with
        | VoidElement(_, props) -> 
            props 
            |> List.collect (function | Feliz.ViewEngine.Children children -> children | _ -> [ ])
        | TextElement _ -> 
            [el] // Preserve text elements as children
        | Element(_, props) -> 
            props 
            |> List.collect (function | Feliz.ViewEngine.Children children -> children | _ -> [])
        | ReactElement.Elements(elements) -> 
            elements 
            |> Seq.toList
        |> Seq.toArray

    let rec Render (el: ReactElement) : VNode =
        let reactChildren = getChildrenFromEl el
        let vueChildren = reactChildren |> Array.map Render

        match el with
        | VoidElement(tag, props) ->
            let vProps = props |> propsToVObj
            printfn $"rendering void element {tag} with props {vProps}"
            Vue.h(tag, vProps, vueChildren)
        | TextElement text -> 
            printfn $"rendering text element"
            text // Return text as a string
        | Element(tag, props) ->
            let vProps = props |> propsToVObj
            printfn $"rendering element {tag} with props {vProps}"
            Vue.h(tag, vProps, vueChildren)
        | ReactElement.Elements(elements) ->
            printfn $"rendering nested elements: {elements |> Seq.length}"
            Vue.h("div", [| |], elements |> Seq.map Render |> Array.ofSeq) // Wrap in a div


