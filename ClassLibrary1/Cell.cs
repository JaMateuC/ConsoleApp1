using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class Cell
    {

        private int positionX;
        private int positionY;
        private Boolean exist;
        private Boolean[] live;
        private Boolean[] born;

        public Cell()
        {
            this.positionX = 0;
            this.positionY = 0;
            this.exist = false;
            this.live = new Boolean[9] { false, false, false, false, false, true, false, true, false };
            this.born = new Boolean[9] { true, false, true, false, false, false, true, true, false };
        }

        public Cell(int x, int y, Boolean exist)
        {
            this.positionX = x;
            this.positionY = y;
            this.exist =exist;
            this.live = new Boolean[9] { false, false, false, true, true, false, false, true, false };
            this.born = new Boolean[9] { false, true, false, false, false, false, false, false, false };
        }

        public Boolean[] GetLive()
        {
            return this.live;
        }

        public int GetPositionX()
        {
            return this.positionX;
        }

        public int GetPositionY()
        {
            return this.positionY;
        }

        public Boolean GetExist()
        {
            return this.exist;
        }

        public void SetExist(Boolean exist)
        {
            this.exist = exist;
        }

        public Boolean Born(int totalCell)
        {
            for (int i = 0; i < this.live.Length; i++)
            {
                if (this.born[i] && i == totalCell)
                {
                    return true;
                }
            }
            return false;
        }

        public Boolean Live(int totalCell)
        {
            for (int i = 0; i < this.live.Length; i++)
            {
                if (this.live[i] && i == totalCell)
                {
                    return true;
                }
            }
            return false;
        }

        public int CellCount(Cell[,] cellSystem, Table table)
        {
            int totalCell = 0;
            for(int x = -1; x <= 1; x++)
            {
                for(int y = -1; y <= 1; y++)
                {
                    if (!(x == 0 && y == 0))
                    {
                        if ((this.positionX + x) < 0 && (this.positionY + y) < 0)
                        {
                            if (cellSystem[table.GetRows() - 1, table.GetColumns() - 1].GetExist())
                            {
                                totalCell++;
                            }
                        }
                        else if ((this.positionX + x) >= table.GetRows() && (this.positionY + y) >= table.GetColumns())
                        {

                            if (cellSystem[0, 0].GetExist())
                            {
                                totalCell++;
                            }

                        }
                        else if ((this.positionX + x) < 0 && (this.positionY + y) >= table.GetColumns())
                        {
                            if (cellSystem[table.GetRows() - 1, 0].GetExist())
                            {
                                totalCell++;
                            }
                        }
                        else if ((this.positionY + y) < 0 && (this.positionX + x) >= table.GetRows())
                        {
                            if (cellSystem[0, table.GetColumns() - 1].GetExist())
                            {
                                totalCell++;
                            }
                        }
                        else if ((this.positionY + y) < 0)
                        {
                            if (cellSystem[this.positionX + x, table.GetColumns() - 1].GetExist())
                            {
                                totalCell++;
                            }
                        }
                        else if((this.positionX + x) < 0)
                        {
                            if (cellSystem[table.GetRows() - 1, this.positionY + y].GetExist())
                            {
                                totalCell++;
                            }
                        }
                        else if((this.positionX + x) >= table.GetRows())
                        {
                            if (cellSystem[0, this.positionY + y].GetExist())
                            {
                                totalCell++;
                            }
                        }
                        else if((this.positionY + y) >= table.GetColumns())
                        {
                            if (cellSystem[this.positionX + x, 0].GetExist())
                            {
                                totalCell++;
                            }
                        }
                        else
                        {
                            if (cellSystem[this.positionX + x, this.positionY + y].GetExist())
                            {
                                totalCell++;
                            }
                        }
                    }
                }
            }
            return totalCell;
        }

    }
}
