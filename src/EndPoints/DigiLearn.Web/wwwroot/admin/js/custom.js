$("#CategoryId").change(function () {
    var currentId = $(this).val();
    $.ajax({
        url: "/admin/products/Index/LoadChildCategories?parentId=" + currentId,
        type: "get"
    }).done(function (data) {
        $("#SubCategoryId").html(data);
    });
});
$("#SubCategoryId").change(function () {
    var currentId = $(this).val();
    $.ajax({
        url: "/admin/products/Index/LoadChildCategories?parentId=" + currentId,
        type: "get"
    }).done(function (data) {
        $("#SecondarySubCategoryId").html(data);
    });
});
function AddRow() {
    var count = $("#rowCount").val();

    for (var i = 0; i < count; i++) {
        $("#table-body").append(
            "<tr>" +
            "<td><input type='text' autocomplete='off' name='Keys' class='form-control'/></td>" +
            "<td><input type='text' autocomplete='off' name='Values' class='form-control'/></td></tr>"
        );
    }
}

function changePageId(pageId) {
    var url = new URL(window.location.href);
    var search_params = url.searchParams;
    search_params.set('filterParams.pageId', pageId);
    url.search = search_params.toString();
    var new_url = url.toString();
    window.location.replace(new_url);
}