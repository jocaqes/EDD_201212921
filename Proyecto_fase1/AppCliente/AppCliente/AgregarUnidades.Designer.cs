namespace AppCliente
{
    partial class AgregarUnidades
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
            this.label1 = new System.Windows.Forms.Label();
            this.label_limite = new System.Windows.Forms.Label();
            this.combo_unidades = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.text_columna = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.text_fila = new System.Windows.Forms.TextBox();
            this.boton_insertar = new System.Windows.Forms.Button();
            this.picture_esenario = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picture_esenario)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(990, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Limite de Unidades";
            // 
            // label_limite
            // 
            this.label_limite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_limite.AutoSize = true;
            this.label_limite.Location = new System.Drawing.Point(1091, 31);
            this.label_limite.Name = "label_limite";
            this.label_limite.Size = new System.Drawing.Size(46, 17);
            this.label_limite.TabIndex = 2;
            this.label_limite.Text = "label2";
            // 
            // combo_unidades
            // 
            this.combo_unidades.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_unidades.AutoCompleteCustomSource.AddRange(new string[] {
            "Submarino",
            "Fragata",
            "Crucero",
            "Bombardero",
            "Helicoptero de Combate",
            "Caza",
            "NeoSatelite"});
            this.combo_unidades.FormattingEnabled = true;
            this.combo_unidades.Items.AddRange(new object[] {
            "Submarino",
            "Crucero",
            "Fragata",
            "Helicoptero de Combate",
            "Caza",
            "Bombardero",
            "NeoSatelite"});
            this.combo_unidades.Location = new System.Drawing.Point(993, 81);
            this.combo_unidades.Name = "combo_unidades";
            this.combo_unidades.Size = new System.Drawing.Size(144, 24);
            this.combo_unidades.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1018, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tipo de Unidad";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1003, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Coordenada en X";
            // 
            // text_columna
            // 
            this.text_columna.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.text_columna.Location = new System.Drawing.Point(1006, 169);
            this.text_columna.Name = "text_columna";
            this.text_columna.Size = new System.Drawing.Size(131, 22);
            this.text_columna.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1003, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Coordenada en Y";
            // 
            // text_fila
            // 
            this.text_fila.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.text_fila.Location = new System.Drawing.Point(1006, 246);
            this.text_fila.Name = "text_fila";
            this.text_fila.Size = new System.Drawing.Size(130, 22);
            this.text_fila.TabIndex = 8;
            // 
            // boton_insertar
            // 
            this.boton_insertar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boton_insertar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boton_insertar.Location = new System.Drawing.Point(1006, 301);
            this.boton_insertar.Name = "boton_insertar";
            this.boton_insertar.Size = new System.Drawing.Size(131, 31);
            this.boton_insertar.TabIndex = 9;
            this.boton_insertar.Text = "Agregar";
            this.boton_insertar.UseVisualStyleBackColor = true;
            this.boton_insertar.Click += new System.EventHandler(this.boton_insertar_Click);
            // 
            // picture_esenario
            // 
            this.picture_esenario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picture_esenario.Location = new System.Drawing.Point(13, 13);
            this.picture_esenario.Name = "picture_esenario";
            this.picture_esenario.Size = new System.Drawing.Size(857, 505);
            this.picture_esenario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picture_esenario.TabIndex = 0;
            this.picture_esenario.TabStop = false;
            // 
            // AgregarUnidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 530);
            this.Controls.Add(this.boton_insertar);
            this.Controls.Add(this.text_fila);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.text_columna);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.combo_unidades);
            this.Controls.Add(this.label_limite);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picture_esenario);
            this.Name = "AgregarUnidades";
            this.Text = "AgregarUnidades";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AgregarUnidades_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.picture_esenario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picture_esenario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_limite;
        private System.Windows.Forms.ComboBox combo_unidades;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox text_columna;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox text_fila;
        private System.Windows.Forms.Button boton_insertar;
    }
}