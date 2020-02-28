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
                // list.Add(modifyFileName(file));
                list.Add(getFullPath(file));

            }
            foreach (var folder in folders)
            {
                // list.Add(modifyFolderName(folder));
                list.Add(getFullPath(folder));
            }

            return list.ToArray();

        }

        public static string getFullPath(string filename)
        {

            return Path.GetFullPath(filename);
        }

        // this is hub function
        public static string getLeastPath(string filename){
            
            if(isDir(filename)){
                return modifyFolderName(filename);
            }
            
            return modifyFileName(filename);
        }

        public static string getPreviousPath(string filename){

            if(isDir(filename)){
                int index = filename.LastIndexOf(Path.DirectorySeparatorChar);
                return filename.Substring(0, index);
            }
            return filename;
        }
        public static string modifyFileName(string filename)
        {
            if (Config.json["visualFileName"] == true)
            {
                return Path.GetFileName(filename);
            }
            return filename;
        }

        public static string modifyFolderName(string foldername)
        {
            if (Config.json["visualFileName"] == true)
            {
                int index = foldername.LastIndexOf(Path.DirectorySeparatorChar);
                return foldername.Substring(index);

            }

            return foldername;
        }

        public static bool isDir(string filename)
        {
            // get the file attributes for file or directory
            FileAttributes attr = File.GetAttributes(filename);

            if (attr.HasFlag(FileAttributes.Directory))
                return true;
            return false;
        }

    }

}
