﻿namespace TimeSheet
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.AdminBtn = new System.Windows.Forms.Button();
            this.userBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.usersCB = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // AdminBtn
            // 
            this.AdminBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AdminBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdminBtn.ForeColor = System.Drawing.Color.White;
            this.AdminBtn.Location = new System.Drawing.Point(388, 208);
            this.AdminBtn.Name = "AdminBtn";
            this.AdminBtn.Size = new System.Drawing.Size(113, 34);
            this.AdminBtn.TabIndex = 0;
            this.AdminBtn.Text = "Admin";
            this.AdminBtn.UseVisualStyleBackColor = true;
            // 
            // userBtn
            // 
            this.userBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.userBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userBtn.ForeColor = System.Drawing.Color.White;
            this.userBtn.Location = new System.Drawing.Point(242, 208);
            this.userBtn.Name = "userBtn";
            this.userBtn.Size = new System.Drawing.Size(112, 34);
            this.userBtn.TabIndex = 1;
            this.userBtn.Text = "User";
            this.userBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(316, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select User";
            // 
            // usersCB
            // 
            this.usersCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usersCB.FormattingEnabled = true;
            this.usersCB.Location = new System.Drawing.Point(283, 153);
            this.usersCB.Name = "usersCB";
            this.usersCB.Size = new System.Drawing.Size(172, 24);
            this.usersCB.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(111)))), ((int)(((byte)(155)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.usersCB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.userBtn);
            this.Controls.Add(this.AdminBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AdminBtn;
        private System.Windows.Forms.Button userBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox usersCB;
    }
}

