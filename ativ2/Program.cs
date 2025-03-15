using ConsoleDump;
class Program{
    static void Main(){
        var cotas = CotaParlamentar.LerCotasParlamentares(@"C:\Users\davic\OneDrive\Desktop\TAPOO\ativ2\ExercicioLINQ\cota_parlamentar.csv");
        imprimirMenu();
        var numerovalido = int.TryParse(Console.ReadLine(), out var input);
        while(input != 0){
            if(numerovalido){
                switch(input){
                    case 1:
                        Funcoes.imprimirGastoPorPartido(cotas);
                        break;
                    case 2:
                        Funcoes.imprimirDeputadosGasto(cotas);
                        break;
                    case 3:
                        Funcoes.imprimirMediaMensal(cotas);
                        break;
                    case 4:
                        Funcoes.imprimirDeputadosGastoAlimento(cotas);
                        break;
                    case 5:
                        Funcoes.imprimirListaDeFornecedores(cotas);
                        break;
                    case 6:
                        Funcoes.imprimirGastosPorUF(cotas);
                        break;
                    case 7:
                        Funcoes.imprimirMesescomMaisDocumentos(cotas);
                        break;
                    case 8:
                        Funcoes.imprimirDeputadoGasto10(cotas);
                        break;
                    case 9:
                        Funcoes.imprimirTotalGastoPorDespesa(cotas);
                        break;
                    case 10:
                        Funcoes.imprimirDespesaAnual(cotas);
                        break;
                    default:
                        Console.WriteLine("Por favor insira um numero de 0 a 10");
                        break;
                }
                
            }else{
                Console.WriteLine("Insira um numero por favor");
            }
            imprimirMenu();
            numerovalido = int.TryParse(Console.ReadLine(), out input);
        }
    }
    static void imprimirMenu(){
        Console.WriteLine(
                "MENU:\n" +
                "1) Total gasto por partido\n" +
                "2) Deputados com maior gasto individual (top 5)\n" +
                "3) Gasto médio por mês\n" +
                "4) Total gasto em alimentação por deputado\n" +
                "5) Lista de fornecedores mais utilizados\n" +
                "6) Gasto total por UF\n" +
                "7) Meses com maior número de documentos emitidos\n" +
                "8) Deputados com despesas acima de R$ 10.000,00\n" +
                "9) Total gasto por tipo de despesa\n" +
                "10) Total de gastos por ano\n" +
                "0) Sair"
            );
        Console.Write("Insira o input:");
    }
}

