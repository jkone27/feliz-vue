### VNode

```ts
type VNodeChildren = 
  | string
  | VNode
  | VNode[]
  | { [key: string]: Slots }
  | null
  | undefined;

function h(
  type: string | Component,
  props?: Record<string, any> | null,
  children?: VNodeChildren
): VNode
```