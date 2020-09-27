using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace JParserOutputToClipboard
{
    public class UtilsCommon
    {
        /// <summary>
        /// Get the directory that the executable resides in.
        /// </summary>
        public static string getAppDir(bool addSlash)
        {
            string appDir = Application.ExecutablePath.Substring(
                0, Application.ExecutablePath.LastIndexOf(Path.DirectorySeparatorChar));

            if(addSlash)
            {
                appDir += Path.DirectorySeparatorChar;
            }

            return appDir;
        }


        /// <summary>
        /// Get the line ending type: CRLF, LF, or CR
        /// </summary>
        public static string getLineEnding(string text)
        {
            string lineEnding = "";

            if (text.Contains("\r\n"))
            {
                lineEnding = "\r\n";
            }
            else if (text.Contains("\n"))
            {
                lineEnding = "\n";
            }
            else
            {
                lineEnding = "\r";
            }

            return lineEnding;
        }


        /// <summary>
        ///  Get a list of non-hidden files in a directory that match the given file pattern.
        /// </summary>
        public static string[] getNonHiddenFilesInDir(string dir, string searchPatttern)
        {
            if (Directory.Exists(dir))
            {
                string[] subsFiles = Directory.GetFiles(dir, searchPatttern, SearchOption.TopDirectoryOnly);
                List<string> unHiddenFiles = new List<string>();

                foreach (string file in subsFiles)
                {
                    if ((File.GetAttributes(file) & FileAttributes.Hidden) != FileAttributes.Hidden)
                    {
                        unHiddenFiles.Add(file);
                    }
                }

                return unHiddenFiles.ToArray();
            }
            else
            {
                return new string[0];
            }
        }


        /// <summary>
        ///  Get a list of non-hidden files in a directory.
        /// </summary>
        public static string[] getNonHiddenFilesInDir(string dir)
        {
            return getNonHiddenFilesInDir(dir, "*");
        }


    }
}