$(function () {
    $('.btn-outline-danger').click(function () {
        var url = $(this).data('request-url');
        val1 = "1";
        val2 = "2";
        return $.ajax({
            type: "POST",
            url: url,
            data: { number1: val1, number2: val2 },
            contentType: "application/json",
            dataType: "json",
            success: function (response) {
                if (response.responseCode == 0) {
                    var piggy = JSON.parse(response.responseMessage);
                    var selectorHouseId = '#house_' + piggy.Id;
                    var selectorPiggyId = '#piggy_' + piggy.Id;
                    const cardHouse = document.querySelector(selectorHouseId);
                    if (piggy.MyHouse.buildingStatus == false)
                    {                        
                        cardHouse.querySelector('.card-title').textContent = 'Destroyed'                        
                    }
                    cardHouse.querySelector('.stat').textContent = piggy.MyHouse.BuildingSolidity; 

                    const cardPiggy = document.querySelector(selectorPiggyId);
                    if (piggy.status == 2) {
                        cardPiggy.querySelector('.card-title').textContent = 'Dead'
                    }
                    cardPiggy.querySelector('.stat').textContent = piggy.MyHouse.BuildingSolidity; 
                }
                else {
                    alert(response.ResponseMessage);
                }                             
            },
            error: function (req, status, error) {
                alert(error);
            }
        });
    });
});