using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TesteSKA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercicioSKA : ControllerBase
    {
        [HttpGet("exercicio2")]
        public string Exercicio2()
        {
            return CalculaFibonacci(0, 1, 1, 40);
        }

        [HttpGet("exercicio3")]
        public string Exercicio3()
        {
            int[] numeros = GerarListaNumerosAleatorios(10, 100, 200).ToArray();
            string arrayOriginal = string.Join(" ", numeros);
            int[] arrayOrdenado = IntArrayBubbleSort(numeros).ToArray();
            string arrayOrdenadoStr = string.Join(" ", arrayOrdenado);
            return $"Array original: {arrayOriginal}\n\nArray ordenado: {arrayOrdenadoStr}";
        }

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


        private string CalculaFibonacci(int a, int b, int counter, int len)
        {
            if (counter <= len)
            {
                return $"{a} {CalculaFibonacci(b, a + b, counter + 1, len)}";
            }
            return "";
        }

        private IEnumerable<int> GerarListaNumerosAleatorios(int quantidade, int min, int max)
        {
            if (quantidade > (max - min) + 1)
                throw new ArgumentException("A quantidade de números aleatórios não pode ser maior que a diferença entre o máximo e o mínimo.");

            Random random = new Random();
            return Enumerable.Range(min, max - min + 1).OrderBy(x => random.Next()).Take(quantidade);
        }

        private IEnumerable<int> IntArrayBubbleSort(IEnumerable<int> data)
        {
            int[] array = data.ToArray();
            int i, j;
            int N = array.Length;
            for (j = N - 1; j > 0; j--)
            {
                for (i = 0; i < j; i++)
                {
                    if (array[i] > array[i + 1])
                        TrocarValores(array, i, i + 1);
                }
            }
            return array;
        }

        private void TrocarValores(int[] arrayDados, int m, int n)
        {
            int temp;
            temp = arrayDados[n];
            arrayDados[n] = arrayDados[m];
            arrayDados[m] = temp;
        }

        private string ChangeDate(string date, char op, long value)
        {
            DateTime dateTime = DateTime.ParseExact(date, "dd/MM/yyyy HH:mm", null);

            if (op == '+')
                dateTime = dateTime.AddMinutes(value);
            else if (op == '-')
                dateTime = dateTime.AddMinutes(-value);
            else
                throw new ArgumentException("Operação inválida. Use apenas '+' ou '-'.");

            return dateTime.ToString("dd/MM/yyyy HH:mm");
        }
    }
}
