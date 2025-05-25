import { Vue_createApp } from "../../../src/Library.fs.js";
import { App_$ctor } from "./App.Feliz.fs.js";

export const app = Vue_createApp(App_$ctor());

app.mount("#app");

