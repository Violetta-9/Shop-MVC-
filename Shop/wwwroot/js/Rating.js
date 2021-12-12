﻿var rating = document.querySelector('.rating');
var ratingItem = document.querySelectorAll('.rating-item');

rating.onclick = function (e) {
    var target = e.target;
    if (target.classList.contains('rating-item')) {
        removeClass(ratingItem, 'current-active');
        target.classList.add('active', 'current-active');
    }
}
rating.onmouseover = function (e) {
    var target = e.target;
    if (target.classList.contains('rating-item')) {
        
        removeClass(ratingItem, 'current-active');
       
        target.classList.add('active', 'current-active');
        mouseOverActiveClass(ratingItem);
       
    }
}
rating.onmouseout = function () {
    addClass(ratingItem, 'active');
    mouseOutActiveClass(ratingItem);
}
function removeClass(arr) {
    for (var i = 0, iLen = arr.length; i < iLen; i++) {
        for (var j = 1; j < arguments.length; j++) {
            ratingItem[i].classList.remove(arguments[j]);
        }
      
    }
}
function addClass(arr) {
 
    for (var i = 0, iLen = arr.length; i < iLen; i++) {
        for (var j = 1; j < arguments.length; j++) {
            ratingItem[i].classList.add(arguments[j]);
           
        }
    }
    
   
}
function mouseOverActiveClass(arr) {

    for (var i = 0, iLen = arr.length; i < iLen; i++) {
        if (arr[i].classList.contains('active')) {
            break;
        } else {
            arr[i].classList.add('active');
            
        }
       
    }
  

}
function mouseOutActiveClass(arr) {
    var num = 0;
    for (var i = arr.length - 1; i >= 0; i--) {
        if (arr[i].classList.contains('current-active')) {
            break;
        } else {
            arr[i].classList.remove('active');
            
        }
    }
   
    var f = document.getElementsByClassName("rating-item");
    for (var i = 0; i < 5; i++) {
        if (f[i].classList.contains("active")) {
            num++;
        }
    }
    var rf = document.getElementById("ratingValue");
    rf.value = num;
    console.log(rf);

}
