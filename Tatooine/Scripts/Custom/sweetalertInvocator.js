
function showAlert_Informative(icon, title, text, showButton, timer) {
    //convierte a bool mediante condicion
    let displayButton = (showButton === 1);
    //Si muestro boton el timer no se define, sino si
    let timerInt = showButton ? undefined : parseInt(timer);

    Swal.fire({
        icon,
        title,
        text,
        showConfirmButton: displayButton,
        timer: timerInt
    })
}

function showAlert_Interactive(icon, title, text, idinputhidden) {
    Swal.fire({
        icon,
        title,
        text,
        showConfirmButton: true
    },
    function (isConfirm) {
        if (isConfirm) {
            _doPostBack('btnLogout', 'OnClick');
        }
        else {
            return false;
        }
    });
}