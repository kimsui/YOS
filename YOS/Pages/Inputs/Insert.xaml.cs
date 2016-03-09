using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data;
using System.IO;

namespace YOS.Pages.Inputs
{
	/// <summary>
	/// Interaction logic for About.xaml
	/// </summary>
	public partial class Insert: UserControl
	{
        static DataTable dt= new DataTable();
        static DataTable dt2 = new DataTable();
        static DataSet ds;
        static DataSet ds2;
        static DataTable CloneDT;
        static StringBuilder sb;
        static StringWriter stream;

        public Insert()
		{
			InitializeComponent();
		}

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            string strConn = "User Id=scott;Password=tiger;Data Source=ORCL";

            OracleDataAdapter oraDA = new OracleDataAdapter("SELECT * FROM LECTURER2", strConn);
            //DataTable dt = new DataTable();
            oraDA.Fill(dt);

            ds = new DataSet("XMLTABLE");

            CloneDT = dt.Copy();
            CloneDT.TableName = "XMLTABLE";
            ds.Tables.Add(CloneDT);

            sb = new StringBuilder();
            stream = new StringWriter(sb);
            ds.WriteXml(stream, XmlWriteMode.WriteSchema);

            //dt.WriteXmlSchema(stream);
            ds2 = new DataSet();

            string xmlData = stream.ToString();

            System.IO.StringReader xmlSR = new System.IO.StringReader(xmlData);

            //dataSet.ReadXml(xmlSR, XmlReadMode.IgnoreSchema);


            ds2.ReadXml(xmlSR, XmlReadMode.ReadSchema);
            dt2 = ds2.Tables["XMLTABLE"];

            dataGrid.ItemsSource = dt2.DefaultView;
            
            oraDA.Update(dt);
        }
    }
}
