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
open Fable.Core.JsInterop

importSideEffects "./style.css"

// this one works do not touch it, and do not use it for now
let helloWorldVNode = 
    Vue.h("div", 
        {| id = "app" |}, 
        [| "Hello, World!" |]
    ) 

let app = Vue.createAppFromVNode(App.vnode)
app.mount("#app")

