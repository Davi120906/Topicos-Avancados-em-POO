using System.Runtime.CompilerServices;

public class Funcoes{
    public static void imprimirGastoPorPartido(IEnumerable<CotaParlamentar> cotas){
        var partidos = cotas.GroupBy(c => c.Partido).Select(g => new { Partido = g.Key, Total = g.Sum(c => c.ValorLiquido ?? 0)});
        foreach(var gastoDePartido in partidos){
            Console.WriteLine($"Partido: {gastoDePartido.Partido}, Total: {gastoDePartido.Total}");
        }
    }
    public static void imprimirDeputadosGasto(IEnumerable<CotaParlamentar> cotas){
        var deputados = cotas
        .GroupBy(c => c.NomeParlamentar)  
        .Select(g => new
        {
            NomeParlamentar = g.Key,
            GastoTotal = g.Sum(c => c.ValorLiquido ?? 0)
        })
        .OrderByDescending(d => d.GastoTotal) 
        .Take(5);
        foreach(var gastoDeputado in deputados){
            Console.WriteLine($"Deputado: {gastoDeputado.NomeParlamentar} \n Gasto Individual: {gastoDeputado.GastoTotal}");
        }
    }
    public static void imprimirMediaMensal(IEnumerable<CotaParlamentar> cotas){
        var gastoMedioPorMes = cotas
        .GroupBy( c => new {c.Ano, c.DataEmissao?.Month})
        .Select(g => new
        {
            Ano = g.Key.Ano,
            Mes = g.Key.Month,
            GastoTotal = g.Sum( c => c.ValorLiquido ?? 0),
            NumeroDeRegistros = g.Count()
        })
        .Select( g => new {
            g.Ano,
            g.Mes,
            gastoMedio = g.GastoTotal / g.NumeroDeRegistros
        })
        .OrderBy(g => g.Ano)
        .ThenBy(g => g.Mes);
        foreach(var mes in gastoMedioPorMes){
            Console.WriteLine($"ANO: {mes.Ano}, MES: {mes.Mes}, Gasto Medio: {mes.gastoMedio}");
        }
    }
    public static void imprimirDeputadosGastoAlimento(IEnumerable<CotaParlamentar> cotas){
        var deputados = cotas
        .Where(c => c.Descricao != null && c.Descricao.Contains("ALIMENTAÇÃO"))
        .GroupBy(c => c.NomeParlamentar)  
        .Select(g => new
        {
            NomeParlamentar = g.Key,
            GastoTotal = g.Sum(c => c.ValorLiquido ?? 0)
        });
        foreach(var gastoDeputado in deputados){
            Console.WriteLine($"Deputado: {gastoDeputado.NomeParlamentar} \n Gasto alimentacao: {gastoDeputado.GastoTotal}");
        }
    }
    public static void imprimirListaDeFornecedores(IEnumerable<CotaParlamentar> cotas){
        var fornecedores = cotas
        .GroupBy(c => c.Fornecedor)  
        .Select(g => new
        {
            NomeParlamentar = g.Key,
            TotalCotas = g.Count()  
        });
        foreach(var forn in fornecedores.OrderByDescending(c => c.TotalCotas)){
            Console.WriteLine($"FORNECEDOR: {forn.TotalCotas} Numero de cotas: {forn.TotalCotas}");
        }
    }
    public static void imprimirGastosPorUF(IEnumerable<CotaParlamentar> cotas){
        var UF = cotas
        .GroupBy(c => c.UF)  
        .Select(g => new
        {
            NomedaUF = g.Key,
            TotalGastos = g.Sum(c => c.ValorLiquido ?? 0)  
        });
        foreach(var forn in UF.OrderByDescending(c => c.TotalGastos)){
            Console.WriteLine($"UF: {forn.NomedaUF} Total gasto: {forn.TotalGastos}");
        }
    }
    public static void imprimirMesescomMaisDocumentos(IEnumerable<CotaParlamentar> cotas){
        var mesesComDocumentos = cotas
        .Where(c => c.DataEmissao.HasValue)
        .GroupBy(c => c.DataEmissao.Value.Month)
        .Select(g => new
        {
            Mes = g.Key,
            NumeroDeDocumentos = g.Count()
        });
        var maximoDocumentos = mesesComDocumentos.Max( g => g.NumeroDeDocumentos);
        

        var mesesComMaisDocumentos = mesesComDocumentos.Where(g => g.NumeroDeDocumentos == maximoDocumentos);
        
        foreach (var mes in mesesComMaisDocumentos)
        {
            Console.WriteLine($"Mes: {mes.Mes} - Numero de Documentos Emitidos: {mes.NumeroDeDocumentos}");
        }   
    }
    public static void imprimirDeputadoGasto10(IEnumerable<CotaParlamentar> cotas){
        var deputados = cotas
        .GroupBy(c => c.NomeParlamentar)  
        .Select(g => new
        {
            NomeParlamentar = g.Key,
            GastoTotal = g.Sum(c => c.ValorLiquido ?? 0)
        });
        var deputadosAcimaDe10Mil = deputados.Where(c => c.GastoTotal > 10000);
        foreach(var dep in deputadosAcimaDe10Mil){
            Console.WriteLine($"NOME: {dep.NomeParlamentar} GASTOS: {dep.GastoTotal}");
        }
    }
    public static void imprimirTotalGastoPorDespesa(IEnumerable<CotaParlamentar> cotas){
        var gastoDespesa = cotas
        .GroupBy(c => c.Descricao)
        .Select(g => new
        {
            Despesa = g.Key,
            Gasto = g.Sum(c => c.ValorLiquido ?? 0)
        });
        foreach(var despesa in gastoDespesa){
            Console.WriteLine($"Despesa: {despesa.Despesa} Gasto: {despesa.Gasto}");
        }
    }
    public static void imprimirDespesaAnual(IEnumerable<CotaParlamentar> cotas){
        var despesaAnual = cotas
        .GroupBy(c => c.Ano)
        .Select(g => new
        {
            Ano = g.Key,
            Gasto = g.Sum(c => c.ValorLiquido ?? 0)
        });
        foreach(var ano in despesaAnual){
            Console.WriteLine($"Ano: {ano.Ano} Gasto: {ano.Gasto}");
        }
    }
}
