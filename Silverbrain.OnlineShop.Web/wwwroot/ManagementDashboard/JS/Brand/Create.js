//$('#brandform').on('click', '#createbtn', function (e) {
//    e.preventDefault();
//    submitForm('brandform', this.formAction);
//});

$('#brandform').on('click', '#cancelCratebtn', function (e) {
    e.preventDefault();
    getForm(Constants.UrlActionCreate);
});