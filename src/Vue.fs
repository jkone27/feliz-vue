namespace Feliz.Vue

/// This module provides bindings for Vue.js 3.x using Feliz and JSX.
module Vue =

    open Fable.Core.JsInterop
    
    let h (tag: string, props: VProp, children: VNode array) : VNode =
        importMember "vue"

    let defineComponent (options: obj) : VComponent =
        importMember "vue"

    let createApp (app: VComponent) : VueApp =
        importMember "vue"

    type VueRef<'T> = { mutable value: 'T }

    let reactive (initial: 'T) : 'T = importMember "vue"
    let ref (value: 'T) : VueRef<'T> = importMember "vue"
    let onMounted (fn: unit -> unit) : unit = importMember "vue"
    let onUnmounted (fn: unit -> unit) : unit = importMember "vue"
    let watch (source: obj) (callback: obj -> unit) : unit = importMember "vue"