using System;
using System.IO;

using System.Json;

using dirx.gui;

namespace dirx
{
    class Program
    {
        static void Main(string[] args)
        {

            // config file
            Config.Init();
            string startFolder = Config.json["startFolder"];
            string currentFolder = FileDirInfo.getFullPath(startFolder);

            // main flow
            ConsoleKeyInfo keyinfo = new ConsoleKeyInfo();
            bool isBegin = true;
            SimpleGui gui = new SimpleGui();

            do
            {
                // if begin or enter
                // query list files/folders
                // show list
                if (isBegin == true)
                {
                    string[] item = FileDirInfo.List(currentFolder);
                    gui.updateData(item);

                    isBegin = false;
                }
                else if (keyinfo.Key == ConsoleKey.Enter)
                {

                    string name = gui.getSelectedName();
                    if (FileDirInfo.isDir(name))
                    {
                        // set current folder
                        currentFolder = name;

                        // list all items and show
                        string[] item = FileDirInfo.List(currentFolder);
                        gui.updateData(item);
                    }
                }
                else if (keyinfo.Key == ConsoleKey.Backspace)
                {
                    // return to previous folder
                    currentFolder = FileDirInfo.getPreviousPath(currentFolder);

                    // list all items and show
                    string[] item = FileDirInfo.List(currentFolder);
                    gui.updateData(item);

                }


                // if key down/up
                // show cursor down/up
                else if (keyinfo.Key == ConsoleKey.DownArrow)
                {
                    gui.hoverNext();
                }
                else if (keyinfo.Key == ConsoleKey.UpArrow)
                {
                    gui.hoverPrevious();
                }
            
                // get key
                keyinfo = Console.ReadKey();
            }
            while (keyinfo.Key != ConsoleKey.Escape);


            // clean up every thing
            gui.Dispose();
            // save file for later start
        }

    }
}
