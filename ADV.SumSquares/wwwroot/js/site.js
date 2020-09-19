$(function () {
    $('#execute').on('click', function () {
        var valueNumber = $('#form').serialize();
        $.ajax({
            url: 'Home/CalculationSquares',
            type: 'POST',
            data: valueNumber,
            success: function (data) {
                console.info("Что то пришло");
            },
            error: function (data) {
                console.error("Ошибка произошла при получении результатов расчета " + data);
                ;
            }
        });
    });
});

