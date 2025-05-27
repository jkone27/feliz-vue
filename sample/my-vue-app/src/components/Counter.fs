module Components.Counter

open Feliz.Vue
open Fable.Core.JsInterop

let vue : VComponent =
    let setup () =
        let count = Vue.ref 0

        let onClick = 
            createObj [ "onClick" ==> fun _ -> count.value <- count.value + 1 ]

        fun () -> Vue.h("button",
            onClick,
            [| $"Count: {count.value}" |])

    createObj [ "setup" ==> setup ] 