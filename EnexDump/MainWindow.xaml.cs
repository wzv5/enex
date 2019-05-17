using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.ComponentModel;
using System.IO;

namespace EnexDump
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private class MainDataModel : INotifyPropertyChanged
        {
            private string _sourcefilename;
            public string SourceFileName
            {
                get => _sourcefilename;
                set
                {
                    _sourcefilename = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SourceFileName"));
                    TargetDir = Path.GetDirectoryName(_sourcefilename);
                }
            }

            private string _targetdir;
            public string TargetDir
            {
                get => _targetdir;
                set
                {
                    _targetdir = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TargetDir"));
                }
            }

            private bool _inlineimage;
            public bool InlineImage
            {
                get => _inlineimage;
                set
                {
                    _inlineimage = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("InlineImage"));
                }
            }

            private bool _insertTitle;
            public bool InsertTitle
            {
                get => _insertTitle;
                set
                {
                    _insertTitle = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("InsertTitle"));
                }
            }

            private bool _uuidfilename;
            public bool UUIDFileName
            {
                get => _uuidfilename;
                set
                {
                    _uuidfilename = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("UUIDFileName"));
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
        }

        private MainDataModel model;
        public MainWindow()
        {
            InitializeComponent();
            model = new MainDataModel();
            DataContext = model;
        }

        private void Btn_select_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "enex 文件 | *.enex";
            if (dlg.ShowDialog() == true)
            {
                model.SourceFileName = dlg.FileName;
            }
        }

        private void Btn_select_Drop(object sender, DragEventArgs e)
        {
            var data = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (data == null || data.Length < 1 || !data[0].ToLower().EndsWith(".enex"))
            {
                return;
            }
            model.SourceFileName = data[0];
        }

        private void Btn_seleck_output_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new System.Windows.Forms.FolderBrowserDialog();
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                model.TargetDir = dlg.SelectedPath;
            }
        }

        private void Btn_dump_Click(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(model.SourceFileName))
            {
                MessageBox.Show("请选择一个 enex 文件");
                return;
            }
            try
            {
                var enex = new EnexFile.EnexFile();
                enex.Load(model.SourceFileName);
                enex.DumpAll(model.TargetDir, new EnexFile.MarkdownConfig()
                {
                    InlineImage = model.InlineImage,
                    InsertTitle = model.InsertTitle,
                    UUIDFilename = model.UUIDFileName
                });
                MessageBox.Show("完成");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
        }
    }
}
