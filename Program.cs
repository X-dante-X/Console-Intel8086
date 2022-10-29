using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
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
                    case "ADD":
                        {
                            ADD(intel);
                            Writeout(intel);
                            break;
                        }
                    case "INC":
                        {
                            INC(intel);
                            Writeout(intel);
                            break;
                        }
                    case "DEC":
                        {
                            DEC(intel);
                            Writeout(intel);
                            break;
                        }
                    case "SUB":
                        {
                            SUB(intel);
                            Writeout(intel);
                            break;
                        }
                    case "NOT":
                        {
                            NOT(intel);
                            Writeout(intel);
                            break;
                        }
                    case "AND":
                        {
                            AND(intel);
                            Writeout(intel);
                            break;
                        }
                    case "OR":
                        {
                            OR(intel);
                            Writeout(intel);
                            break;
                        }
                    case "XOR":
                        {
                            XOR(intel);
                            Writeout(intel);
                            break;
                        }
                    default:
                        Console.WriteLine($"{fc} - Wrong function name");
                        break;
                }
            }







        }
        public static void checklen(ref string x)
        {
            if (x.Length > 2)
            {
                x = x.Remove(0, 1);
                checklen(ref x);
            }
            if (x.Length < 2)
            {
                x = x.Insert(0, "0");
                checklen(ref x);
            }
        }
        public static void Writeout(string[,] intel)
        {
            for (int i = 0; i < intel.GetLength(1); i++)
            {
                Console.WriteLine($"{intel[0, i]}={intel[1, i]}");
            }
        }

        public static string[,] AND(string[,] intel)
        {

            Console.WriteLine("Enter registers to AND");
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
                }

            }
            for (int i = 0; i < intel.GetLength(1); i++)
            {
                if (intel[0, i] == reg2)
                {
                    index2 = i;
                }

            }
            int tempreg1 = int.Parse(intel[1, index1], NumberStyles.AllowHexSpecifier);
            int tempreg2 = int.Parse(intel[1, index2], NumberStyles.AllowHexSpecifier);
            int and = tempreg1 & tempreg2;
            intel[1, index1] = Convert.ToString(Convert.ToInt32(and), 16).ToUpper();
            checklen(ref intel[1, index1]);
            return intel;
        }
        public static string[,] OR(string[,] intel)
        {

            Console.WriteLine("Enter registers to OR");
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
                }

            }
            for (int i = 0; i < intel.GetLength(1); i++)
            {
                if (intel[0, i] == reg2)
                {
                    index2 = i;
                }

            }
            int tempreg1 = int.Parse(intel[1, index1], NumberStyles.AllowHexSpecifier);
            int tempreg2 = int.Parse(intel[1, index2], NumberStyles.AllowHexSpecifier);
            int or = tempreg1 | tempreg2;
            intel[1, index1] = Convert.ToString(Convert.ToInt32(or), 16).ToUpper();
            checklen(ref intel[1, index1]);
            return intel;
        }
        public static string[,] XOR(string[,] intel)
        {

            Console.WriteLine("Enter registers to XOR");
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
                }

            }
            for (int i = 0; i < intel.GetLength(1); i++)
            {
                if (intel[0, i] == reg2)
                {
                    index2 = i;
                }

            }
            int tempreg1 = int.Parse(intel[1, index1], NumberStyles.AllowHexSpecifier);
            int tempreg2 = int.Parse(intel[1, index2], NumberStyles.AllowHexSpecifier);
            int xor = tempreg1 ^ tempreg2;
            intel[1, index1] = Convert.ToString(Convert.ToInt32(xor), 16).ToUpper();
            checklen(ref intel[1, index1]);
            return intel;
        }

        public static string[,] SUB(string[,] intel)
        {

            Console.WriteLine("Enter registers to SUB");
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
                }

            }
            for (int i = 0; i < intel.GetLength(1); i++)
            {
                if (intel[0, i] == reg2)
                {
                    index2 = i;
                }

            }
            int tempreg1 = int.Parse(intel[1, index1], NumberStyles.AllowHexSpecifier);
            int tempreg2 = int.Parse(intel[1, index2], NumberStyles.AllowHexSpecifier);
            int sub = tempreg1 - tempreg2;
            intel[1, index1] = Convert.ToString(Convert.ToInt32(sub), 16).ToUpper();
            checklen(ref intel[1, index1]);
            return intel;
        }
        public static string[,] NOT(string[,] intel)
        {

            Console.WriteLine("Enter register to NOT");
            string reg1 = Console.ReadLine().ToUpper();
            reg1 = checkreg(reg1);
            int index1 = 0;

            for (int i = 0; i < intel.GetLength(1); i++)
            {
                if (intel[0, i] == reg1)
                {
                    index1 = i;
                }

            }
            int tempreg1 = int.Parse(intel[1, index1], NumberStyles.AllowHexSpecifier);
            tempreg1= 255 - tempreg1;
            intel[1, index1] = Convert.ToString(Convert.ToInt32(tempreg1), 16).ToUpper();
            checklen(ref intel[1, index1]);
            return intel;
        }
        public static string[,] ADD(string[,] intel)
        {

            Console.WriteLine("Enter registers to ADD");
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
                }

            }
            for (int i = 0; i < intel.GetLength(1); i++)
            {
                if (intel[0, i] == reg2)
                {
                    index2 = i;
                }

            }
            int tempreg1 = int.Parse(intel[1,index1], NumberStyles.AllowHexSpecifier);
            int tempreg2 = int.Parse(intel[1, index2], NumberStyles.AllowHexSpecifier);
            int sum = tempreg1 + tempreg2;
            intel[1, index1] = Convert.ToString(Convert.ToInt32(sum), 16).ToUpper();
            checklen(ref intel[1, index1]);
            return intel;
        }
        public static string[,] INC(string[,] intel)
        {

            Console.WriteLine("Enter register to INC");
            string reg1 = Console.ReadLine().ToUpper();
            reg1 = checkreg(reg1);
            int index1 = 0;

            for (int i = 0; i < intel.GetLength(1); i++)
            {
                if (intel[0, i] == reg1)
                {
                    index1 = i;
                }

            }
            int tempreg1 = int.Parse(intel[1, index1], NumberStyles.AllowHexSpecifier);
            tempreg1++;
            intel[1, index1] = Convert.ToString(Convert.ToInt32(tempreg1), 16).ToUpper();
            checklen(ref intel[1, index1]);
            return intel;
        }
        public static string[,] DEC(string[,] intel)
        {

            Console.WriteLine("Enter register to DEC");
            string reg1 = Console.ReadLine().ToUpper();
            reg1 = checkreg(reg1);
            int index1 = 0;

            for (int i = 0; i < intel.GetLength(1); i++)
            {
                if (intel[0, i] == reg1)
                {
                    index1 = i;
                }

            }
            int tempreg1 = int.Parse(intel[1, index1], NumberStyles.AllowHexSpecifier);
            tempreg1--;
            intel[1, index1] = Convert.ToString(Convert.ToInt32(tempreg1), 16).ToUpper();
            checklen(ref intel[1, index1]);
            return intel;
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

