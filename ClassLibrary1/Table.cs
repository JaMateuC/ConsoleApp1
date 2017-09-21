using System;

namespace ClassLibrary1
{
    public class Table
    {

        private int columns;
        private int rows;
        private String[] draw;

        public Table()
        {
            this.columns = 50;
            this.rows = 40;
            this.draw = new String[this.rows];
        }

        public int GetColumns()
        {
            return this.columns;
        }

        public int GetRows()
        {
            return this.rows;
        }

    }
}
