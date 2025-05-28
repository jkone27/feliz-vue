module Components.HelloWorld

open Feliz
open Feliz.Vue
open Feliz.ViewEngine
open Fable.Core.JsInterop

let html str = str

let vue (msg: string) : VComponent =

    let setup () =
        let count = Vue.ref 0

        let onClick _ = 
            count.value <- count.value + 1

        createObj [
            "msg" ==> msg
            "count" ==> count
            "onClick" ==> onClick
        ]

    let template =
        html """
        <div class="hello">
            <h1>{{ msg }}</h1>
            <button @click="onClick" class="counter">
                You clicked me {{ count }} times.
            </button>
            <p>
                Edit <code>HelloWorld.Feliz.fs</code> to test HMR.
            </p>
        </div>
        """


    createObj [ 
        "setup" ==> setup
        "template" ==> template
    ] 