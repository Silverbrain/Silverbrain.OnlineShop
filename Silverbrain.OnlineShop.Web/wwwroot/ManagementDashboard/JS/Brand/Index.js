var Constants = {
    UrlActionCreate: null,
    UrlActionUpdate: null,
    UrlActionDelete: null,
};
var Fields = {
    HtmlRawToasterSuccessTitle: null,
    HtmlRawToasterErrorTitle: null,
    HtmlRawDeleteButton: null,
    HtmlRawCancelButton: null,
};
var Captions = {
    CreateBrand: null,
    EditBrand: null,
    HtmlRawBrand: null,
};
var Messages = {
    HtmlRawDeleteCautionMessage: null,
};

function success(result) {
    if (result) {
        switch (result.Type) {
            case 'Success':
                refreshGrid();
                getForm(Constants.UrlActionCreate);
                addalert(result.Message, 'success', Fields.HtmlRawToasterSuccessTitle);
                break;
            case 'Error':
                addalert(result.Message, 'error', Fields.HtmlRawToasterErrorTitle);
                break;
        }
    }
}
function submitForm(formId, e, data = null) {
    var submitdata;
    if (data !== null)
        submitdata = data;
    else {
        var file = $("#" + formId);
        submitdata = new FormData(file[0]);
    }
    var formAction = e.formAction;

    if (data !== null) {
        $.post({
            url: formAction,
            data: submitdata,
            success: function (result) {
                success(result);
            },
            error: function (errorData) {
                console.log(errorData);
            }
        });
        return;
    }
    var valid = $("#" + formId).valid();
    if (valid) {
        $.ajax({
            url: formAction,
            data: submitdata,
            processData: false,
            contentType: false,
            type: 'POST',
            success: function (result) {
                success(result);
            },
            error: function (errorData) {
                console.log(errorData);
            }
        });
    }
}
function buttonTemplate(data) {
    return `<a role="button" class="btn ${data.className}" href="#"><span class="${data.iconClass}"></span></a>`
}
//@* function template(data) {
//    let path = String.raw`../@Constants.PathBrandImageRead/` + data.Image;
//    return String.raw`<div class="brand-photo" style="background-image: url(${String.raw`${path}`});"></div>
//    <input class='imgName' type='hidden' value='${data.Image}' />`
//} *@
function addalert(msg, type, title) {
    toastr.options = {
        tapToDismiss: true,
        closeButton: false,
        showDuration: 100,
        hideDuration: 100,
        extendedTimeOut: 500,
        timeOut: 3000, // Set timeOut and extendedTimeOut to 0 to make it sticky
        //closeHtml: '<button type="button"><span class="ti-close"></span></button>',
        //closeClass: 'toast-close-button',
        newestOnTop: true,
        preventDuplicates: false,
        progressBar: false,
        rtl: true,
        positionClass: 'toast-top-center'
    };
    toastr[type](msg, title);
}
function getForm(action, id = null) {
    let $url = (id == null)
        ? action
        : `${action}/${id}`;
    let $data = { Id: id };

    $.get({
        url: $url,
        data: $data,
        success: function (data) {
            $('#brandform').html(data);
            switch (action) {
                case Constants.UrlActionCreate:
                    $('#form-title').html(Captions.CreateBrand);
                    break;
                case Constants.UrlActionUpdate:
                    $('#form-title').html(Captions.EditBrand);
                    break;
            }
        },
        async: false
    });
}
function refreshGrid() {
    $("#grid").data("kendoGrid").dataSource.read();
}
function getDataItem(grid, e) {
    let button = e.target;
    let row = $(button).closest("tr");
    return grid.dataItem(row);
}
function openEditWindow(e) {
    let dataItem = getDataItem(this, e);
    getForm(Constants.UrlActionUpdate, dataItem.Id);
}
function openDeleteWindow(e) {
    e.preventDefault();
    let dataItem = getDataItem(this, e);
    let $action = $('<button />');

    swal({
        text: Messages.HtmlRawDeleteCautionMessage,
        title: `${Captions.HtmlRawBrand}: ${dataItem.Title}`,
        icon: "warning",
        dangerMode: true,
        buttons: {
            confirm: {
                text: Fields.HtmlRawDeleteButton,
                value: "confirm",
            },
            cancel: Fields.HtmlRawCancelButton
        },
    })
        .then((value) => {
            if (value === "confirm") {
                $action.formAction = Constants.UrlActionDelete;
                let $token = $('form > input[name="__RequestVerificationToken"]').val();
                let $data = {
                    __RequestVerificationToken: $token,
                    Id: dataItem.Id
                };
                submitForm('brandform', $action, $data);
            }
        });
}
$(document).ready(function () {
    $.validator.unobtrusive.parse("#brandform");
});