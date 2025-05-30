namespace Components

open Feliz
open Feliz.Vue
open Feliz.ViewEngine
open Fable.Core.JsInterop

module HelloWorldFeliz =

    let vue (msg: string) : VComponent =

        let count = Vue.ref 0

        let onClick _ = 
            count.value <- count.value + 1


        let setup () =
            
            createObj [ 
                "count" ==> count
                "onClick" ==> onClick
            ] 

        let render () =
                Html.div [
                    Html.h1 msg
                    Html.button [
                        prop.className "counter"
                        prop.onClick onClick
                        prop.children [
                            Html.span $"You clicked me {count.value} times."
                        ]
                    ]
                    Html.p [
                        Html.text "Edit "
                        Html.code "HelloWorld.Feliz.fs"
                        Html.text " to test HMR."
                    ]
                ]
                |> VHyperScript.Render


        createObj [ 
            "setup" ==> setup
            "render" ==> render
        ] 