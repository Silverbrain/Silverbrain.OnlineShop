$(function () {
    var imgfile = $('.dropify').dropify({
        messages: {
            'default': Messages.UploadPlaceHolderMessage,
            'replace': Messages.UploadPlaceHolderMessage,
            'remove': Fields.HtmlRawDeleteButton
        }
    });

    imgfile = imgfile.data('dropify');

    if (editMode) {
        imgfile.destroy();
        $('#img-edit').addClass('hidden');
        $('#img-edit').val(null);
    }
    $('#edit-img-btn').on('click', function (e) {
        e.preventDefault();

        $('#img-view').addClass('hidden');
        $('#img-edit').removeClass('hidden');

        if (!imgfile.isDropified())
            imgfile.init();
    });
    $('#edit-img-cancel-btn').on('click', function (e) {
        e.preventDefault();

        $('#img-view').removeClass('hidden');

        $('#img-edit').addClass('hidden');
        $('#img-edit').val(null);

        if (imgfile.isDropified())
            imgfile.destroy();
    });
});