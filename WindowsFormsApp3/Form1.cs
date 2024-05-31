using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Path_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog())
            {
                // 設定對話框的屬性
                folderBrowserDialog1.Description = "選擇資料夾";
                folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer; // 設定根資料夾

                // 如果使用者選擇了資料夾並按下了「確定」按鈕
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    // 取得選擇的資料夾路徑
                    string folderPath = folderBrowserDialog1.SelectedPath;

                    // 將路徑顯示在標籤中或做其他處理
                    url.Text = folderPath;
                }
            } // 使用完 FolderBrowserDialog 後，會自動釋放資源
        }

        private void CopyFolder(string sourceFolder, string destFolder)
        {
            // 如果目的地資料夾不存在，則建立它
            if (!Directory.Exists(destFolder))
            {
                Directory.CreateDirectory(destFolder);
            }

            // 複製資料夾內的所有檔案
            foreach (string file in Directory.GetFiles(sourceFolder))
            {
                string destFile = Path.Combine(destFolder, Path.GetFileName(file));
                System.IO.File.Copy(file, destFile, true);
            }

            // 複製資料夾內的所有子資料夾（遞迴）
            foreach (string folder in Directory.GetDirectories(sourceFolder))
            {
                string destSubFolder = Path.Combine(destFolder, Path.GetFileName(folder));
                CopyFolder(folder, destSubFolder);
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            // 取得選擇的資料夾路徑
            string sourceFolderPath = url.Text.Trim();

            if (string.IsNullOrEmpty(sourceFolderPath))
            {
                MessageBox.Show("請選擇資料夾路徑");
                url.Focus();
                return;
            }

            // 取得資料夾的父資料夾路徑
            string parentFolderPath = Directory.GetParent(sourceFolderPath).FullName;

            string[] subDirectories = Directory.GetDirectories(parentFolderPath);

            // 新資料夾的名稱為原資料夾名稱加上"_1"
            string newFolderName = Path.GetFileName(sourceFolderPath) + "_" + subDirectories.Length.ToString();

            // 新資料夾的完整路徑
            string newFolderPath = Path.Combine(Path.GetDirectoryName(sourceFolderPath), newFolderName);

            //如果有選中項 改用選中項的路徑
            if (SaveList.SelectedIndex > -1)
            {
                newFolderPath = SaveList.SelectedItem.ToString();                
            }

            // 建立新資料夾
            Directory.CreateDirectory(newFolderPath);

            // 複製資料夾內的所有檔案及子資料夾至新資料夾中
            CopyFolder(sourceFolderPath, newFolderPath);

            MessageBox.Show("資料夾及其內容已成功複製至新資料夾中。");

            bool itemExists = false;
            foreach (var item in SaveList.Items)
            {
                // 如果要检查的项已经存在于 ListBox 中，将 itemExists 设置为 true，并跳出循环
                if (item.ToString() == newFolderPath)
                {
                    itemExists = true;                   
                }
            }

            if (!itemExists)
            {
                SaveList.Items.Add(newFolderPath);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Load_Click(object sender, EventArgs e)
        {
            if (SaveList.SelectedItems.Count < 1)
            {
                MessageBox.Show("請選擇欲讀取的備份檔");
                return;
            }

            // 取得選擇的資料夾路徑
            string sourceFolderPath = SaveList.SelectedItem.ToString();

            //目標資料夾
            string targetFolder = url.Text.Trim();

            // 取得指定資料夾中的所有檔案
            string[] files = Directory.GetFiles(sourceFolderPath);

            CopyFolder(sourceFolderPath, targetFolder);

            // 複製資料夾中的所有檔案到目標資料夾
            //foreach (string file in files)
            //{
            //    string fileName = Path.GetFileName(file);
            //    string destFile = Path.Combine(targetFolder, fileName);
            //    System.IO.File.Copy(file, destFile, true);
            //}

            MessageBox.Show("檔案已成功複製至目標資料夾！", "完成", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void Form1_Click(object sender, EventArgs e)
        {
            SaveList.SelectedIndex = -1;
        }

        private void url_TextChanged(object sender, EventArgs e)
        {

        }

        private void Load_Save_Data_List_Click(object sender, EventArgs e)
        {
            string urlString = url.Text.Trim(); //檔案路徑
            if (string.IsNullOrEmpty(urlString))
            {
                MessageBox.Show("請選擇目標資料夾路徑");
                url.Focus();
                return;
            }

            SaveList.Items.Clear(); //移除所有項目

            string parentFolderPath = Directory.GetParent(urlString).FullName;

            string[] subDirectories = Directory.GetDirectories(parentFolderPath);

            Array.Sort(subDirectories, StringComparer.CurrentCultureIgnoreCase);

            foreach (string i in subDirectories)
            {                
                if (i != urlString)
                {
                    SaveList.Items.Add(i);
                }
            }

            if (SaveList.Items.Count < 1)
            {
                MessageBox.Show("目前暫無備份，請按下存檔進行備份。");
            }
        }
    }
}
