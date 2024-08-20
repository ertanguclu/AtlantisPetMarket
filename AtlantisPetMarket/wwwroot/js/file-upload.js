(function ($) {
    'use strict';
    $(function () {
        // Dosya seçme işlemi
        $('.file-upload-browse').on('click', function (e) {
            e.preventDefault(); // Sayfanın yeniden yüklenmesini önler
            var fileInput = $(this).closest('.form-group').find('.file-upload-default');
            fileInput.trigger('click');
        });

        // Dosya seçildikten sonra dosya adını göster
        $('.file-upload-default').on('change', function () {
            var fileName = $(this).val().replace(/C:\\fakepath\\/i, '');
            $(this).closest('.form-group').find('.form-control.file-upload-info').val(fileName);
        });
    });
})(jQuery);

