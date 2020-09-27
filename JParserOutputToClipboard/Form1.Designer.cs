namespace JParserOutputToClipboard
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Button parseButton;
            this.textBox1 = new System.Windows.Forms.TextBox();
            parseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // parseButton
            // 
            parseButton.Dock = System.Windows.Forms.DockStyle.Top;
            parseButton.Location = new System.Drawing.Point(0, 263);
            parseButton.Name = "parseButton";
            parseButton.Size = new System.Drawing.Size(617, 23);
            parseButton.TabIndex = 1;
            parseButton.Text = "Parse Text";
            parseButton.UseVisualStyleBackColor = true;
            parseButton.Click += new System.EventHandler(this.parseButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.AcceptsTab = true;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(617, 263);
            this.textBox1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 367);
            this.Controls.Add(parseButton);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "JParser Output to Clipboard";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox textBox1;

        #endregion
    }
}