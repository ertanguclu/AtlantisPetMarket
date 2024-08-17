(function ($) {
    'use strict';
    $(function () {
        $('.file-upload-browse').off('click').on('click', function () {
            var file = $(this).parent().parent().parent().find('.file-upload-default');
            file.trigger('click');
        });
        $('.file-upload-default').off('change').on('change', function () {
            var fileName = $(this).val().replace(/C:\\fakepath\\/i, '');
            $(this).parent().find('.form-control.file-upload-info').val(fileName);
        });
    });
})(jQuery);

