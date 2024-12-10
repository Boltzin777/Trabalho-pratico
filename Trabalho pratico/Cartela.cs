using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_pratico
{
    internal class Cartela
    {
        public int[,] cartelas = new int [5,5];
        private int[] numcartela = new int[25];

        public void Prenchercartela()
        {
            Random rand = new Random();
            for (int i = 0; i < cartelas.GetLength(0); i++) 
            {
                for (int j = 0; j < cartelas.GetLength(1); j++) 
                {                   
                    int numero;
                    bool repetido;
                    do
                    {

                        if (j == 0) numero = rand.Next(1, 16);
                       
                        else if (j == 1) numero = rand.Next(16, 31);

                        else if (j == 2) numero = rand.Next(31, 46);

                        else if (j == 3) numero = rand.Next(46, 61);

                        else numero = rand.Next(61, 76);


                        repetido = false;
                        for (int k = 0; k < cartelas.GetLength(0); k++)
                        {
                            for (int l = 0; l < cartelas.GetLength(1); l++)
                            {
                                if (cartelas[k, l] == numero)
                                {
                                    repetido = true;
                                    break;
                                }
                            }
                            if (repetido) break;
                        }
                    } while (repetido);

                    cartelas[i, j] = numero;
                }
            }
            cartelas[2, 2] = 0;
            int cont = 0;
            for (int i = 0; i < cartelas.GetLength(0); i++)
            {
                for (int j = 0; j < cartelas.GetLength(1); j++)
                {
                    numcartela[cont++] = cartelas[i, j];
                }
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
        public void ExibirCartela()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write($"{cartelas[i, j],3} ");
                }
                Console.WriteLine();
            }
        }

        public void ExibirCartelaarq(StreamWriter writer)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    writer.Write($"{cartelas[i, j],3} ");
                }
                writer.WriteLine();
            }
        }


    }
}
