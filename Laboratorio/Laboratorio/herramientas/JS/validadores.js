function validar() {
    var email = document.getElementById('TXT_EMAIL');
    var password = document.getElementById('TXT_PASSWORD').value;
    emailreg = /^\w+([.-_+]?\w+)*@\w+([.-]?\w+)*(\.\w{2,10})+$/;
    if (emailreg.test(email.value)) {
        if (password != '') {
            alert('Es valido');
            return true;
        }
        else {
            alert('contraseña invalida');
            return false;
        }
    }
    else {
        alert('email invalido');
        return false;
    }
}
