namespace Bai03
{
    partial class frmPhanGiai
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtNhap = new System.Windows.Forms.TextBox();
            this.btnPhanGiai = new System.Windows.Forms.Button();
            this.gbKetQua = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIPv4 = new System.Windows.Forms.TextBox();
            this.txtSubnetMask = new System.Windows.Forms.TextBox();
            this.txtDefaultGateway = new System.Windows.Forms.TextBox();
            this.gbKetQua.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập tên miền";
            // 
            // txtNhap
            // 
            this.txtNhap.Location = new System.Drawing.Point(238, 29);
            this.txtNhap.Name = "txtNhap";
            this.txtNhap.Size = new System.Drawing.Size(481, 31);
            this.txtNhap.TabIndex = 1;
            // 
            // btnPhanGiai
            // 
            this.btnPhanGiai.Location = new System.Drawing.Point(252, 85);
            this.btnPhanGiai.Name = "btnPhanGiai";
            this.btnPhanGiai.Size = new System.Drawing.Size(274, 55);
            this.btnPhanGiai.TabIndex = 2;
            this.btnPhanGiai.Text = "Phân Giải";
            this.btnPhanGiai.UseVisualStyleBackColor = true;
            this.btnPhanGiai.Click += new System.EventHandler(this.btnPhanGiai_Click);
            // 
            // gbKetQua
            // 
            this.gbKetQua.Controls.Add(this.txtDefaultGateway);
            this.gbKetQua.Controls.Add(this.txtSubnetMask);
            this.gbKetQua.Controls.Add(this.txtIPv4);
            this.gbKetQua.Controls.Add(this.label4);
            this.gbKetQua.Controls.Add(this.label3);
            this.gbKetQua.Controls.Add(this.label2);
            this.gbKetQua.Location = new System.Drawing.Point(47, 175);
            this.gbKetQua.Name = "gbKetQua";
            this.gbKetQua.Size = new System.Drawing.Size(730, 226);
            this.gbKetQua.TabIndex = 3;
            this.gbKetQua.TabStop = false;
            this.gbKetQua.Text = "Kết quả";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Địa chỉ IPv4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Mặt nạ mạng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "Gateway mặc định";
            // 
            // txtIPv4
            // 
            this.txtIPv4.Location = new System.Drawing.Point(193, 30);
            this.txtIPv4.Name = "txtIPv4";
            this.txtIPv4.Size = new System.Drawing.Size(525, 31);
            this.txtIPv4.TabIndex = 3;
            // 
            // txtSubnetMask
            // 
            this.txtSubnetMask.Location = new System.Drawing.Point(193, 87);
            this.txtSubnetMask.Name = "txtSubnetMask";
            this.txtSubnetMask.Size = new System.Drawing.Size(525, 31);
            this.txtSubnetMask.TabIndex = 4;
            // 
            // txtDefaultGateway
            // 
            this.txtDefaultGateway.Location = new System.Drawing.Point(193, 146);
            this.txtDefaultGateway.Name = "txtDefaultGateway";
            this.txtDefaultGateway.Size = new System.Drawing.Size(525, 31);
            this.txtDefaultGateway.TabIndex = 5;
            // 
            // frmPhanGiai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gbKetQua);
            this.Controls.Add(this.btnPhanGiai);
            this.Controls.Add(this.txtNhap);
            this.Controls.Add(this.label1);
            this.Name = "frmPhanGiai";
            this.Text = "Phân giải tên miền";
            this.gbKetQua.ResumeLayout(false);
            this.gbKetQua.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNhap;
        private System.Windows.Forms.Button btnPhanGiai;
        private System.Windows.Forms.GroupBox gbKetQua;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIPv4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDefaultGateway;
        private System.Windows.Forms.TextBox txtSubnetMask;
    }
}
