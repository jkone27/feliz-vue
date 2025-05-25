module App

open Feliz
open Feliz.Vue
open Components
open Feliz.ViewEngine

let x = Html.div [ ]

(*
// Define root component using only `h`
const App = {
    render() {
        return h('div', { id: 'app' }, 'Hello, World!')
    }
}
}

*)
type App() = 

    interface IVueComponent with 

        member this.render() =

            Html.div [
                Html.div [
                    Html.a [
                        prop.href "https://vite.dev"
                        prop.target "_blank"
                        prop.children [
                            Html.img [ prop.src "/vite.svg"; prop.className "logo"; prop.alt "Vite logo" ]
                        ]
                    ]
                    Html.a [
                        prop.href "https://vuejs.org/"
                        prop.target "_blank"
                        prop.children [
                            Html.img [ 
                                prop.src "./assets/vue.svg"; prop.className "logo vue"; prop.alt "Vue logo" 
                            ]
                        ]
                    ]
                ]
                
                Html.h1 "HELLO VUE 3 + FELIZ + F#"
            ]
            |> H.Render
            
