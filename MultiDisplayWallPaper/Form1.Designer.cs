namespace MultiDisplayWallPaper
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
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
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
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPath1 = new System.Windows.Forms.Button();
            this.textPath1 = new System.Windows.Forms.Label();
            this.textPath2 = new System.Windows.Forms.Label();
            this.pictBoxDisplay1 = new System.Windows.Forms.PictureBox();
            this.pictBoxDisplay2 = new System.Windows.Forms.PictureBox();
            this.listBoxDisplay1 = new System.Windows.Forms.ListBox();
            this.listBoxDisplay2 = new System.Windows.Forms.ListBox();
            this.btnSavePath = new System.Windows.Forms.Button();
            this.textSavePath = new System.Windows.Forms.Label();
            this.PorgBar = new System.Windows.Forms.ProgressBar();
            this.textDone = new System.Windows.Forms.Label();
            this.btnPath2 = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictBoxDisplay1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictBoxDisplay2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPath1
            // 
            this.btnPath1.Location = new System.Drawing.Point(12, 12);
            this.btnPath1.Name = "btnPath1";
            this.btnPath1.Size = new System.Drawing.Size(80, 30);
            this.btnPath1.TabIndex = 0;
            this.btnPath1.Text = "Path1";
            this.btnPath1.UseVisualStyleBackColor = true;
            this.btnPath1.Click += new System.EventHandler(this.btnPath1_Click);
            // 
            // textPath1
            // 
            this.textPath1.AutoSize = true;
            this.textPath1.Location = new System.Drawing.Point(98, 21);
            this.textPath1.Name = "textPath1";
            this.textPath1.Size = new System.Drawing.Size(31, 12);
            this.textPath1.TabIndex = 1;
            this.textPath1.Text = "Path1";
            this.textPath1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textPath2
            // 
            this.textPath2.AutoSize = true;
            this.textPath2.Location = new System.Drawing.Point(98, 59);
            this.textPath2.Name = "textPath2";
            this.textPath2.Size = new System.Drawing.Size(31, 12);
            this.textPath2.TabIndex = 1;
            this.textPath2.Text = "Path2";
            this.textPath2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictBoxDisplay1
            // 
            this.pictBoxDisplay1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictBoxDisplay1.Location = new System.Drawing.Point(204, 287);
            this.pictBoxDisplay1.Name = "pictBoxDisplay1";
            this.pictBoxDisplay1.Size = new System.Drawing.Size(400, 225);
            this.pictBoxDisplay1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictBoxDisplay1.TabIndex = 2;
            this.pictBoxDisplay1.TabStop = false;
            // 
            // pictBoxDisplay2
            // 
            this.pictBoxDisplay2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictBoxDisplay2.Location = new System.Drawing.Point(610, 112);
            this.pictBoxDisplay2.Name = "pictBoxDisplay2";
            this.pictBoxDisplay2.Size = new System.Drawing.Size(225, 400);
            this.pictBoxDisplay2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictBoxDisplay2.TabIndex = 3;
            this.pictBoxDisplay2.TabStop = false;
            // 
            // listBoxDisplay1
            // 
            this.listBoxDisplay1.FormattingEnabled = true;
            this.listBoxDisplay1.ItemHeight = 12;
            this.listBoxDisplay1.Location = new System.Drawing.Point(12, 112);
            this.listBoxDisplay1.Name = "listBoxDisplay1";
            this.listBoxDisplay1.Size = new System.Drawing.Size(90, 400);
            this.listBoxDisplay1.TabIndex = 4;
            this.listBoxDisplay1.SelectedIndexChanged += new System.EventHandler(this.listBoxDisplay1_SelectedIndexChanged);
            // 
            // listBoxDisplay2
            // 
            this.listBoxDisplay2.FormattingEnabled = true;
            this.listBoxDisplay2.ItemHeight = 12;
            this.listBoxDisplay2.Location = new System.Drawing.Point(108, 112);
            this.listBoxDisplay2.Name = "listBoxDisplay2";
            this.listBoxDisplay2.Size = new System.Drawing.Size(90, 400);
            this.listBoxDisplay2.TabIndex = 5;
            this.listBoxDisplay2.SelectedIndexChanged += new System.EventHandler(this.listBoxDisplay2_SelectedIndexChanged);
            // 
            // btnSavePath
            // 
            this.btnSavePath.Location = new System.Drawing.Point(872, 516);
            this.btnSavePath.Name = "btnSavePath";
            this.btnSavePath.Size = new System.Drawing.Size(80, 30);
            this.btnSavePath.TabIndex = 0;
            this.btnSavePath.Text = "SavePath";
            this.btnSavePath.UseVisualStyleBackColor = true;
            this.btnSavePath.Click += new System.EventHandler(this.btnSavePath_Click);
            // 
            // textSavePath
            // 
            this.textSavePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textSavePath.AutoSize = true;
            this.textSavePath.Location = new System.Drawing.Point(819, 525);
            this.textSavePath.Name = "textSavePath";
            this.textSavePath.Size = new System.Drawing.Size(47, 12);
            this.textSavePath.TabIndex = 1;
            this.textSavePath.Text = "SavePath";
            this.textSavePath.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PorgBar
            // 
            this.PorgBar.Location = new System.Drawing.Point(822, 553);
            this.PorgBar.Name = "PorgBar";
            this.PorgBar.Size = new System.Drawing.Size(130, 23);
            this.PorgBar.TabIndex = 6;
            // 
            // textDone
            // 
            this.textDone.Location = new System.Drawing.Point(902, 579);
            this.textDone.Name = "textDone";
            this.textDone.Size = new System.Drawing.Size(50, 12);
            this.textDone.TabIndex = 1;
            this.textDone.Text = "DONE!";
            this.textDone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.textDone.Visible = false;
            // 
            // btnPath2
            // 
            this.btnPath2.Location = new System.Drawing.Point(12, 50);
            this.btnPath2.Name = "btnPath2";
            this.btnPath2.Size = new System.Drawing.Size(80, 30);
            this.btnPath2.TabIndex = 7;
            this.btnPath2.Text = "Path2";
            this.btnPath2.UseVisualStyleBackColor = true;
            this.btnPath2.Click += new System.EventHandler(this.btnPath2_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(730, 550);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(80, 30);
            this.btnStart.TabIndex = 8;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(640, 550);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 30);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnPath2);
            this.Controls.Add(this.PorgBar);
            this.Controls.Add(this.listBoxDisplay2);
            this.Controls.Add(this.listBoxDisplay1);
            this.Controls.Add(this.pictBoxDisplay2);
            this.Controls.Add(this.pictBoxDisplay1);
            this.Controls.Add(this.textPath2);
            this.Controls.Add(this.textSavePath);
            this.Controls.Add(this.textDone);
            this.Controls.Add(this.textPath1);
            this.Controls.Add(this.btnSavePath);
            this.Controls.Add(this.btnPath1);
            this.Name = "Form1";
            this.Text = "MultiDisplayWallPaper";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictBoxDisplay1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictBoxDisplay2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPath1;
        private System.Windows.Forms.Label textPath1;
        private System.Windows.Forms.Label textPath2;
        private System.Windows.Forms.PictureBox pictBoxDisplay1;
        private System.Windows.Forms.PictureBox pictBoxDisplay2;
        private System.Windows.Forms.ListBox listBoxDisplay1;
        private System.Windows.Forms.ListBox listBoxDisplay2;
        private System.Windows.Forms.Button btnSavePath;
        private System.Windows.Forms.Label textSavePath;
        private System.Windows.Forms.ProgressBar PorgBar;
        private System.Windows.Forms.Label textDone;
        private System.Windows.Forms.Button btnPath2;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnCancel;
    }
}

