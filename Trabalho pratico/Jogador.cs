using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Trabalho_pratico
{
    internal class Jogador
    {
        public string nome;
        public Cartela [] cartelas;

        public Jogador(string nome, int quantcartelas)
        {
            this.nome = nome;
            cartelas = new Cartela[quantcartelas];

            for (int i = 0; i < quantcartelas; i++)
            {
                Cartela novaCartela;
                bool cartelaUnica;

                do
                {
                    novaCartela = new Cartela();
                    novaCartela.Prenchercartela();
                    cartelaUnica = true;

                    
                    for (int j = 0; j < i; j++) 
                    {
                        if (Verificarcartelas(cartelas[j], novaCartela))
                        {
                            cartelaUnica = false;
                            break;
                        }
                    }
                }
                while (!cartelaUnica); 

                cartelas[i] = novaCartela; 
            }
        }
        public bool VerificaNumero(int numero)
        {
            foreach (Cartela cartela in cartelas)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (cartela.cartelas[i, j] == numero)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        private bool Verificarcartelas(Cartela cartela1, Cartela cartela2)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (cartela1.cartelas[i, j] != cartela2.cartelas[i, j])
                    {
                        return false;
                    }
                }
            }
            return true; 
        }
        public void ExibirInformacoes()
        {
            Console.WriteLine("Nome:" + nome);
            Console.WriteLine("Cartelas do jogador:");
            for (int i = 0; i < cartelas.Length; i++)
            {
                Console.WriteLine($"\nCartela {i + 1}:");
                cartelas[i].ExibirCartela();
            }
        }
    }
}
