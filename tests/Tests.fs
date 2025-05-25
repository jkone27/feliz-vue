module Tests

open System
open Xunit
open Feliz.Vue
open Feliz

[<Fact>]
let ``My test`` () =
    Assert.True(true)

[<Fact>]
let ``ref creates a mutable reference`` () =
    let r = Composition.ref 42
    Assert.Equal(42, r.value)
    r.value <- 100
    Assert.Equal(100, r.value)

[<Fact>]
let ``reactive creates an object with initial state`` () =
    let state = Composition.reactive {| count = 0 |}
    Assert.Equal(0, state.count)

[<Fact>]
let ``defineComponent returns a VueElement`` () =
    let comp = VueBindings.Vue.defineComponent (box {| name = "Test" |})
    Assert.NotNull(comp)

[<Fact>]
let ``createApp returns a VueApp with mount method`` () =
    let comp = VueBindings.Vue.defineComponent (box {| name = "Test" |})
    let app = VueBindings.Vue.createApp comp
    Assert.NotNull(app)
    Assert.True(app.mount ":memory:" |> ignore; true)

[<Fact>]
let ``vue.on creates a custom event property`` () =
    let handlerCalled = ref false
    let handler _ = handlerCalled := true
    let prop = Feliz.vue.on ("click", handler)
    Assert.NotNull(prop)

[<Fact>]
let ``vue.create defines a component with props and setup`` () =
    let comp = vue.create("TestComponent", box {| foo = 1 |}, fun _ -> Html.div [])
    Assert.NotNull(comp)

[<Fact>]
let ``vue.directive creates a custom directive property`` () =
    let prop = vue.directive("model", 42)
    Assert.NotNull(prop)
