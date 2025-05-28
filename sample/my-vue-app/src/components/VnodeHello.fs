module Components.VnodeHello

open Feliz.Vue

let vue = 
    Vue.h("h1", 
        {| |},
        [| "Hello, World!" |]
    ) 