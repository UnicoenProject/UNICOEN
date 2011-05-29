/*Blind Up*/
/*Configuration*/
var global = '';
this.effect;

var selectorid = 0;
function openLangSelector(){
    clearInterval( selectorid );
    if($('lang-area').effect != null){
        $('lang-area').effect.cancel();
    }
    $('lang-area').effect = new Effect.Appear('lang-area', {
        from:0,
        to:1.0,
        duration: 0.2
    });
}
function cancelFadeLangSelector(){
    //$('lang-area').effect.cancel();
    clearInterval( selectorid );
    if($('lang-area').effect != null){
        $('lang-area').effect.cancel();
    }
    $('lang-area').effect = new Effect.Appear('lang-area', {
        to:1.0,
        duration: 0.2
    });
    
}
function callFadeLangSelector(){
    selectorid = setInterval( fadeLangSelector , 100 );
}
function fadeLangSelector(){
    clearInterval( selectorid );
    if($('lang-area').effect != null){
        $('lang-area').effect.cancel();
    }
    $('lang-area').effect = new Effect.Fade('lang-area', {
        to:0,
        duration: 0.5
    });
}
function fadeLangSelectorPre(){
    clearInterval( selectorid );
    if($('lang-area').effect != null){
        $('lang-area').effect.cancel();
    }
    $('lang-area').effect = new Effect.Fade('lang-area', {
        to:0,
        duration: 0.1
    });
}
var btn_search_on = new Image();
btn_search_on.src = '/common/images/btn_search_submit_on.gif';
var btn_search_off = new Image();
btn_search_off.src = '/common/images/btn_search_submit.gif';

function openWin(file,w,h){
    window.open(file,"winPhoto","menubar=no,status=no,scrollbars=yes,toolbar=no,width="+w+",height="+h+"")
}
function btnsearchOn(t){
    t.src = btn_search_on.src;
}
function btnsearchOff(t){
    t.src = btn_search_off.src;
}

function effecton(_this){
    if($(_this).effect != null){
        $(_this).effect.cancel();
    }
    $(_this).effect = new Effect.Fade(_this, {
        to:0.7,
        // delay:0, // äJénÇ‹Ç≈ÇÃïbêî 
        fps:60,
        duration: 0.1,
        beforeStartInternal: function(effect) {
        }, 
        afterFinishInternal: function(effect) {
        }
    });
}
function effectoff(_this){
    if($(_this).effect != null){
        $(_this).effect.cancel();
    }
    $(_this).effect = new Effect.Appear(_this, {
        to:1.0,
        // delay:0, // äJénÇ‹Ç≈ÇÃïbêî 
        fps:60,
        duration: 0.1,
        beforeStartInternal: function(effect) {
        }, 
        afterFinishInternal: function(effect) {
        }
    });
}
function swapImage(f,t){
    $(t).src = f;   
}


/* jumpToPageTop */



function setObj(id) {

    if (document.all) {

        return document.all(id);

    } else if (document.getElementById) {

        return document.getElementById(id);

    } else if (document.layers) {

        return document.layers[id];

    }

        return false;

}



function getScrollLeft() { // 020225

 if ((navigator.appName.indexOf("Microsoft Internet Explorer",0) != -1)) {

  return document.body.scrollLeft;

 } else if (window.pageXOffset) {

  return window.pageXOffset;

 } else {

  return 0;

 }

}



function getScrollTop() { // 020225
var ret = Position.realOffset($('wrap'));
/* if ((navigator.appName.indexOf("Microsoft Internet Explorer",0) != -1)) {
  return document.body.clientHeight;

 } else if (window.pageYOffset) {

alert(pageYOffset);
  return window.pageYOffset;

 } else {

  return 0;

 }*/
 return ret[1];

}



function getScrollWidth() { // 010317

 if ((navigator.appName.indexOf("Microsoft Internet Explorer",0) != -1)) {

  return document.body.scrollWidth;

 } else if (window.innerWidth) {

  return window.innerWidth;

 }

 return 0;

}



