﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using FreeNet;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace CSampleClient
{
    using GameServer;
    using System.Windows.Controls;
    class Program
	{
		static List<IPeer> game_servers = new List<IPeer>();

        static public UserControl uc_;

		static public void SrvrConn()
		{
			CPacketBufferManager.initialize(2000);
			// CNetworkService객체는 메시지의 비동기 송,수신 처리를 수행한다.
			// 메시지 송,수신은 서버, 클라이언트 모두 동일한 로직으로 처리될 수 있으므로
			// CNetworkService객체를 생성하여 Connector객체에 넘겨준다.
			CNetworkService service = new CNetworkService();

			// endpoint정보를 갖고있는 Connector생성. 만들어둔 NetworkService객체를 넣어준다.
			CConnector connector = new CConnector(service);
			// 접속 성공시 호출될 콜백 매소드 지정.
			connector.connected_callback += on_connected_gameserver;
			IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse("192.168.0.188"), 7979);
			connector.connect(endpoint);
			System.Threading.Thread.Sleep(10);

        }

        static public void SendMessage(string message)
        {
            CPacket msg = CPacket.create((short)PROTOCOL.CHAT_MSG_REQ);
            msg.push(message);
            game_servers[0].send(msg);
        

        //((CRemoteServerPeer)game_servers[0]).token.disconnect();

        //System.Threading.Thread.Sleep(1000 * 20);
        //Console.ReadKey();
        }

        static public void SendMessage2(string dtmessage)
        {
            CPacket msg = CPacket.create((short)PROTOCOL.CHAT_MSG_UPDATE);
            msg.push(dtmessage);
            game_servers[0].send(msg);
        }
        /// <summary>
        /// 접속 성공시 호출될 콜백 매소드.
        /// </summary>
        /// <param name="server_token"></param>
        static void on_connected_gameserver(CUserToken server_token)
		{
			lock (game_servers)
			{
				IPeer server = new CRemoteServerPeer(server_token, uc_);
				game_servers.Add(server);
				//Console.WriteLine("Connected!");
			}
		}

        static public void SetUserControl(UserControl uc)
        {
            uc_ = uc;
        }
	}
}
