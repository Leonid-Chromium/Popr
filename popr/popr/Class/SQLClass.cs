using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace popr.Class
{
    class SQLClass
    {
        public static void DTtoTrace(DataTable dataTable)
        {
            Trace.WriteLine("x = " + dataTable.Rows.Count);
            Trace.WriteLine("y = " + dataTable.Columns.Count);

            for(int i = 0; i < dataTable.Rows.Count; i++)
            {
                Trace.Write("|");
                for(int j = 0; j< dataTable.Columns.Count; j++)
                {
                    Trace.Write(String.Format("{0,3}", dataTable.Rows[i].ItemArray[j].ToString()));
                    Trace.Write("|");
                }
                Trace.WriteLine("");
            }
        }

        public static DataTable returnDT(string query)
        {
            DataTable dataTable = new DataTable();

            try
            {
                Trace.WriteLine("connection string = " + Properties.Settings.Default.ConString);
                Trace.WriteLine("Query = " + query);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, Properties.Settings.Default.ConString);
                sqlDataAdapter.Fill(dataTable);

                DTtoTrace(dataTable);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dataTable;
        }
    }
}
