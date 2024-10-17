$(document).ready(function () {
    $('#registrarBtn').on('click', function (event) {
        event.preventDefault();

        var oferente = {
            nombre: $('#nombre').val(),
            apellido1: $('#apellidos').val().split(' ')[0], // Primer apellido
            apellido2: $('#apellidos').val().split(' ')[1], // Segundo apellido
            correo: $('#correo').val(),
            telefono: $('#telefono').val(),
            cedula: $('#cedula').val()
        };

        $.ajax({
            url: 'http://localhost:5285/Home/RegistrarOferente',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(oferente),
            success: function (response) {
                if (response.success) {
                    alert(response.message);
                } else {
                    alert(response.message);
                }
            },
            error: function (xhr, status, error) {
                console.error("Error en la solicitud AJAX:", error);
                alert('Error: ' + error);
            }
        });
    });
});