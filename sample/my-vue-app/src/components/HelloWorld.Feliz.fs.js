import { Vue_defineComponent, Composition_ref } from "../../../../src/Library.fs.js";
import { ofArray, singleton, ofSeq } from "../fable_modules/fable-library-js.4.25.0/List.js";
import { Interop_mkText, Interop_mkAttr } from "../fable_modules/Feliz.ViewEngine.0.24.0/./Interop.fs.js";
import { IReactProperty, ReactElement } from "../fable_modules/Feliz.ViewEngine.0.24.0/ViewEngine.fs.js";
import { ViewBuilder_escape } from "../fable_modules/Feliz.ViewEngine.0.24.0/./ViewEngine.fs.js";

export function HelloWorld(msg) {
    const count = Composition_ref(0);
    return Vue_defineComponent((_arg) => (new ReactElement(0, ["template", singleton(new IReactProperty(1, [ofSeq([new ReactElement(0, ["div", ofArray([Interop_mkAttr("class", "hello"), new IReactProperty(1, [ofSeq([new ReactElement(0, ["h1", singleton(Interop_mkText(msg))]), new ReactElement(0, ["button", ofArray([Interop_mkAttr("class", "counter"), new IReactProperty(1, [ofSeq([])]), new IReactProperty(1, [ofSeq([new ReactElement(2, [ViewBuilder_escape(`You clicked me ${count.value} times.`)])])])])]), new ReactElement(0, ["p", singleton(Interop_mkText("Edit <code>src/components/HelloWorld.Feliz.fs</code> to test HMR."))])])])])])])]))])));
}

