using Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTransition.src
{
    public class DataGetter
    {
        public DataGetter()
        {

        }

        public DataTable readTable(String fileName)
        {
            FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read);

            //1. Reading from a binary Excel file ('97-2003 format; *.xls)
            //IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
            //...
            //2. Reading from a OpenXml Excel file (2007 format; *.xlsx)
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            //...
            //3. DataSet - The result of each spreadsheet will be created in the result.Tables
            //DataSet result = excelReader.AsDataSet();
            //...
            //4. DataSet - Create column names from first row
            excelReader.IsFirstRowAsColumnNames = true;
            DataSet result = excelReader.AsDataSet();

            //5. Data Reader methods
            while (excelReader.Read())
            {
                //excelReader.GetInt32(0);
            }

            //6. Free resources (IExcelDataReader is IDisposable)
            excelReader.Close();

            //String NSNlist = "";

            /*
            foreach (DataTable table in result.Tables)
            {
               foreach (DataColumn column in table.Columns)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        if (column.ColumnName == columnName && row[column] != null)
                        {
                            NSNlist += row[column].ToString() + ",";
                        }
                    }
                }
            }
            */

            return result.Tables[0];
                //return NSNlist;
            }
    }
}
