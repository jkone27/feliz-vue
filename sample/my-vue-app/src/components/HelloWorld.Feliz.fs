module Components.HelloWorld

open Feliz
open Feliz.Vue
open Feliz.ViewEngine


let vue (msg: string) =
    let count = Vue.ref 0

    let view =
        Html.div [
            Html.div [
                prop.className "hello"
                prop.children [
                    Html.h1 $"hey: {msg}"
                    Html.button [
                        prop.className "counter"
                        prop.onClick (fun _ -> count.value <- count.value + 1)
                        prop.children [ Html.text $"You clicked me {count} times." ]
                    ]
                    Html.p [
                        prop.children [
                            Html.text "Edit "
                            Html.code "src/components/HelloWorld.Feliz.fs"
                            Html.text " to test HMR."
                        ]
                    ]
                ]
            ]
        ]

    let args = VueSetupArgs.Create(props= {| 
        msg = msg
    |})

    React.toReactiveApp(view, args )