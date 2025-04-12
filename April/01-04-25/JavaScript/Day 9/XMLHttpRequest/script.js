
const getData=(link, callback)=>{
    const request = new XMLHttpRequest()
    request.addEventListener("readystatechange", ()=>{
        if(request.readyState == 4 && request.status == 200){
            var data = (request.responseText);
            callback("Not Found",data)
        }
        else if(request.readyState == 4){
            callback("Not Found",undefined)
        }
    })
    request.open("Get", link)
    request.send()
}

var url1 = "https://jsonplaceholder.typicode.com/photos"
var url2 = "https://jsonplaceholder.typicode.com/todoss"

getData(url1,(err, data)=>{
    if(data){
    console.log(data)
        getData(url2,(err, data)=>{
            if(data){
                console.log(data)
            }
            else{
                console.log(`Error: ${err}`);
            }
        })
    }
    else{
        console.log(`Error: ${err}`);
        
    }
    
})