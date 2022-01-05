using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Configuration;
using DAL.Classes;

namespace BLL
{
    public class ReadAsapimExcel
    {
        //בעיות!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //הפונקציה חיבת להחזיר ערך בגלל ה-get?
        //ואם אני לא רוצה שהיא תחזיר ערך מה נעשה?

        //יש לחלץ ולכתוב ב-V
        //WebConfig 
        // אינדקסים  לפרטים אישיים ולתחלת השורות שמהם רוצים לקרוא בהתחלה
       // public static int rCnt = 2;
        public static int cCnt = 0;
        //List<Asapim>
        public static void ReadExcel()
        {
            string excelUrl = ConfigurationManager.AppSettings["ExcelFilePath"];
            string fieldsRight = ConfigurationManager.AppSettings["FieldsRight"];
            string fieldsLeft = ConfigurationManager.AppSettings["FieldsLeft"];
            // לתחלת השורות  שרוצים לקרוא מהטבלה
            int rCnt = IndexOfExcelDAL.readOfExcel();

            Array arrFieldsRight = fieldsRight.Split(',');
            Array arrFieldsLeft = fieldsLeft.Split(',');

            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;

            int rw = 0;
            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(@excelUrl, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            range = xlWorkSheet.UsedRange;
            rw = range.Rows.Count;
            List<Asapim> list = new List<Asapim>();
            for (; rCnt <= rw; rCnt++)
            {
                int cCnt = int.Parse(ConfigurationManager.AppSettings["IndexOfStartAsapim"]);
                Asapim a = new Asapim();
                //פרטים אישי-ים
                a.Name = ((range.Cells[rCnt, 1] as Excel.Range).Value2 != null) ? (range.Cells[rCnt, 1] as Excel.Range).Value2 : "";
                a.Tz = ((range.Cells[rCnt, 2] as Excel.Range).Value2 != null) ? (int)(range.Cells[rCnt, 2] as Excel.Range).Value2 : 0;
                //תאריך הפניה- הבדיקה
                double dateRequest = (range.Cells[rCnt, 3] as Excel.Range).Value2 != null ? (range.Cells[rCnt, 5] as Excel.Range).Value2 : System.DateTime.Today;
                a.DateRequest = DateTime.FromOADate(dateRequest);
                a.SnifName = ((range.Cells[rCnt, 4] as Excel.Range).Value2 != null) ? (string)(range.Cells[rCnt, 4] as Excel.Range).Value2 : "";
                //תאריך לידה
                double dateOfBirth = (range.Cells[rCnt, 5] as Excel.Range).Value2 != null ? (range.Cells[rCnt, 3] as Excel.Range).Value2 : System.DateTime.Today;
                a.Date_of_birth = DateTime.FromOADate(dateOfBirth);
                
                //אוזן ימין
                for (int i = 0; i < arrFieldsRight.Length; i++)
                {
                    double result = ((range.Cells[rCnt, cCnt] as Excel.Range).Value2 != null) ? (range.Cells[rCnt, cCnt] as Excel.Range).Value2 : 0;
                    a.Right.Add(arrFieldsRight.GetValue(i).ToString(), result);
                    cCnt++;
                }
                //אוזן שמאל
                for (int i = 0; i < arrFieldsLeft.Length; i++)
                {
                    double result = ((range.Cells[rCnt, cCnt] as Excel.Range).Value2 != null) ? (range.Cells[rCnt, cCnt] as Excel.Range).Value2 : 0;
                    a.Left.Add(arrFieldsLeft.GetValue(i).ToString(), result);
                    cCnt++;
                }
                //נשמור ב-list רק את התלמידים שזכאיים
                bool isZakai = CalcZakautChinuch(a);
                if(isZakai==true)
                    list.Add(a);

            }
            //עדכון השורה שעד אליה קראנו בטבלה
            bool b= IndexOfExcelDAL.UpdateIndexOfExcel(rCnt); 

            xlWorkBook.Close(true, null, null);
            xlApp.Quit();
            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);
            //כעת יש לשלוח מי"ילים לכל הסניפים עם כל התלמידים הזכאים 
            BLL.EmailsBLL.sendEmailsToSnifim(list);
            //return list;
        }
       
