namespace Ex02
{
    partial class ReverseTicTacToe
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
            this.Player1 = new System.Windows.Forms.Label();
            this.Player2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Player1
            // 
            this.Player1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Player1.AutoSize = true;
            this.Player1.Location = new System.Drawing.Point(86, 408);
            this.Player1.Name = "Player1";
            this.Player1.Size = new System.Drawing.Size(44, 16);
            this.Player1.TabIndex = 0;
            this.Player1.Text = "label1";
            // 
            // Player2
            // 
            this.Player2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Player2.AutoSize = true;
            this.Player2.Location = new System.Drawing.Point(183, 408);
            this.Player2.Name = "Player2";
            this.Player2.Size = new System.Drawing.Size(44, 16);
            this.Player2.TabIndex = 1;
            this.Player2.Text = "label1";
            // 
            // ReverseTicTacToe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 451);
            this.Controls.Add(this.Player2);
            this.Controls.Add(this.Player1);
            this.Name = "ReverseTicTacToe";
            this.Text = "ReverseTicTacToe";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Player1;
        private System.Windows.Forms.Label Player2;
    }
}