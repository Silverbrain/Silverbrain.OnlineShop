//Messages = {
//    UploadPlaceHolderMessage: null
//};
//Fields = {
//    DeleteButton: null
//};

$(function () {
    $('.dropify').dropify({
        messages: {
            'default': Messages.UploadPlaceHolderMessage,
            'replace': Messages.UploadPlaceHolderMessage,
            'remove': Fields.DeleteButton
        }
    });
    $('#brandform').on("change", "#img-create-file", function (event) {
        var file = event.target.files[0];
        $('#ImageName').val(file.name);
    });
});