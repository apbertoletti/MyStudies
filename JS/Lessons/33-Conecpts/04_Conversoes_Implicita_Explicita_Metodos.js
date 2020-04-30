console.log('/********** COERÇÂO **********/')
console.log('5' - 5); //0
console.log('5' + 5); //"55"
console.log(true + 1); //2
console.log(true + true); //2
console.log([] + {}); //"[object Object]"
console.log([] + []); //""

console.log('/********** IMPLÍCITIA **********/')
console.log(+'5'); //5
console.log(5 + ''); //"5"
console.log(123 && 'oi'); //"oi"
console.log(null || true); //true

console.log('/********** EXPLÍCITO **********/')
console.log(Number('50')); //50
console.log(String(50)); //"50"

/*
--JAVA (fortemente tipado)
Public Integer somaNumeros(Integer a, Integer b) { return a + b; }

--JAVASCRIPT (Ducktype: "se anda como um pato e fala como um pato, só pode ser um pato"))
function somaNumeros(a, b) { return a + b; }

*/
