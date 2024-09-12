namespace FIT.WinForms.IB222222
{
    partial class frmNovoUvjerenje
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            pbUplatnica = new PictureBox();
            txtSvrha = new TextBox();
            cmbVrsta = new ComboBox();
            btnSacuvaj = new Button();
            label2 = new Label();
            label3 = new Label();
            err = new ErrorProvider(components);
            openFileDialog1 = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)pbUplatnica).BeginInit();
            ((System.ComponentModel.ISupportInitialize)err).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(41, 20);
            label1.TabIndex = 0;
            label1.Text = "Vrsta";
            // 
            // pbUplatnica
            // 
            pbUplatnica.Location = new Point(290, 32);
            pbUplatnica.Name = "pbUplatnica";
            pbUplatnica.Size = new Size(297, 279);
            pbUplatnica.TabIndex = 1;
            pbUplatnica.TabStop = false;
            pbUplatnica.DoubleClick += pbUplatnica_DoubleClick;
            // 
            // txtSvrha
            // 
            txtSvrha.Location = new Point(16, 94);
            txtSvrha.Multiline = true;
            txtSvrha.Name = "txtSvrha";
            txtSvrha.Size = new Size(268, 270);
            txtSvrha.TabIndex = 2;
            // 
            // cmbVrsta
            // 
            cmbVrsta.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVrsta.FormattingEnabled = true;
            cmbVrsta.Items.AddRange(new object[] { "Dule saiv", "Kerim cava", "vejsil" });
            cmbVrsta.Location = new Point(16, 32);
            cmbVrsta.Name = "cmbVrsta";
            cmbVrsta.Size = new Size(268, 28);
            cmbVrsta.TabIndex = 3;
            // 
            // btnSacuvaj
            // 
            btnSacuvaj.Location = new Point(493, 335);
            btnSacuvaj.Name = "btnSacuvaj";
            btnSacuvaj.Size = new Size(94, 29);
            btnSacuvaj.TabIndex = 4;
            btnSacuvaj.Text = "Sacuvaj";
            btnSacuvaj.UseVisualStyleBackColor = true;
            btnSacuvaj.Click += btnSacuvaj_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 71);
            label2.Name = "label2";
            label2.Size = new Size(45, 20);
            label2.TabIndex = 0;
            label2.Text = "Svrha";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(546, 9);
            label3.Name = "label3";
            label3.Size = new Size(41, 20);
            label3.TabIndex = 0;
            label3.Text = "Vrsta";
            // 
            // err
            // 
            err.ContainerControl = this;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmNovoUvjerenje
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSacuvaj);
            Controls.Add(cmbVrsta);
            Controls.Add(txtSvrha);
            Controls.Add(pbUplatnica);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label1);
            Name = "frmNovoUvjerenje";
            Text = "frmNovoUvjerenje";
            ((System.ComponentModel.ISupportInitialize)pbUplatnica).EndInit();
            ((System.ComponentModel.ISupportInitialize)err).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private PictureBox pbUplatnica;
        private TextBox txtSvrha;
        private ComboBox cmbVrsta;
        private Button btnSacuvaj;
        private Label label2;
        private Label label3;
        private ErrorProvider err;
        private OpenFileDialog openFileDialog1;
    }
}