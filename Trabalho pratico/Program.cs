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

            using (StreamWriter writer = new StreamWriter("log_jogo_bingo.txt", false))
            {
                writer.WriteLine("Início do jogo de Bingo");
                writer.WriteLine($"Número de jogadores: {numJogadores}");
                foreach (Jogador jogador in jogadores)
                {
                    writer.WriteLine($"Jogador: {jogador.nome}, Cartelas: {jogador.cartelas.Length}");
                }

                bool jogoAtivo = true;
                while (jogoAtivo)
                {
                    foreach (Jogador jogador in jogadores)
                    {
                        writer.WriteLine($"\nCartelas do jogador {jogador.nome}:");
                        jogador.ExibirInformacoes(writer);
                    }

                    int numeroSorteado = bingo.Realizarsorteio();
                    writer.WriteLine($"\nNúmero sorteado: {numeroSorteado}");

                    foreach (Jogador jogador in jogadores)
                    {
                        jogador.VerificaNumero(numeroSorteado);
                    }

                    bingo.VerificarBingo();

                    writer.WriteLine("\nDeseja sortear o próximo número? (s/n): ");
                    string resposta = Console.ReadLine().ToLower();
                    if (resposta != "s")
                    {
                        jogoAtivo = false;
                    }

                    int countBingo = 0;
                    foreach (Jogador jogador in jogadores)
                    {
                        foreach (Cartela cartela in jogador.cartelas)
                        {
                            if (cartela.Verificarbingo())
                            {
                                countBingo++;
                                break;
                            }
                        }
                    }

                    if (countBingo == jogadores.Length - 1)
                    {
                        jogoAtivo = false;
                    }
                }

                writer.WriteLine("\nO jogo terminou! Ranking dos jogadores:");
                Array.Sort(jogadores, (x, y) => x.cartelas[0].Verificarbingo().CompareTo(y.cartelas[0].Verificarbingo()));

                foreach (Jogador jogador in jogadores)
                {
                    jogador.ExibirInformacoes(writer);
                }

                writer.WriteLine("Fim do jogo.");
            }
        }
    }
}
