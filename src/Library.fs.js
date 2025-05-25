import { watch, onUnmounted, onMounted, ref, reactive, createApp, defineComponent, h } from "vue";
import { Record } from "../sample/my-vue-app/src/fable_modules/fable-library-js.4.25.0/Types.js";
import { record_type } from "../sample/my-vue-app/src/fable_modules/fable-library-js.4.25.0/Reflection.js";
import { map, collect, empty } from "../sample/my-vue-app/src/fable_modules/fable-library-js.4.25.0/List.js";
import { map as map_1, toList } from "../sample/my-vue-app/src/fable_modules/fable-library-js.4.25.0/Seq.js";
import { toConsole } from "../sample/my-vue-app/src/fable_modules/fable-library-js.4.25.0/String.js";

export const Vue_h = h;

export const Vue_defineComponent = defineComponent;

export const Vue_createApp = createApp;

export class Composition_Ref$1 extends Record {
    constructor(value) {
        super();
        this.value = value;
    }
}

export function Composition_Ref$1_$reflection(gen0) {
    return record_type("Feliz.Vue.Composition.Ref`1", [gen0], Composition_Ref$1, () => [["value", gen0]]);
}

export const Composition_reactive = reactive;

export const Composition_ref = ref;

export const Composition_onMounted = onMounted;

export const Composition_onUnmounted = onUnmounted;

export const Composition_watch = watch;

export function H_getChildrenFromEl(el) {
    switch (el.tag) {
        case 2:
            return empty();
        case 0:
            return collect((_arg_1) => {
                if (_arg_1.tag === 1) {
                    return _arg_1.fields[0];
                }
                else {
                    return empty();
                }
            }, el.fields[1]);
        case 3:
            return toList(el.fields[0]);
        default:
            return collect((_arg) => {
                if (_arg.tag === 1) {
                    return _arg.fields[0];
                }
                else {
                    return empty();
                }
            }, el.fields[1]);
    }
}

export function H_Render(el) {
    const vueChildren = map((el_1) => {
        H_Render(el_1);
    }, H_getChildrenFromEl(el));
    toConsole(`rendering element ${el}`);
    switch (el.tag) {
        case 2: {
            el.fields[0];
            break;
        }
        case 0: {
            Vue_h(el.fields[0], el.fields[1], vueChildren);
            break;
        }
        case 3: {
            map_1((el_2) => {
                H_Render(el_2);
            }, el.fields[0]);
            break;
        }
        default:
            Vue_h(el.fields[0], el.fields[1], vueChildren);
    }
}

