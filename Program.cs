using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connect4
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] tabla = new char[6,7];
            for (int i = 0; i < tabla.GetLength(0); i++)
            {
                for (int j = 0; j < tabla.GetLength(1); j++)
                {
                    tabla[i, j] = '#';
                    Console.Write(tabla[i,j]+"  ");
                }
                Console.WriteLine();
            }
            bool vegeredmeny=true;
            bool asd=true;
            bool szin = true;
            bool dont = true;
            while (asd)
            {
                int oszlop;
                Beolvas:
                if (szin)
                {
                    Console.WriteLine("A piros játékos jön!");
                }
                else
                {
                    Console.WriteLine("A sárga jatekos jön!");
                }
                string oszlop0 = Console.ReadLine();
                if (oszlop0=="1" || oszlop0 == "2" || oszlop0 == "3" || oszlop0 == "4" || oszlop0 == "5" || oszlop0 == "6" || oszlop0 == "7")
                {
                oszlop = int.Parse(oszlop0)-1;
                    
                }
                else
                {
                    Console.WriteLine("1 és 7 közötti számot adj meg!");
                    goto Beolvas;
                }
                if (tabla[5,oszlop]!='#')
                {
                    Console.WriteLine("Ez az oszlop tele van!");
                }
                else
                {
                    for (int i = 0; i < tabla.GetLength(0); i++)
                    {
                        if (tabla[i,oszlop]=='#')
                        {
                            if (szin)
                            {
                                tabla[i, oszlop] = 'O';
                                szin = false;
                            }
                            else
                            {
                                tabla[i, oszlop] = 'X';
                                szin = true;
                            }
                            break;
                        }
                    }
                    Console.Clear();
                    for (int i = tabla.GetLength(0) - 1; i > -1; i--)
                    {
                        for (int j = 0; j < tabla.GetLength(1); j++)
                        {
                            if (tabla[i, j]=='X')
                            {
                                Console.ForegroundColor=ConsoleColor.Yellow;
                                Console.Write(tabla[i, j] + "  ");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else if (tabla[i, j] == 'O')
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(tabla[i, j] + "  ");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                Console.Write(tabla[i, j] + "  ");
                            }
                        }
                        Console.WriteLine();
                    }
                }
                //4 megvan
                //fuggoleges
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < tabla.GetLength(1); j++)
                    {
                        //kek vagy X
                        if (tabla[i, j] =='X' && tabla[i+1, j] == 'X' && tabla[i + 2, j] == 'X' && tabla[i + 3, j] == 'X')
                        {
                            goto Vege;
                        }
                        //piros vagy O
                        if (tabla[i, j] == 'O' && tabla[i + 1, j] == 'O' && tabla[i + 2, j] == 'O' && tabla[i + 3, j] == 'O')
                        {
                            vegeredmeny = false;
                            goto Vege;
                        }
                    }
                }
                //vizszintes
                for (int i = 0; i < tabla.GetLength(0); i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        //kek vagy X
                        if (tabla[i, j] == 'X' && tabla[i , j + 1] == 'X' && tabla[i , j + 2] == 'X' && tabla[i , j + 3] == 'X')
                        {
                            goto Vege;
                        }
                        //piros vagy O
                        if (tabla[i, j] == 'O' && tabla[i , j + 1] == 'O' && tabla[i , j + 2] == 'O' && tabla[i , j + 3] == 'O')
                        {
                            vegeredmeny = false;
                            goto Vege;
                        }
                    }
                }
                //atlo jobbfel
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        //kek vagy X
                        if (tabla[i, j] == 'X' && tabla[i + 1, j + 1] == 'X' && tabla[i + 2, j + 2] == 'X' && tabla[i + 3, j + 3] == 'X')
                        {
                            goto Vege;
                        }
                        //piros vagy O
                        if (tabla[i, j] == 'O' && tabla[i + 1, j + 1] == 'O' && tabla[i + 2, j + 2] == 'O' && tabla[i + 3, j + 3] == 'O')
                        {
                            vegeredmeny = false;
                            goto Vege;
                        }
                    }
                }
                //atlo balfel
                for (int i = 3; i < 6; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        //kek vagy X
                        if (tabla[i, j] == 'X' && tabla[i - 1, j + 1] == 'X' && tabla[i - 2, j + 2] == 'X' && tabla[i - 3, j + 3] == 'X')
                        {
                            goto Vege;
                        }
                        //piros vagy O
                        if (tabla[i, j] == 'O' && tabla[i - 1, j + 1] == 'O' && tabla[i - 2, j + 2] == 'O' && tabla[i - 3, j + 3] == 'O')
                        {
                            vegeredmeny = false;
                            goto Vege;
                        }
                    }
                }
                dont = true;
                //dontetlen
                for (int i = 0; i < tabla.GetLength(1); i++)
                {
                    if (tabla[5,i]=='#')
                    {
                        dont = false;
                        break;
                    }
                }
                if (dont)
                {
                    goto dontetlen;
                }
            }
            Vege:
            if (vegeredmeny)
            {
                Console.WriteLine("A sárga játékos nyert!");
            }
            else
            {
                Console.WriteLine("A piros játékos nyert!");
            }
            dontetlen:
            if (dont)
            {
                Console.WriteLine("Az eredmény döntetlen!");
            }
            Console.ReadKey();
        }
    }
}
