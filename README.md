# TesteSKA

1 � Montar uma query no padr�o de bancos relacionais para buscar todos os pedidos 
criados em mar�o/24 para clientes do estado do RS, informando o c�digo e nome do 
cliente, seu logradouro, cidade e estado, a descri��o do pedido e sua data de abertura. 
Buscar apenas informa��es ativas.

SELECT
    p.cd_pedido,
    c.nm_fantasia AS nome_cliente,
    e.ds_logradouro AS logradouro,
    e.nm_cidade AS cidade,
    e.nm_estado AS estado,
    p.ds_pedido AS descricao_pedido,
    p.dt_abertura AS data_abertura_pedido
FROM
    PEDIDO p
    JOIN CLIENTE c ON p.cd_cliente_faturamento = c.cd_cliente
    JOIN ENDERECO e ON c.cd_cliente = e.cd_cliente
WHERE
    MONTH(p.dt_abertura) = 3
    AND YEAR(p.dt_abertura) = 2024
    AND e.nm_estado = 'RS'
    AND c.cd_status = 1
    AND e.cd_status = 1;
	
	


---------------------------------------------------------------------------------------------------------------------------------------------------------------

2 � Abaixo segue um c�digo escrito em C# com finalidade de calcular o valor presente 
na posi��o especificada na s�rie Fibonacci. � necess�rio realizar alguns ajustes em 
c�digo, informando a corre��o e o valor obtido.
	class Program
	{
	 static void Main(string[] args)
	 {
	 CalculaFibonacci(0, 1, 1, 40);
	 Console.ReadKey()
	 }
	 private static void CalculaFibonacci(int a, int b, int counter, int len)
	 {
	 if (counter <= len)
	 {
	 Console.Write("{0} ", a)
	 CalculaFibonacci(b, a + b, counter + 1, len++)
	 }
	 }
	}
	
Ajestes Questoes 2: 
	*Adicionado ';' na linha CalculaFibonacci(0, 1, 1, 40);
	*Valida��o da logica (counter != len) para (counter <= len)
	* Na linha 'CalculaFibonacci(b, a + b, counter + 1, len++)' couter esta sendo incrementado com mais 2 o que poderia resultar em numero par na sequencia. Tamb�m o len estava sendo incrementado 
class Program
{
    static void Main(string[] args)
    {
        CalculaFibonacci(0, 1, 1, 40);
        Console.ReadKey();
    }

    private static void CalculaFibonacci(int a, int b, int counter, int len)
    {
        if (counter <= len)
        {
            Console.Write("{0} ", a);
            CalculaFibonacci(b, a + b, counter + 1, len);
        }
    }
}

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
3 � O c�digo abaixo foi escrito implementando a ordena��o de uma lista pelo m�todo 
BubbleSort. Gere uma lista de 10 itens, preenchida com n�meros aleat�rios que n�o se 
repitam entre 100 e 200 e corrija a a��o de ordena��o dos n�meros.
class Program
{
 static void Main(string[] args)
 {
 int[] numeros = { };
 Console.WriteLine("Array original\n");
 foreach (int numero in numeros)
 Console.Write($"{numero} ");
 Console.WriteLine("\n\nOrdenando o array usando Bubble Short\n");
 int[] arrayOrdenado = IntArrayBubbleSort(numeros);
 Console.WriteLine("Array Ordenado\n");
 foreach (int numero in arrayOrdenado)
 Console.Write($"{numero} ");
 Console.ReadLine();
 }
 public static int[] IntArrayBubbleSort(int[] data)
 {
 int i, j;
 int N = data.Length;
 for (j = N - 1; j > 0; j--)
 {
 for (i = 0; i < j; i++)
 {
 if (data[j] > data[i + 1])
 TrocarValores(data, i, i + 1);
 }
 }
 return data;
 }
 public static int[] TrocarValores(int[] arrayDados, int m, int n)
 {
 int temp;
 temp = arrayDados[n];
 arrayDados[m] = arrayDados[m];
 arrayDados[n] = temp;
 return arrayDados;
 }
}

Ajustes Questoes 3
*Ajustei para a compara��o ser (data[i] > data[i + 1]) para entao chamar o metodo TrocarValores. Ao inv�s de (data[j] > data[i + 1]) 
public static int[] IntArrayBubbleSort(int[] data)
    {
        int i, j;
        int N = data.Length;
        for (j = N - 1; j > 0; j--)
        {
            for (i = 0; i < j; i++)
            {
                if (data[i] > data[i + 1])
                    TrocarValores(data, i, i + 1);
            }
        }
        return data;
    }

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
4 � Criar um projeto do zero em C#.NET que contenha o m�todo com a seguinte 
assinatura:
public string ChangeDate(string date, char op, long value);
Dado que:
date: � uma data em forma de string formatada no padr�o �dd/MM/yyyy HH:mm�
op: opera��o, s� poder� aceitar os caracteres �+� e �-�
value: valor em minutos que deve ser acrescentado ou decrementado
Exemplo:
ChangeDate("01/03/2010 23:00", '+', 4000) = "04/03/2010 17:40"

Exercicio 4 fui criando ele em forma de um endpoint para uma API

		[HttpPost("exercicio4")]
        public string Exercicio4([FromBody] Exercicio4Request request)
        {
            return ChangeDate(request.Date, request.Op, request.Value);
        }

        public class Exercicio4Request
        {
            public string Date { get; set; }
            public char Op { get; set; }
            public long Value { get; set; }
        }
		
		private string ChangeDate(string date, char op, long value)
        {
            DateTime dateTime = DateTime.ParseExact(date, "dd/MM/yyyy HH:mm", null);

            if (op == '+')
                dateTime = dateTime.AddMinutes(value);
            else if (op == '-')
                dateTime = dateTime.AddMinutes(-value);
            else
                throw new ArgumentException("Opera��o inv�lida. Use apenas '+' ou '-'.");

            return dateTime.ToString("dd/MM/yyyy HH:mm");
        }


-------------------------------------------------------------------------------------------------------------------------------------------

OBS:
Foi criado um repositorio no github com a solu��o dos exercicios 2,3 e 4


https://github.com/neipoeta/Teste
Dentro da pasta controller - ExercicioSKA.cs (Acabei deixando todos no mesmo arquivo para n�o estender demais)