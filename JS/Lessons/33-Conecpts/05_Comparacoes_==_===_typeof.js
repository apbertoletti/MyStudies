/*
Fluxo do '=='
1) verifica se são do mesmo tipo
2) null == undefined, se for, ele retorna true
3) number == string, se for, ele vai converter a string em numero
4) boolean == number, se for, ele vai converter o boolean em numero
5) boolean == string, se for, ele vai converter a string em boolean
6) objeto == primitivo, se for, ele vai converter o objeto em string
*/

console.log('Operador ==')
console.log(3 == '3');
console.log(null == undefined);
console.log(true == 1);
console.log(true == '1');
console.log({teste: 'teste'} == "{teste: 'teste'}");

/*
Fluxo do '==='
É necessário que os valores e os tipos sejam iguais para ser true
*/

console.log('Operador ===')
console.log(3 === '3');
console.log(3 === 3);

/*
typeof para validar tipos
*/

console.log('Typeof para validação')
console.log(typeof 'Gabriel' === 'string');
console.log(typeof 35 === 'number');
console.log(typeof '35' === 'number');
