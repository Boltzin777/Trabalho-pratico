using System;
using System.IO;

namespace Trabalho_pratico
{
    class Program
    {
        static void Main(string[] args)
        {
            int numJogadores = 0;
            while (numJogadores < 2 || numJogadores > 5)
            {
                Console.Write("Informe o número de jogadores (mínimo 2 e máximo 5): ");
                numJogadores = int.Parse(Console.ReadLine());
            }

            Jogador[] jogadores = new Jogador[numJogadores];

            for (int i = 0; i < numJogadores; i++)
            {
                Console.Write($"Informe o nome do Jogador {i + 1}: ");
                string nome = Console.ReadLine();

                int numCartelas = 0;
                while (numCartelas < 1 || numCartelas > 4)
                {
                    Console.Write($"Quantas cartelas o jogador {nome} vai jogar? (mínimo 1, máximo 4): ");
                    numCartelas = int.Parse(Console.ReadLine());
                }

                jogadores[i] = new Jogador(nome, numCartelas);
            }

            Bingo bingo = new Bingo(jogadores);

         
            StreamWriter writer = new StreamWriter("log_jogo_bingo.txt", false);
            writer.WriteLine("Início do jogo de Bingo");
            writer.WriteLine($"Número de jogadores: {numJogadores}");
            for (int i = 0; i < numJogadores; i++)
            {
                writer.WriteLine($"Jogador: {jogadores[i].nome}, Cartelas: {jogadores[i].cartelas.Length}");
            }

            bool jogoAtivo = true;
            while (jogoAtivo)
            {
                for (int i = 0; i < numJogadores; i++)
                {
                    writer.WriteLine($"\nCartelas do jogador {jogadores[i].nome}:");
                    jogadores[i].ExibirInformacoesarq(writer);
                    jogadores[i].ExibirInformacoes();
                }

                int numeroSorteado = bingo.Realizarsorteio();
                writer.WriteLine($"\nNúmero sorteado: {numeroSorteado}");
                Console.WriteLine($"\nNúmero sorteado: {numeroSorteado}");

                for (int i = 0; i < numJogadores; i++)
                {
                    jogadores[i].VerificaNumero(numeroSorteado);
                }

                bingo.VerificarBingo();

                writer.WriteLine("\nDeseja sortear o próximo número? (s/n): ");
                Console.WriteLine("\nDeseja sortear o próximo número? (s/n): ");
                string resposta = Console.ReadLine().ToLower();
                if (resposta != "s")
                {
                    Console.WriteLine("Deseja encerar o jogo? (s/n)");
                    resposta = Console.ReadLine().ToLower();
                    if(resposta == "s")
                    jogoAtivo = false;

                }

                int countBingo = 0;
                for (int i = 0; i < numJogadores; i++)
                {
                    for (int j = 0; j < jogadores[i].cartelas.Length; j++)
                    {
                        if (jogadores[i].cartelas[j].Verificarbingo())
                        {
                            countBingo++;
                            break;
                        }
                    }
                }

                if (countBingo == numJogadores - 1)
                {
                    jogoAtivo = false;
                }
            }

            writer.WriteLine("\nO jogo terminou! Ranking dos jogadores:");
            
            for (int i = 0; i < numJogadores - 1; i++)
            {
                for (int j = i + 1; j < numJogadores; j++)
                {
                    bool bingoI = false;
                    bool bingoJ = false;

                    
                    for (int k = 0; k < jogadores[i].cartelas.Length; k++)
                    {
                        if (jogadores[i].cartelas[k].Verificarbingo())
                        {
                            bingoI = true;
                            break;
                        }
                    }

                    for (int k = 0; k < jogadores[j].cartelas.Length; k++)
                    {
                        if (jogadores[j].cartelas[k].Verificarbingo())
                        {
                            bingoJ = true;
                            break;
                        }
                    }

                    if (bingoI && !bingoJ)
                    {
                        Jogador temp = jogadores[i];
                        jogadores[i] = jogadores[j];
                        jogadores[j] = temp;
                    }
                }
            }

            for (int i = 0; i < numJogadores; i++)
            {
                jogadores[i].ExibirInformacoesarq(writer);
                jogadores[i].ExibirInformacoes();
            }

            writer.WriteLine("Fim do jogo.");
            Console.WriteLine("Fim de jogo");
            writer.Close();
        }
    }
}
