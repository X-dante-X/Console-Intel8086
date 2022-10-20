﻿using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intel
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string[,] intel = new string[2, 8] { { "AL", "AH", "BL", "BH", "CL", "CH", "DL", "DH" }, { "", "", "", "", "", "", "", "" } };
            Console.WriteLine("Enter data into registers");
            for (int i = 0; i < intel.GetLength(1); i++)
            {
                string date = Console.ReadLine().ToUpper();
                date = checkdate(date);
                intel[1, i] = date;

            }
            Writeout(intel);


            while (true)
            {
                Console.WriteLine("Enter function name");
                string fc = Console.ReadLine().ToUpper();
                switch (fc)
                {
                    case "MOV":
                        {
                            MOV(intel);
                            Writeout(intel);
                            break;
                        }
                    case "XCHG":
                        {
                            XCHG(intel);
                            Writeout(intel);
                            break;
                        }
                    default:
                        Console.WriteLine($"{fc} - Wrong function name");
                        break;
                }
            }







        }
        public static void Writeout(string[,] intel)
        {
            for (int i = 0; i < intel.GetLength(1); i++)
            {
                Console.WriteLine($"{intel[0, i]}={intel[1, i]}");
            }
        }

        public static string[,] XCHG(string[,] intel)
        {
            
            Console.WriteLine("Enter registers to XCHG");
            string reg1 = Console.ReadLine().ToUpper();
            string reg2 = Console.ReadLine().ToUpper();
            reg1 = checkreg(reg1);
            reg2 = checkreg(reg2);
            int index1 = 0;
            int index2 = 0;
            string tempreg;

            for (int i = 0; i < intel.GetLength(1); i++)
            {
                if (intel[0, i] == reg1)
                {
                    index1 = i;
                }

            }
            for (int i = 0; i < intel.GetLength(1); i++)
            {
                if (intel[0, i] == reg2)
                {
                    index2 = i;
                }

            }
            tempreg = intel[1, index1];
            intel[1, index1] = intel[1, index2];
            intel[1, index2] = tempreg;
            return intel;
        }
        public static string[,] MOV(string[,] intel)
        {
            Console.WriteLine("Enter registers to MOV");
            string reg1 = Console.ReadLine().ToUpper();
            string reg2 = Console.ReadLine().ToUpper();
            reg1 = checkreg(reg1);
            reg2 = checkreg(reg2);
            int index1 = 0;
            int index2 = 0;

            for (int i = 0; i < intel.GetLength(1); i++)
            {
                if (intel[0, i] == reg1)
                {
                    index1 = i;
                    break;
                }

            }
            for (int i = 0; i < intel.GetLength(1); i++)
            {
                if (intel[0, i] == reg2)
                {
                    index2 = i;
                    break;
                }

            }
            intel[1, index1] = intel[1, index2];
            return intel;
        }

        public static string checkreg(string x)
        {
            if (x == "AL" || x == "AH" || x == "BL" || x == "BH" || x == "CL" || x == "CH" || x == "DL" || x == "DH")
            {
                return x;
            }
            else
            {
                string message = $"{x} - This register does not exist";
                Console.WriteLine(message);
                Environment.Exit(0);
                return "not allowed";
            }
        }

        public static string checkdate(string x)

        {
            if (x.Length == 2)
            {
                if (x[1] == '0' || x[1] == '1' || x[1] == '2' || x[1] == '3' || x[1] == '4' || x[1] == '5' || x[1] == '6' || x[1] == '7' || x[1] == '8' || x[1] == '9' || x[1] == 'A' || x[1] == 'B' || x[1] == 'C' || x[1] == 'D' || x[1] == 'E' || x[1] == 'F')
                {
                    if (x[1] == '0' || x[1] == '1' || x[1] == '2' || x[1] == '3' || x[1] == '4' || x[1] == '5' || x[1] == '6' || x[1] == '7' || x[1] == '8' || x[1] == '9' || x[1] == 'A' || x[1] == 'B' || x[1] == 'C' || x[1] == 'D' || x[1] == 'E' || x[1] == 'F')
                    {
                        return x;
                    }
                    else
                    {
                        string message = $"{x} - Unexceptable value";
                        Console.WriteLine(message);
                        System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.FriendlyName);
                        Environment.Exit(0);
                        return "not allowed";
                    }
                }
                else
                {
                    string message = $"{x} - Unexceptable value";
                    Console.WriteLine(message);
                    System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.FriendlyName);
                    Environment.Exit(0);
                    return "not allowed";
                }

            }
            else
            {
                string message = $"{x} - Unexceptable value";
                Console.WriteLine(message);
                System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.FriendlyName);
                Environment.Exit(0);
                return "not allowed";
            }



        }

    }
}

