namespace WindowsFormsApplication2
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.rtb_line = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rtb_yqx = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rtb_hhqx = new System.Windows.Forms.RichTextBox();
            this.rtb_out = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.but_line = new System.Windows.Forms.Button();
            this.but_yqx = new System.Windows.Forms.Button();
            this.but_hhqx = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtb_line
            // 
            this.rtb_line.Location = new System.Drawing.Point(59, 73);
            this.rtb_line.Name = "rtb_line";
            this.rtb_line.Size = new System.Drawing.Size(268, 198);
            this.rtb_line.TabIndex = 0;
            this.rtb_line.Text = "";
            this.rtb_line.UseWaitCursor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(56, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "直线";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(344, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "圆曲线";
            // 
            // rtb_yqx
            // 
            this.rtb_yqx.Location = new System.Drawing.Point(348, 73);
            this.rtb_yqx.Name = "rtb_yqx";
            this.rtb_yqx.Size = new System.Drawing.Size(296, 198);
            this.rtb_yqx.TabIndex = 2;
            this.rtb_yqx.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(667, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "缓和曲线";
            // 
            // rtb_hhqx
            // 
            this.rtb_hhqx.Location = new System.Drawing.Point(671, 73);
            this.rtb_hhqx.Name = "rtb_hhqx";
            this.rtb_hhqx.Size = new System.Drawing.Size(272, 198);
            this.rtb_hhqx.TabIndex = 4;
            this.rtb_hhqx.Text = "";
            // 
            // rtb_out
            // 
            this.rtb_out.Location = new System.Drawing.Point(59, 371);
            this.rtb_out.Name = "rtb_out";
            this.rtb_out.Size = new System.Drawing.Size(884, 247);
            this.rtb_out.TabIndex = 6;
            this.rtb_out.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(56, 348);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "输出坐标日志：";
            // 
            // but_line
            // 
            this.but_line.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_line.Location = new System.Drawing.Point(90, 277);
            this.but_line.Name = "but_line";
            this.but_line.Size = new System.Drawing.Size(137, 39);
            this.but_line.TabIndex = 8;
            this.but_line.Text = "计算直线";
            this.but_line.UseVisualStyleBackColor = true;
            this.but_line.Click += new System.EventHandler(this.but_line_Click);
            // 
            // but_yqx
            // 
            this.but_yqx.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_yqx.Location = new System.Drawing.Point(420, 277);
            this.but_yqx.Name = "but_yqx";
            this.but_yqx.Size = new System.Drawing.Size(137, 39);
            this.but_yqx.TabIndex = 9;
            this.but_yqx.Text = "计算圆曲线";
            this.but_yqx.UseVisualStyleBackColor = true;
            this.but_yqx.Click += new System.EventHandler(this.but_yqx_Click);
            // 
            // but_hhqx
            // 
            this.but_hhqx.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_hhqx.Location = new System.Drawing.Point(740, 277);
            this.but_hhqx.Name = "but_hhqx";
            this.but_hhqx.Size = new System.Drawing.Size(151, 39);
            this.but_hhqx.TabIndex = 10;
            this.but_hhqx.Text = "计算缓和曲线";
            this.but_hhqx.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 653);
            this.Controls.Add(this.but_hhqx);
            this.Controls.Add(this.but_yqx);
            this.Controls.Add(this.but_line);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rtb_out);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rtb_hhqx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rtb_yqx);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtb_line);
            this.Name = "Form1";
            this.Tag = "";
            this.Text = "曲线测设";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtb_line;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtb_yqx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtb_hhqx;
        private System.Windows.Forms.RichTextBox rtb_out;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button but_line;
        private System.Windows.Forms.Button but_yqx;
        private System.Windows.Forms.Button but_hhqx;
    }
}

