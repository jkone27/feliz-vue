namespace Feliz.Vue

// !!IMPORTANT: Feliz.ViewEngine needs to be extended to support events (road to v1)
// until then it cannot be used for this scope as event props are not
// included in the ReactElement nodes at the time being

/// VHyperScript module provides translation from F# Fable Feliz.ViewEngine DSL
/// to Vue compatible HTML Template synthax as VNode - h function call invocations
module VHyperScript =

    open Feliz.ViewEngine
    open Fable.Core.JsInterop

    /// Build a plain JS props object from Feliz.ViewEngine props
    /// example:
    ///  let vueProps = [ "onClick" ==> onClick; "className" ==> "btn" ] |> createObj
    let inline propsToVObj (props: IReactProperty list) : VProp =

        for p in props do
            printfn $"prop: {p}"

        props
        |> List.collect (function
            | IReactProperty.KeyValue(k, v) -> 
                printfn $"{k} value type: ${v.GetType().FullName}"
                printfn "property: %s , value: %A" k v
                [ k ==> v ]
            | _ -> [ ])
        |> createObj
        |> fun vueObj -> printfn "Vue props: %A" vueObj; vueObj

    /// Extract the immediate children of a ReactElement
    let rec getChildren (el: ReactElement) : ReactElement list =
        match el with
        | Element(_, props)    
        | VoidElement(_, props) ->
            props
            |> List.choose (function 
                IReactProperty.Children ch -> 
                    Some ch 
                | _ -> 
                    None
            )
            |> List.concat
        | ReactElement.Elements els ->
            els |> Seq.collect getChildren |> Seq.toList
        | TextElement _ ->
            [ ]

    /// Recursively convert a `Feliz.ViewEngine.ReactElement` into a `Feliz.Vue.VNode` Vue.h(tag, props, children)
    let rec Render (el: ReactElement) : VNode =
        match el with
        | TextElement txt -> 
            printfn "Rendering TextElement: %s" txt
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
                    Array.append [| txt :> VNode |] children

                Vue.h (tag, propsObj, finalChildren)
            | _ ->
                // Call Vue.h
                Vue.h (tag, propsObj, children)

        | ReactElement.Elements els ->
            // Wrap fragments in a <div>
            els
            |> Seq.map Render
            |> Seq.toArray
            |> box
