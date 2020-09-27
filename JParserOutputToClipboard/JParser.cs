using System;
using System.IO;
using System.Text;
using System.Diagnostics;

namespace JParserOutputToClipboard
{
    public class JParser
  {
    /// <summary>
    /// Get RAW JParser output.
    /// </summary>
    public static string getRaw(string input)
    {
      string parsedText = "";
      string jParserLoc = String.Format("{0}JParser{1}jparser.exe", UtilsCommon.getAppDir(true), Path.DirectorySeparatorChar);
      string jParserInputFile = String.Format("{0}JParser{1}jparser_in_{2}.txt", UtilsCommon.getAppDir(true), Path.DirectorySeparatorChar, Guid.NewGuid());
      string jParserOutputFile = String.Format("{0}JParser{1}jparser_out_{2}.txt", UtilsCommon.getAppDir(true), Path.DirectorySeparatorChar, Guid.NewGuid());

      // Delete old output file
      File.Delete(jParserOutputFile);

      // Write input file without BOM
      using (var writer = new StreamWriter(jParserInputFile, false, new UTF8Encoding(true)))
      {
        writer.Write(input);
      }

      // Create the jParser arguments
      string jParserArgs = String.Format(@"{0} {1}",
        jParserInputFile, jParserOutputFile);

      // Run jParser
      Process proc = new Process();
      proc.StartInfo.FileName = jParserLoc;
      proc.StartInfo.Arguments = jParserArgs;
      proc.StartInfo.UseShellExecute = false;
      proc.StartInfo.CreateNoWindow = true;
      proc.StartInfo.WorkingDirectory = UtilsCommon.getAppDir(true) + "JParser";
      proc.Start();
      proc.WaitForExit(); // Blocking

      // Read the output of jParser
      if (File.Exists(jParserOutputFile))
      {
        using (var reader = new StreamReader(jParserOutputFile))
        {
          parsedText = reader.ReadToEnd();
        }
      }

      File.Delete(jParserInputFile);
      File.Delete(jParserOutputFile);

      return parsedText;
    }
  }
}