using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDETScriptingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory.ToString();
            string datafileloc = Path.GetFullPath(Path.Combine(path, @"..\..\"));
            Writeoutput(comparedt(CsvtoDataTable(string.Format("{0}{1}", datafileloc, "DataFiles\\"), "Analysis-V1.csv", "Yes"),
                CsvtoDataTable(string.Format("{0}{1}", datafileloc, "DataFiles\\"), "Analysis-V2.csv", "Yes")), string.Format("{0}{1}", datafileloc, "Output\\"));
        }

        /// <summary>
        /// Read CSV file into Data Tabel using Oledb Connection
        /// </summary>
        /// <param name="filePath">Path of the data file</param>
        /// <param name="fileName">name of the data file</param>
        /// <param name="columnHeadExist">CSV contains header column - Yes or No</param>
        /// <returns></returns>
        public static DataTable CsvtoDataTable(string filePath, string fileName, string columnHeadExist)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"select * from [" + fileName + "]";
                OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties=\"Text;HDR=" + columnHeadExist + "\"");
                OleDbCommand cmd = new OleDbCommand(query, con);
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                dt.Locale = CultureInfo.CurrentCulture;
                adapter.Fill(dt);
                adapter.Dispose();
                cmd.Dispose();
                con.Dispose();
                return dt;
            } catch(Exception e)
            {
                Console.Write(e.ToString());
                return null;
            }
           
        }

        /// <summary>
        /// Compare two datatables and store output into a datatable
        /// </summary>
        /// <param name="dataTable1"></param>
        /// <param name="dataTable2"></param>
        /// <returns></returns>
        public static DataTable comparedt(DataTable dataTable1, DataTable dataTable2)
        {
            var differences =
                dataTable2.AsEnumerable().Except(dataTable1.AsEnumerable(),
                                                        DataRowComparer.Default);
            return differences.Any() ? differences.CopyToDataTable() : new DataTable();
        }

        /// <summary>
        /// Write Output data table into a csv file
        /// </summary>
        /// <param name="Output">Output table</param>
        public static void Writeoutput(DataTable output, string filelocation)
        {
            StringBuilder sb = new StringBuilder();

            IEnumerable<string> columnNames = output.Columns.Cast<DataColumn>().
                                              Select(column => column.ColumnName);
            sb.AppendLine(string.Join(",", columnNames));

            foreach (DataRow row in output.Rows)
            {
                IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                sb.AppendLine(string.Join(",", fields));
            }

            File.WriteAllText(filelocation+"test"+System.DateTime.Now.ToShortTimeString().Replace(':', '-')+".csv", sb.ToString());
        }
    }
}
