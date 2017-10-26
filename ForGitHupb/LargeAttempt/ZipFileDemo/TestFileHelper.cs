using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZipFileDemo
{
    class TestFileHelper
    {

        private List<string> tempListString;


        /// <summary>
        /// Property FileName stores the name of the text file I am working with. 
        /// </summary>
        public string FileNames { get; set; }

        /// <summary>
        /// a parameter for FileName initialization,
        /// </summary>
        /// <param name="fileNma"></param>

        public TestFileHelper(string fileNma)
        {
            this.FileNames = fileNma;

        }


        /// <summary>
        /// initializes FileName to null.
        /// </summary>
        public TestFileHelper()
        {
            this.FileNames = null;
            this.tempListString = new List<string>();
        }

        /// <summary>
        /// SaveToFile has a List of strings as a parameter. This method should save each 
        ///line of the RichTextBox as a string into the file (with FileName)
        /// </summary>
        /// <param name="lines"></param>

        public void Savefile(List<string> lines)
        {
            FileStream fs = null;
            StreamWriter sr = null;
            try
            {
                fs = new FileStream(FileNames, FileMode.OpenOrCreate, FileAccess.Write);
                sr = new StreamWriter(fs);
                sr.WriteLine();
                lines.Add(sr.ToString());
            }
            catch (IOException) { MessageBox.Show("Error saving"); }
            finally { sr.Close(); }
            
        }


        /// <summary>
        /// Method LoadFromFile should read the file (with FileName), and return a List of 
        /// strings containing all lines from the file. 
        /// </summary>
        /// <returns></returns>
        public List<string> LoadFile()
        {



            List<string> temp = new List<string>();

            FileStream fs = null;
            StreamReader sr = null;
            try
            {

                fs = new FileStream(FileNames, FileMode.Open, FileAccess.Read);
                if (fs.Name == sr.ReadLine())
                    sr = new StreamReader(fs);
                temp.Add(sr.ReadLine());
            }
            catch (IOException) { MessageBox.Show("error reading "); }
            finally { sr.Close(); }
            return temp;

           
        }


    }
}
