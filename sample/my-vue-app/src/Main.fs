open Feliz.Vue
open Fable.Core.JsInterop

importSideEffects "./style.css"

// let app =  Vue.createApp(Components.Counter.vue)

let app = Components.HelloWorld.vue "HELLO"

app.mount("#app")

