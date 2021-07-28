using System;

namespace jogoDeDados
{
    class Program
    {
        static void Main(string[] args)
        {
            sorteio valor = new sorteio();
            string quer, nome1, nome2, jogador1, jogador2; ;
            double aposta, banco1, banco2;
            int soma1, soma2;

            Console.WriteLine("Você quer jogar? (sim ou nao)");
            quer = Console.ReadLine();

            if (quer == "nao" || quer == "não" || quer == "Nao" || quer == "Não")
            {
                Console.WriteLine("fim de jogo");
            }
            else
            {
                Console.WriteLine("digite o nome de um jogador");
                nome1 = Console.ReadLine();

                Console.WriteLine("digite o nome do outro jogador");
                nome2 = Console.ReadLine();

                // decidir o primeiro
                Console.WriteLine("vamos decidir quem será o jogador 1!!\n rode os dados, o jogador que tirar o maior número será o primeiro");
            Dados:
                {
                    valor.Dado(nome1);
                    soma1 = valor.Soma;

                    valor.Dado(nome2);
                    soma2 = valor.Soma;

                    if (soma1 > soma2)
                    {
                        jogador1 = nome1;
                        jogador2 = nome2;
                    }
                    else if (soma1 < soma2)
                    {
                        jogador2 = nome1;
                        jogador1 = nome2;
                    }
                    else
                    {
                        Console.WriteLine("os dados deram iguais, jogue novamente");
                        goto Dados;
                    }
                }
                Console.WriteLine("O jogador 1 é {0}, o jogador 2 é {1}", jogador1, jogador2);

                Console.WriteLine("Quanto dinheiro tem para apostar,{0}?", jogador1);
                banco1 = double.Parse(Console.ReadLine());

                Console.WriteLine("Quanto dinheiro tem para apostar,{0}?", jogador2);
                banco2 = double.Parse(Console.ReadLine());

                while (true)
                {
                    Console.WriteLine("qual a aposta da vez? todos os jogadores irão apostar o mesmo valor");
                    aposta = double.Parse(Console.ReadLine()) * 2;
                    banco1 -= aposta / 2;
                    banco2 -= aposta / 2;

                    valor.Dado(jogador1);//rodar dados do jogador;
                    soma1 = valor.Soma;

                    valor.Perda(soma1, aposta, banco2, banco1, jogador1, jogador2);//verificação de derrota--  dados do perdedor / aposta / banco ganhador / banco perdedor / nome ganhador / nome perdedor
                    if (valor.Fim == 1)
                    {
                        break;
                    }

                    valor.Dado(jogador2);//rodar dados do jogador;
                    soma2 = valor.Soma;

                    valor.Perda(soma2, aposta, banco1, banco2, jogador2, jogador1);//verificação de derrota--  dados do perdedor / aposta / banco ganhador / banco perdedor / nome ganhador / nome perdedor
                Joguin:
                    {
                        if (soma1 > soma2)
                        {
                            banco1 += aposta;
                        }
                        else if (soma1 < soma2)
                        {
                            banco2 += aposta;
                        }
                        else
                        {
                            Console.WriteLine("os dados deram iguais, jogue novamente");
                            goto Joguin;
                        }

                        if (valor.Fim == 1)
                        {
                            break;
                        }
                        if (banco1 <= 0 || banco2 <= 0)
                        {
                            Console.WriteLine("acabou o dinheiro");
                            Console.WriteLine("resultado final: \n{0} - {1} reais\n{2} - {3} reais", jogador1, banco1, jogador2, banco2);
                            break;
                        }
                    }
                Fim:
                    {
                        Console.WriteLine("fim de jogo");
                        Console.ReadKey();
                    }
                }
            }
        }
    }
}
