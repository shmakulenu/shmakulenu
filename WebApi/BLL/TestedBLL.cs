using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Classes;
using DTO;
namespace BLL
{
    public class TestedBLL
    {
        //פונקציה המוסיפה בדיקה
        public static bool AddTest(int tz,string path)
        {
            try
            {
                PatientsDTO patient = PatientDAL.GetPatientsByTz(tz);
                TestedDTO test = new TestedDTO();
                test.Patient_tz = tz;
                test.SnifId = ((int)patient.SnifId);
                test.Test_date_ = DateTime.Now;
                test.File_test_result_navigation = path;
                return TestedDAL.AddTest(test);
            }catch (Exception ex)
            {
                return false;
            }
        }
        const string FILE_PATH = @"F:\פרויקט\Files\";

        public static string AddFile(FileToUpload theFile)
        {
            var filePathName = FILE_PATH + Path.GetFileNameWithoutExtension(theFile.FileName) + "-" +
                DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "") +
                Path.GetExtension(theFile.FileName);
            if (theFile.FileAsBase64.Contains(","))
            {
                theFile.FileAsBase64 = theFile.FileAsBase64.Substring(theFile.FileAsBase64.IndexOf(",") + 1);
            }

            using (var fs = new FileStream(filePathName, FileMode.CreateNew))
            {
                fs.Write(Convert.FromBase64String(theFile.FileAsBase64), 0, Convert.FromBase64String(theFile.FileAsBase64).Length);
            }
            return filePathName;
        }
    }
}
