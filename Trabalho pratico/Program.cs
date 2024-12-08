
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
            Cartela cartela = new Cartela();
            cartela.Prenchercartela();
            cartela.ExibirCartela();
            Console.ReadLine();
        }
    }
}
