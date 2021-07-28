using System;
using System.Collections.Generic;
using System.Text;

namespace jogoDeDados
{
    class sorteio
    {
        public int Dado1 { get; set; }
        public int Dado2 { get; set; }



        Random dado = new Random();

        public int Soma;
        public int Fim = 0;
        public int Rodada = 0;

        public void Dado(string name)
        {
            Console.WriteLine("aperte qualquer tecla para rodar os dados do jogador " + name);
            Console.ReadKey();

            Dado1 = dado.Next(5) + 1;
            Dado2 = dado.Next(5) + 1;
            this.Soma = Dado1 + Dado2;
            Console.WriteLine("dado 1: {0}, dado 2: {1}, total: {2}", Dado1, Dado2, Soma);
        }
        public void Perda(int dadosPerdedor, double apostaa, double bancoGanhador, double bancoPerdedor, string perdedor, string ganhador)
        {
            
            
            if (dadosPerdedor == 7 || dadosPerdedor == 11)
                {
                    bancoGanhador += apostaa;
                    Console.WriteLine("O jogador {2} perdeu a rodada, tirando {0} nos dados, o valor {1} ficou para o jogador {4}.\n carteira atual:\n {4} - {5} reais \n {2} - {3} reais ", dadosPerdedor, apostaa, perdedor, bancoPerdedor, ganhador, bancoGanhador);
                    this.Rodada = 1;
                }
               
            else if (dadosPerdedor == 2 || dadosPerdedor == 3 || dadosPerdedor == 12)
                {
                    bancoGanhador += apostaa;
                    Console.WriteLine(" O jogador {3} ganhou a partida, recebendo um total de {1} reais, o jogador {2} perdeu a partida ao tirar {0} nos dados,\n totalizando {1} reais para a carteira de {3}\n carteira atual:\n {2} - {5} reais \n {3} - {4} reais ", dadosPerdedor, apostaa, perdedor, ganhador, bancoGanhador, bancoPerdedor);
                    this.Fim = 1;
                }
            }    
    }
}
