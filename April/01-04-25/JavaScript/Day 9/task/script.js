//MAP()
let tasks = ["ARI", "ABHI", "PRAD", "GARV"];
let convertedTasks = []
convertedTasks = tasks.map(task => task.toLowerCase())
console.log(convertedTasks)


//REDUCE
const number = [15.5, 2.3, 1.1, 4.7];
console.log(number.reduce(getSum, 0));
function getSum(total, num) {
  return total + Math.round(num);
}


//FILTER
const ages = [32, 33, 16, 40];
console.log(ages.filter(checkAdult));
function checkAdult(age) {
  return age >= 18;
}