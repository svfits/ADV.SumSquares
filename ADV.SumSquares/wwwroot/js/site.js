$(function () {
    $('#execute').on('click', function () {
        var valueNumber = $('#form').serialize();
        $.ajax({
            url: 'Home/CalculationSquares',
            type: 'POST',
            data: valueNumber,
            success: function (data) {
                $('#total').text(data.total);

                for (key of data.history) {
                    var hisHTML = '<li class="list-group-item d-flex justify-content-between align-items-center">' + key + '</li >';
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

