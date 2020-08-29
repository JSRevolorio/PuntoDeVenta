// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

/* Creacion de la tabla*/
$(document).ready(function() {

    $('#tablax').DataTable({
        language: {
            processing: "Tratamiento en curso...",
            search: "Buscar&nbsp;:",
            lengthMenu: "Agrupar de _MENU_ items",
            info: "Mostrando del item _START_ al _END_ de un total de _TOTAL_ items",
            infoEmpty: "No existen datos.",
            infoFiltered: "(filtrado de _MAX_ elementos en total)",
            infoPostFix: "",
            loadingRecords: "Cargando...",
            zeroRecords: "No se encontraron datos con tu busqueda",
            emptyTable: "No hay datos disponibles en la tabla.",
            paginate: {
                first: "Primero",
                previous: "Anterior",
                next: "Siguiente",
                last: "Ultimo"
            },
            aria: {
                sortAscending: ": active para ordenar la columna en orden ascendente",
                sortDescending: ": active para ordenar la columna en orden descendente"
            }
        },
        scrollY: 400,
        lengthMenu: [
            [10, 25, -1],
            [10, 25, "All"]
        ],
    });
});


//funcion menu lateral
$("#menu-toggle").click(function(e) {
    e.preventDefault();
    $("#content-wrapper").toggleClass("toggled");
});


var PlaceHolderElement = $('#PlaceHolderHere');

//funcion que validad los datos (data anotacion) en un modal
PlaceHolderElement.change(
    function() {
        $.validator.unobtrusive.parse("#formSPV");
});

// venta modal parcial formulario (enviar url para cualquer formulario)
$('button[data-toggle="ajax-modal"]').click(function(event) {
    $.ajax({
        type: 'GET',
        url: $(this).data('url')
    }).done(function(data) {
        PlaceHolderElement.html(data);
        PlaceHolderElement.find('.modal').modal('show');
    });
})

//funcion envio POS cualquer formulario enviar url
PlaceHolderElement.on('click', '[data-save="modal"]', function(event) {
    $.validator.unobtrusive.parse("#formSPV");
    if($('#formSPV').valid()){
        var form = $(this).parents('.modal').find('form');

        $.ajax({
            type: 'POST',
            url: form.attr('action'),
            data: form.serialize(),
    
            success: function(respuesta){
                $('#mensaje').addClass('alert alert-success');
                $('#mensaje').html(`<i class="fas fa-check-circle"></i> ${respuesta.mensaje}`)
                $('#formSPV')[0].reset();
                PlaceHolderElement.find('.modal').modal('hide');

                setInterval(()=>{
                    location.reload();
                }, 2000);
            },
    
            error: function(xhr, status) {
                $('#mensaje-modal').addClass('alert alert-danger');
                $('#mensaje-modal').html(`<i class="fas fa-exclamation-circle"></i> ${xhr.responseJSON.mensaje}`);
            },
        });
    }
    else{
        $('#mensaje-modal').addClass('alert alert-danger');
        $('#mensaje-modal').html(`<i class="fas fa-exclamation-circle"></i> validar formulario`);
    }
});

//Mostrar modal url para eliminar registro
var url = ''
$(document).on('click', '#ConfirmModal', function(e) {
    url = $(this).data('url');

    var numero = url.split('/');
    console.log(numero);
    $('#preguntaDeConfirmacion').text('Esta seguro que quiere eliminar el registro: ' + numero[3]);
    $('#exampleModal').modal('show');
});


//funcion que elimina el registro
$(document).on('click', '#deleteRegistro', function(e) {

    $.ajax({
        type: 'Delete',
        url: url,

        success: function(respuesta){
            $('#mensaje').addClass('alert alert-success');
            $('#mensaje').html(`<i class="fas fa-check-circle"></i> ${respuesta.mensaje}`)
            $('#exampleModal').modal('hide');

            setInterval(()=>{
                location.reload();
            }, 2000);
        },

        error: function(xhr, status) {
            $('#mensaje').addClass('alert alert-danger');
            $('#mensaje').html(`<i class="fas fa-exclamation-circle"></i> ${xhr.responseJSON.mensaje}`);
        },
    });
    url = '';    
});

