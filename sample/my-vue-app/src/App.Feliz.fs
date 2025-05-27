module App

open Feliz
open Feliz.Vue
open Components
open Feliz.ViewEngine
open Fable.Core.JsInterop

let vueLogo: string = importDefault "./assets/vue.svg?url"

let comp = (Components.HelloWorld "WORLD")

let view = 
    Html.div [
        Html.div [
            Html.a [
                prop.href "https://vite.dev"
                prop.target "_blank"
                prop.children [
                    Html.img [ 
                        prop.src "/vite.svg"
                        prop.className "logo"
                        prop.alt "Vite logo" 
                    ]
                ]
            ]
            Html.a [
                prop.href "https://vuejs.org/"
                prop.target "_blank"
                prop.children [
                    Html.img [ 
                        prop.src $"{vueLogo}"
                        prop.className "logo vue"
                        prop.alt "Vue logo" 
                    ]
                ]
            ]
        ]
        
        // TODO: next step is integrate components
    ]

