$(document).ready(function () {
    $('#Price').on('input', function () {
        var value = $(this).val();
        $(this).val(value.replace(',', '.'));
    });

    $('form').submit(function () {
        var priceInput = $('#Price');
        var priceValue = priceInput.val();
        priceValue = priceValue.replace(',', '.');
        priceInput.val(priceValue);
    });
});
