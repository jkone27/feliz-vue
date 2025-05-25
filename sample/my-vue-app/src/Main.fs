(*
// vue  with .vue template files

import { createApp } from 'vue'
import './style.css'
import App from './App.vue'

createApp(App).mount('#app')

// but vue with only hyperscript function h is simpler

import { createApp, h } from 'vue'

// Define root component using only `h`
const App = {
    render() {
        return h('div', { id: 'app' }, 'Hello, World!')
    }
}

// Mount the app to a DOM element
createApp(App).mount('#app')

*)

open Feliz.Vue

// or can we reue here Feliz and adapt it to Vue?
// how does the F# api for Vue look like here?

(*
// in Feliz we have
open Browser.Dom

ReactDOM.render(App(), document.getElementById "root")
*)

let SimpleComponent =
    {| render = fun () -> Vue.h("div", {| id = "app" |}, "Hello, World!") |}

printfn "mounting vue app" //ok
let app = Vue.createApp(SimpleComponent)
app.mount "#app"

printfn "mounted" // ok

