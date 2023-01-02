let numbers = [];

function addNumber() {

    let number = 
        document.getElementById("numberInput").value;
    
    if(!isNaN(number)){
        numbers.push(number);
    }
    
    document.getElementById("currentNumbers").innerText = "";

    if(numbers.length > 0){
        for(let i = 0; i < numbers.length; i++){
            document.getElementById("currentNumbers").innerText += `${numbers[i]}` + "\n";
        }
    }
}