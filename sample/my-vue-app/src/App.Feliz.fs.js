import { singleton, ofArray, ofSeq, empty } from "./fable_modules/fable-library-js.4.25.0/List.js";
import { IReactProperty, ReactElement } from "./fable_modules/Feliz.ViewEngine.0.24.0/ViewEngine.fs.js";
import { H_Render } from "../../../src/Library.fs.js";
import { Interop_mkText, Interop_mkAttr } from "./fable_modules/Feliz.ViewEngine.0.24.0/./Interop.fs.js";
import { class_type } from "./fable_modules/fable-library-js.4.25.0/Reflection.js";

export const x = new ReactElement(0, ["div", empty()]);

export class App {
    constructor() {
    }
    render() {
        H_Render(new ReactElement(0, ["div", singleton(new IReactProperty(1, [ofSeq([new ReactElement(0, ["div", singleton(new IReactProperty(1, [ofSeq([new ReactElement(0, ["a", ofArray([Interop_mkAttr("href", "https://vite.dev"), Interop_mkAttr("target", "_blank"), new IReactProperty(1, [ofSeq([new ReactElement(1, ["img", ofArray([Interop_mkAttr("src", "/vite.svg"), Interop_mkAttr("class", "logo"), Interop_mkAttr("alt", "Vite logo")])])])])])]), new ReactElement(0, ["a", ofArray([Interop_mkAttr("href", "https://vuejs.org/"), Interop_mkAttr("target", "_blank"), new IReactProperty(1, [ofSeq([new ReactElement(1, ["img", ofArray([Interop_mkAttr("src", "./assets/vue.svg"), Interop_mkAttr("class", "logo vue"), Interop_mkAttr("alt", "Vue logo")])])])])])])])]))]), new ReactElement(0, ["h1", singleton(Interop_mkText("HELLO VUE 3 + FELIZ + F#"))])])]))]));
    }
}

export function App_$reflection() {
    return class_type("App.App", undefined, App);
}

export function App_$ctor() {
    return new App();
}

