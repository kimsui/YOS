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

namespace YOS.Pages.Inputs
{
	/// <summary>
	/// Interaction logic for About.xaml
	/// </summary>
	public partial class Insert: UserControl
	{
		public Insert()
		{
			InitializeComponent();
		}

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //전송DATA1 "User Id=scott;Password=tiger;Data Source=ORCL"
            string strConn = "User Id=scott;Password=tiger;Data Source=ORCL";

            //전송DATA2 "SELECT * FROM LECTURER2"
            OracleDataAdapter oraDA = new OracleDataAdapter("SELECT * FROM LECTURER2", strConn);
            DataTable dt = new DataTable();
            oraDA.Fill(dt);

            // dt 전송 부분
            // 아래 부분은 전송받은 dt로 데이터 그리드에 표시
            // dt 원복
            dataGrid.ItemsSource = dt.DefaultView;

            oraDA.Update(dt);
        }
    }
}
