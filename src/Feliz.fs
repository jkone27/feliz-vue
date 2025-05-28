namespace Feliz.Vue

// TODO: fix as not working... could simplify rendering of apps / components
module ReactPoc =

    open Feliz.ViewEngine
    open Feliz.Vue

    let toApp(view: ReactElement) : VueApp =
        fun () -> view |> VHyperScript.Render
        |> VueComponent.Create
        |> Vue.createApp

    (* // example in js
        setup(props, { emit, attrs, slots }) {
            const count = ref(0)
            const inc = () => emit('incremented', ++count.value)

            return () =>
                h('button', { ...attrs, onClick: inc }, slots.default?.() ?? `Clicked ${count.value}`)
        }
    *)
    let toReactiveApp(reactiveView: ReactElement, args: VueSetupArgs) : VueApp =
        VueComponent.Create(
            (fun () -> reactiveView |> VHyperScript.Render),
            args
        )
        |> Vue.createApp

