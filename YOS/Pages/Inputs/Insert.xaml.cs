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
using System.Windows.Threading;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data;
using System.IO;
using FreeNet;

namespace YOS.Pages.Inputs
{
    /// <summary>
    /// Interaction logic for About.xaml
    /// </summary>

    //delegate void BatCallback(BallEventArgs e);
    //EventHandler ballInplay = BallInPlay;
    //delegate void MyDelegate();
    //public delegate void MyEventHandler(string message);

    //이벤트 발행부분


    //public delegate void MyEventHandler(string message);

    //class Publisher
    //{
    //    public event MyEventHandler Active;
    //    public void DoActive(int number)
    //    {
    //        if (number % 10 == 0)
    //            Active("Active" + number);
    //        else
    //            MessageBox.Show(number.ToString());
    //    }
    //}

    class Event
    {
        public delegate void myDelegate(DataTable dt);
        public myDelegate mydt;
        public void register(myDelegate de)
        {
            mydt = de;
        }
        public DataTable dt = new DataTable();
    }


    public partial class Insert: UserControl
	{
        static DataTable dt= new DataTable();
        static DataTable dt2 = new DataTable();



        public Insert()
		{
			InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            //Publisher publisher = new Publisher();

            //publisher.Active += new MyEventHandler(CAccessDB.MyHandler);

            //if(publisher!= null)
            //{
            //    publisher.DoActive(1) ;
            //}
            CSampleClient.Program.SrvrConn();
            CSampleClient.Program.SendMessage("SELECT * FROM LECTURER2");


            #region DB접속 및 DT 호출 하여 화면에 출력(WriteXml/ReadXml 테스트-성공)
            //string strConn = "User Id=scott;Password=tiger;Data Source=ORCL"; --> 서버쪽에서 디비랑 접근

            //OracleDataAdapter oraDA = new OracleDataAdapter("SELECT * FROM LECTURER2", strConn);
            ////DataTable dt = new DataTable();
            //oraDA.Fill(dt);

            //ds = new DataSet("XMLTABLE");

            //CloneDT = dt.Copy();
            //CloneDT.TableName = "XMLTABLE";
            //ds.Tables.Add(CloneDT);

            //sb = new StringBuilder();
            //stream = new StringWriter(sb);
            //ds.WriteXml(stream, XmlWriteMode.WriteSchema);

            ////dt.WriteXmlSchema(stream);
            //ds2 = new DataSet();

            //string xmlData = stream.ToString();

            //System.IO.StringReader xmlSR = new System.IO.StringReader(xmlData);

            ////dataSet.ReadXml(xmlSR, XmlReadMode.IgnoreSchema);


            //ds2.ReadXml(xmlSR, XmlReadMode.ReadSchema);
            //dt2 = ds2.Tables["XMLTABLE"];

            //dataGrid.ItemsSource = dt2.DefaultView;

            //oraDA.Update(dt); 
            #endregion

            #region  세션 연결 후 이벤트 전송(CMD - 1)
            //dataGrid.ItemsSource = dt2.DefaultView;

            // 1test


            #endregion

            #region 메인에서 수신한 후 이쪽으로 분기 후 실행코드(CMD - 1)
            #endregion
            //if()

            //this.Dispatcher.Invoke(DispatcherPriority.Normal, new CSampleClient.DelegateGetDataTable());

            //CSampleClient.DelegateGetDataTable test = new CSampleClient.DelegateGetDataTable();
            //
            ///이벤트가 들어올때까지 waiting
            ///이벤트가 들어오면 아래 실행

            {
                #region 화면 출력
                //dataGrid.ItemsSource = dt2.DefaultView;


                // dataGrid.ItemsSource = dt.DefaultView;
                #endregion
            }

            //이벤트가 안들어 오면
            //else 실행
            //{

            //}
            //dataGrid.ItemsSource = dt.DefaultView;



            /// string 데이터를 ReadXml 메쏘드를 사용하여 xml다시 생성
            /// xml 을 다시 dt 로 변환
            /// WPF 화면에 출력
            ///





        }



        //private void UserControl_Initialized(object sender, EventArgs e)
        //{
        //    #region DB접속 및 DT 호출 하여 화면에 출력(WriteXml/ReadXml 테스트-성공)
        //    //string strConn = "User Id=scott;Password=tiger;Data Source=ORCL"; --> 서버쪽에서 디비랑 접근

        //    //OracleDataAdapter oraDA = new OracleDataAdapter("SELECT * FROM LECTURER2", strConn);
        //    ////DataTable dt = new DataTable();
        //    //oraDA.Fill(dt);

        //    //ds = new DataSet("XMLTABLE");

        //    //CloneDT = dt.Copy();
        //    //CloneDT.TableName = "XMLTABLE";
        //    //ds.Tables.Add(CloneDT);

        //    //sb = new StringBuilder();
        //    //stream = new StringWriter(sb);
        //    //ds.WriteXml(stream, XmlWriteMode.WriteSchema);

        //    ////dt.WriteXmlSchema(stream);
        //    //ds2 = new DataSet();

        //    //string xmlData = stream.ToString();

        //    //System.IO.StringReader xmlSR = new System.IO.StringReader(xmlData);

        //    ////dataSet.ReadXml(xmlSR, XmlReadMode.IgnoreSchema);


        //    //ds2.ReadXml(xmlSR, XmlReadMode.ReadSchema);
        //    //dt2 = ds2.Tables["XMLTABLE"];

        //    //dataGrid.ItemsSource = dt2.DefaultView;

        //    //oraDA.Update(dt); 
        //    #endregion

        //    #region  세션 연결 후 이벤트 전송(CMD - 1)
        //    //dataGrid.ItemsSource = dt2.DefaultView;
        //    CSampleClient.Program.SrvrConn();
        //    CSampleClient.Program.SendMessage("SELECT * FROM LECTURER2"); // 1test


        //    #endregion

        //    #region 메인에서 수신한 후 이쪽으로 분기 후 실행코드(CMD - 1)
        //    //if()

        //    //this.Dispatcher.Invoke(DispatcherPriority.Normal, new CSampleClient.DelegateGetDataTable());

        //    //CSampleClient.DelegateGetDataTable test = new CSampleClient.DelegateGetDataTable();
        //    //
        //    ///이벤트가 들어올때까지 waiting
        //    ///이벤트가 들어오면 아래 실행
        //    #endregion

        //    {
        //        #region 화면 출력
        //        //dataGrid.ItemsSource = dt2.DefaultView;
        //        Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal,
        //                      new Action(() => dt = CAccessDB.getdt()));
        //        //dt = CAccessDB.getdt();
        //        Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal,
        //           new Action(() => dataGrid.ItemsSource = dt.DefaultView));
        //        // dataGrid.ItemsSource = dt.DefaultView;
        //        #endregion
        //    }
        //}
    }



    //class Bat
    //{
        
    //    private BatCallback hitBallCallBack;
    //    public Bat(BatCallback callbackDelegate)
    //    {
    //        this.hitBallCallBack = new BatCallback(callbackDelegate);
    //    }
    //    public void HitTheBall(BallEventArgs e)
    //    {
    //        if (hitBallCallBack != null)
    //            hitBallCallBack(e);
    //    }

    //    public Bat GetNewBat()
    //    {
            
    //        return new Bat(new BatCallback(OnBallInPlay));
    //    }
    //}
}
