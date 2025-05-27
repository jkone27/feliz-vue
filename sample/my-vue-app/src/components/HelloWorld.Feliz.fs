module Components

open Feliz
open Feliz.Vue
open Feliz.ViewEngine


let HelloWorld (msg: string)  =
    let count = Vue.ref 0

    let view =
        Html.div [
            Html.div [
                prop.className "hello"
                prop.children [
                    Html.h1 $"{msg}"
                    Html.button [
                        prop.className "counter"
                        prop.onClick (fun _ -> count.value <- count.value + 1)
                        prop.children [ Html.text $"You clicked me {count} times." ]
                    ]
                    Html.p "Edit <code>src/components/HelloWorld.Feliz.fs</code> to test HMR."
                ]
            ]
        ]

    let args = VueSetupArgs.Create(props= {| 
        msg = msg
    |})

    React.toReactiveApp(view, args )