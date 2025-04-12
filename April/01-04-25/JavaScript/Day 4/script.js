function login(email, password){
    return new Promise((resolve, reject)=>{
        setTimeout(()=>{
            if(email == 'aritradeb45@gmail.com' && password == '123'){
                resolve(email)
            }
            else{
                reject(email)
            }
        }, 2000)
    })
    
}

function getVideos(email){
    return new Promise((resolve, reject)=>{
        setTimeout(()=>{
            if(email){
                resolve(["video1","video2", "video3"])
            }
            else{
                reject()
            }
        }, 2000)
    })
}

function getVideoDetails(videos, videoName){
    return new Promise((resolve, reject)=>{
        
        setTimeout(()=>{
            if(videos.includes(videoName)){
                //alert(videoName);
                resolve(videoName)
            }
            else{
                reject()
            }
        }, 3000)
    })
}

let userEmail = prompt("Enter Email")
let userPassword = prompt("Enter Password")


//Async & await

var doOperation=async()=>{
   var email= await login(userEmail, userPassword)
   console.log(`Login Successful ${email}`)
   var videos=await getVideos(email)
   console.log(`Videos ${videos}`)
   let videoName = prompt("enter Video Name")
   var deatils=  await getVideoDetails(videos,videoName)
   console.log(`Details ${deatils}`)

}

doOperation()






// login(userEmail, userPassword).then((email)=>{
//     console.log(`Login Successful ${email}`)
//     return getVideos(email)
// }).then((videos)=>{
//     console.log(videos)
//     let videoName = prompt("enter Video Name")
//     return getVideoDetails(videos,videoName)
// }).then((videoDetails)=>{
//     console.log(videoDetails)
// })
// .catch((email)=>{
//     console.log(`Check this email ${email} and try again`)
// })

// login(userEmail, userPassword, ((email)=>{
//     console.log(`Login Successful ${email}`)
//     getVideos(((videos)=>{
//         console.log(videos)
//     }))
// }))

// ------------------------------------------------------------
// var getPromise=(score)=>{
//     return new Promise((resolve, reject)=>{
//         setTimeout(()=>{
//             if(score>85){
//                 resolve()
//             }
//             else{
//                 reject()
//             }
//         }, 2000)
        
//     })
// }

// getPromise(10).then(()=>{
//     console.log("Bike Received")
// }).catch(()=>{
//     console.log("No Bike")
// })

