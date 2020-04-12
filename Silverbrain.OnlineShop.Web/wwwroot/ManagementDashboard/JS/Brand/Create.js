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
    })
});