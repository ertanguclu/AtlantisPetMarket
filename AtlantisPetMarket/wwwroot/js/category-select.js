$(document).ready(function () {
    $('#ParentCategoryId').change(function () {
        var parentCategoryId = $(this).val();
        if (parentCategoryId) {
            $.ajax({
                url: getCategoriesUrl,
                type: "GET",
                data: { parentCategoryId: parentCategoryId },
                success: function (data) {
                    var categorySelect = $('#CategoryId');
                    categorySelect.empty();
                    if (data && data.length > 0) {
                        $.each(data, function (i, category) {
                            categorySelect.append('<option value="' + category.id + '">' + category.categoryName + '</option>');
                        });
                    } else {
                        categorySelect.append('<option value="">No categories available</option>');
                    }
                }
            });
        } else {
            $('#CategoryId').empty().append('<option value="">Lütfen bir üst kategori seçin</option>');
        }
    });
});
