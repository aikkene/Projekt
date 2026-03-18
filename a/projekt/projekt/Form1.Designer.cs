namespace projekt
{
    partial class GlownaForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            miasto = new TextBox();
            button1 = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // miasto
            // 
            miasto.Location = new Point(75, 56);
            miasto.Name = "miasto";
            miasto.Size = new Size(136, 27);
            miasto.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(75, 89);
            button1.Name = "button1";
            button1.Size = new Size(136, 29);
            button1.TabIndex = 1;
            button1.Text = "Sprawdź pogodę";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(97, 23);
            label1.Name = "label1";
            label1.Size = new Size(95, 20);
            label1.TabIndex = 2;
            label1.Text = "Podaj miasto";
            label1.Click += label1_Click;
            // 
            // GlownaForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 167);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(miasto);
            Name = "GlownaForm";
            Text = "Pogoda";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox miasto;
        private Button button1;
        private Label label1;
    }
}
