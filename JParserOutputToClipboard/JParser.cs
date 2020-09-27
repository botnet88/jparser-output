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
      var parsedText = "";
      var runTimeExePath = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
      var runTimeDirectory = Path.GetDirectoryName(runTimeExePath)?.Substring(6) + @"\"; // substring removes "file://" from string
      var jParserDirectory = runTimeDirectory + "JParser";
      var jParserExePath = jParserDirectory + @"\jparser.exe";
      var jParserInputFile = $@"{jParserDirectory}\jparser_in_{Guid.NewGuid()}.txt";
      var jParserOutputFile = $@"{jParserDirectory}\jparser_out_{Guid.NewGuid()}.txt";

      // Delete old output file
      File.Delete(jParserOutputFile);

      // Write input file without BOM
      using (var writer = new StreamWriter(jParserInputFile, false, new UTF8Encoding(true)))
      {
        writer.Write(input);
      }

      // Create the jParser arguments
      string jParserArgs = $"{"\"" + jParserInputFile + "\""} {"\"" + jParserOutputFile + "\""}"; // call arguments with quotes around them

      // Run jParser
      Process proc = new Process();
      proc.StartInfo.FileName = jParserExePath;
      proc.StartInfo.Arguments = jParserArgs;
      proc.StartInfo.UseShellExecute = false;
      proc.StartInfo.CreateNoWindow = true;
      proc.StartInfo.WorkingDirectory = jParserDirectory;
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