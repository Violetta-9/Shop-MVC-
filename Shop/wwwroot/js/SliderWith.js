// Добавляем прослушку на всем окне
window.addEventListener("click", function (event) {
   
    // Объявляем переменную для счетчика
    var counter = 0;
    var productId = document.querySelectorAll(".idProduct");

    var productParent = event.target.closest('.Products');

    var result = productParent.querySelector('.idProduct');

    var result2 = parseInt(result.innerHTML);

    // Проверяем клик строго по кнопкам Плюс либо Минус
    if (event.target.dataset.action === 'plus' || event.target.dataset.action === 'minus') {
        // Находим обертку счетчика
        var counterWrapper = event.target.closest('.counter-wrapper');
        // Находим див с числом счетчика
        counter = counterWrapper.querySelector('[data-counter]');
    }

    // Проверяем является ли элемент по которому был совершен клик кнопкой Плюс
    if (event.target.dataset.action === 'plus') {
        counter.innerText = ++counter.innerText;
        
       
        addProduct(result2);
       
    }

    // Проверяем является ли элемент по которому был совершен клик кнопкой Минус
    if (event.target.dataset.action === 'minus') {

        // Проверяем чтобы счетчик был больше 1
        if (parseInt(counter.innerText) > 1) {
            // Изменяем текст в счетчике уменьшая его на 1
            counter.innerText = --counter.innerText;
            subProduct(result2);
           
            
            
        }

    }
    var fullPriceEl = document.querySelector(".totalPrice");
   
    var resultOfPrice = caltCartPrice();
    fullPriceEl.innerText= resultOfPrice;

    

});