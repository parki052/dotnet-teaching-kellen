function greetUser(){
    var name =
        document.getElementById("userNameInput").value;

    document.getElementById("greeting").style.display = "block";
    document.getElementById("userName").innerText = name;
}