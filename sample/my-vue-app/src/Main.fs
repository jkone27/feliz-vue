open Feliz.Vue
open Fable.Core.JsInterop

importSideEffects "./style.css"

// this one works do not touch it, and do not use it for now
let helloWorldVNode = 
    Vue.h("h1", 
        {| |},
        [| "Hello, World!" |]
    ) 

let app = Vue.createAppFromVNode(App.vnode)
app.mount("#app")

