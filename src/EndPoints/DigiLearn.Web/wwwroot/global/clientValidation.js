function getExtension(path) {
    var basename = path.split(/[\\/]/).pop(),  // extract file name from full path ...
        // (supports `\\` and `/` separators)
        pos = basename.lastIndexOf(".");       // get last position of `.`

    if (basename === "" || pos < 1)            // if file name is empty or ...
        return "";                             //  `.` not found (-1) or comes first (0)

    return basename.slice(pos + 1);            // extract extension ignoring `.`
}
jQuery.validator.addMethod("fileSize",
    function (value, element, params) {
        var fileSize = element.files[0].size / 1024 / 1024;
        var maxFileSize = $(element).attr("filesize") / 1024;
        return maxFileSize >= fileSize;
    });
jQuery.validator.addMethod("fileImage",
    function (value, element, params) {
        var fileType = getExtension(value.toLowerCase());
        if (!fileType)
            return true;

        if (fileType === "png" || fileType === "jpg" || fileType === "jpeg" ||
            fileType === "bmp" || fileType === "svg" || fileType === "gif" ||
            fileType === "tiff" || fileType === "webp" || fileType === "ico" || fileType === "pjpeg")
            return true;
        else
            return false;
    });
jQuery.validator.addMethod("fileType",
    function (value, element, params) {
        var fileType = getExtension(value.toLowerCase());
        var acceptType = $(element).attr("fileType");
        if (fileType === acceptType)
            return true;
        else
            return false;
    });
jQuery.validator.unobtrusive.adapters.addBool("fileType");
jQuery.validator.unobtrusive.adapters.addBool("fileSize");
jQuery.validator.unobtrusive.adapters.addBool("fileImage");