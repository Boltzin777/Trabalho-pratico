
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_pratico
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Jogador jogador = new Jogador("Lucas", 4);           
            jogador.ExibirInformacoes();          
            Console.WriteLine("\nDigite um número para verificar nas cartelas:");
            int numero = int.Parse(Console.ReadLine());
            if (jogador.VerificaNumero(numero))
            {
                Console.WriteLine($"O número {numero} está presente nas cartelas do jogador {jogador.nome}.");
            }
            else
            {
                Console.WriteLine($"O número {numero} NÃO está presente nas cartelas do jogador {jogador.nome}.");
            }
            Console.ReadLine();
        }
    }
}
