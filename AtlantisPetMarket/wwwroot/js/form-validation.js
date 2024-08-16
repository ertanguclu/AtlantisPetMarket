document.querySelector('.file-upload-browse').addEventListener('click', function () {
    var fileInput = document.querySelector('.file-upload-default');
    fileInput.click();
});

document.querySelector('.file-upload-default').addEventListener('change', function () {
    var filePath = this.value.split('\\').pop();
    document.querySelector('.file-upload-info').value = filePath;
});

document.querySelector('form').addEventListener('submit', function (event) {
    var fileInput = document.querySelector('.file-upload-default');
    if (!fileInput.value) {
        alert("Lütfen bir resim seçiniz.");
        event.preventDefault();
    }
});
