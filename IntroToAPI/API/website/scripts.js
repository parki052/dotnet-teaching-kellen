function getStudents(){

    fetch('https://localhost:44333/students')
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

        fetch(`https://localhost:44333/students/${id}`)
        .then((response) => response.json())
        .then((data) => {
            console.log(data);
        });
}

function removeStudentById(){

    var id = document.getElementById('removeStudentId').value;

    fetch(`https://localhost:44333/students/${id}`, {
        method: 'DELETE'
    })
    .then((response) => response.text())
    .then((data) => {
        console.log(data);
    });
}