        public static bool CalcZakautChinuch(Asapim a)
        {
            
            
            double IsZakutChinuch = 26;
            // אוזן ימין נמוך  
            double rLowSum = CalcAvgRightLowSum(a);
            //חישוב אוזן ימין גבוה 
            double rHightSum = CalcAvgRightHightSum(a);
            // אוזן שמאל נמוך  
            double lLowSum = CalcAvgLeftLowSum(a);
            //חישוב אוזן שמאל גבוה 
            double lHightSum = CalcAvgLeftHightSum(a);
            //האם זכאי?????????????????????????????????????        
            if (rLowSum >= IsZakutChinuch || rHightSum >= IsZakutChinuch || lLowSum >= IsZakutChinuch || lHightSum >= IsZakutChinuch)
            {
                //זכאי 
                //לאחר כל החישובים נבדוק
                //האם זכאי?????????????????????????????????????        
                //תעדכן ב- data base
                PatientsDTO newPatient = new PatientsDTO();
                //צריך לחלק את השם מה
                //-excel
                //לשם פרטי ושם משפחה
                newPatient.First_name = a.Name;
                newPatient.Tz = a.Tz;
                newPatient.date_of_birth = a.Date_of_birth;
                
                RequestsDTO newRequst = new RequestsDTO();
                newRequst.Date = a.DateRequest;
                newRequst.Patient_tz = a.Tz;
                newRequst.StatusId = 1;

                
                
                bool b = false, b1 = false;
                //אם קיים פצינט כזה רק תעדכן שינויים
                if(PatientDAL.GetPatientsByTz(newPatient.Tz)==null)
                    b = PatientDAL.AddPatient(newPatient);
                else
                    b = PatientDAL.UpdatePatient(newPatient);
                //אם קיימת פניה לפצינט זה ,רק תעדכן פניה
                if(RequestsDAL.GetRequestByTz(newRequst.Patient_tz)==null)
                    b1 = RequestsDAL.AddRequest(newRequst);
                else
                    b1 = RequestsDAL.UpdateRequest(newRequst);
                //אם כן צריך לשמור ב
                //list
                return true;
                //רק מי שזכאי
                

                

            }
            return false;
        }
        // אוזן ימין נמוך 
        public static double CalcAvgRightLowSum(Asapim a)
        {
            double rLowSum = 0;
            double countrLowSum = 0;
            //חישובים עבור אוזן ימין

            if (a.Right["R500"] != 0)
            {
                rLowSum += a.Right["R500"];
                countrLowSum++;
            }
            if (a.Right["R1000"] != 0)
            {
                rLowSum += a.Right["R1000"];
                countrLowSum++;
            }
            if (a.Right["R2000"] != 0)
            {
                rLowSum += a.Right["R2000"];
                countrLowSum++;
            }
            if (a.Right["R4000"] != 0)
            {
                rLowSum += a.Right["R4000"];
                countrLowSum++;
            }
            //אם אין מה שחיבים הבדיקה לא תקינה
            if (countrLowSum < 3)
                return 0;
            //ניתן להמשיך עם הביניים
            if (a.Right["R750"] != 0)
            {
                rLowSum += a.Right["R750"];
                countrLowSum++;
            }
            if (a.Right["R1500"] != 0)
            {
                rLowSum += a.Right["R1500"];
                countrLowSum++;
            }
            //חישוב ממוצע ימין נמוך
            return rLowSum = rLowSum / countrLowSum;
        }
        //אוזן ימין גבוה
        public static double CalcAvgRightHightSum(Asapim a)
        {
            double rHightSum = 0;
            double countrHightSum = 0;
            if (a.Right["R3000"] != 0)
            {
                rHightSum += a.Right["R3000"];
                countrHightSum++;
            }
            if (a.Right["R6000"] != 0)
            {
                rHightSum += a.Right["R6000"];
                countrHightSum++;
            }
            if (a.Right["R8000"] != 0)
            {
                rHightSum += a.Right["R8000"];
                countrHightSum++;
            }
            //אם אין מה שחיבים הבדיקה לא תקינה
            if (countrHightSum < 3)
                return 0;
            //חישוב ממוצע ימין גבוה 
            return rHightSum = rHightSum / countrHightSum;
        }
        // אוזן שמאל נמוך 
        public static double CalcAvgLeftLowSum(Asapim a)
        {
            double lLowSum = 0;
            double countlLowSum = 0;

            if (a.Left["L500"] != 0)
            {
                lLowSum += a.Left["L500"];
                countlLowSum++;
            }
            if (a.Left["L1000"] != 0)
            {
                lLowSum += a.Left["L1000"];
                countlLowSum++;
            }
            if (a.Left["L2000"] != 0)
            {
                lLowSum += a.Left["L2000"];
                countlLowSum++;
            }
            if (a.Left["L4000"] != 0)
            {
                lLowSum += a.Left["L4000"];
                countlLowSum++;
            }
            //אם אין מה שחיבים הבדיקה לא תקינה
            if (countlLowSum < 3)
                return 0;
            //ניתן להמשיך עם הביניים
            if (a.Left["L750"] != 0)
            {
                lLowSum += a.Left["L750"];
                countlLowSum++;
            }
            if (a.Left["L1500"] != 0)
            {
                lLowSum += a.Left["L1500"];
                countlLowSum++;
            }
            //חישוב ממוצע שמאל נמוך
            return lLowSum = lLowSum / countlLowSum;
        }
        //אוזן שמאל גבוה
        public static double CalcAvgLeftHightSum(Asapim a)
        {
            double lHightSum = 0;
            double countlHightSum = 0;
            if (a.Left["L3000"] != 0)
            {
                lHightSum += a.Left["L3000"];
                countlHightSum++;
            }
            if (a.Left["L6000"] != 0)
            {
                lHightSum += a.Left["L6000"];
                countlHightSum++;
            }
            if (a.Left["L8000"] != 0)
            {
                lHightSum += a.Left["L8000"];
                countlHightSum++;
            }
            //אם אין מה שחיבים הבדיקה לא תקינה
            if (countlHightSum < 3)
                return 0;
            //חישוב ממוצע שמאל גבוה 
            return lHightSum = lHightSum / countlHightSum;
        }

        //פונקציה הממחזירה list מהפרטים הנחוצים לשליחת מייל
        public static string ToString(List<Asapim> a)
        {
            string s="";
            for (int i = 0; i < a.Count(); i++)
            {
                s += a[i].Tz + "," + a[i].Name + "," + a[i].SnifName + "," + a[i].DateRequest;
                s += "\n";
            }
            return s;
        }


    }
}
//אוביקט שמשגיח על קובץ מסוים ובשינוי מפעיל פונקציה 
//FileSystemWatcher watcher = new FileSystemWatcher(@excelUrl);
////אוביקט המקשיב לארוע
//watcher.Changed += Watcher_Changed;

// פונקציה  הקשבה לארוע כרגע לא פועלת!!!!!!!!!!!!!!
//private static void Watcher_Changed(object sender, FileSystemEventArgs e)

