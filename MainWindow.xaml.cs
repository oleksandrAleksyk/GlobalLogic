using System.Windows;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace Global_Logic_Wfp_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string DirectoryPath;
        public MainWindow()
        {
            InitializeComponent();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowDialog();
            if (folderBrowserDialog.SelectedPath != null)
            {
                textBox.Text = folderBrowserDialog.SelectedPath;
                DirectoryPath = textBox.Text.ToString();
            }

            
            if (textBox.Text != "Your folder path.....")
            {
                string path = DirectoryPath;
                DisplayInfo(path);
            }
        }

        
        
        string GetFolderName(string path)
        {
            string name = new DirectoryInfo(path).Name;
            return name;
        }
        string GetFolderTimeOfCretion(string path)
        {
            string timeOfCreation = new DirectoryInfo(path).CreationTime.ToString();
            return timeOfCreation;
        }

        string GetFileName(string path)
        {
            string name = new FileInfo(path).Name;      
           
            
            return name;
        }
        string GetFileTimeOfCreation(string path)
        {
            string timeOfCreation = new FileInfo(path).CreationTime.ToString();
            return timeOfCreation;
        }
        string GetFileSize(string path)
        {   string size = new FileInfo(path).Length.ToString();
            return size;
        }


        void DisplayInfo(string path)
        {
            var display ="\nName:" + GetFolderName(path) + "\nTime of creation:" + GetFolderTimeOfCretion(path) + "\n";
            displayInfo.Text += display;
            foreach (var files in new DirectoryInfo(path).GetFiles())
            {
                string filesPath = path + "\\" + files;

                string show = "\t"+"Name:"+GetFileName(filesPath)+"\n\t"+"TimeOfCreation"+GetFileTimeOfCreation(filesPath)+"\n\t"+"Size:"+GetFileSize(filesPath)+"\n";
                displayInfo.Text += GetFolderName(path)+"`s files\n"+show;
            }
            if (new DirectoryInfo(path).GetDirectories().Length > 0)
            {
                foreach (var folder in new DirectoryInfo(path).GetDirectories())
                {
                    displayInfo.Text += GetFolderName(path)+"`s"+" subFolder:\n";
                    string subFolderPath = path + "\\" + folder;
                    DisplayInfo(subFolderPath);
                }
            }

        }

        
    }
}
