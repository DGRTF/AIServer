(window.webpackJsonp=window.webpackJsonp||[]).push([[2],{"/GqU":function(t,n,e){var r=e("RK3t"),o=e("HYAF");t.exports=function(t){return r(o(t))}},"/b8u":function(t,n,e){var r=e("STAE");t.exports=r&&!Symbol.sham&&"symbol"==typeof Symbol.iterator},"/qmn":function(t,n,e){var r=e("2oRo");t.exports=r.Promise},"0BK2":function(t,n){t.exports={}},"0Dky":function(t,n){t.exports=function(t){try{return!!t()}catch(n){return!0}}},"0GbY":function(t,n,e){var r=e("Qo9l"),o=e("2oRo"),i=function(t){return"function"==typeof t?t:void 0};t.exports=function(t,n){return arguments.length<2?i(r[t])||i(o[t]):r[t]&&r[t][n]||o[t]&&o[t][n]}},"0eef":function(t,n,e){"use strict";var r={}.propertyIsEnumerable,o=Object.getOwnPropertyDescriptor,i=o&&!r.call({1:2},1);n.f=i?function(t){var n=o(this,t);return!!n&&n.enumerable}:r},"2oRo":function(t,n,e){(function(n){var e=function(t){return t&&t.Math==Math&&t};t.exports=e("object"==typeof globalThis&&globalThis)||e("object"==typeof window&&window)||e("object"==typeof self&&self)||e("object"==typeof n&&n)||Function("return this")()}).call(this,e("yLpj"))},"6JNq":function(t,n,e){var r=e("UTVS"),o=e("Vu81"),i=e("Bs8V"),u=e("m/L8");t.exports=function(t,n){for(var e=o(n),c=u.f,a=i.f,s=0;s<e.length;s++){var f=e[s];r(t,f)||c(t,f,a(n,f))}}},"8GlL":function(t,n,e){"use strict";var r=e("HAuM"),o=function(t){var n,e;this.promise=new t((function(t,r){if(void 0!==n||void 0!==e)throw TypeError("Bad Promise constructor");n=t,e=r})),this.resolve=r(n),this.reject=r(e)};t.exports.f=function(t){return new o(t)}},"93I0":function(t,n,e){var r=e("VpIT"),o=e("kOOl"),i=r("keys");t.exports=function(t){return i[t]||(i[t]=o(t))}},Bs8V:function(t,n,e){var r=e("g6v/"),o=e("0eef"),i=e("XGwC"),u=e("/GqU"),c=e("wE6v"),a=e("UTVS"),s=e("DPsx"),f=Object.getOwnPropertyDescriptor;n.f=r?f:function(t,n){if(t=u(t),n=c(n,!0),s)try{return f(t,n)}catch(e){}if(a(t,n))return i(!o.f.call(t,n),t[n])}},DPsx:function(t,n,e){var r=e("g6v/"),o=e("0Dky"),i=e("zBJ4");t.exports=!r&&!o((function(){return 7!=Object.defineProperty(i("div"),"a",{get:function(){return 7}}).a}))},HAuM:function(t,n){t.exports=function(t){if("function"!=typeof t)throw TypeError(String(t)+" is not a function");return t}},HYAF:function(t,n){t.exports=function(t){if(null==t)throw TypeError("Can't call method on "+t);return t}},"I+eb":function(t,n,e){var r=e("2oRo"),o=e("Bs8V").f,i=e("kRJp"),u=e("busE"),c=e("zk60"),a=e("6JNq"),s=e("lMq5");t.exports=function(t,n){var e,f,l,p,h,v=t.target,y=t.global,d=t.stat;if(e=y?r:d?r[v]||c(v,{}):(r[v]||{}).prototype)for(f in n){if(p=n[f],l=t.noTargetGet?(h=o(e,f))&&h.value:e[f],!s(y?f:v+(d?".":"#")+f,t.forced)&&void 0!==l){if(typeof p==typeof l)continue;a(p,l)}(t.sham||l&&l.sham)&&i(p,"sham",!0),u(e,f,p,t)}}},I8vh:function(t,n,e){var r=e("ppGB"),o=Math.max,i=Math.min;t.exports=function(t,n){var e=r(t);return e<0?o(e+n,0):i(e,n)}},JBy8:function(t,n,e){var r=e("yoRg"),o=e("eDl+").concat("length","prototype");n.f=Object.getOwnPropertyNames||function(t){return r(t,o)}},QeBL:function(t,n,e){"use strict";e.r(n),e.d(n,"default",(function(){return f}));var r=e("q1tI"),o=e.n(r),i=(e("p532"),e("o0o1")),u=e.n(i);e("ls82");function c(t,n,e,r,o,i,u){try{var c=t[i](u),a=c.value}catch(s){return void e(s)}c.done?n(a):Promise.resolve(a).then(r,o)}var a=e("dI71"),s=(e("RPDD"),function(t){function n(n){var e;return(e=t.call(this,n)||this).state={numberResponse:null},e}Object(a.a)(n,t);var e=n.prototype;return e.render=function(){return o.a.createElement("div",{className:"paint-board"},o.a.createElement("canvas",{className:"paint-board__canvas",width:"400",height:"400",onMouseDown:this.canvas_mousedown.bind(this),onMouseMove:this.canvas_mousemove.bind(this),onMouseOut:this.canvas_mouseout.bind(this),onMouseUp:this.canvas_mouseup.bind(this)}),o.a.createElement("button",{className:"paint-board__send-button",onClick:this.sendCanvas.bind(this)},"Отправить"),o.a.createElement("label",{className:"paint-board__label-response"},"Результат:",o.a.createElement("input",{className:"paint-board__response",readOnly:!0,value:""+(this.state.numberResponse?this.state.numberResponse:"")})))},e.canvas_mousedown=function(t){this.canvas=t.target,this.paint=!0,this.ctx=this.canvas.getContext("2d"),this.ctx.beginPath();var n=this.canvas.getBoundingClientRect(),e=t.clientX-n.left-2,r=t.clientY-n.top-2;this.ctx.moveTo(e,r),this.ctx.lineWidth=25,this.ctx.strokeStyle="white"},e.canvas_mousemove=function(t){if(this.paint){var n=this.canvas.getBoundingClientRect(),e=t.clientX-n.left-2,r=t.clientY-n.top-2;this.ctx.lineTo(e,r),this.ctx.stroke()}},e.canvas_mouseup=function(){this.endDriving()},e.canvas_mouseout=function(){this.ctx&&this.endDriving()},e.endDriving=function(){this.paint=!1,this.ctx.closePath()},e.sendCanvas=function(){var t,n=(t=u.a.mark((function t(n){var e,r,o,i,c=this;return u.a.wrap((function(t){for(;;)switch(t.prev=t.next){case 0:if(!this.canvas){t.next=18;break}return(e=n.target).disabled=!0,t.next=5,new Promise((function(t){return c.canvas.toBlob(t,"image/jpeg")}));case 5:return r=t.sent,(o=new FormData).append("file",r),t.next=11,fetch("/AINumber/DefineNumber",{method:"POST",headers:{},body:o}).finally((function(){e.disabled=!1}));case 11:return i=t.sent,t.t0=this,t.next=15,i.json();case 15:t.t1=t.sent,t.t2={numberResponse:t.t1},t.t0.setState.call(t.t0,t.t2);case 18:case"end":return t.stop()}}),t,this)})),function(){var n=this,e=arguments;return new Promise((function(r,o){var i=t.apply(n,e);function u(t){c(i,r,o,u,a,"next",t)}function a(t){c(i,r,o,u,a,"throw",t)}u(void 0)}))});return function(t){return n.apply(this,arguments)}}(),n}(r.Component));e("pxef");function f(t){return o.a.createElement("div",{className:"home"},o.a.createElement(s,null))}},Qo9l:function(t,n,e){var r=e("2oRo");t.exports=r},RK3t:function(t,n,e){var r=e("0Dky"),o=e("xrYK"),i="".split;t.exports=r((function(){return!Object("z").propertyIsEnumerable(0)}))?function(t){return"String"==o(t)?i.call(t,""):Object(t)}:Object},RPDD:function(t,n,e){},SEBh:function(t,n,e){var r=e("glrk"),o=e("HAuM"),i=e("tiKp")("species");t.exports=function(t,n){var e,u=r(t).constructor;return void 0===u||null==(e=r(u)[i])?n:o(e)}},STAE:function(t,n,e){var r=e("0Dky");t.exports=!!Object.getOwnPropertySymbols&&!r((function(){return!String(Symbol())}))},TWQb:function(t,n,e){var r=e("/GqU"),o=e("UMSQ"),i=e("I8vh"),u=function(t){return function(n,e,u){var c,a=r(n),s=o(a.length),f=i(u,s);if(t&&e!=e){for(;s>f;)if((c=a[f++])!=c)return!0}else for(;s>f;f++)if((t||f in a)&&a[f]===e)return t||f||0;return!t&&-1}};t.exports={includes:u(!0),indexOf:u(!1)}},UMSQ:function(t,n,e){var r=e("ppGB"),o=Math.min;t.exports=function(t){return t>0?o(r(t),9007199254740991):0}},UTVS:function(t,n){var e={}.hasOwnProperty;t.exports=function(t,n){return e.call(t,n)}},VpIT:function(t,n,e){var r=e("xDBR"),o=e("xs3f");(t.exports=function(t,n){return o[t]||(o[t]=void 0!==n?n:{})})("versions",[]).push({version:"3.6.5",mode:r?"pure":"global",copyright:"© 2020 Denis Pushkarev (zloirock.ru)"})},Vu81:function(t,n,e){var r=e("0GbY"),o=e("JBy8"),i=e("dBg+"),u=e("glrk");t.exports=r("Reflect","ownKeys")||function(t){var n=o.f(u(t)),e=i.f;return e?n.concat(e(t)):n}},XGwC:function(t,n){t.exports=function(t,n){return{enumerable:!(1&t),configurable:!(2&t),writable:!(4&t),value:n}}},afO8:function(t,n,e){var r,o,i,u=e("f5p1"),c=e("2oRo"),a=e("hh1v"),s=e("kRJp"),f=e("UTVS"),l=e("93I0"),p=e("0BK2"),h=c.WeakMap;if(u){var v=new h,y=v.get,d=v.has,m=v.set;r=function(t,n){return m.call(v,t,n),n},o=function(t){return y.call(v,t)||{}},i=function(t){return d.call(v,t)}}else{var g=l("state");p[g]=!0,r=function(t,n){return s(t,g,n),n},o=function(t){return f(t,g)?t[g]:{}},i=function(t){return f(t,g)}}t.exports={set:r,get:o,has:i,enforce:function(t){return i(t)?o(t):r(t,{})},getterFor:function(t){return function(n){var e;if(!a(n)||(e=o(n)).type!==t)throw TypeError("Incompatible receiver, "+t+" required");return e}}}},busE:function(t,n,e){var r=e("2oRo"),o=e("kRJp"),i=e("UTVS"),u=e("zk60"),c=e("iSVu"),a=e("afO8"),s=a.get,f=a.enforce,l=String(String).split("String");(t.exports=function(t,n,e,c){var a=!!c&&!!c.unsafe,s=!!c&&!!c.enumerable,p=!!c&&!!c.noTargetGet;"function"==typeof e&&("string"!=typeof n||i(e,"name")||o(e,"name",n),f(e).source=l.join("string"==typeof n?n:"")),t!==r?(a?!p&&t[n]&&(s=!0):delete t[n],s?t[n]=e:o(t,n,e)):s?t[n]=e:u(n,e)})(Function.prototype,"toString",(function(){return"function"==typeof this&&s(this).source||c(this)}))},"dBg+":function(t,n){n.f=Object.getOwnPropertySymbols},"eDl+":function(t,n){t.exports=["constructor","hasOwnProperty","isPrototypeOf","propertyIsEnumerable","toLocaleString","toString","valueOf"]},f5p1:function(t,n,e){var r=e("2oRo"),o=e("iSVu"),i=r.WeakMap;t.exports="function"==typeof i&&/native code/.test(o(i))},"g6v/":function(t,n,e){var r=e("0Dky");t.exports=!r((function(){return 7!=Object.defineProperty({},1,{get:function(){return 7}})[1]}))},glrk:function(t,n,e){var r=e("hh1v");t.exports=function(t){if(!r(t))throw TypeError(String(t)+" is not an object");return t}},hh1v:function(t,n){t.exports=function(t){return"object"==typeof t?null!==t:"function"==typeof t}},iSVu:function(t,n,e){var r=e("xs3f"),o=Function.toString;"function"!=typeof r.inspectSource&&(r.inspectSource=function(t){return o.call(t)}),t.exports=r.inspectSource},kOOl:function(t,n){var e=0,r=Math.random();t.exports=function(t){return"Symbol("+String(void 0===t?"":t)+")_"+(++e+r).toString(36)}},kRJp:function(t,n,e){var r=e("g6v/"),o=e("m/L8"),i=e("XGwC");t.exports=r?function(t,n,e){return o.f(t,n,i(1,e))}:function(t,n,e){return t[n]=e,t}},lMq5:function(t,n,e){var r=e("0Dky"),o=/#|\.prototype\./,i=function(t,n){var e=c[u(t)];return e==s||e!=a&&("function"==typeof n?r(n):!!n)},u=i.normalize=function(t){return String(t).replace(o,".").toLowerCase()},c=i.data={},a=i.NATIVE="N",s=i.POLYFILL="P";t.exports=i},ls82:function(t,n,e){var r=function(t){"use strict";var n=Object.prototype,e=n.hasOwnProperty,r="function"==typeof Symbol?Symbol:{},o=r.iterator||"@@iterator",i=r.asyncIterator||"@@asyncIterator",u=r.toStringTag||"@@toStringTag";function c(t,n,e){return Object.defineProperty(t,n,{value:e,enumerable:!0,configurable:!0,writable:!0}),t[n]}try{c({},"")}catch(_){c=function(t,n,e){return t[n]=e}}function a(t,n,e,r){var o=n&&n.prototype instanceof l?n:l,i=Object.create(o.prototype),u=new E(r||[]);return i._invoke=function(t,n,e){var r="suspendedStart";return function(o,i){if("executing"===r)throw new Error("Generator is already running");if("completed"===r){if("throw"===o)throw i;return k()}for(e.method=o,e.arg=i;;){var u=e.delegate;if(u){var c=b(u,e);if(c){if(c===f)continue;return c}}if("next"===e.method)e.sent=e._sent=e.arg;else if("throw"===e.method){if("suspendedStart"===r)throw r="completed",e.arg;e.dispatchException(e.arg)}else"return"===e.method&&e.abrupt("return",e.arg);r="executing";var a=s(t,n,e);if("normal"===a.type){if(r=e.done?"completed":"suspendedYield",a.arg===f)continue;return{value:a.arg,done:e.done}}"throw"===a.type&&(r="completed",e.method="throw",e.arg=a.arg)}}}(t,e,u),i}function s(t,n,e){try{return{type:"normal",arg:t.call(n,e)}}catch(_){return{type:"throw",arg:_}}}t.wrap=a;var f={};function l(){}function p(){}function h(){}var v={};v[o]=function(){return this};var y=Object.getPrototypeOf,d=y&&y(y(O([])));d&&d!==n&&e.call(d,o)&&(v=d);var m=h.prototype=l.prototype=Object.create(v);function g(t){["next","throw","return"].forEach((function(n){c(t,n,(function(t){return this._invoke(n,t)}))}))}function x(t,n){var r;this._invoke=function(o,i){function u(){return new n((function(r,u){!function r(o,i,u,c){var a=s(t[o],t,i);if("throw"!==a.type){var f=a.arg,l=f.value;return l&&"object"==typeof l&&e.call(l,"__await")?n.resolve(l.__await).then((function(t){r("next",t,u,c)}),(function(t){r("throw",t,u,c)})):n.resolve(l).then((function(t){f.value=t,u(f)}),(function(t){return r("throw",t,u,c)}))}c(a.arg)}(o,i,r,u)}))}return r=r?r.then(u,u):u()}}function b(t,n){var e=t.iterator[n.method];if(void 0===e){if(n.delegate=null,"throw"===n.method){if(t.iterator.return&&(n.method="return",n.arg=void 0,b(t,n),"throw"===n.method))return f;n.method="throw",n.arg=new TypeError("The iterator does not provide a 'throw' method")}return f}var r=s(e,t.iterator,n.arg);if("throw"===r.type)return n.method="throw",n.arg=r.arg,n.delegate=null,f;var o=r.arg;return o?o.done?(n[t.resultName]=o.value,n.next=t.nextLoc,"return"!==n.method&&(n.method="next",n.arg=void 0),n.delegate=null,f):o:(n.method="throw",n.arg=new TypeError("iterator result is not an object"),n.delegate=null,f)}function w(t){var n={tryLoc:t[0]};1 in t&&(n.catchLoc=t[1]),2 in t&&(n.finallyLoc=t[2],n.afterLoc=t[3]),this.tryEntries.push(n)}function S(t){var n=t.completion||{};n.type="normal",delete n.arg,t.completion=n}function E(t){this.tryEntries=[{tryLoc:"root"}],t.forEach(w,this),this.reset(!0)}function O(t){if(t){var n=t[o];if(n)return n.call(t);if("function"==typeof t.next)return t;if(!isNaN(t.length)){var r=-1,i=function n(){for(;++r<t.length;)if(e.call(t,r))return n.value=t[r],n.done=!1,n;return n.value=void 0,n.done=!0,n};return i.next=i}}return{next:k}}function k(){return{value:void 0,done:!0}}return p.prototype=m.constructor=h,h.constructor=p,p.displayName=c(h,u,"GeneratorFunction"),t.isGeneratorFunction=function(t){var n="function"==typeof t&&t.constructor;return!!n&&(n===p||"GeneratorFunction"===(n.displayName||n.name))},t.mark=function(t){return Object.setPrototypeOf?Object.setPrototypeOf(t,h):(t.__proto__=h,c(t,u,"GeneratorFunction")),t.prototype=Object.create(m),t},t.awrap=function(t){return{__await:t}},g(x.prototype),x.prototype[i]=function(){return this},t.AsyncIterator=x,t.async=function(n,e,r,o,i){void 0===i&&(i=Promise);var u=new x(a(n,e,r,o),i);return t.isGeneratorFunction(e)?u:u.next().then((function(t){return t.done?t.value:u.next()}))},g(m),c(m,u,"Generator"),m[o]=function(){return this},m.toString=function(){return"[object Generator]"},t.keys=function(t){var n=[];for(var e in t)n.push(e);return n.reverse(),function e(){for(;n.length;){var r=n.pop();if(r in t)return e.value=r,e.done=!1,e}return e.done=!0,e}},t.values=O,E.prototype={constructor:E,reset:function(t){if(this.prev=0,this.next=0,this.sent=this._sent=void 0,this.done=!1,this.delegate=null,this.method="next",this.arg=void 0,this.tryEntries.forEach(S),!t)for(var n in this)"t"===n.charAt(0)&&e.call(this,n)&&!isNaN(+n.slice(1))&&(this[n]=void 0)},stop:function(){this.done=!0;var t=this.tryEntries[0].completion;if("throw"===t.type)throw t.arg;return this.rval},dispatchException:function(t){if(this.done)throw t;var n=this;function r(e,r){return u.type="throw",u.arg=t,n.next=e,r&&(n.method="next",n.arg=void 0),!!r}for(var o=this.tryEntries.length-1;o>=0;--o){var i=this.tryEntries[o],u=i.completion;if("root"===i.tryLoc)return r("end");if(i.tryLoc<=this.prev){var c=e.call(i,"catchLoc"),a=e.call(i,"finallyLoc");if(c&&a){if(this.prev<i.catchLoc)return r(i.catchLoc,!0);if(this.prev<i.finallyLoc)return r(i.finallyLoc)}else if(c){if(this.prev<i.catchLoc)return r(i.catchLoc,!0)}else{if(!a)throw new Error("try statement without catch or finally");if(this.prev<i.finallyLoc)return r(i.finallyLoc)}}}},abrupt:function(t,n){for(var r=this.tryEntries.length-1;r>=0;--r){var o=this.tryEntries[r];if(o.tryLoc<=this.prev&&e.call(o,"finallyLoc")&&this.prev<o.finallyLoc){var i=o;break}}i&&("break"===t||"continue"===t)&&i.tryLoc<=n&&n<=i.finallyLoc&&(i=null);var u=i?i.completion:{};return u.type=t,u.arg=n,i?(this.method="next",this.next=i.finallyLoc,f):this.complete(u)},complete:function(t,n){if("throw"===t.type)throw t.arg;return"break"===t.type||"continue"===t.type?this.next=t.arg:"return"===t.type?(this.rval=this.arg=t.arg,this.method="return",this.next="end"):"normal"===t.type&&n&&(this.next=n),f},finish:function(t){for(var n=this.tryEntries.length-1;n>=0;--n){var e=this.tryEntries[n];if(e.finallyLoc===t)return this.complete(e.completion,e.afterLoc),S(e),f}},catch:function(t){for(var n=this.tryEntries.length-1;n>=0;--n){var e=this.tryEntries[n];if(e.tryLoc===t){var r=e.completion;if("throw"===r.type){var o=r.arg;S(e)}return o}}throw new Error("illegal catch attempt")},delegateYield:function(t,n,e){return this.delegate={iterator:O(t),resultName:n,nextLoc:e},"next"===this.method&&(this.arg=void 0),f}},t}(t.exports);try{regeneratorRuntime=r}catch(o){Function("r","regeneratorRuntime = r")(r)}},"m/L8":function(t,n,e){var r=e("g6v/"),o=e("DPsx"),i=e("glrk"),u=e("wE6v"),c=Object.defineProperty;n.f=r?c:function(t,n,e){if(i(t),n=u(n,!0),i(e),o)try{return c(t,n,e)}catch(r){}if("get"in e||"set"in e)throw TypeError("Accessors not supported");return"value"in e&&(t[n]=e.value),t}},o0o1:function(t,n,e){t.exports=e("ls82")},p532:function(t,n,e){"use strict";var r=e("I+eb"),o=e("xDBR"),i=e("/qmn"),u=e("0Dky"),c=e("0GbY"),a=e("SEBh"),s=e("zfnd"),f=e("busE");r({target:"Promise",proto:!0,real:!0,forced:!!i&&u((function(){i.prototype.finally.call({then:function(){}},(function(){}))}))},{finally:function(t){var n=a(this,c("Promise")),e="function"==typeof t;return this.then(e?function(e){return s(n,t()).then((function(){return e}))}:t,e?function(e){return s(n,t()).then((function(){throw e}))}:t)}}),o||"function"!=typeof i||i.prototype.finally||f(i.prototype,"finally",c("Promise").prototype.finally)},ppGB:function(t,n){var e=Math.ceil,r=Math.floor;t.exports=function(t){return isNaN(t=+t)?0:(t>0?r:e)(t)}},pxef:function(t,n,e){},tiKp:function(t,n,e){var r=e("2oRo"),o=e("VpIT"),i=e("UTVS"),u=e("kOOl"),c=e("STAE"),a=e("/b8u"),s=o("wks"),f=r.Symbol,l=a?f:f&&f.withoutSetter||u;t.exports=function(t){return i(s,t)||(c&&i(f,t)?s[t]=f[t]:s[t]=l("Symbol."+t)),s[t]}},wE6v:function(t,n,e){var r=e("hh1v");t.exports=function(t,n){if(!r(t))return t;var e,o;if(n&&"function"==typeof(e=t.toString)&&!r(o=e.call(t)))return o;if("function"==typeof(e=t.valueOf)&&!r(o=e.call(t)))return o;if(!n&&"function"==typeof(e=t.toString)&&!r(o=e.call(t)))return o;throw TypeError("Can't convert object to primitive value")}},xDBR:function(t,n){t.exports=!1},xrYK:function(t,n){var e={}.toString;t.exports=function(t){return e.call(t).slice(8,-1)}},xs3f:function(t,n,e){var r=e("2oRo"),o=e("zk60"),i=r["__core-js_shared__"]||o("__core-js_shared__",{});t.exports=i},yLpj:function(t,n){var e;e=function(){return this}();try{e=e||new Function("return this")()}catch(r){"object"==typeof window&&(e=window)}t.exports=e},yoRg:function(t,n,e){var r=e("UTVS"),o=e("/GqU"),i=e("TWQb").indexOf,u=e("0BK2");t.exports=function(t,n){var e,c=o(t),a=0,s=[];for(e in c)!r(u,e)&&r(c,e)&&s.push(e);for(;n.length>a;)r(c,e=n[a++])&&(~i(s,e)||s.push(e));return s}},zBJ4:function(t,n,e){var r=e("2oRo"),o=e("hh1v"),i=r.document,u=o(i)&&o(i.createElement);t.exports=function(t){return u?i.createElement(t):{}}},zfnd:function(t,n,e){var r=e("glrk"),o=e("hh1v"),i=e("8GlL");t.exports=function(t,n){if(r(t),o(n)&&n.constructor===t)return n;var e=i.f(t);return(0,e.resolve)(n),e.promise}},zk60:function(t,n,e){var r=e("2oRo"),o=e("kRJp");t.exports=function(t,n){try{o(r,t,n)}catch(e){r[t]=n}return n}}}]);