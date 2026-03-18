namespace projekt
{
    partial class GlownaForm
    {
        private System.ComponentModel.IContainer components = null;
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

        private void InitializeComponent()
        {
            button1 = new Button();
            miasto = new TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(55, 107);
            button1.Name = "button1";
            button1.Size = new Size(125, 32);
            button1.TabIndex = 0;
            button1.Text = "Sprawdź";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // miasto
            // 
            miasto.Location = new Point(55, 74);
            miasto.Name = "miasto";
            miasto.Size = new Size(125, 27);
            miasto.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(42, 31);
            label2.Name = "label2";
            label2.Size = new Size(168, 40);
            label2.TabIndex = 5;
            label2.Text = "W jakim mieście chcesz \r\nsprawdzic pogode?\r\n";
            // 
            // GlownaForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(258, 211);
            Controls.Add(label2);
            Controls.Add(miasto);
            Controls.Add(button1);
            Name = "GlownaForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox miasto;
        private Label label2;
    }
}
