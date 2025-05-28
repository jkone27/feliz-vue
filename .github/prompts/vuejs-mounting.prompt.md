## Vue Mounting Models


1) Vue with only hyperscript function h is simpler (MVP)

```js
import { createApp, h } from 'vue'

// Define root component using only `h`
const App = {
    render() {
        return h('div', { id: 'app' }, 'Hello, World!')
    }
}

// Mount the app to a DOM element
createApp(App).mount('#app')
```


2) vue  with .vue template files

```js
import { createApp } from 'vue'
import './style.css'
import App from './App.vue'

createApp(App).mount('#app')
``