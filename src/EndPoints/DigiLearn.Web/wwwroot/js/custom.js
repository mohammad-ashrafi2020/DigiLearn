function changeCommentPage(pageId, type, entityId) {
    $.ajax({
        url: `/comment/getByFilter?entityId=${entityId}&commentType=${type}&pageId=${pageId}`,
        type: "get",
        beforeSend: function () {
            $(".loading").show();
        },
        complete: function () {
            $(".loading").hide();
        },
    }).done(function (data) {
        $("#comment_list").html(data);
    });
}

function replyComment(id) {
    $("#parentId").val(id);
}

function deleteComment(id) {
    deleteItem(`/comment/delete?commentId=${id}`,"آیا از حذف نظر اطمینان دارید ؟");
}