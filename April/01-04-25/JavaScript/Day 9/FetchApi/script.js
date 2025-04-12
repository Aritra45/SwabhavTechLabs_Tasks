fetch("https://jsonplaceholder.typicode.com/photos").then((response)=>{
    if(response.status == 200){
        return (response);
    }
    
    throw new Error("could not find the photos url")
}).then((data)=>{
    console.log(data)
    return fetch("https://jsonplaceholder.typicode.com/todos")
}).then((str)=>{
    if(str.status == 200){
        console.log(str)
    }
   else{
    throw new Error("could not find the todos url")
   }
    
}).catch((err)=>{
    console.log(err)
})