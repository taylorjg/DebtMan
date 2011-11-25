$("#addCreditorEditorRow").live("click", function () {
    $.ajax({
        url: this.href,
        cache: false,
        success: function (html) { $("#creditorEditorRows").append(html); }
    });
    return false;
});

$("a.deleteCreditorEditorRow").live("click", function () {
    $(this).parents("div.creditorEditorRow:first").remove();
    return false;
});
