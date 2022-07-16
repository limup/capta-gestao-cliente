namespace Capta_Tecnologia
{
    partial class frmCapta
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
            this.btnCliente = new System.Windows.Forms.Button();
            this.lstvCLientes = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(371, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Portal Cliente Capta";
            // 
            // btnCliente
            // 
            this.btnCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCliente.Location = new System.Drawing.Point(107, 88);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(171, 57);
            this.btnCliente.TabIndex = 1;
            this.btnCliente.Text = "Cadastrar Cliente";
            this.btnCliente.UseVisualStyleBackColor = true;
            this.btnCliente.Click += new System.EventHandler(this.btnCliente_Click);
            // 
            // lstvCLientes
            // 
            this.lstvCLientes.AllowColumnReorder = true;
            this.lstvCLientes.FullRowSelect = true;
            this.lstvCLientes.GridLines = true;
            this.lstvCLientes.Location = new System.Drawing.Point(12, 169);
            this.lstvCLientes.MultiSelect = false;
            this.lstvCLientes.Name = "lstvCLientes";
            this.lstvCLientes.Size = new System.Drawing.Size(383, 292);
            this.lstvCLientes.TabIndex = 2;
            this.lstvCLientes.UseCompatibleStateImageBehavior = false;
            this.lstvCLientes.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lstvCLientes_ItemSelectionChanged);
            this.lstvCLientes.SelectedIndexChanged += new System.EventHandler(this.lstvCLientes_SelectedIndexChanged);
            // 
            // frmCapta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 470);
            this.Controls.Add(this.lstvCLientes);
            this.Controls.Add(this.btnCliente);
            this.Controls.Add(this.label1);
            this.Name = "frmCapta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Capta Tecnologia";
            this.Load += new System.EventHandler(this.frmCapta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCliente;
        public System.Windows.Forms.ListView lstvCLientes;
    }
}