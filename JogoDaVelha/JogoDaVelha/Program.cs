using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaVelha
{
    internal class Program
    {
        public static char P1 { get; set; } = '1';
        public static char P2 { get; set; } = '2';
        public static char P3 { get; set; } = '3';
        public static char P4 { get; set; } = '4';
        public static char P5 { get; set; } = '5';
        public static char P6 { get; set; } = '6';
        public static char P7 { get; set; } = '7';
        public static char P8 { get; set; } = '8';
        public static char P9 { get; set; } = '9';
        public static char simbl { get; set; } = 'X';
        public static int rodada { get; set; } = 0;
        public static string jogadorDaVez { get; set; } = "";
        public static char pEscolhida { get; set; } = ' ';

        static void Main(string[] args)
        {

            string nomeJogador1; string nomeJogador2;

            Console.WriteLine("Informe o nome do Player 1");
            nomeJogador1 = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"{nomeJogador1}, seu símbolo será X ! \n");

            Console.WriteLine("Informe o nome do Player 2");
            nomeJogador2 = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"{nomeJogador2}, seu símbolo será O ! \n");

            Console.WriteLine("Aperte qualquer tecla para iniciar");

            Console.ReadKey();

            while (verificarVitoria() == false && verificaEmpate() == false)
            {
                rodada++;

                gerarMatriz();

                verificaTurno();

                msgColetaPosicao(nomeJogador1, nomeJogador2);

                pEscolhida = Convert.ToChar(Console.ReadLine());

                verificaCampoInvalido(pEscolhida);

                marcarCampo(pEscolhida);

                gerarMatriz();


            }

            if (verificarVitoria() == true)
            {
                Console.WriteLine(verificaJogador(nomeJogador1, nomeJogador2) + ", parabéns! Você venceu!");
            }

            if (verificaEmpate() == true)
            {
                Console.WriteLine("Tivemos um empate!");
            }

            Console.ReadKey();


        }


        static void marcarCampo(char pEscolhida)
        {

            switch (pEscolhida)
            {
                case '1':

                    P1 = simbl;
                    break;


                case '2':

                    P2 = simbl;
                    break;

                case '3':

                    P3 = simbl;
                    break;

                case '4':

                    P4 = simbl;
                    break;

                case '5':

                    P5 = simbl;
                    break;

                case '6':

                    P6 = simbl;
                    break;

                case '7':

                    P7 = simbl;
                    break;

                case '8':

                    P8 = simbl;
                    break;

                case '9':

                    P9 = simbl;
                    break;


                default:
                    verificaCampoInvalido(pEscolhida);
                    break;

            }


        }

        static void verificaTurno()
        {

            if (rodada % 2 != 0)
            {
                simbl = 'X';
            }

            else
            {
                simbl = 'O';
            }

        }

        static string verificaJogador(string play1, string play2)
        {

            if (rodada % 2 != 0)
            {
                jogadorDaVez = play1;
            }

            else
            {
                jogadorDaVez = play2;
            }

            return jogadorDaVez;
        }


        static void gerarMatriz()
        {
            Console.Clear();

            Console.WriteLine("\n");
            Console.WriteLine($"  {P1}  |  {P2}  |  {P3}  ");
            Console.WriteLine("-----|-----|-----");
            Console.WriteLine($"  {P4}  |  {P5}  |  {P6}  ");
            Console.WriteLine("-----|-----|-----");
            Console.WriteLine($"  {P7}  |  {P8}  |  {P9}  ");
            Console.WriteLine("\n");



        }

        static void msgColetaPosicao(string play1, string play2)
        {

            if (rodada % 2 != 0)
            {
                Console.WriteLine(play1 + ", informe qual posição deseja jogar");
            }

            else
            {
                Console.WriteLine(play2 + ", informe qual posição deseja jogar");
            }



        }

        static void verificaCampoInvalido(char pEscolhidaNovamente)
        {

            bool controle = false;


            while (controle == false)
            {

                pEscolhidaNovamente = pEscolhida;

                if (P2 == 'X' && pEscolhidaNovamente == '2' || P1 == 'O' && pEscolhidaNovamente == '1' ||
                    P4 == 'X' && pEscolhidaNovamente == '4' || P3 == 'O' && pEscolhidaNovamente == '3' ||
                    P1 == 'X' && pEscolhidaNovamente == '1' || P4 == 'O' && pEscolhidaNovamente == '4' ||
                    P5 == 'X' && pEscolhidaNovamente == '5' || P5 == 'O' && pEscolhidaNovamente == '5' ||
                    P3 == 'X' && pEscolhidaNovamente == '3' || P2 == 'O' && pEscolhidaNovamente == '2' ||
                    P6 == 'X' && pEscolhidaNovamente == '6' || P6 == 'O' && pEscolhidaNovamente == '6' ||
                    P7 == 'X' && pEscolhidaNovamente == '7' || P7 == 'O' && pEscolhidaNovamente == '7' ||
                    P8 == 'X' && pEscolhidaNovamente == '8' || P8 == 'O' && pEscolhidaNovamente == '8' ||
                    P9 == 'X' && pEscolhidaNovamente == '9' || P9 == 'O' && pEscolhidaNovamente == '9')
                {
                    Console.Clear();
                    gerarMatriz();
                    Console.WriteLine("Este campo nao e valido, selecione novamente.");
                    pEscolhida = Convert.ToChar(Console.ReadLine());
                }

                else
                {
                    controle = true;
                }
            }
        }

        static bool verificarVitoria()
        {

            if (P1 == P4 && P1 == P7 || P2 == P5 && P2 == P8 || P3 == P6 && P3 == P9 ||
                P1 == P2 && P1 == P3 || P4 == P5 && P4 == P6 || P7 == P8 && P7 == P9 ||
                P1 == P5 && P1 == P9 || P3 == P5 && P3 == P7)

            {
                return true;
            }

            else
            {
                return false;
            }

        }

        static bool verificaEmpate()
        {
            if (rodada == 9 && verificarVitoria() == false)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
    }
}
