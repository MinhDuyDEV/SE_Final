namespace SE_FinalProject
{
    partial class WarehouseStatistics
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
            this.buttonStockReport = new System.Windows.Forms.Button();
            this.buttonBestSelling = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewWarehouseStatistics = new System.Windows.Forms.DataGridView();
            this.textBoxMonth = new System.Windows.Forms.TextBox();
            this.labelMonth = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWarehouseStatistics)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStockReport
            // 
            this.buttonStockReport.Location = new System.Drawing.Point(46, 142);
            this.buttonStockReport.Margin = new System.Windows.Forms.Padding(2);
            this.buttonStockReport.Name = "buttonStockReport";
            this.buttonStockReport.Size = new System.Drawing.Size(152, 45);
            this.buttonStockReport.TabIndex = 1;
            this.buttonStockReport.Text = "Stock report";
            this.buttonStockReport.UseVisualStyleBackColor = true;
            this.buttonStockReport.Click += new System.EventHandler(this.buttonStockReport_Click);
            // 
            // buttonBestSelling
            // 
            this.buttonBestSelling.Location = new System.Drawing.Point(46, 242);
            this.buttonBestSelling.Margin = new System.Windows.Forms.Padding(2);
            this.buttonBestSelling.Name = "buttonBestSelling";
            this.buttonBestSelling.Size = new System.Drawing.Size(152, 45);
            this.buttonBestSelling.TabIndex = 2;
            this.buttonBestSelling.Text = "Best-selling";
            this.buttonBestSelling.UseVisualStyleBackColor = true;
            this.buttonBestSelling.Click += new System.EventHandler(this.buttonBestSelling_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewWarehouseStatistics);
            this.groupBox1.Location = new System.Drawing.Point(280, 46);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(605, 358);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Warehouse Statistics";
            // 
            // dataGridViewWarehouseStatistics
            // 
            this.dataGridViewWarehouseStatistics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWarehouseStatistics.Location = new System.Drawing.Point(0, 24);
            this.dataGridViewWarehouseStatistics.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewWarehouseStatistics.Name = "dataGridViewWarehouseStatistics";
            this.dataGridViewWarehouseStatistics.RowHeadersWidth = 51;
            this.dataGridViewWarehouseStatistics.RowTemplate.Height = 24;
            this.dataGridViewWarehouseStatistics.Size = new System.Drawing.Size(603, 333);
            this.dataGridViewWarehouseStatistics.TabIndex = 0;
            // 
            // textBoxMonth
            // 
            this.textBoxMonth.Location = new System.Drawing.Point(86, 73);
            this.textBoxMonth.Name = "textBoxMonth";
            this.textBoxMonth.Size = new System.Drawing.Size(100, 20);
            this.textBoxMonth.TabIndex = 4;
            // 
            // labelMonth
            // 
            this.labelMonth.AutoSize = true;
            this.labelMonth.Location = new System.Drawing.Point(43, 76);
            this.labelMonth.Name = "labelMonth";
            this.labelMonth.Size = new System.Drawing.Size(37, 13);
            this.labelMonth.TabIndex = 5;
            this.labelMonth.Text = "Month";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(945, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Warehouse =>";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(945, 88);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "DeliveryNote =>";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // WarehouseStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 412);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelMonth);
            this.Controls.Add(this.textBoxMonth);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonBestSelling);
            this.Controls.Add(this.buttonStockReport);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "WarehouseStatistics";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WarehouseStatistics";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWarehouseStatistics)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonStockReport;
        private System.Windows.Forms.Button buttonBestSelling;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridViewWarehouseStatistics;
        private System.Windows.Forms.TextBox textBoxMonth;
        private System.Windows.Forms.Label labelMonth;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}