﻿
//Método para cargar un PartialView en un Div.
function LoadPartialView(IdContenedor, Url) {
    $(IdContenedor).load(Url);
}
function ValidatorEspagnol() {
    jQuery.extend(jQuery.validator.messages, {
        required: "Este campo es obligatorio.",
        remote: "Por favor, rellena este campo.",
        email: "Por favor, escribe una dirección de correo válida",
        url: "Por favor, escribe una URL válida.",
        date: "Por favor, escribe una fecha válida.",
        dateISO: "Por favor, escribe una fecha (ISO) válida.",
        number: "Por favor, escribe un número entero válido.",
        digits: "Por favor, escribe sólo dígitos.",
        creditcard: "Por favor, escribe un número de tarjeta válido.",
        equalTo: "Por favor, escribe el mismo valor de nuevo.",
        accept: "Por favor, escribe un valor con una extensión aceptada.",
        maxlength: jQuery.validator.format("Por favor, no escribas más de {0} caracteres."),
        minlength: jQuery.validator.format("Por favor, no escribas menos de {0} caracteres."),
        rangelength: jQuery.validator.format("Por favor, escribe un valor entre {0} y {1} caracteres."),
        range: jQuery.validator.format("Por favor, escribe un valor entre {0} y {1}."),
        max: jQuery.validator.format("Por favor, escribe un valor menor o igual a {0}."),
        min: jQuery.validator.format("Por favor, escribe un valor mayor o igual a {0}.")
    });
}

//Método para abrir dialog.
function AbrirDialog(IdDialog) {
    $(IdDialog).dialog('open'); //Ouvrir le dialog.
}
//Método para cerrar dialog.
function CerraDialog(IdDialog) {
    $(IdDialog).dialog('close');
}

//Método para actualizar tabla.
function ActualizarTabla(IdTable) {
    $(IdTable).dataTable()._fnAjaxUpdate();
}


//Método para cambiar de formulario
function CambiarFormulario(IdDesactivado, IdActivo) {
    $(IdDesactivado).hide('ZoomOut');
    $(IdActivo).show('ZoomIn');
}
