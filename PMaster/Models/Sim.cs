using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace PMaster.Models
{
    public class Sim
    {




        private Tuple<string, int, string> pair_path_percentage = null;
        private List<Tuple<string, int, string>> result_List = new List<Tuple<string, int, string>>();
        private string vew_full = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="folder_To_Check"></param>
        /// <param name="assignmentName"></param>
        /// <param name="All_Filles"></param>
        public List<Tuple<string, int, string>> Check(string folder_To_Check, string assignmentName, string All_Filles,string languageChosen)
        {

            Process process = new Process();
            string outputt = null;
            List<string> outputList = new List<string>();

            string[] folder_toCheck = null;

            string[] filePaths = null;
            switch (languageChosen)
            {
                case "C#":

                    folder_toCheck = Directory.GetFiles(folder_To_Check, "*.cs", SearchOption.AllDirectories);

                    filePaths = Directory.GetFiles(All_Filles, "*.cs", SearchOption.AllDirectories);
                    break;
                case "Java":

                     folder_toCheck = Directory.GetFiles(folder_To_Check, "*.java", SearchOption.AllDirectories);
                     filePaths = Directory.GetFiles(All_Filles, "*.java", SearchOption.AllDirectories);
                    break;

                case "C++/C":

                    folder_toCheck = Directory.GetFiles(folder_To_Check, "*.c", SearchOption.AllDirectories);
                    filePaths = Directory.GetFiles(All_Filles, "*.c", SearchOption.AllDirectories);
                    break;

                case "Python":

                    folder_toCheck = Directory.GetFiles(folder_To_Check, "*.py", SearchOption.AllDirectories);
                    filePaths = Directory.GetFiles(All_Filles, "*.py", SearchOption.AllDirectories);
                    break;

                case "PHP":

                    folder_toCheck = Directory.GetFiles(folder_To_Check, "*.php", SearchOption.AllDirectories);
                    filePaths = Directory.GetFiles(All_Filles, "*.php", SearchOption.AllDirectories);
                    break;
                default:
                    break;
            }

            //string[] folder_toCheck = Directory.GetFiles(folder_To_Check, "*.cs", SearchOption.AllDirectories);

            //string[] filePaths = Directory.GetFiles(All_Filles, "*.cs", SearchOption.AllDirectories);

            if (filePaths.Count() == 0)
            {
                foreach (var item in folder_toCheck)
                {
                    File.Delete(item);
                }

                return null;
            }

            try
            {


                process.StartInfo.FileName = @"C:\Users\Systeembeheer\Desktop\WebMaster\PMasterWorkingOnBeta\PMaster\Sim\sim_c.exe";

                process.StartInfo.Arguments = "-R -t 20 -P " + folder_To_Check + " " + All_Filles;

                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.Start();
                // Synchronously read the standard output of the spawned process. 
                StreamReader reader = process.StandardOutput;
                // this is for the output

                while ((reader.ReadLine()) != null)
                {
                    outputt = reader.ReadLine();
                    if (outputt == null)
                        break;
                    if (outputt.Contains("consists for"))
                    {
                        outputList.Add(outputt);
                        vew_full = "-R " + folder_To_Check + " " + All_Filles;
                    }

                }


                var returnType = "";




                for (int i = 0; i < outputList.Count; i++)
                {

                    if (outputList[i].IndexOf("%") != -1)
                    {
                        string strTemp = String.Join("", outputList[i].Substring(0, outputList[i].IndexOf("%")).Reverse());
                        char[] type = strTemp.Split(' ')[1].ToCharArray();
                        Array.Reverse(type);
                        returnType = new string(type);
                        pair_path_percentage = new Tuple<string, int, string>(outputList[i], Convert.ToInt32(returnType), vew_full);



                        result_List.Add(pair_path_percentage);

                    }

                }
              
                if (outputList != null)
                {

                }

                process.WaitForExit();
                process.Close();


                if (outputList.Count() != 0)
                {
                    foreach (var item in folder_toCheck)
                    {
                        File.Delete(item);
                    }
                    //File.Delete(folder_To_Check);


                    return result_List;
                }
                else
                {
                    foreach (var item in folder_toCheck)
                    {
                        File.Delete(item);
                    }
                    return null;
                }



            }
            catch (Exception ex)
            {

                throw ex;
            }



        }




        public string FullResult(string fullPath, string path)
        {
            Process process = new Process();

            string new_path = path + "/fullresult" + "fullresult.txt";
            List<string> outputlist = new List<string>();
            List<string> results = new List<string>();
            try
            {


                process.StartInfo.FileName = @"C:\Users\Systeembeheer\Desktop\WebMaster\PMasterWorkingOnBeta\PMaster\Sim\sim_c.exe";

                process.StartInfo.Arguments = " " + fullPath;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.Start();
              
                using (StreamReader reader = process.StandardOutput)
                {



                    while ((reader.ReadLine()) != null)
                    {


                        results.Add(reader.ReadLine());
                    }
                }
              

                using (StreamWriter writer = new StreamWriter(new_path))
                {
                    foreach (string item in results)
                    {
                        writer.WriteLine(item);
                    }

                }
                

                process.WaitForExit();
                process.Close();
            

                return new_path;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public List<string> ReadFull_Result(string path_parameter)
        {
            List<string> resul_full = new List<string>();
        
            var fileStream = new FileStream(path_parameter, FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                do
                {
                    resul_full.Add(streamReader.ReadToEnd());
                } while (streamReader.ReadLine() != null);



            }


            return resul_full;
        }

    }
}
