$(function () {
    $('#brandform').on('click', '#createbtn', function (e) {
        e.preventDefault();
        submitForm('brandform', this);
    });

    $('#brandform').on('click', '#cancelCratebtn', function (e) {
        e.preventDefault();
        getForm(Constants.UrlActionCreate);
    });
});