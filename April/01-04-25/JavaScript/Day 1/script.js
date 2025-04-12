// console.log("Welcome to JavaScript Day1");
// alert("hi friends");
// confirm("Do you want to delete this file")
// // prompt("Enter a Number")

// while(true){
// let res = prompt("Enter a Number")
// if(res%2 == 0){
//     alert("its even")
    
// }
// else{
//     alert("its odd")
    
// }
// var c=confirm("do you want to continue?")

// if(c == false){
//     break
// }

// }

// function demo(){
//     var num = 10
//     if(num == 10){
//         let num = 30
//         console.log(num)
//     }
//     console.log(num)
// }
// demo()

// let email = "aritradeb45@gmail.com"
// let emailArray = email.split("@")
// console.log(emailArray[1])
// console.log(emailArray)
// console.log(email.substring(email.indexOf("@")+1,20))
// console.log(email.slice(email.indexOf("@")+1, 15))


// let fruits = ["Apple", "Mango", "Pinapple"]
// fruits.push("Banana")
// console.log(fruits)
// fruits.pop()
// console.log(fruits)
// console.log(fruits.at(1))
// console.log(fruits.includes("Apple"));
// fruits.forEach(f=>console.log(f))


// function greet(name){
//     console.log(`Welcome ${name}`)
// }
// greet("Aritra")

// function greet(){
//     console.log(`Welcome ${arguments[0]} ${arguments[1]}`)
// }
// greet("Aritra", "Deb")

// const greet=(name)=>{
//     console.log(`Welcome ${name}`)
// }
// greet("Aritra")

// const greet=(name, surname)=>{
//     console.log(`Welcome ${name} ${surname}`)
// }
// greet("Aritra", "Deb")

// const greet = function(lastname, firstname="Aritra"){
//     console.log(`Welcome ${firstname} ${lastname}`)
// }
// greet("Deb")

// const addition=(num1, num2)=>{
//     return num1+num2
// }
// console.log(addition(20, 10))

// const addition=num1=>num1
// console.log(addition(20))



// const func1=(callback)=>{
//     console.log("func1")
//     callback()
// }
// const func2=()=>{
//     console.log("func2")
// }
// func1(func2)


// const func1=(callback)=>{
//     console.log("hi number")
//     callback(20)
// }
// func1((value)=>{console.log(value)})




// let student = ["Aritra", "Abhishek", "Garvita", "Pradnya"]
// const bodyRef = document.querySelector("body")
// const uiElement = document.createElement("ul")
// //html = ``
// student.forEach((students, index)=>{
//      const liElement = document.createElement("li")
//      //html =`${index+1} ${students}`
//      liElement.innerText=`${index+1} ${students}`
//      uiElement.appendChild(liElement)
// })
// bodyRef.appendChild(uiElement)





// let student = []
// const divtask=document.querySelector("#taskdiv")
// const inputRef = document.querySelector("input")
// const uiElement = document.createElement("ul")
// function display(){
//     uiElement.innerHTML=''
//     text=inputRef.value
//     student.push(text)
//     student.forEach((students, index)=>{
//         const liElement = document.createElement("li")
//         html=`${index+1} ${students}`
//         liElement.innerText=html
//         uiElement.appendChild(liElement)
//         console.log(students)


        
//     })
//     divtask.appendChild(uiElement)
// }




let tasks = [];
let convertedTasks = []
const uiElement = document.querySelector("#taskdiv > ul");
const inputRef = document.querySelector("input");
var isPresent = false
const inputText = ""
function addTask() {
    
    if(inputRef.value == ""){
        alert("Nothing to add")
    }
    else{
        let text = inputRef.value;
        
        // tasks.forEach(task=>{
        //     if(text == task){
        //         alert(`${inputRef.value} task is already present`)
        //         isPresent = true
        //     }
                
            
        // })
        // if(!isPresent){
        //     tasks.push(text);
        //     inputRef.value = inputText
        // }
        convertedTasks = tasks.map(task => task.toLowerCase())
        isPresent = convertedTasks.includes(text.toLowerCase())
        if(!isPresent){
            tasks.push(text);
        }
        else{
            alert(`${inputRef.value} task is already present`)
        }
        inputRef.value = inputText
    }
    
    display();
}

function display() {
    uiElement.innerHTML = '';
    tasks.forEach((task, index) => {
        const liElement = document.createElement("li");
        liElement.innerText = `${index + 1}. ${task}`;
        const completedBtn = document.createElement("button");
        completedBtn.innerText = "Completed";
        completedBtn.onclick=()=>{
        completedTasks.push(task)
        deleteBtn.onclick()
        completedDisplay()
    }

    const deleteBtn = document.createElement("button");
    deleteBtn.innerText = "Delete";
    deleteBtn.onclick = () => {
        tasks.splice(index, 1); 
        display(); 
    };

    liElement.appendChild(completedBtn);
    liElement.appendChild(deleteBtn);
    uiElement.appendChild(liElement);
    });
}

let completedTasks = [];
const uiCompletedElement = document.querySelector("#completeTaskDiv > ul");
function completedDisplay(){
    uiCompletedElement.innerHTML = '';
    completedTasks.forEach((task, index) => {
        const liElement = document.createElement("li");
        liElement.innerText = `${index + 1}. ${task}`;
        const deleteBtn2 = document.createElement("button");
        deleteBtn2.innerText = "Delete";
        deleteBtn2.onclick = () => {
        completedTasks.splice(index, 1); 
        completedDisplay(); 
    };
    liElement.appendChild(deleteBtn2);
        uiCompletedElement.appendChild(liElement);
    });
}

