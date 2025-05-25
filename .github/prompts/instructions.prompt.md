# Feliz.Vue: Fable Vue.js Bindings Development Specification

## Project Overview
Create F# bindings for Vue.js 3.x that integrate seamlessly with the Feliz DSL pattern, enabling F# developers to build Vue.js applications using familiar Fable tooling.
a bit like https://github.com/fable-compiler/Feliz.JSX for react and solid apps

## Technical Requirements

1. create the simplest possible bindings for Vue.js 3.x
2. use the created bindings in the sample application so that it can run succesfully
3. the sample app is based on `vite create vue@latest` and uses the default template,
   but it should be modified to use the bindings instead of the default Vue.js API
4. the sample app should be a single page application that uses the bindings to create a simple counter app
5. the extension of the original files of the sample vue app is `.original.vue` so you can use it as reference for the corresponding .fs files

### Feliz HTML DSL
- do not get confused with Fable HTML DSL, they are slightly different

### Html vue templates to js render function only
- https://github.com/HCESrl/html-to-vue

### Checking Compilation Errors
- always run first `pwd` , `ls` and `tree -L 4` to see where u are
- check compilation error first always from cli `dotnet build .` in the directory of the `.fsproj` file

### Core Stack
- F# (.fs, .fsproj files)
- .NET SDK 9.0
- Fable 4.x
- Vue.js 3.x
- Feliz.ViewEngine for Feliz DSL
- Vite 5.x with vite-plugin-fable
- Bun package manager

### Project Structure
```
feliz-vue/
├── src/           # Core binding source files
├── sample/        # Example projects using the bindings
```

### Implementation Requirements
1. Vue.js Core Bindings
   - Component composition API
   - Lifecycle hooks
   - Reactive state management
   - Event handling
   - Template directives
   - do not support .vue files, we just need .fs files so use jsx internally

2. Feliz Integration
   - Follow Feliz DSL patterns
   - Type-safe prop definitions
   - Component builder pattern
   - Consistent naming conventions

3. Testing Strategy
   - Unit tests for all bindings
   - Integration tests with Vue.js components
   - Sample application in /sample directory
   - Test coverage minimum: 80%

### Distribution
- NuGet package with semantic versioning
- README with installation and usage instructions
- API documentation following F# formatting guidelines
- Source link enabled for debugging

### Quality Standards
- F# coding conventions
- XML documentation for public APIs
- Comprehensive test coverage
- Performance benchmarks
- Compatibility testing with different Vue.js versions

## Reference Documentation
- Feliz.ViewEngine: https://github.com/dbrattli/Feliz.ViewEngine/blob/master/src/ViewEngine.fs
- https://github.com/dbrattli/Feliz.ViewEngine (this is used explicitly for feliz DSL)
- Feliz.Jsx: https://github.com/fable-compiler/Feliz.JSX (not used atm)
- Vue.js: https://vuejs.org/api
- Binding Guide: https://hashset.dev/article/18_let_s_write_fable_bindings_for_a_js_library
- Vite Plugin: https://fable.io/vite-plugin-fable/
- Fable Jsx: https://fable.io/blog/2022/2022-10-12-react-jsx.html
- Vue Rendering mechanism: https://vuejs.org/guide/extras/rendering-mechanism.html
- Vue Reactivity: https://vuejs.org/guide/extras/reactivity-in-depth.html
- Conversation with GPT on Vue and library: https://chatgpt.com/share/6832f72f-2a10-800e-8b98-fa84736682f7
- https://hox.tunaxor.me/guides/general-usage.html (also can work with feliz dsl, optional)
- Fable: https://fable.io/docs
- Feliz: https://zaid-ajaj.github.io/Feliz (not actually used but DSL is similar)
