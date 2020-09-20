$(function () {
    $('#execute').on('click', function () {
        
        var valueNumber = $('input[name$="Numbers"]').serializeArray(); 

        $.ajax({
            url: 'Home/CalculationSquares',
            type: 'POST',
            data: valueNumber,
            success: function (data) {
                try {
                    $('#total').text(data.total);

                    $('li[name$="historyLog"]').remove();

                    for (key of data.history) {
                        var hisHTML = '<li class="list-group-item d-flex justify-content-between align-items-center" name="historyLog" >' + key + '</li >';
                        $('#history').append(hisHTML);
                    }
                } catch (e) {
                    ///конечно так не красиво делать, но все же ))
                    alert(data);
                }
            },
            error: function (data) {
                console.error("Ошибка произошла при получении результатов расчета и истории " + data);
                ;
            }
        });
    });
});

