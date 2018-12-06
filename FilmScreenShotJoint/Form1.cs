using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FilmScreenShotJoint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            showError += new ShowError(ShowErrorByConsole);
            showError += new ShowError(ShowErrorByMessageBox);
            pictureBoxPreviewInitSize = pictureBoxPreview.Size;
        }

        private Size pictureBoxPreviewInitSize;
        const int panelWidth = 526;
        const int panelHeight = 284;
        const int numericUpDownWidth = 50;
        const int numericUpDownHeight = 21;
        const int pictureBoxWidth = 467;
        /// <summary>
        /// 数字选择器的量程
        /// 
        /// </summary>
        private int limitLength;
        /// <summary>
        /// 默认截图区域顶部位置
        /// </summary>
        private int defaultLimitTop;
        /// <summary>
        /// 默认截图高度
        /// </summary>
        private int minSubtitleHeight;
        private int initExtraSubtitleHeight = 40;

        private const int topFlag = 1, bottomFlag = 2;

        private List<Image> imageList = new List<Image>();
        /// <summary>
        /// 存储用户选择的图片高度区间的列表<top, bottom>
        /// </summary>
        private List<LowerUpper> imageHeightSelectionList = new List<LowerUpper>();
        // 图片实际宽度和高度（多张图片宽高要一致）
        private int ImageRealWidth, imageRealHeight;

        private delegate void ShowError(string msg);
        private ShowError showError;
        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (Image img in imageList)
            {
                img.Dispose();
            }
            imageList.Clear();
            imageHeightSelectionList.Clear();
            ClearPreview();
        }

        private void ClearPreview()
        {
            if (pictureBoxPreview.Image != null)
            {
                pictureBoxPreview.Image.Dispose();
                pictureBoxPreview.Image = null;
            }
        }

        private void EnablePreview(bool enable)
        {
            buttonPreview.Enabled = enable;
            if (!enable)
            {
                EnablePreviewModeAndSave(enable);
            }
        }

        private void EnablePreviewModeAndSave(bool enable)
        {
            buttonSave.Enabled = 
            radioButtonAutoSize.Enabled = 
            radioButtonZoom.Enabled = enable;
        }

        private void SetLimit(int limitLen)
        {
            limitLength = limitLen;
            defaultLimitTop = (int)(limitLength * 0.78);
            minSubtitleHeight = Math.Min((int)(limitLength * 0.1), 40);
        }

        /// <summary>
        /// 点击选择文件按钮后的事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            Clear();

            flowLayoutPanel1.Focus();

            ImageRealWidth = -1;
            imageRealHeight = -1;
            string[] selectedImageFiles = openFileDialog1.FileNames;
            foreach(string fileName in selectedImageFiles)
            {
                Console.WriteLine(fileName);
                ////通过输入文件目录，文件模式，访问模式等参数，通过流打开文件
                //FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                ////通过调用系统的画笔工具，画出一个Image类型的数据，传给pictureBox。
                //Image image = Bitmap.FromStream(fs);
                Image image = Image.FromFile(fileName);
                if (ImageRealWidth < 0)
                {
                    ImageRealWidth = image.Width;
                    imageRealHeight = image.Height;
                    SetLimit(imageRealHeight);
                    imageList.Add(image);
                }
                else if (ImageRealWidth != image.Width || imageRealHeight != image.Height)
                {
                    showError("图片尺寸不一致！");
                    return;
                }
                else
                {
                    imageList.Add(image);
                }
                    
            }
            showImageList();
            EnablePreview(true);
            EnablePreviewModeAndSave(false);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            if (pictureBoxPreview.Image != null)
            {
                pictureBoxPreview.Image.Save(saveFileDialog1.FileName);
            }    
        }

        /// <summary>
        /// 将选中的图片展示出来
        /// </summary>
        private void showImageList()
        {
            int i = 0;
            foreach(Image img in imageList)
            {
                showAImage(img, i++);
            }
        }

        private void showAImage(Image img, int index)
        {
            #region pictureBox
            PictureBox pictureBox = new PictureBox
            {
                BackColor = SystemColors.Window,
                Dock = DockStyle.Left,
                Location = new Point(0, 0),
                Size = new Size(pictureBoxWidth, panelHeight),
                Name = "pictureBox" + index,
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = img
            };
            pictureBox.Click += new EventHandler(panel_Click);
            #endregion

            #region numericUpDown
            NumericUpDown top = new NumericUpDown
            {
                Location = new Point(panelWidth - numericUpDownWidth, 0),
                Size = new Size(numericUpDownWidth, numericUpDownHeight),
                TabIndex = topFlag,
                Minimum = 1,
                Maximum = defaultLimitTop,
                Value = Math.Max(defaultLimitTop - initExtraSubtitleHeight / 2, 1)
            };
            top.ValueChanged += new EventHandler(numericUpDownValueChanged);

            NumericUpDown bottom = new NumericUpDown
            {
                Location = new Point(panelWidth - numericUpDownWidth, panelHeight - numericUpDownHeight),
                Size = new Size(numericUpDownWidth, numericUpDownHeight),
                TabIndex = bottomFlag,
                Minimum = defaultLimitTop + minSubtitleHeight,
                Maximum = limitLength,
                Value = Math.Min(defaultLimitTop + minSubtitleHeight + initExtraSubtitleHeight / 2, limitLength)
            };
            bottom.ValueChanged += new EventHandler(numericUpDownValueChanged);
            #endregion

            #region panel      
            Color coverPanelColor = Color.LightBlue;
            Panel panelTop = new Panel
            {
                BackColor = coverPanelColor,
                Location = new Point(0, 0),
                Name = "panelTop" + index,
                Size = new Size(pictureBoxWidth, panelHeight * (int)top.Value / limitLength),
                TabIndex = topFlag
            };

            Panel panelBottom = new Panel
            {
                BackColor = coverPanelColor,
                Location = new Point(0, panelHeight * (int)bottom.Value / limitLength),
                Name = "panelBottom" + index,
                Size = new Size(pictureBoxWidth, panelHeight * (limitLength - (int)top.Value) / limitLength),
                TabIndex = bottomFlag
            };

            Panel panel = new Panel
            {
                BackColor = SystemColors.ActiveBorder,
                Location = new Point(8, 8),
                Name = "panel" + index,
                Size = new Size(panelWidth, panelHeight),
                TabIndex = 0
            };
            panel.Controls.Add(top);
            panel.Controls.Add(bottom);
            panel.Controls.Add(panelTop);// 先加的显示在上层
            panel.Controls.Add(panelBottom);// 先加的显示在上层
            panel.Controls.Add(pictureBox);
            panel.Click += new EventHandler(panel_Click);
            
            

            //using (Graphics g = panel.CreateGraphics())
            //{
            //    Brush brush = Brushes.Red; ;
            //    g.FillRectangles(brush, new Rectangle[]
            //    {
            //        new Rectangle(0, 0, panelWidth, panelHeight * defaultMax / (int)top.Value),
            //        new Rectangle(0, panelHeight * defaultMax / (int)bottom.Value, panelWidth, panelHeight * defaultMax/(defaultMax-(int)bottom.Value))
            //    });
            //}

            

            flowLayoutPanel1.Controls.Add(panel);
            #endregion
        }


        private void numericUpDownValueChanged(object sender, EventArgs e)
        {
            if (!(sender is NumericUpDown))
            {
                return;
            }
            NumericUpDown src = (NumericUpDown)sender, dest;
            Panel panel;
            // 上面
            if (src.TabIndex == topFlag)
            {
                dest = GetInParent<NumericUpDown>(src.Parent, bottomFlag);
                if (dest == null)
                {
                    showError("dest is null");
                    return;
                }
                src.Maximum = Math.Max(src.Maximum, dest.Value);
                dest.Minimum = src.Value + minSubtitleHeight;// todo 如果dest的值小于最小值，可能需要程序调整
                panel = GetInParent<Panel>(src.Parent, topFlag);
                if (panel == null)
                {
                    showError("panel is null");
                    return;
                }
                panel.Size = new Size(pictureBoxWidth, panelHeight * (int)src.Value / limitLength);
            }
            else// 下面
            {
                dest = GetInParent<NumericUpDown>(src.Parent, topFlag);
                if (dest == null)
                {
                    showError("dest is null");
                    return;
                }
                src.Minimum = Math.Min(src.Minimum, dest.Value);
                dest.Maximum = src.Value - minSubtitleHeight;// todo 如果dest的值小于最小值，可能需要程序调整
                panel = GetInParent<Panel>(src.Parent, bottomFlag);
                if (panel == null)
                {
                    showError("panel is null");
                    return;
                }
                panel.Size = new Size(pictureBoxWidth, panelHeight * (limitLength - (int)src.Value) / limitLength);
                panel.Location = new Point(0, panelHeight * (int)src.Value / limitLength);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            EnablePreview(false);
        }

        private void panel_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Focus();
            Console.WriteLine("flowLayoutPanel1.Focus");
        }

        private void buttonPreview_Click(object sender, EventArgs e)
        {
            imageHeightSelectionList.Clear();
            foreach (Control c in flowLayoutPanel1.Controls)
            {
                if (c is Panel)// 遍历每一个截图面板
                {
                    NumericUpDown top = GetInParent<NumericUpDown>(c, topFlag);
                    NumericUpDown bottom = GetInParent<NumericUpDown>(c, bottomFlag);
                    if (top == null || bottom == null)
                    {
                        showError("can not found limit");
                        return;
                    }
                    int lower = imageRealHeight * (int)top.Value / limitLength;
                    int upper = imageRealHeight * (int)bottom.Value / limitLength;
                    Console.WriteLine($"lower:{lower}, upper:{upper}");
                    imageHeightSelectionList.Add(new LowerUpper(lower, upper));
                }
            }
            GenerateImageAndShow();
            EnablePreviewModeAndSave(true);
        }

        private void GenerateImageAndShow()
        {
            int totalHeight = 0;
            for (int i = 0; i < imageHeightSelectionList.Count; i++)
            {
                LowerUpper range = imageHeightSelectionList[i];
                if (i == 0)
                {
                    totalHeight += range.upper;
                }
                else
                {
                    totalHeight += range.upper - range.lower + 1;
                }
            }
            Bitmap bitmap = new Bitmap(ImageRealWidth, totalHeight);
            Graphics g = Graphics.FromImage(bitmap);
            g.DrawImage(bitmap, bitmap.Width, bitmap.Height);
            int currentHeight = 0;
            for (int i=0;i<imageList.Count;i++)
            {
                LowerUpper range = imageHeightSelectionList[i];
               
                Image img = imageList[i];
                int y, height;
                if (i == 0)
                {
                    y = 0;
                    height = range.upper;
                }
                else
                {
                    y = range.lower - 1;
                    height = range.upper - range.lower + 1;
                }
                // 摘要:在指定的位置绘制图像的一部分。
                // 参数:
                //   image:要绘制的 System.Drawing.Image。
                //   x:所绘制图像的左上角的 x 坐标。
                //   y:所绘制图像的左上角的 y 坐标。
                //   srcRect:System.Drawing.Rectangle 结构，它指定 image 对象中要绘制的部分。
                //   srcUnit:System.Drawing.GraphicsUnit 枚举的成员，它指定 srcRect 参数所用的度量单位。
                // public void DrawImage(Image image, int x, int y, Rectangle srcRect, GraphicsUnit srcUnit);
                g.DrawImage(img, 0, currentHeight, new Rectangle(0, y, ImageRealWidth, height), GraphicsUnit.Pixel);
                currentHeight += height;
            }
            g.Dispose();
            ClearPreview();
            Console.WriteLine($"bitmap.Width: {bitmap.Width}, bitmap.Height:{bitmap.Height}, panelPreview.Size:{panelPreview.Size}");
            pictureBoxPreview.Image = bitmap;
            panelPreview.Focus();
        }

        private T GetInParent<T>(Control parent, int flag) where T : Control
        {
            foreach (Control c in parent.Controls)
            {
                if (c is T && c.TabIndex == flag)
                {
                    return (T)c;
                }
            }
            return null;
        }
        
        private void ShowErrorByConsole(string msg)
        {
            Console.WriteLine(msg);
        }

        private void radioButtonZoom_CheckedChanged(object sender, EventArgs e)
        {
            pictureBoxPreview.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxPreview.Location = new Point(0, 0);
            pictureBoxPreview.Size = pictureBoxPreviewInitSize;
            panelPreview.Focus();
        }

        private void radioButtonAutoSize_CheckedChanged(object sender, EventArgs e)
        {
            pictureBoxPreview.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBoxPreview.Location = new Point(0, 0);
            panelPreview.Focus();
        }

        private void ShowErrorByMessageBox(string msg)
        {
            MessageBox.Show(msg);
        }

        struct LowerUpper
        {
            public int lower, upper;
            public LowerUpper(int l, int u)
            {
                lower = l;
                upper = u;
            }
        }
    }
}
