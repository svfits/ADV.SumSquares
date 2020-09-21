$(function () {
    $('#execute').on('click', function () {

        var valueNumber = $('input[name$="Numbers"]').serializeArray();

        $.ajax({
            url: 'Home/CalculationSquares',
            type: 'POST',
            data: valueNumber,
            success: function (data) {

                if (data.errorMessage !== "") {
                    alert(data.errorMessage);
                    return;
                }

                $('#total').text(data.total);
                $('li[name$="historyLog"]').remove();

                for (key of data.history) {
                    var hisHTML = '<li class="list-group-item d-flex justify-content-between align-items-center" name="historyLog" >' + key + '</li >';
                    $('#history').append(hisHTML);
                }
            },
            error: function (data) {
                console.error("Ошибка произошла при получении результатов расчета и истории " + data);
                ;
            }
        });
    });
});

