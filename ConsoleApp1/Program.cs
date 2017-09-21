using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            Table tabla = new Table();
            Cell[,] cellSystem = new Cell[tabla.GetRows(),tabla.GetColumns()];

            cellSystem = PrepareSystem(tabla, cellSystem);

            PrintTable(tabla.GetColumns(), tabla.GetRows(), cellSystem);
            Console.ReadLine();

            while (true)
            {
                Console.WriteLine();
                RefreshSystem(tabla, cellSystem);
                PrintTable(tabla.GetColumns(), tabla.GetRows(), cellSystem);
                Console.ReadLine();
            }

        }

        public static void PrintColumns(int columns)
        {
            for (int i = 0; i < columns; i++)
            {
                Console.Write(" --");
            }
            Console.Write("\n");
        }

        public static void PrintRows(int columns, Cell[,] cellSystem, int row)
        {
            
            for (int i = 0; i < columns; i++)
            {
                if (cellSystem[row,i].GetExist())
                {
                    Console.Write("|X ");
                }
                else
                {
                    Console.Write("|  ");
                }
            }

            Console.Write("|\n");
        }

        public static void PrintTable(int columns, int rows, Cell[,] cellSystem)
        {
            for (int i = 0; i < rows; i++)
            {
                PrintColumns(columns);
                PrintRows(columns, cellSystem, i);
            }
            PrintColumns(columns);
        }

        public static Cell[,] PrepareSystem(Table tabla, Cell[,] cellSystem)
        {

            int cell = 0;
            for (int row = 0; row < tabla.GetRows(); row++)
            {
                for (int column = 0; column < tabla.GetColumns(); column++)
                {
                    if((row)%2 == 0 || column == 2)
                    {
                        cellSystem[row,column] = new Cell(column, row, true);
                    }
                    else
                    {
                        cellSystem[row,column] = new Cell(column, row, false);
                    }
                    cell++;
                }
            }

            return cellSystem;
        }

        public static Cell[,] RefreshSystem(Table table, Cell[,] cellSystem)
        {
            Boolean[,] exist = new Boolean[table.GetRows(), table.GetColumns()];
            for(int row = 0; row < table.GetRows(); row++)
            {
                for(int column = 0; column < table.GetColumns(); column++)
                {
                    if (cellSystem[row, column].GetExist())
                    {
                        exist[row, column] = cellSystem[row, column].Live(cellSystem[row, column].CellCount(cellSystem, table));
                    }
                    else
                    {
                        exist[row, column] = cellSystem[row, column].Born(cellSystem[row, column].CellCount(cellSystem, table));
                    }
                    
                }
            }

            for (int row = 0; row < table.GetRows(); row++)
            {
                for (int column = 0; column < table.GetColumns(); column++)
                {
                    cellSystem[row, column].SetExist(exist[row,column]);
                }
            }

            return cellSystem;
        }

    }
}
