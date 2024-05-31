namespace WindowsFormsApp3
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
            this.url = new System.Windows.Forms.TextBox();
            this.PathDir = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.Loadfile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SaveList = new System.Windows.Forms.ListBox();
            this.Load_Save_Data_List = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // url
            // 
            this.url.Location = new System.Drawing.Point(38, 41);
            this.url.Name = "url";
            this.url.Size = new System.Drawing.Size(846, 29);
            this.url.TabIndex = 0;
            this.url.TextChanged += new System.EventHandler(this.url_TextChanged);
            // 
            // PathDir
            // 
            this.PathDir.Location = new System.Drawing.Point(38, 89);
            this.PathDir.Name = "PathDir";
            this.PathDir.Size = new System.Drawing.Size(140, 45);
            this.PathDir.TabIndex = 1;
            this.PathDir.Text = "選擇存檔路徑";
            this.PathDir.UseVisualStyleBackColor = true;
            this.PathDir.Click += new System.EventHandler(this.Path_Click);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(932, 210);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(110, 45);
            this.Save.TabIndex = 2;
            this.Save.Text = "存檔";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Loadfile
            // 
            this.Loadfile.Location = new System.Drawing.Point(932, 283);
            this.Loadfile.Name = "Loadfile";
            this.Loadfile.Size = new System.Drawing.Size(110, 45);
            this.Loadfile.TabIndex = 3;
            this.Loadfile.Text = "讀取";
            this.Loadfile.UseVisualStyleBackColor = true;
            this.Loadfile.Click += new System.EventHandler(this.Load_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // SaveList
            // 
            this.SaveList.FormattingEnabled = true;
            this.SaveList.ItemHeight = 18;
            this.SaveList.Location = new System.Drawing.Point(38, 210);
            this.SaveList.Name = "SaveList";
            this.SaveList.Size = new System.Drawing.Size(846, 454);
            this.SaveList.TabIndex = 4;
            // 
            // Load_Save_Data_List
            // 
            this.Load_Save_Data_List.Location = new System.Drawing.Point(910, 31);
            this.Load_Save_Data_List.Name = "Load_Save_Data_List";
            this.Load_Save_Data_List.Size = new System.Drawing.Size(132, 45);
            this.Load_Save_Data_List.TabIndex = 5;
            this.Load_Save_Data_List.Text = "載入存檔資料";
            this.Load_Save_Data_List.UseVisualStyleBackColor = true;
            this.Load_Save_Data_List.Click += new System.EventHandler(this.Load_Save_Data_List_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1141, 767);
            this.Controls.Add(this.Load_Save_Data_List);
            this.Controls.Add(this.SaveList);
            this.Controls.Add(this.Loadfile);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.PathDir);
            this.Controls.Add(this.url);
            this.Name = "Form1";
            this.Text = "存檔備份";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.Form1_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox url;
        private System.Windows.Forms.Button PathDir;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Loadfile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ListBox SaveList;
        private System.Windows.Forms.Button Load_Save_Data_List;
    }
}

