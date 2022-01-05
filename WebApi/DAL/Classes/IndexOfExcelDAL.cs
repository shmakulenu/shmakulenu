using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace DAL.Classes
{
    public class IndexOfExcelDAL
    {
        public static int readOfExcel()
        {
            using (ShemaKolenuEntities sk = new ShemaKolenuEntities())
            {
                return sk.IndexOfExcel.Select(i => i.Id).FirstOrDefault();
            }
        }
        public static bool UpdateIndexOfExcel(int row)
        {
            using (ShemaKolenuEntities sk = new ShemaKolenuEntities())
            {
                IndexOfExcel rowToEdit = sk.IndexOfExcel.FirstOrDefault();
                sk.IndexOfExcel.Remove(rowToEdit);
                sk.SaveChanges();
                IndexOfExcel newRow = new IndexOfExcel();
                newRow.Id = row;
                sk.IndexOfExcel.Add(newRow);
                try
                {
                    sk.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
    }
}
