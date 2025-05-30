namespace Feliz.ViewEngine

// extend ReactElement union
// type ReactElement = 
//     | ReactElement.Element


module prop =

    open Feliz.Vue

    let vnode (vnode: VNode) : IReactProperty =  
        vnode.ToString() |> IReactProperty.Text