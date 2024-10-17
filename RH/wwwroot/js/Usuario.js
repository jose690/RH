$((function () {
    $('#buscarBtn').on('click', function (event) {
        event.preventDefault(); // Evita el envío del formulario por defecto

        $.ajax({
            url: '/Home/BuscarUsuario',
            type: 'GET',
            data: {
                cedula: $('#cedula').val(),
                tipoIdentificacion: $('#tipoIdentificacion').val()
            },
            success: function (response) {
                if (response.success) {
                    // Manejar la respuesta exitosa
                    $('#nombre').val(response.nombre);
                    $('#apellidos').val(response.apellido1 + ' ' + response.apellido2);
                    $('#fechaNacimiento').val(response.fechaNacimiento);
                    $('#genero').val(response.genero);
                } else {
                    alert(response.message); // Asegúrate de que esta línea recupera el mensaje correctamente
                }
            },
            error: function (xhr, status, error) {
                console.error("Error en la solicitud AJAX:", error);  // Registrar el error para depuración
                alert('Error: ' + error);
            }
        });
    });
}));
