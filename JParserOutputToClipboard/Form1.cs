using System;
using System.Windows.Forms;

namespace JParserOutputToClipboard
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void parseButton_Click(object sender, EventArgs e)
        {
            var output = JParser.getRaw(textBox1.Text); // string with garbage data I don't want
            // convert string to list which will soon be cleaned
            var outputListBeforeEdit = output.Split(
                new[] { Environment.NewLine },
                StringSplitOptions.None
            );

            var outputClean = "";
            // for each item in list, remove junk I don't want, and append it to final clean output
            foreach (var item in outputListBeforeEdit)
            {
                if (item.StartsWith("\t")) continue; // if current line is blank don't do anything with it
                var firstWordInList = item.Split('\t')[0];
                if ( firstWordInList == "LINEBREAK" )
                {
                    outputClean += System.Environment.NewLine;
                }
                else
                {
                    outputClean += firstWordInList + ' ';
                }
            }

            textBox1.Text = outputClean;
            Clipboard.SetText(outputClean);
        }
    }
}