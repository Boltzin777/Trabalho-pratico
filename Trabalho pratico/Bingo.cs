using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_pratico
{
    internal class Bingo
    {
        public int[] numsorteados = new int[75];
        private int indiceAtual = 0;

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

        public void ExibirNumerosSorteados()
        {
            Console.WriteLine("Números sorteados:");
            for (int i = 0; i < indiceAtual; i++)
            {
                Console.Write(numsorteados[i] + (i < indiceAtual - 1 ? ", " : "\n"));
            }
        }
        public bool Verificarbingo()
        {
            
            for (int i = 0; i < 5; i++)
            {
                bool linhaCompleta = true;
                for (int j = 0; j < 5; j++)
                {
                    if (cartelas[i, j] != 0)
                    {
                        linhaCompleta = false;
                        break;
                    }
                }
                if (linhaCompleta) return true;  
            }

            
            for (int j = 0; j < 5; j++)
            {
                bool colunaCompleta = true;
                for (int i = 0; i < 5; i++)
                {
                    if (cartelas[i, j] != 0)
                    {
                        colunaCompleta = false;
                        break;
                    }
                }
                if (colunaCompleta) return true;  
            }

            return false; 
        }
    }

}
    

