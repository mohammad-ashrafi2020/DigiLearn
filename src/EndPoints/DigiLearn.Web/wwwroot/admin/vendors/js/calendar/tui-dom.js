/*!
 * tui-dom.js
 * @version 3.0.0
 * @author NHNEnt FE Development Lab <dl_javascript@nhnent.com>
 * @license MIT
 */
(function webpackUniversalModuleDefinition(root, factory) {
	if(typeof exports === 'object' && typeof module === 'object')
		module.exports = factory(require("tui-code-snippet"));
	else if(typeof define === 'function' && define.amd)
		define(["tui-code-snippet"], factory);
	else if(typeof exports === 'object')
		exports["dom"] = factory(require("tui-code-snippet"));
	else
		root["tui"] = root["tui"] || {}, root["tui"]["dom"] = factory((root["tui"] && root["tui"]["util"]));
})(this, function(__WEBPACK_EXTERNAL_MODULE_3__) {
return /******/ (function(modules) { // webpackBootstrap
/******/ 	// The module cache
/******/ 	var installedModules = {};

/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {

/******/ 		// Check if module is in cache
/******/ 		if(installedModules[moduleId])
/******/ 			return installedModules[moduleId].exports;

/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = installedModules[moduleId] = {
/******/ 			exports: {},
/******/ 			id: moduleId,
/******/ 			loaded: false
/******/ 		};

/******/ 		// Execute the module function
/******/ 		modules[moduleId].call(module.exports, module, module.exports, __webpack_require__);

/******/ 		// Flag the module as loaded
/******/ 		module.loaded = true;

/******/ 		// Return the exports of the module
/******/ 		return module.exports;
/******/ 	}


/******/ 	// expose the modules object (__webpack_modules__)
/******/ 	__webpack_require__.m = modules;

/******/ 	// expose the module cache
/******/ 	__webpack_require__.c = installedModules;

/******/ 	// __webpack_public_path__
/******/ 	__webpack_require__.p = "dist";

/******/ 	// Load entry module and return exports
/******/ 	return __webpack_require__(0);
/******/ })
/************************************************************************/
/******/ ([
/* 0 */
/***/ (function(module, exports, __webpack_require__) {

	'use strict';

	var _domevent = __webpack_require__(1);

	var domevent = _interopRequireWildcard(_domevent);

	var _domutil = __webpack_require__(2);

	var domutil = _interopRequireWildcard(_domutil);

	var _tuiCodeSnippet = __webpack_require__(3);

	var _tuiCodeSnippet2 = _interopRequireDefault(_tuiCodeSnippet);

	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { 'default': obj }; }

	function _interopRequireWildcard(obj) { if (obj && obj.__esModule) { return obj; } else { var newObj = {}; if (obj != null) { for (var key in obj) { if (Object.prototype.hasOwnProperty.call(obj, key)) newObj[key] = obj[key]; } } newObj['default'] = obj; return newObj; } }

	/**
	 * @fileoverview
	 * @author NHN Ent.
	 *         FE Development Lab <dl_javascript@nhnent.com>
	 * @namespace tui.dom
	 * @desc DOM manipulation utilities
	 * @example
	 * // node, commonjs
	 * var domUtil = require('tui-dom');
	 * domUtil.addClass(element, 'foo', 'bar');
	 * @example
	 * // distribution file, script
	 * <script src='path/to/tui-dom.js'></script>
	 * <script>
	 * var domUtil = tui.dom;
	 * domUtil.addClass(element, 'foo', 'bar');
	 * </script>
	 */
	module.exports = _tuiCodeSnippet2['default'].extend({}, domutil, domevent);

/***/ }),
/* 1 */
/***/ (function(module, exports, __webpack_require__) {

	'use strict';

	exports.__esModule = true;

	var _slicedToArray = function () { function sliceIterator(arr, i) { var _arr = []; var _n = true; var _d = false; var _e = undefined; try { for (var _i = arr[Symbol.iterator](), _s; !(_n = (_s = _i.next()).done); _n = true) { _arr.push(_s.value); if (i && _arr.length === i) break; } } catch (err) { _d = true; _e = err; } finally { try { if (!_n && _i["return"]) _i["return"](); } finally { if (_d) throw _e; } } return _arr; } return function (arr, i) { if (Array.isArray(arr)) { return arr; } else if (Symbol.iterator in Object(arr)) { return sliceIterator(arr, i); } else { throw new TypeError("Invalid attempt to destructure non-iterable instance"); } }; }(); /**
	                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          * DOM event utility module.
	                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          * @fileoverview Module for handle DOM events
	                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          * @author NHN Ent. FE Development Lab <dl_javascript@nhnent.com>
	                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          */


	exports.on = on;
	exports.once = once;
	exports.off = off;
	exports.checkMouse = checkMouse;
	exports._isIE8AndEarlier = _isIE8AndEarlier;
	exports.getMouseButton = getMouseButton;
	exports._getMouseButtonIE8AndEarlier = _getMouseButtonIE8AndEarlier;
	exports.getMousePosition = getMousePosition;

	var _domutil = __webpack_require__(2);

	var _tuiCodeSnippet = __webpack_require__(3);

	var _tuiCodeSnippet2 = _interopRequireDefault(_tuiCodeSnippet);

	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { 'default': obj }; }

	var EVENT_KEY = '_feEventKey';

	/**
	 * @module
	 * @ignore
	 */

	/**
	 * Get event collection for specific HTML element
	 * @param {HTMLElement} element - HTML element
	 * @param {string} [type] - event type
	 * @returns {(object|Map)}
	 */
	function safeEvent(element, type) {
	    var events = element[EVENT_KEY];

	    if (!events) {
	        events = element[EVENT_KEY] = {};
	    }

	    if (type) {
	        var handlerMap = events[type];

	        if (!handlerMap) {
	            handlerMap = events[type] = new _tuiCodeSnippet2['default'].Map();
	        }

	        events = handlerMap;
	    }

	    return events;
	}

	/**
	 * Memorize DOM event handler for unbinding
	 * @param {HTMLElement} element - element to bind events
	 * @param {string} type - events name
	 * @param {function} keyFn - handler function that user passed at on() use
	 * @param {function} valueFn - handler function that wrapped by domevent for
	 *  implementing some features
	 */
	function memorizeHandler(element, type, keyFn, valueFn) {
	    var map = safeEvent(element, type);
	    var items = map.get(keyFn);

	    if (items) {
	        items.push(valueFn);
	    } else {
	        items = [valueFn];
	        map.set(keyFn, items);
	    }
	}

	/**
	 * Forget memorized DOM event handlers
	 * @param {HTMLElement} element - element to bind events
	 * @param {string} type - events name
	 * @param {function} keyFn - handler function that user passed at on() use
	 */
	function forgetHandler(element, type, keyFn) {
	    safeEvent(element, type)['delete'](keyFn);
	}

	/**
	 * Bind DOM events
	 * @param {HTMLElement} element - element to bind events
	 * @param {string} type - events name
	 * @param {function} handler - handler function or context for handler
	 *  method
	 * @param {object} [context] context - context for handler method.
	 */
	function bindEvent(element, type, handler, context) {
	    /**
	     * Event handler
	     * @param {Event} e - event object
	     */
	    function eventHandler(e) {
	        handler.call(context || element, e || window.event);
	    }

	    /**
	     * Event handler for normalize mouseenter event
	     * @param {MouseEvent} e - event object
	     */
	    function mouseEnterHandler(e) {
	        e = e || window.event;

	        if (checkMouse(element, e)) {
	            eventHandler(e);
	        }
	    }

	    if ('addEventListener' in element) {
	        if (type === 'mouseenter' || type === 'mouseleave') {
	            type = type === 'mouseenter' ? 'mouseover' : 'mouseout';
	            element.addEventListener(type, mouseEnterHandler);
	            memorizeHandler(element, type, handler, mouseEnterHandler);
	        } else {
	            element.addEventListener(type, eventHandler);
	            memorizeHandler(element, type, handler, eventHandler);
	        }
	    } else if ('attachEvent' in element) {
	        element.attachEvent('on' + type, eventHandler);
	        memorizeHandler(element, type, handler, eventHandler);
	    }
	}

	/**
	 * Unbind DOM events
	 * @param {HTMLElement} element - element to unbind events
	 * @param {string} type - events name
	 * @param {function} handler - handler function or context for handler
	 *  method
	 */
	function unbindEvent(element, type, handler) {
	    var events = safeEvent(element, type);
	    var items = events.get(handler);

	    if (!items) {
	        return;
	    }

	    forgetHandler(element, type, handler);

	    _tuiCodeSnippet2['default'].forEach(items, function (func) {
	        if ('removeEventListener' in element) {
	            element.removeEventListener(type, func);
	        } else if ('detachEvent' in element) {
	            element.detachEvent('on' + type, func);
	        }
	    });
	}

	/**
	 * Bind DOM events
	 * @param {HTMLElement} element - element to bind events
	 * @param {(string|object)} types - Space splitted events names or
	 *  eventName:handler object
	 * @param {(function|object)} handler - handler function or context for handler
	 *  method
	 * @param {object} [context] context - context for handler method.
	 * @name on
	 * @memberof tui.dom
	 * @function
	 */
	function on(element, types, handler, context) {
	    if (_tuiCodeSnippet2['default'].isString(types)) {
	        _tuiCodeSnippet2['default'].forEach(types.split(/\s+/g), function (type) {
	            bindEvent(element, type, handler, context);
	        });

	        return;
	    }

	    _tuiCodeSnippet2['default'].forEach(types, function (func, type) {
	        bindEvent(element, type, func, handler);
	    });
	}

	/**
	 * Bind DOM event. this event will unbind after invokes.
	 * @param {HTMLElement} element - HTMLElement to bind events.
	 * @param {(string|object)} types - Space splitted events names or
	 *  eventName:handler object.
	 * @param {*} handler - handler function or context for handler method.
	 * @param {*} [context] - context object for handler method.
	 * @name once
	 * @memberof tui.dom
	 * @function
	 */
	function once(element, types, handler, context) {
	    if (_tuiCodeSnippet2['default'].isObject(types)) {
	        var _iteratorNormalCompletion = true;
	        var _didIteratorError = false;
	        var _iteratorError = undefined;

	        try {
	            for (var _iterator = types[Symbol.iterator](), _step; !(_iteratorNormalCompletion = (_step = _iterator.next()).done); _iteratorNormalCompletion = true) {
	                var _step$value = _slicedToArray(_step.value, 2),
	                    fn = _step$value[0],
	                    type = _step$value[1];

	                once(element, type, fn, handler);
	            }
	        } catch (err) {
	            _didIteratorError = true;
	            _iteratorError = err;
	        } finally {
	            try {
	                if (!_iteratorNormalCompletion && _iterator['return']) {
	                    _iterator['return']();
	                }
	            } finally {
	                if (_didIteratorError) {
	                    throw _iteratorError;
	                }
	            }
	        }

	        return;
	    }

	    var onceHandler = function onceHandler() {
	        for (var _len = arguments.length, args = Array(_len), _key = 0; _key < _len; _key++) {
	            args[_key] = arguments[_key];
	        }

	        handler.apply(context || element, args);
	        off(element, types, onceHandler, context);
	    };

	    on(element, types, onceHandler, context);
	}

	/**
	 * Unbind DOM events
	 * @param {HTMLElement} element - element to unbindbind events
	 * @param {(string|object)} types - Space splitted events names or
	 *  eventName:handler object
	 * @param {(function|object)} handler - handler function or context for handler
	 *  method
	 * @name off
	 * @memberof tui.dom
	 * @function
	 */
	function off(element, types, handler) {
	    if (_tuiCodeSnippet2['default'].isString(types)) {
	        _tuiCodeSnippet2['default'].forEach(types.split(/\s+/g), function (type) {
	            unbindEvent(element, type, handler);
	        });

	        return;
	    }

	    _tuiCodeSnippet2['default'].forEach(types, function (func, type) {
	        unbindEvent(element, type, func);
	    });
	}

	/**
	 * Check mouse was leave event element with ignoreing child nodes
	 * @param {HTMLElement} element - element to check
	 * @param {MouseEvent} e - mouse event
	 * @returns {boolean} whether mouse leave element?
	 * @name checkMouse
	 * @memberof tui.dom
	 * @function
	 */
	function checkMouse(element, e) {
	    var related = e.relatedTarget;

	    if (!related) {
	        return true;
	    }

	    try {
	        while (related && related !== element) {
	            related = related.parentNode;
	        }
	    } catch (err) {
	        return false;
	    }

	    return related !== element;
	}

	var primaryButton = ['0', '1', '3', '5', '7'];
	var secondaryButton = ['2', '6'];
	var wheelButton = ['4'];

	var isStandardMouseEvent = !_isIE8AndEarlier();

	/**
	 * test if browser is IE8 and earlier(IE6 or IE7)
	 * @returns {boolean} - whether browser is IE6 ~ 8 or not
	 * @private
	 */
	function _isIE8AndEarlier() {
	    return navigator.userAgent.indexOf('msie 8') > -1 || navigator.userAgent.indexOf('msie 7') > -1 || navigator.userAgent.indexOf('msie 6') > -1;
	}

	/**
	 * Normalize mouse event's button attributes.
	 *
	 * Can detect which button is clicked by this method.
	 *
	 * Meaning of return numbers
	 *
	 * - 0: primary mouse button
	 * - 1: wheel button or center button
	 * - 2: secondary mouse button
	 * @param {MouseEvent} mouseEvent - The mouse event object want to know.
	 * @returns {number} - The value of meaning which button is clicked?
	 * @name getMouseButton
	 * @memberof tui.dom
	 * @function
	 */
	function getMouseButton(mouseEvent) {
	    if (isStandardMouseEvent) {
	        return mouseEvent.button;
	    }

	    return _getMouseButtonIE8AndEarlier(mouseEvent);
	}

	/**
	 * Normalize return value of mouseEvent.button
	 * Make same to standard MouseEvent's button value
	 * @param {DispCEventObj} mouseEvent - mouse event object
	 * @returns {number|null} - id indicating which mouse button is clicked
	 * @private
	 */
	function _getMouseButtonIE8AndEarlier(mouseEvent) {
	    var button = String(mouseEvent.button);

	    if (_tuiCodeSnippet2['default'].inArray(button, primaryButton) > -1) {
	        return 0;
	    } else if (_tuiCodeSnippet2['default'].inArray(button, secondaryButton) > -1) {
	        return 2;
	    } else if (_tuiCodeSnippet2['default'].inArray(button, wheelButton) > -1) {
	        return 1;
	    }

	    return null;
	}

	/**
	 * Get mouse position from mouse event
	 *
	 * If supplied relatveElement parameter then return relative position based on
	 *  element
	 * @param {(MouseEvent|object|number[])} position - mouse position object
	 * @param {HTMLElement} relativeElement HTML element that calculate relative
	 *  position
	 * @returns {number[]} mouse position
	 * @name getMousePosition
	 * @memberof tui.dom
	 * @function
	 */
	function getMousePosition(position, relativeElement) {
	    var isArray = _tuiCodeSnippet2['default'].isArray(position);

	    var clientX = isArray ? position[0] : position.clientX;
	    var clientY = isArray ? position[1] : position.clientY;

	    if (!relativeElement) {
	        return [clientX, clientY];
	    }

	    var rect = (0, _domutil.getRect)(relativeElement);

	    return [clientX - rect.left - relativeElement.clientLeft, clientY - rect.top - relativeElement.clientTop];
	}

/***/ }),
/* 2 */
/***/ (function(module, exports, __webpack_require__) {

	'use strict';

	exports.__esModule = true;
	exports.css = css;
	exports.getClass = getClass;
	exports.hasClass = hasClass;
	exports.addClass = addClass;
	exports.toggleClass = toggleClass;
	exports.removeClass = removeClass;
	exports.getRect = getRect;
	exports.setData = setData;
	exports.getData = getData;
	exports.removeData = removeData;
	exports.removeElement = removeElement;
	exports.setBound = setBound;
	exports.matches = matches;
	exports.closest = closest;
	exports.find = find;
	exports.findAll = findAll;
	exports.stopPropagation = stopPropagation;
	exports.preventDefault = preventDefault;
	exports.disableTextSelection = disableTextSelection;
	exports.enableTextSelection = enableTextSelection;
	exports.textContent = textContent;
	exports.insertAfter = insertAfter;

	var _domevent = __webpack_require__(1);

	var domevent = _interopRequireWildcard(_domevent);

	var _tuiCodeSnippet = __webpack_require__(3);

	var _tuiCodeSnippet2 = _interopRequireDefault(_tuiCodeSnippet);

	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { 'default': obj }; }

	function _interopRequireWildcard(obj) { if (obj && obj.__esModule) { return obj; } else { var newObj = {}; if (obj != null) { for (var key in obj) { if (Object.prototype.hasOwnProperty.call(obj, key)) newObj[key] = obj[key]; } } newObj['default'] = obj; return newObj; } }

	/**
	 * @fileoverview DOM manipulation utility module
	 * @author NHN Ent. FE Development Lab <dl_javascript@nhnent.com>
	 */
	var aps = Array.prototype.slice;
	var trim = function trim(str) {
	    return str.replace(/^[\s\uFEFF\xA0]+|[\s\uFEFF\xA0]+$/g, '');
	};

	/**
	 * Setting element style
	 * @param {(HTMLElement|SVGElement)} element - element to setting style
	 * @param {(string|object)} key - style prop name or {prop: value} pair object
	 * @param {string} [value] - style value
	 * @name css
	 * @memberof tui.dom
	 * @function
	 * @api
	 */
	function css(element, key, value) {
	    var style = element.style;


	    if (_tuiCodeSnippet2['default'].isString(key)) {
	        style[key] = value;

	        return;
	    }

	    _tuiCodeSnippet2['default'].forEach(key, function (v, k) {
	        style[k] = v;
	    });
	}

	/**
	 * Get HTML element's design classes.
	 * @param {(HTMLElement|SVGElement)} element target element
	 * @returns {string} element css class name
	 * @name getClass
	 * @memberof tui.dom
	 * @function
	 * @api
	 */
	function getClass(element) {
	    if (!element || !element.className) {
	        return '';
	    }

	    if (_tuiCodeSnippet2['default'].isUndefined(element.className.baseVal)) {
	        return element.className;
	    }

	    return element.className.baseVal;
	}

	/**
	 * Check element has specific css class
	 * @param {(HTMLElement|SVGElement)} element - target element
	 * @param {string} cssClass - css class
	 * @returns {boolean}
	 * @name hasClass
	 * @memberof tui.dom
	 * @function
	 * @api
	 */
	function hasClass(element, cssClass) {
	    if (element.classList) {
	        return element.classList.contains(cssClass);
	    }

	    var origin = getClass(element).split(/\s+/);

	    return _tuiCodeSnippet2['default'].inArray(cssClass, origin) > -1;
	}

	/**
	 * Set className value
	 * @param {(HTMLElement|SVGElement)} element - target element
	 * @param {(string|string[])} cssClass - class names
	 * @ignore
	 */
	function setClassName(element, cssClass) {
	    cssClass = _tuiCodeSnippet2['default'].isArray(cssClass) ? cssClass.join(' ') : cssClass;

	    cssClass = trim(cssClass);

	    if (_tuiCodeSnippet2['default'].isUndefined(element.className.baseVal)) {
	        element.className = cssClass;
	        return;
	    }

	    element.className.baseVal = cssClass;
	}

	/**
	 * Add css class to element
	 * @param {(HTMLElement|SVGElement)} element - target element
	 * @param {...string} cssClass - css classes to add
	 * @name addClass
	 * @memberof tui.dom
	 * @function
	 */
	function addClass(element) {
	    var cssClass = aps.call(arguments, 1); // eslint-disable-line prefer-rest-params

	    if (element.classList) {
	        var classList = element.classList;

	        _tuiCodeSnippet2['default'].forEach(cssClass, function (name) {
	            classList.add(name);
	        });
	        return;
	    }

	    var origin = getClass(element);

	    if (origin) {
	        cssClass = [].concat(origin.split(/\s+/), cssClass);
	    }

	    var newClass = [];

	    _tuiCodeSnippet2['default'].forEach(cssClass, function (cls) {
	        if (_tuiCodeSnippet2['default'].inArray(cls, newClass) < 0) {
	            newClass.push(cls);
	        }
	    });

	    setClassName(element, newClass);
	}

	/**
	 * Toggle css class
	 * @param {(HTMLElement|SVGElement)} element - target element
	 * @param {...string} cssClass - css classes to toggle
	 * @name toggleClass
	 * @memberof tui.dom
	 * @function
	 */
	function toggleClass(element) {
	    var cssClass = aps.call(arguments, 1); // eslint-disable-line prefer-rest-params

	    if (element.classList) {
	        _tuiCodeSnippet2['default'].forEach(cssClass, function (name) {
	            element.classList.toggle(name);
	        });
	        return;
	    }

	    var newClass = getClass(element).split(/\s+/);

	    _tuiCodeSnippet2['default'].forEach(cssClass, function (name) {
	        var idx = _tuiCodeSnippet2['default'].inArray(name, newClass);

	        if (idx > -1) {
	            newClass.splice(idx, 1);
	        } else {
	            newClass.push(name);
	        }
	    });

	    setClassName(element, newClass);
	}

	/**
	 * Remove css class from element
	 * @param {(HTMLElement|SVGElement)} element - target element
	 * @param {...string} cssClass - css classes to remove
	 * @name removeClass
	 * @memberof tui.dom
	 * @function
	 */
	function removeClass(element) {
	    // eslint-disable-line
	    var cssClass = aps.call(arguments, 1); // eslint-disable-line prefer-rest-params

	    if (element.classList) {
	        var classList = element.classList;

	        _tuiCodeSnippet2['default'].forEach(cssClass, function (name) {
	            classList.remove(name);
	        });

	        return;
	    }

	    var origin = getClass(element).split(/\s+/);

	    var newClass = _tuiCodeSnippet2['default'].filter(origin, function (name) {
	        return _tuiCodeSnippet2['default'].inArray(name, cssClass) < 0;
	    });

	    setClassName(element, newClass);
	}

	/**
	 * getBoundingClientRect polyfill
	 * @param {HTMLElement} element - target element
	 * @returns {object} rect object
	 * @name getRect
	 * @memberof tui.dom
	 * @function
	 */
	function getRect(element) {
	    var rect = element.getBoundingClientRect();
	    var top = rect.top,
	        right = rect.right,
	        bottom = rect.bottom,
	        left = rect.left;
	    var width = rect.width,
	        height = rect.height;


	    if (_tuiCodeSnippet2['default'].isUndefined(width) || _tuiCodeSnippet2['default'].isUndefined(height)) {
	        width = element.offsetWidth;
	        height = element.offsetHeight;
	    }

	    return { top: top, right: right, bottom: bottom, left: left, width: width, height: height };
	}

	/**
	 * Convert uppercase letter to hyphen lowercase character
	 * @param {string} match - match from String.prototype.replace method
	 * @returns {string}
	 * @name upperToHyphenLower
	 * @memberof tui.dom
	 * @function
	 */
	function upperToHyphenLower(match) {
	    return '-' + match.toLowerCase();
	}

	/**
	 * Set data attribute to target element
	 * @param {HTMLElement} element - element to set data attribute
	 * @param {string} key - key
	 * @param {string} value - value
	 * @name setData
	 * @memberof tui.dom
	 * @function
	 */
	function setData(element, key, value) {
	    if (element.dataset) {
	        element.dataset[key] = value;

	        return;
	    }

	    key = key.replace(/([A-Z])/g, upperToHyphenLower);

	    element.setAttribute('data-' + key, value);
	}

	/**
	 * Get data value from data-attribute
	 * @param {HTMLElement} element - target element
	 * @param {string} key - key
	 * @returns {string} value
	 * @name getData
	 * @memberof tui.dom
	 * @function
	 */
	function getData(element, key) {
	    if (element.dataset) {
	        return element.dataset[key];
	    }

	    key = key.replace(/([A-Z])/g, upperToHyphenLower);

	    return element.getAttribute('data-' + key);
	}

	/**
	 * Remove data property
	 * @param {HTMLElement} element - target element
	 * @param {string} key - key
	 * @name removeData
	 * @memberof tui.dom
	 * @function
	 */
	function removeData(element, key) {
	    if (element.dataset) {
	        delete element.dataset[key];

	        return;
	    }

	    key = key.replace(/([A-Z])/g, upperToHyphenLower);

	    element.removeAttribute('data-' + key);
	}

	/**
	 * Remove element from parent node.
	 * @param {HTMLElement} element - element to remove.
	 * @name removeElement
	 * @memberof tui.dom
	 * @function
	 */
	function removeElement(element) {
	    if (element && element.parentNode) {
	        element.parentNode.removeChild(element);
	    }
	}

	/**
	 * Set element bound
	 * @param {HTMLElement} element - element to change bound
	 * @param {object} bound - bound object
	 * @param {number} [bound.top] - top pixel
	 * @param {number} [bound.right] - right pixel
	 * @param {number} [bound.bottom] - bottom pixel
	 * @param {number} [bound.left] - left pixel
	 * @param {number} [bound.width] - width pixel
	 * @param {number} [bound.height] - height pixel
	 * @name setBound
	 * @memberof tui.dom
	 * @function
	 */
	function setBound(element) {
	    var _ref = arguments.length > 1 && arguments[1] !== undefined ? arguments[1] : {},
	        top = _ref.top,
	        right = _ref.right,
	        bottom = _ref.bottom,
	        left = _ref.left,
	        width = _ref.width,
	        height = _ref.height;

	    var args = { top: top, right: right, bottom: bottom, left: left, width: width, height: height };
	    var newBound = {};

	    _tuiCodeSnippet2['default'].forEach(args, function (value, prop) {
	        if (_tuiCodeSnippet2['default'].isExisty(value)) {
	            newBound[prop] = _tuiCodeSnippet2['default'].isNumber(value) ? value + 'px' : value;
	        }
	    });

	    _tuiCodeSnippet2['default'].extend(element.style, newBound);
	}

	var elProto = Element.prototype;
	var matchSelector = elProto.matches || elProto.webkitMatchesSelector || elProto.mozMatchesSelector || elProto.msMatchesSelector || function (selector) {
	    var doc = this.document || this.ownerDocument;
	    return _tuiCodeSnippet2['default'].inArray(this, findAll(doc, selector)) > -1;
	};

	/**
	 * Check element match selector
	 * @param {HTMLElement} element - element to check
	 * @param {string} selector - selector to check
	 * @returns {boolean} is selector matched to element?
	 * @name matches
	 * @memberof tui.dom
	 * @function
	 */
	function matches(element, selector) {
	    return matchSelector.call(element, selector);
	}

	/**
	 * Find parent element recursively
	 * @param {HTMLElement} element - base element to start find
	 * @param {string} selector - selector string for find
	 * @returns {HTMLElement} - element finded or null
	 * @name closest
	 * @memberof tui.dom
	 * @function
	 */
	function closest(element, selector) {
	    var parent = element.parentNode;

	    if (matches(element, selector)) {
	        return element;
	    }

	    while (parent && parent !== document) {
	        if (matches(parent, selector)) {
	            return parent;
	        }

	        parent = parent.parentNode;
	    }

	    return null;
	}

	/**
	 * Find single element
	 * @param {(HTMLElement|string)} [element=document] - base element to find
	 * @param {string} [selector] - css selector
	 * @returns {HTMLElement}
	 * @name find
	 * @memberof tui.dom
	 * @function
	 */
	function find(element, selector) {
	    if (_tuiCodeSnippet2['default'].isString(element)) {
	        return document.querySelector(element);
	    }

	    return element.querySelector(selector);
	}

	/**
	 * Find multiple element
	 * @param {(HTMLElement|string)} [element=document] - base element to
	 *  find
	 * @param {string} [selector] - css selector
	 * @returns {HTMLElement[]}
	 * @name findAll
	 * @memberof tui.dom
	 * @function
	 */
	function findAll(element, selector) {
	    if (_tuiCodeSnippet2['default'].isString(element)) {
	        return _tuiCodeSnippet2['default'].toArray(document.querySelectorAll(element));
	    }

	    return _tuiCodeSnippet2['default'].toArray(element.querySelectorAll(selector));
	}

	/**
	 * Stop event propagation.
	 * @param {Event} e - event object
	 * @name stopPropagation
	 * @memberof tui.dom
	 * @function
	 */
	function stopPropagation(e) {
	    if (e.stopPropagation) {
	        e.stopPropagation();

	        return;
	    }

	    e.cancelBubble = true;
	}

	/**
	 * Prevent default action
	 * @param {Event} e - event object
	 * @name preventDefault
	 * @memberof tui.dom
	 * @function
	 */
	function preventDefault(e) {
	    if (e.preventDefault) {
	        e.preventDefault();

	        return;
	    }

	    e.returnValue = false;
	}

	/**
	 * Check specific CSS style is available.
	 * @param {array} props property name to testing
	 * @returns {(string|boolean)} return true when property is available
	 * @name testCSSProp
	 * @memberof tui.dom
	 * @function
	 * @example
	 * //-- #1. Get Module --//
	 * var domUtil = require('tui-dom'); // node, commonjs
	 * var domUtil = tui.dom; // distribution file
	 *
	 * //-- #2. Use property --//
	 * var props = ['transform', '-webkit-transform'];
	 * domutil.testCSSProp(props);    // 'transform'
	 */
	function testCSSProp(props) {
	    var style = document.documentElement.style;

	    var len = props.length;

	    for (var i = 0; i < len; i += 1) {
	        if (props[i] in style) {
	            return props[i];
	        }
	    }

	    return false;
	}

	var prevSelectStyle = '';
	var SUPPORT_SELECTSTART = 'onselectstart' in document;
	var userSelectProperty = testCSSProp(['userSelect', 'WebkitUserSelect', 'OUserSelect', 'MozUserSelect', 'msUserSelect']);

	/**
	 * Disable browser's text selection behaviors.
	 * @param {HTMLElement} [el] - target element. if not supplied, use `document`
	 * @name disableTextSelection
	 * @memberof tui.dom
	 * @function
	 */
	function disableTextSelection() {
	    var el = arguments.length > 0 && arguments[0] !== undefined ? arguments[0] : document;

	    var style = void 0;

	    if (SUPPORT_SELECTSTART) {
	        domevent.on(el, 'selectstart', preventDefault);
	    } else {
	        el = el === document ? document.documentElement : el;
	        style = el.style;
	        prevSelectStyle = style[userSelectProperty];
	        style[userSelectProperty] = 'none';
	    }
	}

	/**
	 * Enable browser's text selection behaviors.
	 * @param {HTMLElement} [el] - target element. if not supplied, use `document`
	 * @name enableTextSelection
	 * @memberof tui.dom
	 * @function
	 */
	function enableTextSelection() {
	    var el = arguments.length > 0 && arguments[0] !== undefined ? arguments[0] : document;

	    if (SUPPORT_SELECTSTART) {
	        domevent.off(el, 'selectstart', preventDefault);
	    } else {
	        el = el === document ? document.documentElement : el;
	        el.style[userSelectProperty] = prevSelectStyle;
	    }
	}

	/**
	 * Represents the text content of a node and its descendants
	 * @param {HTMLElement} element - html element
	 * @returns {string} text content
	 * @name textContent
	 * @memberof tui.dom
	 * @function
	 */
	function textContent(element) {
	    if (_tuiCodeSnippet2['default'].isExisty(element.textContent)) {
	        return element.textContent;
	    }

	    return element.innerText;
	}

	/**
	 * Insert element to next of target element
	 * @param {HTMLElement} element - html element to insert
	 * @param {HTMLElement} target - target element
	 * @name insertAfter
	 * @memberof tui.dom
	 * @function
	 */
	function insertAfter(element, target) {
	    var parent = target.parentNode;

	    if (target === parent.lastChild) {
	        parent.appendChild(element);
	    } else {
	        parent.insertBefore(element, target.nextSibling);
	    }
	}

/***/ }),
/* 3 */
/***/ (function(module, exports) {

	module.exports = __WEBPACK_EXTERNAL_MODULE_3__;

/***/ })
/******/ ])
});
;