//01

var list = ["{'id': 123, 'name': 'ABC'}", "{'id': 123, 'name': 'ABC'}"]; 
var unique_list = new Set(list); // returns Set {"{'id': 123, 'name': 'ABC'}"}
var list = Array.from(unique_list); // converts back to an array
console.log(list);