function getScrollHeight() { // 010317

 if ((navigator.appName.indexOf("Microsoft Internet Explorer",0) != -1)) {

  return document.body.scrollHeight;

 } else if (window.innerHeight) {

  return window.innerHeight;

 }

 return 0;

}







function toHex(_int) {

 if (i < 0) {

  return '00';

 } else if (_int > 255) {

  return 'ff';

 } else {

  return '' + hexbox[Math.floor(_int/16)] + hexbox[_int%16];

 }

}



var pageScrollTimer;

function pageScroll(toX,toY,frms,cuX,cuY) { // 020314
 if (pageScrollTimer) clearTimeout(pageScrollTimer);

 if (!toX || toX < 0) toX = 0;

 if (!toY || toY < 0) toY = 0;

 if (!cuX) cuX = 0 + getScrollLeft();

 if (!cuY) cuY = 0 + getScrollTop();

 if (!frms) frms = 6;

 if (toY > cuY && toY > (getAnchorPosObj('end','enddiv').y) - getInnerSize().height) toY = (getAnchorPosObj('end','enddiv').y - getInnerSize().height) + 1;

 cuX += (toX - getScrollLeft()) / frms; if (cuX < 0) cuX = 0;

 cuY += (toY - getScrollTop()) / frms;  if (cuY < 0) cuY = 0;

 var posX = Math.floor(cuX);

 var posY = Math.floor(cuY);

 window.scrollTo(posX, posY);



 if (posX != toX || posY != toY) {

  pageScrollTimer = setTimeout("pageScroll("+toX+","+toY+","+frms+","+cuX+","+cuY+")",16);

 }

}



function jumpToPageTop() { // 020301

// if (!MacIE3 && !MacIE4 && !NN && window.scrollTo || NN && (Vminor >= 4.75) && window.scrollTo) {

  pageScroll(0,0,5);

// } else {

//  location.hash = "top";

// }

}

function getInnerSize() {

 var obj = new Object();



 if (document.all || (document.getElementById && IE)) {

  obj.width = document.body.clientWidth;

  obj.height = document.body.clientHeight;

 } else if (document.layers || (document.getElementById && Moz)) {

  obj.width = window.innerWidth;

  obj.height = window.innerHeight;

 }



 return obj;

}



function getAnchorPosObj(elementname, elementid) {

 var obj = setObj(elementname);

 var objnew = new Object();

 var objtmp;



 if (document.getElementById && IE) {

  objtmp = obj;

   objnew.x = objtmp.offsetLeft;

  objnew.y = objtmp.offsetTop;

 while ((objtmp = objtmp.offsetParent) != null) {

   objnew.x += objtmp.offsetLeft;

   objnew.y += objtmp.offsetTop;

  }

 } else if (document.getElementById && Moz) {

//  objnew.x = document.getElementsByTagName("A").namedItem(elementname).offsetLeft;

//  objnew.y = document.getElementsByTagName("A").namedItem(elementname).offsetTop;

  objnew.x = document.getElementsByTagName("DIV").namedItem(elementid).offsetLeft;

  objnew.y = document.getElementsByTagName("DIV").namedItem(elementid).offsetTop;

 } else if (document.all) {

  objtmp = obj;

  objnew.x = objtmp.offsetLeft;

  objnew.y = objtmp.offsetTop;

  while ((objtmp = objtmp.offsetParent) != null) {

   objnew.x += objtmp.offsetLeft;

   objnew.y += objtmp.offsetTop;

  }

 } else if (document.layers) {

  objnew.x = document.anchors[elementname].x;

  objnew.y = document.anchors[elementname].y;

 } else {

  objnew.x = 0;

  objnew.y = 0;

 }

 return objnew;

}



function jumpToAnchor(elementname, elementid) {

 if (getAnchorPosObj(elementname, elementid).x != 0 || getAnchorPosObj(elementname, elementid).y != 0) {

  pageScroll(0,getAnchorPosObj(elementname, elementid).y,5);

 } else {

  location.hash = elementname;

 }

}


