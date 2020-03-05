using System;
using System.IO;
using System.Collections.Generic;

namespace dirx.gui
{

    public class SimpleGui
    {
        private List<string[]> data;

        private int selectedIndex;

        private int rootX, rootY;
        private int lastX, lastY;

        private int cursorIndex;

        public SimpleGui()
        {

            // read data from config file
            // header title

            // init data
            data = new List<string[]>();
            selectedIndex = -1;

            // get console
            rootX = Consolex.getX();
            rootY = Consolex.getY();

            lastX = rootX;
            lastY = rootY;

            // cursor
            cursorIndex = -1;

        }

        public bool isEmptyData()
        {

            if (data == null || data.Count == 0)
            {
                return true;
            }
            return false;

        }

        public void updateData(List<string[]> data)
        {
            // update date item when viewing a folder

            // check input data
            //...

            // assign data
            this.data = data;

            // set index
            this.selectedIndex = 0;

            // present data
            show();
        }

        // present data
        private void show()
        {
            // clear screen
            clearScreen();

            // show data
            int line = 0;
            foreach (var list in data)
            {
                Consolex.setXY(rootX + 5, rootY + line);

                foreach (var item in list)
                {
                    // show all in one line  
                    Consolex.write(dirx.FileDirInfo.getLeastPath(item));
                    Consolex.write("\t");
                }
                // next line
                Consolex.write("\n");
                line++;
            }

            // remember last x,y
            lastX = Consolex.getX();
            lastY = Consolex.getY();

            // show cursor
            showCursor();

            // go to last x,y
            Consolex.setXY(lastX, lastY + 1);
        }

        private void clearScreen()
        {
            // Console.Clear();

            // go to root x,y
            Consolex.setXY(rootX, rootY);

            // loop clear until reach last x,y
            for (int i = rootY; i < lastY; i++)
            {
                for (int j = 0; j < dirx.Config.json["maxClearCharacter"]; j++)
                {
                    Consolex.write(" ");
                }
            }
        }

        private void showCursor()
        {
            // get cursor from config file
            string cursor = dirx.Config.json["cursor"];

            // clear first
            if (isValidIndex(cursorIndex))
            {
                Consolex.setXY(rootX, rootY + cursorIndex);
                for (int i = 0; i < cursor.Length; i++)
                {
                    Consolex.write(" ");
                }

            }


            // show cursor
            Consolex.setXY(rootX, rootY + selectedIndex);
            Consolex.write(cursor);

            // save cursor index
            cursorIndex = selectedIndex;
        }

        // this function wrap data and call 'updateData(List<string[]> data)'
        public void updateData(string[] data)
        {
            // update date item when viewing a folder

            List<string[]> datax = new List<string[]>();
            foreach (var item in data)
            {
                datax.Add(new string[] { item });

            }

            updateData(datax);
        }

        public string getData(int row, int col)
        {

            // check if row col valid
            if (row >= 0 && row <= data.Count - 1
            && col >= 0 && col <= data[row].Length - 1)
            {

                return this.data[row][col];
            }

            return null;
        }

        public int hoverAt(int index)
        {
            // check data
            if (!isValidData())
            {
                return -1;
            }


            // check index
            if (isValidIndex(index))
            {
                selectedIndex = index;
            }

            // show cursor
            showCursor();
            return selectedIndex;
        }

        public int hoverNext()
        {
            // check data
            if (!isValidData())
            {
                return -1;
            }

            // check index
            if (isValidIndex(selectedIndex + 1))
            {
                selectedIndex += 1;
            }

            // show cursor
            showCursor();
            return selectedIndex;
        }
        public int hoverPrevious()
        {
            // check data
            if (!isValidData())
            {
                return -1;
            }
            // check index
            if (isValidIndex(selectedIndex - 1))
            {
                selectedIndex -= 1;
            }

            // show cursor
            showCursor();
            return selectedIndex;
        }

        private bool isValidIndex(int index)
        {
            if (index >= 0 && index <= data.Count - 1)
            {
                return true;
            }
            return false;
        }

        private bool isValidData()
        {
            if (data == null || data.Count == 0)
            {
                return false;
            }
            return true;
        }

        private int convertToAcceptedIndex(int index)
        {
            // check data
            //...


            return Math.Abs(index % data.Count);
        }

        public string getSelectedName()
        {
            if (isValidIndex(selectedIndex) && isValidData()
            && data[selectedIndex] != null && data[selectedIndex].Length > 0)
            {
                return this.data[selectedIndex][0];

            }

            return null;
        }

    }
}