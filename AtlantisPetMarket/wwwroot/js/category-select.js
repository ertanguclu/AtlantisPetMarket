$(document).ready(function () {
    function loadCategories(parentCategoryId) {
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
    }

    // Sayfa yüklendiğinde ilk ParentCategory'ye göre kategorileri yükle
    var initialParentCategoryId = $('#ParentCategoryId').val();
    if (initialParentCategoryId) {
        loadCategories(initialParentCategoryId);
    }

    // Üst Kategori değiştiğinde kategorileri yeniden yükle
    $('#ParentCategoryId').change(function () {
        var parentCategoryId = $(this).val();
        loadCategories(parentCategoryId);
    });
});
