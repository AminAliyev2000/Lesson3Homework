using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3Homework
{
    class ButtonsFunctionality
    {

        public string FileName { get; set; }
        private string GetPathOfFile(string filePath)
        {
            return filePath.EndsWith(".txt") ? filePath : filePath + ".txt";
        }
        public string ReadTextFromFile()
        {
            var open = new OpenFileDialog();
            open.Filter = "Txt Files (*.txt)| *.txt";

            if (open.ShowDialog() != true)
                return String.Empty;

            FileName = open.FileName;

            return File.ReadAllText(FileName);
        }

        public void SaveTextToFile(string data)
        {
            var save = new SaveFileDialog();

            save.Filter = "Txt Files (*.txt)| *.txt";

            if (save.ShowDialog() != true)
                return;

            FileName = GetPathOfFile(save.FileName);

            File.WriteAllText(FileName, data);
        }

        public void AutoSaving(string data)
        {
            if (String.IsNullOrWhiteSpace(FileName))
                return;

            File.WriteAllText(FileName, data);
        }
    }
}
