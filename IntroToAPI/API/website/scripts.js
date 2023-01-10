var api = 'https://localhost:44333';

function getStudents(){

    fetch(`${api}/students`)
    .then((response) => response.json())
    .then((data) => {
        document.getElementById('students').innerHTML = "";
        for(let i = 0; i < data.length; i++){
            document.getElementById('students').innerHTML += `<li>(Id: ${data[i].id})Name: ${data[i].name}   ||  Age:  ${data[i].age}</li>`;
        }
    });

}

function getStudentById(){

    var id = document.getElementById('studentId').value;

        fetch(`${api}/students/${id}`)
        .then((response) => response.json())
        .then((data) => {
            console.log(data);
        });
}

function addStudent(){
    var newName = document.getElementById("addStudent_name").value;
    var newAge = document.getElementById("addStudent_age").value;

    var obj = {
        id: -1,
        name: newName,
        age: Number(newAge)
    }

    fetch(`${api}/students/add`, {
        method: 'POST',
        body: JSON.stringify(obj),
        headers: {
            "Content-Type": "application/json"
        }
    })
    .then((response) => response.json())
    .then((data) => {
        console.log(data);
    });

}

function removeStudentById(){

    var id = document.getElementById('removeStudentId').value;

    fetch(`${api}/students/${id}`, {
        method: 'DELETE'
    })
    .then((response) => response.text())
    .then((data) => {
        console.log(data);
    });
}