
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

function showAlert_Interactive(icon, title, text) {
    Swal.fire({
        icon,
        title,
        text,
        showConfirmButton: true,
        allowOutsideClick: false
    }).then((result) => {
        if (result.value) {
            let clickButton = document.getElementById('alertAction');
            clickButton.click();
        }
    })
}

function testAlert() {
    let clickButton = document.getElementById('alertAction');
    clickButton.click();
}