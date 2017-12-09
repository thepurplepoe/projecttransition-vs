using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTransition.src
{

    public class Transition
    {
        public DataGetter dataGetter;

        public DataTable TableA;
        public DataTable TableB;

        public Transition()
        {
            dataGetter = new DataGetter();
        }

        public void readTables(String fileNameA, String fileNameB, String fileNameOutput)
        {
            TableA = dataGetter.readTable(fileNameA);
            TableB = dataGetter.readTable(fileNameB);

            DataColumn NSNA = null;
            DataColumn NSNB = null;
            DataColumn Intended1 = null;
            DataColumn Intended2 = null;

            foreach (DataColumn column in TableA.Columns)
            {
                if (column.ColumnName == "NSN")
                {
                    NSNA = column;
                }
                if (column.ColumnName == "Intended1")
                {
                    Intended1 = column;
                }
                if (column.ColumnName == "Intended2")
                {
                    Intended2 = column;
                }
            }

            foreach (DataColumn column in TableB.Columns)
            {
                if (column.ColumnName == "NSN")
                {
                    NSNB = column;
                }
            }

            DataTable output = new DataTable();

            List<Tuple<String, int>> outputs = new List<Tuple<String, int>>();

            for (int i = 0; i < TableA.Rows.Count; i++)
            {
                if (TableA.Rows[i][Intended1].ToString() == "ACOL" || TableA.Rows[i][Intended2].ToString() == "ACOL")
                {
                    bool hasFound = false;
                    for (int j = 0; j < TableB.Rows.Count; j++)
                    {
                        if (TableA.Rows[i][NSNA].ToString() == TableB.Rows[j][NSNB].ToString())
                        {
                            hasFound = true;
                        }
                    }
                    if (!hasFound)
                    {
                        outputs.Add(new Tuple<String, int>(TableA.Rows[i][NSNA].ToString(), i));
                    }
                }
            }

            String csvout = "School,NSN,Last Name,FIrst Name,Legal Last Name,Legal First Name,Intended1,Intended2,Status";

            foreach (Tuple<String, int> t in outputs)
            {
                csvout += "\r\n";
                for (int i = 0; i < TableA.Columns.Count; i++)
                {
                    csvout += TableA.Rows[t.Item2][i].ToString() + ",";
                }
                csvout.Remove(csvout.Length - 1);
            }

            StreamWriter sw = File.AppendText(fileNameOutput);
            sw.Write("\r\n" + csvout);
            sw.Close();

            //return outputs;
        }

    }


}
