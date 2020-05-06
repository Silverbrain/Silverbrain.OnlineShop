$(function () {
    $('#brandform').on('click', '#updatebtn', function (e) {
        e.preventDefault();
        submitForm('brandform', this);
    });

    $('#brandform').on('click', '#cancelUpdatebtn', function (e) {
        e.preventDefault();
        getForm(Constants.UrlActionCreate);
    });
})