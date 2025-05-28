open Feliz.Vue
open Fable.Core.JsInterop

importSideEffects "./style.css"

let app =  Vue.createApp(Components.HelloWorld.vue "Hello Reactive!")

app.mount("#app")

