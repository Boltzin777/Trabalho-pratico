using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_pratico
{
    internal class Bingo
    {
        public Jogador[] jogadores;
        public int[] numsorteados = new int[75];
        private int indiceAtual = 0;

        public Bingo(Jogador[] jogadores)
        {
            this.jogadores = jogadores;
        }
        public int Realizarsorteio()
        {           
            Random random = new Random();
            int numeroSorteado;
            bool jaSorteado;           
            do
            {
                numeroSorteado = random.Next(1, 76); 
                jaSorteado = false;

               
                for (int i = 0; i < indiceAtual; i++)
                {
                    if (numsorteados[i] == numeroSorteado)
                    {
                        jaSorteado = true;
                        break;
                    }
                }

            } while (jaSorteado);

            
            numsorteados[indiceAtual] = numeroSorteado;
            indiceAtual++; 

            return numeroSorteado;
        }
        public void VerificarBingo()
        {
            foreach (Jogador jogador in jogadores)
            {
                foreach (Cartela cartela in jogador.cartelas)
                {
                    if (cartela.Verificarbingo())
                    {
                        Console.WriteLine($"{jogador.nome} fez Bingo!");                        
                    }
                }
            }            
        }
        public void ExibirNumerosSorteados()
        {
            Console.WriteLine("Números sorteados:");
            for (int i = 0; i < indiceAtual; i++)
            {
                Console.Write(numsorteados[i] + (i < indiceAtual - 1 ? ", " : "\n"));
            }
        }   
    }
}
    

