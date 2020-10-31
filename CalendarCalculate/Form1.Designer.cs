namespace CalendarCalculate
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.DescriptionOfUse = new System.Windows.Forms.Label();
            this.year = new System.Windows.Forms.TextBox();
            this.yearLabel = new System.Windows.Forms.Label();
            this.calculatedDateInterval = new System.Windows.Forms.TextBox();
            this.dateLabel = new System.Windows.Forms.Label();
            this.weekth = new System.Windows.Forms.TextBox();
            this.weekthLabel = new System.Windows.Forms.Label();
            this.calBeginDateLabel = new System.Windows.Forms.Label();
            this.calBeginDate = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.calBeginDate);
            this.panel1.Controls.Add(this.calBeginDateLabel);
            this.panel1.Controls.Add(this.DescriptionOfUse);
            this.panel1.Controls.Add(this.year);
            this.panel1.Controls.Add(this.yearLabel);
            this.panel1.Controls.Add(this.calculatedDateInterval);
            this.panel1.Controls.Add(this.dateLabel);
            this.panel1.Controls.Add(this.weekth);
            this.panel1.Controls.Add(this.weekthLabel);
            this.panel1.Location = new System.Drawing.Point(5, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(755, 299);
            this.panel1.TabIndex = 100001;
            // 
            // DescriptionOfUse
            // 
            this.DescriptionOfUse.AutoSize = true;
            this.DescriptionOfUse.BackColor = System.Drawing.Color.LightCyan;
            this.DescriptionOfUse.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.DescriptionOfUse.Location = new System.Drawing.Point(13, 13);
            this.DescriptionOfUse.Name = "DescriptionOfUse";
            this.DescriptionOfUse.Size = new System.Drawing.Size(357, 25);
            this.DescriptionOfUse.TabIndex = 100007;
            this.DescriptionOfUse.Text = "請輸入年份和第幾週,可計算其日期區間\r\n";
            // 
            // year
            // 
            this.year.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.year.Location = new System.Drawing.Point(124, 54);
            this.year.Name = "year";
            this.year.Size = new System.Drawing.Size(292, 34);
            this.year.TabIndex = 100001;
            this.year.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.year_KeyPress);
            // 
            // yearLabel
            // 
            this.yearLabel.AutoSize = true;
            this.yearLabel.BackColor = System.Drawing.Color.LightYellow;
            this.yearLabel.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.yearLabel.ForeColor = System.Drawing.Color.Blue;
            this.yearLabel.Location = new System.Drawing.Point(13, 63);
            this.yearLabel.Name = "yearLabel";
            this.yearLabel.Size = new System.Drawing.Size(52, 25);
            this.yearLabel.TabIndex = 100006;
            this.yearLabel.Text = "年份";
            // 
            // calculatedDateInterval
            // 
            this.calculatedDateInterval.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.calculatedDateInterval.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.calculatedDateInterval.Location = new System.Drawing.Point(124, 175);
            this.calculatedDateInterval.Name = "calculatedDateInterval";
            this.calculatedDateInterval.ReadOnly = true;
            this.calculatedDateInterval.Size = new System.Drawing.Size(611, 34);
            this.calculatedDateInterval.TabIndex = 100003;
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.BackColor = System.Drawing.Color.LightYellow;
            this.dateLabel.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dateLabel.ForeColor = System.Drawing.Color.Green;
            this.dateLabel.Location = new System.Drawing.Point(13, 184);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(92, 25);
            this.dateLabel.TabIndex = 100004;
            this.dateLabel.Text = "日期區間";
            // 
            // weekth
            // 
            this.weekth.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.weekth.Location = new System.Drawing.Point(124, 113);
            this.weekth.Name = "weekth";
            this.weekth.Size = new System.Drawing.Size(292, 34);
            this.weekth.TabIndex = 100002;
            this.weekth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.weekth_KeyPress);
            // 
            // weekthLabel
            // 
            this.weekthLabel.AutoSize = true;
            this.weekthLabel.BackColor = System.Drawing.Color.LightYellow;
            this.weekthLabel.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.weekthLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.weekthLabel.Location = new System.Drawing.Point(13, 122);
            this.weekthLabel.Name = "weekthLabel";
            this.weekthLabel.Size = new System.Drawing.Size(72, 25);
            this.weekthLabel.TabIndex = 100005;
            this.weekthLabel.Text = "第幾週";
            // 
            // calBeginDateLabel
            // 
            this.calBeginDateLabel.AutoSize = true;
            this.calBeginDateLabel.BackColor = System.Drawing.Color.LightYellow;
            this.calBeginDateLabel.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.calBeginDateLabel.ForeColor = System.Drawing.Color.Green;
            this.calBeginDateLabel.Location = new System.Drawing.Point(13, 246);
            this.calBeginDateLabel.Name = "calBeginDateLabel";
            this.calBeginDateLabel.Size = new System.Drawing.Size(92, 25);
            this.calBeginDateLabel.TabIndex = 100008;
            this.calBeginDateLabel.Text = "開頭日期";
            // 
            // calBeginDate
            // 
            this.calBeginDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.calBeginDate.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.calBeginDate.Location = new System.Drawing.Point(124, 237);
            this.calBeginDate.Name = "calBeginDate";
            this.calBeginDate.ReadOnly = true;
            this.calBeginDate.Size = new System.Drawing.Size(292, 34);
            this.calBeginDate.TabIndex = 100009;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(766, 302);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "週別轉日期區間-計算";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label DescriptionOfUse;
        private System.Windows.Forms.TextBox year;
        private System.Windows.Forms.Label yearLabel;
        private System.Windows.Forms.TextBox calculatedDateInterval;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.TextBox weekth;
        private System.Windows.Forms.Label weekthLabel;
        private System.Windows.Forms.Label calBeginDateLabel;
        private System.Windows.Forms.TextBox calBeginDate;



    }
}

