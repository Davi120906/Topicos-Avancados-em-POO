using CAS;
using System.Numerics;

Expressao a = 10;
Expressao b = "b";

Expressao soma = a * 10;
Expressao c = 50;

Complexos teste = new Complexos(5,5);
Expressao som = teste.Derivar((b as Simbolo));

Console.WriteLine(som.Simplificar());

