$(document).ready(function () {
    $('#txtramo').blur(function () {
        if ($('#txtramo').val() != '') {
            $.ajax({

                url: "/Busqueda/_BusquedaClave",
                type: 'POST',
                data: { id: $('#txtramo').val() },
                success: function (data) {
                    if (data != null) {
                        $("#txtproducto").removeAttr("disabled");
                        $("#txtramodesc").val(data);
                    }
                }
            })

        }
    });
    $('#txtproducto').blur(function () {
        if ($('#txtproducto').val() != '') {
            $.ajax({
                url: "/Busqueda/_BusquedaclaveProd",
                type: 'POST',
                data: { id: $('#txtproducto').val() },
                success: function (data) {

                    $("#txtproductodesc").val(data);
                }
            })

        }
    });
})
function muestra() {
    $.ajax({
        url: "CatalogoProd" + "/_BusquedaClave",
        type: 'POST',
        data: { id: $('#txtproductoclave').val(), desc: $('#txtproductodesc').val() },
        success: function (data) {
            $("#tblView").html(data);
        }
    })

}