namespace FilmScreenShotJoint
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBoxOriginalImage = new System.Windows.Forms.GroupBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonPreview = new System.Windows.Forms.Button();
            this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.groupBoxPreview = new System.Windows.Forms.GroupBox();
            this.panelPreview = new System.Windows.Forms.Panel();
            this.buttonSave = new System.Windows.Forms.Button();
            this.radioButtonZoom = new System.Windows.Forms.RadioButton();
            this.radioButtonAutoSize = new System.Windows.Forms.RadioButton();
            this.checkBoxUniOp = new System.Windows.Forms.CheckBox();
            this.groupBoxOriginalImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            this.groupBoxPreview.SuspendLayout();
            this.panelPreview.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 17);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(556, 593);
            this.flowLayoutPanel1.TabIndex = 1;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // groupBoxOriginalImage
            // 
            this.groupBoxOriginalImage.Controls.Add(this.flowLayoutPanel1);
            this.groupBoxOriginalImage.Location = new System.Drawing.Point(12, 37);
            this.groupBoxOriginalImage.Name = "groupBoxOriginalImage";
            this.groupBoxOriginalImage.Size = new System.Drawing.Size(562, 613);
            this.groupBoxOriginalImage.TabIndex = 2;
            this.groupBoxOriginalImage.TabStop = false;
            this.groupBoxOriginalImage.Text = "原图列表";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "JPG文件(*.jpg)|*.jpg|*.jpeg|*.*";
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Title = "请选择截图";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "JPG文件(*.jpg)|*.jpg|*.jpeg|*.*";
            // 
            // buttonOpen
            // 
            this.buttonOpen.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonOpen.Location = new System.Drawing.Point(12, 8);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(92, 23);
            this.buttonOpen.TabIndex = 3;
            this.buttonOpen.Text = "选择文件...";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // buttonPreview
            // 
            this.buttonPreview.Location = new System.Drawing.Point(701, 621);
            this.buttonPreview.Name = "buttonPreview";
            this.buttonPreview.Size = new System.Drawing.Size(84, 26);
            this.buttonPreview.TabIndex = 4;
            this.buttonPreview.Text = "预览";
            this.buttonPreview.UseVisualStyleBackColor = true;
            this.buttonPreview.Click += new System.EventHandler(this.buttonPreview_Click);
            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.Size = new System.Drawing.Size(580, 552);
            this.pictureBoxPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPreview.TabIndex = 5;
            this.pictureBoxPreview.TabStop = false;
            // 
            // groupBoxPreview
            // 
            this.groupBoxPreview.Controls.Add(this.panelPreview);
            this.groupBoxPreview.Location = new System.Drawing.Point(580, 37);
            this.groupBoxPreview.Name = "groupBoxPreview";
            this.groupBoxPreview.Size = new System.Drawing.Size(592, 578);
            this.groupBoxPreview.TabIndex = 6;
            this.groupBoxPreview.TabStop = false;
            this.groupBoxPreview.Text = "结果预览";
            // 
            // panelPreview
            // 
            this.panelPreview.AutoScroll = true;
            this.panelPreview.Controls.Add(this.pictureBoxPreview);
            this.panelPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPreview.Location = new System.Drawing.Point(3, 17);
            this.panelPreview.Name = "panelPreview";
            this.panelPreview.Size = new System.Drawing.Size(586, 558);
            this.panelPreview.TabIndex = 6;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(871, 621);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(84, 26);
            this.buttonSave.TabIndex = 7;
            this.buttonSave.Text = "保存";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // radioButtonZoom
            // 
            this.radioButtonZoom.AutoSize = true;
            this.radioButtonZoom.Checked = true;
            this.radioButtonZoom.Location = new System.Drawing.Point(580, 15);
            this.radioButtonZoom.Name = "radioButtonZoom";
            this.radioButtonZoom.Size = new System.Drawing.Size(59, 16);
            this.radioButtonZoom.TabIndex = 8;
            this.radioButtonZoom.TabStop = true;
            this.radioButtonZoom.Text = "缩略图";
            this.radioButtonZoom.UseVisualStyleBackColor = true;
            this.radioButtonZoom.CheckedChanged += new System.EventHandler(this.radioButtonZoom_CheckedChanged);
            // 
            // radioButtonAutoSize
            // 
            this.radioButtonAutoSize.AutoSize = true;
            this.radioButtonAutoSize.Location = new System.Drawing.Point(681, 15);
            this.radioButtonAutoSize.Name = "radioButtonAutoSize";
            this.radioButtonAutoSize.Size = new System.Drawing.Size(47, 16);
            this.radioButtonAutoSize.TabIndex = 9;
            this.radioButtonAutoSize.TabStop = true;
            this.radioButtonAutoSize.Text = "原图";
            this.radioButtonAutoSize.UseVisualStyleBackColor = true;
            this.radioButtonAutoSize.CheckedChanged += new System.EventHandler(this.radioButtonAutoSize_CheckedChanged);
            // 
            // checkBoxUniOp
            // 
            this.checkBoxUniOp.AutoSize = true;
            this.checkBoxUniOp.Checked = true;
            this.checkBoxUniOp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxUniOp.Location = new System.Drawing.Point(499, 16);
            this.checkBoxUniOp.Name = "checkBoxUniOp";
            this.checkBoxUniOp.Size = new System.Drawing.Size(72, 16);
            this.checkBoxUniOp.TabIndex = 10;
            this.checkBoxUniOp.Text = "统一操作";
            this.checkBoxUniOp.UseVisualStyleBackColor = true;
            this.checkBoxUniOp.CheckedChanged += new System.EventHandler(this.checkBoxUniOp_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 662);
            this.Controls.Add(this.checkBoxUniOp);
            this.Controls.Add(this.radioButtonAutoSize);
            this.Controls.Add(this.radioButtonZoom);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBoxPreview);
            this.Controls.Add(this.buttonPreview);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.groupBoxOriginalImage);
            this.Name = "Form1";
            this.Text = "截图拼接小工具";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxOriginalImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            this.groupBoxPreview.ResumeLayout(false);
            this.panelPreview.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBoxOriginalImage;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button buttonPreview;
        private System.Windows.Forms.PictureBox pictureBoxPreview;
        private System.Windows.Forms.GroupBox groupBoxPreview;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Panel panelPreview;
        private System.Windows.Forms.RadioButton radioButtonZoom;
        private System.Windows.Forms.RadioButton radioButtonAutoSize;
        private System.Windows.Forms.CheckBox checkBoxUniOp;
    }
}

