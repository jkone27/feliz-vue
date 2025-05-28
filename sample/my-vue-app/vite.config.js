import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'
import fable from 'vite-plugin-fable'
import vueDevTools from 'vite-plugin-vue-devtools'

// https://vite.dev/config/
export default defineConfig({
  plugins: [
    fable({
      fsproj: './src/MyVueApp.fsproj', jsx: 'preserve'
    }),
    vueDevTools(), 
    vue()
  ],
  build: {
    sourcemap: true,
    // asset inlining can be problematic with Fable it seems (?) avoid it for now
    assetsInlineLimit: 0,
  },
  resolve: {
    alias: {
      vue: 'vue/dist/vue.esm-bundler.js'
    }
  }
})
