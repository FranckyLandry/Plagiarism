using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace PMaster.Models
{
    public class UnzipFileUpload
    {

        public List<Tuple<string, int,string>> UnzipFile(HttpPostedFileBase fileUploaded, int student_Id, string basePath, Assignment assignment, string tempfile, string languageChosen,out string folder_path)
        {


            if (!(Path.GetExtension(fileUploaded.FileName) == ".zip" && fileUploaded != null && fileUploaded.ContentLength > 0))
            {
                folder_path = null;
                return null;
            }

            using (ZipArchive archive = new ZipArchive(fileUploaded.InputStream))
            {
                var fileName = Path.GetFileNameWithoutExtension(fileUploaded.FileName);

                fileName = student_Id + "_" + fileName;




                var folderPath = Path.Combine(basePath, assignment.CourseName.Trim(), assignment.AssignmentName.Trim(), student_Id.ToString());
                var folderPath_AllAssignemnet = Path.Combine(basePath, assignment.CourseName.Trim(), assignment.AssignmentName.Trim());




                //Save the new file to a temporaly file

                //archive.ExtractToDirectory(tempfile);

                foreach (var item in archive.Entries)
                {
                    if (GetOnlyClass(item,languageChosen))
                        item.ExtractToFile(Path.Combine(tempfile, item.Name));
                }

                //var all_Files = Directory.GetFileSystemEntries(folderPath_AllAssignemnet);


                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                

                Sim sim = new Sim();

               var result =  sim.Check(tempfile, assignment.AssignmentName, folderPath_AllAssignemnet,languageChosen);

              
                foreach (var item in archive.Entries)
                {
                    if (GetOnlyClass(item,languageChosen))
                    {
                        item.ExtractToFile(Path.Combine(folderPath, item.Name));
                    }

                   
                }



                folder_path = folderPath;
                return result; 
            }
        }


        public bool GetOnlyClass(ZipArchiveEntry entry,string languageChosen)
        {
            switch (languageChosen)
            {
                case "C#":
                    if (entry.FullName.EndsWith(".cs", StringComparison.OrdinalIgnoreCase) &&
                                      (!(entry.FullName.Contains("Resources"))) &&
                                      (!(entry.FullName.Contains("AssemblyInfo"))) &&
                                      (!(entry.FullName.Contains("Settings"))) &&
                                      (!(entry.FullName.Contains("Form"))) &&
                                      //(!(entry.FullName.Contains("Program"))) &&
                                      (!(entry.FullName.Contains("Temp"))))
                        return true;

                    break;

                case "Java":
                    if (entry.FullName.EndsWith(".java", StringComparison.OrdinalIgnoreCase))
                                    
                        return true;
                    break;

                case "C++/C":
                    if (entry.FullName.EndsWith(".c", StringComparison.OrdinalIgnoreCase))

                        return true;
                    break;

                case "Python":
                    if (entry.FullName.EndsWith(".py", StringComparison.OrdinalIgnoreCase))

                        return true;


                    break;

                case "PHP":
                    if (entry.FullName.EndsWith(".py", StringComparison.OrdinalIgnoreCase))

                        return true;

                    break;
                //default:
                //    return false;
                //    //break;
            }
            return false;


          
          

        }

        
        

    }
}