namespace Feliz.Vue

/// This module provides translation from F# Fable Feliz.ViewEngine DSL
/// to Vue compatible HTML Template synthax as VNode - h function call invocations
module VHyperScript =

    open Feliz.ViewEngine
    open Fable.Core.JsInterop

    /// Build a plain JS props object from Feliz.ViewEngine props
    /// example:
    ///  let vueProps = [ "onClick" ==> onClick; "className" ==> "btn" ] |> createObj
    let inline propsToVObj (props: IReactProperty list) : VProp =
        props
        |> List.collect (function
            // Map onClick event handler for vue compatibility
            | IReactProperty.KeyValue("onClick", v) -> 
                [ "onClick" ==> v ]
            | IReactProperty.KeyValue(k,v) -> 
                printfn "property: %s , value: %A" k v
                [ k ==> v ]
            | _ -> [ ])
        |> createObj

    /// Extract the immediate children of a ReactElement
    let inline getChildren (el: ReactElement) : ReactElement list =
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

    /// Recursively convert a `Feliz.ViewEngine.ReactElement` into a `Feliz.Vue.VNode` Vue.h(tag, props, children)
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
                let finalChildren = 
                    Array.append [| ((fun () -> txt)()) :> VNode |] children

                Vue.h (tag, propsObj, finalChildren)
            | _ ->
                // Call Vue.h
                Vue.h (tag, propsObj, children)

        | ReactElement.Elements els ->
            // Wrap fragments in a <div>
            let children =
                els
                |> Seq.map Render
                |> Seq.toArray

            Vue.h ("div", (createObj []) ,children)