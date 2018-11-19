namespace QuanLyQuanAnNhat
{
    partial class Form_BaoCao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_BaoCao));
            this.lsvBaoCao = new System.Windows.Forms.ListView();
            this.MaHD = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbxNhanVien = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lsvBaoCao
            // 
            this.lsvBaoCao.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MaHD,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lsvBaoCao.GridLines = true;
            this.lsvBaoCao.Location = new System.Drawing.Point(65, 12);
            this.lsvBaoCao.Name = "lsvBaoCao";
            this.lsvBaoCao.Size = new System.Drawing.Size(617, 475);
            this.lsvBaoCao.TabIndex = 0;
            this.lsvBaoCao.UseCompatibleStateImageBehavior = false;
            this.lsvBaoCao.View = System.Windows.Forms.View.Details;
            // 
            // MaHD
            // 
            this.MaHD.Text = "Mã hóa đơn";
            this.MaHD.Width = 119;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Mã nhân viên";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Mã bàn";
            this.columnHeader3.Width = 87;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Tổng tiền";
            this.columnHeader4.Width = 140;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Thời gian";
            this.columnHeader5.Width = 169;
            // 
            // cbxNhanVien
            // 
            this.cbxNhanVien.FormattingEnabled = true;
            this.cbxNhanVien.Items.AddRange(new object[] {
            "Tất cả"});
            this.cbxNhanVien.Location = new System.Drawing.Point(732, 111);
            this.cbxNhanVien.Name = "cbxNhanVien";
            this.cbxNhanVien.Size = new System.Drawing.Size(150, 21);
            this.cbxNhanVien.TabIndex = 1;
            
            this.cbxNhanVien.SelectedValueChanged += new System.EventHandler(this.cbxNhanVien_SelectedValueChanged);
            // 
            // Form_BaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(921, 499);
            this.Controls.Add(this.cbxNhanVien);
            this.Controls.Add(this.lsvBaoCao);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_BaoCao";
            this.Text = "Form_BaoCao";
            this.Load += new System.EventHandler(this.Form_BaoCao_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lsvBaoCao;
        private System.Windows.Forms.ComboBox cbxNhanVien;
        private System.Windows.Forms.ColumnHeader MaHD;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}