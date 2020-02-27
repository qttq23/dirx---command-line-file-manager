using System;
using System.IO;
using System.Collections.Generic;

namespace dirx
{
    public class FileDirInfo
    {

        public static string[] List(string foldername)
        {

            var list = new List<string>();
            string[] files = Directory.GetFiles(foldername);
            string[] folders = Directory.GetDirectories(foldername);
            foreach (var file in files)
            {
                list.Add(modifyFileName(file));

            }
            foreach (var folder in folders)
            {
                list.Add(modifyFolderName(folder));
            }

            return list.ToArray();

        }

        private static string modifyFileName(string filename)
        {
            if(Config.json["visualFileName"] == false)
            {
                return filename;
            }
            return filename.Substring(2);
        }
        private static string modifyFolderName(string foldername)
        {
            if (Config.json["visualFileName"] == false)
            {
                return foldername;
            }

            return foldername;
        }

    }

}
