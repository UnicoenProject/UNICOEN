(function (window, document, Math, nop, undef){
	var debug = 	(function (){
		if ("console" in window){
			return 			(function (msg){
				window.console.log('Processing.js: ' + msg);
			});
		}		else
{
			return nop();
		}
	})();
	var ajax = 	(function (url){
		var xhr = new XMLHttpRequest();
		xhr.open("GET", url, false);
		if (xhr.overrideMimeType){
			xhr.overrideMimeType("text/plain");
		}
		xhr.setRequestHeader("If-Modified-Since", "Fri, 01 Jan 1960 00:00:00 GMT");
		xhr.send(null);
		if ((xhr.status !== 200) && (xhr.status !== 0)){
			throw "XMLHttpRequest failed, status code " + xhr.status;
		}
		return xhr.responseText;
	});
	var isDOMPresent = ("document" in this) && !("fake" in this.document);
		(function fixOperaCreateImageData(){
		try{
			if (!("createImageData" in CanvasRenderingContext2D.prototype)){
				CanvasRenderingContext2D.prototype.createImageData = 				(function (sw, sh){
					return new ImageData(sw, sh);
				});
			}
		}catch( e ){
		}
	})();
		function setupTypedArray(name, fallback){
		if (name in window){
			return window[name];
		}
		if (typeofwindow[fallback] === "function"){
			return window[fallback];
		}		else
{
			return 			(function (obj){
				if (obj instanceof Array){
					return obj;
				}				else
{
					if (typeofobj === "number"){
						var arr = [];
						arr.length = obj;
						return arr;
					}
				}
			});
		}
	}
	var Float32Array = setupTypedArray("Float32Array", "WebGLFloatArray"); var Int32Array = setupTypedArray("Int32Array", "WebGLIntArray"); var Uint16Array = setupTypedArray("Uint16Array", "WebGLUnsignedShortArray"); var Uint8Array = setupTypedArray("Uint8Array", "WebGLUnsignedByteArray");
	var PConstants = {	X:0, 	Y:1, 	Z:2, 	R:3, 	G:4, 	B:5, 	A:6, 	U:7, 	V:8, 	NX:9, 	NY:10, 	NZ:11, 	EDGE:12, 	SR:13, 	SG:14, 	SB:15, 	SA:16, 	SW:17, 	TX:18, 	TY:19, 	TZ:20, 	VX:21, 	VY:22, 	VZ:23, 	VW:24, 	AR:25, 	AG:26, 	AB:27, 	DR:3, 	DG:4, 	DB:5, 	DA:6, 	SPR:28, 	SPG:29, 	SPB:30, 	SHINE:31, 	ER:32, 	EG:33, 	EB:34, 	BEEN_LIT:35, 	VERTEX_FIELD_COUNT:36, 	P2D:1, 	JAVA2D:1, 	WEBGL:2, 	P3D:2, 	OPENGL:2, 	PDF:0, 	DXF:0, 	OTHER:0, 	WINDOWS:1, 	MAXOSX:2, 	LINUX:3, 	EPSILON:0.0001, 	MAX_FLOAT:3.4028235E+38, 	MIN_FLOAT:-3.4028235E+38, 	MAX_INT:2147483647, 	MIN_INT:-2147483648, 	PI:Math.PI, 	TWO_PI:2 * Math.PI, 	HALF_PI:Math.PI / 2, 	THIRD_PI:Math.PI / 3, 	QUARTER_PI:Math.PI / 4, 	DEG_TO_RAD:Math.PI / 180, 	RAD_TO_DEG:180 / Math.PI, 	WHITESPACE:" \t\n\r\f\u00A0", 	RGB:1, 	ARGB:2, 	HSB:3, 	ALPHA:4, 	CMYK:5, 	TIFF:0, 	TARGA:1, 	JPEG:2, 	GIF:3, 	BLUR:11, 	GRAY:12, 	INVERT:13, 	OPAQUE:14, 	POSTERIZE:15, 	THRESHOLD:16, 	ERODE:17, 	DILATE:18, 	REPLACE:0, 	BLEND:1 << 0, 	ADD:1 << 1, 	SUBTRACT:1 << 2, 	LIGHTEST:1 << 3, 	DARKEST:1 << 4, 	DIFFERENCE:1 << 5, 	EXCLUSION:1 << 6, 	MULTIPLY:1 << 7, 	SCREEN:1 << 8, 	OVERLAY:1 << 9, 	HARD_LIGHT:1 << 10, 	SOFT_LIGHT:1 << 11, 	DODGE:1 << 12, 	BURN:1 << 13, 	ALPHA_MASK:-16777216, 	RED_MASK:16711680, 	GREEN_MASK:65280, 	BLUE_MASK:255, 	CUSTOM:0, 	ORTHOGRAPHIC:2, 	PERSPECTIVE:3, 	POINT:2, 	POINTS:2, 	LINE:4, 	LINES:4, 	TRIANGLE:8, 	TRIANGLES:9, 	TRIANGLE_STRIP:10, 	TRIANGLE_FAN:11, 	QUAD:16, 	QUADS:16, 	QUAD_STRIP:17, 	POLYGON:20, 	PATH:21, 	RECT:30, 	ELLIPSE:31, 	ARC:32, 	SPHERE:40, 	BOX:41, 	GROUP:0, 	PRIMITIVE:1, 	GEOMETRY:3, 	VERTEX:0, 	BEZIER_VERTEX:1, 	CURVE_VERTEX:2, 	BREAK:3, 	CLOSESHAPE:4, 	OPEN:1, 	CLOSE:2, 	CORNER:0, 	CORNERS:1, 	RADIUS:2, 	CENTER_RADIUS:2, 	CENTER:3, 	DIAMETER:3, 	CENTER_DIAMETER:3, 	BASELINE:0, 	TOP:101, 	BOTTOM:102, 	NORMAL:1, 	NORMALIZED:1, 	IMAGE:2, 	MODEL:4, 	SHAPE:5, 	SQUARE:'butt', 	ROUND:'round', 	PROJECT:'square', 	MITER:'miter', 	BEVEL:'bevel', 	AMBIENT:0, 	DIRECTIONAL:1, 	SPOT:3, 	BACKSPACE:8, 	TAB:9, 	ENTER:10, 	RETURN:13, 	ESC:27, 	DELETE:127, 	CODED:-1, 	SHIFT:16, 	CONTROL:17, 	ALT:18, 	CAPSLK:20, 	PGUP:33, 	PGDN:34, 	END:35, 	HOME:36, 	LEFT:37, 	UP:38, 	RIGHT:39, 	DOWN:40, 	F1:112, 	F2:113, 	F3:114, 	F4:115, 	F5:116, 	F6:117, 	F7:118, 	F8:119, 	F9:120, 	F10:121, 	F11:122, 	F12:123, 	NUMLK:144, 	META:157, 	INSERT:155, 	ARROW:'default', 	CROSS:'crosshair', 	HAND:'pointer', 	MOVE:'move', 	TEXT:'text', 	WAIT:'wait', 	NOCURSOR:"url('data:image/gif;base64,R0lGODlhAQABAIAAAP///wAAACH5BAEAAAAALAAAAAABAAEAAAICRAEAOw=='), auto", 	DISABLE_OPENGL_2X_SMOOTH:1, 	ENABLE_OPENGL_2X_SMOOTH:-1, 	ENABLE_OPENGL_4X_SMOOTH:2, 	ENABLE_NATIVE_FONTS:3, 	DISABLE_DEPTH_TEST:4, 	ENABLE_DEPTH_TEST:-4, 	ENABLE_DEPTH_SORT:5, 	DISABLE_DEPTH_SORT:-5, 	DISABLE_OPENGL_ERROR_REPORT:6, 	ENABLE_OPENGL_ERROR_REPORT:-6, 	ENABLE_ACCURATE_TEXTURES:7, 	DISABLE_ACCURATE_TEXTURES:-7, 	HINT_COUNT:10, 	SINCOS_LENGTH:parseInt(360 / 0.5, 10), 	PRECISIONB:15, 	PRECISIONF:1 << 15, 	PREC_MAXVAL:(1 << 15) - 1, 	PREC_ALPHA_SHIFT:24 - 15, 	PREC_RED_SHIFT:16 - 15, 	NORMAL_MODE_AUTO:0, 	NORMAL_MODE_SHAPE:1, 	NORMAL_MODE_VERTEX:2, 	MAX_LIGHTS:8	};
		function virtHashCode(obj){
		if (obj.constructor === String){
			var hash = 0;
			for(var i = 0; i < obj.length;++i){
				hash = (((hash * 31) + obj.charCodeAt(i)) & -1);
			}
			return hash;
		}		else
{
			if (typeofobj !== "object"){
				return obj & -1;
			}			else
{
				if (obj.hashCode instanceof Function){
					return obj.hashCode();
				}				else
{
					if (obj.$id === undef){
						obj.$id = (((Math.floor(Math.random() * 65536) - -32768) << 16) | Math.floor(Math.random() * 65536));
					}
					return obj.$id;
				}
			}
		}
	}
		function virtEquals(obj, other){
		if ((obj === null) || (other === null)){
			return (obj === null) && (other === null);
		}		else
{
			if (obj.constructor === String){
				return obj === other;
			}			else
{
				if (typeofobj !== "object"){
					return obj === other;
				}				else
{
					if (obj.equals instanceof Function){
						return obj.equals(other);
					}					else
{
						return obj === other;
					}
				}
			}
		}
	}
	var ObjectIterator = 	(function (obj){
		if (obj.iterator instanceof Function){
			return obj.iterator();
		}		else
{
			if (obj instanceof Array){
				var index = -1;
				this.hasNext = 				(function (){
					return ++index < obj.length;
				});
				this.next = 				(function (){
					return obj[index];
				});
			}			else
{
				throw "Unable to iterate: " + obj;
			}
		}
	});
	var ArrayList = 	(function (){
				function Iterator(array){
			var index = 0;
			this.hasNext = 			(function (){
				return index < array.length;
			});
			this.next = 			(function (){
				return array[index++];
			});
			this.remove = 			(function (){
				array.splice(index, 1);
			});
		}
				function ArrayList(){
			var array;
			if (arguments.length === 0){
				array = [];
			}			else
{
				if ((arguments.length > 0) && (typeofarguments[0] !== 'number')){
					array = arguments[0];
				}				else
{
					array = [];
					array.length = (0 | arguments[0]);
				}
			}
			this.get = 			(function (i){
				return array[i];
			});
			this.contains = 			(function (item){
				return this.indexOf(item) > -1;
			});
			this.indexOf = 			(function (item){
				for(var i = 0, len = array.length; i < len;++i){
					if (virtEquals(item, array[i])){
						return i;
					}
				}
				return -1;
			});
			this.add = 			(function (){
				if (arguments.length === 1){
					array.push(arguments[0]);
				}				else
{
					if (arguments.length === 2){
						var arg0 = arguments[0];
						if (typeofarg0 === 'number'){
							if ((arg0 >= 0) && (arg0 <= array.length)){
								array.splice(arg0, 0, arguments[1]);
							}							else
{
								throw arg0 + " is not a valid index";
							}
						}						else
{
							throw typeofarg0 + " is not a number";
						}
					}					else
{
						throw "Please use the proper number of parameters.";
					}
				}
			});
			this.addAll = 			(function (arg1, arg2){
				var it;
				if (typeofarg1 === "number"){
					if ((arg1 < 0) || (arg1 > array.length)){
						throw (("Index out of bounds for addAll: " + arg1) + " greater or equal than ") + array.length;
					}
					it = new ObjectIterator(arg2);
					while(it.hasNext()){
						array.splice(arg1++, 0, it.next());
					}
				}				else
{
					it = new ObjectIterator(arg1);
					while(it.hasNext()){
						array.push(it.next());
					}
				}
			});
			this.set = 			(function (){
				if (arguments.length === 2){
					var arg0 = arguments[0];
					if (typeofarg0 === 'number'){
						if ((arg0 >= 0) && (arg0 < array.length)){
							array.splice(arg0, 1, arguments[1]);
						}						else
{
							throw arg0 + " is not a valid index.";
						}
					}					else
{
						throw typeofarg0 + " is not a number";
					}
				}				else
{
					throw "Please use the proper number of parameters.";
				}
			});
			this.size = 			(function (){
				return array.length;
			});
			this.clear = 			(function (){
				array.length = 0;
			});
			this.remove = 			(function (item){
				if (typeofitem === 'number'){
					return array.splice(item, 1)[0];
				}				else
{
					item = this.indexOf(item);
					if (item > -1){
						array.splice(item, 1);
						return true;
					}
					return false;
				}
			});
			this.isEmpty = 			(function (){
				return !array.length;
			});
			this.clone = 			(function (){
				return new ArrayList(array.slice(0));
			});
			this.toArray = 			(function (){
				return array.slice(0);
			});
			this.iterator = 			(function (){
				return new Iterator(array);
			});
		}
		return ArrayList;
	})();
	var HashMap = 	(function (){
				function HashMap(){
			if ((arguments.length === 1) && (arguments[0].constructor === HashMap)){
				return arguments[0].clone();
			}
			var initialCapacity = (arguments.length > 0) ? arguments[0] : 16;
			var loadFactor = (arguments.length > 1) ? arguments[1] : 0.75;
			var buckets = [];
			buckets.length = initialCapacity;
			var count = 0;
			var hashMap = this;
						function getBucketIndex(key){
				var index = virtHashCode(key) % buckets.length;
				return (index < 0) ? (buckets.length + index) : index;
			}
						function ensureLoad(){
				if (count <= (loadFactor * buckets.length)){
					return ;
				}
				var allEntries = [];
				for(var i = 0; i < buckets.length;++i){
					if (buckets[i] !== undef){
						allEntries = allEntries.concat(buckets[i]);
					}
				}
				var newBucketsLength = buckets.length * 2;
				buckets = [];
				buckets.length = newBucketsLength;
				for(var j = 0; j < allEntries.length;++j){
					var index = getBucketIndex(allEntries[j].key);
					var bucket = buckets[index];
					if (bucket === undef){
						buckets[index] = (bucket = []);
					}
					bucket.push(allEntries[j]);
				}
			}
						function Iterator(conversion, removeItem){
				var bucketIndex = 0;
				var itemIndex = -1;
				var endOfBuckets = false;
								function findNext(){
					while(!endOfBuckets){
						++itemIndex;
						if (bucketIndex >= buckets.length){
							endOfBuckets = true;
						}						else
{
							if ((buckets[bucketIndex] === undef) || (itemIndex >= buckets[bucketIndex].length)){
								itemIndex = -1;
								++bucketIndex;
							}							else
{
								return ;
							}
						}
					}
				}
				this.hasNext = 				(function (){
					return !endOfBuckets;
				});
				this.next = 				(function (){
					var result = conversion(buckets[bucketIndex][itemIndex]);
					findNext();
					return result;
				});
				this.remove = 				(function (){
					removeItem(this.next());
					--itemIndex;
				});
				findNext();
			}
						function Set(conversion, isIn, removeItem){
				this.clear = 				(function (){
					hashMap.clear();
				});
				this.contains = 				(function (o){
					return isIn(o);
				});
				this.containsAll = 				(function (o){
					var it = o.iterator();
					while(it.hasNext()){
						if (!this.contains(it.next())){
							return false;
						}
					}
					return true;
				});
				this.isEmpty = 				(function (){
					return hashMap.isEmpty();
				});
				this.iterator = 				(function (){
					return new Iterator(conversion, removeItem);
				});
				this.remove = 				(function (o){
					if (this.contains(o)){
						removeItem(o);
						return true;
					}
					return false;
				});
				this.removeAll = 				(function (c){
					var it = c.iterator();
					var changed = false;
					while(it.hasNext()){
						var item = it.next();
						if (this.contains(item)){
							removeItem(item);
							changed = true;
						}
					}
					return true;
				});
				this.retainAll = 				(function (c){
					var it = this.iterator();
					var toRemove = [];
					while(it.hasNext()){
						var entry = it.next();
						if (!c.contains(entry)){
							toRemove.push(entry);
						}
					}
					for(var i = 0; i < toRemove.length;++i){
						removeItem(toRemove[i]);
					}
					return toRemove.length > 0;
				});
				this.size = 				(function (){
					return hashMap.size();
				});
				this.toArray = 				(function (){
					var result = [];
					var it = this.iterator();
					while(it.hasNext()){
						result.push(it.next());
					}
					return result;
				});
			}
						function Entry(pair){
				this._isIn = 				(function (map){
					return (map === hashMap) && (pair.removed === undef);
				});
				this.equals = 				(function (o){
					return virtEquals(pair.key, o.getKey());
				});
				this.getKey = 				(function (){
					return pair.key;
				});
				this.getValue = 				(function (){
					return pair.value;
				});
				this.hashCode = 				(function (o){
					return virtHashCode(pair.key);
				});
				this.setValue = 				(function (value){
					var old = pair.value;
					pair.value = value;
					return old;
				});
			}
			this.clear = 			(function (){
				count = 0;
				buckets = [];
				buckets.length = initialCapacity;
			});
			this.clone = 			(function (){
				var map = new HashMap();
				map.putAll(this);
				return map;
			});
			this.containsKey = 			(function (key){
				var index = getBucketIndex(key);
				var bucket = buckets[index];
				if (bucket === undef){
					return false;
				}
				for(var i = 0; i < bucket.length;++i){
					if (virtEquals(bucket[i].key, key)){
						return true;
					}
				}
				return false;
			});
			this.containsValue = 			(function (value){
				for(var i = 0; i < buckets.length;++i){
					var bucket = buckets[i];
					if (bucket === undef){
						continue ;
					}
					for(var j = 0; j < bucket.length;++j){
						if (virtEquals(bucket[j].value, value)){
							return true;
						}
					}
				}
				return false;
			});
			this.entrySet = 			(function (){
				return new Set(				(function (pair){
					return new Entry(pair);
				}), 				(function (pair){
					return (pair.constructor === Entry) && pair._isIn(hashMap);
				}), 				(function (pair){
					return hashMap.remove(pair.getKey());
				}));
			});
			this.get = 			(function (key){
				var index = getBucketIndex(key);
				var bucket = buckets[index];
				if (bucket === undef){
					return null;
				}
				for(var i = 0; i < bucket.length;++i){
					if (virtEquals(bucket[i].key, key)){
						return bucket[i].value;
					}
				}
				return null;
			});
			this.isEmpty = 			(function (){
				return count === 0;
			});
			this.keySet = 			(function (){
				return new Set(				(function (pair){
					return pair.key;
				}), 				(function (key){
					return hashMap.containsKey(key);
				}), 				(function (key){
					return hashMap.remove(key);
				}));
			});
			this.put = 			(function (key, value){
				var index = getBucketIndex(key);
				var bucket = buckets[index];
				if (bucket === undef){
					++count;
					buckets[index] = [{					key:key, 					value:value					}];
					ensureLoad();
					return null;
				}
				for(var i = 0; i < bucket.length;++i){
					if (virtEquals(bucket[i].key, key)){
						var previous = bucket[i].value;
						bucket[i].value = value;
						return previous;
					}
				}
				++count;
				bucket.push({				key:key, 				value:value				});
				ensureLoad();
				return null;
			});
			this.putAll = 			(function (m){
				var it = m.entrySet().iterator();
				while(it.hasNext()){
					var entry = it.next();
					this.put(entry.getKey(), entry.getValue());
				}
			});
			this.remove = 			(function (key){
				var index = getBucketIndex(key);
				var bucket = buckets[index];
				if (bucket === undef){
					return null;
				}
				for(var i = 0; i < bucket.length;++i){
					if (virtEquals(bucket[i].key, key)){
						--count;
						var previous = bucket[i].value;
						bucket[i].removed = true;
						if (bucket.length > 1){
							bucket.splice(i, 1);
						}						else
{
							buckets[index] = undef;
						}
						return previous;
					}
				}
				return null;
			});
			this.size = 			(function (){
				return count;
			});
			this.values = 			(function (){
				var result = [];
				var it = this.entrySet().iterator();
				while(it.hasNext()){
					var entry = it.next();
					result.push(entry.getValue());
				}
				return result;
			});
		}
		return HashMap;
	})();
	var PVector = 	(function (){
				function PVector(x, y, z){
			this.x = (x || 0);
			this.y = (y || 0);
			this.z = (z || 0);
		}
				function createPVectorMethod(method){
			return 			(function (v1, v2){
				var v = v1.get();
				v[method](v2);
				return v;
			});
		}
				function createSimplePVectorMethod(method){
			return 			(function (v1, v2){
				return v1[method](v2);
			});
		}
		var simplePVMethods = "dist dot cross".split(" ");
		var method = simplePVMethods.length;
		PVector.angleBetween = 		(function (v1, v2){
			return Math.acos(v1.dot(v2) / (v1.mag() * v2.mag()));
		});
		PVector.prototype = {		set:		(function (v, y, z){
			if (arguments.length === 1){
				this.set(v.x || v[0], v.y || v[1], v.z || v[2]);
			}			else
{
				this.x = v;
				this.y = y;
				this.z = z;
			}
		}), 		get:		(function (){
			return new PVector(this.x, this.y, this.z);
		}), 		mag:		(function (){
			return Math.sqrt(((this.x * this.x) + (this.y * this.y)) + (this.z * this.z));
		}), 		add:		(function (v, y, z){
			if (arguments.length === 3){
				this.x += v;
				this.y += y;
				this.z += z;
			}			else
{
				if (arguments.length === 1){
					this.x += v.x;
					this.y += v.y;
					this.z += v.z;
				}
			}
		}), 		sub:		(function (v, y, z){
			if (arguments.length === 3){
				this.x -= v;
				this.y -= y;
				this.z -= z;
			}			else
{
				if (arguments.length === 1){
					this.x -= v.x;
					this.y -= v.y;
					this.z -= v.z;
				}
			}
		}), 		mult:		(function (v){
			if (typeofv === 'number'){
				this.x *= v;
				this.y *= v;
				this.z *= v;
			}			else
{
				if (typeofv === 'object'){
					this.x *= v.x;
					this.y *= v.y;
					this.z *= v.z;
				}
			}
		}), 		div:		(function (v){
			if (typeofv === 'number'){
				this.x /= v;
				this.y /= v;
				this.z /= v;
			}			else
{
				if (typeofv === 'object'){
					this.x /= v.x;
					this.y /= v.y;
					this.z /= v.z;
				}
			}
		}), 		dist:		(function (v){
			var dx = this.x - v.x; var dy = this.y - v.y; var dz = this.z - v.z;
			return Math.sqrt(((dx * dx) + (dy * dy)) + (dz * dz));
		}), 		dot:		(function (v, y, z){
			if (arguments.length === 3){
				return ((this.x * v) + (this.y * y)) + (this.z * z);
			}			else
{
				if (arguments.length === 1){
					return ((this.x * v.x) + (this.y * v.y)) + (this.z * v.z);
				}
			}
		}), 		cross:		(function (v){
			return new PVector((this.y * v.z) - (v.y * this.z), (this.z * v.x) - (v.z * this.x), (this.x * v.y) - (v.x * this.y));
		}), 		normalize:		(function (){
			var m = this.mag();
			if (m > 0){
				this.div(m);
			}
		}), 		limit:		(function (high){
			if (this.mag() > high){
				this.normalize();
				this.mult(high);
			}
		}), 		heading2D:		(function (){
			return -Math.atan2(-this.y, this.x);
		}), 		toString:		(function (){
			return ((((("[" + this.x) + ", ") + this.y) + ", ") + this.z) + "]";
		}), 		array:		(function (){
			return [this.x,this.y,this.z];
		})		};
		while(method--){
			PVector[simplePVMethods[method]] = createSimplePVectorMethod(simplePVMethods[method]);
		}
		for(method in PVector.prototype){
			if (PVector.prototype.hasOwnProperty(method) && !PVector.hasOwnProperty(method)){
				PVector[method] = createPVectorMethod(method);
			}
		}
		return PVector;
	})();
		function DefaultScope(){
	}
	DefaultScope.prototype = PConstants;
	var defaultScope = new DefaultScope();
	defaultScope.ArrayList = ArrayList;
	defaultScope.HashMap = HashMap;
	defaultScope.PVector = PVector;
	defaultScope.ObjectIterator = ObjectIterator;
	var colors = {	aliceblue:"#f0f8ff", 	antiquewhite:"#faebd7", 	aqua:"#00ffff", 	aquamarine:"#7fffd4", 	azure:"#f0ffff", 	beige:"#f5f5dc", 	bisque:"#ffe4c4", 	black:"#000000", 	blanchedalmond:"#ffebcd", 	blue:"#0000ff", 	blueviolet:"#8a2be2", 	brown:"#a52a2a", 	burlywood:"#deb887", 	cadetblue:"#5f9ea0", 	chartreuse:"#7fff00", 	chocolate:"#d2691e", 	coral:"#ff7f50", 	cornflowerblue:"#6495ed", 	cornsilk:"#fff8dc", 	crimson:"#dc143c", 	cyan:"#00ffff", 	darkblue:"#00008b", 	darkcyan:"#008b8b", 	darkgoldenrod:"#b8860b", 	darkgray:"#a9a9a9", 	darkgreen:"#006400", 	darkkhaki:"#bdb76b", 	darkmagenta:"#8b008b", 	darkolivegreen:"#556b2f", 	darkorange:"#ff8c00", 	darkorchid:"#9932cc", 	darkred:"#8b0000", 	darksalmon:"#e9967a", 	darkseagreen:"#8fbc8f", 	darkslateblue:"#483d8b", 	darkslategray:"#2f4f4f", 	darkturquoise:"#00ced1", 	darkviolet:"#9400d3", 	deeppink:"#ff1493", 	deepskyblue:"#00bfff", 	dimgray:"#696969", 	dodgerblue:"#1e90ff", 	firebrick:"#b22222", 	floralwhite:"#fffaf0", 	forestgreen:"#228b22", 	fuchsia:"#ff00ff", 	gainsboro:"#dcdcdc", 	ghostwhite:"#f8f8ff", 	gold:"#ffd700", 	goldenrod:"#daa520", 	gray:"#808080", 	green:"#008000", 	greenyellow:"#adff2f", 	honeydew:"#f0fff0", 	hotpink:"#ff69b4", 	indianred:"#cd5c5c", 	indigo:"#4b0082", 	ivory:"#fffff0", 	khaki:"#f0e68c", 	lavender:"#e6e6fa", 	lavenderblush:"#fff0f5", 	lawngreen:"#7cfc00", 	lemonchiffon:"#fffacd", 	lightblue:"#add8e6", 	lightcoral:"#f08080", 	lightcyan:"#e0ffff", 	lightgoldenrodyellow:"#fafad2", 	lightgrey:"#d3d3d3", 	lightgreen:"#90ee90", 	lightpink:"#ffb6c1", 	lightsalmon:"#ffa07a", 	lightseagreen:"#20b2aa", 	lightskyblue:"#87cefa", 	lightslategray:"#778899", 	lightsteelblue:"#b0c4de", 	lightyellow:"#ffffe0", 	lime:"#00ff00", 	limegreen:"#32cd32", 	linen:"#faf0e6", 	magenta:"#ff00ff", 	maroon:"#800000", 	mediumaquamarine:"#66cdaa", 	mediumblue:"#0000cd", 	mediumorchid:"#ba55d3", 	mediumpurple:"#9370d8", 	mediumseagreen:"#3cb371", 	mediumslateblue:"#7b68ee", 	mediumspringgreen:"#00fa9a", 	mediumturquoise:"#48d1cc", 	mediumvioletred:"#c71585", 	midnightblue:"#191970", 	mintcream:"#f5fffa", 	mistyrose:"#ffe4e1", 	moccasin:"#ffe4b5", 	navajowhite:"#ffdead", 	navy:"#000080", 	oldlace:"#fdf5e6", 	olive:"#808000", 	olivedrab:"#6b8e23", 	orange:"#ffa500", 	orangered:"#ff4500", 	orchid:"#da70d6", 	palegoldenrod:"#eee8aa", 	palegreen:"#98fb98", 	paleturquoise:"#afeeee", 	palevioletred:"#d87093", 	papayawhip:"#ffefd5", 	peachpuff:"#ffdab9", 	peru:"#cd853f", 	pink:"#ffc0cb", 	plum:"#dda0dd", 	powderblue:"#b0e0e6", 	purple:"#800080", 	red:"#ff0000", 	rosybrown:"#bc8f8f", 	royalblue:"#4169e1", 	saddlebrown:"#8b4513", 	salmon:"#fa8072", 	sandybrown:"#f4a460", 	seagreen:"#2e8b57", 	seashell:"#fff5ee", 	sienna:"#a0522d", 	silver:"#c0c0c0", 	skyblue:"#87ceeb", 	slateblue:"#6a5acd", 	slategray:"#708090", 	snow:"#fffafa", 	springgreen:"#00ff7f", 	steelblue:"#4682b4", 	tan:"#d2b48c", 	teal:"#008080", 	thistle:"#d8bfd8", 	tomato:"#ff6347", 	turquoise:"#40e0d0", 	violet:"#ee82ee", 	wheat:"#f5deb3", 	white:"#ffffff", 	whitesmoke:"#f5f5f5", 	yellow:"#ffff00", 	yellowgreen:"#9acd32"	};
	var processingInstances = [];
	var processingInstanceIds = {	};
	var removeInstance = 	(function (id){
		processingInstances.splice(processingInstanceIds[id], 1);
		deleteprocessingInstanceIds[id];
	});
	var addInstance = 	(function (processing){
		if ((processing.externals.canvas.id === undef) || !processing.externals.canvas.id.length){
			processing.externals.canvas.id = ("__processing" + processingInstances.length);
		}
		processingInstanceIds[processing.externals.canvas.id] = processingInstances.length;
		processingInstances.push(processing);
	});
	var Processing = this.Processing = 	(function (curElement, aCode){
		if (!(this instanceof Processing)){
			throw "called Processing constructor as if it were a function: missing 'new'.";
		}
				function unimplemented(s){
			Processing.debug('Unimplemented - ' + s);
		}
		var p = this;
		var pgraphicsMode = arguments.length === 0;
		if (pgraphicsMode){
			curElement = document.createElement("canvas");
			p.canvas = curElement;
		}
		p.externals = {		canvas:curElement, 		context:undef, 		sketch:undef		};
		p.name = 'Processing.js Instance';
		p.use3DContext = false;
		p.focused = false;
		p.breakShape = false;
		p.glyphTable = {		};
		p.pmouseX = 0;
		p.pmouseY = 0;
		p.mouseX = 0;
		p.mouseY = 0;
		p.mouseButton = 0;
		p.mouseScroll = 0;
		p.mouseClicked = undef;
		p.mouseDragged = undef;
		p.mouseMoved = undef;
		p.mousePressed = undef;
		p.mouseReleased = undef;
		p.mouseScrolled = undef;
		p.mouseOver = undef;
		p.mouseOut = undef;
		p.touchStart = undef;
		p.touchEnd = undef;
		p.touchMove = undef;
		p.touchCancel = undef;
		p.key = undef;
		p.keyCode = undef;
		p.keyPressed = 		(function (){
		});
		p.keyReleased = 		(function (){
		});
		p.keyTyped = 		(function (){
		});
		p.draw = undef;
		p.setup = undef;
		p.__mousePressed = false;
		p.__keyPressed = false;
		p.__frameRate = 60;
		p.frameCount = 0;
		p.width = 100;
		p.height = 100;
		p.defineProperty = 		(function (obj, name, desc){
			if ("defineProperty" in Object){
				Object.defineProperty(obj, name, desc);
			}			else
{
				if (desc.hasOwnProperty("get")){
					obj.__defineGetter__(name, desc.get);
				}
				if (desc.hasOwnProperty("set")){
					obj.__defineSetter__(name, desc.set);
				}
			}
		});
		var curContext; var curSketch; var drawing; var online = true; var doFill = true; var fillStyle = [1,1,1,1]; var currentFillColor = -1; var isFillDirty = true; var doStroke = true; var strokeStyle = [0.8,0.8,0.8,1]; var currentStrokeColor = -131587; var isStrokeDirty = true; var lineWidth = 1; var loopStarted = false; var doLoop = true; var looping = 0; var curRectMode = PConstants.CORNER; var curEllipseMode = PConstants.CENTER; var normalX = 0; var normalY = 0; var normalZ = 0; var normalMode = PConstants.NORMAL_MODE_AUTO; var inDraw = false; var curFrameRate = 60; var curMsPerFrame = 1000 / curFrameRate; var curCursor = PConstants.ARROW; var oldCursor = curElement.style.cursor; var curShape = PConstants.POLYGON; var curShapeCount = 0; var curvePoints = []; var curTightness = 0; var curveDet = 20; var curveInited = false; var backgroundObj = -3355444; var bezDetail = 20; var colorModeA = 255; var colorModeX = 255; var colorModeY = 255; var colorModeZ = 255; var pathOpen = false; var mouseDragging = false; var curColorMode = PConstants.RGB; var curTint = null; var curTextSize = 12; var curTextFont = {		name:"\"Arial\", sans-serif", 		origName:"Arial"		}; var curTextLeading = 14; var getLoaded = false; var start = new Date().getTime(); var timeSinceLastFPS = start; var framesSinceLastFPS = 0; var textcanvas; var curveBasisMatrix; var curveToBezierMatrix; var curveDrawMatrix; var bezierDrawMatrix; var bezierBasisInverse; var bezierBasisMatrix; var firstCodedDown = true; var firstEDGKeyDown = true; var firstEDMKeyDown = true; var firstMKeyDown = true; var firstGKeyDown = true; var gRefire = false; var curContextCache = {		attributes:{		}, 		locations:{		}		}; var programObject3D; var programObject2D; var programObjectUnlitShape; var boxBuffer; var boxNormBuffer; var boxOutlineBuffer; var rectBuffer; var rectNormBuffer; var sphereBuffer; var lineBuffer; var fillBuffer; var fillColorBuffer; var strokeColorBuffer; var pointBuffer; var shapeTexVBO; var canTex; var textTex; var curTexture = {		width:0, 		height:0		}; var curTextureMode = PConstants.IMAGE; var usingTexture = false; var textBuffer; var textureBuffer; var indexBuffer; var horizontalTextAlignment = PConstants.LEFT; var verticalTextAlignment = PConstants.BASELINE; var baselineOffset = 0.2; var tMode = PConstants.MODEL; var originalContext; var proxyContext = null; var isContextReplaced = false; var setPixelsCached; var maxPixelsCached = 1000; var pressedKeysMap = []; var lastPressedKeyCode = null; var codedKeys = [PConstants.SHIFT,PConstants.CONTROL,PConstants.ALT,PConstants.CAPSLK,PConstants.PGUP,PConstants.PGDN,PConstants.END,PConstants.HOME,PConstants.LEFT,PConstants.UP,PConstants.RIGHT,PConstants.DOWN,PConstants.NUMLK,PConstants.INSERT,PConstants.F1,PConstants.F2,PConstants.F3,PConstants.F4,PConstants.F5,PConstants.F6,PConstants.F7,PConstants.F8,PConstants.F9,PConstants.F10,PConstants.F11,PConstants.F12,PConstants.META];
		var stylePaddingLeft; var stylePaddingTop; var styleBorderLeft; var styleBorderTop;
		if (document.defaultView && document.defaultView.getComputedStyle){
			stylePaddingLeft = (parseInt(document.defaultView.getComputedStyle(curElement, null)['paddingLeft'], 10) || 0);
			stylePaddingTop = (parseInt(document.defaultView.getComputedStyle(curElement, null)['paddingTop'], 10) || 0);
			styleBorderLeft = (parseInt(document.defaultView.getComputedStyle(curElement, null)['borderLeftWidth'], 10) || 0);
			styleBorderTop = (parseInt(document.defaultView.getComputedStyle(curElement, null)['borderTopWidth'], 10) || 0);
		}
		var lightCount = 0;
		var sphereDetailV = 0; var sphereDetailU = 0; var sphereX = []; var sphereY = []; var sphereZ = []; var sinLUT = new Float32Array(PConstants.SINCOS_LENGTH); var cosLUT = new Float32Array(PConstants.SINCOS_LENGTH); var sphereVerts; var sphereNorms;
		var cam; var cameraInv; var forwardTransform; var reverseTransform; var modelView; var modelViewInv; var userMatrixStack; var userReverseMatrixStack; var inverseCopy; var projection; var manipulatingCamera = false; var frustumMode = false; var cameraFOV = 60 * (Math.PI / 180); var cameraX = p.width / 2; var cameraY = p.height / 2; var cameraZ = cameraY / Math.tan(cameraFOV / 2); var cameraNear = cameraZ / 10; var cameraFar = cameraZ * 10; var cameraAspect = p.width / p.height;
		var vertArray = []; var curveVertArray = []; var curveVertCount = 0; var isCurve = false; var isBezier = false; var firstVert = true;
		var curShapeMode = PConstants.CORNER;
		var styleArray = [];
		var boxVerts = new Float32Array([0.5,0.5,-0.5,0.5,-0.5,-0.5,-0.5,-0.5,-0.5,-0.5,-0.5,-0.5,-0.5,0.5,-0.5,0.5,0.5,-0.5,0.5,0.5,0.5,-0.5,0.5,0.5,-0.5,-0.5,0.5,-0.5,-0.5,0.5,0.5,-0.5,0.5,0.5,0.5,0.5,0.5,0.5,-0.5,0.5,0.5,0.5,0.5,-0.5,0.5,0.5,-0.5,0.5,0.5,-0.5,-0.5,0.5,0.5,-0.5,0.5,-0.5,-0.5,0.5,-0.5,0.5,-0.5,-0.5,0.5,-0.5,-0.5,0.5,-0.5,-0.5,-0.5,0.5,-0.5,-0.5,-0.5,-0.5,-0.5,-0.5,-0.5,0.5,-0.5,0.5,0.5,-0.5,0.5,0.5,-0.5,0.5,-0.5,-0.5,-0.5,-0.5,0.5,0.5,0.5,0.5,0.5,-0.5,-0.5,0.5,-0.5,-0.5,0.5,-0.5,-0.5,0.5,0.5,0.5,0.5,0.5]);
		var boxOutlineVerts = new Float32Array([0.5,0.5,0.5,0.5,-0.5,0.5,0.5,0.5,-0.5,0.5,-0.5,-0.5,-0.5,0.5,-0.5,-0.5,-0.5,-0.5,-0.5,0.5,0.5,-0.5,-0.5,0.5,0.5,0.5,0.5,0.5,0.5,-0.5,0.5,0.5,-0.5,-0.5,0.5,-0.5,-0.5,0.5,-0.5,-0.5,0.5,0.5,-0.5,0.5,0.5,0.5,0.5,0.5,0.5,-0.5,0.5,0.5,-0.5,-0.5,0.5,-0.5,-0.5,-0.5,-0.5,-0.5,-0.5,-0.5,-0.5,-0.5,-0.5,0.5,-0.5,-0.5,0.5,0.5,-0.5,0.5]);
		var boxNorms = new Float32Array([0,0,-1,0,0,-1,0,0,-1,0,0,-1,0,0,-1,0,0,-1,0,0,1,0,0,1,0,0,1,0,0,1,0,0,1,0,0,1,1,0,0,1,0,0,1,0,0,1,0,0,1,0,0,1,0,0,0,-1,0,0,-1,0,0,-1,0,0,-1,0,0,-1,0,0,-1,0,-1,0,0,-1,0,0,-1,0,0,-1,0,0,-1,0,0,-1,0,0,0,1,0,0,1,0,0,1,0,0,1,0,0,1,0,0,1,0]);
		var rectVerts = new Float32Array([0,0,0,0,1,0,1,1,0,1,0,0]);
		var rectNorms = new Float32Array([0,0,1,0,0,1,0,0,1,0,0,1]);
		var vShaderSrcUnlitShape = ((((((("varying vec4 frontColor;" + "attribute vec3 aVertex;") + "attribute vec4 aColor;") + "uniform mat4 uView;") + "uniform mat4 uProjection;") + "void main(void) {") + "  frontColor = aColor;") + "  gl_Position = uProjection * uView * vec4(aVertex, 1.0);") + "}";
		var fShaderSrcUnlitShape = ((((("#ifdef GL_ES\n" + "precision highp float;\n") + "#endif\n") + "varying vec4 frontColor;") + "void main(void){") + "  gl_FragColor = frontColor;") + "}";
		var vertexShaderSource2D = ((((((((((((("varying vec4 frontColor;" + "attribute vec3 Vertex;") + "attribute vec2 aTextureCoord;") + "uniform vec4 color;") + "uniform mat4 model;") + "uniform mat4 view;") + "uniform mat4 projection;") + "uniform float pointSize;") + "varying vec2 vTextureCoord;") + "void main(void) {") + "  gl_PointSize = pointSize;") + "  frontColor = color;") + "  gl_Position = projection * view * model * vec4(Vertex, 1.0);") + "  vTextureCoord = aTextureCoord;") + "}";
		var fragmentShaderSource2D = (((((((((((((("#ifdef GL_ES\n" + "precision highp float;\n") + "#endif\n") + "varying vec4 frontColor;") + "varying vec2 vTextureCoord;") + "uniform sampler2D uSampler;") + "uniform int picktype;") + "void main(void){") + "  if(picktype == 0){") + "    gl_FragColor = frontColor;") + "  }") + "  else if(picktype == 1){") + "    float alpha = texture2D(uSampler, vTextureCoord).a;") + "    gl_FragColor = vec4(frontColor.rgb*alpha, alpha);\n") + "  }") + "}";
		var webglMaxTempsWorkaround = /Windows/.test(navigator.userAgent);
		var vertexShaderSource3D = ((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((("varying vec4 frontColor;" + "attribute vec3 Vertex;") + "attribute vec3 Normal;") + "attribute vec4 aColor;") + "attribute vec2 aTexture;") + "varying   vec2 vTexture;") + "uniform vec4 color;") + "uniform bool usingMat;") + "uniform vec3 specular;") + "uniform vec3 mat_emissive;") + "uniform vec3 mat_ambient;") + "uniform vec3 mat_specular;") + "uniform float shininess;") + "uniform mat4 model;") + "uniform mat4 view;") + "uniform mat4 projection;") + "uniform mat4 normalTransform;") + "uniform int lightCount;") + "uniform vec3 falloff;") + "struct Light {") + "  int type;") + "  vec3 color;") + "  vec3 position;") + "  vec3 direction;") + "  float angle;") + "  vec3 halfVector;") + "  float concentration;") + "};") + "uniform Light lights0;") + "uniform Light lights1;") + "uniform Light lights2;") + "uniform Light lights3;") + "uniform Light lights4;") + "uniform Light lights5;") + "uniform Light lights6;") + "uniform Light lights7;") + "Light getLight(int index){") + "  if(index == 0) return lights0;") + "  if(index == 1) return lights1;") + "  if(index == 2) return lights2;") + "  if(index == 3) return lights3;") + "  if(index == 4) return lights4;") + "  if(index == 5) return lights5;") + "  if(index == 6) return lights6;") + "  return lights7;") + "}") + "void AmbientLight( inout vec3 totalAmbient, in vec3 ecPos, in Light light ) {") + "  float d = length( light.position - ecPos );") + "  float attenuation = 1.0 / ( falloff[0] + ( falloff[1] * d ) + ( falloff[2] * d * d ));") + "  totalAmbient += light.color * attenuation;") + "}") + "void DirectionalLight( inout vec3 col, inout vec3 spec, in vec3 vertNormal, in vec3 ecPos, in Light light ) {") + "  float powerfactor = 0.0;") + "  float nDotVP = max(0.0, dot( vertNormal, normalize(-light.position) ));") + "  float nDotVH = max(0.0, dot( vertNormal, normalize(-light.position-normalize(ecPos) )));") + "  if( nDotVP != 0.0 ){") + "    powerfactor = pow( nDotVH, shininess );") + "  }") + "  col += light.color * nDotVP;") + "  spec += specular * powerfactor;") + "}") + "void PointLight( inout vec3 col, inout vec3 spec, in vec3 vertNormal, in vec3 ecPos, in Light light ) {") + "  float powerfactor;") + "   vec3 VP = light.position - ecPos;") + "  float d = length( VP ); ") + "  VP = normalize( VP );") + "  float attenuation = 1.0 / ( falloff[0] + ( falloff[1] * d ) + ( falloff[2] * d * d ));") + "  float nDotVP = max( 0.0, dot( vertNormal, VP ));") + "  vec3 halfVector = normalize( VP - normalize(ecPos) );") + "  float nDotHV = max( 0.0, dot( vertNormal, halfVector ));") + "  if( nDotVP == 0.0) {") + "    powerfactor = 0.0;") + "  }") + "  else{") + "    powerfactor = pow( nDotHV, shininess );") + "  }") + "  spec += specular * powerfactor * attenuation;") + "  col += light.color * nDotVP * attenuation;") + "}") + "void SpotLight( inout vec3 col, inout vec3 spec, in vec3 vertNormal, in vec3 ecPos, in Light light ) {") + "  float spotAttenuation;") + "  float powerfactor;") + "  vec3 VP = light.position - ecPos; ") + "  vec3 ldir = normalize( -light.direction );") + "  float d = length( VP );") + "  VP = normalize( VP );") + "  float attenuation = 1.0 / ( falloff[0] + ( falloff[1] * d ) + ( falloff[2] * d * d ) );") + "  float spotDot = dot( VP, ldir );") + (webglMaxTempsWorkaround ? "  spotAttenuation = 1.0; " : ((((((("  if( spotDot > cos( light.angle ) ) {" + "    spotAttenuation = pow( spotDot, light.concentration );") + "  }") + "  else{") + "    spotAttenuation = 0.0;") + "  }") + "  attenuation *= spotAttenuation;") + ""))) + "  float nDotVP = max( 0.0, dot( vertNormal, VP ));") + "  vec3 halfVector = normalize( VP - normalize(ecPos) );") + "  float nDotHV = max( 0.0, dot( vertNormal, halfVector ));") + "  if( nDotVP == 0.0 ) {") + "    powerfactor = 0.0;") + "  }") + "  else {") + "    powerfactor = pow( nDotHV, shininess );") + "  }") + "  spec += specular * powerfactor * attenuation;") + "  col += light.color * nDotVP * attenuation;") + "}") + "void main(void) {") + "  vec3 finalAmbient = vec3( 0.0, 0.0, 0.0 );") + "  vec3 finalDiffuse = vec3( 0.0, 0.0, 0.0 );") + "  vec3 finalSpecular = vec3( 0.0, 0.0, 0.0 );") + "  vec4 col = color;") + "  if(color[0] == -1.0){") + "    col = aColor;") + "  }") + "  vec3 norm = normalize(vec3( normalTransform * vec4( Normal, 0.0 ) ));") + "  vec4 ecPos4 = view * model * vec4(Vertex,1.0);") + "  vec3 ecPos = (vec3(ecPos4))/ecPos4.w;") + "  if( lightCount == 0 ) {") + "    frontColor = col + vec4(mat_specular,1.0);") + "  }") + "  else {") + "    for( int i = 0; i < 8; i++ ) {") + "      Light l = getLight(i);") + "      if( i >= lightCount ){") + "        break;") + "      }") + "      if( l.type == 0 ) {") + "        AmbientLight( finalAmbient, ecPos, l );") + "      }") + "      else if( l.type == 1 ) {") + "        DirectionalLight( finalDiffuse, finalSpecular, norm, ecPos, l );") + "      }") + "      else if( l.type == 2 ) {") + "        PointLight( finalDiffuse, finalSpecular, norm, ecPos, l );") + "      }") + "      else {") + "        SpotLight( finalDiffuse, finalSpecular, norm, ecPos, l );") + "      }") + "    }") + "   if( usingMat == false ) {") + "     frontColor = vec4(") + "       vec3(col) * finalAmbient +") + "       vec3(col) * finalDiffuse +") + "       vec3(col) * finalSpecular,") + "       col[3] );") + "   }") + "   else{") + "     frontColor = vec4( ") + "       mat_emissive + ") + "       (vec3(col) * mat_ambient * finalAmbient) + ") + "       (vec3(col) * finalDiffuse) + ") + "       (mat_specular * finalSpecular), ") + "       col[3] );") + "    }") + "  }") + "  vTexture.xy = aTexture.xy;") + "  gl_Position = projection * view * model * vec4( Vertex, 1.0 );") + "}";
		var fragmentShaderSource3D = ((((((((((((("#ifdef GL_ES\n" + "precision highp float;\n") + "#endif\n") + "varying vec4 frontColor;") + "uniform sampler2D sampler;") + "uniform bool usingTexture;") + "varying vec2 vTexture;") + "void main(void){") + "  if(usingTexture){") + "    gl_FragColor =  vec4(texture2D(sampler, vTexture.xy));") + "  }") + "  else{") + "    gl_FragColor = frontColor;") + "  }") + "}";
				function uniformf(cacheId, programObj, varName, varValue){
			var varLocation = curContextCache.locations[cacheId];
			if (varLocation === undef){
				varLocation = curContext.getUniformLocation(programObj, varName);
				curContextCache.locations[cacheId] = varLocation;
			}
			if (varLocation !== -1){
				if (varValue.length === 4){
					curContext.uniform4fv(varLocation, varValue);
				}				else
{
					if (varValue.length === 3){
						curContext.uniform3fv(varLocation, varValue);
					}					else
{
						if (varValue.length === 2){
							curContext.uniform2fv(varLocation, varValue);
						}						else
{
							curContext.uniform1f(varLocation, varValue);
						}
					}
				}
			}
		}
				function uniformi(cacheId, programObj, varName, varValue){
			var varLocation = curContextCache.locations[cacheId];
			if (varLocation === undef){
				varLocation = curContext.getUniformLocation(programObj, varName);
				curContextCache.locations[cacheId] = varLocation;
			}
			if (varLocation !== -1){
				if (varValue.length === 4){
					curContext.uniform4iv(varLocation, varValue);
				}				else
{
					if (varValue.length === 3){
						curContext.uniform3iv(varLocation, varValue);
					}					else
{
						if (varValue.length === 2){
							curContext.uniform2iv(varLocation, varValue);
						}						else
{
							curContext.uniform1i(varLocation, varValue);
						}
					}
				}
			}
		}
				function vertexAttribPointer(cacheId, programObj, varName, size, VBO){
			var varLocation = curContextCache.attributes[cacheId];
			if (varLocation === undef){
				varLocation = curContext.getAttribLocation(programObj, varName);
				curContextCache.attributes[cacheId] = varLocation;
			}
			if (varLocation !== -1){
				curContext.bindBuffer(curContext.ARRAY_BUFFER, VBO);
				curContext.vertexAttribPointer(varLocation, size, curContext.FLOAT, false, 0, 0);
				curContext.enableVertexAttribArray(varLocation);
			}
		}
				function disableVertexAttribPointer(cacheId, programObj, varName){
			var varLocation = curContextCache.attributes[cacheId];
			if (varLocation === undef){
				varLocation = curContext.getAttribLocation(programObj, varName);
				curContextCache.attributes[cacheId] = varLocation;
			}
			if (varLocation !== -1){
				curContext.disableVertexAttribArray(varLocation);
			}
		}
				function uniformMatrix(cacheId, programObj, varName, transpose, matrix){
			var varLocation = curContextCache.locations[cacheId];
			if (varLocation === undef){
				varLocation = curContext.getUniformLocation(programObj, varName);
				curContextCache.locations[cacheId] = varLocation;
			}
			if (varLocation !== -1){
				if (matrix.length === 16){
					curContext.uniformMatrix4fv(varLocation, transpose, matrix);
				}				else
{
					if (matrix.length === 9){
						curContext.uniformMatrix3fv(varLocation, transpose, matrix);
					}					else
{
						curContext.uniformMatrix2fv(varLocation, transpose, matrix);
					}
				}
			}
		}
		var imageModeCorner = 		(function (x, y, w, h, whAreSizes){
			return {			x:x, 			y:y, 			w:w, 			h:h			};
		});
		var imageModeConvert = imageModeCorner;
		var imageModeCorners = 		(function (x, y, w, h, whAreSizes){
			return {			x:x, 			y:y, 			w:whAreSizes ? w : (w - x), 			h:whAreSizes ? h : (h - y)			};
		});
		var imageModeCenter = 		(function (x, y, w, h, whAreSizes){
			return {			x:x - (w / 2), 			y:y - (h / 2), 			w:w, 			h:h			};
		});
		var createProgramObject = 		(function (curContext, vetexShaderSource, fragmentShaderSource){
			var vertexShaderObject = curContext.createShader(curContext.VERTEX_SHADER);
			curContext.shaderSource(vertexShaderObject, vetexShaderSource);
			curContext.compileShader(vertexShaderObject);
			if (!curContext.getShaderParameter(vertexShaderObject, curContext.COMPILE_STATUS)){
				throw curContext.getShaderInfoLog(vertexShaderObject);
			}
			var fragmentShaderObject = curContext.createShader(curContext.FRAGMENT_SHADER);
			curContext.shaderSource(fragmentShaderObject, fragmentShaderSource);
			curContext.compileShader(fragmentShaderObject);
			if (!curContext.getShaderParameter(fragmentShaderObject, curContext.COMPILE_STATUS)){
				throw curContext.getShaderInfoLog(fragmentShaderObject);
			}
			var programObject = curContext.createProgram();
			curContext.attachShader(programObject, vertexShaderObject);
			curContext.attachShader(programObject, fragmentShaderObject);
			curContext.linkProgram(programObject);
			if (!curContext.getProgramParameter(programObject, curContext.LINK_STATUS)){
				throw "Error linking shaders.";
			}
			return programObject;
		});
		var DrawingShared = 		(function (){
		});
		var Drawing2D = 		(function (){
		});
		var Drawing3D = 		(function (){
		});
		var DrawingPre = 		(function (){
		});
		Drawing2D.prototype = new DrawingShared();
		Drawing2D.prototype.constructor = Drawing2D;
		Drawing3D.prototype = new DrawingShared();
		Drawing3D.prototype.constructor = Drawing3D;
		DrawingPre.prototype = new DrawingShared();
		DrawingPre.prototype.constructor = DrawingPre;
		DrawingShared.prototype.a3DOnlyFunction = 		(function (){
		});
		var charMap = {		};
		var Char = p.Character = 		(function (chr){
			if ((typeofchr === 'string') && (chr.length === 1)){
				this.code = chr.charCodeAt(0);
			}			else
{
				if (typeofchr === 'number'){
					this.code = chr;
				}				else
{
					if (chr instanceof Char){
						this.code = chr;
					}					else
{
						this.code = NaN;
					}
				}
			}
			return (charMap[this.code] === undef) ? (charMap[this.code] = this) : charMap[this.code];
		});
		Char.prototype.toString = 		(function (){
			return String.fromCharCode(this.code);
		});
		Char.prototype.valueOf = 		(function (){
			return this.code;
		});
		var PShape = p.PShape = 		(function (family){
			this.family = (family || PConstants.GROUP);
			this.visible = true;
			this.style = true;
			this.children = [];
			this.nameTable = [];
			this.params = [];
			this.name = "";
			this.image = null;
			this.matrix = null;
			this.kind = null;
			this.close = null;
			this.width = null;
			this.height = null;
			this.parent = null;
		});
		PShape.prototype = {		isVisible:		(function (){
			return this.visible;
		}), 		setVisible:		(function (visible){
			this.visible = visible;
		}), 		disableStyle:		(function (){
			this.style = false;
			for(var i = 0, j = this.children.length; i < j;i++){
				this.children[i].disableStyle();
			}
		}), 		enableStyle:		(function (){
			this.style = true;
			for(var i = 0, j = this.children.length; i < j;i++){
				this.children[i].enableStyle();
			}
		}), 		getFamily:		(function (){
			return this.family;
		}), 		getWidth:		(function (){
			return this.width;
		}), 		getHeight:		(function (){
			return this.height;
		}), 		setName:		(function (name){
			this.name = name;
		}), 		getName:		(function (){
			return this.name;
		}), 		draw:		(function (){
			if (this.visible){
				this.pre();
				this.drawImpl();
				this.post();
			}
		}), 		drawImpl:		(function (){
			if (this.family === PConstants.GROUP){
				this.drawGroup();
			}			else
{
				if (this.family === PConstants.PRIMITIVE){
					this.drawPrimitive();
				}				else
{
					if (this.family === PConstants.GEOMETRY){
						this.drawGeometry();
					}					else
{
						if (this.family === PConstants.PATH){
							this.drawPath();
						}
					}
				}
			}
		}), 		drawPath:		(function (){
			var i; var j;
			if (this.vertices.length === 0){
				return ;
			}
			p.beginShape();
			if (this.vertexCodes.length === 0){
				if (this.vertices[0].length === 2){
					for(i = 0, j = this.vertices.length; i < j;i++){
						p.vertex(this.vertices[i][0], this.vertices[i][1]);
					}
				}				else
{
					for(i = 0, j = this.vertices.length; i < j;i++){
						p.vertex(this.vertices[i][0], this.vertices[i][1], this.vertices[i][2]);
					}
				}
			}			else
{
				var index = 0;
				if (this.vertices[0].length === 2){
					for(i = 0, j = this.vertexCodes.length; i < j;i++){
						if (this.vertexCodes[i] === PConstants.VERTEX){
							p.vertex(this.vertices[index][0], this.vertices[index][1]);
							if (this.vertices[index]["moveTo"] === true){
								vertArray[vertArray.length - 1]["moveTo"] = true;
							}							else
{
								if (this.vertices[index]["moveTo"] === false){
									vertArray[vertArray.length - 1]["moveTo"] = false;
								}
							}
							p.breakShape = false;
							index++;
						}						else
{
							if (this.vertexCodes[i] === PConstants.BEZIER_VERTEX){
								p.bezierVertex(this.vertices[index + 0][0], this.vertices[index + 0][1], this.vertices[index + 1][0], this.vertices[index + 1][1], this.vertices[index + 2][0], this.vertices[index + 2][1]);
								index += 3;
							}							else
{
								if (this.vertexCodes[i] === PConstants.CURVE_VERTEX){
									p.curveVertex(this.vertices[index][0], this.vertices[index][1]);
									index++;
								}								else
{
									if (this.vertexCodes[i] === PConstants.BREAK){
										p.breakShape = true;
									}
								}
							}
						}
					}
				}				else
{
					for(i = 0, j = this.vertexCodes.length; i < j;i++){
						if (this.vertexCodes[i] === PConstants.VERTEX){
							p.vertex(this.vertices[index][0], this.vertices[index][1], this.vertices[index][2]);
							if (this.vertices[index]["moveTo"] === true){
								vertArray[vertArray.length - 1]["moveTo"] = true;
							}							else
{
								if (this.vertices[index]["moveTo"] === false){
									vertArray[vertArray.length - 1]["moveTo"] = false;
								}
							}
							p.breakShape = false;
						}						else
{
							if (this.vertexCodes[i] === PConstants.BEZIER_VERTEX){
								p.bezierVertex(this.vertices[index + 0][0], this.vertices[index + 0][1], this.vertices[index + 0][2], this.vertices[index + 1][0], this.vertices[index + 1][1], this.vertices[index + 1][2], this.vertices[index + 2][0], this.vertices[index + 2][1], this.vertices[index + 2][2]);
								index += 3;
							}							else
{
								if (this.vertexCodes[i] === PConstants.CURVE_VERTEX){
									p.curveVertex(this.vertices[index][0], this.vertices[index][1], this.vertices[index][2]);
									index++;
								}								else
{
									if (this.vertexCodes[i] === PConstants.BREAK){
										p.breakShape = true;
									}
								}
							}
						}
					}
				}
			}
			p.endShape(this.close ? PConstants.CLOSE : PConstants.OPEN);
		}), 		drawGeometry:		(function (){
			var i; var j;
			p.beginShape(this.kind);
			if (this.style){
				for(i = 0, j = this.vertices.length; i < j;i++){
					p.vertex(this.vertices[i]);
				}
			}			else
{
				for(i = 0, j = this.vertices.length; i < j;i++){
					var vert = this.vertices[i];
					if (vert[2] === 0){
						p.vertex(vert[0], vert[1]);
					}					else
{
						p.vertex(vert[0], vert[1], vert[2]);
					}
				}
			}
			p.endShape();
		}), 		drawGroup:		(function (){
			for(var i = 0, j = this.children.length; i < j;i++){
				this.children[i].draw();
			}
		}), 		drawPrimitive:		(function (){
			if (this.kind === PConstants.POINT){
				p.point(this.params[0], this.params[1]);
			}			else
{
				if (this.kind === PConstants.LINE){
					if (this.params.length === 4){
						p.line(this.params[0], this.params[1], this.params[2], this.params[3]);
					}					else
{
						p.line(this.params[0], this.params[1], this.params[2], this.params[3], this.params[4], this.params[5]);
					}
				}				else
{
					if (this.kind === PConstants.TRIANGLE){
						p.triangle(this.params[0], this.params[1], this.params[2], this.params[3], this.params[4], this.params[5]);
					}					else
{
						if (this.kind === PConstants.QUAD){
							p.quad(this.params[0], this.params[1], this.params[2], this.params[3], this.params[4], this.params[5], this.params[6], this.params[7]);
						}						else
{
							if (this.kind === PConstants.RECT){
								if (this.image !== null){
									p.imageMode(PConstants.CORNER);
									p.image(this.image, this.params[0], this.params[1], this.params[2], this.params[3]);
								}								else
{
									p.rectMode(PConstants.CORNER);
									p.rect(this.params[0], this.params[1], this.params[2], this.params[3]);
								}
							}							else
{
								if (this.kind === PConstants.ELLIPSE){
									p.ellipseMode(PConstants.CORNER);
									p.ellipse(this.params[0], this.params[1], this.params[2], this.params[3]);
								}								else
{
									if (this.kind === PConstants.ARC){
										p.ellipseMode(PConstants.CORNER);
										p.arc(this.params[0], this.params[1], this.params[2], this.params[3], this.params[4], this.params[5]);
									}									else
{
										if (this.kind === PConstants.BOX){
											if (this.params.length === 1){
												p.box(this.params[0]);
											}											else
{
												p.box(this.params[0], this.params[1], this.params[2]);
											}
										}										else
{
											if (this.kind === PConstants.SPHERE){
												p.sphere(this.params[0]);
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}), 		pre:		(function (){
			if (this.matrix){
				p.pushMatrix();
				curContext.transform(this.matrix.elements[0], this.matrix.elements[3], this.matrix.elements[1], this.matrix.elements[4], this.matrix.elements[2], this.matrix.elements[5]);
			}
			if (this.style){
				p.pushStyle();
				this.styles();
			}
		}), 		post:		(function (){
			if (this.matrix){
				p.popMatrix();
			}
			if (this.style){
				p.popStyle();
			}
		}), 		styles:		(function (){
			if (this.stroke){
				p.stroke(this.strokeColor);
				p.strokeWeight(this.strokeWeight);
				p.strokeCap(this.strokeCap);
				p.strokeJoin(this.strokeJoin);
			}			else
{
				p.noStroke();
			}
			if (this.fill){
				p.fill(this.fillColor);
			}			else
{
				p.noFill();
			}
		}), 		getChild:		(function (child){
			var i; var j;
			if (typeofchild === 'number'){
				return this.children[child];
			}			else
{
				var found;
				if ((child === "") || (this.name === child)){
					return this;
				}				else
{
					if (this.nameTable.length > 0){
						for(i = 0, j = this.nameTable.length; (i < j) || found;i++){
							if (this.nameTable[i].getName === child){
								found = this.nameTable[i];
							}
						}
						if (found){
							return found;
						}
					}
					for(i = 0, j = this.children.length; i < j;i++){
						found = this.children[i].getChild(child);
						if (found){
							return found;
						}
					}
				}
				return null;
			}
		}), 		getChildCount:		(function (){
			return this.children.length;
		}), 		addChild:		(function (child){
			this.children.push(child);
			child.parent = this;
			if (child.getName() !== null){
				this.addName(child.getName(), child);
			}
		}), 		addName:		(function (name, shape){
			if (this.parent !== null){
				this.parent.addName(name, shape);
			}			else
{
				this.nameTable.push([name,shape]);
			}
		}), 		translate:		(function (){
			if (arguments.length === 2){
				this.checkMatrix(2);
				this.matrix.translate(arguments[0], arguments[1]);
			}			else
{
				this.checkMatrix(3);
				this.matrix.translate(arguments[0], arguments[1], 0);
			}
		}), 		checkMatrix:		(function (dimensions){
			if (this.matrix === null){
				if (dimensions === 2){
					this.matrix = new p.PMatrix2D();
				}				else
{
					this.matrix = new p.PMatrix3D();
				}
			}			else
{
				if ((dimensions === 3) && (this.matrix instanceof p.PMatrix2D)){
					this.matrix = new p.PMatrix3D();
				}
			}
		}), 		rotateX:		(function (angle){
			this.rotate(angle, 1, 0, 0);
		}), 		rotateY:		(function (angle){
			this.rotate(angle, 0, 1, 0);
		}), 		rotateZ:		(function (angle){
			this.rotate(angle, 0, 0, 1);
		}), 		rotate:		(function (){
			if (arguments.length === 1){
				this.checkMatrix(2);
				this.matrix.rotate(arguments[0]);
			}			else
{
				this.checkMatrix(3);
				this.matrix.rotate(arguments[0], arguments[1], arguments[2], arguments[3]);
			}
		}), 		scale:		(function (){
			if (arguments.length === 2){
				this.checkMatrix(2);
				this.matrix.scale(arguments[0], arguments[1]);
			}			else
{
				if (arguments.length === 3){
					this.checkMatrix(2);
					this.matrix.scale(arguments[0], arguments[1], arguments[2]);
				}				else
{
					this.checkMatrix(2);
					this.matrix.scale(arguments[0]);
				}
			}
		}), 		resetMatrix:		(function (){
			this.checkMatrix(2);
			this.matrix.reset();
		}), 		applyMatrix:		(function (matrix){
			if (arguments.length === 1){
				this.applyMatrix(matrix.elements[0], matrix.elements[1], 0, matrix.elements[2], matrix.elements[3], matrix.elements[4], 0, matrix.elements[5], 0, 0, 1, 0, 0, 0, 0, 1);
			}			else
{
				if (arguments.length === 6){
					this.checkMatrix(2);
					this.matrix.apply(arguments[0], arguments[1], arguments[2], 0, arguments[3], arguments[4], arguments[5], 0, 0, 0, 1, 0, 0, 0, 0, 1);
				}				else
{
					if (arguments.length === 16){
						this.checkMatrix(3);
						this.matrix.apply(arguments[0], arguments[1], arguments[2], arguments[3], arguments[4], arguments[5], arguments[6], arguments[7], arguments[8], arguments[9], arguments[10], arguments[11], arguments[12], arguments[13], arguments[14], arguments[15]);
					}
				}
			}
		})		};
		var PShapeSVG = p.PShapeSVG = 		(function (){
			p.PShape.call(this);
			if (arguments.length === 1){
				this.element = arguments[0];
				this.vertexCodes = [];
				this.vertices = [];
				this.opacity = 1;
				this.stroke = false;
				this.strokeColor = PConstants.ALPHA_MASK;
				this.strokeWeight = 1;
				this.strokeCap = PConstants.SQUARE;
				this.strokeJoin = PConstants.MITER;
				this.strokeGradient = null;
				this.strokeGradientPaint = null;
				this.strokeName = null;
				this.strokeOpacity = 1;
				this.fill = true;
				this.fillColor = PConstants.ALPHA_MASK;
				this.fillGradient = null;
				this.fillGradientPaint = null;
				this.fillName = null;
				this.fillOpacity = 1;
				if (this.element.getName() !== "svg"){
					throw ("root is not <svg>, it's <" + this.element.getName()) + ">";
				}
			}			else
{
				if (arguments.length === 2){
					if (typeofarguments[1] === 'string'){
						if (arguments[1].indexOf(".svg") > -1){
							this.element = new p.XMLElement(null, arguments[1]);
							this.vertexCodes = [];
							this.vertices = [];
							this.opacity = 1;
							this.stroke = false;
							this.strokeColor = PConstants.ALPHA_MASK;
							this.strokeWeight = 1;
							this.strokeCap = PConstants.SQUARE;
							this.strokeJoin = PConstants.MITER;
							this.strokeGradient = "";
							this.strokeGradientPaint = "";
							this.strokeName = "";
							this.strokeOpacity = 1;
							this.fill = true;
							this.fillColor = PConstants.ALPHA_MASK;
							this.fillGradient = null;
							this.fillGradientPaint = null;
							this.fillOpacity = 1;
						}
					}					else
{
						if (arguments[0]){
							this.element = arguments[1];
							this.vertexCodes = arguments[0].vertexCodes.slice();
							this.vertices = arguments[0].vertices.slice();
							this.stroke = arguments[0].stroke;
							this.strokeColor = arguments[0].strokeColor;
							this.strokeWeight = arguments[0].strokeWeight;
							this.strokeCap = arguments[0].strokeCap;
							this.strokeJoin = arguments[0].strokeJoin;
							this.strokeGradient = arguments[0].strokeGradient;
							this.strokeGradientPaint = arguments[0].strokeGradientPaint;
							this.strokeName = arguments[0].strokeName;
							this.fill = arguments[0].fill;
							this.fillColor = arguments[0].fillColor;
							this.fillGradient = arguments[0].fillGradient;
							this.fillGradientPaint = arguments[0].fillGradientPaint;
							this.fillName = arguments[0].fillName;
							this.strokeOpacity = arguments[0].strokeOpacity;
							this.fillOpacity = arguments[0].fillOpacity;
							this.opacity = arguments[0].opacity;
						}
					}
				}
			}
			this.name = this.element.getStringAttribute("id");
			var displayStr = this.element.getStringAttribute("display", "inline");
			this.visible = (displayStr !== "none");
			var str = this.element.getAttribute("transform");
			if (str){
				this.matrix = this.parseMatrix(str);
			}
			var viewBoxStr = this.element.getStringAttribute("viewBox");
			if (viewBoxStr !== null){
				var viewBox = viewBoxStr.split(" ");
				this.width = viewBox[2];
				this.height = viewBox[3];
			}
			var unitWidth = this.element.getStringAttribute("width");
			var unitHeight = this.element.getStringAttribute("height");
			if (unitWidth !== null){
				this.width = this.parseUnitSize(unitWidth);
				this.height = this.parseUnitSize(unitHeight);
			}			else
{
				if ((this.width === 0) || (this.height === 0)){
					this.width = 1;
					this.height = 1;
					throw "The width and/or height is not " + "readable in the <svg> tag of this file.";
				}
			}
			this.parseColors(this.element);
			this.parseChildren(this.element);
		});
		PShapeSVG.prototype = new PShape();
		PShapeSVG.prototype.parseMatrix = 		(function (){
						function getCoords(s){
				var m = [];
				s.replace(/\((.*?)\)/, 				(function (){
					return 					(function (all, params){
						m = params.replace(/,+/g, " ").split(/\s+/);
					});
				})());
			}
			return 			(function (str){
				this.checkMatrix(2);
				var pieces = [];
				str.replace(/\s*(\w+)\((.*?)\)/g, 				(function (all){
					pieces.push(p.trim(all));
				}));
				if (pieces.length === 0){
					return null;
				}
				for(var i = 0, j = pieces.length; i < j;i++){
					var m = getCoords(pieces[i]);
					if (pieces[i].indexOf("matrix") !== -1){
						this.matrix.set(m[0], m[2], m[4], m[1], m[3], m[5]);
					}					else
{
						if (pieces[i].indexOf("translate") !== -1){
							var tx = m[0];
							var ty = (m.length === 2) ? m[1] : 0;
							this.matrix.translate(tx, ty);
						}						else
{
							if (pieces[i].indexOf("scale") !== -1){
								var sx = m[0];
								var sy = (m.length === 2) ? m[1] : m[0];
								this.matrix.scale(sx, sy);
							}							else
{
								if (pieces[i].indexOf("rotate") !== -1){
									var angle = m[0];
									if (m.length === 1){
										this.matrix.rotate(p.radians(angle));
									}									else
{
										if (m.length === 3){
											this.matrix.translate(m[1], m[2]);
											this.matrix.rotate(p.radians(m[0]));
											this.matrix.translate(-m[1], -m[2]);
										}
									}
								}								else
{
									if (pieces[i].indexOf("skewX") !== -1){
										this.matrix.skewX(parseFloat(m[0]));
									}									else
{
										if (pieces[i].indexOf("skewY") !== -1){
											this.matrix.skewY(m[0]);
										}
									}
								}
							}
						}
					}
				}
				return this.matrix;
			});
		})();
		PShapeSVG.prototype.parseChildren = 		(function (element){
			var newelement = element.getChildren();
			var children = new p.PShape();
			for(var i = 0, j = newelement.length; i < j;i++){
				var kid = this.parseChild(newelement[i]);
				if (kid){
					children.addChild(kid);
				}
			}
			this.children.push(children);
		});
		PShapeSVG.prototype.getName = 		(function (){
			return this.name;
		});
		PShapeSVG.prototype.parseChild = 		(function (elem){
			var name = elem.getName();
			var shape;
			if (name === "g"){
				shape = new PShapeSVG(this, elem);
			}			else
{
				if (name === "defs"){
					shape = new PShapeSVG(this, elem);
				}				else
{
					if (name === "line"){
						shape = new PShapeSVG(this, elem);
						shape.parseLine();
					}					else
{
						if (name === "circle"){
							shape = new PShapeSVG(this, elem);
							shape.parseEllipse(true);
						}						else
{
							if (name === "ellipse"){
								shape = new PShapeSVG(this, elem);
								shape.parseEllipse(false);
							}							else
{
								if (name === "rect"){
									shape = new PShapeSVG(this, elem);
									shape.parseRect();
								}								else
{
									if (name === "polygon"){
										shape = new PShapeSVG(this, elem);
										shape.parsePoly(true);
									}									else
{
										if (name === "polyline"){
											shape = new PShapeSVG(this, elem);
											shape.parsePoly(false);
										}										else
{
											if (name === "path"){
												shape = new PShapeSVG(this, elem);
												shape.parsePath();
											}											else
{
												if (name === "radialGradient"){
													unimplemented('PShapeSVG.prototype.parseChild, name = radialGradient');
												}												else
{
													if (name === "linearGradient"){
														unimplemented('PShapeSVG.prototype.parseChild, name = linearGradient');
													}													else
{
														if (name === "text"){
															unimplemented('PShapeSVG.prototype.parseChild, name = text');
														}														else
{
															if (name === "filter"){
																unimplemented('PShapeSVG.prototype.parseChild, name = filter');
															}															else
{
																if (name === "mask"){
																	unimplemented('PShapeSVG.prototype.parseChild, name = mask');
																}																else
{
																	nop();
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			return shape;
		});
		PShapeSVG.prototype.parsePath = 		(function (){
			this.family = PConstants.PATH;
			this.kind = 0;
			var pathDataChars = [];
			var c;
			var pathData = p.trim(this.element.getStringAttribute("d").replace(/[\s,]+/g, ' '));
			if (pathData === null){
				return ;
			}
			pathData = p.__toCharArray(pathData);
			var cx = 0; var cy = 0; var ctrlX = 0; var ctrlY = 0; var ctrlX1 = 0; var ctrlX2 = 0; var ctrlY1 = 0; var ctrlY2 = 0; var endX = 0; var endY = 0; var ppx = 0; var ppy = 0; var px = 0; var py = 0; var i = 0; var valOf = 0;
			var str = "";
			var tmpArray = [];
			var flag = false;
			var lastInstruction;
			var command;
			var j; var k;
			while(i < pathData.length){
				valOf = pathData[i].valueOf();
				if (((valOf >= 65) && (valOf <= 90)) || ((valOf >= 97) && (valOf <= 122))){
					j = i;
					i++;
					if (i < pathData.length){
						tmpArray = [];
						valOf = pathData[i].valueOf();
						while(!((((valOf >= 65) && (valOf <= 90)) || ((valOf >= 97) && (valOf <= 100))) || ((valOf >= 102) && (valOf <= 122))) && (flag === false)){
							if (valOf === 32){
								if (str !== ""){
									tmpArray.push(parseFloat(str));
									str = "";
								}
								i++;
							}							else
{
								if (valOf === 45){
									if (pathData[i - 1].valueOf() === 101){
										str += pathData[i].toString();
										i++;
									}									else
{
										if (str !== ""){
											tmpArray.push(parseFloat(str));
										}
										str = pathData[i].toString();
										i++;
									}
								}								else
{
									str += pathData[i].toString();
									i++;
								}
							}
							if (i === pathData.length){
								flag = true;
							}							else
{
								valOf = pathData[i].valueOf();
							}
						}
					}
					if (str !== ""){
						tmpArray.push(parseFloat(str));
						str = "";
					}
					command = pathData[j];
					valOf = command.valueOf();
					if (valOf === 77){
						if ((tmpArray.length >= 2) && ((tmpArray.length % 2) === 0)){
							cx = tmpArray[0];
							cy = tmpArray[1];
							this.parsePathMoveto(cx, cy);
							if (tmpArray.length > 2){
								for(j = 2, k = tmpArray.length; j < k;j += 2){
									cx = tmpArray[j];
									cy = tmpArray[j + 1];
									this.parsePathLineto(cx, cy);
								}
							}
						}
					}					else
{
						if (valOf === 109){
							if ((tmpArray.length >= 2) && ((tmpArray.length % 2) === 0)){
								this.parsePathMoveto(cx, cy);
								if (tmpArray.length > 2){
									for(j = 2, k = tmpArray.length; j < k;j += 2){
										cx += tmpArray[j];
										cy += tmpArray[j + 1];
										this.parsePathLineto(cx, cy);
									}
								}
							}
						}						else
{
							if (valOf === 76){
								if ((tmpArray.length >= 2) && ((tmpArray.length % 2) === 0)){
									for(j = 0, k = tmpArray.length; j < k;j += 2){
										cx = tmpArray[j];
										cy = tmpArray[j + 1];
										this.parsePathLineto(cx, cy);
									}
								}
							}							else
{
								if (valOf === 108){
									if ((tmpArray.length >= 2) && ((tmpArray.length % 2) === 0)){
										for(j = 0, k = tmpArray.length; j < k;j += 2){
											cx += tmpArray[j];
											cy += tmpArray[j + 1];
											this.parsePathLineto(cx, cy);
										}
									}
								}								else
{
									if (valOf === 72){
										for(j = 0, k = tmpArray.length; j < k;j++){
											cx = tmpArray[j];
											this.parsePathLineto(cx, cy);
										}
									}									else
{
										if (valOf === 104){
											for(j = 0, k = tmpArray.length; j < k;j++){
												cx += tmpArray[j];
												this.parsePathLineto(cx, cy);
											}
										}										else
{
											if (valOf === 86){
												for(j = 0, k = tmpArray.length; j < k;j++){
													cy = tmpArray[j];
													this.parsePathLineto(cx, cy);
												}
											}											else
{
												if (valOf === 118){
													for(j = 0, k = tmpArray.length; j < k;j++){
														cy += tmpArray[j];
														this.parsePathLineto(cx, cy);
													}
												}												else
{
													if (valOf === 67){
														if ((tmpArray.length >= 6) && ((tmpArray.length % 6) === 0)){
															for(j = 0, k = tmpArray.length; j < k;j += 6){
																ctrlX1 = tmpArray[j];
																ctrlY1 = tmpArray[j + 1];
																ctrlX2 = tmpArray[j + 2];
																ctrlY2 = tmpArray[j + 3];
																endX = tmpArray[j + 4];
																endY = tmpArray[j + 5];
																this.parsePathCurveto(ctrlX1, ctrlY1, ctrlX2, ctrlY2, endX, endY);
																cx = endX;
																cy = endY;
															}
														}
													}													else
{
														if (valOf === 99){
															if ((tmpArray.length >= 6) && ((tmpArray.length % 6) === 0)){
																for(j = 0, k = tmpArray.length; j < k;j += 6){
																	ctrlX1 = (cx + tmpArray[j]);
																	ctrlY1 = (cy + tmpArray[j + 1]);
																	ctrlX2 = (cx + tmpArray[j + 2]);
																	ctrlY2 = (cy + tmpArray[j + 3]);
																	endX = (cx + tmpArray[j + 4]);
																	endY = (cy + tmpArray[j + 5]);
																	this.parsePathCurveto(ctrlX1, ctrlY1, ctrlX2, ctrlY2, endX, endY);
																	cx = endX;
																	cy = endY;
																}
															}
														}														else
{
															if (valOf === 83){
																if ((tmpArray.length >= 4) && ((tmpArray.length % 4) === 0)){
																	for(j = 0, k = tmpArray.length; j < k;j += 4){
																		if ((lastInstruction.toLowerCase() === "c") || (lastInstruction.toLowerCase() === "s")){
																			ppx = this.vertices[this.vertices.length - 2][0];
																			ppy = this.vertices[this.vertices.length - 2][1];
																			px = this.vertices[this.vertices.length - 1][0];
																			py = this.vertices[this.vertices.length - 1][1];
																			ctrlX1 = (px + (px - ppx));
																			ctrlY1 = (py + (py - ppy));
																		}																		else
{
																			ctrlX1 = this.vertices[this.vertices.length - 1][0];
																			ctrlY1 = this.vertices[this.vertices.length - 1][1];
																		}
																		ctrlX2 = tmpArray[j];
																		ctrlY2 = tmpArray[j + 1];
																		endX = tmpArray[j + 2];
																		endY = tmpArray[j + 3];
																		this.parsePathCurveto(ctrlX1, ctrlY1, ctrlX2, ctrlY2, endX, endY);
																		cx = endX;
																		cy = endY;
																	}
																}
															}															else
{
																if (valOf === 115){
																	if ((tmpArray.length >= 4) && ((tmpArray.length % 4) === 0)){
																		for(j = 0, k = tmpArray.length; j < k;j += 4){
																			if ((lastInstruction.toLowerCase() === "c") || (lastInstruction.toLowerCase() === "s")){
																				ppx = this.vertices[this.vertices.length - 2][0];
																				ppy = this.vertices[this.vertices.length - 2][1];
																				px = this.vertices[this.vertices.length - 1][0];
																				py = this.vertices[this.vertices.length - 1][1];
																				ctrlX1 = (px + (px - ppx));
																				ctrlY1 = (py + (py - ppy));
																			}																			else
{
																				ctrlX1 = this.vertices[this.vertices.length - 1][0];
																				ctrlY1 = this.vertices[this.vertices.length - 1][1];
																			}
																			ctrlX2 = (cx + tmpArray[j]);
																			ctrlY2 = (cy + tmpArray[j + 1]);
																			endX = (cx + tmpArray[j + 2]);
																			endY = (cy + tmpArray[j + 3]);
																			this.parsePathCurveto(ctrlX1, ctrlY1, ctrlX2, ctrlY2, endX, endY);
																			cx = endX;
																			cy = endY;
																		}
																	}
																}																else
{
																	if (valOf === 81){
																		if ((tmpArray.length >= 4) && ((tmpArray.length % 4) === 0)){
																			for(j = 0, k = tmpArray.length; j < k;j += 4){
																				ctrlX = tmpArray[j];
																				ctrlY = tmpArray[j + 1];
																				endX = tmpArray[j + 2];
																				endY = tmpArray[j + 3];
																				this.parsePathQuadto(cx, cy, ctrlX, ctrlY, endX, endY);
																				cx = endX;
																				cy = endY;
																			}
																		}
																	}																	else
{
																		if (valOf === 113){
																			if ((tmpArray.length >= 4) && ((tmpArray.length % 4) === 0)){
																				for(j = 0, k = tmpArray.length; j < k;j += 4){
																					ctrlX = (cx + tmpArray[j]);
																					ctrlY = (cy + tmpArray[j + 1]);
																					endX = (cx + tmpArray[j + 2]);
																					endY = (cy + tmpArray[j + 3]);
																					this.parsePathQuadto(cx, cy, ctrlX, ctrlY, endX, endY);
																					cx = endX;
																					cy = endY;
																				}
																			}
																		}																		else
{
																			if (valOf === 84){
																				if ((tmpArray.length >= 2) && ((tmpArray.length % 2) === 0)){
																					for(j = 0, k = tmpArray.length; j < k;j += 2){
																						if ((lastInstruction.toLowerCase() === "q") || (lastInstruction.toLowerCase() === "t")){
																							ppx = this.vertices[this.vertices.length - 2][0];
																							ppy = this.vertices[this.vertices.length - 2][1];
																							px = this.vertices[this.vertices.length - 1][0];
																							py = this.vertices[this.vertices.length - 1][1];
																							ctrlX = (px + (px - ppx));
																							ctrlY = (py + (py - ppy));
																						}																						else
{
																							ctrlX = cx;
																							ctrlY = cy;
																						}
																						endX = tmpArray[j];
																						endY = tmpArray[j + 1];
																						this.parsePathQuadto(cx, cy, ctrlX, ctrlY, endX, endY);
																						cx = endX;
																						cy = endY;
																					}
																				}
																			}																			else
{
																				if (valOf === 116){
																					if ((tmpArray.length >= 2) && ((tmpArray.length % 2) === 0)){
																						for(j = 0, k = tmpArray.length; j < k;j += 2){
																							if ((lastInstruction.toLowerCase() === "q") || (lastInstruction.toLowerCase() === "t")){
																								ppx = this.vertices[this.vertices.length - 2][0];
																								ppy = this.vertices[this.vertices.length - 2][1];
																								px = this.vertices[this.vertices.length - 1][0];
																								py = this.vertices[this.vertices.length - 1][1];
																								ctrlX = (px + (px - ppx));
																								ctrlY = (py + (py - ppy));
																							}																							else
{
																								ctrlX = cx;
																								ctrlY = cy;
																							}
																							endX = (cx + tmpArray[j]);
																							endY = (cy + tmpArray[j + 1]);
																							this.parsePathQuadto(cx, cy, ctrlX, ctrlY, endX, endY);
																							cx = endX;
																							cy = endY;
																						}
																					}
																				}																				else
{
																					if (valOf === 90){
																						nop();
																					}																					else
{
																						if (valOf === 122){
																							this.close = true;
																						}
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
					lastInstruction = command.toString();
				}				else
{
					i++;
				}
			}
		});
		PShapeSVG.prototype.parsePathQuadto = 		(function (x1, y1, cx, cy, x2, y2){
			if (this.vertices.length > 0){
				this.parsePathCode(PConstants.BEZIER_VERTEX);
				this.parsePathVertex(x1 + (((cx - x1) * 2) / 3), y1 + (((cy - y1) * 2) / 3));
				this.parsePathVertex(x2 + (((cx - x2) * 2) / 3), y2 + (((cy - y2) * 2) / 3));
				this.parsePathVertex(x2, y2);
			}			else
{
				throw "Path must start with M/m";
			}
		});
		PShapeSVG.prototype.parsePathCurveto = 		(function (x1, y1, x2, y2, x3, y3){
			if (this.vertices.length > 0){
				this.parsePathCode(PConstants.BEZIER_VERTEX);
				this.parsePathVertex(x1, y1);
				this.parsePathVertex(x2, y2);
				this.parsePathVertex(x3, y3);
			}			else
{
				throw "Path must start with M/m";
			}
		});
		PShapeSVG.prototype.parsePathLineto = 		(function (px, py){
			if (this.vertices.length > 0){
				this.parsePathCode(PConstants.VERTEX);
				this.parsePathVertex(px, py);
				this.vertices[this.vertices.length - 1]["moveTo"] = false;
			}			else
{
				throw "Path must start with M/m";
			}
		});
		PShapeSVG.prototype.parsePathMoveto = 		(function (px, py){
			if (this.vertices.length > 0){
				this.parsePathCode(PConstants.BREAK);
			}
			this.parsePathCode(PConstants.VERTEX);
			this.parsePathVertex(px, py);
			this.vertices[this.vertices.length - 1]["moveTo"] = true;
		});
		PShapeSVG.prototype.parsePathVertex = 		(function (x, y){
			var verts = [];
			verts[0] = x;
			verts[1] = y;
			this.vertices.push(verts);
		});
		PShapeSVG.prototype.parsePathCode = 		(function (what){
			this.vertexCodes.push(what);
		});
		PShapeSVG.prototype.parsePoly = 		(function (val){
			this.family = PConstants.PATH;
			this.close = val;
			var pointsAttr = p.trim(this.element.getStringAttribute("points").replace(/[,\s]+/g, ' '));
			if (pointsAttr !== null){
				var pointsBuffer = pointsAttr.split(" ");
				if ((pointsBuffer.length % 2) === 0){
					for(var i = 0, j = pointsBuffer.length; i < j;i++){
						var verts = [];
						verts[0] = pointsBuffer[i];
						verts[1] = pointsBuffer[++i];
						this.vertices.push(verts);
					}
				}				else
{
					throw "Error parsing polygon points: odd number of coordinates provided";
				}
			}
		});
		PShapeSVG.prototype.parseRect = 		(function (){
			this.kind = PConstants.RECT;
			this.family = PConstants.PRIMITIVE;
			this.params = [];
			this.params[0] = this.element.getFloatAttribute("x");
			this.params[1] = this.element.getFloatAttribute("y");
			this.params[2] = this.element.getFloatAttribute("width");
			this.params[3] = this.element.getFloatAttribute("height");
		});
		PShapeSVG.prototype.parseEllipse = 		(function (val){
			this.kind = PConstants.ELLIPSE;
			this.family = PConstants.PRIMITIVE;
			this.params = [];
			this.params[0] = this.element.getFloatAttribute("cx");
			this.params[1] = this.element.getFloatAttribute("cy");
			var rx; var ry;
			if (val){
				rx = (ry = this.element.getFloatAttribute("r"));
			}			else
{
				rx = this.element.getFloatAttribute("rx");
				ry = this.element.getFloatAttribute("ry");
			}
			this.params[0] -= rx;
			this.params[1] -= ry;
			this.params[2] = (rx * 2);
			this.params[3] = (ry * 2);
		});
		PShapeSVG.prototype.parseLine = 		(function (){
			this.kind = PConstants.LINE;
			this.family = PConstants.PRIMITIVE;
			this.params = [];
			this.params[0] = this.element.getFloatAttribute("x1");
			this.params[1] = this.element.getFloatAttribute("y1");
			this.params[2] = this.element.getFloatAttribute("x2");
			this.params[3] = this.element.getFloatAttribute("y2");
		});
		PShapeSVG.prototype.parseColors = 		(function (element){
			if (element.hasAttribute("opacity")){
				this.setOpacity(element.getAttribute("opacity"));
			}
			if (element.hasAttribute("stroke")){
				this.setStroke(element.getAttribute("stroke"));
			}
			if (element.hasAttribute("stroke-width")){
				this.setStrokeWeight(element.getAttribute("stroke-width"));
			}
			if (element.hasAttribute("stroke-linejoin")){
				this.setStrokeJoin(element.getAttribute("stroke-linejoin"));
			}
			if (element.hasAttribute("stroke-linecap")){
				this.setStrokeCap(element.getStringAttribute("stroke-linecap"));
			}
			if (element.hasAttribute("fill")){
				this.setFill(element.getStringAttribute("fill"));
			}
			if (element.hasAttribute("style")){
				var styleText = element.getStringAttribute("style");
				var styleTokens = styleText.toString().split(";");
				for(var i = 0, j = styleTokens.length; i < j;i++){
					var tokens = p.trim(styleTokens[i].split(":"));
					if (tokens[0] === "fill"){
						this.setFill(tokens[1]);
					}					else
{
						if (tokens[0] === "fill-opacity"){
							this.setFillOpacity(tokens[1]);
						}						else
{
							if (tokens[0] === "stroke"){
								this.setStroke(tokens[1]);
							}							else
{
								if (tokens[0] === "stroke-width"){
									this.setStrokeWeight(tokens[1]);
								}								else
{
									if (tokens[0] === "stroke-linecap"){
										this.setStrokeCap(tokens[1]);
									}									else
{
										if (tokens[0] === "stroke-linejoin"){
											this.setStrokeJoin(tokens[1]);
										}										else
{
											if (tokens[0] === "stroke-opacity"){
												this.setStrokeOpacity(tokens[1]);
											}											else
{
												if (tokens[0] === "opacity"){
													this.setOpacity(tokens[1]);
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		});
		PShapeSVG.prototype.setFillOpacity = 		(function (opacityText){
			this.fillOpacity = parseFloat(opacityText);
			this.fillColor = (((this.fillOpacity * 255) << 24) | (this.fillColor & -1));
		});
		PShapeSVG.prototype.setFill = 		(function (fillText){
			var opacityMask = this.fillColor & -16777216;
			if (fillText === "none"){
				this.fill = false;
			}			else
{
				if (fillText.indexOf("#") === 0){
					this.fill = true;
					this.fillColor = (opacityMask | (parseInt(fillText.substring(1), 16) & -1));
				}				else
{
					if (fillText.indexOf("rgb") === 0){
						this.fill = true;
						this.fillColor = (opacityMask | this.parseRGB(fillText));
					}					else
{
						if (fillText.indexOf("url(#") === 0){
							this.fillName = fillText.substring(5, fillText.length - 1);
						}						else
{
							if (colors[fillText]){
								this.fill = true;
								this.fillColor = (opacityMask | (parseInt(colors[fillText].substring(1), 16) & -1));
							}
						}
					}
				}
			}
		});
		PShapeSVG.prototype.setOpacity = 		(function (opacity){
			this.strokeColor = (((parseFloat(opacity) * 255) << 24) | (this.strokeColor & -1));
			this.fillColor = (((parseFloat(opacity) * 255) << 24) | (this.fillColor & -1));
		});
		PShapeSVG.prototype.setStroke = 		(function (strokeText){
			var opacityMask = this.strokeColor & -16777216;
			if (strokeText === "none"){
				this.stroke = false;
			}			else
{
				if (strokeText.charAt(0) === "#"){
					this.stroke = true;
					this.strokeColor = (opacityMask | (parseInt(strokeText.substring(1), 16) & -1));
				}				else
{
					if (strokeText.indexOf("rgb") === 0){
						this.stroke = true;
						this.strokeColor = (opacityMask | this.parseRGB(strokeText));
					}					else
{
						if (strokeText.indexOf("url(#") === 0){
							this.strokeName = strokeText.substring(5, strokeText.length - 1);
						}						else
{
							if (colors[strokeText]){
								this.stroke = true;
								this.strokeColor = (opacityMask | (parseInt(colors[strokeText].substring(1), 16) & -1));
							}
						}
					}
				}
			}
		});
		PShapeSVG.prototype.setStrokeWeight = 		(function (weight){
			this.strokeWeight = this.parseUnitSize(weight);
		});
		PShapeSVG.prototype.setStrokeJoin = 		(function (linejoin){
			if (linejoin === "miter"){
				this.strokeJoin = PConstants.MITER;
			}			else
{
				if (linejoin === "round"){
					this.strokeJoin = PConstants.ROUND;
				}				else
{
					if (linejoin === "bevel"){
						this.strokeJoin = PConstants.BEVEL;
					}
				}
			}
		});
		PShapeSVG.prototype.setStrokeCap = 		(function (linecap){
			if (linecap === "butt"){
				this.strokeCap = PConstants.SQUARE;
			}			else
{
				if (linecap === "round"){
					this.strokeCap = PConstants.ROUND;
				}				else
{
					if (linecap === "square"){
						this.strokeCap = PConstants.PROJECT;
					}
				}
			}
		});
		PShapeSVG.prototype.setStrokeOpacity = 		(function (opacityText){
			this.strokeOpacity = parseFloat(opacityText);
			this.strokeColor = (((this.strokeOpacity * 255) << 24) | (this.strokeColor & -1));
		});
		PShapeSVG.prototype.parseRGB = 		(function (color){
			var sub = color.substring(color.indexOf('(') + 1, color.indexOf(')'));
			var values = sub.split(", ");
			return ((values[0] << 16) | (values[1] << 8)) | values[2];
		});
		PShapeSVG.prototype.parseUnitSize = 		(function (text){
			var len = text.length - 2;
			if (len < 0){
				return text;
			}
			if (text.indexOf("pt") === len){
				return parseFloat(text.substring(0, len)) * 1.25;
			}			else
{
				if (text.indexOf("pc") === len){
					return parseFloat(text.substring(0, len)) * 15;
				}				else
{
					if (text.indexOf("mm") === len){
						return parseFloat(text.substring(0, len)) * 3.543307;
					}					else
{
						if (text.indexOf("cm") === len){
							return parseFloat(text.substring(0, len)) * 35.43307;
						}						else
{
							if (text.indexOf("in") === len){
								return parseFloat(text.substring(0, len)) * 90;
							}							else
{
								if (text.indexOf("px") === len){
									return parseFloat(text.substring(0, len));
								}								else
{
									return parseFloat(text);
								}
							}
						}
					}
				}
			}
		});
		p.shape = 		(function (shape, x, y, width, height){
			if ((arguments.length >= 1) && (arguments[0] !== null)){
				if (shape.isVisible()){
					p.pushMatrix();
					if (curShapeMode === PConstants.CENTER){
						if (arguments.length === 5){
							p.translate(x - (width / 2), y - (height / 2));
							p.scale(width / shape.getWidth(), height / shape.getHeight());
						}						else
{
							if (arguments.length === 3){
								p.translate(x - (shape.getWidth() / 2), -shape.getHeight() / 2);
							}							else
{
								p.translate(-shape.getWidth() / 2, -shape.getHeight() / 2);
							}
						}
					}					else
{
						if (curShapeMode === PConstants.CORNER){
							if (arguments.length === 5){
								p.translate(x, y);
								p.scale(width / shape.getWidth(), height / shape.getHeight());
							}							else
{
								if (arguments.length === 3){
									p.translate(x, y);
								}
							}
						}						else
{
							if (curShapeMode === PConstants.CORNERS){
								if (arguments.length === 5){
									width -= x;
									height -= y;
									p.translate(x, y);
									p.scale(width / shape.getWidth(), height / shape.getHeight());
								}								else
{
									if (arguments.length === 3){
										p.translate(x, y);
									}
								}
							}
						}
					}
					shape.draw();
					if (((arguments.length === 1) && (curShapeMode === PConstants.CENTER)) || (arguments.length > 1)){
						p.popMatrix();
					}
				}
			}
		});
		p.shapeMode = 		(function (mode){
			curShapeMode = mode;
		});
		p.loadShape = 		(function (filename){
			if (arguments.length === 1){
				if (filename.indexOf(".svg") > -1){
					return new PShapeSVG(null, filename);
				}
			}
			return null;
		});
		var XMLAttribute = 		(function (fname, n, nameSpace, v, t){
			this.fullName = (fname || "");
			this.name = (n || "");
			this.namespace = (nameSpace || "");
			this.value = v;
			this.type = t;
		});
		XMLAttribute.prototype = {		getName:		(function (){
			return this.name;
		}), 		getFullName:		(function (){
			return this.fullName;
		}), 		getNamespace:		(function (){
			return this.namespace;
		}), 		getValue:		(function (){
			return this.value;
		}), 		getType:		(function (){
			return this.type;
		}), 		setValue:		(function (newval){
			this.value = newval;
		})		};
		var XMLElement = p.XMLElement = 		(function (){
			this.attributes = [];
			this.children = [];
			this.fullName = null;
			this.name = null;
			this.namespace = "";
			this.content = null;
			this.parent = null;
			this.lineNr = "";
			this.systemID = "";
			this.type = "ELEMENT";
			if (arguments.length === 4){
				this.fullName = (arguments[0] || "");
				if (arguments[1]){
					this.name = arguments[1];
				}				else
{
					var index = this.fullName.indexOf(':');
					if (index >= 0){
						this.name = this.fullName.substring(index + 1);
					}					else
{
						this.name = this.fullName;
					}
				}
				this.namespace = arguments[1];
				this.lineNr = arguments[3];
				this.systemID = arguments[2];
			}			else
{
				if ((arguments.length === 2) && (arguments[1].indexOf(".") > -1)){
					this.parse(arguments[arguments.length - 1]);
				}				else
{
					if ((arguments.length === 1) && (typeofarguments[0] === "string")){
						this.parse(arguments[0]);
					}
				}
			}
		});
		XMLElement.prototype = {		parse:		(function (filename){
			var xmlDoc;
			try{
				if ((filename.indexOf(".xml") > -1) || (filename.indexOf(".svg") > -1)){
					filename = ajax(filename);
				}
				xmlDoc = new DOMParser().parseFromString(filename, "text/xml");
				var elements = xmlDoc.documentElement;
				if (elements){
					this.parseChildrenRecursive(null, elements);
				}				else
{
					throw "Error loading document";
				}
				return this;
			}catch( e ){
				throw e;
			}
		}), 		parseChildrenRecursive:		(function (parent, elementpath){
			var xmlelement; var xmlattribute; var tmpattrib; var l; var m; var child;
			if (!parent){
				this.fullName = elementpath.localName;
				this.name = elementpath.nodeName;
				xmlelement = this;
			}			else
{
				xmlelement = new XMLElement(elementpath.localName, elementpath.nodeName, "", "");
				xmlelement.parent = parent;
			}
			if ((elementpath.nodeType === 3) && (elementpath.textContent !== "")){
				return this.createPCDataElement(elementpath.textContent);
			}
			for(l = 0, m = elementpath.attributes.length; l < m;l++){
				tmpattrib = elementpath.attributes[l];
				xmlattribute = new XMLAttribute(tmpattrib.getname, tmpattrib.nodeName, tmpattrib.namespaceURI, tmpattrib.nodeValue, tmpattrib.nodeType);
				xmlelement.attributes.push(xmlattribute);
			}
			for(l = 0, m = elementpath.childNodes.length; l < m;l++){
				var node = elementpath.childNodes[l];
				if ((node.nodeType === 1) || (node.nodeType === 3)){
					child = xmlelement.parseChildrenRecursive(xmlelement, node);
					if (child !== null){
						xmlelement.children.push(child);
					}
				}
			}
			return xmlelement;
		}), 		createElement:		(function (){
			if (arguments.length === 2){
				return new XMLElement(arguments[0], arguments[1], null, null);
			}			else
{
				return new XMLElement(arguments[0], arguments[1], arguments[2], arguments[3]);
			}
		}), 		createPCDataElement:		(function (content){
			if (content.replace(/^\s+$/g, "") === ""){
				return null;
			}
			var pcdata = new XMLElement();
			pcdata.content = content;
			pcdata.type = "TEXT";
			return pcdata;
		}), 		hasAttribute:		(function (){
			if (arguments.length === 1){
				return this.getAttribute(arguments[0]) !== null;
			}			else
{
				if (arguments.length === 2){
					return this.getAttribute(arguments[0], arguments[1]) !== null;
				}
			}
		}), 		equals:		(function (other){
			if (!(other instanceof XMLElement)){
				return false;
			}
			var i; var j;
			if (this.name !== other.getLocalName()){
				return false;
			}
			if (this.attributes.length !== other.getAttributeCount()){
				return false;
			}
			if (this.attributes.length !== other.attributes.length){
				return false;
			}
			var attr_name; var attr_ns; var attr_value; var attr_type; var attr_other;
			for(i = 0, j = this.attributes.length; i < j;i++){
				attr_name = this.attributes[i].getName();
				attr_ns = this.attributes[i].getNamespace();
				attr_other = other.findAttribute(attr_name, attr_ns);
				if (attr_other === null){
					return false;
				}
				if (this.attributes[i].getValue() !== attr_other.getValue()){
					return false;
				}
				if (this.attributes[i].getType() !== attr_other.getType()){
					return false;
				}
			}
			if (this.children.length !== other.getChildCount()){
				return false;
			}
			if (this.children.length > 0){
				var child1; var child2;
				for(i = 0, j = this.children.length; i < j;i++){
					child1 = this.getChild(i);
					child2 = other.getChild(i);
					if (!child1.equals(child2)){
						return false;
					}
				}
				return true;
			}			else
{
				return this.content === other.content;
			}
		}), 		getContent:		(function (){
			if (this.type === "TEXT"){
				return this.content;
			}			else
{
				if ((this.children.length === 1) && (this.children[0].type === "TEXT")){
					return this.children[0].content;
				}
			}
			return null;
		}), 		getAttribute:		(function (){
			var attribute;
			if (arguments.length === 2){
				attribute = this.findAttribute(arguments[0]);
				if (attribute){
					return attribute.getValue();
				}				else
{
					return arguments[1];
				}
			}			else
{
				if (arguments.length === 1){
					attribute = this.findAttribute(arguments[0]);
					if (attribute){
						return attribute.getValue();
					}					else
{
						return null;
					}
				}				else
{
					if (arguments.length === 3){
						attribute = this.findAttribute(arguments[0], arguments[1]);
						if (attribute){
							return attribute.getValue();
						}						else
{
							return arguments[2];
						}
					}
				}
			}
		}), 		getStringAttribute:		(function (){
			if (arguments.length === 1){
				return this.getAttribute(arguments[0]);
			}			else
{
				if (arguments.length === 2){
					return this.getAttribute(arguments[0], arguments[1]);
				}				else
{
					return this.getAttribute(arguments[0], arguments[1], arguments[2]);
				}
			}
		}), 		getString:		(function (attributeName){
			return this.getStringAttribute(attributeName);
		}), 		getFloatAttribute:		(function (){
			if (arguments.length === 1){
				return parseFloat(this.getAttribute(arguments[0], 0));
			}			else
{
				if (arguments.length === 2){
					return this.getAttribute(arguments[0], arguments[1]);
				}				else
{
					return this.getAttribute(arguments[0], arguments[1], arguments[2]);
				}
			}
		}), 		getFloat:		(function (attributeName){
			return this.getFloatAttribute(attributeName);
		}), 		getIntAttribute:		(function (){
			if (arguments.length === 1){
				return this.getAttribute(arguments[0], 0);
			}			else
{
				if (arguments.length === 2){
					return this.getAttribute(arguments[0], arguments[1]);
				}				else
{
					return this.getAttribute(arguments[0], arguments[1], arguments[2]);
				}
			}
		}), 		getInt:		(function (attributeName){
			return this.getIntAttribute(attributeName);
		}), 		hasChildren:		(function (){
			return this.children.length > 0;
		}), 		addChild:		(function (child){
			if (child !== null){
				child.parent = this;
				this.children.push(child);
			}
		}), 		insertChild:		(function (child, index){
			if (child){
				if ((child.getLocalName() === null) && !this.hasChildren()){
					var lastChild = this.children[this.children.length - 1];
					if (lastChild.getLocalName() === null){
						lastChild.setContent(lastChild.getContent() + child.getContent());
						return ;
					}
				}
				child.parent = this;
				this.children.splice(index, 0, child);
			}
		}), 		getChild:		(function (){
			if (typeofarguments[0] === "number"){
				return this.children[arguments[0]];
			}			else
{
				if (arguments[0].indexOf('/') !== -1){
					this.getChildRecursive(arguments[0].split("/"), 0);
				}				else
{
					var kid; var kidName;
					for(var i = 0, j = this.getChildCount(); i < j;i++){
						kid = this.getChild(i);
						kidName = kid.getName();
						if ((kidName !== null) && (kidName === arguments[0])){
							return kid;
						}
					}
					return null;
				}
			}
		}), 		getChildren:		(function (){
			if (arguments.length === 1){
				if (typeofarguments[0] === "number"){
					return this.getChild(arguments[0]);
				}				else
{
					if (arguments[0].indexOf('/') !== -1){
						return this.getChildrenRecursive(arguments[0].split("/"), 0);
					}					else
{
						var matches = [];
						var kid; var kidName;
						for(var i = 0, j = this.getChildCount(); i < j;i++){
							kid = this.getChild(i);
							kidName = kid.getName();
							if ((kidName !== null) && (kidName === arguments[0])){
								matches.push(kid);
							}
						}
						return matches;
					}
				}
			}			else
{
				return this.children;
			}
		}), 		getChildCount:		(function (){
			return this.children.length;
		}), 		getChildRecursive:		(function (items, offset){
			var kid; var kidName;
			for(var i = 0, j = this.getChildCount(); i < j;i++){
				kid = this.getChild(i);
				kidName = kid.getName();
				if ((kidName !== null) && (kidName === items[offset])){
					if (offset === (items.length - 1)){
						return kid;
					}					else
{
						offset += 1;
						return kid.getChildRecursive(items, offset);
					}
				}
			}
			return null;
		}), 		getChildrenRecursive:		(function (items, offset){
			if (offset === (items.length - 1)){
				return this.getChildren(items[offset]);
			}
			var matches = this.getChildren(items[offset]);
			var kidMatches = [];
			for(var i = 0; i < matches.length;i++){
				kidMatches = kidMatches.concat(matches[i].getChildrenRecursive(items, offset + 1));
			}
			return kidMatches;
		}), 		isLeaf:		(function (){
			return !this.hasChildren();
		}), 		listChildren:		(function (){
			var arr = [];
			for(var i = 0, j = this.children.length; i < j;i++){
				arr.push(this.getChild(i).getName());
			}
			return arr;
		}), 		removeAttribute:		(function (name, namespace){
			this.namespace = (namespace || "");
			for(var i = 0, j = this.attributes.length; i < j;i++){
				if ((this.attributes[i].getName() === name) && (this.attributes[i].getNamespace() === this.namespace)){
					this.attributes.splice(i, 1);
					break ;
				}
			}
		}), 		removeChild:		(function (child){
			if (child){
				for(var i = 0, j = this.children.length; i < j;i++){
					if (this.children[i].equals(child)){
						this.children.splice(i, 1);
						break ;
					}
				}
			}
		}), 		removeChildAtIndex:		(function (index){
			if (this.children.length > index){
				this.children.splice(index, 1);
			}
		}), 		findAttribute:		(function (name, namespace){
			this.namespace = (namespace || "");
			for(var i = 0, j = this.attributes.length; i < j;i++){
				if ((this.attributes[i].getName() === name) && (this.attributes[i].getNamespace() === this.namespace)){
					return this.attributes[i];
				}
			}
			return null;
		}), 		setAttribute:		(function (){
			var attr;
			if (arguments.length === 3){
				var index = arguments[0].indexOf(':');
				var name = arguments[0].substring(index + 1);
				attr = this.findAttribute(name, arguments[1]);
				if (attr){
					attr.setValue(arguments[2]);
				}				else
{
					attr = new XMLAttribute(arguments[0], name, arguments[1], arguments[2], "CDATA");
					this.attributes.push(attr);
				}
			}			else
{
				attr = this.findAttribute(arguments[0]);
				if (attr){
					attr.setValue(arguments[1]);
				}				else
{
					attr = new XMLAttribute(arguments[0], arguments[0], null, arguments[1], "CDATA");
					this.attributes.push(attr);
				}
			}
		}), 		setString:		(function (attribute, value){
			this.setAttribute(attribute, value);
		}), 		setInt:		(function (attribute, value){
			this.setAttribute(attribute, value);
		}), 		setFloat:		(function (attribute, value){
			this.setAttribute(attribute, value);
		}), 		setContent:		(function (content){
			if (this.children.length > 0){
				Processing.debug("Tried to set content for XMLElement with children");
			}
			this.content = content;
		}), 		setName:		(function (){
			if (arguments.length === 1){
				this.name = arguments[0];
				this.fullName = arguments[0];
				this.namespace = null;
			}			else
{
				var index = arguments[0].indexOf(':');
				if ((arguments[1] === null) || (index < 0)){
					this.name = arguments[0];
				}				else
{
					this.name = arguments[0].substring(index + 1);
				}
				this.fullName = arguments[0];
				this.namespace = arguments[1];
			}
		}), 		getName:		(function (){
			return this.fullName;
		}), 		getLocalName:		(function (){
			return this.name;
		}), 		getAttributeCount:		(function (){
			return this.attributes.length;
		}), 		toString:		(function (){
			if (this.type === "TEXT"){
				return this.content;
			}
			var tagstring = (((this.namespace !== "") && (this.namespace !== this.name)) ? (this.namespace + ":") : "") + this.name;
			var xmlstring = "<" + tagstring;
			var a; var c;
			for(a = 0; a < this.attributes.length;a++){
				var attr = this.attributes[a];
				xmlstring += (((((" " + attr.getName()) + "=") + '"') + attr.getValue()) + '"');
			}
			if (this.children.length === 0){
				if (this.content === ""){
					xmlstring += "/>";
				}				else
{
					xmlstring += ((((">" + this.content) + "</") + tagstring) + ">");
				}
			}			else
{
				xmlstring += ">";
				for(c = 0; c < this.children.length;c++){
					xmlstring += this.children[c].toString();
				}
				xmlstring += (("</" + tagstring) + ">");
			}
			return xmlstring;
		})		};
		XMLElement.parse = 		(function (xmlstring){
			var element = new XMLElement();
			element.parse(xmlstring);
			return element;
		});
		var printMatrixHelper = 		(function (elements){
			var big = 0;
			for(var i = 0; i < elements.length;i++){
				if (i !== 0){
					big = Math.max(big, Math.abs(elements[i]));
				}				else
{
					big = Math.abs(elements[i]);
				}
			}
			var digits = (big + "").indexOf(".");
			if (digits === 0){
				digits = 1;
			}			else
{
				if (digits === -1){
					digits = (big + "").length;
				}
			}
			return digits;
		});
		var PMatrix2D = p.PMatrix2D = 		(function (){
			if (arguments.length === 0){
				this.reset();
			}			else
{
				if ((arguments.length === 1) && (arguments[0] instanceof PMatrix2D)){
					this.set(arguments[0].array());
				}				else
{
					if (arguments.length === 6){
						this.set(arguments[0], arguments[1], arguments[2], arguments[3], arguments[4], arguments[5]);
					}
				}
			}
		});
		PMatrix2D.prototype = {		set:		(function (){
			if (arguments.length === 6){
				var a = arguments;
				this.set([a[0],a[1],a[2],a[3],a[4],a[5]]);
			}			else
{
				if ((arguments.length === 1) && (arguments[0] instanceof PMatrix2D)){
					this.elements = arguments[0].array();
				}				else
{
					if ((arguments.length === 1) && (arguments[0] instanceof Array)){
						this.elements = arguments[0].slice();
					}
				}
			}
		}), 		get:		(function (){
			var outgoing = new PMatrix2D();
			outgoing.set(this.elements);
			return outgoing;
		}), 		reset:		(function (){
			this.set([1,0,0,0,1,0]);
		}), 		array:		(function array(){
			return this.elements.slice();
		}), 		translate:		(function (tx, ty){
			this.elements[2] = (((tx * this.elements[0]) + (ty * this.elements[1])) + this.elements[2]);
			this.elements[5] = (((tx * this.elements[3]) + (ty * this.elements[4])) + this.elements[5]);
		}), 		invTranslate:		(function (tx, ty){
			this.translate(-tx, -ty);
		}), 		transpose:		(function (){
		}), 		mult:		(function (source, target){
			var x; var y;
			if (source instanceof PVector){
				x = source.x;
				y = source.y;
				if (!target){
					target = new PVector();
				}
			}			else
{
				if (source instanceof Array){
					x = source[0];
					y = source[1];
					if (!target){
						target = [];
					}
				}
			}
			if (target instanceof Array){
				target[0] = (((this.elements[0] * x) + (this.elements[1] * y)) + this.elements[2]);
				target[1] = (((this.elements[3] * x) + (this.elements[4] * y)) + this.elements[5]);
			}			else
{
				if (target instanceof PVector){
					target.x = (((this.elements[0] * x) + (this.elements[1] * y)) + this.elements[2]);
					target.y = (((this.elements[3] * x) + (this.elements[4] * y)) + this.elements[5]);
					target.z = 0;
				}
			}
			return target;
		}), 		multX:		(function (x, y){
			return ((x * this.elements[0]) + (y * this.elements[1])) + this.elements[2];
		}), 		multY:		(function (x, y){
			return ((x * this.elements[3]) + (y * this.elements[4])) + this.elements[5];
		}), 		skewX:		(function (angle){
			this.apply(1, 0, 1, angle, 0, 0);
		}), 		skewY:		(function (angle){
			this.apply(1, 0, 1, 0, angle, 0);
		}), 		determinant:		(function (){
			return (this.elements[0] * this.elements[4]) - (this.elements[1] * this.elements[3]);
		}), 		invert:		(function (){
			var d = this.determinant();
			if (Math.abs(d) > PConstants.MIN_INT){
				var old00 = this.elements[0];
				var old01 = this.elements[1];
				var old02 = this.elements[2];
				var old10 = this.elements[3];
				var old11 = this.elements[4];
				var old12 = this.elements[5];
				this.elements[0] = (old11 / d);
				this.elements[3] = (-old10 / d);
				this.elements[1] = (-old01 / d);
				this.elements[4] = (old00 / d);
				this.elements[2] = (((old01 * old12) - (old11 * old02)) / d);
				this.elements[5] = (((old10 * old02) - (old00 * old12)) / d);
				return true;
			}
			return false;
		}), 		scale:		(function (sx, sy){
			if (sx && !sy){
				sy = sx;
			}
			if (sx && sy){
				this.elements[0] *= sx;
				this.elements[1] *= sy;
				this.elements[3] *= sx;
				this.elements[4] *= sy;
			}
		}), 		invScale:		(function (sx, sy){
			if (sx && !sy){
				sy = sx;
			}
			this.scale(1 / sx, 1 / sy);
		}), 		apply:		(function (){
			var source;
			if ((arguments.length === 1) && (arguments[0] instanceof PMatrix2D)){
				source = arguments[0].array();
			}			else
{
				if (arguments.length === 6){
					source = Array.prototype.slice.call(arguments);
				}				else
{
					if ((arguments.length === 1) && (arguments[0] instanceof Array)){
						source = arguments[0];
					}
				}
			}
			var result = [0,0,this.elements[2],0,0,this.elements[5]];
			var e = 0;
			for(var row = 0; row < 2;row++){
				for(var col = 0; col < 3;col++, e++){
					result[e] += ((this.elements[(row * 3) + 0] * source[col + 0]) + (this.elements[(row * 3) + 1] * source[col + 3]));
				}
			}
			this.elements = result.slice();
		}), 		preApply:		(function (){
			var source;
			if ((arguments.length === 1) && (arguments[0] instanceof PMatrix2D)){
				source = arguments[0].array();
			}			else
{
				if (arguments.length === 6){
					source = Array.prototype.slice.call(arguments);
				}				else
{
					if ((arguments.length === 1) && (arguments[0] instanceof Array)){
						source = arguments[0];
					}
				}
			}
			var result = [0,0,source[2],0,0,source[5]];
			result[2] = ((source[2] + (this.elements[2] * source[0])) + (this.elements[5] * source[1]));
			result[5] = ((source[5] + (this.elements[2] * source[3])) + (this.elements[5] * source[4]));
			result[0] = ((this.elements[0] * source[0]) + (this.elements[3] * source[1]));
			result[3] = ((this.elements[0] * source[3]) + (this.elements[3] * source[4]));
			result[1] = ((this.elements[1] * source[0]) + (this.elements[4] * source[1]));
			result[4] = ((this.elements[1] * source[3]) + (this.elements[4] * source[4]));
			this.elements = result.slice();
		}), 		rotate:		(function (angle){
			var c = Math.cos(angle);
			var s = Math.sin(angle);
			var temp1 = this.elements[0];
			var temp2 = this.elements[1];
			this.elements[0] = ((c * temp1) + (s * temp2));
			this.elements[1] = ((-s * temp1) + (c * temp2));
			temp1 = this.elements[3];
			temp2 = this.elements[4];
			this.elements[3] = ((c * temp1) + (s * temp2));
			this.elements[4] = ((-s * temp1) + (c * temp2));
		}), 		rotateZ:		(function (angle){
			this.rotate(angle);
		}), 		invRotateZ:		(function (angle){
			this.rotateZ(angle - Math.PI);
		}), 		print:		(function (){
			var digits = printMatrixHelper(this.elements);
			var output = ((((((((((("" + p.nfs(this.elements[0], digits, 4)) + " ") + p.nfs(this.elements[1], digits, 4)) + " ") + p.nfs(this.elements[2], digits, 4)) + "\n") + p.nfs(this.elements[3], digits, 4)) + " ") + p.nfs(this.elements[4], digits, 4)) + " ") + p.nfs(this.elements[5], digits, 4)) + "\n\n";
			p.println(output);
		})		};
		var PMatrix3D = p.PMatrix3D = 		(function (){
			this.reset();
		});
		PMatrix3D.prototype = {		set:		(function (){
			if (arguments.length === 16){
				this.elements = Array.prototype.slice.call(arguments);
			}			else
{
				if ((arguments.length === 1) && (arguments[0] instanceof PMatrix3D)){
					this.elements = arguments[0].array();
				}				else
{
					if ((arguments.length === 1) && (arguments[0] instanceof Array)){
						this.elements = arguments[0].slice();
					}
				}
			}
		}), 		get:		(function (){
			var outgoing = new PMatrix3D();
			outgoing.set(this.elements);
			return outgoing;
		}), 		reset:		(function (){
			this.set([1,0,0,0,0,1,0,0,0,0,1,0,0,0,0,1]);
		}), 		array:		(function array(){
			return this.elements.slice();
		}), 		translate:		(function (tx, ty, tz){
			if (tz === undef){
				tz = 0;
			}
			this.elements[3] += (((tx * this.elements[0]) + (ty * this.elements[1])) + (tz * this.elements[2]));
			this.elements[7] += (((tx * this.elements[4]) + (ty * this.elements[5])) + (tz * this.elements[6]));
			this.elements[11] += (((tx * this.elements[8]) + (ty * this.elements[9])) + (tz * this.elements[10]));
			this.elements[15] += (((tx * this.elements[12]) + (ty * this.elements[13])) + (tz * this.elements[14]));
		}), 		transpose:		(function (){
			var temp = this.elements.slice();
			this.elements[0] = temp[0];
			this.elements[1] = temp[4];
			this.elements[2] = temp[8];
			this.elements[3] = temp[12];
			this.elements[4] = temp[1];
			this.elements[5] = temp[5];
			this.elements[6] = temp[9];
			this.elements[7] = temp[13];
			this.elements[8] = temp[2];
			this.elements[9] = temp[6];
			this.elements[10] = temp[10];
			this.elements[11] = temp[14];
			this.elements[12] = temp[3];
			this.elements[13] = temp[7];
			this.elements[14] = temp[11];
			this.elements[15] = temp[15];
		}), 		mult:		(function (source, target){
			var x; var y; var z; var w;
			if (source instanceof PVector){
				x = source.x;
				y = source.y;
				z = source.z;
				w = 1;
				if (!target){
					target = new PVector();
				}
			}			else
{
				if (source instanceof Array){
					x = source[0];
					y = source[1];
					z = source[2];
					w = (source[3] || 1);
					if (!target || ((target.length !== 3) && (target.length !== 4))){
						target = [0,0,0];
					}
				}
			}
			if (target instanceof Array){
				if (target.length === 3){
					target[0] = ((((this.elements[0] * x) + (this.elements[1] * y)) + (this.elements[2] * z)) + this.elements[3]);
					target[1] = ((((this.elements[4] * x) + (this.elements[5] * y)) + (this.elements[6] * z)) + this.elements[7]);
					target[2] = ((((this.elements[8] * x) + (this.elements[9] * y)) + (this.elements[10] * z)) + this.elements[11]);
				}				else
{
					if (target.length === 4){
						target[0] = ((((this.elements[0] * x) + (this.elements[1] * y)) + (this.elements[2] * z)) + (this.elements[3] * w));
						target[1] = ((((this.elements[4] * x) + (this.elements[5] * y)) + (this.elements[6] * z)) + (this.elements[7] * w));
						target[2] = ((((this.elements[8] * x) + (this.elements[9] * y)) + (this.elements[10] * z)) + (this.elements[11] * w));
						target[3] = ((((this.elements[12] * x) + (this.elements[13] * y)) + (this.elements[14] * z)) + (this.elements[15] * w));
					}
				}
			}
			if (target instanceof PVector){
				target.x = ((((this.elements[0] * x) + (this.elements[1] * y)) + (this.elements[2] * z)) + this.elements[3]);
				target.y = ((((this.elements[4] * x) + (this.elements[5] * y)) + (this.elements[6] * z)) + this.elements[7]);
				target.z = ((((this.elements[8] * x) + (this.elements[9] * y)) + (this.elements[10] * z)) + this.elements[11]);
			}
			return target;
		}), 		preApply:		(function (){
			var source;
			if ((arguments.length === 1) && (arguments[0] instanceof PMatrix3D)){
				source = arguments[0].array();
			}			else
{
				if (arguments.length === 16){
					source = Array.prototype.slice.call(arguments);
				}				else
{
					if ((arguments.length === 1) && (arguments[0] instanceof Array)){
						source = arguments[0];
					}
				}
			}
			var result = [0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0];
			var e = 0;
			for(var row = 0; row < 4;row++){
				for(var col = 0; col < 4;col++, e++){
					result[e] += ((((this.elements[col + 0] * source[(row * 4) + 0]) + (this.elements[col + 4] * source[(row * 4) + 1])) + (this.elements[col + 8] * source[(row * 4) + 2])) + (this.elements[col + 12] * source[(row * 4) + 3]));
				}
			}
			this.elements = result.slice();
		}), 		apply:		(function (){
			var source;
			if ((arguments.length === 1) && (arguments[0] instanceof PMatrix3D)){
				source = arguments[0].array();
			}			else
{
				if (arguments.length === 16){
					source = Array.prototype.slice.call(arguments);
				}				else
{
					if ((arguments.length === 1) && (arguments[0] instanceof Array)){
						source = arguments[0];
					}
				}
			}
			var result = [0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0];
			var e = 0;
			for(var row = 0; row < 4;row++){
				for(var col = 0; col < 4;col++, e++){
					result[e] += ((((this.elements[(row * 4) + 0] * source[col + 0]) + (this.elements[(row * 4) + 1] * source[col + 4])) + (this.elements[(row * 4) + 2] * source[col + 8])) + (this.elements[(row * 4) + 3] * source[col + 12]));
				}
			}
			this.elements = result.slice();
		}), 		rotate:		(function (angle, v0, v1, v2){
			if (!v1){
				this.rotateZ(angle);
			}			else
{
				var c = p.cos(angle);
				var s = p.sin(angle);
				var t = 1 - c;
				this.apply(((t * v0) * v0) + c, ((t * v0) * v1) - (s * v2), ((t * v0) * v2) + (s * v1), 0, ((t * v0) * v1) + (s * v2), ((t * v1) * v1) + c, ((t * v1) * v2) - (s * v0), 0, ((t * v0) * v2) - (s * v1), ((t * v1) * v2) + (s * v0), ((t * v2) * v2) + c, 0, 0, 0, 0, 1);
			}
		}), 		invApply:		(function (){
			if (inverseCopy === undef){
				inverseCopy = new PMatrix3D();
			}
			var a = arguments;
			inverseCopy.set(a[0], a[1], a[2], a[3], a[4], a[5], a[6], a[7], a[8], a[9], a[10], a[11], a[12], a[13], a[14], a[15]);
			if (!inverseCopy.invert()){
				return false;
			}
			this.preApply(inverseCopy);
			return true;
		}), 		rotateX:		(function (angle){
			var c = p.cos(angle);
			var s = p.sin(angle);
			this.apply([1,0,0,0,0,c,-s,0,0,s,c,0,0,0,0,1]);
		}), 		rotateY:		(function (angle){
			var c = p.cos(angle);
			var s = p.sin(angle);
			this.apply([c,0,s,0,0,1,0,0,-s,0,c,0,0,0,0,1]);
		}), 		rotateZ:		(function (angle){
			var c = Math.cos(angle);
			var s = Math.sin(angle);
			this.apply([c,-s,0,0,s,c,0,0,0,0,1,0,0,0,0,1]);
		}), 		scale:		(function (sx, sy, sz){
			if ((sx && !sy) && !sz){
				sy = (sz = sx);
			}			else
{
				if ((sx && sy) && !sz){
					sz = 1;
				}
			}
			if ((sx && sy) && sz){
				this.elements[0] *= sx;
				this.elements[1] *= sy;
				this.elements[2] *= sz;
				this.elements[4] *= sx;
				this.elements[5] *= sy;
				this.elements[6] *= sz;
				this.elements[8] *= sx;
				this.elements[9] *= sy;
				this.elements[10] *= sz;
				this.elements[12] *= sx;
				this.elements[13] *= sy;
				this.elements[14] *= sz;
			}
		}), 		skewX:		(function (angle){
			var t = Math.tan(angle);
			this.apply(1, t, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);
		}), 		skewY:		(function (angle){
			var t = Math.tan(angle);
			this.apply(1, 0, 0, 0, t, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);
		}), 		multX:		(function (x, y, z, w){
			if (!z){
				return ((this.elements[0] * x) + (this.elements[1] * y)) + this.elements[3];
			}			else
{
				if (!w){
					return (((this.elements[0] * x) + (this.elements[1] * y)) + (this.elements[2] * z)) + this.elements[3];
				}				else
{
					return (((this.elements[0] * x) + (this.elements[1] * y)) + (this.elements[2] * z)) + (this.elements[3] * w);
				}
			}
		}), 		multY:		(function (x, y, z, w){
			if (!z){
				return ((this.elements[4] * x) + (this.elements[5] * y)) + this.elements[7];
			}			else
{
				if (!w){
					return (((this.elements[4] * x) + (this.elements[5] * y)) + (this.elements[6] * z)) + this.elements[7];
				}				else
{
					return (((this.elements[4] * x) + (this.elements[5] * y)) + (this.elements[6] * z)) + (this.elements[7] * w);
				}
			}
		}), 		multZ:		(function (x, y, z, w){
			if (!w){
				return (((this.elements[8] * x) + (this.elements[9] * y)) + (this.elements[10] * z)) + this.elements[11];
			}			else
{
				return (((this.elements[8] * x) + (this.elements[9] * y)) + (this.elements[10] * z)) + (this.elements[11] * w);
			}
		}), 		multW:		(function (x, y, z, w){
			if (!w){
				return (((this.elements[12] * x) + (this.elements[13] * y)) + (this.elements[14] * z)) + this.elements[15];
			}			else
{
				return (((this.elements[12] * x) + (this.elements[13] * y)) + (this.elements[14] * z)) + (this.elements[15] * w);
			}
		}), 		invert:		(function (){
			var fA0 = (this.elements[0] * this.elements[5]) - (this.elements[1] * this.elements[4]);
			var fA1 = (this.elements[0] * this.elements[6]) - (this.elements[2] * this.elements[4]);
			var fA2 = (this.elements[0] * this.elements[7]) - (this.elements[3] * this.elements[4]);
			var fA3 = (this.elements[1] * this.elements[6]) - (this.elements[2] * this.elements[5]);
			var fA4 = (this.elements[1] * this.elements[7]) - (this.elements[3] * this.elements[5]);
			var fA5 = (this.elements[2] * this.elements[7]) - (this.elements[3] * this.elements[6]);
			var fB0 = (this.elements[8] * this.elements[13]) - (this.elements[9] * this.elements[12]);
			var fB1 = (this.elements[8] * this.elements[14]) - (this.elements[10] * this.elements[12]);
			var fB2 = (this.elements[8] * this.elements[15]) - (this.elements[11] * this.elements[12]);
			var fB3 = (this.elements[9] * this.elements[14]) - (this.elements[10] * this.elements[13]);
			var fB4 = (this.elements[9] * this.elements[15]) - (this.elements[11] * this.elements[13]);
			var fB5 = (this.elements[10] * this.elements[15]) - (this.elements[11] * this.elements[14]);
			var fDet = (((((fA0 * fB5) - (fA1 * fB4)) + (fA2 * fB3)) + (fA3 * fB2)) - (fA4 * fB1)) + (fA5 * fB0);
			if (Math.abs(fDet) <= 1E-09){
				return false;
			}
			var kInv = [];
			kInv[0] = (((+this.elements[5] * fB5) - (this.elements[6] * fB4)) + (this.elements[7] * fB3));
			kInv[4] = (((-this.elements[4] * fB5) + (this.elements[6] * fB2)) - (this.elements[7] * fB1));
			kInv[8] = (((+this.elements[4] * fB4) - (this.elements[5] * fB2)) + (this.elements[7] * fB0));
			kInv[12] = (((-this.elements[4] * fB3) + (this.elements[5] * fB1)) - (this.elements[6] * fB0));
			kInv[1] = (((-this.elements[1] * fB5) + (this.elements[2] * fB4)) - (this.elements[3] * fB3));
			kInv[5] = (((+this.elements[0] * fB5) - (this.elements[2] * fB2)) + (this.elements[3] * fB1));
			kInv[9] = (((-this.elements[0] * fB4) + (this.elements[1] * fB2)) - (this.elements[3] * fB0));
			kInv[13] = (((+this.elements[0] * fB3) - (this.elements[1] * fB1)) + (this.elements[2] * fB0));
			kInv[2] = (((+this.elements[13] * fA5) - (this.elements[14] * fA4)) + (this.elements[15] * fA3));
			kInv[6] = (((-this.elements[12] * fA5) + (this.elements[14] * fA2)) - (this.elements[15] * fA1));
			kInv[10] = (((+this.elements[12] * fA4) - (this.elements[13] * fA2)) + (this.elements[15] * fA0));
			kInv[14] = (((-this.elements[12] * fA3) + (this.elements[13] * fA1)) - (this.elements[14] * fA0));
			kInv[3] = (((-this.elements[9] * fA5) + (this.elements[10] * fA4)) - (this.elements[11] * fA3));
			kInv[7] = (((+this.elements[8] * fA5) - (this.elements[10] * fA2)) + (this.elements[11] * fA1));
			kInv[11] = (((-this.elements[8] * fA4) + (this.elements[9] * fA2)) - (this.elements[11] * fA0));
			kInv[15] = (((+this.elements[8] * fA3) - (this.elements[9] * fA1)) + (this.elements[10] * fA0));
			var fInvDet = 1 / fDet;
			kInv[0] *= fInvDet;
			kInv[1] *= fInvDet;
			kInv[2] *= fInvDet;
			kInv[3] *= fInvDet;
			kInv[4] *= fInvDet;
			kInv[5] *= fInvDet;
			kInv[6] *= fInvDet;
			kInv[7] *= fInvDet;
			kInv[8] *= fInvDet;
			kInv[9] *= fInvDet;
			kInv[10] *= fInvDet;
			kInv[11] *= fInvDet;
			kInv[12] *= fInvDet;
			kInv[13] *= fInvDet;
			kInv[14] *= fInvDet;
			kInv[15] *= fInvDet;
			this.elements = kInv.slice();
			return true;
		}), 		toString:		(function (){
			var str = "";
			for(var i = 0; i < 15;i++){
				str += (this.elements[i] + ", ");
			}
			str += this.elements[15];
			return str;
		}), 		print:		(function (){
			var digits = printMatrixHelper(this.elements);
			var output = ((((((((((((((((((((((((((((((("" + p.nfs(this.elements[0], digits, 4)) + " ") + p.nfs(this.elements[1], digits, 4)) + " ") + p.nfs(this.elements[2], digits, 4)) + " ") + p.nfs(this.elements[3], digits, 4)) + "\n") + p.nfs(this.elements[4], digits, 4)) + " ") + p.nfs(this.elements[5], digits, 4)) + " ") + p.nfs(this.elements[6], digits, 4)) + " ") + p.nfs(this.elements[7], digits, 4)) + "\n") + p.nfs(this.elements[8], digits, 4)) + " ") + p.nfs(this.elements[9], digits, 4)) + " ") + p.nfs(this.elements[10], digits, 4)) + " ") + p.nfs(this.elements[11], digits, 4)) + "\n") + p.nfs(this.elements[12], digits, 4)) + " ") + p.nfs(this.elements[13], digits, 4)) + " ") + p.nfs(this.elements[14], digits, 4)) + " ") + p.nfs(this.elements[15], digits, 4)) + "\n\n";
			p.println(output);
		}), 		invTranslate:		(function (tx, ty, tz){
			this.preApply(1, 0, 0, -tx, 0, 1, 0, -ty, 0, 0, 1, -tz, 0, 0, 0, 1);
		}), 		invRotateX:		(function (angle){
			var c = Math.cos(-angle);
			var s = Math.sin(-angle);
			this.preApply([1,0,0,0,0,c,-s,0,0,s,c,0,0,0,0,1]);
		}), 		invRotateY:		(function (angle){
			var c = Math.cos(-angle);
			var s = Math.sin(-angle);
			this.preApply([c,0,s,0,0,1,0,0,-s,0,c,0,0,0,0,1]);
		}), 		invRotateZ:		(function (angle){
			var c = Math.cos(-angle);
			var s = Math.sin(-angle);
			this.preApply([c,-s,0,0,s,c,0,0,0,0,1,0,0,0,0,1]);
		}), 		invScale:		(function (x, y, z){
			this.preApply([1 / x,0,0,0,0,1 / y,0,0,0,0,1 / z,0,0,0,0,1]);
		})		};
		var PMatrixStack = p.PMatrixStack = 		(function (){
			this.matrixStack = [];
		});
		PMatrixStack.prototype.load = 		(function (){
			var tmpMatrix = drawing.$newPMatrix();
			if (arguments.length === 1){
				tmpMatrix.set(arguments[0]);
			}			else
{
				tmpMatrix.set(arguments);
			}
			this.matrixStack.push(tmpMatrix);
		});
		Drawing2D.prototype.$newPMatrix = 		(function (){
			return new PMatrix2D();
		});
		Drawing3D.prototype.$newPMatrix = 		(function (){
			return new PMatrix3D();
		});
		PMatrixStack.prototype.push = 		(function (){
			this.matrixStack.push(this.peek());
		});
		PMatrixStack.prototype.pop = 		(function (){
			return this.matrixStack.pop();
		});
		PMatrixStack.prototype.peek = 		(function (){
			var tmpMatrix = drawing.$newPMatrix();
			tmpMatrix.set(this.matrixStack[this.matrixStack.length - 1]);
			return tmpMatrix;
		});
		PMatrixStack.prototype.mult = 		(function (matrix){
			this.matrixStack[this.matrixStack.length - 1].apply(matrix);
		});
		p.split = 		(function (str, delim){
			return str.split(delim);
		});
		p.splitTokens = 		(function (str, tokens){
			if (arguments.length === 1){
				tokens = "\n\t\r\f ";
			}
			tokens = (("[" + tokens) + "]");
			var ary = [];
			var index = 0;
			var pos = str.search(tokens);
			while(pos >= 0){
				if (pos === 0){
					str = str.substring(1);
				}				else
{
					ary[index] = str.substring(0, pos);
					index++;
					str = str.substring(pos);
				}
				pos = str.search(tokens);
			}
			if (str.length > 0){
				ary[index] = str;
			}
			if (ary.length === 0){
				ary = undef;
			}
			return ary;
		});
		p.append = 		(function (array, element){
			array[array.length] = element;
			return array;
		});
		p.concat = 		(function (array1, array2){
			return array1.concat(array2);
		});
		p.sort = 		(function (array, numElem){
			var ret = [];
			if (array.length > 0){
				var elemsToCopy = (numElem > 0) ? numElem : array.length;
				for(var i = 0; i < elemsToCopy;i++){
					ret.push(array[i]);
				}
				if (typeofarray[0] === "string"){
					ret.sort();
				}				else
{
					ret.sort(					(function (a, b){
						return a - b;
					}));
				}
				if (numElem > 0){
					for(var j = ret.length; j < array.length;j++){
						ret.push(array[j]);
					}
				}
			}
			return ret;
		});
		p.splice = 		(function (array, value, index){
			if (value.length === 0){
				return array;
			}
			if (value instanceof Array){
				for(var i = 0, j = index; i < value.length;j++, i++){
					array.splice(j, 0, value[i]);
				}
			}			else
{
				array.splice(index, 0, value);
			}
			return array;
		});
		p.subset = 		(function (array, offset, length){
			if (arguments.length === 2){
				return array.slice(offset, array.length);
			}			else
{
				if (arguments.length === 3){
					return array.slice(offset, offset + length);
				}
			}
		});
		p.join = 		(function (array, seperator){
			return array.join(seperator);
		});
		p.shorten = 		(function (ary){
			var newary = [];
			var len = ary.length;
			for(var i = 0; i < len;i++){
				newary[i] = ary[i];
			}
			newary.pop();
			return newary;
		});
		p.expand = 		(function (ary, newSize){
			var temp = ary.slice(0);
			if (arguments.length === 1){
				temp.length = (ary.length * 2);
				return temp;
			}			else
{
				if (arguments.length === 2){
					temp.length = newSize;
					return temp;
				}
			}
		});
		p.arrayCopy = 		(function (){
			var src; var srcPos = 0; var dest; var destPos = 0; var length;
			if (arguments.length === 2){
				src = arguments[0];
				dest = arguments[1];
				length = src.length;
			}			else
{
				if (arguments.length === 3){
					src = arguments[0];
					dest = arguments[1];
					length = arguments[2];
				}				else
{
					if (arguments.length === 5){
						src = arguments[0];
						srcPos = arguments[1];
						dest = arguments[2];
						destPos = arguments[3];
						length = arguments[4];
					}
				}
			}
			for(var i = srcPos, j = destPos; i < (length + srcPos);i++, j++){
				if (dest[j] !== undef){
					dest[j] = src[i];
				}				else
{
					throw "array index out of bounds exception";
				}
			}
		});
		p.reverse = 		(function (array){
			return array.reverse();
		});
		p.mix = 		(function (a, b, f){
			return a + (((b - a) * f) >> 8);
		});
		p.peg = 		(function (n){
			return (n < 0) ? 0 : ((n > 255) ? 255 : n);
		});
		p.modes = {		replace:		(function (c1, c2){
			return c2;
		}), 		blend:		(function (c1, c2){
			var f = (c2 & PConstants.ALPHA_MASK) >>> 24;
			return (((Math.min(((c1 & PConstants.ALPHA_MASK) >>> 24) + f, -1) << 24) | (p.mix(c1 & PConstants.RED_MASK, c2 & PConstants.RED_MASK, f) & PConstants.RED_MASK)) | (p.mix(c1 & PConstants.GREEN_MASK, c2 & PConstants.GREEN_MASK, f) & PConstants.GREEN_MASK)) | p.mix(c1 & PConstants.BLUE_MASK, c2 & PConstants.BLUE_MASK, f);
		}), 		add:		(function (c1, c2){
			var f = (c2 & PConstants.ALPHA_MASK) >>> 24;
			return (((Math.min(((c1 & PConstants.ALPHA_MASK) >>> 24) + f, -1) << 24) | (Math.min((c1 & PConstants.RED_MASK) + (((c2 & PConstants.RED_MASK) >> 8) * f), PConstants.RED_MASK) & PConstants.RED_MASK)) | (Math.min((c1 & PConstants.GREEN_MASK) + (((c2 & PConstants.GREEN_MASK) >> 8) * f), PConstants.GREEN_MASK) & PConstants.GREEN_MASK)) | Math.min((c1 & PConstants.BLUE_MASK) + (((c2 & PConstants.BLUE_MASK) * f) >> 8), PConstants.BLUE_MASK);
		}), 		subtract:		(function (c1, c2){
			var f = (c2 & PConstants.ALPHA_MASK) >>> 24;
			return (((Math.min(((c1 & PConstants.ALPHA_MASK) >>> 24) + f, -1) << 24) | (Math.max((c1 & PConstants.RED_MASK) - (((c2 & PConstants.RED_MASK) >> 8) * f), PConstants.GREEN_MASK) & PConstants.RED_MASK)) | (Math.max((c1 & PConstants.GREEN_MASK) - (((c2 & PConstants.GREEN_MASK) >> 8) * f), PConstants.BLUE_MASK) & PConstants.GREEN_MASK)) | Math.max((c1 & PConstants.BLUE_MASK) - (((c2 & PConstants.BLUE_MASK) * f) >> 8), 0);
		}), 		lightest:		(function (c1, c2){
			var f = (c2 & PConstants.ALPHA_MASK) >>> 24;
			return (((Math.min(((c1 & PConstants.ALPHA_MASK) >>> 24) + f, -1) << 24) | (Math.max(c1 & PConstants.RED_MASK, ((c2 & PConstants.RED_MASK) >> 8) * f) & PConstants.RED_MASK)) | (Math.max(c1 & PConstants.GREEN_MASK, ((c2 & PConstants.GREEN_MASK) >> 8) * f) & PConstants.GREEN_MASK)) | Math.max(c1 & PConstants.BLUE_MASK, ((c2 & PConstants.BLUE_MASK) * f) >> 8);
		}), 		darkest:		(function (c1, c2){
			var f = (c2 & PConstants.ALPHA_MASK) >>> 24;
			return (((Math.min(((c1 & PConstants.ALPHA_MASK) >>> 24) + f, -1) << 24) | (p.mix(c1 & PConstants.RED_MASK, Math.min(c1 & PConstants.RED_MASK, ((c2 & PConstants.RED_MASK) >> 8) * f), f) & PConstants.RED_MASK)) | (p.mix(c1 & PConstants.GREEN_MASK, Math.min(c1 & PConstants.GREEN_MASK, ((c2 & PConstants.GREEN_MASK) >> 8) * f), f) & PConstants.GREEN_MASK)) | p.mix(c1 & PConstants.BLUE_MASK, Math.min(c1 & PConstants.BLUE_MASK, ((c2 & PConstants.BLUE_MASK) * f) >> 8), f);
		}), 		difference:		(function (c1, c2){
			var f = (c2 & PConstants.ALPHA_MASK) >>> 24;
			var ar = (c1 & PConstants.RED_MASK) >> 16;
			var ag = (c1 & PConstants.GREEN_MASK) >> 8;
			var ab = c1 & PConstants.BLUE_MASK;
			var br = (c2 & PConstants.RED_MASK) >> 16;
			var bg = (c2 & PConstants.GREEN_MASK) >> 8;
			var bb = c2 & PConstants.BLUE_MASK;
			var cr = (ar > br) ? (ar - br) : (br - ar);
			var cg = (ag > bg) ? (ag - bg) : (bg - ag);
			var cb = (ab > bb) ? (ab - bb) : (bb - ab);
			return (((Math.min(((c1 & PConstants.ALPHA_MASK) >>> 24) + f, -1) << 24) | (p.peg(ar + (((cr - ar) * f) >> 8)) << 16)) | (p.peg(ag + (((cg - ag) * f) >> 8)) << 8)) | p.peg(ab + (((cb - ab) * f) >> 8));
		}), 		exclusion:		(function (c1, c2){
			var f = (c2 & PConstants.ALPHA_MASK) >>> 24;
			var ar = (c1 & PConstants.RED_MASK) >> 16;
			var ag = (c1 & PConstants.GREEN_MASK) >> 8;
			var ab = c1 & PConstants.BLUE_MASK;
			var br = (c2 & PConstants.RED_MASK) >> 16;
			var bg = (c2 & PConstants.GREEN_MASK) >> 8;
			var bb = c2 & PConstants.BLUE_MASK;
			var cr = (ar + br) - ((ar * br) >> 7);
			var cg = (ag + bg) - ((ag * bg) >> 7);
			var cb = (ab + bb) - ((ab * bb) >> 7);
			return (((Math.min(((c1 & PConstants.ALPHA_MASK) >>> 24) + f, -1) << 24) | (p.peg(ar + (((cr - ar) * f) >> 8)) << 16)) | (p.peg(ag + (((cg - ag) * f) >> 8)) << 8)) | p.peg(ab + (((cb - ab) * f) >> 8));
		}), 		multiply:		(function (c1, c2){
			var f = (c2 & PConstants.ALPHA_MASK) >>> 24;
			var ar = (c1 & PConstants.RED_MASK) >> 16;
			var ag = (c1 & PConstants.GREEN_MASK) >> 8;
			var ab = c1 & PConstants.BLUE_MASK;
			var br = (c2 & PConstants.RED_MASK) >> 16;
			var bg = (c2 & PConstants.GREEN_MASK) >> 8;
			var bb = c2 & PConstants.BLUE_MASK;
			var cr = (ar * br) >> 8;
			var cg = (ag * bg) >> 8;
			var cb = (ab * bb) >> 8;
			return (((Math.min(((c1 & PConstants.ALPHA_MASK) >>> 24) + f, -1) << 24) | (p.peg(ar + (((cr - ar) * f) >> 8)) << 16)) | (p.peg(ag + (((cg - ag) * f) >> 8)) << 8)) | p.peg(ab + (((cb - ab) * f) >> 8));
		}), 		screen:		(function (c1, c2){
			var f = (c2 & PConstants.ALPHA_MASK) >>> 24;
			var ar = (c1 & PConstants.RED_MASK) >> 16;
			var ag = (c1 & PConstants.GREEN_MASK) >> 8;
			var ab = c1 & PConstants.BLUE_MASK;
			var br = (c2 & PConstants.RED_MASK) >> 16;
			var bg = (c2 & PConstants.GREEN_MASK) >> 8;
			var bb = c2 & PConstants.BLUE_MASK;
			var cr = 255 - (((255 - ar) * (255 - br)) >> 8);
			var cg = 255 - (((255 - ag) * (255 - bg)) >> 8);
			var cb = 255 - (((255 - ab) * (255 - bb)) >> 8);
			return (((Math.min(((c1 & PConstants.ALPHA_MASK) >>> 24) + f, -1) << 24) | (p.peg(ar + (((cr - ar) * f) >> 8)) << 16)) | (p.peg(ag + (((cg - ag) * f) >> 8)) << 8)) | p.peg(ab + (((cb - ab) * f) >> 8));
		}), 		hard_light:		(function (c1, c2){
			var f = (c2 & PConstants.ALPHA_MASK) >>> 24;
			var ar = (c1 & PConstants.RED_MASK) >> 16;
			var ag = (c1 & PConstants.GREEN_MASK) >> 8;
			var ab = c1 & PConstants.BLUE_MASK;
			var br = (c2 & PConstants.RED_MASK) >> 16;
			var bg = (c2 & PConstants.GREEN_MASK) >> 8;
			var bb = c2 & PConstants.BLUE_MASK;
			var cr = (br < 128) ? ((ar * br) >> 7) : (255 - (((255 - ar) * (255 - br)) >> 7));
			var cg = (bg < 128) ? ((ag * bg) >> 7) : (255 - (((255 - ag) * (255 - bg)) >> 7));
			var cb = (bb < 128) ? ((ab * bb) >> 7) : (255 - (((255 - ab) * (255 - bb)) >> 7));
			return (((Math.min(((c1 & PConstants.ALPHA_MASK) >>> 24) + f, -1) << 24) | (p.peg(ar + (((cr - ar) * f) >> 8)) << 16)) | (p.peg(ag + (((cg - ag) * f) >> 8)) << 8)) | p.peg(ab + (((cb - ab) * f) >> 8));
		}), 		soft_light:		(function (c1, c2){
			var f = (c2 & PConstants.ALPHA_MASK) >>> 24;
			var ar = (c1 & PConstants.RED_MASK) >> 16;
			var ag = (c1 & PConstants.GREEN_MASK) >> 8;
			var ab = c1 & PConstants.BLUE_MASK;
			var br = (c2 & PConstants.RED_MASK) >> 16;
			var bg = (c2 & PConstants.GREEN_MASK) >> 8;
			var bb = c2 & PConstants.BLUE_MASK;
			var cr = (((ar * br) >> 7) + ((ar * ar) >> 8)) - (((ar * ar) * br) >> 15);
			var cg = (((ag * bg) >> 7) + ((ag * ag) >> 8)) - (((ag * ag) * bg) >> 15);
			var cb = (((ab * bb) >> 7) + ((ab * ab) >> 8)) - (((ab * ab) * bb) >> 15);
			return (((Math.min(((c1 & PConstants.ALPHA_MASK) >>> 24) + f, -1) << 24) | (p.peg(ar + (((cr - ar) * f) >> 8)) << 16)) | (p.peg(ag + (((cg - ag) * f) >> 8)) << 8)) | p.peg(ab + (((cb - ab) * f) >> 8));
		}), 		overlay:		(function (c1, c2){
			var f = (c2 & PConstants.ALPHA_MASK) >>> 24;
			var ar = (c1 & PConstants.RED_MASK) >> 16;
			var ag = (c1 & PConstants.GREEN_MASK) >> 8;
			var ab = c1 & PConstants.BLUE_MASK;
			var br = (c2 & PConstants.RED_MASK) >> 16;
			var bg = (c2 & PConstants.GREEN_MASK) >> 8;
			var bb = c2 & PConstants.BLUE_MASK;
			var cr = (ar < 128) ? ((ar * br) >> 7) : (255 - (((255 - ar) * (255 - br)) >> 7));
			var cg = (ag < 128) ? ((ag * bg) >> 7) : (255 - (((255 - ag) * (255 - bg)) >> 7));
			var cb = (ab < 128) ? ((ab * bb) >> 7) : (255 - (((255 - ab) * (255 - bb)) >> 7));
			return (((Math.min(((c1 & PConstants.ALPHA_MASK) >>> 24) + f, -1) << 24) | (p.peg(ar + (((cr - ar) * f) >> 8)) << 16)) | (p.peg(ag + (((cg - ag) * f) >> 8)) << 8)) | p.peg(ab + (((cb - ab) * f) >> 8));
		}), 		dodge:		(function (c1, c2){
			var f = (c2 & PConstants.ALPHA_MASK) >>> 24;
			var ar = (c1 & PConstants.RED_MASK) >> 16;
			var ag = (c1 & PConstants.GREEN_MASK) >> 8;
			var ab = c1 & PConstants.BLUE_MASK;
			var br = (c2 & PConstants.RED_MASK) >> 16;
			var bg = (c2 & PConstants.GREEN_MASK) >> 8;
			var bb = c2 & PConstants.BLUE_MASK;
			var cr = (br === 255) ? 255 : p.peg((ar << 8) / (255 - br));
			var cg = (bg === 255) ? 255 : p.peg((ag << 8) / (255 - bg));
			var cb = (bb === 255) ? 255 : p.peg((ab << 8) / (255 - bb));
			return (((Math.min(((c1 & PConstants.ALPHA_MASK) >>> 24) + f, -1) << 24) | (p.peg(ar + (((cr - ar) * f) >> 8)) << 16)) | (p.peg(ag + (((cg - ag) * f) >> 8)) << 8)) | p.peg(ab + (((cb - ab) * f) >> 8));
		}), 		burn:		(function (c1, c2){
			var f = (c2 & PConstants.ALPHA_MASK) >>> 24;
			var ar = (c1 & PConstants.RED_MASK) >> 16;
			var ag = (c1 & PConstants.GREEN_MASK) >> 8;
			var ab = c1 & PConstants.BLUE_MASK;
			var br = (c2 & PConstants.RED_MASK) >> 16;
			var bg = (c2 & PConstants.GREEN_MASK) >> 8;
			var bb = c2 & PConstants.BLUE_MASK;
			var cr = (br === 0) ? 0 : (255 - p.peg(((255 - ar) << 8) / br));
			var cg = (bg === 0) ? 0 : (255 - p.peg(((255 - ag) << 8) / bg));
			var cb = (bb === 0) ? 0 : (255 - p.peg(((255 - ab) << 8) / bb));
			return (((Math.min(((c1 & PConstants.ALPHA_MASK) >>> 24) + f, -1) << 24) | (p.peg(ar + (((cr - ar) * f) >> 8)) << 16)) | (p.peg(ag + (((cg - ag) * f) >> 8)) << 8)) | p.peg(ab + (((cb - ab) * f) >> 8));
		})		};
				function color$4(aValue1, aValue2, aValue3, aValue4){
			var r; var g; var b; var a;
			if (curColorMode === PConstants.HSB){
				var rgb = p.color.toRGB(aValue1, aValue2, aValue3);
				r = rgb[0];
				g = rgb[1];
				b = rgb[2];
			}			else
{
				r = Math.round(255 * (aValue1 / colorModeX));
				g = Math.round(255 * (aValue2 / colorModeY));
				b = Math.round(255 * (aValue3 / colorModeZ));
			}
			a = Math.round(255 * (aValue4 / colorModeA));
			r = ((r > 255) ? 255 : r);
			g = ((g > 255) ? 255 : g);
			b = ((b > 255) ? 255 : b);
			a = ((a > 255) ? 255 : a);
			return ((((a << 24) & PConstants.ALPHA_MASK) | ((r << 16) & PConstants.RED_MASK)) | ((g << 8) & PConstants.GREEN_MASK)) | (b & PConstants.BLUE_MASK);
		}
				function color$2(aValue1, aValue2){
			var a;
			if (aValue1 & PConstants.ALPHA_MASK){
				a = Math.round(255 * (aValue2 / colorModeA));
				a = ((a > 255) ? 255 : a);
				return (aValue1 - (aValue1 & PConstants.ALPHA_MASK)) + ((a << 24) & PConstants.ALPHA_MASK);
			}			else
{
				if (curColorMode === PConstants.RGB){
					return color$4(aValue1, aValue1, aValue1, aValue2);
				}				else
{
					if (curColorMode === PConstants.HSB){
						return color$4(0, 0, (aValue1 / colorModeX) * colorModeZ, aValue2);
					}
				}
			}
		}
				function color$1(aValue1){
			if ((aValue1 <= colorModeX) && (aValue1 >= 0)){
				if (curColorMode === PConstants.RGB){
					return color$4(aValue1, aValue1, aValue1, colorModeA);
				}				else
{
					if (curColorMode === PConstants.HSB){
						return color$4(0, 0, (aValue1 / colorModeX) * colorModeZ, colorModeA);
					}
				}
			}			else
{
				if (aValue1){
					return aValue1;
				}
			}
		}
		p.color = 		(function (aValue1, aValue2, aValue3, aValue4){
			if ((((aValue1 !== undef) && (aValue2 !== undef)) && (aValue3 !== undef)) && (aValue4 !== undef)){
				return color$4(aValue1, aValue2, aValue3, aValue4);
			}
			if (((aValue1 !== undef) && (aValue2 !== undef)) && (aValue3 !== undef)){
				return color$4(aValue1, aValue2, aValue3, colorModeA);
			}
			if ((aValue1 !== undef) && (aValue2 !== undef)){
				return color$2(aValue1, aValue2);
			}
			if (typeofaValue1 === "number"){
				return color$1(aValue1);
			}
			return color$4(colorModeX, colorModeY, colorModeZ, colorModeA);
		});
		p.color.toString = 		(function (colorInt){
			return ((((((("rgba(" + ((colorInt & PConstants.RED_MASK) >>> 16)) + ",") + ((colorInt & PConstants.GREEN_MASK) >>> 8)) + ",") + (colorInt & PConstants.BLUE_MASK)) + ",") + (((colorInt & PConstants.ALPHA_MASK) >>> 24) / 255)) + ")";
		});
		p.color.toInt = 		(function (r, g, b, a){
			return ((((a << 24) & PConstants.ALPHA_MASK) | ((r << 16) & PConstants.RED_MASK)) | ((g << 8) & PConstants.GREEN_MASK)) | (b & PConstants.BLUE_MASK);
		});
		p.color.toArray = 		(function (colorInt){
			return [(colorInt & PConstants.RED_MASK) >>> 16,(colorInt & PConstants.GREEN_MASK) >>> 8,colorInt & PConstants.BLUE_MASK,(colorInt & PConstants.ALPHA_MASK) >>> 24];
		});
		p.color.toGLArray = 		(function (colorInt){
			return [((colorInt & PConstants.RED_MASK) >>> 16) / 255,((colorInt & PConstants.GREEN_MASK) >>> 8) / 255,(colorInt & PConstants.BLUE_MASK) / 255,((colorInt & PConstants.ALPHA_MASK) >>> 24) / 255];
		});
		p.color.toRGB = 		(function (h, s, b){
			h = ((h > colorModeX) ? colorModeX : h);
			s = ((s > colorModeY) ? colorModeY : s);
			b = ((b > colorModeZ) ? colorModeZ : b);
			h = ((h / colorModeX) * 360);
			s = ((s / colorModeY) * 100);
			b = ((b / colorModeZ) * 100);
			var br = Math.round((b / 100) * 255);
			if (s === 0){
				return [br,br,br];
			}			else
{
				var hue = h % 360;
				var f = hue % 60;
				var p = Math.round(((b * (100 - s)) / 10000) * 255);
				var q = Math.round(((b * (6000 - (s * f))) / 600000) * 255);
				var t = Math.round(((b * (6000 - (s * (60 - f)))) / 600000) * 255);
				switch(Math.floor(hue / 60)) {
					case 0:
{
						return [br,t,p];
					}					case 1:
{
						return [q,br,p];
					}					case 2:
{
						return [p,br,t];
					}					case 3:
{
						return [p,q,br];
					}					case 4:
{
						return [t,p,br];
					}					case 5:
{
						return [br,p,q];
					}}
			}
		});
		p.color.toHSB = 		(function (colorInt){
			var red; var green; var blue;
			red = (((colorInt & PConstants.RED_MASK) >>> 16) / 255);
			green = (((colorInt & PConstants.GREEN_MASK) >>> 8) / 255);
			blue = ((colorInt & PConstants.BLUE_MASK) / 255);
			var max = p.max(p.max(red, green), blue); var min = p.min(p.min(red, green), blue); var hue; var saturation;
			if (min === max){
				return [0,0,max];
			}			else
{
				saturation = ((max - min) / max);
				if (red === max){
					hue = ((green - blue) / (max - min));
				}				else
{
					if (green === max){
						hue = (2 + ((blue - red) / (max - min)));
					}					else
{
						hue = (4 + ((red - green) / (max - min)));
					}
				}
				hue /= 6;
				if (hue < 0){
					hue += 1;
				}				else
{
					if (hue > 1){
						hue -= 1;
					}
				}
			}
			return [hue * colorModeX,saturation * colorModeY,max * colorModeZ];
		});
		p.brightness = 		(function (colInt){
			return p.color.toHSB(colInt)[2];
		});
		p.saturation = 		(function (colInt){
			return p.color.toHSB(colInt)[1];
		});
		p.hue = 		(function (colInt){
			return p.color.toHSB(colInt)[0];
		});
		var verifyChannel = 		(function (aColor){
			if (aColor.constructor === Array){
				return aColor;
			}			else
{
				return p.color(aColor);
			}
		});
		p.red = 		(function (aColor){
			return (((aColor & PConstants.RED_MASK) >>> 16) / 255) * colorModeX;
		});
		p.green = 		(function (aColor){
			return (((aColor & PConstants.GREEN_MASK) >>> 8) / 255) * colorModeY;
		});
		p.blue = 		(function (aColor){
			return ((aColor & PConstants.BLUE_MASK) / 255) * colorModeZ;
		});
		p.alpha = 		(function (aColor){
			return (((aColor & PConstants.ALPHA_MASK) >>> 24) / 255) * colorModeA;
		});
		p.lerpColor = 		(function (c1, c2, amt){
			var colorBits1 = p.color(c1);
			var r1 = (colorBits1 & PConstants.RED_MASK) >>> 16;
			var g1 = (colorBits1 & PConstants.GREEN_MASK) >>> 8;
			var b1 = colorBits1 & PConstants.BLUE_MASK;
			var a1 = ((colorBits1 & PConstants.ALPHA_MASK) >>> 24) / colorModeA;
			var colorBits2 = p.color(c2);
			var r2 = (colorBits2 & PConstants.RED_MASK) >>> 16;
			var g2 = (colorBits2 & PConstants.GREEN_MASK) >>> 8;
			var b2 = colorBits2 & PConstants.BLUE_MASK;
			var a2 = ((colorBits2 & PConstants.ALPHA_MASK) >>> 24) / colorModeA;
			var r = parseInt(p.lerp(r1, r2, amt), 10);
			var g = parseInt(p.lerp(g1, g2, amt), 10);
			var b = parseInt(p.lerp(b1, b2, amt), 10);
			var a = parseFloat(p.lerp(a1, a2, amt) * colorModeA);
			return p.color.toInt(r, g, b, a);
		});
		p.defaultColor = 		(function (aValue1, aValue2, aValue3){
			var tmpColorMode = curColorMode;
			curColorMode = PConstants.RGB;
			var c = p.color((aValue1 / 255) * colorModeX, (aValue2 / 255) * colorModeY, (aValue3 / 255) * colorModeZ);
			curColorMode = tmpColorMode;
			return c;
		});
		p.colorMode = 		(function (){
			curColorMode = arguments[0];
			if (arguments.length > 1){
				colorModeX = arguments[1];
				colorModeY = (arguments[2] || arguments[1]);
				colorModeZ = (arguments[3] || arguments[1]);
				colorModeA = (arguments[4] || arguments[1]);
			}
		});
		p.blendColor = 		(function (c1, c2, mode){
			var color = 0;
			switch(mode) {
				case PConstants.REPLACE:
{
					color = p.modes.replace(c1, c2);
					break ;
				}				case PConstants.BLEND:
{
					color = p.modes.blend(c1, c2);
					break ;
				}				case PConstants.ADD:
{
					color = p.modes.add(c1, c2);
					break ;
				}				case PConstants.SUBTRACT:
{
					color = p.modes.subtract(c1, c2);
					break ;
				}				case PConstants.LIGHTEST:
{
					color = p.modes.lightest(c1, c2);
					break ;
				}				case PConstants.DARKEST:
{
					color = p.modes.darkest(c1, c2);
					break ;
				}				case PConstants.DIFFERENCE:
{
					color = p.modes.difference(c1, c2);
					break ;
				}				case PConstants.EXCLUSION:
{
					color = p.modes.exclusion(c1, c2);
					break ;
				}				case PConstants.MULTIPLY:
{
					color = p.modes.multiply(c1, c2);
					break ;
				}				case PConstants.SCREEN:
{
					color = p.modes.screen(c1, c2);
					break ;
				}				case PConstants.HARD_LIGHT:
{
					color = p.modes.hard_light(c1, c2);
					break ;
				}				case PConstants.SOFT_LIGHT:
{
					color = p.modes.soft_light(c1, c2);
					break ;
				}				case PConstants.OVERLAY:
{
					color = p.modes.overlay(c1, c2);
					break ;
				}				case PConstants.DODGE:
{
					color = p.modes.dodge(c1, c2);
					break ;
				}				case PConstants.BURN:
{
					color = p.modes.burn(c1, c2);
					break ;
				}}
			return color;
		});
				function saveContext(){
			curContext.save();
		}
				function restoreContext(){
			curContext.restore();
			isStrokeDirty = true;
			isFillDirty = true;
		}
		p.printMatrix = 		(function (){
			modelView.print();
		});
		Drawing2D.prototype.translate = 		(function (x, y){
			forwardTransform.translate(x, y);
			reverseTransform.invTranslate(x, y);
			curContext.translate(x, y);
		});
		Drawing3D.prototype.translate = 		(function (x, y, z){
			forwardTransform.translate(x, y, z);
			reverseTransform.invTranslate(x, y, z);
		});
		Drawing2D.prototype.scale = 		(function (x, y){
			forwardTransform.scale(x, y);
			reverseTransform.invScale(x, y);
			curContext.scale(x, y || x);
		});
		Drawing3D.prototype.scale = 		(function (x, y, z){
			forwardTransform.scale(x, y, z);
			reverseTransform.invScale(x, y, z);
		});
		Drawing2D.prototype.pushMatrix = 		(function (){
			userMatrixStack.load(modelView);
			userReverseMatrixStack.load(modelViewInv);
			saveContext();
		});
		Drawing3D.prototype.pushMatrix = 		(function (){
			userMatrixStack.load(modelView);
			userReverseMatrixStack.load(modelViewInv);
		});
		Drawing2D.prototype.popMatrix = 		(function (){
			modelView.set(userMatrixStack.pop());
			modelViewInv.set(userReverseMatrixStack.pop());
			restoreContext();
		});
		Drawing3D.prototype.popMatrix = 		(function (){
			modelView.set(userMatrixStack.pop());
			modelViewInv.set(userReverseMatrixStack.pop());
		});
		Drawing2D.prototype.resetMatrix = 		(function (){
			forwardTransform.reset();
			reverseTransform.reset();
			curContext.setTransform(1, 0, 0, 1, 0, 0);
		});
		Drawing3D.prototype.resetMatrix = 		(function (){
			forwardTransform.reset();
			reverseTransform.reset();
		});
		DrawingShared.prototype.applyMatrix = 		(function (){
			var a = arguments;
			forwardTransform.apply(a[0], a[1], a[2], a[3], a[4], a[5], a[6], a[7], a[8], a[9], a[10], a[11], a[12], a[13], a[14], a[15]);
			reverseTransform.invApply(a[0], a[1], a[2], a[3], a[4], a[5], a[6], a[7], a[8], a[9], a[10], a[11], a[12], a[13], a[14], a[15]);
		});
		Drawing2D.prototype.applyMatrix = 		(function (){
			var a = arguments;
			for(var cnt = a.length; cnt < 16;cnt++){
				a[cnt] = 0;
			}
			a[10] = (a[15] = 1);
			DrawingShared.prototype.applyMatrix.apply(this, a);
		});
		p.rotateX = 		(function (angleInRadians){
			forwardTransform.rotateX(angleInRadians);
			reverseTransform.invRotateX(angleInRadians);
		});
		p.rotateZ = 		(function (angleInRadians){
			forwardTransform.rotateZ(angleInRadians);
			reverseTransform.invRotateZ(angleInRadians);
			if (p.use3DContext){
				return ;
			}
			curContext.rotate(angleInRadians);
		});
		p.rotateY = 		(function (angleInRadians){
			forwardTransform.rotateY(angleInRadians);
			reverseTransform.invRotateY(angleInRadians);
		});
		Drawing2D.prototype.rotate = 		(function (angleInRadians){
			p.rotateZ(angleInRadians);
		});
		Drawing3D.prototype.rotate = 		(function (angleInRadians){
			p.rotateZ(angleInRadians);
		});
		p.pushStyle = 		(function (){
			saveContext();
			p.pushMatrix();
			var newState = {			'doFill':doFill, 			'currentFillColor':currentFillColor, 			'doStroke':doStroke, 			'currentStrokeColor':currentStrokeColor, 			'curTint':curTint, 			'curRectMode':curRectMode, 			'curColorMode':curColorMode, 			'colorModeX':colorModeX, 			'colorModeZ':colorModeZ, 			'colorModeY':colorModeY, 			'colorModeA':colorModeA, 			'curTextFont':curTextFont, 			'curTextSize':curTextSize			};
			styleArray.push(newState);
		});
		p.popStyle = 		(function (){
			var oldState = styleArray.pop();
			if (oldState){
				restoreContext();
				p.popMatrix();
				doFill = oldState.doFill;
				currentFillColor = oldState.currentFillColor;
				doStroke = oldState.doStroke;
				currentStrokeColor = oldState.currentStrokeColor;
				curTint = oldState.curTint;
				curRectMode = oldState.curRectmode;
				curColorMode = oldState.curColorMode;
				colorModeX = oldState.colorModeX;
				colorModeZ = oldState.colorModeZ;
				colorModeY = oldState.colorModeY;
				colorModeA = oldState.colorModeA;
				curTextFont = oldState.curTextFont;
				curTextSize = oldState.curTextSize;
			}			else
{
				throw "Too many popStyle() without enough pushStyle()";
			}
		});
		p.year = 		(function (){
			return new Date().getFullYear();
		});
		p.month = 		(function (){
			return new Date().getMonth() + 1;
		});
		p.day = 		(function (){
			return new Date().getDate();
		});
		p.hour = 		(function (){
			return new Date().getHours();
		});
		p.minute = 		(function (){
			return new Date().getMinutes();
		});
		p.second = 		(function (){
			return new Date().getSeconds();
		});
		p.millis = 		(function (){
			return new Date().getTime() - start;
		});
		DrawingShared.prototype.redraw = 		(function (){
			var sec = (new Date().getTime() - timeSinceLastFPS) / 1000;
			framesSinceLastFPS++;
			var fps = framesSinceLastFPS / sec;
			if (sec > 0.5){
				timeSinceLastFPS = new Date().getTime();
				framesSinceLastFPS = 0;
				p.__frameRate = fps;
			}
			p.frameCount++;
		});
		Drawing2D.prototype.redraw = 		(function (){
			DrawingShared.prototype.redraw.apply(this, arguments);
			curContext.lineWidth = lineWidth;
			inDraw = true;
			saveContext();
			p.draw();
			restoreContext();
			inDraw = false;
		});
		Drawing3D.prototype.redraw = 		(function (){
			DrawingShared.prototype.redraw.apply(this, arguments);
			inDraw = true;
			curContext.clear(curContext.DEPTH_BUFFER_BIT);
			curContextCache = {			attributes:{			}, 			locations:{			}			};
			p.noLights();
			p.lightFalloff(1, 0, 0);
			p.shininess(1);
			p.ambient(255, 255, 255);
			p.specular(0, 0, 0);
			p.emissive(0, 0, 0);
			p.camera();
			p.draw();
			inDraw = false;
		});
		p.noLoop = 		(function (){
			doLoop = false;
			loopStarted = false;
			clearInterval(looping);
		});
		p.loop = 		(function (){
			if (loopStarted){
				return ;
			}
			timeSinceLastFPS = new Date().getTime();
			framesSinceLastFPS = 0;
			looping = window.setInterval(			(function (){
				try{
					p.redraw();
				}catch( e_loop ){
					window.clearInterval(looping);
					throw e_loop;
				}
			}), curMsPerFrame);
			doLoop = true;
			loopStarted = true;
		});
		p.frameRate = 		(function (aRate){
			curFrameRate = aRate;
			curMsPerFrame = (1000 / curFrameRate);
			if (doLoop){
				p.noLoop();
				p.loop();
			}
		});
		var eventHandlers = [];
		p.exit = 		(function (){
			window.clearInterval(looping);
			removeInstance(p.externals.canvas.id);
			for(var lib in Processing.lib){
				if (Processing.lib.hasOwnProperty(lib)){
					if (Processing.lib[lib].hasOwnProperty("detach")){
						Processing.lib[lib].detach(p);
					}
				}
			}
			for(var i = 0, ehl = eventHandlers.length; i < ehl;i++){
				var elem = eventHandlers[i][0]; var type = eventHandlers[i][1]; var fn = eventHandlers[i][2];
				if (elem.removeEventListener){
					elem.removeEventListener(type, fn, false);
				}				else
{
					if (elem.detachEvent){
						elem.detachEvent("on" + type, fn);
					}
				}
			}
		});
		p.cursor = 		(function (){
			if ((arguments.length > 1) || ((arguments.length === 1) && (arguments[0] instanceof p.PImage))){
				var image = arguments[0]; var x; var y;
				if (arguments.length >= 3){
					x = arguments[1];
					y = arguments[2];
					if ((((x < 0) || (y < 0)) || (y >= image.height)) || (x >= image.width)){
						throw "x and y must be non-negative and less than the dimensions of the image";
					}
				}				else
{
					x = (image.width >>> 1);
					y = (image.height >>> 1);
				}
				var imageDataURL = image.toDataURL();
				var style = ((((("url(\"" + imageDataURL) + "\") ") + x) + " ") + y) + ", default";
				curCursor = (curElement.style.cursor = style);
			}			else
{
				if (arguments.length === 1){
					var mode = arguments[0];
					curCursor = (curElement.style.cursor = mode);
				}				else
{
					curCursor = (curElement.style.cursor = oldCursor);
				}
			}
		});
		p.noCursor = 		(function (){
			curCursor = (curElement.style.cursor = PConstants.NOCURSOR);
		});
		p.link = 		(function (href, target){
			if (target !== undef){
				window.open(href, target);
			}			else
{
				window.location = href;
			}
		});
		p.beginDraw = 		(function (){
		});
		p.endDraw = 		(function (){
		});
		p.Import = 		(function (lib){
		});
		var contextMenu = 		(function (e){
			e.preventDefault();
			e.stopPropagation();
		});
		p.disableContextMenu = 		(function (){
			curElement.addEventListener('contextmenu', contextMenu, false);
		});
		p.enableContextMenu = 		(function (){
			curElement.removeEventListener('contextmenu', contextMenu, false);
		});
		p.status = 		(function (text){
			window.status = text;
		});
				function decToBin(value, numBitsInValue){
			var mask = 1;
			mask = (mask << (numBitsInValue - 1));
			var str = "";
			for(var i = 0; i < numBitsInValue;i++){
				str += ((mask & value) ? "1" : "0");
				mask = (mask >>> 1);
			}
			return str;
		}
		p.binary = 		(function (num, numBits){
			var numBitsInValue = 32;
			if (typeofnum === "number"){
				if (numBits){
					numBitsInValue = numBits;
				}
				return decToBin(num, numBitsInValue);
			}
			if (num instanceof Char){
				num = num.toString().charCodeAt(0);
				if (numBits){
					numBitsInValue = 32;
				}				else
{
					numBitsInValue = 16;
				}
			}
			var str = decToBin(num, numBitsInValue);
			if (numBits){
				str = str.substr(-numBits);
			}
			return str;
		});
		p.unbinary = 		(function (binaryString){
			var binaryPattern = new RegExp("^[0|1]{8}$");
			var addUp = 0;
			var i;
			if (binaryString instanceof Array){
				var values = [];
				for(i = 0; i < binaryString.length;i++){
					values[i] = p.unbinary(binaryString[i]);
				}
				return values;
			}			else
{
				if (isNaN(binaryString)){
					throw "NaN_Err";
				}				else
{
					if ((arguments.length === 1) || (binaryString.length === 8)){
						if (binaryPattern.test(binaryString)){
							for(i = 0; i < 8;i++){
								addUp += (Math.pow(2, i) * parseInt(binaryString.charAt(7 - i), 10));
							}
							return addUp + "";
						}						else
{
							throw "notBinary: the value passed into unbinary was not an 8 bit binary number";
						}
					}					else
{
						throw "longErr";
					}
				}
			}
		});
				function nfCoreScalar(value, plus, minus, leftDigits, rightDigits, group){
			var sign = (value < 0) ? minus : plus;
			var autoDetectDecimals = rightDigits === 0;
			var rightDigitsOfDefault = ((rightDigits === undef) || (rightDigits < 0)) ? 0 : rightDigits;
			var absValue = Math.abs(value);
			if (autoDetectDecimals){
				rightDigitsOfDefault = 1;
				absValue *= 10;
				while((Math.abs(Math.round(absValue) - absValue) > 1E-06) && (rightDigitsOfDefault < 7)){
					++rightDigitsOfDefault;
					absValue *= 10;
				}
			}			else
{
				if (rightDigitsOfDefault !== 0){
					absValue *= Math.pow(10, rightDigitsOfDefault);
				}
			}
			var number; var doubled = absValue * 2;
			if (Math.floor(absValue) === absValue){
				number = absValue;
			}			else
{
				if (Math.floor(doubled) === doubled){
					var floored = Math.floor(absValue);
					number = (floored + (floored % 2));
				}				else
{
					number = Math.round(absValue);
				}
			}
			var buffer = "";
			var totalDigits = leftDigits + rightDigitsOfDefault;
			while((totalDigits > 0) || (number > 0)){
				totalDigits--;
				buffer = (("" + (number % 10)) + buffer);
				number = Math.floor(number / 10);
			}
			if (group !== undef){
				var i = (buffer.length - 3) - rightDigitsOfDefault;
				while(i > 0){
					buffer = ((buffer.substring(0, i) + group) + buffer.substring(i));
					i -= 3;
				}
			}
			if (rightDigitsOfDefault > 0){
				return ((sign + buffer.substring(0, buffer.length - rightDigitsOfDefault)) + ".") + buffer.substring(buffer.length - rightDigitsOfDefault, buffer.length);
			}			else
{
				return sign + buffer;
			}
		}
				function nfCore(value, plus, minus, leftDigits, rightDigits, group){
			if (value instanceof Array){
				var arr = [];
				for(var i = 0, len = value.length; i < len;i++){
					arr.push(nfCoreScalar(value[i], plus, minus, leftDigits, rightDigits, group));
				}
				return arr;
			}			else
{
				return nfCoreScalar(value, plus, minus, leftDigits, rightDigits, group);
			}
		}
		p.nf = 		(function (value, leftDigits, rightDigits){
			return nfCore(value, "", "-", leftDigits, rightDigits);
		});
		p.nfs = 		(function (value, leftDigits, rightDigits){
			return nfCore(value, " ", "-", leftDigits, rightDigits);
		});
		p.nfp = 		(function (value, leftDigits, rightDigits){
			return nfCore(value, "+", "-", leftDigits, rightDigits);
		});
		p.nfc = 		(function (value, leftDigits, rightDigits){
			return nfCore(value, "", "-", leftDigits, rightDigits, ",");
		});
		var decimalToHex = 		(function (d, padding){
			padding = (((padding === undef) || (padding === null)) ? (padding = 8) : padding);
			if (d < 0){
				d = ((-1 + d) + 1);
			}
			var hex = Number(d).toString(16).toUpperCase();
			while(hex.length < padding){
				hex = ("0" + hex);
			}
			if (hex.length >= padding){
				hex = hex.substring(hex.length - padding, hex.length);
			}
			return hex;
		});
		p.hex = 		(function (value, len){
			if (arguments.length === 1){
				if (value instanceof Char){
					len = 4;
				}				else
{
					len = 8;
				}
			}
			return decimalToHex(value, len);
		});
				function unhexScalar(hex){
			var value = parseInt("0x" + hex, 16);
			if (value > 2147483647){
				value -= 4294967296;
			}
			return value;
		}
		p.unhex = 		(function (hex){
			if (hex instanceof Array){
				var arr = [];
				for(var i = 0; i < hex.length;i++){
					arr.push(unhexScalar(hex[i]));
				}
				return arr;
			}			else
{
				return unhexScalar(hex);
			}
		});
		p.loadStrings = 		(function (filename){
			if (localStorage[filename]){
				return localStorage[filename].split("\n");
			}
			var filecontent = ajax(filename);
			if ((typeoffilecontent !== "string") || (filecontent === "")){
				return [];
			}
			filecontent = filecontent.replace(/(\r\n?)/g, "\n").replace(/\n$/, "");
			return filecontent.split("\n");
		});
		p.saveStrings = 		(function (filename, strings){
			localStorage[filename] = strings.join('\n');
		});
		p.loadBytes = 		(function (url, strings){
			var string = ajax(url);
			var ret = [];
			for(var i = 0; i < string.length;i++){
				ret.push(string.charCodeAt(i));
			}
			return ret;
		});
				function removeFirstArgument(args){
			return Array.prototype.slice.call(args, 1);
		}
		p.matchAll = 		(function (aString, aRegExp){
			var results = []; var latest;
			var regexp = new RegExp(aRegExp, "g");
			while((latest = regexp.exec(aString)) !== null){
				results.push(latest);
				if (latest[0].length === 0){
					++regexp.lastIndex;
				}
			}
			return (results.length > 0) ? results : null;
		});
		p.__contains = 		(function (subject, subStr){
			if (typeofsubject !== "string"){
				return subject.contains.apply(subject, removeFirstArgument(arguments));
			}
			return (((subject !== null) && (subStr !== null)) && (typeofsubStr === "string")) && (subject.indexOf(subStr) > -1);
		});
		p.__replaceAll = 		(function (subject, regex, replacement){
			if (typeofsubject !== "string"){
				return subject.replaceAll.apply(subject, removeFirstArgument(arguments));
			}
			return subject.replace(new RegExp(regex, "g"), replacement);
		});
		p.__replaceFirst = 		(function (subject, regex, replacement){
			if (typeofsubject !== "string"){
				return subject.replaceFirst.apply(subject, removeFirstArgument(arguments));
			}
			return subject.replace(new RegExp(regex, ""), replacement);
		});
		p.__replace = 		(function (subject, what, replacement){
			if (typeofsubject !== "string"){
				return subject.replace.apply(subject, removeFirstArgument(arguments));
			}
			if (what instanceof RegExp){
				return subject.replace(what, replacement);
			}
			if (typeofwhat !== "string"){
				what = what.toString();
			}
			if (what === ""){
				return subject;
			}
			var i = subject.indexOf(what);
			if (i < 0){
				return subject;
			}
			var j = 0; var result = "";
			do{
				result += (subject.substring(j, i) + replacement);
				j = (i + what.length);
			}while((i = subject.indexOf(what, j)) >= 0);
			return result + subject.substring(j);
		});
		p.__equals = 		(function (subject, other){
			if (subject.equals instanceof Function){
				return subject.equals.apply(subject, removeFirstArgument(arguments));
			}
			return subject.valueOf() === other.valueOf();
		});
		p.__toCharArray = 		(function (subject){
			if (typeofsubject !== "string"){
				return subject.toCharArray.apply(subject, removeFirstArgument(arguments));
			}
			var chars = [];
			for(var i = 0, len = subject.length; i < len;++i){
				chars[i] = new Char(subject.charAt(i));
			}
			return chars;
		});
		p.__split = 		(function (subject, regex, limit){
			var pattern = new RegExp(regex);
			if ((limit === undef) || (limit < 1)){
				return subject.split(pattern);
			}
			var result = []; var currSubject = subject; var pos;
			while(((pos = currSubject.search(pattern)) !== -1) && (result.length < (limit - 1))){
				var match = pattern.exec(currSubject).toString();
				result.push(currSubject.substring(0, pos));
				currSubject = currSubject.substring(pos + match.length);
			}
			if ((pos !== -1) || (currSubject !== "")){
				result.push(currSubject);
			}
			return result;
		});
		p.match = 		(function (str, regexp){
			return str.match(regexp);
		});
		p.__hashCode = 		(function (subject){
			if (subject.hashCode instanceof Function){
				return subject.hashCode.apply(subject, removeFirstArgument(arguments));
			}
			return 0 | subject;
		});
		p.__printStackTrace = 		(function (subject){
			p.println("Exception: " + subject.toString());
		});
		var logBuffer = [];
		p.console = (window.console || Processing.logger);
		p.println = 		(function (message){
			var bufferLen = logBuffer.length;
			if (bufferLen){
				Processing.logger.log(logBuffer.join(""));
				logBuffer.length = 0;
			}
			if ((arguments.length === 0) && (bufferLen === 0)){
				Processing.logger.log("");
			}			else
{
				if (arguments.length !== 0){
					Processing.logger.log(message);
				}
			}
		});
		p.print = 		(function (message){
			logBuffer.push(message);
		});
		p.str = 		(function (val){
			if (val instanceof Array){
				var arr = [];
				for(var i = 0; i < val.length;i++){
					arr.push(val[i].toString() + "");
				}
				return arr;
			}			else
{
				return val.toString() + "";
			}
		});
		p.trim = 		(function (str){
			if (str instanceof Array){
				var arr = [];
				for(var i = 0; i < str.length;i++){
					arr.push(str[i].replace(/^\s*/, '').replace(/\s*$/, '').replace(/\r*$/, ''));
				}
				return arr;
			}			else
{
				return str.replace(/^\s*/, '').replace(/\s*$/, '').replace(/\r*$/, '');
			}
		});
				function booleanScalar(val){
			if (typeofval === 'number'){
				return val !== 0;
			}			else
{
				if (typeofval === 'boolean'){
					return val;
				}				else
{
					if (typeofval === 'string'){
						return val.toLowerCase() === 'true';
					}					else
{
						if (val instanceof Char){
							return ((val.code === 49) || (val.code === 84)) || (val.code === 116);
						}
					}
				}
			}
		}
		p.parseBoolean = 		(function (val){
			if (val instanceof Array){
				var ret = [];
				for(var i = 0; i < val.length;i++){
					ret.push(booleanScalar(val[i]));
				}
				return ret;
			}			else
{
				return booleanScalar(val);
			}
		});
		p.parseByte = 		(function (what){
			if (what instanceof Array){
				var bytes = [];
				for(var i = 0; i < what.length;i++){
					bytes.push((0 - (what[i] & -128)) | (what[i] & 127));
				}
				return bytes;
			}			else
{
				return (0 - (what & -128)) | (what & 127);
			}
		});
		p.parseChar = 		(function (key){
			if (typeofkey === "number"){
				return new Char(String.fromCharCode(key & -1));
			}			else
{
				if (key instanceof Array){
					var ret = [];
					for(var i = 0; i < key.length;i++){
						ret.push(new Char(String.fromCharCode(key[i] & -1)));
					}
					return ret;
				}				else
{
					throw "char() may receive only one argument of type int, byte, int[], or byte[].";
				}
			}
		});
				function floatScalar(val){
			if (typeofval === 'number'){
				return val;
			}			else
{
				if (typeofval === 'boolean'){
					return val ? 1 : 0;
				}				else
{
					if (typeofval === 'string'){
						return parseFloat(val);
					}					else
{
						if (val instanceof Char){
							return val.code;
						}
					}
				}
			}
		}
		p.parseFloat = 		(function (val){
			if (val instanceof Array){
				var ret = [];
				for(var i = 0; i < val.length;i++){
					ret.push(floatScalar(val[i]));
				}
				return ret;
			}			else
{
				return floatScalar(val);
			}
		});
				function intScalar(val, radix){
			if (typeofval === 'number'){
				return val & -1;
			}			else
{
				if (typeofval === 'boolean'){
					return val ? 1 : 0;
				}				else
{
					if (typeofval === 'string'){
						var number = parseInt(val, radix || 10);
						return number & -1;
					}					else
{
						if (val instanceof Char){
							return val.code;
						}
					}
				}
			}
		}
		p.parseInt = 		(function (val, radix){
			if (val instanceof Array){
				var ret = [];
				for(var i = 0; i < val.length;i++){
					if ((typeofval[i] === 'string') && !/^\s*[+\-]?\d+\s*$/.test(val[i])){
						ret.push(0);
					}					else
{
						ret.push(intScalar(val[i], radix));
					}
				}
				return ret;
			}			else
{
				return intScalar(val, radix);
			}
		});
		p.__int_cast = 		(function (val){
			return 0 | val;
		});
		p.__instanceof = 		(function (obj, type){
			if (typeoftype !== "function"){
				throw "Function is expected as type argument for instanceof operator";
			}
			if (typeofobj === "string"){
				return (type === Object) || (type === String);
			}
			if (obj instanceof type){
				return true;
			}
			if ((typeofobj !== "object") || (obj === null)){
				return false;
			}
			var objType = obj.constructor;
			if (type.$isInterface){
				var interfaces = [];
				while(objType){
					if (objType.$interfaces){
						interfaces = interfaces.concat(objType.$interfaces);
					}
					objType = objType.$base;
				}
				while(interfaces.length > 0){
					var i = interfaces.shift();
					if (i === type){
						return true;
					}
					if (i.$interfaces){
						interfaces = interfaces.concat(i.$interfaces);
					}
				}
				return false;
			}
			while(objType.hasOwnProperty("$base")){
				objType = objType.$base;
				if (objType === type){
					return true;
				}
			}
			return false;
		});
		p.abs = Math.abs;
		p.ceil = Math.ceil;
		p.constrain = 		(function (aNumber, aMin, aMax){
			return (aNumber > aMax) ? aMax : ((aNumber < aMin) ? aMin : aNumber);
		});
		p.dist = 		(function (){
			var dx; var dy; var dz;
			if (arguments.length === 4){
				dx = (arguments[0] - arguments[2]);
				dy = (arguments[1] - arguments[3]);
				return Math.sqrt((dx * dx) + (dy * dy));
			}			else
{
				if (arguments.length === 6){
					dx = (arguments[0] - arguments[3]);
					dy = (arguments[1] - arguments[4]);
					dz = (arguments[2] - arguments[5]);
					return Math.sqrt(((dx * dx) + (dy * dy)) + (dz * dz));
				}
			}
		});
		p.exp = Math.exp;
		p.floor = Math.floor;
		p.lerp = 		(function (value1, value2, amt){
			return ((value2 - value1) * amt) + value1;
		});
		p.log = Math.log;
		p.mag = 		(function (a, b, c){
			if (arguments.length === 2){
				return Math.sqrt((a * a) + (b * b));
			}			else
{
				if (arguments.length === 3){
					return Math.sqrt(((a * a) + (b * b)) + (c * c));
				}
			}
		});
		p.map = 		(function (value, istart, istop, ostart, ostop){
			return ostart + ((ostop - ostart) * ((value - istart) / (istop - istart)));
		});
		p.max = 		(function (){
			if (arguments.length === 2){
				return (arguments[0] < arguments[1]) ? arguments[1] : arguments[0];
			}			else
{
				var numbers = (arguments.length === 1) ? arguments[0] : arguments;
				if (!(("length" in numbers) && (numbers.length > 0))){
					throw "Non-empty array is expected";
				}
				var max = numbers[0]; var count = numbers.length;
				for(var i = 1; i < count;++i){
					if (max < numbers[i]){
						max = numbers[i];
					}
				}
				return max;
			}
		});
		p.min = 		(function (){
			if (arguments.length === 2){
				return (arguments[0] < arguments[1]) ? arguments[0] : arguments[1];
			}			else
{
				var numbers = (arguments.length === 1) ? arguments[0] : arguments;
				if (!(("length" in numbers) && (numbers.length > 0))){
					throw "Non-empty array is expected";
				}
				var min = numbers[0]; var count = numbers.length;
				for(var i = 1; i < count;++i){
					if (min > numbers[i]){
						min = numbers[i];
					}
				}
				return min;
			}
		});
		p.norm = 		(function (aNumber, low, high){
			return (aNumber - low) / (high - low);
		});
		p.pow = Math.pow;
		p.round = Math.round;
		p.sq = 		(function (aNumber){
			return aNumber * aNumber;
		});
		p.sqrt = Math.sqrt;
		p.acos = Math.acos;
		p.asin = Math.asin;
		p.atan = Math.atan;
		p.atan2 = Math.atan2;
		p.cos = Math.cos;
		p.degrees = 		(function (aAngle){
			return (aAngle * 180) / Math.PI;
		});
		p.radians = 		(function (aAngle){
			return (aAngle / 180) * Math.PI;
		});
		p.sin = Math.sin;
		p.tan = Math.tan;
		var currentRandom = Math.random;
		p.random = 		(function (){
			if (arguments.length === 0){
				return currentRandom();
			}			else
{
				if (arguments.length === 1){
					return currentRandom() * arguments[0];
				}				else
{
					var aMin = arguments[0]; var aMax = arguments[1];
					return (currentRandom() * (aMax - aMin)) + aMin;
				}
			}
		});
				function Marsaglia(i1, i2){
			var z = i1 || 362436069; var w = i2 || 521288629;
			var nextInt = 			(function (){
				z = (((36969 * (z & 65535)) + (z >>> 16)) & -1);
				w = (((18000 * (w & 65535)) + (w >>> 16)) & -1);
				return (((z & -1) << 16) | (w & -1)) & -1;
			});
			this.nextDouble = 			(function (){
				var i = nextInt() / 4294967296;
				return (i < 0) ? (1 + i) : i;
			});
			this.nextInt = nextInt;
		}
		Marsaglia.createRandomized = 		(function (){
			var now = new Date();
			return new Marsaglia((now / 60000) & -1, now & -1);
		});
		p.randomSeed = 		(function (seed){
			currentRandom = new Marsaglia(seed).nextDouble;
		});
		p.Random = 		(function (seed){
			var haveNextNextGaussian = false; var nextNextGaussian; var random;
			this.nextGaussian = 			(function (){
				if (haveNextNextGaussian){
					haveNextNextGaussian = false;
					return nextNextGaussian;
				}				else
{
					var v1; var v2; var s;
					do{
						v1 = ((2 * random()) - 1);
						v2 = ((2 * random()) - 1);
						s = ((v1 * v1) + (v2 * v2));
					}while((s >= 1) || (s === 0));
					var multiplier = Math.sqrt((-2 * Math.log(s)) / s);
					nextNextGaussian = (v2 * multiplier);
					haveNextNextGaussian = true;
					return v1 * multiplier;
				}
			});
			random = ((seed === undef) ? Math.random : new Marsaglia(seed).nextDouble);
		});
				function PerlinNoise(seed){
			var rnd = (seed !== undef) ? new Marsaglia(seed) : Marsaglia.createRandomized();
			var i; var j;
			var perm = new Uint8Array(512);
			for(i = 0; i < 256;++i){
				perm[i] = i;
			}
			for(i = 0; i < 256;++i){
				var t = perm[j = (rnd.nextInt() & -1)];
				perm[j] = perm[i];
				perm[i] = t;
			}
			for(i = 0; i < 256;++i){
				perm[i + 256] = perm[i];
			}
						function grad3d(i, x, y, z){
				var h = i & 15;
				var u = (h < 8) ? x : y; var v = (h < 4) ? y : (((h === 12) || (h === 14)) ? x : z);
				return (((h & 1) === 0) ? u : -u) + (((h & 2) === 0) ? v : -v);
			}
						function grad2d(i, x, y){
				var v = ((i & 1) === 0) ? x : y;
				return ((i & 2) === 0) ? -v : v;
			}
						function grad1d(i, x){
				return ((i & 1) === 0) ? -x : x;
			}
						function lerp(t, a, b){
				return a + (t * (b - a));
			}
			this.noise3d = 			(function (x, y, z){
				var X = Math.floor(x) & 255; var Y = Math.floor(y) & 255; var Z = Math.floor(z) & 255;
				x -= Math.floor(x);
				y -= Math.floor(y);
				z -= Math.floor(z);
				var fx = ((3 - (2 * x)) * x) * x; var fy = ((3 - (2 * y)) * y) * y; var fz = ((3 - (2 * z)) * z) * z;
				var p0 = perm[X] + Y; var p00 = perm[p0] + Z; var p01 = perm[p0 + 1] + Z; var p1 = perm[X + 1] + Y; var p10 = perm[p1] + Z; var p11 = perm[p1 + 1] + Z;
				return lerp(fz, lerp(fy, lerp(fx, grad3d(perm[p00], x, y, z), grad3d(perm[p10], x - 1, y, z)), lerp(fx, grad3d(perm[p01], x, y - 1, z), grad3d(perm[p11], x - 1, y - 1, z))), lerp(fy, lerp(fx, grad3d(perm[p00 + 1], x, y, z - 1), grad3d(perm[p10 + 1], x - 1, y, z - 1)), lerp(fx, grad3d(perm[p01 + 1], x, y - 1, z - 1), grad3d(perm[p11 + 1], x - 1, y - 1, z - 1))));
			});
			this.noise2d = 			(function (x, y){
				var X = Math.floor(x) & 255; var Y = Math.floor(y) & 255;
				x -= Math.floor(x);
				y -= Math.floor(y);
				var fx = ((3 - (2 * x)) * x) * x; var fy = ((3 - (2 * y)) * y) * y;
				var p0 = perm[X] + Y; var p1 = perm[X + 1] + Y;
				return lerp(fy, lerp(fx, grad2d(perm[p0], x, y), grad2d(perm[p1], x - 1, y)), lerp(fx, grad2d(perm[p0 + 1], x, y - 1), grad2d(perm[p1 + 1], x - 1, y - 1)));
			});
			this.noise1d = 			(function (x){
				var X = Math.floor(x) & 255;
				x -= Math.floor(x);
				var fx = ((3 - (2 * x)) * x) * x;
				return lerp(fx, grad1d(perm[X], x), grad1d(perm[X + 1], x - 1));
			});
		}
		var noiseProfile = {		generator:undef, 		octaves:4, 		fallout:0.5, 		seed:undef		};
		p.noise = 		(function (x, y, z){
			if (noiseProfile.generator === undef){
				noiseProfile.generator = new PerlinNoise(noiseProfile.seed);
			}
			var generator = noiseProfile.generator;
			var effect = 1; var k = 1; var sum = 0;
			for(var i = 0; i < noiseProfile.octaves;++i){
				effect *= noiseProfile.fallout;
				switch(arguments.length) {
					case 1:
{
						sum += ((effect * (1 + generator.noise1d(k * x))) / 2);
						break ;
					}					case 2:
{
						sum += ((effect * (1 + generator.noise2d(k * x, k * y))) / 2);
						break ;
					}					case 3:
{
						sum += ((effect * (1 + generator.noise3d(k * x, k * y, k * z))) / 2);
						break ;
					}}
				k *= 2;
			}
			return sum;
		});
		p.noiseDetail = 		(function (octaves, fallout){
			noiseProfile.octaves = octaves;
			if (fallout !== undef){
				noiseProfile.fallout = fallout;
			}
		});
		p.noiseSeed = 		(function (seed){
			noiseProfile.seed = seed;
			noiseProfile.generator = undef;
		});
		DrawingShared.prototype.size = 		(function (aWidth, aHeight, aMode){
			p.stroke(0);
			p.fill(255);
			var savedProperties = {			fillStyle:curContext.fillStyle, 			strokeStyle:curContext.strokeStyle, 			lineCap:curContext.lineCap, 			lineJoin:curContext.lineJoin			};
			if (curElement.style.length > 0){
				curElement.style.removeProperty("width");
				curElement.style.removeProperty("height");
			}
			curElement.width = (p.width = (aWidth || 100));
			curElement.height = (p.height = (aHeight || 100));
			for(var prop in savedProperties){
				if (savedProperties.hasOwnProperty(prop)){
					curContext[prop] = savedProperties[prop];
				}
			}
			p.textSize(curTextSize);
			p.background();
			maxPixelsCached = Math.max(1000, (aWidth * aHeight) * 0.05);
			p.externals.context = curContext;
			for(var i = 0; i < PConstants.SINCOS_LENGTH;i++){
				sinLUT[i] = p.sin((i * (PConstants.PI / 180)) * 0.5);
				cosLUT[i] = p.cos((i * (PConstants.PI / 180)) * 0.5);
			}
		});
		Drawing2D.prototype.size = 		(function (aWidth, aHeight, aMode){
			if (curContext === undef){
				curContext = curElement.getContext("2d");
				userMatrixStack = new PMatrixStack();
				userReverseMatrixStack = new PMatrixStack();
				forwardTransform = new PMatrix2D();
				reverseTransform = new PMatrix2D();
				modelView = forwardTransform;
				modelViewInv = reverseTransform;
			}
			DrawingShared.prototype.size.apply(this, arguments);
		});
		Drawing3D.prototype.size = 		(function (){
			var size3DCalled = false;
			return 			(function size(aWidth, aHeight, aMode){
				if (size3DCalled){
					throw "Multiple calls to size() for 3D renders are not allowed.";
				}
				size3DCalled = true;
								function getGLContext(canvas){
					var ctxNames = ['experimental-webgl','webgl','webkit-3d']; var gl;
					for(var i = 0, l = ctxNames.length; i < l;i++){
						gl = canvas.getContext(ctxNames[i]);
						if (gl){
							break ;
						}
					}
					return gl;
				}
				try{
					if ((curElement.width !== aWidth) || (curElement.height !== aHeight)){
						curElement.setAttribute("width", aWidth);
						curElement.setAttribute("height", aHeight);
					}
					curContext = getGLContext(curElement);
					canTex = curContext.createTexture();
					textTex = curContext.createTexture();
				}catch( e_size ){
					Processing.debug(e_size);
				}
				if (!curContext){
					throw "WebGL context is not supported on this browser.";
				}
				curContext.viewport(0, 0, curElement.width, curElement.height);
				curContext.enable(curContext.DEPTH_TEST);
				curContext.enable(curContext.BLEND);
				curContext.blendFunc(curContext.SRC_ALPHA, curContext.ONE_MINUS_SRC_ALPHA);
				programObject2D = createProgramObject(curContext, vertexShaderSource2D, fragmentShaderSource2D);
				curContext.useProgram(programObject2D);
				p.strokeWeight(1);
				programObject3D = createProgramObject(curContext, vertexShaderSource3D, fragmentShaderSource3D);
				programObjectUnlitShape = createProgramObject(curContext, vShaderSrcUnlitShape, fShaderSrcUnlitShape);
				curContext.useProgram(programObject3D);
				uniformi("usingTexture3d", programObject3D, "usingTexture", usingTexture);
				p.lightFalloff(1, 0, 0);
				p.shininess(1);
				p.ambient(255, 255, 255);
				p.specular(0, 0, 0);
				p.emissive(0, 0, 0);
				boxBuffer = curContext.createBuffer();
				curContext.bindBuffer(curContext.ARRAY_BUFFER, boxBuffer);
				curContext.bufferData(curContext.ARRAY_BUFFER, boxVerts, curContext.STATIC_DRAW);
				boxNormBuffer = curContext.createBuffer();
				curContext.bindBuffer(curContext.ARRAY_BUFFER, boxNormBuffer);
				curContext.bufferData(curContext.ARRAY_BUFFER, boxNorms, curContext.STATIC_DRAW);
				boxOutlineBuffer = curContext.createBuffer();
				curContext.bindBuffer(curContext.ARRAY_BUFFER, boxOutlineBuffer);
				curContext.bufferData(curContext.ARRAY_BUFFER, boxOutlineVerts, curContext.STATIC_DRAW);
				rectBuffer = curContext.createBuffer();
				curContext.bindBuffer(curContext.ARRAY_BUFFER, rectBuffer);
				curContext.bufferData(curContext.ARRAY_BUFFER, rectVerts, curContext.STATIC_DRAW);
				rectNormBuffer = curContext.createBuffer();
				curContext.bindBuffer(curContext.ARRAY_BUFFER, rectNormBuffer);
				curContext.bufferData(curContext.ARRAY_BUFFER, rectNorms, curContext.STATIC_DRAW);
				sphereBuffer = curContext.createBuffer();
				lineBuffer = curContext.createBuffer();
				fillBuffer = curContext.createBuffer();
				fillColorBuffer = curContext.createBuffer();
				strokeColorBuffer = curContext.createBuffer();
				shapeTexVBO = curContext.createBuffer();
				pointBuffer = curContext.createBuffer();
				curContext.bindBuffer(curContext.ARRAY_BUFFER, pointBuffer);
				curContext.bufferData(curContext.ARRAY_BUFFER, new Float32Array([0,0,0]), curContext.STATIC_DRAW);
				textBuffer = curContext.createBuffer();
				curContext.bindBuffer(curContext.ARRAY_BUFFER, textBuffer);
				curContext.bufferData(curContext.ARRAY_BUFFER, new Float32Array([1,1,0,-1,1,0,-1,-1,0,1,-1,0]), curContext.STATIC_DRAW);
				textureBuffer = curContext.createBuffer();
				curContext.bindBuffer(curContext.ARRAY_BUFFER, textureBuffer);
				curContext.bufferData(curContext.ARRAY_BUFFER, new Float32Array([0,0,1,0,1,1,0,1]), curContext.STATIC_DRAW);
				indexBuffer = curContext.createBuffer();
				curContext.bindBuffer(curContext.ELEMENT_ARRAY_BUFFER, indexBuffer);
				curContext.bufferData(curContext.ELEMENT_ARRAY_BUFFER, new Uint16Array([0,1,2,2,3,0]), curContext.STATIC_DRAW);
				cam = new PMatrix3D();
				cameraInv = new PMatrix3D();
				modelView = new PMatrix3D();
				modelViewInv = new PMatrix3D();
				projection = new PMatrix3D();
				p.camera();
				p.perspective();
				forwardTransform = modelView;
				reverseTransform = modelViewInv;
				userMatrixStack = new PMatrixStack();
				userReverseMatrixStack = new PMatrixStack();
				curveBasisMatrix = new PMatrix3D();
				curveToBezierMatrix = new PMatrix3D();
				curveDrawMatrix = new PMatrix3D();
				bezierDrawMatrix = new PMatrix3D();
				bezierBasisInverse = new PMatrix3D();
				bezierBasisMatrix = new PMatrix3D();
				bezierBasisMatrix.set(-1, 3, -3, 1, 3, -6, 3, 0, -3, 3, 0, 0, 1, 0, 0, 0);
				DrawingShared.prototype.size.apply(this, arguments);
			});
		})();
		Drawing2D.prototype.ambientLight = DrawingShared.prototype.a3DOnlyFunction;
		Drawing3D.prototype.ambientLight = 		(function (r, g, b, x, y, z){
			if (lightCount === PConstants.MAX_LIGHTS){
				throw ("can only create " + PConstants.MAX_LIGHTS) + " lights";
			}
			var pos = new PVector(x, y, z);
			var view = new PMatrix3D();
			view.scale(1, -1, 1);
			view.apply(modelView.array());
			view.mult(pos, pos);
			curContext.useProgram(programObject3D);
			uniformf("lights.color.3d." + lightCount, programObject3D, ("lights" + lightCount) + ".color", [r / 255,g / 255,b / 255]);
			uniformf("lights.position.3d." + lightCount, programObject3D, ("lights" + lightCount) + ".position", pos.array());
			uniformi("lights.type.3d." + lightCount, programObject3D, ("lights" + lightCount) + ".type", 0);
			uniformi("lightCount3d", programObject3D, "lightCount", ++lightCount);
		});
		Drawing2D.prototype.directionalLight = DrawingShared.prototype.a3DOnlyFunction;
		Drawing3D.prototype.directionalLight = 		(function (r, g, b, nx, ny, nz){
			if (lightCount === PConstants.MAX_LIGHTS){
				throw ("can only create " + PConstants.MAX_LIGHTS) + " lights";
			}
			curContext.useProgram(programObject3D);
			var mvm = new PMatrix3D();
			mvm.scale(1, -1, 1);
			mvm.apply(modelView.array());
			mvm = mvm.array();
			var dir = [((mvm[0] * nx) + (mvm[4] * ny)) + (mvm[8] * nz),((mvm[1] * nx) + (mvm[5] * ny)) + (mvm[9] * nz),((mvm[2] * nx) + (mvm[6] * ny)) + (mvm[10] * nz)];
			uniformf("lights.color.3d." + lightCount, programObject3D, ("lights" + lightCount) + ".color", [r / 255,g / 255,b / 255]);
			uniformf("lights.position.3d." + lightCount, programObject3D, ("lights" + lightCount) + ".position", dir);
			uniformi("lights.type.3d." + lightCount, programObject3D, ("lights" + lightCount) + ".type", 1);
			uniformi("lightCount3d", programObject3D, "lightCount", ++lightCount);
		});
		Drawing2D.prototype.lightFalloff = DrawingShared.prototype.a3DOnlyFunction;
		Drawing3D.prototype.lightFalloff = 		(function (constant, linear, quadratic){
			curContext.useProgram(programObject3D);
			uniformf("falloff3d", programObject3D, "falloff", [constant,linear,quadratic]);
		});
		Drawing2D.prototype.lightSpecular = DrawingShared.prototype.a3DOnlyFunction;
		Drawing3D.prototype.lightSpecular = 		(function (r, g, b){
			curContext.useProgram(programObject3D);
			uniformf("specular3d", programObject3D, "specular", [r / 255,g / 255,b / 255]);
		});
		p.lights = 		(function (){
			p.ambientLight(128, 128, 128);
			p.directionalLight(128, 128, 128, 0, 0, -1);
			p.lightFalloff(1, 0, 0);
			p.lightSpecular(0, 0, 0);
		});
		Drawing2D.prototype.pointLight = DrawingShared.prototype.a3DOnlyFunction;
		Drawing3D.prototype.pointLight = 		(function (r, g, b, x, y, z){
			if (lightCount === PConstants.MAX_LIGHTS){
				throw ("can only create " + PConstants.MAX_LIGHTS) + " lights";
			}
			var pos = new PVector(x, y, z);
			var view = new PMatrix3D();
			view.scale(1, -1, 1);
			view.apply(modelView.array());
			view.mult(pos, pos);
			curContext.useProgram(programObject3D);
			uniformf("lights.color.3d." + lightCount, programObject3D, ("lights" + lightCount) + ".color", [r / 255,g / 255,b / 255]);
			uniformf("lights.position.3d." + lightCount, programObject3D, ("lights" + lightCount) + ".position", pos.array());
			uniformi("lights.type.3d." + lightCount, programObject3D, ("lights" + lightCount) + ".type", 2);
			uniformi("lightCount3d", programObject3D, "lightCount", ++lightCount);
		});
		Drawing2D.prototype.noLights = DrawingShared.prototype.a3DOnlyFunction;
		Drawing3D.prototype.noLights = 		(function (){
			lightCount = 0;
			curContext.useProgram(programObject3D);
			uniformi("lightCount3d", programObject3D, "lightCount", lightCount);
		});
		Drawing2D.prototype.spotLight = DrawingShared.prototype.a3DOnlyFunction;
		Drawing3D.prototype.spotLight = 		(function (r, g, b, x, y, z, nx, ny, nz, angle, concentration){
			if (lightCount === PConstants.MAX_LIGHTS){
				throw ("can only create " + PConstants.MAX_LIGHTS) + " lights";
			}
			curContext.useProgram(programObject3D);
			var pos = new PVector(x, y, z);
			var mvm = new PMatrix3D();
			mvm.scale(1, -1, 1);
			mvm.apply(modelView.array());
			mvm.mult(pos, pos);
			mvm = mvm.array();
			var dir = [((mvm[0] * nx) + (mvm[4] * ny)) + (mvm[8] * nz),((mvm[1] * nx) + (mvm[5] * ny)) + (mvm[9] * nz),((mvm[2] * nx) + (mvm[6] * ny)) + (mvm[10] * nz)];
			uniformf("lights.color.3d." + lightCount, programObject3D, ("lights" + lightCount) + ".color", [r / 255,g / 255,b / 255]);
			uniformf("lights.position.3d." + lightCount, programObject3D, ("lights" + lightCount) + ".position", pos.array());
			uniformf("lights.direction.3d." + lightCount, programObject3D, ("lights" + lightCount) + ".direction", dir);
			uniformf("lights.concentration.3d." + lightCount, programObject3D, ("lights" + lightCount) + ".concentration", concentration);
			uniformf("lights.angle.3d." + lightCount, programObject3D, ("lights" + lightCount) + ".angle", angle);
			uniformi("lights.type.3d." + lightCount, programObject3D, ("lights" + lightCount) + ".type", 3);
			uniformi("lightCount3d", programObject3D, "lightCount", ++lightCount);
		});
		p.beginCamera = 		(function (){
			if (manipulatingCamera){
				throw "You cannot call beginCamera() again before calling endCamera()";
			}			else
{
				manipulatingCamera = true;
				forwardTransform = cameraInv;
				reverseTransform = cam;
			}
		});
		p.endCamera = 		(function (){
			if (!manipulatingCamera){
				throw "You cannot call endCamera() before calling beginCamera()";
			}			else
{
				modelView.set(cam);
				modelViewInv.set(cameraInv);
				forwardTransform = modelView;
				reverseTransform = modelViewInv;
				manipulatingCamera = false;
			}
		});
		p.camera = 		(function (eyeX, eyeY, eyeZ, centerX, centerY, centerZ, upX, upY, upZ){
			if (arguments.length === 0){
				cameraX = (curElement.width / 2);
				cameraY = (curElement.height / 2);
				cameraZ = (cameraY / Math.tan(cameraFOV / 2));
				eyeX = cameraX;
				eyeY = cameraY;
				eyeZ = cameraZ;
				centerX = cameraX;
				centerY = cameraY;
				centerZ = 0;
				upX = 0;
				upY = 1;
				upZ = 0;
			}
			var z = new PVector(eyeX - centerX, eyeY - centerY, eyeZ - centerZ);
			var y = new PVector(upX, upY, upZ);
			var transX; var transY; var transZ;
			z.normalize();
			var x = PVector.cross(y, z);
			y = PVector.cross(z, x);
			x.normalize();
			y.normalize();
			cam.set(x.x, x.y, x.z, 0, y.x, y.y, y.z, 0, z.x, z.y, z.z, 0, 0, 0, 0, 1);
			cam.translate(-eyeX, -eyeY, -eyeZ);
			cameraInv.reset();
			cameraInv.invApply(x.x, x.y, x.z, 0, y.x, y.y, y.z, 0, z.x, z.y, z.z, 0, 0, 0, 0, 1);
			cameraInv.translate(eyeX, eyeY, eyeZ);
			modelView.set(cam);
			modelViewInv.set(cameraInv);
		});
		p.perspective = 		(function (fov, aspect, near, far){
			if (arguments.length === 0){
				cameraY = (curElement.height / 2);
				cameraZ = (cameraY / Math.tan(cameraFOV / 2));
				cameraNear = (cameraZ / 10);
				cameraFar = (cameraZ * 10);
				cameraAspect = (curElement.width / curElement.height);
				fov = cameraFOV;
				aspect = cameraAspect;
				near = cameraNear;
				far = cameraFar;
			}
			var yMax; var yMin; var xMax; var xMin;
			yMax = (near * Math.tan(fov / 2));
			yMin = -yMax;
			xMax = (yMax * aspect);
			xMin = (yMin * aspect);
			p.frustum(xMin, xMax, yMin, yMax, near, far);
		});
		p.frustum = 		(function (left, right, bottom, top, near, far){
			frustumMode = true;
			projection = new PMatrix3D();
			projection.set((2 * near) / (right - left), 0, (right + left) / (right - left), 0, 0, (2 * near) / (top - bottom), (top + bottom) / (top - bottom), 0, 0, 0, -(far + near) / (far - near), -((2 * far) * near) / (far - near), 0, 0, -1, 0);
			var proj = new PMatrix3D();
			proj.set(projection);
			proj.transpose();
			curContext.useProgram(programObject2D);
			uniformMatrix("projection2d", programObject2D, "projection", false, proj.array());
			curContext.useProgram(programObject3D);
			uniformMatrix("projection3d", programObject3D, "projection", false, proj.array());
			curContext.useProgram(programObjectUnlitShape);
			uniformMatrix("uProjectionUS", programObjectUnlitShape, "uProjection", false, proj.array());
		});
		p.ortho = 		(function (left, right, bottom, top, near, far){
			if (arguments.length === 0){
				left = 0;
				right = p.width;
				bottom = 0;
				top = p.height;
				near = -10;
				far = 10;
			}
			var x = 2 / (right - left);
			var y = 2 / (top - bottom);
			var z = -2 / (far - near);
			var tx = -(right + left) / (right - left);
			var ty = -(top + bottom) / (top - bottom);
			var tz = -(far + near) / (far - near);
			projection = new PMatrix3D();
			projection.set(x, 0, 0, tx, 0, y, 0, ty, 0, 0, z, tz, 0, 0, 0, 1);
			var proj = new PMatrix3D();
			proj.set(projection);
			proj.transpose();
			curContext.useProgram(programObject2D);
			uniformMatrix("projection2d", programObject2D, "projection", false, proj.array());
			curContext.useProgram(programObject3D);
			uniformMatrix("projection3d", programObject3D, "projection", false, proj.array());
			curContext.useProgram(programObjectUnlitShape);
			uniformMatrix("uProjectionUS", programObjectUnlitShape, "uProjection", false, proj.array());
			frustumMode = false;
		});
		p.printProjection = 		(function (){
			projection.print();
		});
		p.printCamera = 		(function (){
			cam.print();
		});
		Drawing2D.prototype.box = DrawingShared.prototype.a3DOnlyFunction;
		Drawing3D.prototype.box = 		(function (w, h, d){
			if (!h || !d){
				h = (d = w);
			}
			var model = new PMatrix3D();
			model.scale(w, h, d);
			var view = new PMatrix3D();
			view.scale(1, -1, 1);
			view.apply(modelView.array());
			view.transpose();
			if (doFill){
				curContext.useProgram(programObject3D);
				uniformMatrix("model3d", programObject3D, "model", false, model.array());
				uniformMatrix("view3d", programObject3D, "view", false, view.array());
				curContext.enable(curContext.POLYGON_OFFSET_FILL);
				curContext.polygonOffset(1, 1);
				uniformf("color3d", programObject3D, "color", fillStyle);
				if (lightCount > 0){
					var v = new PMatrix3D();
					v.set(view);
					var m = new PMatrix3D();
					m.set(model);
					v.mult(m);
					var normalMatrix = new PMatrix3D();
					normalMatrix.set(v);
					normalMatrix.invert();
					normalMatrix.transpose();
					uniformMatrix("normalTransform3d", programObject3D, "normalTransform", false, normalMatrix.array());
					vertexAttribPointer("normal3d", programObject3D, "Normal", 3, boxNormBuffer);
				}				else
{
					disableVertexAttribPointer("normal3d", programObject3D, "Normal");
				}
				vertexAttribPointer("vertex3d", programObject3D, "Vertex", 3, boxBuffer);
				disableVertexAttribPointer("aColor3d", programObject3D, "aColor");
				disableVertexAttribPointer("aTexture3d", programObject3D, "aTexture");
				curContext.drawArrays(curContext.TRIANGLES, 0, boxVerts.length / 3);
				curContext.disable(curContext.POLYGON_OFFSET_FILL);
			}
			if ((lineWidth > 0) && doStroke){
				curContext.useProgram(programObject2D);
				uniformMatrix("model2d", programObject2D, "model", false, model.array());
				uniformMatrix("view2d", programObject2D, "view", false, view.array());
				uniformf("color2d", programObject2D, "color", strokeStyle);
				uniformi("picktype2d", programObject2D, "picktype", 0);
				vertexAttribPointer("vertex2d", programObject2D, "Vertex", 3, boxOutlineBuffer);
				disableVertexAttribPointer("aTextureCoord2d", programObject2D, "aTextureCoord");
				curContext.lineWidth(lineWidth);
				curContext.drawArrays(curContext.LINES, 0, boxOutlineVerts.length / 3);
			}
		});
		var initSphere = 		(function (){
			var i;
			sphereVerts = [];
			for(i = 0; i < sphereDetailU;i++){
				sphereVerts.push(0);
				sphereVerts.push(-1);
				sphereVerts.push(0);
				sphereVerts.push(sphereX[i]);
				sphereVerts.push(sphereY[i]);
				sphereVerts.push(sphereZ[i]);
			}
			sphereVerts.push(0);
			sphereVerts.push(-1);
			sphereVerts.push(0);
			sphereVerts.push(sphereX[0]);
			sphereVerts.push(sphereY[0]);
			sphereVerts.push(sphereZ[0]);
			var v1; var v11; var v2;
			var voff = 0;
			for(i = 2; i < sphereDetailV;i++){
				v1 = (v11 = voff);
				voff += sphereDetailU;
				v2 = voff;
				for(var j = 0; j < sphereDetailU;j++){
					sphereVerts.push(parseFloat(sphereX[v1]));
					sphereVerts.push(parseFloat(sphereY[v1]));
					sphereVerts.push(parseFloat(sphereZ[v1++]));
					sphereVerts.push(parseFloat(sphereX[v2]));
					sphereVerts.push(parseFloat(sphereY[v2]));
					sphereVerts.push(parseFloat(sphereZ[v2++]));
				}
				v1 = v11;
				v2 = voff;
				sphereVerts.push(parseFloat(sphereX[v1]));
				sphereVerts.push(parseFloat(sphereY[v1]));
				sphereVerts.push(parseFloat(sphereZ[v1]));
				sphereVerts.push(parseFloat(sphereX[v2]));
				sphereVerts.push(parseFloat(sphereY[v2]));
				sphereVerts.push(parseFloat(sphereZ[v2]));
			}
			for(i = 0; i < sphereDetailU;i++){
				v2 = (voff + i);
				sphereVerts.push(parseFloat(sphereX[v2]));
				sphereVerts.push(parseFloat(sphereY[v2]));
				sphereVerts.push(parseFloat(sphereZ[v2]));
				sphereVerts.push(0);
				sphereVerts.push(1);
				sphereVerts.push(0);
			}
			sphereVerts.push(parseFloat(sphereX[voff]));
			sphereVerts.push(parseFloat(sphereY[voff]));
			sphereVerts.push(parseFloat(sphereZ[voff]));
			sphereVerts.push(0);
			sphereVerts.push(1);
			sphereVerts.push(0);
			curContext.bindBuffer(curContext.ARRAY_BUFFER, sphereBuffer);
			curContext.bufferData(curContext.ARRAY_BUFFER, new Float32Array(sphereVerts), curContext.STATIC_DRAW);
		});
		p.sphereDetail = 		(function (ures, vres){
			var i;
			if (arguments.length === 1){
				ures = (vres = arguments[0]);
			}
			if (ures < 3){
				ures = 3;
			}
			if (vres < 2){
				vres = 2;
			}
			if ((ures === sphereDetailU) && (vres === sphereDetailV)){
				return ;
			}
			var delta = PConstants.SINCOS_LENGTH / ures;
			var cx = new Float32Array(ures);
			var cz = new Float32Array(ures);
			for(i = 0; i < ures;i++){
				cx[i] = cosLUT[parseInt((i * delta) % PConstants.SINCOS_LENGTH, 10)];
				cz[i] = sinLUT[parseInt((i * delta) % PConstants.SINCOS_LENGTH, 10)];
			}
			var vertCount = (ures * (vres - 1)) + 2;
			var currVert = 0;
			sphereX = new Float32Array(vertCount);
			sphereY = new Float32Array(vertCount);
			sphereZ = new Float32Array(vertCount);
			var angle_step = (PConstants.SINCOS_LENGTH * 0.5) / vres;
			var angle = angle_step;
			for(i = 1; i < vres;i++){
				var curradius = sinLUT[parseInt(angle % PConstants.SINCOS_LENGTH, 10)];
				var currY = -cosLUT[parseInt(angle % PConstants.SINCOS_LENGTH, 10)];
				for(var j = 0; j < ures;j++){
					sphereX[currVert] = (cx[j] * curradius);
					sphereY[currVert] = currY;
					sphereZ[currVert++] = (cz[j] * curradius);
				}
				angle += angle_step;
			}
			sphereDetailU = ures;
			sphereDetailV = vres;
			initSphere();
		});
		Drawing2D.prototype.sphere = DrawingShared.prototype.a3DOnlyFunction;
		Drawing3D.prototype.sphere = 		(function (){
			var sRad = arguments[0];
			if ((sphereDetailU < 3) || (sphereDetailV < 2)){
				p.sphereDetail(30);
			}
			var model = new PMatrix3D();
			model.scale(sRad, sRad, sRad);
			var view = new PMatrix3D();
			view.scale(1, -1, 1);
			view.apply(modelView.array());
			view.transpose();
			if (doFill){
				if (lightCount > 0){
					var v = new PMatrix3D();
					v.set(view);
					var m = new PMatrix3D();
					m.set(model);
					v.mult(m);
					var normalMatrix = new PMatrix3D();
					normalMatrix.set(v);
					normalMatrix.invert();
					normalMatrix.transpose();
					uniformMatrix("normalTransform3d", programObject3D, "normalTransform", false, normalMatrix.array());
					vertexAttribPointer("normal3d", programObject3D, "Normal", 3, sphereBuffer);
				}				else
{
					disableVertexAttribPointer("normal3d", programObject3D, "Normal");
				}
				curContext.useProgram(programObject3D);
				disableVertexAttribPointer("aTexture3d", programObject3D, "aTexture");
				uniformMatrix("model3d", programObject3D, "model", false, model.array());
				uniformMatrix("view3d", programObject3D, "view", false, view.array());
				vertexAttribPointer("vertex3d", programObject3D, "Vertex", 3, sphereBuffer);
				disableVertexAttribPointer("aColor3d", programObject3D, "aColor");
				curContext.enable(curContext.POLYGON_OFFSET_FILL);
				curContext.polygonOffset(1, 1);
				uniformf("color3d", programObject3D, "color", fillStyle);
				curContext.drawArrays(curContext.TRIANGLE_STRIP, 0, sphereVerts.length / 3);
				curContext.disable(curContext.POLYGON_OFFSET_FILL);
			}
			if ((lineWidth > 0) && doStroke){
				curContext.useProgram(programObject2D);
				uniformMatrix("model2d", programObject2D, "model", false, model.array());
				uniformMatrix("view2d", programObject2D, "view", false, view.array());
				vertexAttribPointer("vertex2d", programObject2D, "Vertex", 3, sphereBuffer);
				disableVertexAttribPointer("aTextureCoord2d", programObject2D, "aTextureCoord");
				uniformf("color2d", programObject2D, "color", strokeStyle);
				uniformi("picktype2d", programObject2D, "picktype", 0);
				curContext.lineWidth(lineWidth);
				curContext.drawArrays(curContext.LINE_STRIP, 0, sphereVerts.length / 3);
			}
		});
		p.modelX = 		(function (x, y, z){
			var mv = modelView.array();
			var ci = cameraInv.array();
			var ax = (((mv[0] * x) + (mv[1] * y)) + (mv[2] * z)) + mv[3];
			var ay = (((mv[4] * x) + (mv[5] * y)) + (mv[6] * z)) + mv[7];
			var az = (((mv[8] * x) + (mv[9] * y)) + (mv[10] * z)) + mv[11];
			var aw = (((mv[12] * x) + (mv[13] * y)) + (mv[14] * z)) + mv[15];
			var ox = (((ci[0] * ax) + (ci[1] * ay)) + (ci[2] * az)) + (ci[3] * aw);
			var ow = (((ci[12] * ax) + (ci[13] * ay)) + (ci[14] * az)) + (ci[15] * aw);
			return (ow !== 0) ? (ox / ow) : ox;
		});
		p.modelY = 		(function (x, y, z){
			var mv = modelView.array();
			var ci = cameraInv.array();
			var ax = (((mv[0] * x) + (mv[1] * y)) + (mv[2] * z)) + mv[3];
			var ay = (((mv[4] * x) + (mv[5] * y)) + (mv[6] * z)) + mv[7];
			var az = (((mv[8] * x) + (mv[9] * y)) + (mv[10] * z)) + mv[11];
			var aw = (((mv[12] * x) + (mv[13] * y)) + (mv[14] * z)) + mv[15];
			var oy = (((ci[4] * ax) + (ci[5] * ay)) + (ci[6] * az)) + (ci[7] * aw);
			var ow = (((ci[12] * ax) + (ci[13] * ay)) + (ci[14] * az)) + (ci[15] * aw);
			return (ow !== 0) ? (oy / ow) : oy;
		});
		p.modelZ = 		(function (x, y, z){
			var mv = modelView.array();
			var ci = cameraInv.array();
			var ax = (((mv[0] * x) + (mv[1] * y)) + (mv[2] * z)) + mv[3];
			var ay = (((mv[4] * x) + (mv[5] * y)) + (mv[6] * z)) + mv[7];
			var az = (((mv[8] * x) + (mv[9] * y)) + (mv[10] * z)) + mv[11];
			var aw = (((mv[12] * x) + (mv[13] * y)) + (mv[14] * z)) + mv[15];
			var oz = (((ci[8] * ax) + (ci[9] * ay)) + (ci[10] * az)) + (ci[11] * aw);
			var ow = (((ci[12] * ax) + (ci[13] * ay)) + (ci[14] * az)) + (ci[15] * aw);
			return (ow !== 0) ? (oz / ow) : oz;
		});
		Drawing2D.prototype.ambient = DrawingShared.prototype.a3DOnlyFunction;
		Drawing3D.prototype.ambient = 		(function (){
			var a = arguments;
			curContext.useProgram(programObject3D);
			uniformi("usingMat3d", programObject3D, "usingMat", true);
			if (a.length === 1){
				if (typeofa[0] === "string"){
					var c = a[0].slice(5, -1).split(",");
					uniformf("mat_ambient3d", programObject3D, "mat_ambient", [c[0] / 255,c[1] / 255,c[2] / 255]);
				}				else
{
					uniformf("mat_ambient3d", programObject3D, "mat_ambient", [a[0] / 255,a[0] / 255,a[0] / 255]);
				}
			}			else
{
				uniformf("mat_ambient3d", programObject3D, "mat_ambient", [a[0] / 255,a[1] / 255,a[2] / 255]);
			}
		});
		Drawing2D.prototype.emissive = DrawingShared.prototype.a3DOnlyFunction;
		Drawing3D.prototype.emissive = 		(function (){
			var a = arguments;
			curContext.useProgram(programObject3D);
			uniformi("usingMat3d", programObject3D, "usingMat", true);
			if (a.length === 1){
				if (typeofa[0] === "string"){
					var c = a[0].slice(5, -1).split(",");
					uniformf("mat_emissive3d", programObject3D, "mat_emissive", [c[0] / 255,c[1] / 255,c[2] / 255]);
				}				else
{
					uniformf("mat_emissive3d", programObject3D, "mat_emissive", [a[0] / 255,a[0] / 255,a[0] / 255]);
				}
			}			else
{
				uniformf("mat_emissive3d", programObject3D, "mat_emissive", [a[0] / 255,a[1] / 255,a[2] / 255]);
			}
		});
		Drawing2D.prototype.shininess = DrawingShared.prototype.a3DOnlyFunction;
		Drawing3D.prototype.shininess = 		(function (shine){
			curContext.useProgram(programObject3D);
			uniformi("usingMat3d", programObject3D, "usingMat", true);
			uniformf("shininess3d", programObject3D, "shininess", shine);
		});
		Drawing2D.prototype.specular = DrawingShared.prototype.a3DOnlyFunction;
		Drawing3D.prototype.specular = 		(function (){
			var c = p.color.apply(this, arguments);
			curContext.useProgram(programObject3D);
			uniformi("usingMat3d", programObject3D, "usingMat", true);
			uniformf("mat_specular3d", programObject3D, "mat_specular", p.color.toGLArray(c).slice(0, 3));
		});
		p.screenX = 		(function (x, y, z){
			var mv = modelView.array();
			if (mv.length === 16){
				var ax = (((mv[0] * x) + (mv[1] * y)) + (mv[2] * z)) + mv[3];
				var ay = (((mv[4] * x) + (mv[5] * y)) + (mv[6] * z)) + mv[7];
				var az = (((mv[8] * x) + (mv[9] * y)) + (mv[10] * z)) + mv[11];
				var aw = (((mv[12] * x) + (mv[13] * y)) + (mv[14] * z)) + mv[15];
				var pj = projection.array();
				var ox = (((pj[0] * ax) + (pj[1] * ay)) + (pj[2] * az)) + (pj[3] * aw);
				var ow = (((pj[12] * ax) + (pj[13] * ay)) + (pj[14] * az)) + (pj[15] * aw);
				if (ow !== 0){
					ox /= ow;
				}
				return (p.width * (1 + ox)) / 2;
			}			else
{
				return modelView.multX(x, y);
			}
		});
		p.screenY = 		(function screenY(x, y, z){
			var mv = modelView.array();
			if (mv.length === 16){
				var ax = (((mv[0] * x) + (mv[1] * y)) + (mv[2] * z)) + mv[3];
				var ay = (((mv[4] * x) + (mv[5] * y)) + (mv[6] * z)) + mv[7];
				var az = (((mv[8] * x) + (mv[9] * y)) + (mv[10] * z)) + mv[11];
				var aw = (((mv[12] * x) + (mv[13] * y)) + (mv[14] * z)) + mv[15];
				var pj = projection.array();
				var oy = (((pj[4] * ax) + (pj[5] * ay)) + (pj[6] * az)) + (pj[7] * aw);
				var ow = (((pj[12] * ax) + (pj[13] * ay)) + (pj[14] * az)) + (pj[15] * aw);
				if (ow !== 0){
					oy /= ow;
				}
				return (p.height * (1 + oy)) / 2;
			}			else
{
				return modelView.multY(x, y);
			}
		});
		p.screenZ = 		(function screenZ(x, y, z){
			var mv = modelView.array();
			if (mv.length !== 16){
				return 0;
			}
			var pj = projection.array();
			var ax = (((mv[0] * x) + (mv[1] * y)) + (mv[2] * z)) + mv[3];
			var ay = (((mv[4] * x) + (mv[5] * y)) + (mv[6] * z)) + mv[7];
			var az = (((mv[8] * x) + (mv[9] * y)) + (mv[10] * z)) + mv[11];
			var aw = (((mv[12] * x) + (mv[13] * y)) + (mv[14] * z)) + mv[15];
			var oz = (((pj[8] * ax) + (pj[9] * ay)) + (pj[10] * az)) + (pj[11] * aw);
			var ow = (((pj[12] * ax) + (pj[13] * ay)) + (pj[14] * az)) + (pj[15] * aw);
			if (ow !== 0){
				oz /= ow;
			}
			return (oz + 1) / 2;
		});
		DrawingShared.prototype.fill = 		(function (){
			var color = p.color(arguments[0], arguments[1], arguments[2], arguments[3]);
			if ((color === currentFillColor) && doFill){
				return ;
			}
			doFill = true;
			currentFillColor = color;
		});
		Drawing2D.prototype.fill = 		(function (){
			DrawingShared.prototype.fill.apply(this, arguments);
			isFillDirty = true;
		});
		Drawing3D.prototype.fill = 		(function (){
			DrawingShared.prototype.fill.apply(this, arguments);
			fillStyle = p.color.toGLArray(currentFillColor);
		});
				function executeContextFill(){
			if (doFill){
				if (isFillDirty){
					curContext.fillStyle = p.color.toString(currentFillColor);
					isFillDirty = false;
				}
				curContext.fill();
			}
		}
		p.noFill = 		(function (){
			doFill = false;
		});
		DrawingShared.prototype.stroke = 		(function (){
			var color = p.color(arguments[0], arguments[1], arguments[2], arguments[3]);
			if ((color === currentStrokeColor) && doStroke){
				return ;
			}
			doStroke = true;
			currentStrokeColor = color;
		});
		Drawing2D.prototype.stroke = 		(function (){
			DrawingShared.prototype.stroke.apply(this, arguments);
			isStrokeDirty = true;
		});
		Drawing3D.prototype.stroke = 		(function (){
			DrawingShared.prototype.stroke.apply(this, arguments);
			strokeStyle = p.color.toGLArray(currentStrokeColor);
		});
				function executeContextStroke(){
			if (doStroke){
				if (isStrokeDirty){
					curContext.strokeStyle = p.color.toString(currentStrokeColor);
					isStrokeDirty = false;
				}
				curContext.stroke();
			}
		}
		p.noStroke = 		(function (){
			doStroke = false;
		});
		DrawingShared.prototype.strokeWeight = 		(function (w){
			lineWidth = w;
		});
		Drawing2D.prototype.strokeWeight = 		(function (w){
			DrawingShared.prototype.strokeWeight.apply(this, arguments);
			curContext.lineWidth = w;
		});
		Drawing3D.prototype.strokeWeight = 		(function (w){
			DrawingShared.prototype.strokeWeight.apply(this, arguments);
			curContext.useProgram(programObject2D);
			uniformf("pointSize2d", programObject2D, "pointSize", w);
		});
		p.strokeCap = 		(function (value){
			drawing.$ensureContext().lineCap = value;
		});
		p.strokeJoin = 		(function (value){
			drawing.$ensureContext().lineJoin = value;
		});
		DrawingShared.prototype.smooth = 		(function (){
			curElement.style.setProperty("image-rendering", "optimizeQuality", "important");
		});
		Drawing2D.prototype.smooth = 		(function (){
			DrawingShared.prototype.smooth.apply(this, arguments);
			if ("mozImageSmoothingEnabled" in curContext){
				curContext.mozImageSmoothingEnabled = true;
			}
		});
		DrawingShared.prototype.noSmooth = 		(function (){
			curElement.style.setProperty("image-rendering", "optimizeSpeed", "important");
		});
		Drawing2D.prototype.noSmooth = 		(function (){
			DrawingShared.prototype.noSmooth.apply(this, arguments);
			if ("mozImageSmoothingEnabled" in curContext){
				curContext.mozImageSmoothingEnabled = false;
			}
		});
				function colorBlendWithAlpha(c1, c2, k){
			var f = 0 | (k * ((c2 & PConstants.ALPHA_MASK) >>> 24));
			return (((Math.min(((c1 & PConstants.ALPHA_MASK) >>> 24) + f, -1) << 24) | (p.mix(c1 & PConstants.RED_MASK, c2 & PConstants.RED_MASK, f) & PConstants.RED_MASK)) | (p.mix(c1 & PConstants.GREEN_MASK, c2 & PConstants.GREEN_MASK, f) & PConstants.GREEN_MASK)) | p.mix(c1 & PConstants.BLUE_MASK, c2 & PConstants.BLUE_MASK, f);
		}
		Drawing2D.prototype.point = 		(function (x, y){
			if (doStroke){
				if (curSketch.options.crispLines){
					var alphaOfPointWeight = Math.PI / 4;
					var c = p.get(x, y);
					p.set(x, y, colorBlendWithAlpha(c, currentStrokeColor, alphaOfPointWeight));
				}				else
{
					if (lineWidth > 1){
						curContext.fillStyle = p.color.toString(currentStrokeColor);
						isFillDirty = true;
						curContext.beginPath();
						curContext.arc(x, y, lineWidth / 2, 0, PConstants.TWO_PI, false);
						curContext.fill();
						curContext.closePath();
					}					else
{
						curContext.fillStyle = p.color.toString(currentStrokeColor);
						curContext.fillRect(Math.round(x), Math.round(y), 1, 1);
						isFillDirty = true;
					}
				}
			}
		});
		Drawing3D.prototype.point = 		(function (x, y, z){
			var model = new PMatrix3D();
			model.translate(x, y, z || 0);
			model.transpose();
			var view = new PMatrix3D();
			view.scale(1, -1, 1);
			view.apply(modelView.array());
			view.transpose();
			curContext.useProgram(programObject2D);
			uniformMatrix("model2d", programObject2D, "model", false, model.array());
			uniformMatrix("view2d", programObject2D, "view", false, view.array());
			if ((lineWidth > 0) && doStroke){
				uniformf("color2d", programObject2D, "color", strokeStyle);
				uniformi("picktype2d", programObject2D, "picktype", 0);
				vertexAttribPointer("vertex2d", programObject2D, "Vertex", 3, pointBuffer);
				disableVertexAttribPointer("aTextureCoord2d", programObject2D, "aTextureCoord");
				curContext.drawArrays(curContext.POINTS, 0, 1);
			}
		});
		p.beginShape = 		(function (type){
			curShape = type;
			curvePoints = [];
			vertArray = [];
		});
		DrawingShared.prototype.vertex = 		(function (){
			var vert = [];
			if (firstVert){
				firstVert = false;
			}
			if (arguments.length === 4){
				vert[0] = arguments[0];
				vert[1] = arguments[1];
				vert[2] = 0;
				vert[3] = arguments[2];
				vert[4] = arguments[3];
			}			else
{
				vert[0] = arguments[0];
				vert[1] = arguments[1];
				vert[2] = (arguments[2] || 0);
				vert[3] = (arguments[3] || 0);
				vert[4] = (arguments[4] || 0);
			}
			vert["isVert"] = true;
			return vert;
		});
		Drawing2D.prototype.vertex = 		(function (){
			var vert = DrawingShared.prototype.vertex.apply(this, arguments);
			vert[5] = currentFillColor;
			vert[6] = currentStrokeColor;
			vertArray.push(vert);
		});
		Drawing3D.prototype.vertex = 		(function (){
			var vert = DrawingShared.prototype.vertex.apply(this, arguments);
			vert[5] = fillStyle[0];
			vert[6] = fillStyle[1];
			vert[7] = fillStyle[2];
			vert[8] = fillStyle[3];
			vert[9] = strokeStyle[0];
			vert[10] = strokeStyle[1];
			vert[11] = strokeStyle[2];
			vert[12] = strokeStyle[3];
			vert[13] = normalX;
			vert[14] = normalY;
			vert[15] = normalZ;
			vertArray.push(vert);
		});
		var point3D = 		(function (vArray, cArray){
			var view = new PMatrix3D();
			view.scale(1, -1, 1);
			view.apply(modelView.array());
			view.transpose();
			curContext.useProgram(programObjectUnlitShape);
			uniformMatrix("uViewUS", programObjectUnlitShape, "uView", false, view.array());
			vertexAttribPointer("aVertexUS", programObjectUnlitShape, "aVertex", 3, pointBuffer);
			curContext.bufferData(curContext.ARRAY_BUFFER, new Float32Array(vArray), curContext.STREAM_DRAW);
			vertexAttribPointer("aColorUS", programObjectUnlitShape, "aColor", 4, fillColorBuffer);
			curContext.bufferData(curContext.ARRAY_BUFFER, new Float32Array(cArray), curContext.STREAM_DRAW);
			curContext.drawArrays(curContext.POINTS, 0, vArray.length / 3);
		});
		var line3D = 		(function (vArray, mode, cArray){
			var ctxMode;
			if (mode === "LINES"){
				ctxMode = curContext.LINES;
			}			else
{
				if (mode === "LINE_LOOP"){
					ctxMode = curContext.LINE_LOOP;
				}				else
{
					ctxMode = curContext.LINE_STRIP;
				}
			}
			var view = new PMatrix3D();
			view.scale(1, -1, 1);
			view.apply(modelView.array());
			view.transpose();
			curContext.useProgram(programObjectUnlitShape);
			uniformMatrix("uViewUS", programObjectUnlitShape, "uView", false, view.array());
			vertexAttribPointer("aVertexUS", programObjectUnlitShape, "aVertex", 3, lineBuffer);
			curContext.bufferData(curContext.ARRAY_BUFFER, new Float32Array(vArray), curContext.STREAM_DRAW);
			vertexAttribPointer("aColorUS", programObjectUnlitShape, "aColor", 4, strokeColorBuffer);
			curContext.bufferData(curContext.ARRAY_BUFFER, new Float32Array(cArray), curContext.STREAM_DRAW);
			curContext.lineWidth(lineWidth);
			curContext.drawArrays(ctxMode, 0, vArray.length / 3);
		});
		var fill3D = 		(function (vArray, mode, cArray, tArray){
			var ctxMode;
			if (mode === "TRIANGLES"){
				ctxMode = curContext.TRIANGLES;
			}			else
{
				if (mode === "TRIANGLE_FAN"){
					ctxMode = curContext.TRIANGLE_FAN;
				}				else
{
					ctxMode = curContext.TRIANGLE_STRIP;
				}
			}
			var view = new PMatrix3D();
			view.scale(1, -1, 1);
			view.apply(modelView.array());
			view.transpose();
			curContext.useProgram(programObject3D);
			uniformMatrix("model3d", programObject3D, "model", false, [1,0,0,0,0,1,0,0,0,0,1,0,0,0,0,1]);
			uniformMatrix("view3d", programObject3D, "view", false, view.array());
			curContext.enable(curContext.POLYGON_OFFSET_FILL);
			curContext.polygonOffset(1, 1);
			uniformf("color3d", programObject3D, "color", [-1,0,0,0]);
			vertexAttribPointer("vertex3d", programObject3D, "Vertex", 3, fillBuffer);
			curContext.bufferData(curContext.ARRAY_BUFFER, new Float32Array(vArray), curContext.STREAM_DRAW);
			vertexAttribPointer("aColor3d", programObject3D, "aColor", 4, fillColorBuffer);
			curContext.bufferData(curContext.ARRAY_BUFFER, new Float32Array(cArray), curContext.STREAM_DRAW);
			disableVertexAttribPointer("normal3d", programObject3D, "Normal");
			var i;
			if (usingTexture){
				if (curTextureMode === PConstants.IMAGE){
					for(i = 0; i < tArray.length;i += 2){
						tArray[i] = (tArray[i] / curTexture.width);
						tArray[i + 1] /= curTexture.height;
					}
				}
				for(i = 0; i < tArray.length;i += 2){
					if (tArray[i + 0] > 1){
						tArray[i + 0] -= (tArray[i + 0] - 1);
					}
					if (tArray[i + 1] > 1){
						tArray[i + 1] -= (tArray[i + 1] - 1);
					}
				}
				uniformi("usingTexture3d", programObject3D, "usingTexture", usingTexture);
				vertexAttribPointer("aTexture3d", programObject3D, "aTexture", 2, shapeTexVBO);
				curContext.bufferData(curContext.ARRAY_BUFFER, new Float32Array(tArray), curContext.STREAM_DRAW);
			}
			curContext.drawArrays(ctxMode, 0, vArray.length / 3);
			curContext.disable(curContext.POLYGON_OFFSET_FILL);
		});
		Drawing2D.prototype.endShape = 		(function (mode){
			if (vertArray.length === 0){
				return ;
			}
			var closeShape = mode === PConstants.CLOSE;
			var lineVertArray = [];
			var fillVertArray = [];
			var colorVertArray = [];
			var strokeVertArray = [];
			var texVertArray = [];
			var cachedVertArray;
			firstVert = true;
			var i; var j; var k;
			var vertArrayLength = vertArray.length;
			for(i = 0; i < vertArrayLength;i++){
				cachedVertArray = vertArray[i];
				for(j = 0; j < 3;j++){
					fillVertArray.push(cachedVertArray[j]);
				}
			}
			for(i = 0; i < vertArrayLength;i++){
				cachedVertArray = vertArray[i];
				for(j = 5; j < 9;j++){
					colorVertArray.push(cachedVertArray[j]);
				}
			}
			for(i = 0; i < vertArrayLength;i++){
				cachedVertArray = vertArray[i];
				for(j = 9; j < 13;j++){
					strokeVertArray.push(cachedVertArray[j]);
				}
			}
			for(i = 0; i < vertArrayLength;i++){
				cachedVertArray = vertArray[i];
				texVertArray.push(cachedVertArray[3]);
				texVertArray.push(cachedVertArray[4]);
			}
			if (closeShape){
				fillVertArray.push(vertArray[0][0]);
				fillVertArray.push(vertArray[0][1]);
				fillVertArray.push(vertArray[0][2]);
				for(i = 5; i < 9;i++){
					colorVertArray.push(vertArray[0][i]);
				}
				for(i = 9; i < 13;i++){
					strokeVertArray.push(vertArray[0][i]);
				}
				texVertArray.push(vertArray[0][3]);
				texVertArray.push(vertArray[0][4]);
			}
			if (isCurve && ((curShape === PConstants.POLYGON) || (curShape === undef))){
				if (vertArrayLength > 3){
					var b = []; var s = 1 - curTightness;
					curContext.beginPath();
					curContext.moveTo(vertArray[1][0], vertArray[1][1]);
					for(i = 1; (i + 2) < vertArrayLength;i++){
						cachedVertArray = vertArray[i];
						b[0] = [cachedVertArray[0],cachedVertArray[1]];
						b[1] = [cachedVertArray[0] + (((s * vertArray[i + 1][0]) - (s * vertArray[i - 1][0])) / 6),cachedVertArray[1] + (((s * vertArray[i + 1][1]) - (s * vertArray[i - 1][1])) / 6)];
						b[2] = [vertArray[i + 1][0] + (((s * vertArray[i][0]) - (s * vertArray[i + 2][0])) / 6),vertArray[i + 1][1] + (((s * vertArray[i][1]) - (s * vertArray[i + 2][1])) / 6)];
						b[3] = [vertArray[i + 1][0],vertArray[i + 1][1]];
						curContext.bezierCurveTo(b[1][0], b[1][1], b[2][0], b[2][1], b[3][0], b[3][1]);
					}
					if (closeShape){
						curContext.lineTo(vertArray[0][0], vertArray[0][1]);
					}
					executeContextFill();
					executeContextStroke();
					curContext.closePath();
				}
			}			else
{
				if (isBezier && ((curShape === PConstants.POLYGON) || (curShape === undef))){
					curContext.beginPath();
					for(i = 0; i < vertArrayLength;i++){
						cachedVertArray = vertArray[i];
						if (vertArray[i]["isVert"]){
							if (vertArray[i]["moveTo"]){
								curContext.moveTo(cachedVertArray[0], cachedVertArray[1]);
							}							else
{
								curContext.lineTo(cachedVertArray[0], cachedVertArray[1]);
							}
						}						else
{
							curContext.bezierCurveTo(vertArray[i][0], vertArray[i][1], vertArray[i][2], vertArray[i][3], vertArray[i][4], vertArray[i][5]);
						}
					}
					if (closeShape){
						curContext.lineTo(vertArray[0][0], vertArray[0][1]);
					}
					executeContextFill();
					executeContextStroke();
					curContext.closePath();
				}				else
{
					if (curShape === PConstants.POINTS){
						for(i = 0; i < vertArrayLength;i++){
							cachedVertArray = vertArray[i];
							if (doStroke){
								p.stroke(cachedVertArray[6]);
							}
							p.point(cachedVertArray[0], cachedVertArray[1]);
						}
					}					else
{
						if (curShape === PConstants.LINES){
							for(i = 0; (i + 1) < vertArrayLength;i += 2){
								cachedVertArray = vertArray[i];
								if (doStroke){
									p.stroke(vertArray[i + 1][6]);
								}
								p.line(cachedVertArray[0], cachedVertArray[1], vertArray[i + 1][0], vertArray[i + 1][1]);
							}
						}						else
{
							if (curShape === PConstants.TRIANGLES){
								for(i = 0; (i + 2) < vertArrayLength;i += 3){
									cachedVertArray = vertArray[i];
									curContext.beginPath();
									curContext.moveTo(cachedVertArray[0], cachedVertArray[1]);
									curContext.lineTo(vertArray[i + 1][0], vertArray[i + 1][1]);
									curContext.lineTo(vertArray[i + 2][0], vertArray[i + 2][1]);
									curContext.lineTo(cachedVertArray[0], cachedVertArray[1]);
									if (doFill){
										p.fill(vertArray[i + 2][5]);
										executeContextFill();
									}
									if (doStroke){
										p.stroke(vertArray[i + 2][6]);
										executeContextStroke();
									}
									curContext.closePath();
								}
							}							else
{
								if (curShape === PConstants.TRIANGLE_STRIP){
									for(i = 0; (i + 1) < vertArrayLength;i++){
										cachedVertArray = vertArray[i];
										curContext.beginPath();
										curContext.moveTo(vertArray[i + 1][0], vertArray[i + 1][1]);
										curContext.lineTo(cachedVertArray[0], cachedVertArray[1]);
										if (doStroke){
											p.stroke(vertArray[i + 1][6]);
										}
										if (doFill){
											p.fill(vertArray[i + 1][5]);
										}
										if ((i + 2) < vertArrayLength){
											curContext.lineTo(vertArray[i + 2][0], vertArray[i + 2][1]);
											if (doStroke){
												p.stroke(vertArray[i + 2][6]);
											}
											if (doFill){
												p.fill(vertArray[i + 2][5]);
											}
										}
										executeContextFill();
										executeContextStroke();
										curContext.closePath();
									}
								}								else
{
									if (curShape === PConstants.TRIANGLE_FAN){
										if (vertArrayLength > 2){
											curContext.beginPath();
											curContext.moveTo(vertArray[0][0], vertArray[0][1]);
											curContext.lineTo(vertArray[1][0], vertArray[1][1]);
											curContext.lineTo(vertArray[2][0], vertArray[2][1]);
											if (doFill){
												p.fill(vertArray[2][5]);
												executeContextFill();
											}
											if (doStroke){
												p.stroke(vertArray[2][6]);
												executeContextStroke();
											}
											curContext.closePath();
											for(i = 3; i < vertArrayLength;i++){
												cachedVertArray = vertArray[i];
												curContext.beginPath();
												curContext.moveTo(vertArray[0][0], vertArray[0][1]);
												curContext.lineTo(vertArray[i - 1][0], vertArray[i - 1][1]);
												curContext.lineTo(cachedVertArray[0], cachedVertArray[1]);
												if (doFill){
													p.fill(cachedVertArray[5]);
													executeContextFill();
												}
												if (doStroke){
													p.stroke(cachedVertArray[6]);
													executeContextStroke();
												}
												curContext.closePath();
											}
										}
									}									else
{
										if (curShape === PConstants.QUADS){
											for(i = 0; (i + 3) < vertArrayLength;i += 4){
												cachedVertArray = vertArray[i];
												curContext.beginPath();
												curContext.moveTo(cachedVertArray[0], cachedVertArray[1]);
												for(j = 1; j < 4;j++){
													curContext.lineTo(vertArray[i + j][0], vertArray[i + j][1]);
												}
												curContext.lineTo(cachedVertArray[0], cachedVertArray[1]);
												if (doFill){
													p.fill(vertArray[i + 3][5]);
													executeContextFill();
												}
												if (doStroke){
													p.stroke(vertArray[i + 3][6]);
													executeContextStroke();
												}
												curContext.closePath();
											}
										}										else
{
											if (curShape === PConstants.QUAD_STRIP){
												if (vertArrayLength > 3){
													for(i = 0; (i + 1) < vertArrayLength;i += 2){
														cachedVertArray = vertArray[i];
														curContext.beginPath();
														if ((i + 3) < vertArrayLength){
															curContext.moveTo(vertArray[i + 2][0], vertArray[i + 2][1]);
															curContext.lineTo(cachedVertArray[0], cachedVertArray[1]);
															curContext.lineTo(vertArray[i + 1][0], vertArray[i + 1][1]);
															curContext.lineTo(vertArray[i + 3][0], vertArray[i + 3][1]);
															if (doFill){
																p.fill(vertArray[i + 3][5]);
															}
															if (doStroke){
																p.stroke(vertArray[i + 3][6]);
															}
														}														else
{
															curContext.moveTo(cachedVertArray[0], cachedVertArray[1]);
															curContext.lineTo(vertArray[i + 1][0], vertArray[i + 1][1]);
														}
														executeContextFill();
														executeContextStroke();
														curContext.closePath();
													}
												}
											}											else
{
												curContext.beginPath();
												curContext.moveTo(vertArray[0][0], vertArray[0][1]);
												for(i = 1; i < vertArrayLength;i++){
													cachedVertArray = vertArray[i];
													if (cachedVertArray["isVert"]){
														if (cachedVertArray["moveTo"]){
															curContext.moveTo(cachedVertArray[0], cachedVertArray[1]);
														}														else
{
															curContext.lineTo(cachedVertArray[0], cachedVertArray[1]);
														}
													}
												}
												if (closeShape){
													curContext.lineTo(vertArray[0][0], vertArray[0][1]);
												}
												executeContextFill();
												executeContextStroke();
												curContext.closePath();
											}
										}
									}
								}
							}
						}
					}
				}
			}
			isCurve = false;
			isBezier = false;
			curveVertArray = [];
			curveVertCount = 0;
		});
		Drawing3D.prototype.endShape = 		(function (mode){
			if (vertArray.length === 0){
				return ;
			}
			var closeShape = mode === PConstants.CLOSE;
			var lineVertArray = [];
			var fillVertArray = [];
			var colorVertArray = [];
			var strokeVertArray = [];
			var texVertArray = [];
			var cachedVertArray;
			firstVert = true;
			var i; var j; var k;
			var vertArrayLength = vertArray.length;
			for(i = 0; i < vertArrayLength;i++){
				cachedVertArray = vertArray[i];
				for(j = 0; j < 3;j++){
					fillVertArray.push(cachedVertArray[j]);
				}
			}
			for(i = 0; i < vertArrayLength;i++){
				cachedVertArray = vertArray[i];
				for(j = 5; j < 9;j++){
					colorVertArray.push(cachedVertArray[j]);
				}
			}
			for(i = 0; i < vertArrayLength;i++){
				cachedVertArray = vertArray[i];
				for(j = 9; j < 13;j++){
					strokeVertArray.push(cachedVertArray[j]);
				}
			}
			for(i = 0; i < vertArrayLength;i++){
				cachedVertArray = vertArray[i];
				texVertArray.push(cachedVertArray[3]);
				texVertArray.push(cachedVertArray[4]);
			}
			if (closeShape){
				fillVertArray.push(vertArray[0][0]);
				fillVertArray.push(vertArray[0][1]);
				fillVertArray.push(vertArray[0][2]);
				for(i = 5; i < 9;i++){
					colorVertArray.push(vertArray[0][i]);
				}
				for(i = 9; i < 13;i++){
					strokeVertArray.push(vertArray[0][i]);
				}
				texVertArray.push(vertArray[0][3]);
				texVertArray.push(vertArray[0][4]);
			}
			if (isCurve && ((curShape === PConstants.POLYGON) || (curShape === undef))){
				lineVertArray = fillVertArray;
				if (doStroke){
					line3D(lineVertArray, null, strokeVertArray);
				}
				if (doFill){
					fill3D(fillVertArray, null, colorVertArray);
				}
			}			else
{
				if (isBezier && ((curShape === PConstants.POLYGON) || (curShape === undef))){
					lineVertArray = fillVertArray;
					lineVertArray.splice(lineVertArray.length - 3);
					strokeVertArray.splice(strokeVertArray.length - 4);
					if (doStroke){
						line3D(lineVertArray, null, strokeVertArray);
					}
					if (doFill){
						fill3D(fillVertArray, "TRIANGLES", colorVertArray);
					}
				}				else
{
					if (curShape === PConstants.POINTS){
						for(i = 0; i < vertArrayLength;i++){
							cachedVertArray = vertArray[i];
							for(j = 0; j < 3;j++){
								lineVertArray.push(cachedVertArray[j]);
							}
						}
						point3D(lineVertArray, strokeVertArray);
					}					else
{
						if (curShape === PConstants.LINES){
							for(i = 0; i < vertArrayLength;i++){
								cachedVertArray = vertArray[i];
								for(j = 0; j < 3;j++){
									lineVertArray.push(cachedVertArray[j]);
								}
							}
							for(i = 0; i < vertArrayLength;i++){
								cachedVertArray = vertArray[i];
								for(j = 5; j < 9;j++){
									colorVertArray.push(cachedVertArray[j]);
								}
							}
							line3D(lineVertArray, "LINES", strokeVertArray);
						}						else
{
							if (curShape === PConstants.TRIANGLES){
								if (vertArrayLength > 2){
									for(i = 0; (i + 2) < vertArrayLength;i += 3){
										fillVertArray = [];
										texVertArray = [];
										lineVertArray = [];
										colorVertArray = [];
										strokeVertArray = [];
										for(j = 0; j < 3;j++){
											for(k = 0; k < 3;k++){
												lineVertArray.push(vertArray[i + j][k]);
												fillVertArray.push(vertArray[i + j][k]);
											}
										}
										for(j = 0; j < 3;j++){
											for(k = 3; k < 5;k++){
												texVertArray.push(vertArray[i + j][k]);
											}
										}
										for(j = 0; j < 3;j++){
											for(k = 5; k < 9;k++){
												colorVertArray.push(vertArray[i + j][k]);
												strokeVertArray.push(vertArray[i + j][k + 4]);
											}
										}
										if (doStroke){
											line3D(lineVertArray, "LINE_LOOP", strokeVertArray);
										}
										if (doFill || usingTexture){
											fill3D(fillVertArray, "TRIANGLES", colorVertArray, texVertArray);
										}
									}
								}
							}							else
{
								if (curShape === PConstants.TRIANGLE_STRIP){
									if (vertArrayLength > 2){
										for(i = 0; (i + 2) < vertArrayLength;i++){
											lineVertArray = [];
											fillVertArray = [];
											strokeVertArray = [];
											colorVertArray = [];
											texVertArray = [];
											for(j = 0; j < 3;j++){
												for(k = 0; k < 3;k++){
													lineVertArray.push(vertArray[i + j][k]);
													fillVertArray.push(vertArray[i + j][k]);
												}
											}
											for(j = 0; j < 3;j++){
												for(k = 3; k < 5;k++){
													texVertArray.push(vertArray[i + j][k]);
												}
											}
											for(j = 0; j < 3;j++){
												for(k = 5; k < 9;k++){
													strokeVertArray.push(vertArray[i + j][k + 4]);
													colorVertArray.push(vertArray[i + j][k]);
												}
											}
											if (doFill || usingTexture){
												fill3D(fillVertArray, "TRIANGLE_STRIP", colorVertArray, texVertArray);
											}
											if (doStroke){
												line3D(lineVertArray, "LINE_LOOP", strokeVertArray);
											}
										}
									}
								}								else
{
									if (curShape === PConstants.TRIANGLE_FAN){
										if (vertArrayLength > 2){
											for(i = 0; i < 3;i++){
												cachedVertArray = vertArray[i];
												for(j = 0; j < 3;j++){
													lineVertArray.push(cachedVertArray[j]);
												}
											}
											for(i = 0; i < 3;i++){
												cachedVertArray = vertArray[i];
												for(j = 9; j < 13;j++){
													strokeVertArray.push(cachedVertArray[j]);
												}
											}
											if (doStroke){
												line3D(lineVertArray, "LINE_LOOP", strokeVertArray);
											}
											for(i = 2; (i + 1) < vertArrayLength;i++){
												lineVertArray = [];
												strokeVertArray = [];
												lineVertArray.push(vertArray[0][0]);
												lineVertArray.push(vertArray[0][1]);
												lineVertArray.push(vertArray[0][2]);
												strokeVertArray.push(vertArray[0][9]);
												strokeVertArray.push(vertArray[0][10]);
												strokeVertArray.push(vertArray[0][11]);
												strokeVertArray.push(vertArray[0][12]);
												for(j = 0; j < 2;j++){
													for(k = 0; k < 3;k++){
														lineVertArray.push(vertArray[i + j][k]);
													}
												}
												for(j = 0; j < 2;j++){
													for(k = 9; k < 13;k++){
														strokeVertArray.push(vertArray[i + j][k]);
													}
												}
												if (doStroke){
													line3D(lineVertArray, "LINE_STRIP", strokeVertArray);
												}
											}
											if (doFill || usingTexture){
												fill3D(fillVertArray, "TRIANGLE_FAN", colorVertArray, texVertArray);
											}
										}
									}									else
{
										if (curShape === PConstants.QUADS){
											for(i = 0; (i + 3) < vertArrayLength;i += 4){
												lineVertArray = [];
												for(j = 0; j < 4;j++){
													cachedVertArray = vertArray[i + j];
													for(k = 0; k < 3;k++){
														lineVertArray.push(cachedVertArray[k]);
													}
												}
												if (doStroke){
													line3D(lineVertArray, "LINE_LOOP", strokeVertArray);
												}
												if (doFill){
													fillVertArray = [];
													colorVertArray = [];
													texVertArray = [];
													for(j = 0; j < 3;j++){
														fillVertArray.push(vertArray[i][j]);
													}
													for(j = 5; j < 9;j++){
														colorVertArray.push(vertArray[i][j]);
													}
													for(j = 0; j < 3;j++){
														fillVertArray.push(vertArray[i + 1][j]);
													}
													for(j = 5; j < 9;j++){
														colorVertArray.push(vertArray[i + 1][j]);
													}
													for(j = 0; j < 3;j++){
														fillVertArray.push(vertArray[i + 3][j]);
													}
													for(j = 5; j < 9;j++){
														colorVertArray.push(vertArray[i + 3][j]);
													}
													for(j = 0; j < 3;j++){
														fillVertArray.push(vertArray[i + 2][j]);
													}
													for(j = 5; j < 9;j++){
														colorVertArray.push(vertArray[i + 2][j]);
													}
													if (usingTexture){
														texVertArray.push(vertArray[i + 0][3]);
														texVertArray.push(vertArray[i + 0][4]);
														texVertArray.push(vertArray[i + 1][3]);
														texVertArray.push(vertArray[i + 1][4]);
														texVertArray.push(vertArray[i + 3][3]);
														texVertArray.push(vertArray[i + 3][4]);
														texVertArray.push(vertArray[i + 2][3]);
														texVertArray.push(vertArray[i + 2][4]);
													}
													fill3D(fillVertArray, "TRIANGLE_STRIP", colorVertArray, texVertArray);
												}
											}
										}										else
{
											if (curShape === PConstants.QUAD_STRIP){
												var tempArray = [];
												if (vertArrayLength > 3){
													for(i = 0; i < 2;i++){
														cachedVertArray = vertArray[i];
														for(j = 0; j < 3;j++){
															lineVertArray.push(cachedVertArray[j]);
														}
													}
													for(i = 0; i < 2;i++){
														cachedVertArray = vertArray[i];
														for(j = 9; j < 13;j++){
															strokeVertArray.push(cachedVertArray[j]);
														}
													}
													line3D(lineVertArray, "LINE_STRIP", strokeVertArray);
													if ((vertArrayLength > 4) && ((vertArrayLength % 2) > 0)){
														tempArray = fillVertArray.splice(fillVertArray.length - 3);
														vertArray.pop();
													}
													for(i = 0; (i + 3) < vertArrayLength;i += 2){
														lineVertArray = [];
														strokeVertArray = [];
														for(j = 0; j < 3;j++){
															lineVertArray.push(vertArray[i + 1][j]);
														}
														for(j = 0; j < 3;j++){
															lineVertArray.push(vertArray[i + 3][j]);
														}
														for(j = 0; j < 3;j++){
															lineVertArray.push(vertArray[i + 2][j]);
														}
														for(j = 0; j < 3;j++){
															lineVertArray.push(vertArray[i + 0][j]);
														}
														for(j = 9; j < 13;j++){
															strokeVertArray.push(vertArray[i + 1][j]);
														}
														for(j = 9; j < 13;j++){
															strokeVertArray.push(vertArray[i + 3][j]);
														}
														for(j = 9; j < 13;j++){
															strokeVertArray.push(vertArray[i + 2][j]);
														}
														for(j = 9; j < 13;j++){
															strokeVertArray.push(vertArray[i + 0][j]);
														}
														if (doStroke){
															line3D(lineVertArray, "LINE_STRIP", strokeVertArray);
														}
													}
													if (doFill || usingTexture){
														fill3D(fillVertArray, "TRIANGLE_LIST", colorVertArray, texVertArray);
													}
												}
											}											else
{
												if (vertArrayLength === 1){
													for(j = 0; j < 3;j++){
														lineVertArray.push(vertArray[0][j]);
													}
													for(j = 9; j < 13;j++){
														strokeVertArray.push(vertArray[0][j]);
													}
													point3D(lineVertArray, strokeVertArray);
												}												else
{
													for(i = 0; i < vertArrayLength;i++){
														cachedVertArray = vertArray[i];
														for(j = 0; j < 3;j++){
															lineVertArray.push(cachedVertArray[j]);
														}
														for(j = 5; j < 9;j++){
															strokeVertArray.push(cachedVertArray[j]);
														}
													}
													if (doStroke && closeShape){
														line3D(lineVertArray, "LINE_LOOP", strokeVertArray);
													}													else
{
														if (doStroke && !closeShape){
															line3D(lineVertArray, "LINE_STRIP", strokeVertArray);
														}
													}
													if (doFill || usingTexture){
														fill3D(fillVertArray, "TRIANGLE_FAN", colorVertArray, texVertArray);
													}
												}
											}
										}
									}
								}
							}
						}
					}
					usingTexture = false;
					curContext.useProgram(programObject3D);
					uniformi("usingTexture3d", programObject3D, "usingTexture", usingTexture);
				}
			}
			isCurve = false;
			isBezier = false;
			curveVertArray = [];
			curveVertCount = 0;
		});
		var splineForward = 		(function (segments, matrix){
			var f = 1 / segments;
			var ff = f * f;
			var fff = ff * f;
			matrix.set(0, 0, 0, 1, fff, ff, f, 0, 6 * fff, 2 * ff, 0, 0, 6 * fff, 0, 0, 0);
		});
		var curveInit = 		(function (){
			if (!curveDrawMatrix){
				curveBasisMatrix = new PMatrix3D();
				curveDrawMatrix = new PMatrix3D();
				curveInited = true;
			}
			var s = curTightness;
			curveBasisMatrix.set((s - 1) / 2, (s + 3) / 2, (-3 - s) / 2, (1 - s) / 2, 1 - s, (-5 - s) / 2, s + 2, (s - 1) / 2, (s - 1) / 2, 0, (1 - s) / 2, 0, 0, 1, 0, 0);
			splineForward(curveDet, curveDrawMatrix);
			if (!bezierBasisInverse){
				curveToBezierMatrix = new PMatrix3D();
			}
			curveToBezierMatrix.set(curveBasisMatrix);
			curveToBezierMatrix.preApply(bezierBasisInverse);
			curveDrawMatrix.apply(curveBasisMatrix);
		});
		Drawing2D.prototype.bezierVertex = 		(function (){
			isBezier = true;
			var vert = [];
			if (firstVert){
				throw "vertex() must be used at least once before calling bezierVertex()";
			}
			for(var i = 0; i < arguments.length;i++){
				vert[i] = arguments[i];
			}
			vertArray.push(vert);
			vertArray[vertArray.length - 1]["isVert"] = false;
		});
		Drawing3D.prototype.bezierVertex = 		(function (){
			isBezier = true;
			var vert = [];
			if (firstVert){
				throw "vertex() must be used at least once before calling bezierVertex()";
			}
			if (arguments.length === 9){
				if (bezierDrawMatrix === undef){
					bezierDrawMatrix = new PMatrix3D();
				}
				var lastPoint = vertArray.length - 1;
				splineForward(bezDetail, bezierDrawMatrix);
				bezierDrawMatrix.apply(bezierBasisMatrix);
				var draw = bezierDrawMatrix.array();
				var x1 = vertArray[lastPoint][0]; var y1 = vertArray[lastPoint][1]; var z1 = vertArray[lastPoint][2];
				var xplot1 = (((draw[4] * x1) + (draw[5] * arguments[0])) + (draw[6] * arguments[3])) + (draw[7] * arguments[6]);
				var xplot2 = (((draw[8] * x1) + (draw[9] * arguments[0])) + (draw[10] * arguments[3])) + (draw[11] * arguments[6]);
				var xplot3 = (((draw[12] * x1) + (draw[13] * arguments[0])) + (draw[14] * arguments[3])) + (draw[15] * arguments[6]);
				var yplot1 = (((draw[4] * y1) + (draw[5] * arguments[1])) + (draw[6] * arguments[4])) + (draw[7] * arguments[7]);
				var yplot2 = (((draw[8] * y1) + (draw[9] * arguments[1])) + (draw[10] * arguments[4])) + (draw[11] * arguments[7]);
				var yplot3 = (((draw[12] * y1) + (draw[13] * arguments[1])) + (draw[14] * arguments[4])) + (draw[15] * arguments[7]);
				var zplot1 = (((draw[4] * z1) + (draw[5] * arguments[2])) + (draw[6] * arguments[5])) + (draw[7] * arguments[8]);
				var zplot2 = (((draw[8] * z1) + (draw[9] * arguments[2])) + (draw[10] * arguments[5])) + (draw[11] * arguments[8]);
				var zplot3 = (((draw[12] * z1) + (draw[13] * arguments[2])) + (draw[14] * arguments[5])) + (draw[15] * arguments[8]);
				for(var j = 0; j < bezDetail;j++){
					x1 += xplot1;
					xplot1 += xplot2;
					xplot2 += xplot3;
					y1 += yplot1;
					yplot1 += yplot2;
					yplot2 += yplot3;
					z1 += zplot1;
					zplot1 += zplot2;
					zplot2 += zplot3;
					p.vertex(x1, y1, z1);
				}
				p.vertex(arguments[6], arguments[7], arguments[8]);
			}
		});
		var executeTexImage2D = 		(function (){
			var canvas2d = document.createElement('canvas');
			try{
				curContext.texImage2D(curContext.TEXTURE_2D, 0, curContext.RGBA, curContext.RGBA, curContext.UNSIGNED_BYTE, canvas2d);
				executeTexImage2D = 				(function (texture){
					curContext.texImage2D(curContext.TEXTURE_2D, 0, curContext.RGBA, curContext.RGBA, curContext.UNSIGNED_BYTE, texture);
				});
			}catch( e ){
				executeTexImage2D = 				(function (texture){
					curContext.texImage2D(curContext.TEXTURE_2D, 0, texture, false);
				});
			}
			executeTexImage2D.apply(this, arguments);
		});
		p.texture = 		(function (pimage){
			var curContext = drawing.$ensureContext();
			if (pimage.localName === "canvas"){
				curContext.bindTexture(curContext.TEXTURE_2D, canTex);
				executeTexImage2D(pimage);
				curContext.texParameteri(curContext.TEXTURE_2D, curContext.TEXTURE_MAG_FILTER, curContext.LINEAR);
				curContext.texParameteri(curContext.TEXTURE_2D, curContext.TEXTURE_MIN_FILTER, curContext.LINEAR);
				curContext.generateMipmap(curContext.TEXTURE_2D);
			}			else
{
				if (!pimage.__texture){
					var texture = curContext.createTexture();
					pimage.__texture = texture;
					var cvs = document.createElement('canvas');
					var pot;
					if (pimage.width & ((pimage.width - 1) === 0)){
						cvs.width = pimage.width;
					}					else
{
						pot = 1;
						while(pot < pimage.width){
							pot *= 2;
						}
						cvs.width = pot;
					}
					if (pimage.height & ((pimage.height - 1) === 0)){
						cvs.height = pimage.height;
					}					else
{
						pot = 1;
						while(pot < pimage.height){
							pot *= 2;
						}
						cvs.height = pot;
					}
					var ctx = cvs.getContext('2d');
					var textureImage = ctx.createImageData(cvs.width, cvs.height);
					var imgData = pimage.toImageData();
					for(var i = 0; i < cvs.width;i += 1){
						for(var j = 0; j < cvs.height;j += 1){
							var index = ((j * cvs.width) + i) * 4;
							textureImage.data[index + 0] = imgData.data[index + 0];
							textureImage.data[index + 1] = imgData.data[index + 1];
							textureImage.data[index + 2] = imgData.data[index + 2];
							textureImage.data[index + 3] = 255;
						}
					}
					ctx.putImageData(textureImage, 0, 0);
					pimage.__cvs = cvs;
					curContext.bindTexture(curContext.TEXTURE_2D, pimage.__texture);
					curContext.texParameteri(curContext.TEXTURE_2D, curContext.TEXTURE_MIN_FILTER, curContext.LINEAR_MIPMAP_LINEAR);
					curContext.texParameteri(curContext.TEXTURE_2D, curContext.TEXTURE_MAG_FILTER, curContext.LINEAR);
					curContext.texParameteri(curContext.TEXTURE_2D, curContext.TEXTURE_WRAP_T, curContext.CLAMP_TO_EDGE);
					curContext.texParameteri(curContext.TEXTURE_2D, curContext.TEXTURE_WRAP_S, curContext.CLAMP_TO_EDGE);
					executeTexImage2D(pimage.__cvs);
					curContext.generateMipmap(curContext.TEXTURE_2D);
				}				else
{
					curContext.bindTexture(curContext.TEXTURE_2D, pimage.__texture);
				}
			}
			curTexture.width = pimage.width;
			curTexture.height = pimage.height;
			usingTexture = true;
			curContext.useProgram(programObject3D);
			uniformi("usingTexture3d", programObject3D, "usingTexture", usingTexture);
		});
		p.textureMode = 		(function (mode){
			curTextureMode = mode;
		});
		var curveVertexSegment = 		(function (x1, y1, z1, x2, y2, z2, x3, y3, z3, x4, y4, z4){
			var x0 = x2;
			var y0 = y2;
			var z0 = z2;
			var draw = curveDrawMatrix.array();
			var xplot1 = (((draw[4] * x1) + (draw[5] * x2)) + (draw[6] * x3)) + (draw[7] * x4);
			var xplot2 = (((draw[8] * x1) + (draw[9] * x2)) + (draw[10] * x3)) + (draw[11] * x4);
			var xplot3 = (((draw[12] * x1) + (draw[13] * x2)) + (draw[14] * x3)) + (draw[15] * x4);
			var yplot1 = (((draw[4] * y1) + (draw[5] * y2)) + (draw[6] * y3)) + (draw[7] * y4);
			var yplot2 = (((draw[8] * y1) + (draw[9] * y2)) + (draw[10] * y3)) + (draw[11] * y4);
			var yplot3 = (((draw[12] * y1) + (draw[13] * y2)) + (draw[14] * y3)) + (draw[15] * y4);
			var zplot1 = (((draw[4] * z1) + (draw[5] * z2)) + (draw[6] * z3)) + (draw[7] * z4);
			var zplot2 = (((draw[8] * z1) + (draw[9] * z2)) + (draw[10] * z3)) + (draw[11] * z4);
			var zplot3 = (((draw[12] * z1) + (draw[13] * z2)) + (draw[14] * z3)) + (draw[15] * z4);
			p.vertex(x0, y0, z0);
			for(var j = 0; j < curveDet;j++){
				x0 += xplot1;
				xplot1 += xplot2;
				xplot2 += xplot3;
				y0 += yplot1;
				yplot1 += yplot2;
				yplot2 += yplot3;
				z0 += zplot1;
				zplot1 += zplot2;
				zplot2 += zplot3;
				p.vertex(x0, y0, z0);
			}
		});
		Drawing2D.prototype.curveVertex = 		(function (x, y){
			isCurve = true;
			p.vertex(x, y);
		});
		Drawing3D.prototype.curveVertex = 		(function (x, y, z){
			isCurve = true;
			if (!curveInited){
				curveInit();
			}
			var vert = [];
			vert[0] = x;
			vert[1] = y;
			vert[2] = z;
			curveVertArray.push(vert);
			curveVertCount++;
			if (curveVertCount > 3){
				curveVertexSegment(curveVertArray[curveVertCount - 4][0], curveVertArray[curveVertCount - 4][1], curveVertArray[curveVertCount - 4][2], curveVertArray[curveVertCount - 3][0], curveVertArray[curveVertCount - 3][1], curveVertArray[curveVertCount - 3][2], curveVertArray[curveVertCount - 2][0], curveVertArray[curveVertCount - 2][1], curveVertArray[curveVertCount - 2][2], curveVertArray[curveVertCount - 1][0], curveVertArray[curveVertCount - 1][1], curveVertArray[curveVertCount - 1][2]);
			}
		});
		Drawing2D.prototype.curve = 		(function (){
			if (arguments.length === 8){
				p.beginShape();
				p.curveVertex(arguments[0], arguments[1]);
				p.curveVertex(arguments[2], arguments[3]);
				p.curveVertex(arguments[4], arguments[5]);
				p.curveVertex(arguments[6], arguments[7]);
				p.endShape();
			}
		});
		Drawing3D.prototype.curve = 		(function (){
			if (arguments.length === 12){
				p.beginShape();
				p.curveVertex(arguments[0], arguments[1], arguments[2]);
				p.curveVertex(arguments[3], arguments[4], arguments[5]);
				p.curveVertex(arguments[6], arguments[7], arguments[8]);
				p.curveVertex(arguments[9], arguments[10], arguments[11]);
				p.endShape();
			}
		});
		p.curveTightness = 		(function (tightness){
			curTightness = tightness;
		});
		p.curveDetail = 		(function (detail){
			curveDet = detail;
			curveInit();
		});
		p.rectMode = 		(function (aRectMode){
			curRectMode = aRectMode;
		});
		p.imageMode = 		(function (mode){
			switch(mode) {
				case PConstants.CORNER:
{
					imageModeConvert = imageModeCorner;
					break ;
				}				case PConstants.CORNERS:
{
					imageModeConvert = imageModeCorners;
					break ;
				}				case PConstants.CENTER:
{
					imageModeConvert = imageModeCenter;
					break ;
				}				default:
{
					throw "Invalid imageMode";
				}}
		});
		p.ellipseMode = 		(function (aEllipseMode){
			curEllipseMode = aEllipseMode;
		});
		p.arc = 		(function (x, y, width, height, start, stop){
			if ((width <= 0) || (stop < start)){
				return ;
			}
			if (curEllipseMode === PConstants.CORNERS){
				width = (width - x);
				height = (height - y);
			}			else
{
				if (curEllipseMode === PConstants.RADIUS){
					x = (x - width);
					y = (y - height);
					width = (width * 2);
					height = (height * 2);
				}				else
{
					if (curEllipseMode === PConstants.CENTER){
						x = (x - (width / 2));
						y = (y - (height / 2));
					}
				}
			}
			while(start < 0){
				start += PConstants.TWO_PI;
				stop += PConstants.TWO_PI;
			}
			if ((stop - start) > PConstants.TWO_PI){
				start = 0;
				stop = PConstants.TWO_PI;
			}
			var hr = width / 2;
			var vr = height / 2;
			var centerX = x + hr;
			var centerY = y + vr;
			var startLUT = 0 | (-0.5 + ((start / PConstants.TWO_PI) * PConstants.SINCOS_LENGTH));
			var stopLUT = 0 | (0.5 + ((stop / PConstants.TWO_PI) * PConstants.SINCOS_LENGTH));
			var i; var j;
			if (doFill){
				var savedStroke = doStroke;
				doStroke = false;
				p.beginShape();
				p.vertex(centerX, centerY);
				for(i = startLUT, j = startLUT; i < stopLUT;i++, j++){
					if (j >= PConstants.SINCOS_LENGTH){
						j = (j - PConstants.SINCOS_LENGTH);
					}
					p.vertex(centerX + (cosLUT[j] * hr), centerY + (sinLUT[j] * vr));
				}
				p.endShape(PConstants.CLOSE);
				doStroke = savedStroke;
			}
			if (doStroke){
				var savedFill = doFill;
				doFill = false;
				p.beginShape();
				for(i = startLUT, j = startLUT; i < stopLUT;i++, j++){
					if (j >= PConstants.SINCOS_LENGTH){
						j = (j - PConstants.SINCOS_LENGTH);
					}
					p.vertex(centerX + (cosLUT[j] * hr), centerY + (sinLUT[j] * vr));
				}
				j = (stopLUT % PConstants.SINCOS_LENGTH);
				p.vertex(centerX + (cosLUT[j] * hr), centerY + (sinLUT[j] * vr));
				p.endShape();
				doFill = savedFill;
			}
		});
		Drawing2D.prototype.line = 		(function (){
			var x1; var y1; var x2; var y2;
			x1 = arguments[0];
			y1 = arguments[1];
			x2 = arguments[2];
			y2 = arguments[3];
			if ((x1 === x2) && (y1 === y2)){
				p.point(x1, y1);
			}			else
{
				if (((((x1 === x2) || (y1 === y2)) && (lineWidth <= 1)) && doStroke) && curSketch.options.crispLines){
					var temp;
					if (x1 === x2){
						if (y1 > y2){
							temp = y1;
							y1 = y2;
							y2 = temp;
						}
						for(var y = y1; y <= y2;++y){
							p.set(x1, y, currentStrokeColor);
						}
					}					else
{
						if (x1 > x2){
							temp = x1;
							x1 = x2;
							x2 = temp;
						}
						for(var x = x1; x <= x2;++x){
							p.set(x, y1, currentStrokeColor);
						}
					}
					return ;
				}				else
{
					if (doStroke){
						curContext.beginPath();
						curContext.moveTo(x1 || 0, y1 || 0);
						curContext.lineTo(x2 || 0, y2 || 0);
						executeContextStroke();
						curContext.closePath();
					}
				}
			}
		});
		Drawing3D.prototype.line = 		(function (){
			var x1; var y1; var z1; var x2; var y2; var z2;
			if (arguments.length === 6){
				x1 = arguments[0];
				y1 = arguments[1];
				z1 = arguments[2];
				x2 = arguments[3];
				y2 = arguments[4];
				z2 = arguments[5];
			}			else
{
				if (arguments.length === 4){
					x1 = arguments[0];
					y1 = arguments[1];
					z1 = 0;
					x2 = arguments[2];
					y2 = arguments[3];
					z2 = 0;
				}
			}
			if (((x1 === x2) && (y1 === y2)) && (z1 === z2)){
				p.point(x1, y1, z1);
				return ;
			}
			var lineVerts = [x1,y1,z1,x2,y2,z2];
			var view = new PMatrix3D();
			view.scale(1, -1, 1);
			view.apply(modelView.array());
			view.transpose();
			if ((lineWidth > 0) && doStroke){
				curContext.useProgram(programObject2D);
				uniformMatrix("model2d", programObject2D, "model", false, [1,0,0,0,0,1,0,0,0,0,1,0,0,0,0,1]);
				uniformMatrix("view2d", programObject2D, "view", false, view.array());
				uniformf("color2d", programObject2D, "color", strokeStyle);
				uniformi("picktype2d", programObject2D, "picktype", 0);
				curContext.lineWidth(lineWidth);
				vertexAttribPointer("vertex2d", programObject2D, "Vertex", 3, lineBuffer);
				disableVertexAttribPointer("aTextureCoord2d", programObject2D, "aTextureCoord");
				curContext.bufferData(curContext.ARRAY_BUFFER, new Float32Array(lineVerts), curContext.STREAM_DRAW);
				curContext.drawArrays(curContext.LINES, 0, 2);
			}
		});
		Drawing2D.prototype.bezier = 		(function (){
			if (arguments.length !== 8){
				throw "You must use 8 parameters for bezier() in 2D mode";
			}
			p.beginShape();
			p.vertex(arguments[0], arguments[1]);
			p.bezierVertex(arguments[2], arguments[3], arguments[4], arguments[5], arguments[6], arguments[7]);
			p.endShape();
		});
		Drawing3D.prototype.bezier = 		(function (){
			if (arguments.length !== 12){
				throw "You must use 12 parameters for bezier() in 3D mode";
			}
			p.beginShape();
			p.vertex(arguments[0], arguments[1], arguments[2]);
			p.bezierVertex(arguments[3], arguments[4], arguments[5], arguments[6], arguments[7], arguments[8], arguments[9], arguments[10], arguments[11]);
			p.endShape();
		});
		p.bezierDetail = 		(function (detail){
			bezDetail = detail;
		});
		p.bezierPoint = 		(function (a, b, c, d, t){
			return ((((((1 - t) * (1 - t)) * (1 - t)) * a) + ((((3 * (1 - t)) * (1 - t)) * t) * b)) + ((((3 * (1 - t)) * t) * t) * c)) + (((t * t) * t) * d);
		});
		p.bezierTangent = 		(function (a, b, c, d, t){
			return ((((3 * t) * t) * (((-a + (3 * b)) - (3 * c)) + d)) + ((6 * t) * ((a - (2 * b)) + c))) + (3 * (-a + b));
		});
		p.curvePoint = 		(function (a, b, c, d, t){
			return 0.5 * ((((2 * b) + ((-a + c) * t)) + ((((((2 * a) - (5 * b)) + (4 * c)) - d) * t) * t)) + ((((((-a + (3 * b)) - (3 * c)) + d) * t) * t) * t));
		});
		p.curveTangent = 		(function (a, b, c, d, t){
			return 0.5 * (((-a + c) + ((2 * ((((2 * a) - (5 * b)) + (4 * c)) - d)) * t)) + (((3 * (((-a + (3 * b)) - (3 * c)) + d)) * t) * t));
		});
		p.triangle = 		(function (x1, y1, x2, y2, x3, y3){
			p.beginShape(PConstants.TRIANGLES);
			p.vertex(x1, y1, 0);
			p.vertex(x2, y2, 0);
			p.vertex(x3, y3, 0);
			p.endShape();
		});
		p.quad = 		(function (x1, y1, x2, y2, x3, y3, x4, y4){
			p.beginShape(PConstants.QUADS);
			p.vertex(x1, y1, 0);
			p.vertex(x2, y2, 0);
			p.vertex(x3, y3, 0);
			p.vertex(x4, y4, 0);
			p.endShape();
		});
		Drawing2D.prototype.rect = 		(function (x, y, width, height){
			if (!width && !height){
				return ;
			}
			if (((doStroke && !doFill) && (lineWidth <= 1)) && curSketch.options.crispLines){
				var i; var x2 = (x + width) - 1; var y2 = (y + height) - 1;
				for(i = 0; i < width;++i){
					p.set(x + i, y, currentStrokeColor);
					p.set(x + i, y2, currentStrokeColor);
				}
				for(i = 0; i < height;++i){
					p.set(x, y + i, currentStrokeColor);
					p.set(x2, y + i, currentStrokeColor);
				}
				return ;
			}
			curContext.beginPath();
			var offsetStart = 0;
			var offsetEnd = 0;
			if (curRectMode === PConstants.CORNERS){
				width -= x;
				height -= y;
			}
			if (curRectMode === PConstants.RADIUS){
				width *= 2;
				height *= 2;
			}
			if ((curRectMode === PConstants.CENTER) || (curRectMode === PConstants.RADIUS)){
				x -= (width / 2);
				y -= (height / 2);
			}
			curContext.rect(Math.round(x) - offsetStart, Math.round(y) - offsetStart, Math.round(width) + offsetEnd, Math.round(height) + offsetEnd);
			executeContextFill();
			executeContextStroke();
			curContext.closePath();
		});
		Drawing3D.prototype.rect = 		(function (x, y, width, height){
			var model = new PMatrix3D();
			model.translate(x, y, 0);
			model.scale(width, height, 1);
			model.transpose();
			var view = new PMatrix3D();
			view.scale(1, -1, 1);
			view.apply(modelView.array());
			view.transpose();
			if ((lineWidth > 0) && doStroke){
				curContext.useProgram(programObject2D);
				uniformMatrix("model2d", programObject2D, "model", false, model.array());
				uniformMatrix("view2d", programObject2D, "view", false, view.array());
				uniformf("color2d", programObject2D, "color", strokeStyle);
				uniformi("picktype2d", programObject2D, "picktype", 0);
				vertexAttribPointer("vertex2d", programObject2D, "Vertex", 3, rectBuffer);
				disableVertexAttribPointer("aTextureCoord2d", programObject2D, "aTextureCoord");
				curContext.lineWidth(lineWidth);
				curContext.drawArrays(curContext.LINE_LOOP, 0, rectVerts.length / 3);
			}
			if (doFill){
				curContext.useProgram(programObject3D);
				uniformMatrix("model3d", programObject3D, "model", false, model.array());
				uniformMatrix("view3d", programObject3D, "view", false, view.array());
				curContext.enable(curContext.POLYGON_OFFSET_FILL);
				curContext.polygonOffset(1, 1);
				uniformf("color3d", programObject3D, "color", fillStyle);
				if (lightCount > 0){
					var v = new PMatrix3D();
					v.set(view);
					var m = new PMatrix3D();
					m.set(model);
					v.mult(m);
					var normalMatrix = new PMatrix3D();
					normalMatrix.set(v);
					normalMatrix.invert();
					normalMatrix.transpose();
					uniformMatrix("normalTransform3d", programObject3D, "normalTransform", false, normalMatrix.array());
					vertexAttribPointer("normal3d", programObject3D, "Normal", 3, rectNormBuffer);
				}				else
{
					disableVertexAttribPointer("normal3d", programObject3D, "Normal");
				}
				vertexAttribPointer("vertex3d", programObject3D, "Vertex", 3, rectBuffer);
				curContext.drawArrays(curContext.TRIANGLE_FAN, 0, rectVerts.length / 3);
				curContext.disable(curContext.POLYGON_OFFSET_FILL);
			}
		});
		DrawingShared.prototype.ellipse = 		(function (x, y, width, height){
			x = (x || 0);
			y = (y || 0);
			if ((width <= 0) && (height <= 0)){
				return ;
			}
			if (curEllipseMode === PConstants.RADIUS){
				width *= 2;
				height *= 2;
			}
			if (curEllipseMode === PConstants.CORNERS){
				width = (width - x);
				height = (height - y);
			}
			if ((curEllipseMode === PConstants.CORNER) || (curEllipseMode === PConstants.CORNERS)){
				x += (width / 2);
				y += (height / 2);
			}
			return {			'x':x, 			'y':y, 			'width':width, 			'height':height			};
		});
		Drawing2D.prototype.ellipse = 		(function (x, y, width, height){
			var params = DrawingShared.prototype.ellipse.apply(this, arguments); var offsetStart = 0;
			if (!params){
				return ;
			}
			x = params['x'];
			y = params['y'];
			width = params['width'];
			height = params['height'];
			if (width === height){
				curContext.beginPath();
				curContext.arc(x - offsetStart, y - offsetStart, width / 2, 0, PConstants.TWO_PI, false);
				executeContextFill();
				executeContextStroke();
				curContext.closePath();
			}			else
{
				var w = width / 2; var h = height / 2; var C = 0.552284749830793;
				var c_x = C * w; var c_y = C * h;
				p.beginShape();
				p.vertex(x + w, y);
				p.bezierVertex(x + w, y - c_y, x + c_x, y - h, x, y - h);
				p.bezierVertex(x - c_x, y - h, x - w, y - c_y, x - w, y);
				p.bezierVertex(x - w, y + c_y, x - c_x, y + h, x, y + h);
				p.bezierVertex(x + c_x, y + h, x + w, y + c_y, x + w, y);
				p.endShape();
			}
		});
		Drawing3D.prototype.ellipse = 		(function (x, y, width, height){
			var params = DrawingShared.prototype.ellipse.apply(this, arguments); var offsetStart = 0;
			if (!params){
				return ;
			}
			x = params['x'];
			y = params['y'];
			width = params['width'];
			height = params['height'];
			var w = width / 2; var h = height / 2; var C = 0.552284749830793;
			var c_x = C * w; var c_y = C * h;
			p.beginShape();
			p.vertex(x + w, y);
			p.bezierVertex(x + w, y - c_y, 0, x + c_x, y - h, 0, x, y - h, 0);
			p.bezierVertex(x - c_x, y - h, 0, x - w, y - c_y, 0, x - w, y, 0);
			p.bezierVertex(x - w, y + c_y, 0, x - c_x, y + h, 0, x, y + h, 0);
			p.bezierVertex(x + c_x, y + h, 0, x + w, y + c_y, 0, x + w, y, 0);
			p.endShape();
			if (doFill){
				var xAv = 0; var yAv = 0; var i; var j;
				for(i = 0; i < vertArray.length;i++){
					xAv += vertArray[i][0];
					yAv += vertArray[i][1];
				}
				xAv /= vertArray.length;
				yAv /= vertArray.length;
				var vert = []; var fillVertArray = []; var colorVertArray = [];
				vert[0] = xAv;
				vert[1] = yAv;
				vert[2] = 0;
				vert[3] = 0;
				vert[4] = 0;
				vert[5] = fillStyle[0];
				vert[6] = fillStyle[1];
				vert[7] = fillStyle[2];
				vert[8] = fillStyle[3];
				vert[9] = strokeStyle[0];
				vert[10] = strokeStyle[1];
				vert[11] = strokeStyle[2];
				vert[12] = strokeStyle[3];
				vert[13] = normalX;
				vert[14] = normalY;
				vert[15] = normalZ;
				vertArray.unshift(vert);
				for(i = 0; i < vertArray.length;i++){
					for(j = 0; j < 3;j++){
						fillVertArray.push(vertArray[i][j]);
					}
					for(j = 5; j < 9;j++){
						colorVertArray.push(vertArray[i][j]);
					}
				}
				fill3D(fillVertArray, "TRIANGLE_FAN", colorVertArray);
			}
		});
		p.normal = 		(function (nx, ny, nz){
			if ((arguments.length !== 3) || !(((typeofnx === "number") && (typeofny === "number")) && (typeofnz === "number"))){
				throw "normal() requires three numeric arguments.";
			}
			normalX = nx;
			normalY = ny;
			normalZ = nz;
			if (curShape !== 0){
				if (normalMode === PConstants.NORMAL_MODE_AUTO){
					normalMode = PConstants.NORMAL_MODE_SHAPE;
				}				else
{
					if (normalMode === PConstants.NORMAL_MODE_SHAPE){
						normalMode = PConstants.NORMAL_MODE_VERTEX;
					}
				}
			}
		});
		p.save = 		(function (file, img){
			if (img !== undef){
				return window.open(img.toDataURL(), "_blank");
			}			else
{
				return window.open(p.externals.canvas.toDataURL(), "_blank");
			}
		});
		var saveNumber = 0;
		p.saveFrame = 		(function (file){
			if (file === undef){
				file = "screen-####.png";
			}
			var frameFilename = file.replace(/#+/, 			(function (all){
				var s = "" + saveNumber++;
				while(s.length < all.length){
					s = ("0" + s);
				}
				return s;
			}));
			p.save(frameFilename);
		});
		var utilityContext2d = document.createElement("canvas").getContext("2d");
		var canvasDataCache = [undef,undef,undef];
				function getCanvasData(obj, w, h){
			var canvasData = canvasDataCache.shift();
			if (canvasData === undef){
				canvasData = {				};
				canvasData.canvas = document.createElement("canvas");
				canvasData.context = canvasData.canvas.getContext('2d');
			}
			canvasDataCache.push(canvasData);
			var canvas = canvasData.canvas; var context = canvasData.context; var width = w || obj.width; var height = h || obj.height;
			canvas.width = width;
			canvas.height = height;
			if (!obj){
				context.clearRect(0, 0, width, height);
			}			else
{
				if ("data" in obj){
					context.putImageData(obj, 0, 0);
				}				else
{
					context.clearRect(0, 0, width, height);
					context.drawImage(obj, 0, 0, width, height);
				}
			}
			return canvasData;
		}
		var PImage = 		(function (aWidth, aHeight, aFormat){
			this.get = 			(function (x, y, w, h){
				if (!arguments.length){
					return p.get(this);
				}				else
{
					if (arguments.length === 2){
						return p.get(x, y, this);
					}					else
{
						if (arguments.length === 4){
							return p.get(x, y, w, h, this);
						}
					}
				}
			});
			this.set = 			(function (x, y, c){
				p.set(x, y, c, this);
			});
			this.blend = 			(function (srcImg, x, y, width, height, dx, dy, dwidth, dheight, MODE){
				if (arguments.length === 9){
					p.blend(this, srcImg, x, y, width, height, dx, dy, dwidth, dheight, this);
				}				else
{
					if (arguments.length === 10){
						p.blend(srcImg, x, y, width, height, dx, dy, dwidth, dheight, MODE, this);
					}
				}
				deletethis.sourceImg;
			});
			this.copy = 			(function (srcImg, sx, sy, swidth, sheight, dx, dy, dwidth, dheight){
				if (arguments.length === 8){
					p.blend(this, srcImg, sx, sy, swidth, sheight, dx, dy, dwidth, PConstants.REPLACE, this);
				}				else
{
					if (arguments.length === 9){
						p.blend(srcImg, sx, sy, swidth, sheight, dx, dy, dwidth, dheight, PConstants.REPLACE, this);
					}
				}
				deletethis.sourceImg;
			});
			this.filter = 			(function (mode, param){
				if (arguments.length === 2){
					p.filter(mode, param, this);
				}				else
{
					if (arguments.length === 1){
						p.filter(mode, null, this);
					}
				}
				deletethis.sourceImg;
			});
			this.save = 			(function (file){
				p.save(file, this);
			});
			this.resize = 			(function (w, h){
				if (this.isRemote){
					throw "Image is loaded remotely. Cannot resize.";
				}				else
{
					if ((this.width !== 0) || (this.height !== 0)){
						if ((w === 0) && (h !== 0)){
							w = Math.floor((this.width / this.height) * h);
						}						else
{
							if ((h === 0) && (w !== 0)){
								h = Math.floor((this.height / this.width) * w);
							}
						}
						var canvas = getCanvasData(this.imageData).canvas;
						var imageData = getCanvasData(canvas, w, h).context.getImageData(0, 0, w, h);
						this.fromImageData(imageData);
					}
				}
			});
			this.mask = 			(function (mask){
				this.__mask = undef;
				if (mask instanceof PImage){
					if ((mask.width === this.width) && (mask.height === this.height)){
						this.__mask = mask;
					}					else
{
						throw "mask must have the same dimensions as PImage.";
					}
				}				else
{
					if (mask instanceof Array){
						if (this.pixels.length === mask.length){
							this.__mask = mask;
						}						else
{
							throw "mask array must be the same length as PImage pixels array.";
						}
					}
				}
			});
			this.pixels = {			getLength:			(function (aImg){
				if (aImg.isRemote){
					throw "Image is loaded remotely. Cannot get length.";
				}				else
{
					return 					(function (){
						return aImg.imageData.data.length ? (aImg.imageData.data.length / 4) : 0;
					});
				}
			})(this), 			getPixel:			(function (aImg){
				if (aImg.isRemote){
					throw "Image is loaded remotely. Cannot get pixels.";
				}				else
{
					return 					(function (i){
						var offset = i * 4;
						return p.color.toInt(aImg.imageData.data[offset], aImg.imageData.data[offset + 1], aImg.imageData.data[offset + 2], aImg.imageData.data[offset + 3]);
					});
				}
			})(this), 			setPixel:			(function (aImg){
				if (aImg.isRemote){
					throw "Image is loaded remotely. Cannot set pixel.";
				}				else
{
					return 					(function (i, c){
						var offset = i * 4;
						aImg.imageData.data[offset + 0] = ((c & PConstants.RED_MASK) >>> 16);
						aImg.imageData.data[offset + 1] = ((c & PConstants.GREEN_MASK) >>> 8);
						aImg.imageData.data[offset + 2] = (c & PConstants.BLUE_MASK);
						aImg.imageData.data[offset + 3] = ((c & PConstants.ALPHA_MASK) >>> 24);
					});
				}
			})(this), 			set:			(function (arr){
				if (this.isRemote){
					throw "Image is loaded remotely. Cannot set pixels.";
				}				else
{
					for(var i = 0, aL = arr.length; i < aL;i++){
						this.setPixel(i, arr[i]);
					}
				}
			})			};
			this.loadPixels = 			(function (){
			});
			this.updatePixels = 			(function (){
			});
			this.toImageData = 			(function (){
				if (this.isRemote){
					return this.sourceImg;
				}				else
{
					var canvasData = getCanvasData(this.imageData);
					return canvasData.context.getImageData(0, 0, this.width, this.height);
				}
			});
			this.toDataURL = 			(function (){
				if (this.isRemote){
					throw "Image is loaded remotely. Cannot create dataURI.";
				}				else
{
					var canvasData = getCanvasData(this.imageData);
					return canvasData.canvas.toDataURL();
				}
			});
			this.fromImageData = 			(function (canvasImg){
				this.width = canvasImg.width;
				this.height = canvasImg.height;
				this.imageData = canvasImg;
				this.format = PConstants.ARGB;
			});
			this.fromHTMLImageData = 			(function (htmlImg){
				var canvasData = getCanvasData(htmlImg);
				try{
					var imageData = canvasData.context.getImageData(0, 0, htmlImg.width, htmlImg.height);
					this.fromImageData(imageData);
				}catch( e ){
					if (htmlImg.width && htmlImg.height){
						this.isRemote = true;
						this.width = htmlImg.width;
						this.height = htmlImg.height;
					}
				}
				this.sourceImg = htmlImg;
			});
			if (arguments.length === 1){
				this.fromHTMLImageData(arguments[0]);
			}			else
{
				if ((arguments.length === 2) || (arguments.length === 3)){
					this.width = (aWidth || 1);
					this.height = (aHeight || 1);
					this.imageData = utilityContext2d.createImageData(this.width, this.height);
					this.format = (((aFormat === PConstants.ARGB) || (aFormat === PConstants.ALPHA)) ? aFormat : PConstants.RGB);
					if (this.format === PConstants.RGB){
						for(var i = 3, data = this.imageData.data, len = data.length; i < len;i += 4){
							data[i] = 255;
						}
					}
				}				else
{
					this.width = 0;
					this.height = 0;
					this.imageData = utilityContext2d.createImageData(1, 1);
					this.format = PConstants.ARGB;
				}
			}
		});
		p.PImage = PImage;
		p.createImage = 		(function (w, h, mode){
			return new PImage(w, h, mode);
		});
		p.loadImage = 		(function (file, type, callback){
			if (type){
				file = ((file + ".") + type);
			}
			var pimg;
			if (curSketch.imageCache.images[file]){
				pimg = new PImage(curSketch.imageCache.images[file]);
				pimg.loaded = true;
				return pimg;
			}			else
{
				pimg = new PImage();
				var img = document.createElement('img');
				pimg.sourceImg = img;
				img.onload = 				(function (aImage, aPImage, aCallback){
					var image = aImage;
					var pimg = aPImage;
					var callback = aCallback;
					return 					(function (){
						pimg.fromHTMLImageData(image);
						pimg.loaded = true;
						if (callback){
							callback();
						}
					});
				})(img, pimg, callback);
				img.src = file;
				return pimg;
			}
		});
		p.requestImage = p.loadImage;
				function get$0(){
			var c = new PImage(p.width, p.height, PConstants.RGB);
			c.fromImageData(curContext.getImageData(0, 0, p.width, p.height));
			return c;
		}
				function get$2(x, y){
			var data;
			if ((((x < p.width) && (x >= 0)) && (y >= 0)) && (y < p.height)){
				if (isContextReplaced){
					var offset = ((0 | x) + (p.width * (0 | y))) * 4;
					data = p.imageData.data;
					return p.color.toInt(data[offset], data[offset + 1], data[offset + 2], data[offset + 3]);
				}
				data = curContext.getImageData(0 | x, 0 | y, 1, 1).data;
				return p.color.toInt(data[0], data[1], data[2], data[3]);
			}			else
{
				return 0;
			}
		}
				function get$3(x, y, img){
			if (img.isRemote){
				throw "Image is loaded remotely. Cannot get x,y.";
			}			else
{
				var offset = ((y * img.width) * 4) + (x * 4);
				return p.color.toInt(img.imageData.data[offset], img.imageData.data[offset + 1], img.imageData.data[offset + 2], img.imageData.data[offset + 3]);
			}
		}
				function get$4(x, y, w, h){
			var c = new PImage(w, h, PConstants.RGB);
			c.fromImageData(curContext.getImageData(x, y, w, h));
			return c;
		}
				function get$5(x, y, w, h, img){
			if (img.isRemote){
				throw "Image is loaded remotely. Cannot get x,y,w,h.";
			}			else
{
				var c = new PImage(w, h, PConstants.RGB); var cData = c.imageData.data; var imgWidth = img.width; var imgHeight = img.height; var imgData = img.imageData.data;
				var startRow = Math.max(0, -y); var startColumn = Math.max(0, -x); var stopRow = Math.min(h, imgHeight - y); var stopColumn = Math.min(w, imgWidth - x);
				for(var i = startRow; i < stopRow;++i){
					var sourceOffset = (((y + i) * imgWidth) + (x + startColumn)) * 4;
					var targetOffset = ((i * w) + startColumn) * 4;
					for(var j = startColumn; j < stopColumn;++j){
						cData[targetOffset++] = imgData[sourceOffset++];
						cData[targetOffset++] = imgData[sourceOffset++];
						cData[targetOffset++] = imgData[sourceOffset++];
						cData[targetOffset++] = imgData[sourceOffset++];
					}
				}
				return c;
			}
		}
		p.get = 		(function (x, y, w, h, img){
			if (arguments.length === 2){
				return get$2(x, y);
			}			else
{
				if (arguments.length === 0){
					return get$0();
				}				else
{
					if (arguments.length === 5){
						return get$5(x, y, w, h, img);
					}					else
{
						if (arguments.length === 4){
							return get$4(x, y, w, h);
						}						else
{
							if (arguments.length === 3){
								return get$3(x, y, w);
							}							else
{
								if (arguments.length === 1){
									return x;
								}
							}
						}
					}
				}
			}
		});
		p.createGraphics = 		(function (w, h, render){
			var pg = new Processing();
			pg.size(w, h, render);
			return pg;
		});
				function resetContext(){
			if (isContextReplaced){
				curContext = originalContext;
				isContextReplaced = false;
				p.updatePixels();
			}
		}
				function SetPixelContextWrapper(){
						function wrapFunction(newContext, name){
								function wrapper(){
					resetContext();
					curContext[name].apply(curContext, arguments);
				}
				newContext[name] = wrapper;
			}
						function wrapProperty(newContext, name){
								function getter(){
					resetContext();
					return curContext[name];
				}
								function setter(value){
					resetContext();
					curContext[name] = value;
				}
				p.defineProperty(newContext, name, {				get:getter, 				set:setter				});
			}
			for(var n in curContext){
				if (typeofcurContext[n] === 'function'){
					wrapFunction(this, n);
				}				else
{
					wrapProperty(this, n);
				}
			}
		}
				function replaceContext(){
			if (isContextReplaced){
				return ;
			}
			p.loadPixels();
			if (proxyContext === null){
				originalContext = curContext;
				proxyContext = new SetPixelContextWrapper();
			}
			isContextReplaced = true;
			curContext = proxyContext;
			setPixelsCached = 0;
		}
				function set$3(x, y, c){
			if ((((x < p.width) && (x >= 0)) && (y >= 0)) && (y < p.height)){
				replaceContext();
				p.pixels.setPixel((0 | x) + (p.width * (0 | y)), c);
				if (++setPixelsCached > maxPixelsCached){
					resetContext();
				}
			}
		}
				function set$4(x, y, obj, img){
			if (img.isRemote){
				throw "Image is loaded remotely. Cannot set x,y.";
			}			else
{
				var c = p.color.toArray(obj);
				var offset = ((y * img.width) * 4) + (x * 4);
				var data = img.imageData.data;
				data[offset] = c[0];
				data[offset + 1] = c[1];
				data[offset + 2] = c[2];
				data[offset + 3] = c[3];
			}
		}
		p.set = 		(function (x, y, obj, img){
			var color; var oldFill;
			if (arguments.length === 3){
				if (typeofobj === "number"){
					set$3(x, y, obj);
				}				else
{
					if (obj instanceof PImage){
						p.image(obj, x, y);
					}
				}
			}			else
{
				if (arguments.length === 4){
					set$4(x, y, obj, img);
				}
			}
		});
		p.imageData = {		};
		p.pixels = {		getLength:		(function (){
			return p.imageData.data.length ? (p.imageData.data.length / 4) : 0;
		}), 		getPixel:		(function (i){
			var offset = i * 4;
			return ((((p.imageData.data[offset + 3] << 24) & -16777216) | ((p.imageData.data[offset + 0] << 16) & 16711680)) | ((p.imageData.data[offset + 1] << 8) & 65280)) | (p.imageData.data[offset + 2] & 255);
		}), 		setPixel:		(function (i, c){
			var offset = i * 4;
			p.imageData.data[offset + 0] = ((c & 16711680) >>> 16);
			p.imageData.data[offset + 1] = ((c & 65280) >>> 8);
			p.imageData.data[offset + 2] = (c & 255);
			p.imageData.data[offset + 3] = ((c & -16777216) >>> 24);
		}), 		set:		(function (arr){
			for(var i = 0, aL = arr.length; i < aL;i++){
				this.setPixel(i, arr[i]);
			}
		})		};
		p.loadPixels = 		(function (){
			p.imageData = drawing.$ensureContext().getImageData(0, 0, p.width, p.height);
		});
		p.updatePixels = 		(function (){
			if (p.imageData){
				drawing.$ensureContext().putImageData(p.imageData, 0, 0);
			}
		});
		p.hint = 		(function (which){
			var curContext = drawing.$ensureContext();
			if (which === PConstants.DISABLE_DEPTH_TEST){
				curContext.disable(curContext.DEPTH_TEST);
				curContext.depthMask(false);
				curContext.clear(curContext.DEPTH_BUFFER_BIT);
			}			else
{
				if (which === PConstants.ENABLE_DEPTH_TEST){
					curContext.enable(curContext.DEPTH_TEST);
					curContext.depthMask(true);
				}
			}
		});
		DrawingShared.prototype.background = 		(function (){
			var obj;
			if (arguments[0] instanceof PImage){
				obj = arguments[0];
				if (!obj.loaded){
					throw "Error using image in background(): PImage not loaded.";
				}				else
{
					if ((obj.width !== p.width) || (obj.height !== p.height)){
						throw "Background image must be the same dimensions as the canvas.";
					}
				}
			}			else
{
				obj = p.color.apply(this, arguments);
				if (!curSketch.options.isTransparent){
					obj = (obj | PConstants.ALPHA_MASK);
				}
			}
			backgroundObj = obj;
		});
		Drawing2D.prototype.background = 		(function (){
			if (arguments.length > 0){
				DrawingShared.prototype.background.apply(this, arguments);
			}
			if (backgroundObj instanceof PImage){
				saveContext();
				curContext.setTransform(1, 0, 0, 1, 0, 0);
				p.image(backgroundObj, 0, 0);
				restoreContext();
			}			else
{
				saveContext();
				curContext.setTransform(1, 0, 0, 1, 0, 0);
				if (curSketch.options.isTransparent){
					curContext.clearRect(0, 0, p.width, p.height);
				}
				curContext.fillStyle = p.color.toString(backgroundObj);
				curContext.fillRect(0, 0, p.width, p.height);
				isFillDirty = true;
				restoreContext();
			}
		});
		Drawing3D.prototype.background = 		(function (){
			if (arguments.length > 0){
				DrawingShared.prototype.background.apply(this, arguments);
			}
			var c = p.color.toGLArray(backgroundObj);
			curContext.clearColor(c[0], c[1], c[2], c[3]);
			curContext.clear(curContext.COLOR_BUFFER_BIT | curContext.DEPTH_BUFFER_BIT);
		});
		Drawing2D.prototype.image = 		(function (img, x, y, w, h){
			if (img.width > 0){
				var wid = w || img.width;
				var hgt = h || img.height;
				var bounds = imageModeConvert(x || 0, y || 0, w || img.width, h || img.height, arguments.length < 4);
				var fastImage = (!!img.sourceImg && (curTint === null)) && !img.__mask;
				if (fastImage){
					var htmlElement = img.sourceImg;
					curContext.drawImage(htmlElement, 0, 0, htmlElement.width, htmlElement.height, bounds.x, bounds.y, bounds.w, bounds.h);
				}				else
{
					var obj = img.toImageData();
					if (img.__mask){
						var j; var size;
						if (img.__mask instanceof PImage){
							var objMask = img.__mask.toImageData();
							for(j = 2, size = ((img.width * img.height) * 4); j < size;j += 4){
								obj.data[j + 1] = objMask.data[j];
							}
						}						else
{
							for(j = 0, size = img.__mask.length; j < size;++j){
								obj.data[(j << 2) + 3] = img.__mask[j];
							}
						}
					}
					if (curTint !== null){
						curTint(obj);
					}
					curContext.drawImage(getCanvasData(obj).canvas, 0, 0, img.width, img.height, bounds.x, bounds.y, bounds.w, bounds.h);
				}
			}
		});
		Drawing3D.prototype.image = 		(function (img, x, y, w, h){
			if (img.width > 0){
				var wid = w || img.width;
				var hgt = h || img.height;
				p.beginShape(p.QUADS);
				p.texture(img.externals.canvas);
				p.vertex(x, y, 0, 0, 0);
				p.vertex(x, y + hgt, 0, 0, hgt);
				p.vertex(x + wid, y + hgt, 0, wid, hgt);
				p.vertex(x + wid, y, 0, wid, 0);
				p.endShape();
			}
		});
		p.tint = 		(function (){
			var tintColor = p.color.apply(this, arguments);
			var r = p.red(tintColor) / colorModeX;
			var g = p.green(tintColor) / colorModeY;
			var b = p.blue(tintColor) / colorModeZ;
			var a = p.alpha(tintColor) / colorModeA;
			curTint = 			(function (obj){
				var data = obj.data; var length = (4 * obj.width) * obj.height;
				for(var i = 0; i < length;){
					data[i++] *= r;
					data[i++] *= g;
					data[i++] *= b;
					data[i++] *= a;
				}
			});
		});
		p.noTint = 		(function (){
			curTint = null;
		});
		p.copy = 		(function (src, sx, sy, sw, sh, dx, dy, dw, dh){
			if (arguments.length === 8){
				dh = dw;
				dw = dy;
				dy = dx;
				dx = sh;
				sh = sw;
				sw = sy;
				sy = sx;
				sx = src;
				src = p;
			}
			p.blend(src, sx, sy, sw, sh, dx, dy, dw, dh, PConstants.REPLACE);
		});
		p.blend = 		(function (src, sx, sy, sw, sh, dx, dy, dw, dh, mode, pimgdest){
			if (arguments.length === 9){
				mode = dh;
				dh = dw;
				dw = dy;
				dy = dx;
				dx = sh;
				sh = sw;
				sw = sy;
				sy = sx;
				sx = src;
				src = p;
			}
			var sx2 = sx + sw;
			var sy2 = sy + sh;
			var dx2 = dx + dw;
			var dy2 = dy + dh;
			var dest;
			if (src.isRemote){
				throw "Image is loaded remotely. Cannot blend image.";
			}			else
{
				if ((arguments.length === 10) || (arguments.length === 9)){
					p.loadPixels();
					dest = p;
				}				else
{
					if (((arguments.length === 11) && pimgdest) && pimgdest.imageData){
						dest = pimgdest;
					}
				}
				if (src === p){
					if (p.intersect(sx, sy, sx2, sy2, dx, dy, dx2, dy2)){
						p.blit_resize(p.get(sx, sy, sx2 - sx, sy2 - sy), 0, 0, (sx2 - sx) - 1, (sy2 - sy) - 1, dest.imageData.data, dest.width, dest.height, dx, dy, dx2, dy2, mode);
					}					else
{
						p.blit_resize(src, sx, sy, sx2, sy2, dest.imageData.data, dest.width, dest.height, dx, dy, dx2, dy2, mode);
					}
				}				else
{
					src.loadPixels();
					p.blit_resize(src, sx, sy, sx2, sy2, dest.imageData.data, dest.width, dest.height, dx, dy, dx2, dy2, mode);
				}
				if (arguments.length === 10){
					p.updatePixels();
				}
			}
		});
		var buildBlurKernel = 		(function (r){
			var radius = p.floor(r * 3.5); var i; var radiusi;
			radius = ((radius < 1) ? 1 : ((radius < 248) ? radius : 248));
			if (p.shared.blurRadius !== radius){
				p.shared.blurRadius = radius;
				p.shared.blurKernelSize = (1 + (p.shared.blurRadius << 1));
				p.shared.blurKernel = new Float32Array(p.shared.blurKernelSize);
				var sharedBlurKernal = p.shared.blurKernel;
				var sharedBlurKernelSize = p.shared.blurKernelSize;
				var sharedBlurRadius = p.shared.blurRadius;
				for(i = 0; i < sharedBlurKernelSize;i++){
					sharedBlurKernal[i] = 0;
				}
				var radiusiSquared = (radius - 1) * (radius - 1);
				for(i = 1; i < radius;i++){
					sharedBlurKernal[radius + i] = (sharedBlurKernal[radiusi] = radiusiSquared);
				}
				sharedBlurKernal[radius] = (radius * radius);
			}
		});
		var blurARGB = 		(function (r, aImg){
			var sum; var cr; var cg; var cb; var ca; var c; var m;
			var read; var ri; var ym; var ymi; var bk0;
			var wh = aImg.pixels.getLength();
			var r2 = new Float32Array(wh);
			var g2 = new Float32Array(wh);
			var b2 = new Float32Array(wh);
			var a2 = new Float32Array(wh);
			var yi = 0;
			var x; var y; var i; var offset;
			buildBlurKernel(r);
			var aImgHeight = aImg.height;
			var aImgWidth = aImg.width;
			var sharedBlurKernelSize = p.shared.blurKernelSize;
			var sharedBlurRadius = p.shared.blurRadius;
			var sharedBlurKernal = p.shared.blurKernel;
			var pix = aImg.imageData.data;
			for(y = 0; y < aImgHeight;y++){
				for(x = 0; x < aImgWidth;x++){
					cb = (cg = (cr = (ca = (sum = 0))));
					read = (x - sharedBlurRadius);
					if (read < 0){
						bk0 = -read;
						read = 0;
					}					else
{
						if (read >= aImgWidth){
							break ;
						}
						bk0 = 0;
					}
					for(i = bk0; i < sharedBlurKernelSize;i++){
						if (read >= aImgWidth){
							break ;
						}
						offset = ((read + yi) * 4);
						m = sharedBlurKernal[i];
						ca += (m * pix[offset + 3]);
						cr += (m * pix[offset]);
						cg += (m * pix[offset + 1]);
						cb += (m * pix[offset + 2]);
						sum += m;
						read++;
					}
					ri = (yi + x);
					a2[ri] = (ca / sum);
					r2[ri] = (cr / sum);
					g2[ri] = (cg / sum);
					b2[ri] = (cb / sum);
				}
				yi += aImgWidth;
			}
			yi = 0;
			ym = -sharedBlurRadius;
			ymi = (ym * aImgWidth);
			for(y = 0; y < aImgHeight;y++){
				for(x = 0; x < aImgWidth;x++){
					cb = (cg = (cr = (ca = (sum = 0))));
					if (ym < 0){
						bk0 = (ri = -ym);
						read = x;
					}					else
{
						if (ym >= aImgHeight){
							break ;
						}
						bk0 = 0;
						ri = ym;
						read = (x + ymi);
					}
					for(i = bk0; i < sharedBlurKernelSize;i++){
						if (ri >= aImgHeight){
							break ;
						}
						m = sharedBlurKernal[i];
						ca += (m * a2[read]);
						cr += (m * r2[read]);
						cg += (m * g2[read]);
						cb += (m * b2[read]);
						sum += m;
						ri++;
						read += aImgWidth;
					}
					offset = ((x + yi) * 4);
					pix[offset] = (cr / sum);
					pix[offset + 1] = (cg / sum);
					pix[offset + 2] = (cb / sum);
					pix[offset + 3] = (ca / sum);
				}
				yi += aImgWidth;
				ymi += aImgWidth;
				ym++;
			}
		});
		var dilate = 		(function (isInverted, aImg){
			var currIdx = 0;
			var maxIdx = aImg.pixels.getLength();
			var out = new Int32Array(maxIdx);
			var currRowIdx; var maxRowIdx; var colOrig; var colOut; var currLum;
			var idxRight; var idxLeft; var idxUp; var idxDown; var colRight; var colLeft; var colUp; var colDown; var lumRight; var lumLeft; var lumUp; var lumDown;
			if (!isInverted){
				while(currIdx < maxIdx){
					currRowIdx = currIdx;
					maxRowIdx = (currIdx + aImg.width);
					while(currIdx < maxRowIdx){
						colOrig = (colOut = aImg.pixels.getPixel(currIdx));
						idxLeft = (currIdx - 1);
						idxRight = (currIdx + 1);
						idxUp = (currIdx - aImg.width);
						idxDown = (currIdx + aImg.width);
						if (idxLeft < currRowIdx){
							idxLeft = currIdx;
						}
						if (idxRight >= maxRowIdx){
							idxRight = currIdx;
						}
						if (idxUp < 0){
							idxUp = 0;
						}
						if (idxDown >= maxIdx){
							idxDown = currIdx;
						}
						colUp = aImg.pixels.getPixel(idxUp);
						colLeft = aImg.pixels.getPixel(idxLeft);
						colDown = aImg.pixels.getPixel(idxDown);
						colRight = aImg.pixels.getPixel(idxRight);
						currLum = (((77 * ((colOrig >> 16) & -1)) + (151 * ((colOrig >> 8) & -1))) + (28 * (colOrig & -1)));
						lumLeft = (((77 * ((colLeft >> 16) & -1)) + (151 * ((colLeft >> 8) & -1))) + (28 * (colLeft & -1)));
						lumRight = (((77 * ((colRight >> 16) & -1)) + (151 * ((colRight >> 8) & -1))) + (28 * (colRight & -1)));
						lumUp = (((77 * ((colUp >> 16) & -1)) + (151 * ((colUp >> 8) & -1))) + (28 * (colUp & -1)));
						lumDown = (((77 * ((colDown >> 16) & -1)) + (151 * ((colDown >> 8) & -1))) + (28 * (colDown & -1)));
						if (lumLeft > currLum){
							colOut = colLeft;
							currLum = lumLeft;
						}
						if (lumRight > currLum){
							colOut = colRight;
							currLum = lumRight;
						}
						if (lumUp > currLum){
							colOut = colUp;
							currLum = lumUp;
						}
						if (lumDown > currLum){
							colOut = colDown;
							currLum = lumDown;
						}
						out[currIdx++] = colOut;
					}
				}
			}			else
{
				while(currIdx < maxIdx){
					currRowIdx = currIdx;
					maxRowIdx = (currIdx + aImg.width);
					while(currIdx < maxRowIdx){
						colOrig = (colOut = aImg.pixels.getPixel(currIdx));
						idxLeft = (currIdx - 1);
						idxRight = (currIdx + 1);
						idxUp = (currIdx - aImg.width);
						idxDown = (currIdx + aImg.width);
						if (idxLeft < currRowIdx){
							idxLeft = currIdx;
						}
						if (idxRight >= maxRowIdx){
							idxRight = currIdx;
						}
						if (idxUp < 0){
							idxUp = 0;
						}
						if (idxDown >= maxIdx){
							idxDown = currIdx;
						}
						colUp = aImg.pixels.getPixel(idxUp);
						colLeft = aImg.pixels.getPixel(idxLeft);
						colDown = aImg.pixels.getPixel(idxDown);
						colRight = aImg.pixels.getPixel(idxRight);
						currLum = (((77 * ((colOrig >> 16) & -1)) + (151 * ((colOrig >> 8) & -1))) + (28 * (colOrig & -1)));
						lumLeft = (((77 * ((colLeft >> 16) & -1)) + (151 * ((colLeft >> 8) & -1))) + (28 * (colLeft & -1)));
						lumRight = (((77 * ((colRight >> 16) & -1)) + (151 * ((colRight >> 8) & -1))) + (28 * (colRight & -1)));
						lumUp = (((77 * ((colUp >> 16) & -1)) + (151 * ((colUp >> 8) & -1))) + (28 * (colUp & -1)));
						lumDown = (((77 * ((colDown >> 16) & -1)) + (151 * ((colDown >> 8) & -1))) + (28 * (colDown & -1)));
						if (lumLeft < currLum){
							colOut = colLeft;
							currLum = lumLeft;
						}
						if (lumRight < currLum){
							colOut = colRight;
							currLum = lumRight;
						}
						if (lumUp < currLum){
							colOut = colUp;
							currLum = lumUp;
						}
						if (lumDown < currLum){
							colOut = colDown;
							currLum = lumDown;
						}
						out[currIdx++] = colOut;
					}
				}
			}
			aImg.pixels.set(out);
		});
		p.filter = 		(function (kind, param, aImg){
			var img; var col; var lum; var i;
			if (arguments.length === 3){
				aImg.loadPixels();
				img = aImg;
			}			else
{
				p.loadPixels();
				img = p;
			}
			if (param === undef){
				param = null;
			}
			if (img.isRemote){
				throw "Image is loaded remotely. Cannot filter image.";
			}			else
{
				var imglen = img.pixels.getLength();
				switch(kind) {
					case PConstants.BLUR:
{
						var radius = param || 1;
						blurARGB(radius, img);
						break ;
					}					case PConstants.GRAY:
{
						if (img.format === PConstants.ALPHA){
							for(i = 0; i < imglen;i++){
								col = (255 - img.pixels.getPixel(i));
								img.pixels.setPixel(i, ((-16777216 | (col << 16)) | (col << 8)) | col);
							}
							img.format = PConstants.RGB;
						}						else
{
							for(i = 0; i < imglen;i++){
								col = img.pixels.getPixel(i);
								lum = ((((77 * ((col >> 16) & -1)) + (151 * ((col >> 8) & -1))) + (28 * (col & -1))) >> 8);
								img.pixels.setPixel(i, (((col & PConstants.ALPHA_MASK) | (lum << 16)) | (lum << 8)) | lum);
							}
						}
						break ;
					}					case PConstants.INVERT:
{
						for(i = 0; i < imglen;i++){
							img.pixels.setPixel(i, img.pixels.getPixel(i) ^ -1);
						}
						break ;
					}					case PConstants.POSTERIZE:
{
						if (param === null){
							throw "Use filter(POSTERIZE, int levels) instead of filter(POSTERIZE)";
						}
						var levels = p.floor(param);
						if ((levels < 2) || (levels > 255)){
							throw "Levels must be between 2 and 255 for filter(POSTERIZE, levels)";
						}
						var levels1 = levels - 1;
						for(i = 0; i < imglen;i++){
							var rlevel = (img.pixels.getPixel(i) >> 16) & -1;
							var glevel = (img.pixels.getPixel(i) >> 8) & -1;
							var blevel = img.pixels.getPixel(i) & -1;
							rlevel = ((((rlevel * levels) >> 8) * 255) / levels1);
							glevel = ((((glevel * levels) >> 8) * 255) / levels1);
							blevel = ((((blevel * levels) >> 8) * 255) / levels1);
							img.pixels.setPixel(i, (((-16777216 & img.pixels.getPixel(i)) | (rlevel << 16)) | (glevel << 8)) | blevel);
						}
						break ;
					}					case PConstants.OPAQUE:
{
						for(i = 0; i < imglen;i++){
							img.pixels.setPixel(i, img.pixels.getPixel(i) | -16777216);
						}
						img.format = PConstants.RGB;
						break ;
					}					case PConstants.THRESHOLD:
{
						if (param === null){
							param = 0.5;
						}
						if ((param < 0) || (param > 1)){
							throw "Level must be between 0 and 1 for filter(THRESHOLD, level)";
						}
						var thresh = p.floor(param * 255);
						for(i = 0; i < imglen;i++){
							var max = p.max((img.pixels.getPixel(i) & PConstants.RED_MASK) >> 16, p.max((img.pixels.getPixel(i) & PConstants.GREEN_MASK) >> 8, img.pixels.getPixel(i) & PConstants.BLUE_MASK));
							img.pixels.setPixel(i, (img.pixels.getPixel(i) & PConstants.ALPHA_MASK) | ((max < thresh) ? 0 : -1));
						}
						break ;
					}					case PConstants.ERODE:
{
						dilate(true, img);
						break ;
					}					case PConstants.DILATE:
{
						dilate(false, img);
						break ;
					}}
				img.updatePixels();
			}
		});
		p.shared = {		fracU:0, 		ifU:0, 		fracV:0, 		ifV:0, 		u1:0, 		u2:0, 		v1:0, 		v2:0, 		sX:0, 		sY:0, 		iw:0, 		iw1:0, 		ih1:0, 		ul:0, 		ll:0, 		ur:0, 		lr:0, 		cUL:0, 		cLL:0, 		cUR:0, 		cLR:0, 		srcXOffset:0, 		srcYOffset:0, 		r:0, 		g:0, 		b:0, 		a:0, 		srcBuffer:null, 		blurRadius:0, 		blurKernelSize:0, 		blurKernel:null		};
		p.intersect = 		(function (sx1, sy1, sx2, sy2, dx1, dy1, dx2, dy2){
			var sw = (sx2 - sx1) + 1;
			var sh = (sy2 - sy1) + 1;
			var dw = (dx2 - dx1) + 1;
			var dh = (dy2 - dy1) + 1;
			if (dx1 < sx1){
				dw += (dx1 - sx1);
				if (dw > sw){
					dw = sw;
				}
			}			else
{
				var w = (sw + sx1) - dx1;
				if (dw > w){
					dw = w;
				}
			}
			if (dy1 < sy1){
				dh += (dy1 - sy1);
				if (dh > sh){
					dh = sh;
				}
			}			else
{
				var h = (sh + sy1) - dy1;
				if (dh > h){
					dh = h;
				}
			}
			return !((dw <= 0) || (dh <= 0));
		});
		p.filter_new_scanline = 		(function (){
			p.shared.sX = p.shared.srcXOffset;
			p.shared.fracV = (p.shared.srcYOffset & PConstants.PREC_MAXVAL);
			p.shared.ifV = (PConstants.PREC_MAXVAL - p.shared.fracV);
			p.shared.v1 = ((p.shared.srcYOffset >> PConstants.PRECISIONB) * p.shared.iw);
			p.shared.v2 = (Math.min((p.shared.srcYOffset >> PConstants.PRECISIONB) + 1, p.shared.ih1) * p.shared.iw);
		});
		p.filter_bilinear = 		(function (){
			p.shared.fracU = (p.shared.sX & PConstants.PREC_MAXVAL);
			p.shared.ifU = (PConstants.PREC_MAXVAL - p.shared.fracU);
			p.shared.ul = ((p.shared.ifU * p.shared.ifV) >> PConstants.PRECISIONB);
			p.shared.ll = ((p.shared.ifU * p.shared.fracV) >> PConstants.PRECISIONB);
			p.shared.ur = ((p.shared.fracU * p.shared.ifV) >> PConstants.PRECISIONB);
			p.shared.lr = ((p.shared.fracU * p.shared.fracV) >> PConstants.PRECISIONB);
			p.shared.u1 = (p.shared.sX >> PConstants.PRECISIONB);
			p.shared.u2 = Math.min(p.shared.u1 + 1, p.shared.iw1);
			var cULoffset = (p.shared.v1 + p.shared.u1) * 4;
			var cURoffset = (p.shared.v1 + p.shared.u2) * 4;
			var cLLoffset = (p.shared.v2 + p.shared.u1) * 4;
			var cLRoffset = (p.shared.v2 + p.shared.u2) * 4;
			p.shared.cUL = p.color.toInt(p.shared.srcBuffer[cULoffset], p.shared.srcBuffer[cULoffset + 1], p.shared.srcBuffer[cULoffset + 2], p.shared.srcBuffer[cULoffset + 3]);
			p.shared.cUR = p.color.toInt(p.shared.srcBuffer[cURoffset], p.shared.srcBuffer[cURoffset + 1], p.shared.srcBuffer[cURoffset + 2], p.shared.srcBuffer[cURoffset + 3]);
			p.shared.cLL = p.color.toInt(p.shared.srcBuffer[cLLoffset], p.shared.srcBuffer[cLLoffset + 1], p.shared.srcBuffer[cLLoffset + 2], p.shared.srcBuffer[cLLoffset + 3]);
			p.shared.cLR = p.color.toInt(p.shared.srcBuffer[cLRoffset], p.shared.srcBuffer[cLRoffset + 1], p.shared.srcBuffer[cLRoffset + 2], p.shared.srcBuffer[cLRoffset + 3]);
			p.shared.r = ((((((p.shared.ul * ((p.shared.cUL & PConstants.RED_MASK) >> 16)) + (p.shared.ll * ((p.shared.cLL & PConstants.RED_MASK) >> 16))) + (p.shared.ur * ((p.shared.cUR & PConstants.RED_MASK) >> 16))) + (p.shared.lr * ((p.shared.cLR & PConstants.RED_MASK) >> 16))) << PConstants.PREC_RED_SHIFT) & PConstants.RED_MASK);
			p.shared.g = ((((((p.shared.ul * (p.shared.cUL & PConstants.GREEN_MASK)) + (p.shared.ll * (p.shared.cLL & PConstants.GREEN_MASK))) + (p.shared.ur * (p.shared.cUR & PConstants.GREEN_MASK))) + (p.shared.lr * (p.shared.cLR & PConstants.GREEN_MASK))) >>> PConstants.PRECISIONB) & PConstants.GREEN_MASK);
			p.shared.b = (((((p.shared.ul * (p.shared.cUL & PConstants.BLUE_MASK)) + (p.shared.ll * (p.shared.cLL & PConstants.BLUE_MASK))) + (p.shared.ur * (p.shared.cUR & PConstants.BLUE_MASK))) + (p.shared.lr * (p.shared.cLR & PConstants.BLUE_MASK))) >>> PConstants.PRECISIONB);
			p.shared.a = ((((((p.shared.ul * ((p.shared.cUL & PConstants.ALPHA_MASK) >>> 24)) + (p.shared.ll * ((p.shared.cLL & PConstants.ALPHA_MASK) >>> 24))) + (p.shared.ur * ((p.shared.cUR & PConstants.ALPHA_MASK) >>> 24))) + (p.shared.lr * ((p.shared.cLR & PConstants.ALPHA_MASK) >>> 24))) << PConstants.PREC_ALPHA_SHIFT) & PConstants.ALPHA_MASK);
			return ((p.shared.a | p.shared.r) | p.shared.g) | p.shared.b;
		});
		p.blit_resize = 		(function (img, srcX1, srcY1, srcX2, srcY2, destPixels, screenW, screenH, destX1, destY1, destX2, destY2, mode){
			var x; var y;
			if (srcX1 < 0){
				srcX1 = 0;
			}
			if (srcY1 < 0){
				srcY1 = 0;
			}
			if (srcX2 >= img.width){
				srcX2 = (img.width - 1);
			}
			if (srcY2 >= img.height){
				srcY2 = (img.height - 1);
			}
			var srcW = srcX2 - srcX1;
			var srcH = srcY2 - srcY1;
			var destW = destX2 - destX1;
			var destH = destY2 - destY1;
			var smooth = true;
			if (!smooth){
				srcW++;
				srcH++;
			}
			if ((((((((destW <= 0) || (destH <= 0)) || (srcW <= 0)) || (srcH <= 0)) || (destX1 >= screenW)) || (destY1 >= screenH)) || (srcX1 >= img.width)) || (srcY1 >= img.height)){
				return ;
			}
			var dx = Math.floor((srcW / destW) * PConstants.PRECISIONF);
			var dy = Math.floor((srcH / destH) * PConstants.PRECISIONF);
			p.shared.srcXOffset = Math.floor((destX1 < 0) ? (-destX1 * dx) : (srcX1 * PConstants.PRECISIONF));
			p.shared.srcYOffset = Math.floor((destY1 < 0) ? (-destY1 * dy) : (srcY1 * PConstants.PRECISIONF));
			if (destX1 < 0){
				destW += destX1;
				destX1 = 0;
			}
			if (destY1 < 0){
				destH += destY1;
				destY1 = 0;
			}
			destW = Math.min(destW, screenW - destX1);
			destH = Math.min(destH, screenH - destY1);
			var destOffset = (destY1 * screenW) + destX1;
			var destColor;
			p.shared.srcBuffer = img.imageData.data;
			if (smooth){
				p.shared.iw = img.width;
				p.shared.iw1 = (img.width - 1);
				p.shared.ih1 = (img.height - 1);
				switch(mode) {
					case PConstants.BLEND:
{
						for(y = 0; y < destH;y++){
							p.filter_new_scanline();
							for(x = 0; x < destW;x++){
								destColor = p.color.toInt(destPixels[(destOffset + x) * 4], destPixels[((destOffset + x) * 4) + 1], destPixels[((destOffset + x) * 4) + 2], destPixels[((destOffset + x) * 4) + 3]);
								destColor = p.color.toArray(p.modes.blend(destColor, p.filter_bilinear()));
								destPixels[(destOffset + x) * 4] = destColor[0];
								destPixels[((destOffset + x) * 4) + 1] = destColor[1];
								destPixels[((destOffset + x) * 4) + 2] = destColor[2];
								destPixels[((destOffset + x) * 4) + 3] = destColor[3];
								p.shared.sX += dx;
							}
							destOffset += screenW;
							p.shared.srcYOffset += dy;
						}
						break ;
					}					case PConstants.ADD:
{
						for(y = 0; y < destH;y++){
							p.filter_new_scanline();
							for(x = 0; x < destW;x++){
								destColor = p.color.toInt(destPixels[(destOffset + x) * 4], destPixels[((destOffset + x) * 4) + 1], destPixels[((destOffset + x) * 4) + 2], destPixels[((destOffset + x) * 4) + 3]);
								destColor = p.color.toArray(p.modes.add(destColor, p.filter_bilinear()));
								destPixels[(destOffset + x) * 4] = destColor[0];
								destPixels[((destOffset + x) * 4) + 1] = destColor[1];
								destPixels[((destOffset + x) * 4) + 2] = destColor[2];
								destPixels[((destOffset + x) * 4) + 3] = destColor[3];
								p.shared.sX += dx;
							}
							destOffset += screenW;
							p.shared.srcYOffset += dy;
						}
						break ;
					}					case PConstants.SUBTRACT:
{
						for(y = 0; y < destH;y++){
							p.filter_new_scanline();
							for(x = 0; x < destW;x++){
								destColor = p.color.toInt(destPixels[(destOffset + x) * 4], destPixels[((destOffset + x) * 4) + 1], destPixels[((destOffset + x) * 4) + 2], destPixels[((destOffset + x) * 4) + 3]);
								destColor = p.color.toArray(p.modes.subtract(destColor, p.filter_bilinear()));
								destPixels[(destOffset + x) * 4] = destColor[0];
								destPixels[((destOffset + x) * 4) + 1] = destColor[1];
								destPixels[((destOffset + x) * 4) + 2] = destColor[2];
								destPixels[((destOffset + x) * 4) + 3] = destColor[3];
								p.shared.sX += dx;
							}
							destOffset += screenW;
							p.shared.srcYOffset += dy;
						}
						break ;
					}					case PConstants.LIGHTEST:
{
						for(y = 0; y < destH;y++){
							p.filter_new_scanline();
							for(x = 0; x < destW;x++){
								destColor = p.color.toInt(destPixels[(destOffset + x) * 4], destPixels[((destOffset + x) * 4) + 1], destPixels[((destOffset + x) * 4) + 2], destPixels[((destOffset + x) * 4) + 3]);
								destColor = p.color.toArray(p.modes.lightest(destColor, p.filter_bilinear()));
								destPixels[(destOffset + x) * 4] = destColor[0];
								destPixels[((destOffset + x) * 4) + 1] = destColor[1];
								destPixels[((destOffset + x) * 4) + 2] = destColor[2];
								destPixels[((destOffset + x) * 4) + 3] = destColor[3];
								p.shared.sX += dx;
							}
							destOffset += screenW;
							p.shared.srcYOffset += dy;
						}
						break ;
					}					case PConstants.DARKEST:
{
						for(y = 0; y < destH;y++){
							p.filter_new_scanline();
							for(x = 0; x < destW;x++){
								destColor = p.color.toInt(destPixels[(destOffset + x) * 4], destPixels[((destOffset + x) * 4) + 1], destPixels[((destOffset + x) * 4) + 2], destPixels[((destOffset + x) * 4) + 3]);
								destColor = p.color.toArray(p.modes.darkest(destColor, p.filter_bilinear()));
								destPixels[(destOffset + x) * 4] = destColor[0];
								destPixels[((destOffset + x) * 4) + 1] = destColor[1];
								destPixels[((destOffset + x) * 4) + 2] = destColor[2];
								destPixels[((destOffset + x) * 4) + 3] = destColor[3];
								p.shared.sX += dx;
							}
							destOffset += screenW;
							p.shared.srcYOffset += dy;
						}
						break ;
					}					case PConstants.REPLACE:
{
						for(y = 0; y < destH;y++){
							p.filter_new_scanline();
							for(x = 0; x < destW;x++){
								destColor = p.color.toInt(destPixels[(destOffset + x) * 4], destPixels[((destOffset + x) * 4) + 1], destPixels[((destOffset + x) * 4) + 2], destPixels[((destOffset + x) * 4) + 3]);
								if ((img.format !== PConstants.RGB) && (destPixels[(destOffset + x) * 4] !== 255)){
									destColor = p.color.toArray(p.modes.blend(destColor, p.filter_bilinear()));
								}								else
{
									destColor = p.color.toArray(p.filter_bilinear());
								}
								destPixels[(destOffset + x) * 4] = destColor[0];
								destPixels[((destOffset + x) * 4) + 1] = destColor[1];
								destPixels[((destOffset + x) * 4) + 2] = destColor[2];
								destPixels[((destOffset + x) * 4) + 3] = destColor[3];
								p.shared.sX += dx;
							}
							destOffset += screenW;
							p.shared.srcYOffset += dy;
						}
						break ;
					}					case PConstants.DIFFERENCE:
{
						for(y = 0; y < destH;y++){
							p.filter_new_scanline();
							for(x = 0; x < destW;x++){
								destColor = p.color.toInt(destPixels[(destOffset + x) * 4], destPixels[((destOffset + x) * 4) + 1], destPixels[((destOffset + x) * 4) + 2], destPixels[((destOffset + x) * 4) + 3]);
								destColor = p.color.toArray(p.modes.difference(destColor, p.filter_bilinear()));
								destPixels[(destOffset + x) * 4] = destColor[0];
								destPixels[((destOffset + x) * 4) + 1] = destColor[1];
								destPixels[((destOffset + x) * 4) + 2] = destColor[2];
								destPixels[((destOffset + x) * 4) + 3] = destColor[3];
								p.shared.sX += dx;
							}
							destOffset += screenW;
							p.shared.srcYOffset += dy;
						}
						break ;
					}					case PConstants.EXCLUSION:
{
						for(y = 0; y < destH;y++){
							p.filter_new_scanline();
							for(x = 0; x < destW;x++){
								destColor = p.color.toInt(destPixels[(destOffset + x) * 4], destPixels[((destOffset + x) * 4) + 1], destPixels[((destOffset + x) * 4) + 2], destPixels[((destOffset + x) * 4) + 3]);
								destColor = p.color.toArray(p.modes.exclusion(destColor, p.filter_bilinear()));
								destPixels[(destOffset + x) * 4] = destColor[0];
								destPixels[((destOffset + x) * 4) + 1] = destColor[1];
								destPixels[((destOffset + x) * 4) + 2] = destColor[2];
								destPixels[((destOffset + x) * 4) + 3] = destColor[3];
								p.shared.sX += dx;
							}
							destOffset += screenW;
							p.shared.srcYOffset += dy;
						}
						break ;
					}					case PConstants.MULTIPLY:
{
						for(y = 0; y < destH;y++){
							p.filter_new_scanline();
							for(x = 0; x < destW;x++){
								destColor = p.color.toInt(destPixels[(destOffset + x) * 4], destPixels[((destOffset + x) * 4) + 1], destPixels[((destOffset + x) * 4) + 2], destPixels[((destOffset + x) * 4) + 3]);
								destColor = p.color.toArray(p.modes.multiply(destColor, p.filter_bilinear()));
								destPixels[(destOffset + x) * 4] = destColor[0];
								destPixels[((destOffset + x) * 4) + 1] = destColor[1];
								destPixels[((destOffset + x) * 4) + 2] = destColor[2];
								destPixels[((destOffset + x) * 4) + 3] = destColor[3];
								p.shared.sX += dx;
							}
							destOffset += screenW;
							p.shared.srcYOffset += dy;
						}
						break ;
					}					case PConstants.SCREEN:
{
						for(y = 0; y < destH;y++){
							p.filter_new_scanline();
							for(x = 0; x < destW;x++){
								destColor = p.color.toInt(destPixels[(destOffset + x) * 4], destPixels[((destOffset + x) * 4) + 1], destPixels[((destOffset + x) * 4) + 2], destPixels[((destOffset + x) * 4) + 3]);
								destColor = p.color.toArray(p.modes.screen(destColor, p.filter_bilinear()));
								destPixels[(destOffset + x) * 4] = destColor[0];
								destPixels[((destOffset + x) * 4) + 1] = destColor[1];
								destPixels[((destOffset + x) * 4) + 2] = destColor[2];
								destPixels[((destOffset + x) * 4) + 3] = destColor[3];
								p.shared.sX += dx;
							}
							destOffset += screenW;
							p.shared.srcYOffset += dy;
						}
						break ;
					}					case PConstants.OVERLAY:
{
						for(y = 0; y < destH;y++){
							p.filter_new_scanline();
							for(x = 0; x < destW;x++){
								destColor = p.color.toInt(destPixels[(destOffset + x) * 4], destPixels[((destOffset + x) * 4) + 1], destPixels[((destOffset + x) * 4) + 2], destPixels[((destOffset + x) * 4) + 3]);
								destColor = p.color.toArray(p.modes.overlay(destColor, p.filter_bilinear()));
								destPixels[(destOffset + x) * 4] = destColor[0];
								destPixels[((destOffset + x) * 4) + 1] = destColor[1];
								destPixels[((destOffset + x) * 4) + 2] = destColor[2];
								destPixels[((destOffset + x) * 4) + 3] = destColor[3];
								p.shared.sX += dx;
							}
							destOffset += screenW;
							p.shared.srcYOffset += dy;
						}
						break ;
					}					case PConstants.HARD_LIGHT:
{
						for(y = 0; y < destH;y++){
							p.filter_new_scanline();
							for(x = 0; x < destW;x++){
								destColor = p.color.toInt(destPixels[(destOffset + x) * 4], destPixels[((destOffset + x) * 4) + 1], destPixels[((destOffset + x) * 4) + 2], destPixels[((destOffset + x) * 4) + 3]);
								destColor = p.color.toArray(p.modes.hard_light(destColor, p.filter_bilinear()));
								destPixels[(destOffset + x) * 4] = destColor[0];
								destPixels[((destOffset + x) * 4) + 1] = destColor[1];
								destPixels[((destOffset + x) * 4) + 2] = destColor[2];
								destPixels[((destOffset + x) * 4) + 3] = destColor[3];
								p.shared.sX += dx;
							}
							destOffset += screenW;
							p.shared.srcYOffset += dy;
						}
						break ;
					}					case PConstants.SOFT_LIGHT:
{
						for(y = 0; y < destH;y++){
							p.filter_new_scanline();
							for(x = 0; x < destW;x++){
								destColor = p.color.toInt(destPixels[(destOffset + x) * 4], destPixels[((destOffset + x) * 4) + 1], destPixels[((destOffset + x) * 4) + 2], destPixels[((destOffset + x) * 4) + 3]);
								destColor = p.color.toArray(p.modes.soft_light(destColor, p.filter_bilinear()));
								destPixels[(destOffset + x) * 4] = destColor[0];
								destPixels[((destOffset + x) * 4) + 1] = destColor[1];
								destPixels[((destOffset + x) * 4) + 2] = destColor[2];
								destPixels[((destOffset + x) * 4) + 3] = destColor[3];
								p.shared.sX += dx;
							}
							destOffset += screenW;
							p.shared.srcYOffset += dy;
						}
						break ;
					}					case PConstants.DODGE:
{
						for(y = 0; y < destH;y++){
							p.filter_new_scanline();
							for(x = 0; x < destW;x++){
								destColor = p.color.toInt(destPixels[(destOffset + x) * 4], destPixels[((destOffset + x) * 4) + 1], destPixels[((destOffset + x) * 4) + 2], destPixels[((destOffset + x) * 4) + 3]);
								destColor = p.color.toArray(p.modes.dodge(destColor, p.filter_bilinear()));
								destPixels[(destOffset + x) * 4] = destColor[0];
								destPixels[((destOffset + x) * 4) + 1] = destColor[1];
								destPixels[((destOffset + x) * 4) + 2] = destColor[2];
								destPixels[((destOffset + x) * 4) + 3] = destColor[3];
								p.shared.sX += dx;
							}
							destOffset += screenW;
							p.shared.srcYOffset += dy;
						}
						break ;
					}					case PConstants.BURN:
{
						for(y = 0; y < destH;y++){
							p.filter_new_scanline();
							for(x = 0; x < destW;x++){
								destColor = p.color.toInt(destPixels[(destOffset + x) * 4], destPixels[((destOffset + x) * 4) + 1], destPixels[((destOffset + x) * 4) + 2], destPixels[((destOffset + x) * 4) + 3]);
								destColor = p.color.toArray(p.modes.burn(destColor, p.filter_bilinear()));
								destPixels[(destOffset + x) * 4] = destColor[0];
								destPixels[((destOffset + x) * 4) + 1] = destColor[1];
								destPixels[((destOffset + x) * 4) + 2] = destColor[2];
								destPixels[((destOffset + x) * 4) + 3] = destColor[3];
								p.shared.sX += dx;
							}
							destOffset += screenW;
							p.shared.srcYOffset += dy;
						}
						break ;
					}}
			}
		});
				function PFont(name){
			this.name = "sans-serif";
			if (name !== undef){
				switch(name) {
					case "sans-serif":
{
					}					case "serif":
{
					}					case "monospace":
{
					}					case "fantasy":
{
					}					case "cursive":
{
						this.name = name;
						break ;
					}					default:
{
						this.name = (("\"" + name) + "\", sans-serif");
						break ;
					}}
			}
			this.origName = name;
		}
		PFont.prototype.width = 		(function (str){
			if ("measureText" in curContext){
				return curContext.measureText((typeofstr === "number") ? String.fromCharCode(str) : str).width / curTextSize;
			}			else
{
				return 0;
			}
		});
		PFont.list = 		(function (){
			return ["sans-serif","serif","monospace","fantasy","cursive"];
		});
		p.PFont = PFont;
		p.loadFont = 		(function (name){
			if ((name === undef) || (name.indexOf(".svg") === -1)){
				return new PFont(name);
			}			else
{
				var font = p.loadGlyphs(name);
				return {				name:name, 				glyph:true, 				units_per_em:font.units_per_em, 				horiz_adv_x:(1 / font.units_per_em) * font.horiz_adv_x, 				ascent:font.ascent, 				descent:font.descent, 				width:				(function (str){
					var width = 0;
					var len = str.length;
					for(var i = 0; i < len;i++){
						try{
							width += parseFloat(p.glyphLook(p.glyphTable[name], str[i]).horiz_adv_x);
						}catch( e ){
							Processing.debug(e);
						}
					}
					return width / p.glyphTable[name].units_per_em;
				})				};
			}
		});
		p.createFont = 		(function (name, size, smooth, charset){
			if (arguments.length === 2){
				p.textSize(size);
				return p.loadFont(name);
			}			else
{
				if (arguments.length === 3){
					p.textSize(size);
					return p.loadFont(name);
				}				else
{
					if (arguments.length === 4){
						p.textSize(size);
						return p.loadFont(name);
					}					else
{
						throw "incorrent number of parameters for createFont";
					}
				}
			}
		});
		p.textFont = 		(function (font, size){
			curTextFont = font;
			if (size){
				p.textSize(size);
			}			else
{
				var curContext = drawing.$ensureContext();
				curContext.font = ((curTextSize + "px ") + curTextFont.name);
			}
		});
		p.textSize = 		(function (size){
			if (size){
				curTextSize = size;
				var curContext = drawing.$ensureContext();
				curContext.font = ((curTextSize + "px ") + curTextFont.name);
			}
		});
		p.textAlign = 		(function (){
			if (arguments.length === 1){
				horizontalTextAlignment = arguments[0];
			}			else
{
				if (arguments.length === 2){
					horizontalTextAlignment = arguments[0];
					verticalTextAlignment = arguments[1];
				}
			}
		});
				function toP5String(obj){
			if (obj instanceof String){
				return obj;
			}			else
{
				if (typeofobj === 'number'){
					if (obj === (0 | obj)){
						return obj.toString();
					}					else
{
						return p.nf(obj, 0, 3);
					}
				}				else
{
					if ((obj === null) || (obj === undef)){
						return "";
					}					else
{
						return obj.toString();
					}
				}
			}
		}
		Drawing2D.prototype.textWidth = 		(function (str){
			var lines = toP5String(str).split(/\r?\n/g); var width = 0;
			var i; var linesCount = lines.length;
			curContext.font = ((curTextSize + "px ") + curTextFont.name);
			for(i = 0; i < linesCount;++i){
				width = Math.max(width, curContext.measureText(lines[i]).width);
			}
			return width;
		});
		Drawing3D.prototype.textWidth = 		(function (str){
			var lines = toP5String(str).split(/\r?\n/g); var width = 0;
			var i; var linesCount = lines.length;
			if (textcanvas === undef){
				textcanvas = document.createElement("canvas");
			}
			var textContext = textcanvas.getContext("2d");
			textContext.font = ((curTextSize + "px ") + curTextFont.name);
			for(i = 0; i < linesCount;++i){
				width = Math.max(width, textContext.measureText(lines[i]).width);
			}
			return width;
		});
		p.textLeading = 		(function (leading){
			curTextLeading = leading;
		});
				function MeasureTextCanvas(fontFace, fontSize, baseLine, text){
			this.canvas = document.createElement('canvas');
			this.canvas.setAttribute('width', fontSize + "px");
			this.canvas.setAttribute('height', fontSize + "px");
			this.ctx = this.canvas.getContext("2d");
			this.ctx.font = ((fontSize + "pt ") + fontFace);
			this.ctx.fillStyle = "black";
			this.ctx.fillRect(0, 0, fontSize, fontSize);
			this.ctx.fillStyle = "white";
			this.ctx.fillText(text, 0, baseLine);
			this.imageData = this.ctx.getImageData(0, 0, fontSize, fontSize);
			this.get = 			(function (x, y){
				return this.imageData.data[(y * (this.imageData.width * 4)) + (x * 4)];
			});
		}
		p.textAscent = 		(function (){
			var oldTextSize = undef; var oldTextFont = undef; var ascent = undef; var graphics = undef;
			return 			(function textAscent(){
				if ((oldTextFont !== curTextFont) || (oldTextSize !== curTextSize)){
					oldTextFont = curTextFont;
					oldTextSize = curTextSize;
					var found = false; var character = "k"; var colour = p.color(0); var top = 0; var bottom = curTextSize; var yLoc = curTextSize / 2;
					graphics = new MeasureTextCanvas(curTextFont.name, curTextSize, curTextSize, character);
					while(yLoc !== bottom){
						for(var xLoc = 0; xLoc < curTextSize;xLoc++){
							if (graphics.get(xLoc, yLoc) !== colour){
								found = true;
								xLoc = curTextSize;
							}
						}
						if (found){
							bottom = yLoc;
							found = false;
						}						else
{
							top = yLoc;
						}
						yLoc = Math.ceil((bottom + top) / 2);
					}
					ascent = (((curTextSize - 1) - yLoc) + 1);
					return ascent;
				}				else
{
					return ascent;
				}
			});
		})();
		p.textDescent = 		(function (){
			var oldTextSize = undef; var oldTextFont = undef; var descent = undef; var graphics = undef;
			return 			(function textDescent(){
				if ((oldTextFont !== curTextFont) || (oldTextSize !== curTextSize)){
					oldTextFont = curTextFont;
					oldTextSize = curTextSize;
					var found = false; var character = "p"; var colour = p.color(0); var top = 0; var bottom = curTextSize; var yLoc = curTextSize / 2;
					graphics = new MeasureTextCanvas(curTextFont.name, curTextSize, 0, character);
					while(yLoc !== bottom){
						for(var xLoc = 0; xLoc < curTextSize;xLoc++){
							if (graphics.get(xLoc, yLoc) !== colour){
								found = true;
								xLoc = curTextSize;
							}
						}
						if (found){
							top = yLoc;
							found = false;
						}						else
{
							bottom = yLoc;
						}
						yLoc = Math.ceil((bottom + top) / 2);
					}
					descent = (yLoc + 1);
					return descent;
				}				else
{
					return descent;
				}
			});
		})();
		p.glyphLook = 		(function (font, chr){
			try{
				switch(chr) {
					case "1":
{
						return font.one;
					}					case "2":
{
						return font.two;
					}					case "3":
{
						return font.three;
					}					case "4":
{
						return font.four;
					}					case "5":
{
						return font.five;
					}					case "6":
{
						return font.six;
					}					case "7":
{
						return font.seven;
					}					case "8":
{
						return font.eight;
					}					case "9":
{
						return font.nine;
					}					case "0":
{
						return font.zero;
					}					case " ":
{
						return font.space;
					}					case "$":
{
						return font.dollar;
					}					case "!":
{
						return font.exclam;
					}					case '"':
{
						return font.quotedbl;
					}					case "#":
{
						return font.numbersign;
					}					case "%":
{
						return font.percent;
					}					case "&":
{
						return font.ampersand;
					}					case "'":
{
						return font.quotesingle;
					}					case "(":
{
						return font.parenleft;
					}					case ")":
{
						return font.parenright;
					}					case "*":
{
						return font.asterisk;
					}					case "+":
{
						return font.plus;
					}					case ",":
{
						return font.comma;
					}					case "-":
{
						return font.hyphen;
					}					case ".":
{
						return font.period;
					}					case "/":
{
						return font.slash;
					}					case "_":
{
						return font.underscore;
					}					case ":":
{
						return font.colon;
					}					case ";":
{
						return font.semicolon;
					}					case "<":
{
						return font.less;
					}					case "=":
{
						return font.equal;
					}					case ">":
{
						return font.greater;
					}					case "?":
{
						return font.question;
					}					case "@":
{
						return font.at;
					}					case "[":
{
						return font.bracketleft;
					}					case "\\":
{
						return font.backslash;
					}					case "]":
{
						return font.bracketright;
					}					case "^":
{
						return font.asciicircum;
					}					case "`":
{
						return font.grave;
					}					case "{":
{
						return font.braceleft;
					}					case "|":
{
						return font.bar;
					}					case "}":
{
						return font.braceright;
					}					case "~":
{
						return font.asciitilde;
					}					default:
{
						return font[chr];
					}}
			}catch( e ){
				Processing.debug(e);
			}
		});
		Drawing2D.prototype.text$line = 		(function (str, x, y, z, align){
			var textWidth = 0; var xOffset = 0;
			if (!curTextFont.glyph){
				if (str && ("fillText" in curContext)){
					if (isFillDirty){
						curContext.fillStyle = p.color.toString(currentFillColor);
						isFillDirty = false;
					}
					if ((align === PConstants.RIGHT) || (align === PConstants.CENTER)){
						textWidth = curContext.measureText(str).width;
						if (align === PConstants.RIGHT){
							xOffset = -textWidth;
						}						else
{
							xOffset = (-textWidth / 2);
						}
					}
					curContext.fillText(str, x + xOffset, y);
				}
			}			else
{
				var font = p.glyphTable[curTextFont.name];
				saveContext();
				curContext.translate(x, y + curTextSize);
				if ((align === PConstants.RIGHT) || (align === PConstants.CENTER)){
					textWidth = font.width(str);
					if (align === PConstants.RIGHT){
						xOffset = -textWidth;
					}					else
{
						xOffset = (-textWidth / 2);
					}
				}
				var upem = font.units_per_em; var newScale = (1 / upem) * curTextSize;
				curContext.scale(newScale, newScale);
				for(var i = 0, len = str.length; i < len;i++){
					try{
						p.glyphLook(font, str[i]).draw();
					}catch( e ){
						Processing.debug(e);
					}
				}
				restoreContext();
			}
		});
		Drawing3D.prototype.text$line = 		(function (str, x, y, z, align){
			if (textcanvas === undef){
				textcanvas = document.createElement("canvas");
			}
			var oldContext = curContext;
			curContext = textcanvas.getContext("2d");
			curContext.font = ((curTextSize + "px ") + curTextFont.name);
			var textWidth = curContext.measureText(str).width;
			textcanvas.width = textWidth;
			textcanvas.height = curTextSize;
			curContext = textcanvas.getContext("2d");
			curContext.font = ((curTextSize + "px ") + curTextFont.name);
			curContext.textBaseline = "top";
			Drawing2D.prototype.text$line(str, 0, 0, 0, PConstants.LEFT);
			var aspect = textcanvas.width / textcanvas.height;
			curContext = oldContext;
			curContext.bindTexture(curContext.TEXTURE_2D, textTex);
			executeTexImage2D(textcanvas);
			curContext.texParameteri(curContext.TEXTURE_2D, curContext.TEXTURE_MAG_FILTER, curContext.LINEAR);
			curContext.texParameteri(curContext.TEXTURE_2D, curContext.TEXTURE_MIN_FILTER, curContext.LINEAR);
			curContext.texParameteri(curContext.TEXTURE_2D, curContext.TEXTURE_WRAP_T, curContext.CLAMP_TO_EDGE);
			curContext.texParameteri(curContext.TEXTURE_2D, curContext.TEXTURE_WRAP_S, curContext.CLAMP_TO_EDGE);
			var xOffset = 0;
			if (align === PConstants.RIGHT){
				xOffset = -textWidth;
			}			else
{
				if (align === PConstants.CENTER){
					xOffset = (-textWidth / 2);
				}
			}
			var model = new PMatrix3D();
			var scalefactor = curTextSize * 0.5;
			model.translate((x + xOffset) - (scalefactor / 2), y - scalefactor, z);
			model.scale(-aspect * scalefactor, -scalefactor, scalefactor);
			model.translate(-1, -1, -1);
			model.transpose();
			var view = new PMatrix3D();
			view.scale(1, -1, 1);
			view.apply(modelView.array());
			view.transpose();
			curContext.useProgram(programObject2D);
			vertexAttribPointer("vertex2d", programObject2D, "Vertex", 3, textBuffer);
			vertexAttribPointer("aTextureCoord2d", programObject2D, "aTextureCoord", 2, textureBuffer);
			uniformi("uSampler2d", programObject2D, "uSampler", [0]);
			uniformi("picktype2d", programObject2D, "picktype", 1);
			uniformMatrix("model2d", programObject2D, "model", false, model.array());
			uniformMatrix("view2d", programObject2D, "view", false, view.array());
			uniformf("color2d", programObject2D, "color", fillStyle);
			curContext.bindBuffer(curContext.ELEMENT_ARRAY_BUFFER, indexBuffer);
			curContext.drawElements(curContext.TRIANGLES, 6, curContext.UNSIGNED_SHORT, 0);
		});
				function text$4(str, x, y, z){
			var lines; var linesCount;
			if (str.indexOf('\n') < 0){
				lines = [str];
				linesCount = 1;
			}			else
{
				lines = str.split(/\r?\n/g);
				linesCount = lines.length;
			}
			var yOffset;
			if (verticalTextAlignment === PConstants.TOP){
				yOffset = ((1 - baselineOffset) * curTextLeading);
			}			else
{
				if (verticalTextAlignment === PConstants.CENTER){
					yOffset = (((1 - baselineOffset) - (linesCount / 2)) * curTextLeading);
				}				else
{
					if (verticalTextAlignment === PConstants.BOTTOM){
						yOffset = (((1 - baselineOffset) - linesCount) * curTextLeading);
					}					else
{
						yOffset = 0;
					}
				}
			}
			for(var i = 0; i < linesCount;++i){
				var line = lines[i];
				drawing.text$line(line, x, y + yOffset, z, horizontalTextAlignment);
				yOffset += curTextLeading;
			}
		}
				function text$6(str, x, y, width, height, z){
			if (((str.length === 0) || (width === 0)) || (height === 0)){
				return ;
			}
			if (curTextSize > height){
				return ;
			}
			var spaceMark = -1;
			var start = 0;
			var lineWidth = 0;
			var textboxWidth = width;
			var yOffset = 0;
			curContext.font = ((curTextSize + "px ") + curTextFont.name);
			var drawCommands = [];
			for(var charPos = 0, len = str.length; charPos < len;charPos++){
				var currentChar = str[charPos];
				var spaceChar = currentChar === " ";
				var letterWidth = curContext.measureText(currentChar).width;
				if ((currentChar !== "\n") && ((lineWidth + letterWidth) < textboxWidth)){
					if (spaceChar){
						spaceMark = charPos;
					}
					lineWidth += letterWidth;
				}				else
{
					if ((spaceMark + 1) === start){
						if (charPos > 0){
							spaceMark = charPos;
						}						else
{
							return ;
						}
					}
					if (currentChar === "\n"){
						drawCommands.push({						text:str.substring(start, charPos), 						width:lineWidth, 						offset:yOffset						});
						start = (charPos + 1);
					}					else
{
						drawCommands.push({						text:str.substring(start, spaceMark), 						width:lineWidth, 						offset:yOffset						});
						start = (spaceMark + 1);
					}
					yOffset += curTextLeading;
					lineWidth = 0;
					charPos = (start - 1);
				}
			}
			if (start < len){
				drawCommands.push({				text:str.substring(start), 				width:lineWidth, 				offset:yOffset				});
				yOffset += curTextSize;
			}
			var xOffset = 0;
			if (horizontalTextAlignment === PConstants.CENTER){
				xOffset = (width / 2);
			}			else
{
				if (horizontalTextAlignment === PConstants.RIGHT){
					xOffset = width;
				}
			}
			var boxYOffset1 = (1 - baselineOffset) * curTextSize; var boxYOffset2 = 0;
			if (verticalTextAlignment === PConstants.BOTTOM){
				boxYOffset2 = (height - (drawCommands.length * curTextLeading));
			}			else
{
				if (verticalTextAlignment === PConstants.CENTER){
					boxYOffset2 = ((height - (drawCommands.length * curTextLeading)) / 2);
				}
			}
			for(var command = 0, end = drawCommands.length; command < end;command++){
				var drawCommand = drawCommands[command];
				if ((drawCommand.offset + boxYOffset2) < 0){
					continue ;
				}
				if (((drawCommand.offset + boxYOffset2) + curTextSize) > height){
					break ;
				}
				drawing.text$line(drawCommand.text, x + xOffset, ((y + drawCommand.offset) + boxYOffset1) + boxYOffset2, z, horizontalTextAlignment);
			}
		}
		p.text = 		(function (){
			if (tMode === PConstants.SCREEN){
				p.pushMatrix();
				p.resetMatrix();
				var asc = p.textAscent();
				var des = p.textDescent();
				var tWidth = p.textWidth(arguments[0]);
				var tHeight = asc + des;
				var font = p.loadFont(curTextFont.origName);
				var hud = p.createGraphics(tWidth, tHeight);
				hud.beginDraw();
				hud.fill(currentFillColor);
				hud.opaque = false;
				hud.background(0, 0, 0, 0);
				hud.textFont(font);
				hud.textSize(curTextSize);
				hud.text(arguments[0], 0, asc);
				hud.endDraw();
				if ((arguments.length === 5) || (arguments.length === 6)){
					p.image(hud, arguments[1], arguments[2] - asc, arguments[3], arguments[4]);
				}				else
{
					p.image(hud, arguments[1], arguments[2] - asc);
				}
				p.popMatrix();
			}			else
{
				if (tMode === PConstants.SHAPE){
					return ;
				}				else
{
					if (arguments.length === 3){
						text$4(toP5String(arguments[0]), arguments[1], arguments[2], 0);
					}					else
{
						if (arguments.length === 4){
							text$4(toP5String(arguments[0]), arguments[1], arguments[2], arguments[3]);
						}						else
{
							if (arguments.length === 5){
								text$6(toP5String(arguments[0]), arguments[1], arguments[2], arguments[3], arguments[4], 0);
							}							else
{
								if (arguments.length === 6){
									text$6(toP5String(arguments[0]), arguments[1], arguments[2], arguments[3], arguments[4], arguments[5]);
								}
							}
						}
					}
				}
			}
		});
		p.textMode = 		(function (mode){
			tMode = mode;
		});
		p.loadGlyphs = 		(function (url){
			var x; var y; var cx; var cy; var nx; var ny; var d; var a; var lastCom; var lenC; var horiz_adv_x; var getXY = '[0-9\\-]+'; var path;
			var regex = 			(function (needle, hay){
				var i = 0; var results = []; var latest; var regexp = new RegExp(needle, "g");
				latest = (results[i] = regexp.exec(hay));
				while(latest){
					i++;
					latest = (results[i] = regexp.exec(hay));
				}
				return results;
			});
			var buildPath = 			(function (d){
				var c = regex("[A-Za-z][0-9\\- ]+|Z", d);
				path = "var path={draw:function(){saveContext();curContext.beginPath();";
				x = 0;
				y = 0;
				cx = 0;
				cy = 0;
				nx = 0;
				ny = 0;
				d = 0;
				a = 0;
				lastCom = "";
				lenC = (c.length - 1);
				for(var j = 0; j < lenC;j++){
					var com = c[j][0]; var xy = regex(getXY, com);
					switch(com[0]) {
						case "M":
{
							x = parseFloat(xy[0][0]);
							y = parseFloat(xy[1][0]);
							path += (((("curContext.moveTo(" + x) + ",") + -y) + ");");
							break ;
						}						case "L":
{
							x = parseFloat(xy[0][0]);
							y = parseFloat(xy[1][0]);
							path += (((("curContext.lineTo(" + x) + ",") + -y) + ");");
							break ;
						}						case "H":
{
							x = parseFloat(xy[0][0]);
							path += (((("curContext.lineTo(" + x) + ",") + -y) + ");");
							break ;
						}						case "V":
{
							y = parseFloat(xy[0][0]);
							path += (((("curContext.lineTo(" + x) + ",") + -y) + ");");
							break ;
						}						case "T":
{
							nx = parseFloat(xy[0][0]);
							ny = parseFloat(xy[1][0]);
							if ((lastCom === "Q") || (lastCom === "T")){
								d = Math.sqrt(Math.pow(x - cx, 2) + Math.pow(cy - y, 2));
								a = (Math.PI + Math.atan2(cx - x, cy - y));
								cx = (x + (Math.sin(a) * d));
								cy = (y + (Math.cos(a) * d));
							}							else
{
								cx = x;
								cy = y;
							}
							path += (((((((("curContext.quadraticCurveTo(" + cx) + ",") + -cy) + ",") + nx) + ",") + -ny) + ");");
							x = nx;
							y = ny;
							break ;
						}						case "Q":
{
							cx = parseFloat(xy[0][0]);
							cy = parseFloat(xy[1][0]);
							nx = parseFloat(xy[2][0]);
							ny = parseFloat(xy[3][0]);
							path += (((((((("curContext.quadraticCurveTo(" + cx) + ",") + -cy) + ",") + nx) + ",") + -ny) + ");");
							x = nx;
							y = ny;
							break ;
						}						case "Z":
{
							path += "curContext.closePath();";
							break ;
						}}
					lastCom = com[0];
				}
				path += "executeContextFill();executeContextStroke();";
				path += "restoreContext();";
				path += (("curContext.translate(" + horiz_adv_x) + ",0);");
				path += "}}";
				return path;
			});
			var parseSVGFont = 			(function (svg){
				var font = svg.getElementsByTagName("font");
				p.glyphTable[url].horiz_adv_x = font[0].getAttribute("horiz-adv-x");
				var font_face = svg.getElementsByTagName("font-face")[0];
				p.glyphTable[url].units_per_em = parseFloat(font_face.getAttribute("units-per-em"));
				p.glyphTable[url].ascent = parseFloat(font_face.getAttribute("ascent"));
				p.glyphTable[url].descent = parseFloat(font_face.getAttribute("descent"));
				var glyph = svg.getElementsByTagName("glyph"); var len = glyph.length;
				for(var i = 0; i < len;i++){
					var unicode = glyph[i].getAttribute("unicode");
					var name = glyph[i].getAttribute("glyph-name");
					horiz_adv_x = glyph[i].getAttribute("horiz-adv-x");
					if (horiz_adv_x === null){
						horiz_adv_x = p.glyphTable[url].horiz_adv_x;
					}
					d = glyph[i].getAttribute("d");
					if (d !== undef){
						path = buildPath(d);
						eval(path);
						p.glyphTable[url][name] = {						name:name, 						unicode:unicode, 						horiz_adv_x:horiz_adv_x, 						draw:path.draw						};
					}
				}
			});
			var loadXML = 			(function (){
				var xmlDoc;
				try{
					xmlDoc = document.implementation.createDocument("", "", null);
				}catch( e_fx_op ){
					Processing.debug(e_fx_op.message);
					return ;
				}
				try{
					xmlDoc.async = false;
					xmlDoc.load(url);
					parseSVGFont(xmlDoc.getElementsByTagName("svg")[0]);
				}catch( e_sf_ch ){
					Processing.debug(e_sf_ch);
					try{
						var xmlhttp = new window.XMLHttpRequest();
						xmlhttp.open("GET", url, false);
						xmlhttp.send(null);
						parseSVGFont(xmlhttp.responseXML.documentElement);
					}catch( e ){
						Processing.debug(e_sf_ch);
					}
				}
			});
			p.glyphTable[url] = {			};
			loadXML(url);
			return p.glyphTable[url];
		});
		p.param = 		(function (name){
			var attributeName = "data-processing-" + name;
			if (curElement.hasAttribute(attributeName)){
				return curElement.getAttribute(attributeName);
			}
			for(var i = 0, len = curElement.childNodes.length; i < len;++i){
				var item = curElement.childNodes.item(i);
				if ((item.nodeType !== 1) || (item.tagName.toLowerCase() !== "param")){
					continue ;
				}
				if (item.getAttribute("name") === name){
					return item.getAttribute("value");
				}
			}
			if (curSketch.params.hasOwnProperty(name)){
				return curSketch.params[name];
			}
			return null;
		});
				function wireDimensionalFunctions(mode){
			if (mode === '3D'){
				drawing = new Drawing3D();
			}			else
{
				if (mode === '2D'){
					drawing = new Drawing2D();
				}				else
{
					drawing = new DrawingPre();
				}
			}
			for(var i in DrawingPre.prototype){
				if (DrawingPre.prototype.hasOwnProperty(i) && (i.indexOf("$") < 0)){
					p[i] = drawing[i];
				}
			}
			drawing.$init();
		}
				function createDrawingPreFunction(name){
			return 			(function (){
				wireDimensionalFunctions("2D");
				return drawing[name].apply(this, arguments);
			});
		}
		DrawingPre.prototype.translate = createDrawingPreFunction("translate");
		DrawingPre.prototype.scale = createDrawingPreFunction("scale");
		DrawingPre.prototype.pushMatrix = createDrawingPreFunction("pushMatrix");
		DrawingPre.prototype.popMatrix = createDrawingPreFunction("popMatrix");
		DrawingPre.prototype.resetMatrix = createDrawingPreFunction("resetMatrix");
		DrawingPre.prototype.applyMatrix = createDrawingPreFunction("applyMatrix");
		DrawingPre.prototype.rotate = createDrawingPreFunction("rotate");
		DrawingPre.prototype.redraw = createDrawingPreFunction("redraw");
		DrawingPre.prototype.ambientLight = createDrawingPreFunction("ambientLight");
		DrawingPre.prototype.directionalLight = createDrawingPreFunction("directionalLight");
		DrawingPre.prototype.lightFalloff = createDrawingPreFunction("lightFalloff");
		DrawingPre.prototype.lightSpecular = createDrawingPreFunction("lightSpecular");
		DrawingPre.prototype.pointLight = createDrawingPreFunction("pointLight");
		DrawingPre.prototype.noLights = createDrawingPreFunction("noLights");
		DrawingPre.prototype.spotLight = createDrawingPreFunction("spotLight");
		DrawingPre.prototype.box = createDrawingPreFunction("box");
		DrawingPre.prototype.sphere = createDrawingPreFunction("sphere");
		DrawingPre.prototype.ambient = createDrawingPreFunction("ambient");
		DrawingPre.prototype.emissive = createDrawingPreFunction("emissive");
		DrawingPre.prototype.shininess = createDrawingPreFunction("shininess");
		DrawingPre.prototype.specular = createDrawingPreFunction("specular");
		DrawingPre.prototype.fill = createDrawingPreFunction("fill");
		DrawingPre.prototype.stroke = createDrawingPreFunction("stroke");
		DrawingPre.prototype.strokeWeight = createDrawingPreFunction("strokeWeight");
		DrawingPre.prototype.smooth = createDrawingPreFunction("smooth");
		DrawingPre.prototype.noSmooth = createDrawingPreFunction("noSmooth");
		DrawingPre.prototype.point = createDrawingPreFunction("point");
		DrawingPre.prototype.vertex = createDrawingPreFunction("vertex");
		DrawingPre.prototype.endShape = createDrawingPreFunction("endShape");
		DrawingPre.prototype.bezierVertex = createDrawingPreFunction("bezierVertex");
		DrawingPre.prototype.curveVertex = createDrawingPreFunction("curveVertex");
		DrawingPre.prototype.curve = createDrawingPreFunction("curve");
		DrawingPre.prototype.line = createDrawingPreFunction("line");
		DrawingPre.prototype.bezier = createDrawingPreFunction("bezier");
		DrawingPre.prototype.rect = createDrawingPreFunction("rect");
		DrawingPre.prototype.ellipse = createDrawingPreFunction("ellipse");
		DrawingPre.prototype.background = createDrawingPreFunction("background");
		DrawingPre.prototype.image = createDrawingPreFunction("image");
		DrawingPre.prototype.textWidth = createDrawingPreFunction("textWidth");
		DrawingPre.prototype.text$line = createDrawingPreFunction("text$line");
		DrawingPre.prototype.$ensureContext = createDrawingPreFunction("$ensureContext");
		DrawingPre.prototype.$newPMatrix = createDrawingPreFunction("$newPMatrix");
		DrawingPre.prototype.size = 		(function (aWidth, aHeight, aMode){
			wireDimensionalFunctions((aMode === PConstants.WEBGL) ? "3D" : "2D");
			p.size(aWidth, aHeight, aMode);
		});
		DrawingPre.prototype.$init = 		(function (){
		});
		Drawing2D.prototype.$init = 		(function (){
			p.size(p.width, p.height);
			curContext.translate(0.5, 0.5);
			curContext.lineCap = 'round';
			p.noSmooth();
			p.disableContextMenu();
		});
		Drawing3D.prototype.$init = 		(function (){
			p.use3DContext = true;
		});
		DrawingShared.prototype.$ensureContext = 		(function (){
			return curContext;
		});
				function extendClass(subClass, baseClass){
						function extendGetterSetter(propertyName){
				p.defineProperty(subClass, propertyName, {				get:				(function (){
					return baseClass[propertyName];
				}), 				set:				(function (v){
					baseClass[propertyName] = v;
				}), 				enumerable:true				});
			}
			var properties = [];
			for(var propertyName in baseClass){
				if (typeofbaseClass[propertyName] === 'function'){
					if (!subClass.hasOwnProperty(propertyName)){
						subClass[propertyName] = baseClass[propertyName];
					}
				}				else
{
					if ((propertyName.charAt(0) !== "$") && !(propertyName in subClass)){
						properties.push(propertyName);
					}
				}
			}
			while(properties.length > 0){
				extendGetterSetter(properties.shift());
			}
		}
		p.extendClassChain = 		(function (base){
			var path = [base];
			for(var self = base.$upcast; self;self = self.$upcast){
				extendClass(self, base);
				path.push(self);
				base = self;
			}
			while(path.length > 0){
				path.pop().$self = base;
			}
		});
		p.extendStaticMembers = 		(function (derived, base){
			extendClass(derived, base);
		});
		p.extendInterfaceMembers = 		(function (derived, base){
			extendClass(derived, base);
		});
		p.addMethod = 		(function (object, name, fn, superAccessor){
			if (object[name]){
				var args = fn.length; var oldfn = object[name];
				object[name] = 				(function (){
					if (arguments.length === args){
						return fn.apply(this, arguments);
					}					else
{
						return oldfn.apply(this, arguments);
					}
				});
			}			else
{
				object[name] = fn;
			}
		});
		p.createJavaArray = 		(function (type, bounds){
			var result = null;
			if (typeofbounds[0] === 'number'){
				var itemsCount = 0 | bounds[0];
				if (bounds.length <= 1){
					result = [];
					result.length = itemsCount;
					for(var i = 0; i < itemsCount;++i){
						result[i] = 0;
					}
				}				else
{
					result = [];
					var newBounds = bounds.slice(1);
					for(var j = 0; j < itemsCount;++j){
						result.push(p.createJavaArray(type, newBounds));
					}
				}
			}
			return result;
		});
				function attach(elem, type, fn){
			if (elem.addEventListener){
				elem.addEventListener(type, fn, false);
			}			else
{
				elem.attachEvent("on" + type, fn);
			}
			eventHandlers.push([elem,type,fn]);
		}
				function detach(elem, type, fn){
			if (elem.removeEventListener){
				elem.removeEventListener(type, fn, false);
			}			else
{
				if (elem.detachEvent){
					elem.detachEvent("on" + type, fn);
				}
			}
		}
				function calculateOffset(curElement, event){
			var element = curElement; var offsetX = 0; var offsetY = 0;
			p.pmouseX = p.mouseX;
			p.pmouseY = p.mouseY;
			if (element.offsetParent){
				do{
					offsetX += element.offsetLeft;
					offsetY += element.offsetTop;
				}while(!!(element = element.offsetParent));
			}
			element = curElement;
			do{
				offsetX -= (element.scrollLeft || 0);
				offsetY -= (element.scrollTop || 0);
			}while(!!(element = element.parentNode));
			offsetX += stylePaddingLeft;
			offsetY += stylePaddingTop;
			offsetX += styleBorderLeft;
			offsetY += styleBorderTop;
			offsetX += window.pageXOffset;
			offsetY += window.pageYOffset;
			return {			'X':offsetX, 			'Y':offsetY			};
		}
				function updateMousePosition(curElement, event){
			var offset = calculateOffset(curElement, event);
			p.mouseX = (event.pageX - offset.X);
			p.mouseY = (event.pageY - offset.Y);
		}
				function addTouchEventOffset(t){
			var offset = calculateOffset(t.changedTouches[0].target, t.changedTouches[0]); var i;
			for(i = 0; i < t.touches.length;i++){
				var touch = t.touches[i];
				touch.offsetX = (touch.pageX - offset.X);
				touch.offsetY = (touch.pageY - offset.Y);
			}
			for(i = 0; i < t.targetTouches.length;i++){
				var targetTouch = t.targetTouches[i];
				targetTouch.offsetX = (targetTouch.pageX - offset.X);
				targetTouch.offsetY = (targetTouch.pageY - offset.Y);
			}
			for(i = 0; i < t.changedTouches.length;i++){
				var changedTouch = t.changedTouches[i];
				changedTouch.offsetX = (changedTouch.pageX - offset.X);
				changedTouch.offsetY = (changedTouch.pageY - offset.Y);
			}
			return t;
		}
		attach(curElement, "touchstart", 		(function (t){
			curElement.setAttribute("style", "-webkit-user-select: none");
			curElement.setAttribute("onclick", "void(0)");
			curElement.setAttribute("style", "-webkit-tap-highlight-color:rgba(0,0,0,0)");
			for(var i = 0, ehl = eventHandlers.length; i < ehl;i++){
				var elem = eventHandlers[i][0]; var type = eventHandlers[i][1]; var fn = eventHandlers[i][2];
				if (((((((type === "mouseout") || (type === "mousemove")) || (type === "mousedown")) || (type === "mouseup")) || (type === "DOMMouseScroll")) || (type === "mousewheel")) || (type === "touchstart")){
					detach(elem, type, fn);
				}
			}
			if ((((p.touchStart !== undef) || (p.touchMove !== undef)) || (p.touchEnd !== undef)) || (p.touchCancel !== undef)){
				attach(curElement, "touchstart", 				(function (t){
					if (p.touchStart !== undef){
						t = addTouchEventOffset(t);
						p.touchStart(t);
					}
				}));
				attach(curElement, "touchmove", 				(function (t){
					if (p.touchMove !== undef){
						t.preventDefault();
						t = addTouchEventOffset(t);
						p.touchMove(t);
					}
				}));
				attach(curElement, "touchend", 				(function (t){
					if (p.touchEnd !== undef){
						t = addTouchEventOffset(t);
						p.touchEnd(t);
					}
				}));
				attach(curElement, "touchcancel", 				(function (t){
					if (p.touchCancel !== undef){
						t = addTouchEventOffset(t);
						p.touchCancel(t);
					}
				}));
			}			else
{
				attach(curElement, "touchstart", 				(function (e){
					updateMousePosition(curElement, e.touches[0]);
					p.__mousePressed = true;
					p.mouseDragging = false;
					p.mouseButton = PConstants.LEFT;
					if (typeofp.mousePressed === "function"){
						p.mousePressed();
					}
				}));
				attach(curElement, "touchmove", 				(function (e){
					e.preventDefault();
					updateMousePosition(curElement, e.touches[0]);
					if ((typeofp.mouseMoved === "function") && !p.__mousePressed){
						p.mouseMoved();
					}
					if ((typeofp.mouseDragged === "function") && p.__mousePressed){
						p.mouseDragged();
						p.mouseDragging = true;
					}
				}));
				attach(curElement, "touchend", 				(function (e){
					p.__mousePressed = false;
					if ((typeofp.mouseClicked === "function") && !p.mouseDragging){
						p.mouseClicked();
					}
					if (typeofp.mouseReleased === "function"){
						p.mouseReleased();
					}
				}));
			}
			curElement.dispatchEvent(t);
		}));
		attach(curElement, "mousemove", 		(function (e){
			updateMousePosition(curElement, e);
			if ((typeofp.mouseMoved === "function") && !p.__mousePressed){
				p.mouseMoved();
			}
			if ((typeofp.mouseDragged === "function") && p.__mousePressed){
				p.mouseDragged();
				p.mouseDragging = true;
			}
		}));
		attach(curElement, "mouseout", 		(function (e){
			if (typeofp.mouseOut === "function"){
				p.mouseOut();
			}
		}));
		attach(curElement, "mouseover", 		(function (e){
			updateMousePosition(curElement, e);
			if (typeofp.mouseOver === "function"){
				p.mouseOver();
			}
		}));
		attach(curElement, "mousedown", 		(function (e){
			p.__mousePressed = true;
			p.mouseDragging = false;
			switch(e.which) {
				case 1:
{
					p.mouseButton = PConstants.LEFT;
					break ;
				}				case 2:
{
					p.mouseButton = PConstants.CENTER;
					break ;
				}				case 3:
{
					p.mouseButton = PConstants.RIGHT;
					break ;
				}}
			if (typeofp.mousePressed === "function"){
				p.mousePressed();
			}
		}));
		attach(curElement, "mouseup", 		(function (e){
			p.__mousePressed = false;
			if ((typeofp.mouseClicked === "function") && !p.mouseDragging){
				p.mouseClicked();
			}
			if (typeofp.mouseReleased === "function"){
				p.mouseReleased();
			}
		}));
		var mouseWheelHandler = 		(function (e){
			var delta = 0;
			if (e.wheelDelta){
				delta = (e.wheelDelta / 120);
				if (window.opera){
					delta = -delta;
				}
			}			else
{
				if (e.detail){
					delta = (-e.detail / 3);
				}
			}
			p.mouseScroll = delta;
			if (delta && (typeofp.mouseScrolled === 'function')){
				p.mouseScrolled();
			}
		});
		attach(document, 'DOMMouseScroll', mouseWheelHandler);
		attach(document, 'mousewheel', mouseWheelHandler);
		if (typeofcurElement === "string"){
			curElement = document.getElementById(curElement);
		}
		if (!curElement.getAttribute("tabindex")){
			curElement.setAttribute("tabindex", 0);
		}
				function getKeyCode(e){
			var code = e.which || e.keyCode;
			switch(code) {
				case 13:
{
					return 10;
				}				case 91:
{
				}				case 93:
{
				}				case 224:
{
					return 157;
				}				case 57392:
{
					return 17;
				}				case 46:
{
					return 127;
				}				case 45:
{
					return 155;
				}}
			return code;
		}
				function getKeyChar(e){
			var c = e.which || e.keyCode;
			var anyShiftPressed = ((e.shiftKey || e.ctrlKey) || e.altKey) || e.metaKey;
			switch(c) {
				case 13:
{
					c = (anyShiftPressed ? 13 : 10);
					break ;
				}				case 8:
{
					c = (anyShiftPressed ? 127 : 8);
					break ;
				}}
			return new Char(c);
		}
				function suppressKeyEvent(e){
			if (typeofe.preventDefault === "function"){
				e.preventDefault();
			}			else
{
				if (typeofe.stopPropagation === "function"){
					e.stopPropagation();
				}
			}
			return false;
		}
				function updateKeyPressed(){
			var ch;
			for(ch in pressedKeysMap){
				if (pressedKeysMap.hasOwnProperty(ch)){
					p.__keyPressed = true;
					return ;
				}
			}
			p.__keyPressed = false;
		}
				function resetKeyPressed(){
			p.__keyPressed = false;
			pressedKeysMap = [];
			lastPressedKeyCode = null;
		}
				function simulateKeyTyped(code, c){
			pressedKeysMap[code] = c;
			lastPressedKeyCode = null;
			p.key = c;
			p.keyCode = code;
			p.keyPressed();
			p.keyCode = 0;
			p.keyTyped();
			updateKeyPressed();
		}
				function handleKeydown(e){
			var code = getKeyCode(e);
			if (code === PConstants.DELETE){
				simulateKeyTyped(code, new Char(127));
				return ;
			}
			if (codedKeys.indexOf(code) < 0){
				lastPressedKeyCode = code;
				return ;
			}
			var c = new Char(PConstants.CODED);
			p.key = c;
			p.keyCode = code;
			pressedKeysMap[code] = c;
			p.keyPressed();
			lastPressedKeyCode = null;
			updateKeyPressed();
			return suppressKeyEvent(e);
		}
				function handleKeypress(e){
			if (lastPressedKeyCode === null){
				return ;
			}
			var code = lastPressedKeyCode; var c = getKeyChar(e);
			simulateKeyTyped(code, c);
			return suppressKeyEvent(e);
		}
				function handleKeyup(e){
			var code = getKeyCode(e); var c = pressedKeysMap[code];
			if (c === undef){
				return ;
			}
			p.key = c;
			p.keyCode = code;
			p.keyReleased();
			deletepressedKeysMap[code];
			updateKeyPressed();
		}
		if (!pgraphicsMode){
			if (aCode instanceof Processing.Sketch){
				curSketch = aCode;
			}			else
{
				if (typeofaCode === "function"){
					curSketch = new Processing.Sketch(aCode);
				}				else
{
					if (!aCode){
						curSketch = new Processing.Sketch(						(function (){
						}));
					}					else
{
						curSketch = Processing.compile(aCode);
					}
				}
			}
			p.externals.sketch = curSketch;
			wireDimensionalFunctions();
			if ("mozOpaque" in curElement){
				curElement.mozOpaque = !curSketch.options.isTransparent;
			}
			curElement.onfocus = 			(function (){
				p.focused = true;
			});
			curElement.onblur = 			(function (){
				p.focused = false;
				if (!curSketch.options.globalKeyEvents){
					resetKeyPressed();
				}
			});
			if (curSketch.options.pauseOnBlur){
				attach(window, 'focus', 				(function (){
					if (doLoop){
						p.loop();
					}
				}));
				attach(window, 'blur', 				(function (){
					if (doLoop && loopStarted){
						p.noLoop();
						doLoop = true;
					}
					resetKeyPressed();
				}));
			}
			var keyTrigger = curSketch.options.globalKeyEvents ? window : curElement;
			attach(keyTrigger, "keydown", handleKeydown);
			attach(keyTrigger, "keypress", handleKeypress);
			attach(keyTrigger, "keyup", handleKeyup);
			for(var i in Processing.lib){
				if (Processing.lib.hasOwnProperty(i)){
					if (Processing.lib[i].hasOwnProperty("attach")){
						Processing.lib[i].attach(p);
					}					else
{
						if (Processing.lib[i] instanceof Function){
							Processing.lib[i].call(this);
						}
					}
				}
			}
			var executeSketch = 			(function (processing){
				if (!curSketch.imageCache.pending && curSketch.fonts.pending()){
					curSketch.attach(processing, defaultScope);
					if (processing.setup){
						processing.setup();
						if (curContext && !p.use3DContext){
							curContext.setTransform(1, 0, 0, 1, 0, 0);
						}
					}
					resetContext();
					if (processing.draw){
						if (!doLoop){
							processing.redraw();
						}						else
{
							processing.loop();
						}
					}
				}				else
{
					window.setTimeout(					(function (){
						executeSketch(processing);
					}), 10);
				}
			});
			addInstance(this);
			executeSketch(p);
		}		else
{
			curSketch = new Processing.Sketch();
			curSketch.options.isTransparent = true;
			wireDimensionalFunctions();
			p.size = 			(function (w, h, render){
				if (render && (render === PConstants.WEBGL)){
					wireDimensionalFunctions('3D');
				}				else
{
					wireDimensionalFunctions('2D');
				}
				if (render === PConstants.WEBGL){
					p.toImageData = 					(function (){
						var c = document.createElement("canvas");
						var ctx = c.getContext("2d");
						var obj = ctx.createImageData(this.width, this.height);
						var uBuff = new Uint8Array((this.width * this.height) * 4);
						curContext.readPixels(0, 0, this.width, this.height, curContext.RGBA, curContext.UNSIGNED_BYTE, uBuff);
						for(var i = 0, ul = uBuff.length, h = this.height, w = this.width, obj_data = obj.data; i < ul;i++){
							obj_data[i] = uBuff[((((h - 1) - Math.floor((i / 4) / w)) * w) * 4) + (i % (w * 4))];
						}
						return obj;
					});
				}				else
{
					p.toImageData = 					(function (){
						return curContext.getImageData(0, 0, this.width, this.height);
					});
				}
				p.size(w, h, render);
			});
		}
	});
	Processing.debug = debug;
	Processing.prototype = defaultScope;
		function getGlobalMembers(){
		var names = ["abs","acos","alpha","ambient","ambientLight","append","applyMatrix","arc","arrayCopy","asin","atan","atan2","background","beginCamera","beginDraw","beginShape","bezier","bezierDetail","bezierPoint","bezierTangent","bezierVertex","binary","blend","blendColor","blit_resize","blue","box","breakShape","brightness","camera","ceil","Character","color","colorMode","concat","console","constrain","copy","cos","createFont","createGraphics","createImage","cursor","curve","curveDetail","curvePoint","curveTangent","curveTightness","curveVertex","day","defaultColor","degrees","directionalLight","disableContextMenu","dist","draw","ellipse","ellipseMode","emissive","enableContextMenu","endCamera","endDraw","endShape","exit","exp","expand","externals","fill","filter","filter_bilinear","filter_new_scanline","floor","focused","frameCount","frameRate","frustum","get","glyphLook","glyphTable","green","height","hex","hint","hour","hue","image","imageMode","Import","intersect","join","key","keyCode","keyPressed","keyReleased","keyTyped","lerp","lerpColor","lightFalloff","lights","lightSpecular","line","link","loadBytes","loadFont","loadGlyphs","loadImage","loadPixels","loadShape","loadStrings","log","loop","mag","map","match","matchAll","max","millis","min","minute","mix","modelX","modelY","modelZ","modes","month","mouseButton","mouseClicked","mouseDragged","mouseMoved","mouseOut","mouseOver","mousePressed","mouseReleased","mouseScroll","mouseScrolled","mouseX","mouseY","name","nf","nfc","nfp","nfs","noCursor","noFill","noise","noiseDetail","noiseSeed","noLights","noLoop","norm","normal","noSmooth","noStroke","noTint","ortho","param","parseBoolean","parseByte","parseChar","parseFloat","parseInt","peg","perspective","PFont","PImage","pixels","PMatrix2D","PMatrix3D","PMatrixStack","pmouseX","pmouseY","point","pointLight","popMatrix","popStyle","pow","print","printCamera","println","printMatrix","printProjection","PShape","PShapeSVG","pushMatrix","pushStyle","quad","radians","random","Random","randomSeed","rect","rectMode","red","redraw","requestImage","resetMatrix","reverse","rotate","rotateX","rotateY","rotateZ","round","saturation","save","saveFrame","saveStrings","scale","screenX","screenY","screenZ","second","set","setup","shape","shapeMode","shared","shininess","shorten","sin","size","smooth","sort","specular","sphere","sphereDetail","splice","split","splitTokens","spotLight","sq","sqrt","status","str","stroke","strokeCap","strokeJoin","strokeWeight","subset","tan","text","textAlign","textAscent","textDescent","textFont","textLeading","textMode","textSize","texture","textureMode","textWidth","tint","touchCancel","touchEnd","touchMove","touchStart","translate","triangle","trim","unbinary","unhex","updatePixels","use3DContext","vertex","width","XMLElement","year","__contains","__equals","__frameRate","__hashCode","__int_cast","__instanceof","__keyPressed","__mousePressed","__printStackTrace","__replace","__replaceAll","__replaceFirst","__toCharArray","__split"];
		var members = {		};
		var i; var l;
		for(i = 0, l = names.length; i < l;++i){
			members[names[i]] = null;
		}
		for(var lib in Processing.lib){
			if (Processing.lib.hasOwnProperty(lib)){
				if (Processing.lib[lib].exports){
					var exportedNames = Processing.lib[lib].exports;
					for(i = 0, l = exportedNames.length; i < l;++i){
						members[exportedNames[i]] = null;
					}
				}
			}
		}
		return members;
	}
		function parseProcessing(code){
		var globalMembers = getGlobalMembers();
				function splitToAtoms(code){
			var atoms = [];
			var items = code.split(/([\{\[\(\)\]\}])/);
			var result = items[0];
			var stack = [];
			for(var i = 1; i < items.length;i += 2){
				var item = items[i];
				if (((item === '[') || (item === '{')) || (item === '(')){
					stack.push(result);
					result = item;
				}				else
{
					if (((item === ']') || (item === '}')) || (item === ')')){
						var kind = (item === '}') ? 'A' : ((item === ')') ? 'B' : 'C');
						var index = atoms.length;
						atoms.push(result + item);
						result = ((((stack.pop() + '"') + kind) + (index + 1)) + '"');
					}
				}
				result += items[i + 1];
			}
			atoms.unshift(result);
			return atoms;
		}
				function injectStrings(code, strings){
			return code.replace(/'(\d+)'/g, 			(function (all, index){
				var val = strings[index];
				if (val.charAt(0) === "/"){
					return val;
				}				else
{
					return /^'((?:[^'\\\n])|(?:\\.[0-9A-Fa-f]*))'$/.test(val) ? (("(new $p.Character(" + val) + "))") : val;
				}
			}));
		}
				function trimSpaces(string){
			var m1 = /^\s*/.exec(string); var result;
			if (m1[0].length === string.length){
				result = {				left:m1[0], 				middle:"", 				right:""				};
			}			else
{
				var m2 = /\s*$/.exec(string);
				result = {				left:m1[0], 				middle:string.substring(m1[0].length, m2.index), 				right:m2[0]				};
			}
			result.untrim = 			(function (t){
				return (this.left + t) + this.right;
			});
			return result;
		}
				function trim(string){
			return string.replace(/^\s+/, '').replace(/\s+$/, '');
		}
				function appendToLookupTable(table, array){
			for(var i = 0, l = array.length; i < l;++i){
				table[array[i]] = null;
			}
			return table;
		}
				function isLookupTableEmpty(table){
			for(var i in table){
				if (table.hasOwnProperty(i)){
					return false;
				}
			}
			return true;
		}
				function getAtomIndex(templ){
			return templ.substring(2, templ.length - 1);
		}
		var codeWoExtraCr = code.replace(/\r\n?|\n\r/g, "\n");
		var strings = [];
		var codeWoStrings = codeWoExtraCr.replace(/("(?:[^"\\\n]|\\.)*")|('(?:[^'\\\n]|\\.)*')|(([\[\(=|&!\^:?]\s*)(\/(?![*\/])(?:[^\/\\\n]|\\.)*\/[gim]*)\b)|(\/\/[^\n]*\n)|(\/\*(?:(?!\*\/)(?:.|\n))*\*\/)/g, 		(function (all, quoted, aposed, regexCtx, prefix, regex, singleComment, comment){
			var index;
			if (quoted || aposed){
				index = strings.length;
				strings.push(all);
				return ("'" + index) + "'";
			}			else
{
				if (regexCtx){
					index = strings.length;
					strings.push(regex);
					return ((prefix + "'") + index) + "'";
				}				else
{
					return (comment !== "") ? " " : "\n";
				}
			}
		}));
		var genericsWereRemoved;
		var codeWoGenerics = codeWoStrings;
		var replaceFunc = 		(function (all, before, types, after){
			if (!!before || !!after){
				return all;
			}
			genericsWereRemoved = true;
			return "";
		});
		do{
			genericsWereRemoved = false;
			codeWoGenerics = codeWoGenerics.replace(/([<]?)<\s*((?:\?|[A-Za-z_$][\w$]*\b(?:\s*\.\s*[A-Za-z_$][\w$]*\b)*)(?:\s+(?:extends|super)\s+[A-Za-z_$][\w$]*\b(?:\s*\.\s*[A-Za-z_$][\w$]*\b)*)?(?:\s*,\s*(?:\?|[A-Za-z_$][\w$]*\b(?:\s*\.\s*[A-Za-z_$][\w$]*\b)*)(?:\s+(?:extends|super)\s+[A-Za-z_$][\w$]*\b(?:\s*\.\s*[A-Za-z_$][\w$]*\b)*)?)*)\s*>([=]?)/g, replaceFunc);
		}while(genericsWereRemoved);
		var atoms = splitToAtoms(codeWoGenerics);
		var replaceContext;
		var declaredClasses = {		}; var currentClassId; var classIdSeed = 0;
				function addAtom(text, type){
			var lastIndex = atoms.length;
			atoms.push(text);
			return (('"' + type) + lastIndex) + '"';
		}
				function generateClassId(){
			return "class" + ++classIdSeed;
		}
				function appendClass(class_, classId, scopeId){
			class_.classId = classId;
			class_.scopeId = scopeId;
			declaredClasses[classId] = class_;
		}
		var transformClassBody; var transformInterfaceBody; var transformStatementsBlock; var transformStatements; var transformMain; var transformExpression;
		var classesRegex = /\b((?:(?:public|private|final|protected|static|abstract)\s+)*)(class|interface)\s+([A-Za-z_$][\w$]*\b)(\s+extends\s+[A-Za-z_$][\w$]*\b(?:\s*\.\s*[A-Za-z_$][\w$]*\b)*(?:\s*,\s*[A-Za-z_$][\w$]*\b(?:\s*\.\s*[A-Za-z_$][\w$]*\b)*\b)*)?(\s+implements\s+[A-Za-z_$][\w$]*\b(?:\s*\.\s*[A-Za-z_$][\w$]*\b)*(?:\s*,\s*[A-Za-z_$][\w$]*\b(?:\s*\.\s*[A-Za-z_$][\w$]*\b)*\b)*)?\s*("A\d+")/g;
		var methodsRegex = /\b((?:(?:public|private|final|protected|static|abstract|synchronized)\s+)*)((?!(?:else|new|return|throw|function|public|private|protected)\b)[A-Za-z_$][\w$]*\b(?:\s*\.\s*[A-Za-z_$][\w$]*\b)*(?:\s*"C\d+")*)\s*([A-Za-z_$][\w$]*\b)\s*("B\d+")(\s*throws\s+[A-Za-z_$][\w$]*\b(?:\s*\.\s*[A-Za-z_$][\w$]*\b)*(?:\s*,\s*[A-Za-z_$][\w$]*\b(?:\s*\.\s*[A-Za-z_$][\w$]*\b)*)*)?\s*("A\d+"|;)/g;
		var fieldTest = /^((?:(?:public|private|final|protected|static)\s+)*)((?!(?:else|new|return|throw)\b)[A-Za-z_$][\w$]*\b(?:\s*\.\s*[A-Za-z_$][\w$]*\b)*(?:\s*"C\d+")*)\s*([A-Za-z_$][\w$]*\b)\s*(?:"C\d+"\s*)*([=,]|$)/;
		var cstrsRegex = /\b((?:(?:public|private|final|protected|static|abstract)\s+)*)((?!(?:new|return|throw)\b)[A-Za-z_$][\w$]*\b)\s*("B\d+")(\s*throws\s+[A-Za-z_$][\w$]*\b(?:\s*\.\s*[A-Za-z_$][\w$]*\b)*(?:\s*,\s*[A-Za-z_$][\w$]*\b(?:\s*\.\s*[A-Za-z_$][\w$]*\b)*)*)?\s*("A\d+")/g;
		var attrAndTypeRegex = /^((?:(?:public|private|final|protected|static)\s+)*)((?!(?:new|return|throw)\b)[A-Za-z_$][\w$]*\b(?:\s*\.\s*[A-Za-z_$][\w$]*\b)*(?:\s*"C\d+")*)\s*/;
		var functionsRegex = /\bfunction(?:\s+([A-Za-z_$][\w$]*))?\s*("B\d+")\s*("A\d+")/g;
				function extractClassesAndMethods(code){
			var s = code;
			s = s.replace(classesRegex, 			(function (all){
				return addAtom(all, 'E');
			}));
			s = s.replace(methodsRegex, 			(function (all){
				return addAtom(all, 'D');
			}));
			s = s.replace(functionsRegex, 			(function (all){
				return addAtom(all, 'H');
			}));
			return s;
		}
				function extractConstructors(code, className){
			var result = code.replace(cstrsRegex, 			(function (all, attr, name, params, throws_, body){
				if (name !== className){
					return all;
				}				else
{
					return addAtom(all, 'G');
				}
			}));
			return result;
		}
				function AstParam(name){
			this.name = name;
		}
		AstParam.prototype.toString = 		(function (){
			return this.name;
		});
				function AstParams(params){
			this.params = params;
		}
		AstParams.prototype.getNames = 		(function (){
			var names = [];
			for(var i = 0, l = this.params.length; i < l;++i){
				names.push(this.params[i].name);
			}
			return names;
		});
		AstParams.prototype.toString = 		(function (){
			if (this.params.length === 0){
				return "()";
			}
			var result = "(";
			for(var i = 0, l = this.params.length; i < l;++i){
				result += (this.params[i] + ", ");
			}
			return result.substring(0, result.length - 2) + ")";
		});
				function transformParams(params){
			var paramsWoPars = trim(params.substring(1, params.length - 1));
			var result = [];
			if (paramsWoPars !== ""){
				var paramList = paramsWoPars.split(",");
				for(var i = 0; i < paramList.length;++i){
					var param = /\b([A-Za-z_$][\w$]*\b)(\s*"[ABC][\d]*")*\s*$/.exec(paramList[i]);
					result.push(new AstParam(param[1]));
				}
			}
			return new AstParams(result);
		}
				function preExpressionTransform(expr){
			var s = expr;
			s = s.replace(/\bnew\s+([A-Za-z_$][\w$]*\b(?:\s*\.\s*[A-Za-z_$][\w$]*\b)*)(?:\s*"C\d+")+\s*("A\d+")/g, 			(function (all, type, init){
				return init;
			}));
			s = s.replace(/\bnew\s+([A-Za-z_$][\w$]*\b(?:\s*\.\s*[A-Za-z_$][\w$]*\b)*)(?:\s*"B\d+")\s*("A\d+")/g, 			(function (all, type, init){
				return addAtom(all, 'F');
			}));
			s = s.replace(functionsRegex, 			(function (all){
				return addAtom(all, 'H');
			}));
			s = s.replace(/\bnew\s+([A-Za-z_$][\w$]*\b(?:\s*\.\s*[A-Za-z_$][\w$]*\b)*)\s*("C\d+"(?:\s*"C\d+")*)/g, 			(function (all, type, index){
				var args = index.replace(/"C(\d+)"/g, 				(function (all, j){
					return atoms[j];
				})).replace(/\[\s*\]/g, "[null]").replace(/\s*\]\s*\[\s*/g, ", ");
				var arrayInitializer = ("{" + args.substring(1, args.length - 1)) + "}";
				var createArrayArgs = ((("('" + type) + "', ") + addAtom(arrayInitializer, 'A')) + ")";
				return '$p.createJavaArray' + addAtom(createArrayArgs, 'B');
			}));
			s = s.replace(/(\.\s*length)\s*"B\d+"/g, "$1");
			s = s.replace(/#([0-9A-Fa-f]{6})\b/g, 			(function (all, digits){
				return "0xFF" + digits;
			}));
			s = s.replace(/"B(\d+)"(\s*(?:[\w$']|"B))/g, 			(function (all, index, next){
				var atom = atoms[index];
				if (!/^\(\s*[A-Za-z_$][\w$]*\b(?:\s*\.\s*[A-Za-z_$][\w$]*\b)*\s*(?:"C\d+"\s*)*\)$/.test(atom)){
					return all;
				}				else
{
					if (/^\(\s*int\s*\)$/.test(atom)){
						return "(int)" + next;
					}					else
{
						var indexParts = atom.split(/"C(\d+)"/g);
						if (indexParts.length > 1){
							if (!/^\[\s*\]$/.test(atoms[indexParts[1]])){
								return all;
							}
						}
						return "" + next;
					}
				}
			}));
			s = s.replace(/\(int\)([^,\]\)\}\?\:\*\+\-\/\^\|\%\&\~<\>\=]+)/g, 			(function (all, arg){
				var trimmed = trimSpaces(arg);
				return trimmed.untrim(("__int_cast(" + trimmed.middle) + ")");
			}));
			s = s.replace(/\bsuper(\s*"B\d+")/g, "$$superCstr$1").replace(/\bsuper(\s*\.)/g, "$$super$1");
			s = s.replace(/\b0+((\d*)(?:\.[\d*])?(?:[eE][\-\+]?\d+)?[fF]?)\b/, 			(function (all, numberWo0, intPart){
				if (numberWo0 === intPart){
					return all;
				}
				return (intPart === "") ? ("0" + numberWo0) : numberWo0;
			}));
			s = s.replace(/\b(\.?\d+\.?)[fF]\b/g, "$1");
			s = s.replace(/([^\s])%([^=\s])/g, "$1 % $2");
			s = s.replace(/\b(frameRate|keyPressed|mousePressed)\b(?!\s*"B)/g, "__$1");
			s = s.replace(/\b(boolean|byte|char|float|int)\s*"B/g, 			(function (all, name){
				return (("parse" + name.substring(0, 1).toUpperCase()) + name.substring(1)) + "\"B";
			}));
			s = s.replace(/\bpixels\s*(("C(\d+)")|\.length)?(\s*=(?!=)([^,\]\)\}]+))?/g, 			(function (all, indexOrLength, index, atomIndex, equalsPart, rightSide){
				if (index){
					var atom = atoms[atomIndex];
					if (equalsPart){
						return "pixels.setPixel" + addAtom(((("(" + atom.substring(1, atom.length - 1)) + ",") + rightSide) + ")", 'B');
					}					else
{
						return "pixels.getPixel" + addAtom(("(" + atom.substring(1, atom.length - 1)) + ")", 'B');
					}
				}				else
{
					if (indexOrLength){
						return "pixels.getLength" + addAtom("()", 'B');
					}					else
{
						if (equalsPart){
							return "pixels.set" + addAtom(("(" + rightSide) + ")", 'B');
						}						else
{
							return "pixels.toArray" + addAtom("()", 'B');
						}
					}
				}
			}));
			var repeatJavaReplacement;
						function replacePrototypeMethods(all, subject, method, atomIndex){
				var atom = atoms[atomIndex];
				repeatJavaReplacement = true;
				var trimmed = trimSpaces(atom.substring(1, atom.length - 1));
				return ("__" + method) + ((trimmed.middle === "") ? addAtom(("(" + subject.replace(/\.\s*$/, "")) + ")", 'B') : addAtom(((("(" + subject.replace(/\.\s*$/, "")) + ",") + trimmed.middle) + ")", 'B'));
			}
			do{
				repeatJavaReplacement = false;
				s = s.replace(/((?:'\d+'|\b[A-Za-z_$][\w$]*\s*(?:"[BC]\d+")*)\s*\.\s*(?:[A-Za-z_$][\w$]*\s*(?:"[BC]\d+"\s*)*\.\s*)*)(replace|replaceAll|replaceFirst|contains|equals|hashCode|toCharArray|printStackTrace|split)\s*"B(\d+)"/g, replacePrototypeMethods);
			}while(repeatJavaReplacement);
						function replaceInstanceof(all, subject, type){
				repeatJavaReplacement = true;
				return "__instanceof" + addAtom(((("(" + subject) + ", ") + type) + ")", 'B');
			}
			do{
				repeatJavaReplacement = false;
				s = s.replace(/((?:'\d+'|\b[A-Za-z_$][\w$]*\s*(?:"[BC]\d+")*)\s*(?:\.\s*[A-Za-z_$][\w$]*\s*(?:"[BC]\d+"\s*)*)*)instanceof\s+([A-Za-z_$][\w$]*\s*(?:\.\s*[A-Za-z_$][\w$]*)*)/g, replaceInstanceof);
			}while(repeatJavaReplacement);
			s = s.replace(/\bthis(\s*"B\d+")/g, "$$constr$1");
			return s;
		}
				function AstInlineClass(baseInterfaceName, body){
			this.baseInterfaceName = baseInterfaceName;
			this.body = body;
			body.owner = this;
		}
		AstInlineClass.prototype.toString = 		(function (){
			return ("new (" + this.body) + ")";
		});
				function transformInlineClass(class_){
			var m = new RegExp(/\bnew\s*([A-Za-z_$][\w$]*\s*(?:\.\s*[A-Za-z_$][\w$]*)*)\s*"B\d+"\s*"A(\d+)"/).exec(class_);
			var oldClassId = currentClassId; var newClassId = generateClassId();
			currentClassId = newClassId;
			var uniqueClassName = (m[1] + "$") + newClassId;
			var inlineClass = new AstInlineClass(uniqueClassName, transformClassBody(atoms[m[2]], uniqueClassName, "", "implements " + m[1]));
			appendClass(inlineClass, newClassId, oldClassId);
			currentClassId = oldClassId;
			return inlineClass;
		}
				function AstFunction(name, params, body){
			this.name = name;
			this.params = params;
			this.body = body;
		}
		AstFunction.prototype.toString = 		(function (){
			var oldContext = replaceContext;
			var names = appendToLookupTable({			"this":null			}, this.params.getNames());
			replaceContext = 			(function (subject){
				return names.hasOwnProperty(subject.name) ? subject.name : oldContext(subject);
			});
			var result = "function";
			if (this.name){
				result += (" " + this.name);
			}
			result += ((this.params + " ") + this.body);
			replaceContext = oldContext;
			return result;
		});
				function transformFunction(class_){
			var m = new RegExp(/\b([A-Za-z_$][\w$]*)\s*"B(\d+)"\s*"A(\d+)"/).exec(class_);
			return new AstFunction((m[1] !== "function") ? m[1] : null, transformParams(atoms[m[2]]), transformStatementsBlock(atoms[m[3]]));
		}
				function AstInlineObject(members){
			this.members = members;
		}
		AstInlineObject.prototype.toString = 		(function (){
			var oldContext = replaceContext;
			replaceContext = 			(function (subject){
				return (subject.name === "this") ? "this" : oldContext(subject);
			});
			var result = "";
			for(var i = 0, l = this.members.length; i < l;++i){
				if (this.members[i].label){
					result += (this.members[i].label + ": ");
				}
				result += (this.members[i].value.toString() + ", ");
			}
			replaceContext = oldContext;
			return result.substring(0, result.length - 2);
		});
				function transformInlineObject(obj){
			var members = obj.split(',');
			for(var i = 0; i < members.length;++i){
				var label = members[i].indexOf(':');
				if (label < 0){
					members[i] = {					value:transformExpression(members[i])					};
				}				else
{
					members[i] = {					label:trim(members[i].substring(0, label)), 					value:transformExpression(trim(members[i].substring(label + 1)))					};
				}
			}
			return new AstInlineObject(members);
		}
				function expandExpression(expr){
			if ((expr.charAt(0) === '(') || (expr.charAt(0) === '[')){
				return (expr.charAt(0) + expandExpression(expr.substring(1, expr.length - 1))) + expr.charAt(expr.length - 1);
			}			else
{
				if (expr.charAt(0) === '{'){
					if (/^\{\s*(?:[A-Za-z_$][\w$]*|'\d+')\s*:/.test(expr)){
						return ("{" + addAtom(expr.substring(1, expr.length - 1), 'I')) + "}";
					}					else
{
						return ("[" + expandExpression(expr.substring(1, expr.length - 1))) + "]";
					}
				}				else
{
					var trimmed = trimSpaces(expr);
					var result = preExpressionTransform(trimmed.middle);
					result = result.replace(/"[ABC](\d+)"/g, 					(function (all, index){
						return expandExpression(atoms[index]);
					}));
					return trimmed.untrim(result);
				}
			}
		}
				function replaceContextInVars(expr){
			return expr.replace(/(\.\s*)?(\b[A-Za-z_$][\w$]*\b)(\s*\.\s*(\b[A-Za-z_$][\w$]*\b)(\s*\()?)?/g, 			(function (all, memberAccessSign, identifier, suffix, subMember, callSign){
				if (memberAccessSign){
					return all;
				}				else
{
					var subject = {					name:identifier, 					member:subMember, 					callSign:!!callSign					};
					return replaceContext(subject) + ((suffix === undef) ? "" : suffix);
				}
			}));
		}
				function AstExpression(expr, transforms){
			this.expr = expr;
			this.transforms = transforms;
		}
		AstExpression.prototype.toString = 		(function (){
			var transforms = this.transforms;
			var expr = replaceContextInVars(this.expr);
			return expr.replace(/"!(\d+)"/g, 			(function (all, index){
				return transforms[index].toString();
			}));
		});
		transformExpression = 		(function (expr){
			var transforms = [];
			var s = expandExpression(expr);
			s = s.replace(/"H(\d+)"/g, 			(function (all, index){
				transforms.push(transformFunction(atoms[index]));
				return ('"!' + (transforms.length - 1)) + '"';
			}));
			s = s.replace(/"F(\d+)"/g, 			(function (all, index){
				transforms.push(transformInlineClass(atoms[index]));
				return ('"!' + (transforms.length - 1)) + '"';
			}));
			s = s.replace(/"I(\d+)"/g, 			(function (all, index){
				transforms.push(transformInlineObject(atoms[index]));
				return ('"!' + (transforms.length - 1)) + '"';
			}));
			return new AstExpression(s, transforms);
		});
				function AstVarDefinition(name, value, isDefault){
			this.name = name;
			this.value = value;
			this.isDefault = isDefault;
		}
		AstVarDefinition.prototype.toString = 		(function (){
			return (this.name + ' = ') + this.value;
		});
				function transformVarDefinition(def, defaultTypeValue){
			var eqIndex = def.indexOf("=");
			var name; var value; var isDefault;
			if (eqIndex < 0){
				name = def;
				value = defaultTypeValue;
				isDefault = true;
			}			else
{
				name = def.substring(0, eqIndex);
				value = transformExpression(def.substring(eqIndex + 1));
				isDefault = false;
			}
			return new AstVarDefinition(trim(name.replace(/(\s*"C\d+")+/g, "")), value, isDefault);
		}
				function getDefaultValueForType(type){
			if ((type === "int") || (type === "float")){
				return "0";
			}			else
{
				if (type === "boolean"){
					return "false";
				}				else
{
					if (type === "color"){
						return "0x00000000";
					}					else
{
						return "null";
					}
				}
			}
		}
				function AstVar(definitions, varType){
			this.definitions = definitions;
			this.varType = varType;
		}
		AstVar.prototype.getNames = 		(function (){
			var names = [];
			for(var i = 0, l = this.definitions.length; i < l;++i){
				names.push(this.definitions[i].name);
			}
			return names;
		});
		AstVar.prototype.toString = 		(function (){
			return "var " + this.definitions.join(",");
		});
				function AstStatement(expression){
			this.expression = expression;
		}
		AstStatement.prototype.toString = 		(function (){
			return this.expression.toString();
		});
				function transformStatement(statement){
			if (fieldTest.test(statement)){
				var attrAndType = attrAndTypeRegex.exec(statement);
				var definitions = statement.substring(attrAndType[0].length).split(",");
				var defaultTypeValue = getDefaultValueForType(attrAndType[2]);
				for(var i = 0; i < definitions.length;++i){
					definitions[i] = transformVarDefinition(definitions[i], defaultTypeValue);
				}
				return new AstVar(definitions, attrAndType[2]);
			}			else
{
				return new AstStatement(transformExpression(statement));
			}
		}
				function AstForExpression(initStatement, condition, step){
			this.initStatement = initStatement;
			this.condition = condition;
			this.step = step;
		}
		AstForExpression.prototype.toString = 		(function (){
			return ((((("(" + this.initStatement) + "; ") + this.condition) + "; ") + this.step) + ")";
		});
				function AstForInExpression(initStatement, container){
			this.initStatement = initStatement;
			this.container = container;
		}
		AstForInExpression.prototype.toString = 		(function (){
			var init = this.initStatement.toString();
			if (init.indexOf("=") >= 0){
				init = init.substring(0, init.indexOf("="));
			}
			return ((("(" + init) + " in ") + this.container) + ")";
		});
				function AstForEachExpression(initStatement, container){
			this.initStatement = initStatement;
			this.container = container;
		}
		AstForEachExpression.iteratorId = 0;
		AstForEachExpression.prototype.toString = 		(function (){
			var init = this.initStatement.toString();
			var iterator = "$it" + AstForEachExpression.iteratorId++;
			var variableName = init.replace(/^\s*var\s*/, "").split("=")[0];
			var initIteratorAndVariable = ((((("var " + iterator) + " = new $p.ObjectIterator(") + this.container) + "), ") + variableName) + " = void(0)";
			var nextIterationCondition = ((((iterator + ".hasNext() && ((") + variableName) + " = ") + iterator) + ".next()) || true)";
			return ((("(" + initIteratorAndVariable) + "; ") + nextIterationCondition) + ";)";
		});
				function transformForExpression(expr){
			var content;
			if (/\bin\b/.test(expr)){
				content = expr.substring(1, expr.length - 1).split(/\bin\b/g);
				return new AstForInExpression(transformStatement(trim(content[0])), transformExpression(content[1]));
			}			else
{
				if ((expr.indexOf(":") >= 0) && (expr.indexOf(";") < 0)){
					content = expr.substring(1, expr.length - 1).split(":");
					return new AstForEachExpression(transformStatement(trim(content[0])), transformExpression(content[1]));
				}				else
{
					content = expr.substring(1, expr.length - 1).split(";");
					return new AstForExpression(transformStatement(trim(content[0])), transformExpression(content[1]), transformExpression(content[2]));
				}
			}
		}
				function sortByWeight(array){
			array.sort(			(function (a, b){
				return b.weight - a.weight;
			}));
		}
				function AstInnerInterface(name, body, isStatic){
			this.name = name;
			this.body = body;
			this.isStatic = isStatic;
			body.owner = this;
		}
		AstInnerInterface.prototype.toString = 		(function (){
			return "" + this.body;
		});
				function AstInnerClass(name, body, isStatic){
			this.name = name;
			this.body = body;
			this.isStatic = isStatic;
			body.owner = this;
		}
		AstInnerClass.prototype.toString = 		(function (){
			return "" + this.body;
		});
				function transformInnerClass(class_){
			var m = classesRegex.exec(class_);
			classesRegex.lastIndex = 0;
			var isStatic = m[1].indexOf("static") >= 0;
			var body = atoms[getAtomIndex(m[6])]; var innerClass;
			var oldClassId = currentClassId; var newClassId = generateClassId();
			currentClassId = newClassId;
			if (m[2] === "interface"){
				innerClass = new AstInnerInterface(m[3], transformInterfaceBody(body, m[3], m[4]), isStatic);
			}			else
{
				innerClass = new AstInnerClass(m[3], transformClassBody(body, m[3], m[4], m[5]), isStatic);
			}
			appendClass(innerClass, newClassId, oldClassId);
			currentClassId = oldClassId;
			return innerClass;
		}
				function AstClassMethod(name, params, body, isStatic){
			this.name = name;
			this.params = params;
			this.body = body;
			this.isStatic = isStatic;
		}
		AstClassMethod.prototype.toString = 		(function (){
			var paramNames = appendToLookupTable({			}, this.params.getNames());
			var oldContext = replaceContext;
			replaceContext = 			(function (subject){
				return paramNames.hasOwnProperty(subject.name) ? subject.name : oldContext(subject);
			});
			var result = (((("function " + this.methodId) + this.params) + " ") + this.body) + "\n";
			replaceContext = oldContext;
			return result;
		});
				function transformClassMethod(method){
			var m = methodsRegex.exec(method);
			methodsRegex.lastIndex = 0;
			var isStatic = m[1].indexOf("static") >= 0;
			var body = (m[6] !== ';') ? atoms[getAtomIndex(m[6])] : "{}";
			return new AstClassMethod(m[3], transformParams(atoms[getAtomIndex(m[4])]), transformStatementsBlock(body), isStatic);
		}
				function AstClassField(definitions, fieldType, isStatic){
			this.definitions = definitions;
			this.fieldType = fieldType;
			this.isStatic = isStatic;
		}
		AstClassField.prototype.getNames = 		(function (){
			var names = [];
			for(var i = 0, l = this.definitions.length; i < l;++i){
				names.push(this.definitions[i].name);
			}
			return names;
		});
		AstClassField.prototype.toString = 		(function (){
			var thisPrefix = replaceContext({			name:"[this]"			});
			if (this.isStatic){
				var className = this.owner.name;
				var staticDeclarations = [];
				for(var i = 0, l = this.definitions.length; i < l;++i){
					var definition = this.definitions[i];
					var name = definition.name; var staticName = (className + ".") + name;
					var declaration = ((((((((((((((((("if(" + staticName) + " === void(0)) {\n") + " ") + staticName) + " = ") + definition.value) + "; }\n") + "$p.defineProperty(") + thisPrefix) + ", ") + "'") + name) + "', { get: function(){return ") + staticName) + ";}, ") + "set: function(val){") + staticName) + " = val;} });\n";
					staticDeclarations.push(declaration);
				}
				return staticDeclarations.join("");
			}			else
{
				return (thisPrefix + ".") + this.definitions.join(("; " + thisPrefix) + ".");
			}
		});
				function transformClassField(statement){
			var attrAndType = attrAndTypeRegex.exec(statement);
			var isStatic = attrAndType[1].indexOf("static") >= 0;
			var definitions = statement.substring(attrAndType[0].length).split(/,\s*/g);
			var defaultTypeValue = getDefaultValueForType(attrAndType[2]);
			for(var i = 0; i < definitions.length;++i){
				definitions[i] = transformVarDefinition(definitions[i], defaultTypeValue);
			}
			return new AstClassField(definitions, attrAndType[2], isStatic);
		}
				function AstConstructor(params, body){
			this.params = params;
			this.body = body;
		}
		AstConstructor.prototype.toString = 		(function (){
			var paramNames = appendToLookupTable({			}, this.params.getNames());
			var oldContext = replaceContext;
			replaceContext = 			(function (subject){
				return paramNames.hasOwnProperty(subject.name) ? subject.name : oldContext(subject);
			});
			var prefix = ("function $constr_" + this.params.params.length) + this.params.toString();
			var body = this.body.toString();
			if (!/\$(superCstr|constr)\b/.test(body)){
				body = ("{\n$superCstr();\n" + body.substring(1));
			}
			replaceContext = oldContext;
			return (prefix + body) + "\n";
		});
				function transformConstructor(cstr){
			var m = new RegExp(/"B(\d+)"\s*"A(\d+)"/).exec(cstr);
			var params = transformParams(atoms[m[1]]);
			return new AstConstructor(params, transformStatementsBlock(atoms[m[2]]));
		}
				function AstInterfaceBody(name, interfacesNames, methodsNames, fields, innerClasses, misc){
			var i; var l;
			this.name = name;
			this.interfacesNames = interfacesNames;
			this.methodsNames = methodsNames;
			this.fields = fields;
			this.innerClasses = innerClasses;
			this.misc = misc;
			for(i = 0, l = fields.length; i < l;++i){
				fields[i].owner = this;
			}
		}
		AstInterfaceBody.prototype.getMembers = 		(function (classFields, classMethods, classInners){
			if (this.owner.base){
				this.owner.base.body.getMembers(classFields, classMethods, classInners);
			}
			var i; var j; var l; var m;
			for(i = 0, l = this.fields.length; i < l;++i){
				var fieldNames = this.fields[i].getNames();
				for(j = 0, m = fieldNames.length; j < m;++j){
					classFields[fieldNames[j]] = this.fields[i];
				}
			}
			for(i = 0, l = this.methodsNames.length; i < l;++i){
				var methodName = this.methodsNames[i];
				classMethods[methodName] = true;
			}
			for(i = 0, l = this.innerClasses.length; i < l;++i){
				var innerClass = this.innerClasses[i];
				classInners[innerClass.name] = innerClass;
			}
		});
		AstInterfaceBody.prototype.toString = 		(function (){
						function getScopeLevel(p){
				var i = 0;
				while(p){
					++i;
					p = p.scope;
				}
				return i;
			}
			var scopeLevel = getScopeLevel(this.owner);
			var className = this.name;
			var staticDefinitions = "";
			var metadata = "";
			var thisClassFields = {			}; var thisClassMethods = {			}; var thisClassInners = {			};
			this.getMembers(thisClassFields, thisClassMethods, thisClassInners);
			var i; var l; var j; var m;
			if (this.owner.interfaces){
				var resolvedInterfaces = []; var resolvedInterface;
				for(i = 0, l = this.interfacesNames.length; i < l;++i){
					if (!this.owner.interfaces[i]){
						continue ;
					}
					resolvedInterface = replaceContext({					name:this.interfacesNames[i]					});
					resolvedInterfaces.push(resolvedInterface);
					staticDefinitions += (((("$p.extendInterfaceMembers(" + className) + ", ") + resolvedInterface) + ");\n");
				}
				metadata += (((className + ".$interfaces = [") + resolvedInterfaces.join(", ")) + "];\n");
			}
			metadata += (className + ".$isInterface = true;\n");
			metadata += (((className + ".$methods = [\'") + this.methodsNames.join("\', \'")) + "\'];\n");
			sortByWeight(this.innerClasses);
			for(i = 0, l = this.innerClasses.length; i < l;++i){
				var innerClass = this.innerClasses[i];
				if (innerClass.isStatic){
					staticDefinitions += (((((className + ".") + innerClass.name) + " = ") + innerClass) + ";\n");
				}
			}
			for(i = 0, l = this.fields.length; i < l;++i){
				var field = this.fields[i];
				if (field.isStatic){
					staticDefinitions += (((className + ".") + field.definitions.join((";\n" + className) + ".")) + ";\n");
				}
			}
			return (((((((("(function() {\n" + "function ") + className) + "() { throw \'Unable to create the interface\'; }\n") + staticDefinitions) + metadata) + "return ") + className) + ";\n") + "})()";
		});
		transformInterfaceBody = 		(function (body, name, baseInterfaces){
			var declarations = body.substring(1, body.length - 1);
			declarations = extractClassesAndMethods(declarations);
			declarations = extractConstructors(declarations, name);
			var methodsNames = []; var classes = [];
			declarations = declarations.replace(/"([DE])(\d+)"/g, 			(function (all, type, index){
				if (type === 'D'){
					methodsNames.push(index);
				}				else
{
					if (type === 'E'){
						classes.push(index);
					}
				}
				return "";
			}));
			var fields = declarations.split(/;(?:\s*;)*/g);
			var baseInterfaceNames;
			var i; var l;
			if (baseInterfaces !== undef){
				baseInterfaceNames = baseInterfaces.replace(/^\s*extends\s+(.+?)\s*$/g, "$1").split(/\s*,\s*/g);
			}
			for(i = 0, l = methodsNames.length; i < l;++i){
				var method = transformClassMethod(atoms[methodsNames[i]]);
				methodsNames[i] = method.name;
			}
			for(i = 0, l = (fields.length - 1); i < l;++i){
				var field = trimSpaces(fields[i]);
				fields[i] = transformClassField(field.middle);
			}
			var tail = fields.pop();
			for(i = 0, l = classes.length; i < l;++i){
				classes[i] = transformInnerClass(atoms[classes[i]]);
			}
			return new AstInterfaceBody(name, baseInterfaceNames, methodsNames, fields, classes, {			tail:tail			});
		});
				function AstClassBody(name, baseClassName, interfacesNames, functions, methods, fields, cstrs, innerClasses, misc){
			var i; var l;
			this.name = name;
			this.baseClassName = baseClassName;
			this.interfacesNames = interfacesNames;
			this.functions = functions;
			this.methods = methods;
			this.fields = fields;
			this.cstrs = cstrs;
			this.innerClasses = innerClasses;
			this.misc = misc;
			for(i = 0, l = fields.length; i < l;++i){
				fields[i].owner = this;
			}
		}
		AstClassBody.prototype.getMembers = 		(function (classFields, classMethods, classInners){
			if (this.owner.base){
				this.owner.base.body.getMembers(classFields, classMethods, classInners);
			}
			var i; var j; var l; var m;
			for(i = 0, l = this.fields.length; i < l;++i){
				var fieldNames = this.fields[i].getNames();
				for(j = 0, m = fieldNames.length; j < m;++j){
					classFields[fieldNames[j]] = this.fields[i];
				}
			}
			for(i = 0, l = this.methods.length; i < l;++i){
				var method = this.methods[i];
				classMethods[method.name] = method;
			}
			for(i = 0, l = this.innerClasses.length; i < l;++i){
				var innerClass = this.innerClasses[i];
				classInners[innerClass.name] = innerClass;
			}
		});
		AstClassBody.prototype.toString = 		(function (){
						function getScopeLevel(p){
				var i = 0;
				while(p){
					++i;
					p = p.scope;
				}
				return i;
			}
			var scopeLevel = getScopeLevel(this.owner);
			var selfId = "$this_" + scopeLevel;
			var className = this.name;
			var result = ("var " + selfId) + " = this;\n";
			var staticDefinitions = "";
			var metadata = "";
			var thisClassFields = {			}; var thisClassMethods = {			}; var thisClassInners = {			};
			this.getMembers(thisClassFields, thisClassMethods, thisClassInners);
			var oldContext = replaceContext;
			replaceContext = 			(function (subject){
				var name = subject.name;
				if (name === "this"){
					return (subject.callSign || !subject.member) ? (selfId + ".$self") : selfId;
				}				else
{
					if (thisClassFields.hasOwnProperty(name)){
						return thisClassFields[name].isStatic ? ((className + ".") + name) : ((selfId + ".") + name);
					}					else
{
						if (thisClassInners.hasOwnProperty(name)){
							return (selfId + ".") + name;
						}						else
{
							if (thisClassMethods.hasOwnProperty(name)){
								return thisClassMethods[name].isStatic ? ((className + ".") + name) : ((selfId + ".$self.") + name);
							}
						}
					}
				}
				return oldContext(subject);
			});
			var resolvedBaseClassName;
			if (this.baseClassName){
				resolvedBaseClassName = oldContext({				name:this.baseClassName				});
				result += (("var $super = { $upcast: " + selfId) + " };\n");
				result += (("function $superCstr(){" + resolvedBaseClassName) + ".apply($super,arguments);if(!('$self' in $super)) $p.extendClassChain($super)}\n");
				metadata += (((className + ".$base = ") + resolvedBaseClassName) + ";\n");
			}			else
{
				result += (("function $superCstr(){$p.extendClassChain(" + selfId) + ")}\n");
			}
			if (this.owner.base){
				staticDefinitions += (((("$p.extendStaticMembers(" + className) + ", ") + resolvedBaseClassName) + ");\n");
			}
			var i; var l; var j; var m;
			if (this.owner.interfaces){
				var resolvedInterfaces = []; var resolvedInterface;
				for(i = 0, l = this.interfacesNames.length; i < l;++i){
					if (!this.owner.interfaces[i]){
						continue ;
					}
					resolvedInterface = oldContext({					name:this.interfacesNames[i]					});
					resolvedInterfaces.push(resolvedInterface);
					staticDefinitions += (((("$p.extendInterfaceMembers(" + className) + ", ") + resolvedInterface) + ");\n");
				}
				metadata += (((className + ".$interfaces = [") + resolvedInterfaces.join(", ")) + "];\n");
			}
			if (this.functions.length > 0){
				result += (this.functions.join('\n') + '\n');
			}
			sortByWeight(this.innerClasses);
			for(i = 0, l = this.innerClasses.length; i < l;++i){
				var innerClass = this.innerClasses[i];
				if (innerClass.isStatic){
					staticDefinitions += (((((className + ".") + innerClass.name) + " = ") + innerClass) + ";\n");
					result += (((((((selfId + ".") + innerClass.name) + " = ") + className) + ".") + innerClass.name) + ";\n");
				}				else
{
					result += (((((selfId + ".") + innerClass.name) + " = ") + innerClass) + ";\n");
				}
			}
			for(i = 0, l = this.fields.length; i < l;++i){
				var field = this.fields[i];
				if (field.isStatic){
					staticDefinitions += (((className + ".") + field.definitions.join((";\n" + className) + ".")) + ";\n");
					for(j = 0, m = field.definitions.length; j < m;++j){
						var fieldName = field.definitions[j].name; var staticName = (className + ".") + fieldName;
						result += (((((((((("$p.defineProperty(" + selfId) + ", '") + fieldName) + "', {") + "get: function(){return ") + staticName) + "}, ") + "set: function(val){") + staticName) + " = val}});\n");
					}
				}				else
{
					result += (((selfId + ".") + field.definitions.join((";\n" + selfId) + ".")) + ";\n");
				}
			}
			var methodOverloads = {			};
			for(i = 0, l = this.methods.length; i < l;++i){
				var method = this.methods[i];
				var overload = methodOverloads[method.name];
				var methodId = (method.name + "$") + method.params.params.length;
				if (overload){
					++overload;
					methodId += ("_" + overload);
				}				else
{
					overload = 1;
				}
				method.methodId = methodId;
				methodOverloads[method.name] = overload;
				if (method.isStatic){
					staticDefinitions += method;
					staticDefinitions += (((((("$p.addMethod(" + className) + ", '") + method.name) + "', ") + methodId) + ");\n");
					result += (((((("$p.addMethod(" + selfId) + ", '") + method.name) + "', ") + methodId) + ");\n");
				}				else
{
					result += method;
					result += (((((("$p.addMethod(" + selfId) + ", '") + method.name) + "', ") + methodId) + ");\n");
				}
			}
			result += trim(this.misc.tail);
			if (this.cstrs.length > 0){
				result += (this.cstrs.join('\n') + '\n');
			}
			result += "function $constr() {\n";
			var cstrsIfs = [];
			for(i = 0, l = this.cstrs.length; i < l;++i){
				var paramsLength = this.cstrs[i].params.params.length;
				cstrsIfs.push((((((("if(arguments.length === " + paramsLength) + ") { ") + "$constr_") + paramsLength) + ".apply(") + selfId) + ", arguments); }");
			}
			if (cstrsIfs.length > 0){
				result += (cstrsIfs.join(" else ") + " else ");
			}
			result += "$superCstr();\n}\n";
			result += "$constr.apply(null, arguments);\n";
			replaceContext = oldContext;
			return (((((((((("(function() {\n" + "function ") + className) + "() {\n") + result) + "}\n") + staticDefinitions) + metadata) + "return ") + className) + ";\n") + "})()";
		});
		transformClassBody = 		(function (body, name, baseName, interfaces){
			var declarations = body.substring(1, body.length - 1);
			declarations = extractClassesAndMethods(declarations);
			declarations = extractConstructors(declarations, name);
			var methods = []; var classes = []; var cstrs = []; var functions = [];
			declarations = declarations.replace(/"([DEGH])(\d+)"/g, 			(function (all, type, index){
				if (type === 'D'){
					methods.push(index);
				}				else
{
					if (type === 'E'){
						classes.push(index);
					}					else
{
						if (type === 'H'){
							functions.push(index);
						}						else
{
							cstrs.push(index);
						}
					}
				}
				return "";
			}));
			var fields = declarations.replace(/^(?:\s*;)+/, "").split(/;(?:\s*;)*/g);
			var baseClassName; var interfacesNames;
			var i;
			if (baseName !== undef){
				baseClassName = baseName.replace(/^\s*extends\s+([A-Za-z_$][\w$]*\b(?:\s*\.\s*[A-Za-z_$][\w$]*\b)*)\s*$/g, "$1");
			}
			if (interfaces !== undef){
				interfacesNames = interfaces.replace(/^\s*implements\s+(.+?)\s*$/g, "$1").split(/\s*,\s*/g);
			}
			for(i = 0; i < functions.length;++i){
				functions[i] = transformFunction(atoms[functions[i]]);
			}
			for(i = 0; i < methods.length;++i){
				methods[i] = transformClassMethod(atoms[methods[i]]);
			}
			for(i = 0; i < (fields.length - 1);++i){
				var field = trimSpaces(fields[i]);
				fields[i] = transformClassField(field.middle);
			}
			var tail = fields.pop();
			for(i = 0; i < cstrs.length;++i){
				cstrs[i] = transformConstructor(atoms[cstrs[i]]);
			}
			for(i = 0; i < classes.length;++i){
				classes[i] = transformInnerClass(atoms[classes[i]]);
			}
			return new AstClassBody(name, baseClassName, interfacesNames, functions, methods, fields, cstrs, classes, {			tail:tail			});
		});
				function AstInterface(name, body){
			this.name = name;
			this.body = body;
			body.owner = this;
		}
		AstInterface.prototype.toString = 		(function (){
			return (((((((("var " + this.name) + " = ") + this.body) + ";\n") + "$p.") + this.name) + " = ") + this.name) + ";\n";
		});
				function AstClass(name, body){
			this.name = name;
			this.body = body;
			body.owner = this;
		}
		AstClass.prototype.toString = 		(function (){
			return (((((((("var " + this.name) + " = ") + this.body) + ";\n") + "$p.") + this.name) + " = ") + this.name) + ";\n";
		});
				function transformGlobalClass(class_){
			var m = classesRegex.exec(class_);
			classesRegex.lastIndex = 0;
			var body = atoms[getAtomIndex(m[6])];
			var oldClassId = currentClassId; var newClassId = generateClassId();
			currentClassId = newClassId;
			var globalClass;
			if (m[2] === "interface"){
				globalClass = new AstInterface(m[3], transformInterfaceBody(body, m[3], m[4]));
			}			else
{
				globalClass = new AstClass(m[3], transformClassBody(body, m[3], m[4], m[5]));
			}
			appendClass(globalClass, newClassId, oldClassId);
			currentClassId = oldClassId;
			return globalClass;
		}
				function AstMethod(name, params, body){
			this.name = name;
			this.params = params;
			this.body = body;
		}
		AstMethod.prototype.toString = 		(function (){
			var paramNames = appendToLookupTable({			}, this.params.getNames());
			var oldContext = replaceContext;
			replaceContext = 			(function (subject){
				return paramNames.hasOwnProperty(subject.name) ? subject.name : oldContext(subject);
			});
			var result = ((((((((("function " + this.name) + this.params) + " ") + this.body) + "\n") + "$p.") + this.name) + " = ") + this.name) + ";";
			replaceContext = oldContext;
			return result;
		});
				function transformGlobalMethod(method){
			var m = methodsRegex.exec(method);
			var result = methodsRegex.lastIndex = 0;
			return new AstMethod(m[3], transformParams(atoms[getAtomIndex(m[4])]), transformStatementsBlock(atoms[getAtomIndex(m[6])]));
		}
				function preStatementsTransform(statements){
			var s = statements;
			s = s.replace(/\b(catch\s*"B\d+"\s*"A\d+")(\s*catch\s*"B\d+"\s*"A\d+")+/g, "$1");
			return s;
		}
				function AstForStatement(argument, misc){
			this.argument = argument;
			this.misc = misc;
		}
		AstForStatement.prototype.toString = 		(function (){
			return this.misc.prefix + this.argument.toString();
		});
				function AstCatchStatement(argument, misc){
			this.argument = argument;
			this.misc = misc;
		}
		AstCatchStatement.prototype.toString = 		(function (){
			return this.misc.prefix + this.argument.toString();
		});
				function AstPrefixStatement(name, argument, misc){
			this.name = name;
			this.argument = argument;
			this.misc = misc;
		}
		AstPrefixStatement.prototype.toString = 		(function (){
			var result = this.misc.prefix;
			if (this.argument !== undef){
				result += this.argument.toString();
			}
			return result;
		});
				function AstSwitchCase(expr){
			this.expr = expr;
		}
		AstSwitchCase.prototype.toString = 		(function (){
			return ("case " + this.expr) + ":";
		});
				function AstLabel(label){
			this.label = label;
		}
		AstLabel.prototype.toString = 		(function (){
			return this.label;
		});
		transformStatements = 		(function (statements, transformMethod, transformClass){
			var nextStatement = new RegExp(/\b(catch|for|if|switch|while|with)\s*"B(\d+)"|\b(do|else|finally|return|throw|try|break|continue)\b|("[ADEH](\d+)")|\b(case)\s+([^:]+):|\b([A-Za-z_$][\w$]*\s*:)|(;)/g);
			var res = [];
			statements = preStatementsTransform(statements);
			var lastIndex = 0; var m; var space;
			while((m = nextStatement.exec(statements)) !== null){
				if (m[1] !== undef){
					var i = statements.lastIndexOf('"B', nextStatement.lastIndex);
					var statementsPrefix = statements.substring(lastIndex, i);
					if (m[1] === "for"){
						res.push(new AstForStatement(transformForExpression(atoms[m[2]]), {						prefix:statementsPrefix						}));
					}					else
{
						if (m[1] === "catch"){
							res.push(new AstCatchStatement(transformParams(atoms[m[2]]), {							prefix:statementsPrefix							}));
						}						else
{
							res.push(new AstPrefixStatement(m[1], transformExpression(atoms[m[2]]), {							prefix:statementsPrefix							}));
						}
					}
				}				else
{
					if (m[3] !== undef){
						res.push(new AstPrefixStatement(m[3], undef, {						prefix:statements.substring(lastIndex, nextStatement.lastIndex)						}));
					}					else
{
						if (m[4] !== undef){
							space = statements.substring(lastIndex, nextStatement.lastIndex - m[4].length);
							if (trim(space).length !== 0){
								continue ;
							}
							res.push(space);
							var kind = m[4].charAt(1); var atomIndex = m[5];
							if (kind === 'D'){
								res.push(transformMethod(atoms[atomIndex]));
							}							else
{
								if (kind === 'E'){
									res.push(transformClass(atoms[atomIndex]));
								}								else
{
									if (kind === 'H'){
										res.push(transformFunction(atoms[atomIndex]));
									}									else
{
										res.push(transformStatementsBlock(atoms[atomIndex]));
									}
								}
							}
						}						else
{
							if (m[6] !== undef){
								res.push(new AstSwitchCase(transformExpression(trim(m[7]))));
							}							else
{
								if (m[8] !== undef){
									space = statements.substring(lastIndex, nextStatement.lastIndex - m[8].length);
									if (trim(space).length !== 0){
										continue ;
									}
									res.push(new AstLabel(statements.substring(lastIndex, nextStatement.lastIndex)));
								}								else
{
									var statement = trimSpaces(statements.substring(lastIndex, nextStatement.lastIndex - 1));
									res.push(statement.left);
									res.push(transformStatement(statement.middle));
									res.push(statement.right + ";");
								}
							}
						}
					}
				}
				lastIndex = nextStatement.lastIndex;
			}
			var statementsTail = trimSpaces(statements.substring(lastIndex));
			res.push(statementsTail.left);
			if (statementsTail.middle !== ""){
				res.push(transformStatement(statementsTail.middle));
				res.push(";" + statementsTail.right);
			}
			return res;
		});
				function getLocalNames(statements){
			var localNames = [];
			for(var i = 0, l = statements.length; i < l;++i){
				var statement = statements[i];
				if (statement instanceof AstVar){
					localNames = localNames.concat(statement.getNames());
				}				else
{
					if ((statement instanceof AstForStatement) && (statement.argument.initStatement instanceof AstVar)){
						localNames = localNames.concat(statement.argument.initStatement.getNames());
					}					else
{
						if ((((((statement instanceof AstInnerInterface) || (statement instanceof AstInnerClass)) || (statement instanceof AstInterface)) || (statement instanceof AstClass)) || (statement instanceof AstMethod)) || (statement instanceof AstFunction)){
							localNames.push(statement.name);
						}
					}
				}
			}
			return appendToLookupTable({			}, localNames);
		}
				function AstStatementsBlock(statements){
			this.statements = statements;
		}
		AstStatementsBlock.prototype.toString = 		(function (){
			var localNames = getLocalNames(this.statements);
			var oldContext = replaceContext;
			if (!isLookupTableEmpty(localNames)){
				replaceContext = 				(function (subject){
					return localNames.hasOwnProperty(subject.name) ? subject.name : oldContext(subject);
				});
			}
			var result = ("{\n" + this.statements.join('')) + "\n}";
			replaceContext = oldContext;
			return result;
		});
		transformStatementsBlock = 		(function (block){
			var content = trimSpaces(block.substring(1, block.length - 1));
			return new AstStatementsBlock(transformStatements(content.middle));
		});
				function AstRoot(statements){
			this.statements = statements;
		}
		AstRoot.prototype.toString = 		(function (){
			var classes = []; var otherStatements = []; var statement;
			for(var i = 0, len = this.statements.length; i < len;++i){
				statement = this.statements[i];
				if ((statement instanceof AstClass) || (statement instanceof AstInterface)){
					classes.push(statement);
				}				else
{
					otherStatements.push(statement);
				}
			}
			sortByWeight(classes);
			var localNames = getLocalNames(this.statements);
			replaceContext = 			(function (subject){
				var name = subject.name;
				if (localNames.hasOwnProperty(name)){
					return name;
				}				else
{
					if ((globalMembers.hasOwnProperty(name) || PConstants.hasOwnProperty(name)) || defaultScope.hasOwnProperty(name)){
						return "$p." + name;
					}
				}
				return name;
			});
			var result = (((("// this code was autogenerated from PJS\n" + "(function($p) {\n") + classes.join('')) + "\n") + otherStatements.join('')) + "\n})";
			replaceContext = null;
			return result;
		});
		transformMain = 		(function (){
			var statements = extractClassesAndMethods(atoms[0]);
			statements = statements.replace(/\bimport\s+[^;]+;/g, "");
			return new AstRoot(transformStatements(statements, transformGlobalMethod, transformGlobalClass));
		});
				function generateMetadata(ast){
			var globalScope = {			};
			var id; var class_;
			for(id in declaredClasses){
				if (declaredClasses.hasOwnProperty(id)){
					class_ = declaredClasses[id];
					var scopeId = class_.scopeId; var name = class_.name;
					if (scopeId){
						var scope = declaredClasses[scopeId];
						class_.scope = scope;
						if (scope.inScope === undef){
							scope.inScope = {							};
						}
						scope.inScope[name] = class_;
					}					else
{
						globalScope[name] = class_;
					}
				}
			}
						function findInScopes(class_, name){
				var parts = name.split('.');
				var currentScope = class_.scope; var found;
				while(currentScope){
					if (currentScope.hasOwnProperty(parts[0])){
						found = currentScope[parts[0]];
						break ;
					}
					currentScope = currentScope.scope;
				}
				if (found === undef){
					found = globalScope[parts[0]];
				}
				for(var i = 1, l = parts.length; (i < l) && found;++i){
					found = found.inScope[parts[i]];
				}
				return found;
			}
			for(id in declaredClasses){
				if (declaredClasses.hasOwnProperty(id)){
					class_ = declaredClasses[id];
					var baseClassName = class_.body.baseClassName;
					if (baseClassName){
						var parent = findInScopes(class_, baseClassName);
						if (parent){
							class_.base = parent;
							if (!parent.derived){
								parent.derived = [];
							}
							parent.derived.push(class_);
						}
					}
					var interfacesNames = class_.body.interfacesNames; var interfaces = []; var i; var l;
					if (interfacesNames && (interfacesNames.length > 0)){
						for(i = 0, l = interfacesNames.length; i < l;++i){
							var interface_ = findInScopes(class_, interfacesNames[i]);
							interfaces.push(interface_);
							if (!interface_){
								continue ;
							}
							if (!interface_.derived){
								interface_.derived = [];
							}
							interface_.derived.push(class_);
						}
						if (interfaces.length > 0){
							class_.interfaces = interfaces;
						}
					}
				}
			}
		}
				function setWeight(ast){
			var queue = []; var checked = {			};
			var id; var class_;
			for(id in declaredClasses){
				if (declaredClasses.hasOwnProperty(id)){
					class_ = declaredClasses[id];
					if (!class_.inScope && !class_.derived){
						queue.push(id);
						checked[id] = true;
						class_.weight = 0;
					}
				}
			}
			while(queue.length > 0){
				id = queue.shift();
				class_ = declaredClasses[id];
				if (class_.scopeId && !checked[class_.scopeId]){
					queue.push(class_.scopeId);
					checked[class_.scopeId] = true;
					declaredClasses[class_.scopeId].weight = (class_.weight + 1);
				}
				if (class_.base && !checked[class_.base.classId]){
					queue.push(class_.base.classId);
					checked[class_.base.classId] = true;
					class_.base.weight = (class_.weight + 1);
				}
				if (class_.interfaces){
					var i; var l;
					for(i = 0, l = class_.interfaces.length; i < l;++i){
						if (!class_.interfaces[i] || checked[class_.interfaces[i].classId]){
							continue ;
						}
						queue.push(class_.interfaces[i].classId);
						checked[class_.interfaces[i].classId] = true;
						class_.interfaces[i].weight = (class_.weight + 1);
					}
				}
			}
		}
		var transformed = transformMain();
		generateMetadata(transformed);
		setWeight(transformed);
		var redendered = transformed.toString();
		redendered = redendered.replace(/\s*\n(?:[\t ]*\n)+/g, "\n\n");
		return injectStrings(redendered, strings);
	}
		function preprocessCode(aCode, sketch){
		var dm = new RegExp(/\/\*\s*@pjs\s+((?:[^\*]|\*+[^\*\/])*)\*\//g).exec(aCode);
		if (dm && (dm.length === 2)){
			var jsonItems = []; var directives = dm.splice(1, 2)[0].replace(/\{([\s\S]*?)\}/g, 			(function (){
				return 				(function (all, item){
					jsonItems.push(item);
					return ("{" + (jsonItems.length - 1)) + "}";
				});
			})()).replace('\n', '').replace('\r', '').split(";");
			var clean = 			(function (s){
				return s.replace(/^\s*["']?/, '').replace(/["']?\s*$/, '');
			});
			for(var i = 0, dl = directives.length; i < dl;i++){
				var pair = directives[i].split('=');
				if (pair && (pair.length === 2)){
					var key = clean(pair[0]); var value = clean(pair[1]); var list = [];
					if (key === "preload"){
						list = value.split(',');
						for(var j = 0, jl = list.length; j < jl;j++){
							var imageName = clean(list[j]);
							sketch.imageCache.add(imageName);
						}
					}					else
{
						if (key === "transparent"){
							sketch.options.isTransparent = (value === "true");
						}						else
{
							if (key === "font"){
								list = value.split(",");
								for(var x = 0, xl = list.length; x < xl;x++){
									var fontName = clean(list[x]); var index = /^\{(\d*?)\}$/.exec(fontName);
									sketch.fonts.add(index ? JSON.parse(("{" + jsonItems[index[1]]) + "}") : fontName);
								}
							}							else
{
								if (key === "crisp"){
									sketch.options.crispLines = (value === "true");
								}								else
{
									if (key === "pauseOnBlur"){
										sketch.options.pauseOnBlur = (value === "true");
									}									else
{
										if (key === "globalKeyEvents"){
											sketch.options.globalKeyEvents = (value === "true");
										}										else
{
											if (key.substring(0, 6) === "param-"){
												sketch.params[key.substring(6)] = value;
											}											else
{
												sketch.options[key] = value;
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		return aCode;
	}
	Processing.compile = 	(function (pdeCode){
		var sketch = new Processing.Sketch();
		var code = preprocessCode(pdeCode, sketch);
		var compiledPde = parseProcessing(code);
		sketch.sourceCode = compiledPde;
		return sketch;
	});
	var tinylogLite = 	(function (){
		"use strict"
		var tinylogLite = {		}; var undef = "undefined"; var func = "function"; var False = !1; var True = !0; var logLimit = 512; var log = "log";
		if ((typeoftinylog !== undef) && (typeoftinylog[log] === func)){
			tinylogLite[log] = tinylog[log];
		}		else
{
			if ((typeofdocument !== undef) && !document.fake){
								(function (){
					var doc = document; var $div = "div"; var $style = "style"; var $title = "title"; var containerStyles = {					zIndex:10000, 					position:"fixed", 					bottom:"0px", 					width:"100%", 					height:"15%", 					fontFamily:"sans-serif", 					color:"#ccc", 					backgroundColor:"black"					}; var outputStyles = {					position:"relative", 					fontFamily:"monospace", 					overflow:"auto", 					height:"100%", 					paddingTop:"5px"					}; var resizerStyles = {					height:"5px", 					marginTop:"-5px", 					cursor:"n-resize", 					backgroundColor:"darkgrey"					}; var closeButtonStyles = {					position:"absolute", 					top:"5px", 					right:"20px", 					color:"#111", 					MozBorderRadius:"4px", 					webkitBorderRadius:"4px", 					borderRadius:"4px", 					cursor:"pointer", 					fontWeight:"normal", 					textAlign:"center", 					padding:"3px 5px", 					backgroundColor:"#333", 					fontSize:"12px"					}; var entryStyles = {					minHeight:"16px"					}; var entryTextStyles = {					fontSize:"12px", 					margin:"0 8px 0 8px", 					maxWidth:"100%", 					whiteSpace:"pre-wrap", 					overflow:"auto"					}; var view = doc.defaultView; var docElem = doc.documentElement; var docElemStyle = docElem[$style]; var setStyles = 					(function (){
						var i = arguments.length; var elemStyle; var styles; var style;
						while(i--){
							styles = arguments[i--];
							elemStyle = arguments[i][$style];
							for(style in styles){
								if (styles.hasOwnProperty(style)){
									elemStyle[style] = styles[style];
								}
							}
						}
					}); var observer = 					(function (obj, event, handler){
						if (obj.addEventListener){
							obj.addEventListener(event, handler, False);
						}						else
{
							if (obj.attachEvent){
								obj.attachEvent("on" + event, handler);
							}
						}
						return [obj,event,handler];
					}); var unobserve = 					(function (obj, event, handler){
						if (obj.removeEventListener){
							obj.removeEventListener(event, handler, False);
						}						else
{
							if (obj.detachEvent){
								obj.detachEvent("on" + event, handler);
							}
						}
					}); var clearChildren = 					(function (node){
						var children = node.childNodes; var child = children.length;
						while(child--){
							node.removeChild(children.item(0));
						}
					}); var append = 					(function (to, elem){
						return to.appendChild(elem);
					}); var createElement = 					(function (localName){
						return doc.createElement(localName);
					}); var createTextNode = 					(function (text){
						return doc.createTextNode(text);
					}); var createLog = tinylogLite[log] = 					(function (message){
						var uninit; var originalPadding = docElemStyle.paddingBottom; var container = createElement($div); var containerStyle = container[$style]; var resizer = append(container, createElement($div)); var output = append(container, createElement($div)); var closeButton = append(container, createElement($div)); var resizingLog = False; var previousHeight = False; var previousScrollTop = False; var messages = 0; var updateSafetyMargin = 						(function (){
							docElemStyle.paddingBottom = (container.clientHeight + "px");
						}); var setContainerHeight = 						(function (height){
							var viewHeight = view.innerHeight; var resizerHeight = resizer.clientHeight;
							if (height < 0){
								height = 0;
							}							else
{
								if ((height + resizerHeight) > viewHeight){
									height = (viewHeight - resizerHeight);
								}
							}
							containerStyle.height = (((height / viewHeight) * 100) + "%");
							updateSafetyMargin();
						}); var observers = [observer(doc, "mousemove", 						(function (evt){
							if (resizingLog){
								setContainerHeight(view.innerHeight - evt.clientY);
								output.scrollTop = previousScrollTop;
							}
						})),observer(doc, "mouseup", 						(function (){
							if (resizingLog){
								resizingLog = (previousScrollTop = False);
							}
						})),observer(resizer, "dblclick", 						(function (evt){
							evt.preventDefault();
							if (previousHeight){
								setContainerHeight(previousHeight);
								previousHeight = False;
							}							else
{
								previousHeight = container.clientHeight;
								containerStyle.height = "0px";
							}
						})),observer(resizer, "mousedown", 						(function (evt){
							evt.preventDefault();
							resizingLog = True;
							previousScrollTop = output.scrollTop;
						})),observer(resizer, "contextmenu", 						(function (){
							resizingLog = False;
						})),observer(closeButton, "click", 						(function (){
							uninit();
						}))];
						uninit = 						(function (){
							var i = observers.length;
							while(i--){
								unobserve.apply(tinylogLite, observers[i]);
							}
							docElem.removeChild(container);
							docElemStyle.paddingBottom = originalPadding;
							clearChildren(output);
							clearChildren(container);
							tinylogLite[log] = createLog;
						});
						setStyles(container, containerStyles, output, outputStyles, resizer, resizerStyles, closeButton, closeButtonStyles);
						closeButton[$title] = "Close Log";
						append(closeButton, createTextNode("\u2716"));
						resizer[$title] = "Double-click to toggle log minimization";
						docElem.insertBefore(container, docElem.firstChild);
						tinylogLite[log] = 						(function (message){
							if (messages === logLimit){
								output.removeChild(output.firstChild);
							}							else
{
								messages++;
							}
							var entry = append(output, createElement($div)); var entryText = append(entry, createElement($div));
							entry[$title] = new Date().toLocaleTimeString();
							setStyles(entry, entryStyles, entryText, entryTextStyles);
							append(entryText, createTextNode(message));
							output.scrollTop = output.scrollHeight;
						});
						tinylogLite[log](message);
						updateSafetyMargin();
					});
				})();
			}			else
{
				if (typeofprint === func){
					tinylogLite[log] = print;
				}
			}
		}
		return tinylogLite;
	})();
	Processing.logger = tinylogLite;
	Processing.version = "1.2.1";
	Processing.lib = {	};
	Processing.registerLibrary = 	(function (name, desc){
		Processing.lib[name] = desc;
		if (desc.hasOwnProperty("init")){
			desc.init(defaultScope);
		}
	});
	Processing.instances = processingInstances;
	Processing.getInstanceById = 	(function (name){
		return processingInstances[processingInstanceIds[name]];
	});
	Processing.Sketch = 	(function (attachFunction){
		this.attachFunction = attachFunction;
		this.options = {		isTransparent:false, 		crispLines:false, 		pauseOnBlur:false, 		globalKeyEvents:false		};
		this.params = {		};
		this.imageCache = {		pending:0, 		images:{		}, 		add:		(function (href){
			if (isDOMPresent){
				var img = new Image();
				img.onload = 				(function (owner){
					return 					(function (){
						owner.pending--;
					});
				})(this);
				this.pending++;
				this.images[href] = img;
				img.src = href;
			}			else
{
				this.images[href] = null;
			}
		})		};
		this.fonts = {		template:		(function (){
			if (!isDOMPresent){
				return null;
			}
			var element = document.createElement('p');
			element.style.fontFamily = "serif";
			element.style.fontSize = "72px";
			element.style.visibility = "hidden";
			element.innerHTML = "abcmmmmmmmmmmlll";
			document.getElementsByTagName("body")[0].appendChild(element);
			return element;
		})(), 		attempt:0, 		pending:		(function (){
			var r = true;
			for(var i = 0; i < this.fontList.length;i++){
				if ((this.fontList[i].offsetWidth === this.template.offsetWidth) && (this.fontList[i].offsetHeight === this.template.offsetHeight)){
					r = false;
					this.attempt++;
				}				else
{
					document.getElementsByTagName("body")[0].removeChild(this.fontList[i]);
					this.fontList.splice(i--, 1);
					this.attempt = 0;
				}
			}
			if (this.attempt >= 30){
				r = true;
				for(var j = 0; j < this.fontList.length;j++){
					document.getElementsByTagName("body")[0].removeChild(this.fontList[j]);
					this.fontList.splice(j--, 1);
				}
			}
			if (r){
				document.getElementsByTagName("body")[0].removeChild(this.template);
			}
			return r;
		}), 		fontList:[], 		fontFamily:"", 		style:isDOMPresent ? document.createElement('style') : null, 		add:		(function (fontSrc){
			var fontName = (typeoffontSrc === 'object') ? fontSrc.fontFace : fontSrc; var fontUrl = (typeoffontSrc === 'object') ? fontSrc.url : fontSrc;
			this.fontFamily += (((("@font-face{\n  font-family: '" + fontName) + "';\n  src:  url('") + fontUrl) + "');\n}\n");
			this.style.innerHTML = this.fontFamily;
			document.getElementsByTagName("head")[0].appendChild(this.style);
			var preLoader = document.createElement('p');
			preLoader.style.fontFamily = (("'" + fontName) + "', serif");
			preLoader.style.fontSize = "72px";
			preLoader.style.visibility = "hidden";
			preLoader.innerHTML = "abcmmmmmmmmmmlll";
			document.getElementsByTagName("body")[0].appendChild(preLoader);
			this.fontList.push(preLoader);
		})		};
		this.sourceCode = undefined;
		this.attach = 		(function (processing){
			if (typeofthis.attachFunction === "function"){
				this.attachFunction(processing);
			}			else
{
				if (this.sourceCode){
					var func = eval(this.sourceCode);
					func(processing);
					this.attachFunction = func;
				}				else
{
					throw "Unable to attach sketch to the processing instance";
				}
			}
		});
		this.toString = 		(function (){
			var i;
			var code = "((function(Sketch) {\n";
			code += (("var sketch = new Sketch(\n" + this.sourceCode) + ");\n");
			for(i in this.options){
				if (this.options.hasOwnProperty(i)){
					var value = this.options[i];
					code += (((("sketch.options." + i) + " = ") + ((typeofvalue === 'string') ? (('\"' + value) + '\"') : ("" + value))) + ";\n");
				}
			}
			for(i in this.imageCache){
				if (this.options.hasOwnProperty(i)){
					code += (("sketch.imageCache.add(\"" + i) + "\");\n");
				}
			}
			code += "return sketch;\n})(Processing.Sketch))";
			return code;
		});
	});
	var loadSketchFromSources = 	(function (canvas, sources){
		var code = []; var errors = []; var sourcesCount = sources.length; var loaded = 0;
				function ajaxAsync(url, callback){
			var xhr = new XMLHttpRequest();
			xhr.onreadystatechange = 			(function (){
				if (xhr.readyState === 4){
					var error;
					if ((xhr.status !== 200) && (xhr.status !== 0)){
						error = ("Invalid XHR status " + xhr.status);
					}					else
{
						if (xhr.responseText === ""){
							error = "No content";
						}
					}
					callback(xhr.responseText, error);
				}
			});
			xhr.open("GET", url, true);
			if (xhr.overrideMimeType){
				xhr.overrideMimeType("application/json");
			}
			xhr.setRequestHeader("If-Modified-Since", "Fri, 01 Jan 1960 00:00:00 GMT");
			xhr.send(null);
		}
				function loadBlock(index, filename){
			ajaxAsync(filename, 			(function (block, error){
				code[index] = block;
				++loaded;
				if (error){
					errors.push((("  " + filename) + " ==> ") + error);
				}
				if (loaded === sourcesCount){
					if (errors.length === 0){
						try{
							return new Processing(canvas, code.join("\n"));
						}catch( e ){
							Processing.logger.log("Unable to execute pjs sketch: " + e);
						}
					}					else
{
						Processing.logger.log("Unable to load pjs sketch files:\n" + errors.join("\n"));
					}
				}
			}));
		}
		for(var i = 0; i < sourcesCount;++i){
			loadBlock(i, sources[i]);
		}
	});
	var init = 	(function (){
		var canvas = document.getElementsByTagName('canvas');
		for(var i = 0, l = canvas.length; i < l;i++){
			var processingSources = canvas[i].getAttribute('data-processing-sources');
			if (processingSources === null){
				processingSources = canvas[i].getAttribute('data-src');
				if (processingSources === null){
					processingSources = canvas[i].getAttribute('datasrc');
				}
			}
			if (processingSources){
				var filenames = processingSources.split(' ');
				for(var j = 0; j < filenames.length;){
					if (filenames[j]){
						j++;
					}					else
{
						filenames.splice(j, 1);
					}
				}
				loadSketchFromSources(canvas[i], filenames);
			}
		}
	});
	Processing.loadSketchFromSources = loadSketchFromSources;
	Processing.disableInit = 	(function (){
		if (isDOMPresent){
			document.removeEventListener('DOMContentLoaded', init, false);
		}
	});
	Processing.loadSketchFromSources = loadSketchFromSources;
	Processing.disableInit = 	(function (){
		if (isDOMPresent){
			document.removeEventListener('DOMContentLoaded', init, false);
		}
	});
	if (isDOMPresent){
		window['Processing'] = Processing;
		document.addEventListener('DOMContentLoaded', init, false);
	}	else
{
		this.Processing = Processing;
	}
})(window, window.document, Math, (function (){
}));
