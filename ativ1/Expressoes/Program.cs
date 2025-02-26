using CAS;
using System.Numerics;

Expressao a = 10;
Expressao b = "b";

Expressao soma = a * 10;
Expressao c = 50;
//TESTES
Expressao num = new Complexos(3,5); //3 + 5i
Expressao num2 = new Complexos(b,2); //b + 2i
Expressao derivada = num2.Derivar(b as Simbolo);
Expressao real = new Complexos(7,0); // 7 + 0i

Console.WriteLine(num.Simplificar());//DEVE SAIR 3 + 5i
Console.WriteLine(derivada.Simplificar()); //DEVE SAIR 1
Console.WriteLine(real.Simplificar()); //Deve sair 7
