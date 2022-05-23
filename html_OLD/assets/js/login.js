document.getElementById("login_alert").style.visibility = "hidden";

//////////// LOGIN ////////////
function emptyInputs(){
}
function emptyLogInInputs(){
    var userLogin = document.getElementById("user_login").value;
    var passwdLogin = document.getElementById("passwd_login").value;
    
    if (userLogin == "" || passwdLogin == "")
        {
            // alert("Hello! I am an alert box!!");

           document.getElementById("login_alert").style.visibility = "visible";
            document.getElementById("login_alert").innerHTML = "You must fill all the inputs"; 
        }
    else {
        document.getElementById("login_alert").style.visibility = "hidden";

        
    }
}

document.getElementById("login").onclick = function() {emptyLogInInputs()};
