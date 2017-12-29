namespace AppCliente
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
            this.boton_login = new System.Windows.Forms.Button();
            this.text_pass = new System.Windows.Forms.TextBox();
            this.text_nick = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // boton_login
            // 
            this.boton_login.Location = new System.Drawing.Point(161, 146);
            this.boton_login.Name = "boton_login";
            this.boton_login.Size = new System.Drawing.Size(115, 40);
            this.boton_login.TabIndex = 0;
            this.boton_login.Text = "Login";
            this.boton_login.UseVisualStyleBackColor = true;
            this.boton_login.Click += new System.EventHandler(this.boton_login_Click);
            // 
            // text_pass
            // 
            this.text_pass.Location = new System.Drawing.Point(96, 85);
            this.text_pass.Name = "text_pass";
            this.text_pass.Size = new System.Drawing.Size(240, 22);
            this.text_pass.TabIndex = 1;
            // 
            // text_nick
            // 
            this.text_nick.Location = new System.Drawing.Point(96, 57);
            this.text_nick.Name = "text_nick";
            this.text_nick.Size = new System.Drawing.Size(240, 22);
            this.text_nick.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Location = new System.Drawing.Point(44, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nick";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(44, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Pass";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 233);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.text_nick);
            this.Controls.Add(this.text_pass);
            this.Controls.Add(this.boton_login);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Naval Wars";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button boton_login;
        private System.Windows.Forms.TextBox text_pass;
        private System.Windows.Forms.TextBox text_nick;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

