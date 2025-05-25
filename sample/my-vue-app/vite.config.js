import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'
import fable from 'vite-plugin-fable'

// https://vite.dev/config/
export default defineConfig({
  plugins: [
    fable({
      fsproj: './src/MyVueApp.fsproj', jsx: 'preserve'
    }), 
    vue()
  ],
  build: {
    sourcemap: true
  }
})
