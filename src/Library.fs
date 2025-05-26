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
    open Fable.Core.JsInterop

    /// Build a plain JS props object from Feliz.ViewEngine props
    let inline propsToVObj (props: IReactProperty list) : VProp =
        props
        |> List.choose (function
            | IReactProperty.KeyValue(k,v) -> Some(k,v)
            | _ -> None)
        |> createObj

    /// Extract the immediate children of a ReactElement
    let getChildren (el: ReactElement) : ReactElement list =
        match el with
        | Element(_, props)    
        | VoidElement(_, props) ->
            props
            |> List.choose (function IReactProperty.Children ch -> Some ch | _ -> None)
            |> List.concat
        | ReactElement.Elements els ->
            els |> Seq.toList
        | TextElement _ ->
            [ el ]

    /// Recursively convert a `ReactElement` into a Vue `VNode`
    let rec Render (el: ReactElement) : VNode =
        match el with
        | TextElement txt -> 
            printfn "Rendering React text element: %s" txt
            txt
        | Element(tag, props)
        | VoidElement(tag, props) ->
            printfn $"Render {tag}"
            let propsObj = propsToVObj props
            let children =
                getChildren el
                |> List.map Render
                |> List.toArray

            let textLeaf = 
                props
                |> List.choose (function
                    | IVueProperty.Text txt -> Some txt
                    | _ -> None)
                |> List.tryHead

            match textLeaf with
            | Some txt  -> 
                printfn "render text leaf: %s" txt
                let finalChildrenArray = 
                    if Array.isEmpty children then
                        [| txt :> VNode |]
                    else
                        Array.append [| txt |] children

                Vue.h (tag,propsObj, finalChildrenArray)
            | _ ->
                // Call Vue.h
                Vue.h (tag,propsObj,children)

        | ReactElement.Elements els ->
            // Wrap fragments in a <div>
            let children =
                els
                |> Seq.map Render
                |> Seq.toArray

            Vue.h ("div", (createObj []) ,children)