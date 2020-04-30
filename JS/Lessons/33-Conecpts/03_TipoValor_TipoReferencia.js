/******* Tipo valor *********/

var x = 10; // mem.001 = nome é x, e o valor é 10
var y = x; // mem.002 = nome é y, e o valor é o mesmo de x, ou seja, 10
x = 20; // alterando apenas conteúdo do endereço mem.001

console.log(x, y);

/******* Tipo referência *********/
var w = { valor: 10 }; // mem.002
var z = w; // referência a mem.002
w.valor = 20; // alterando o mem.002, ou seja, tanto w como z será alterado

console.log(w, z);
