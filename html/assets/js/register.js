document.getElementById("alertme").style.visibility = "hidden";

function emptyInputs(){
    var name = document.getElementById("name_input").value;
    var surname = document.getElementById("surname_input").value;
    var username = document.getElementById("user_input").value;
    var mail =  document.getElementById("mail_input").value;
    var pw1 = document.getElementById("passwd").value;
    var pw2 = document.getElementById("repasswd").value;
    
    
    if (name == "" || surname == "" || username == "" || mail == "" || pw1 == "" || pw2 == "")
        {
           document.getElementById("alertme").style.visibility = "visible";
            document.getElementById("alertme").innerHTML = "You must fill all the inputs"; 
        }
    else if(pw1 != pw2) {
         document.getElementById("alertme").style.visibility = "visible";
            document.getElementById("alertme").innerHTML = "Passwords did not match";
    }
    else {
        document.getElementById("alertme").style.visibility = "hidden";

        
    }
    
}

document.getElementById("test").onclick = function() {emptyInputs()};
// document.getElementById("test").onclick = function() {ValidateEmail(document.e-mail_input.value)};

// function ValidateEmail(input){
//       var validRegex = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;

//     if(input.value.match(validRegex)){
//         document.getElementById("mail_input").style.color = green;
//     }
//     else{
//         document.getElementById("mail_input").style.color = red;
//     }
// }