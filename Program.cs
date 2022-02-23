using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetoEmerios
{
    static class Program
    {
        public static string[,] input = {
                {"B", "B", "D", "A", "D", "E", "F"},
                {"B", "X", "C", "D", "D", "J", "K"},
                {"H", "Y", "I", "3", "D", "D", "3"},
                {"R", "7", "O", "Ñ", "G", "D", "2"},
                {"W", "N", "S", "P", "E", "0", "D"},
                {"A", "9", "C", "D", "D", "E", "F"},
                {"B", "X", "D", "D", "D", "J", "K"}
            };
        public static int numRows = input.GetLength(0);
        public static int numCols = input.GetLength(1);
        public static int numRepeticiones = 0;
        public static string currentCaracter = "";
        static void Main(string[] args)
        {
            //Result
            Console.WriteLine("Reto: Encuentra la subcadena más larga presente en una matriz");
            Console.WriteLine("Dev: Carlos Medina Silvestre | Backend Developer .Net");
            Console.WriteLine("");
            Console.WriteLine("========================================================");
            Console.WriteLine(string.Format("Cadena mas larga : {0}", getMaxStringConsecutive()));
            Console.WriteLine(string.Format("Caracter: {0}  -  Numero de repeticiones: {1}", currentCaracter, numRepeticiones));
            Console.ReadKey();
        }

        public static string getMaxStringConsecutive()
        {
            StringBuilder str = new StringBuilder();
            int count;
            
            //Iterate Matrix
            for (int k = 0; k < numRows; k++)
            {
                for (int l = 0; l < numCols; l++)
                {
                    var val = input[k, l];
                    count = getStrRigth(k, l, val);
                    setNumRepeticiones(val, count);
                    count = getStrDownRigth(k, l, val);
                    setNumRepeticiones(val, count);
                    count = getStrDown(k, l, val);
                    setNumRepeticiones(val, count);
                    count = getStrDownLeft(k, l, val);
                    setNumRepeticiones(val, count);
                    count = getStrLeft(k, l, val);
                    setNumRepeticiones(val, count);
                    count = getStrUpLeft(k, l, val);
                    setNumRepeticiones(val, count);
                    count = getStrUp(k, l, val);
                    setNumRepeticiones(val, count);
                    count = getStrUpRigth(k, l, val);
                    setNumRepeticiones(val, count);   
                }
            }

            for (int i = 0; i < numRepeticiones; i++)
            {
                str.Append(currentCaracter);
            }

            return string.Join(",", str); ;
        }

        public static int getStrRigth(int row, int col, string str)
        {            
            if (col < numCols - 1)
            {
                var val = input[row, col + 1];
                //Console.WriteLine(val);
                if (str == val)
                    return 1 + getStrRigth(row, col + 1, str);              
            }
            return 0;            
        }

        public static int getStrLeft( int row, int col, string str)
        {
            if (col > 0)
            {
                var val = input[row, col - 1];
                //Console.WriteLine(val);
                if (str == val) 
                    return 1 + getStrLeft(row, col -1, str);
            }
            return 0;
        }

        public static int getStrUp(int row, int col, string str)
        {
            if (row > 0 && row < numRows - 1)
            {
                var val = input[row + 1, col];
                //Console.WriteLine(val);
                if(str == val)
                    return 1 + getStrUp(row + 1, col, str);
            }
            return 0;
        }

        public static int getStrDown(int row, int col, string str)
        {
            if (col < numCols - 1 && row < numRows - 1)
            { 
                var val = input[row + 1, col];
                //Console.WriteLine(val);
                if(str == val)
                    return 1 + getStrDown(row + 1, col, str);
            }
            return 0;
        }

        public static int getStrUpLeft(int row, int col, string str)
        {
            if (row > 0 && col > 0)
            {
                var val = input[row - 1, col - 1];
                //Console.WriteLine(val);
                if(str == val)
                    return 1 + getStrUpLeft(row - 1, col - 1, str);
            }
            return 0;
        }

        public static int getStrUpRigth(int row, int col, string str)
        {
            if (row > 0  && col < numCols - 1)
            {
                var val = input[row - 1, col + 1];
                //Console.WriteLine(val);
                if(str == val)
                    return 1 + getStrUpRigth(row - 1, col + 1, str);
            }
            return 0;
        }

        public static int getStrDownLeft(int row, int col, string str)
        {
            if ((col > 0 && col < numCols - 1) && row < numRows - 1)
            {
                var val = input[row + 1, col -1];
                //Console.WriteLine(val);
                if(str == val)
                    return 1 + getStrDownLeft(row + 1, col - 1, str);
            }
            return 0;
        }

        public static int getStrDownRigth(int row, int col, string str)
        {
            if (col < numCols - 1 && row < numRows - 1)
            {
                var val = input[row + 1, col + 1];
                //Console.WriteLine(val);
                if(str == val)
                    return 1 + getStrDownRigth(row + 1, col + 1, str);
            }
            return 0;
        }

        public static void setNumRepeticiones(string caracter, int repeticiones)
        {
            if (repeticiones > numRepeticiones)
            {
                currentCaracter = caracter;
                numRepeticiones = repeticiones;
            }            
        }
    }
}
