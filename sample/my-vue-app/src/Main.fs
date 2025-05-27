open Feliz.Vue
open Fable.Core.JsInterop

importSideEffects "./style.css"

// this one works do not touch it, and do not use it for now
let helloWorldVNode = 
    Vue.h("h1", 
        {| |},
        [| "Hello, World!" |]
    ) 

// let app2 () = React.toApp (App.view)

let Counter : VComponent =
    let setup () =
        let count = Vue.ref 0

        let increment () =
            count.value <- count.value + 1

        fun () ->
            Vue.h("button",
              createObj [ "onClick" ==> increment ],
              [| $"Count: {count.value}" |])

    createObj [ "setup" ==> setup ] 

let app =  Vue.createApp(Counter)

app.mount("#app")

