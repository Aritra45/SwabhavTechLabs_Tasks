const noOfBlocks = parseInt(prompt("Enter Number of Blocks")); 
console.log(noOfBlocks);
const randomNumber = Math.floor(Math.random() * noOfBlocks + 1);
console.log(randomNumber);
const bodyRef = document.querySelector("body");
let attempts = 0;
for (let i = 1; i <= noOfBlocks; i++) { 
    let para = document.createElement("p"); 
    para.innerText = `${i}`; 
    bodyRef.appendChild(para);

    para.addEventListener("click", (e) => {
        if (attempts < 5) { 
            let clickedNumber = Number(e.target.innerText);

            if (clickedNumber === randomNumber) {
                e.target.classList.add("green");
                const winnerRef = document.querySelector("#winner-gif");
                const winnerImg = document.createElement("img");
                winnerImg.src = "winner.gif";
                winnerImg.alt = "Winner GIF"; 
                winnerRef.appendChild(winnerImg);
                // alert("Winner!");
                attempts = 5
            } 
            else if (clickedNumber > randomNumber) {
                e.target.classList.add("red");
            } 
            else {
                e.target.classList.add("yellow");
            }

            attempts++;
            if (attempts == 5) {
                alert("You lost all chances!");
            }
        }
        
    });
    
}

