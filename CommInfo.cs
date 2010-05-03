using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using BooBox;

namespace BooBoxServer {
	public static class CommInfo {
		private static Socket listeningSock;
		private static int SocketCounter = 0;
		private static ArrayList clientInfoList = ArrayList.Synchronized(new ArrayList());
		private static AsyncCallback asyncWorkerCallBack;

		/// <summary>
		/// Starts the Server listening on Comm.ListeningPort.
		/// </summary>
		public static void StartListening() {
			listeningSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			listeningSock.Bind(new IPEndPoint(IPAddress.Any, Config.Instance.CommInfoPort));
			listeningSock.Listen(4);
			listeningSock.BeginAccept(new AsyncCallback(OnClientConnect), null);
			Log.AddStatusText("Info server now listening on port " + Config.Instance.CommInfoPort.ToString() + ".");
		}

		/// <summary>
		/// Triggered when a Client attempts to Connects. Accepts the connection and begins waiting for Data
		/// </summary>
		/// <param name="asyn">Associated IAsyncResult object</param>
		private static void OnClientConnect(IAsyncResult asyn) {
			ClientInfo tempClientInfo = new ClientInfo(listeningSock.EndAccept(asyn), SocketCounter);
			clientInfoList.Add(tempClientInfo);
			WaitForData(tempClientInfo);
			Interlocked.Increment(ref SocketCounter);
			Log.AddClientText("Info client has connected.", tempClientInfo.Index);
			listeningSock.BeginAccept(new AsyncCallback(OnClientConnect), null);
		}

		private class SocketPacket {
			public Socket Socket;
			public byte[] DataBuffer = new byte[Config.Instance.DataBufferSize];
			public int ClientIndex;
			public ClientInfo ClientInfo;
			/// <summary>
			/// Constructor which starts a SocketPacket based on a ClientInfo object.
			/// </summary>
			/// <param name="iServer">Associated ClientInfo object</param>
			public SocketPacket(ClientInfo iClientInfo) {
				Socket = iClientInfo.Socket;
				ClientIndex = iClientInfo.Index;
				ClientInfo = iClientInfo;
			}
		}

		/// <summary>
		/// An always-active function that waits for the client to send data to the server. Eventually trigers OnDataReceived().
		/// </summary>
		/// <param name="waitClientInfo">Associated ClientInfo object</param>
		private static void WaitForData(ClientInfo waitClientInfo) {
			if (asyncWorkerCallBack == null) { asyncWorkerCallBack = new AsyncCallback(OnDataReceived); }
			SocketPacket tempSocketPacket = new SocketPacket(waitClientInfo);
			waitClientInfo.Socket.BeginReceive(
				tempSocketPacket.DataBuffer,
				0,
				tempSocketPacket.DataBuffer.Length,
				SocketFlags.None,
				asyncWorkerCallBack,
				tempSocketPacket
			);
		}

		/// <summary>
		/// Triggered when data is received from the Client. Takes care of closing dead Sockets and
		/// passing data to Client.OnRecieveData().
		/// </summary>
		/// <param name="asyn">Required associated IAsyncResult</param>
		private static void OnDataReceived(IAsyncResult asyn) {
			SocketPacket SocketPacket = (SocketPacket)asyn.AsyncState;
			try {
				int receiveLen = 0;
				receiveLen = SocketPacket.Socket.EndReceive(asyn);
				if (receiveLen == 0) { CloseClientInfoConnection(SocketPacket.ClientIndex); } else {
					char[] receiveCharsOld = new char[receiveLen];
					int charLength = Encoding.UTF8.GetChars(SocketPacket.DataBuffer, 0, receiveLen, receiveCharsOld, 0);
					char[] receiveChars = new char[charLength];
					Array.Copy(receiveCharsOld, receiveChars, charLength);
					String receiveData = new String(receiveChars);
					SocketPacket.ClientInfo.DataBuffer += receiveData;
					// See if multiple messages were sent in the same packet, if so call OnReceiveData for all of them.
					if (Functions.OccurancesInString(SocketPacket.ClientInfo.DataBuffer, "\x4") >= 1) {
						String[] splitIncommingData = SocketPacket.ClientInfo.DataBuffer.Split(("\x4").ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
						for (int i = 0; i < splitIncommingData.Length; i++) {
							SocketPacket.ClientInfo.DataBuffer = SocketPacket.ClientInfo.DataBuffer.Remove(0, splitIncommingData[i].Length + 1);
							ClientInfoIndexToClientInfo(SocketPacket.ClientIndex).OnReceiveData(splitIncommingData[i]);
						}
					}
					if (SocketPacket.ClientInfo.Socket.Connected == true) {
						WaitForData(ClientInfoIndexToClientInfo(SocketPacket.ClientIndex));
					}
				}
			} catch (ObjectDisposedException) {
				CloseClientInfoConnection(SocketPacket.ClientIndex);
			} catch (NullReferenceException) {
				CloseClientInfoConnection(SocketPacket.ClientIndex);
			} catch (SocketException Se) {
				if (Se.ErrorCode == 10054) {
					CloseClientInfoConnection(SocketPacket.ClientIndex);
				}
			}
		}

		/// <summary>
		/// Closes a server connection based on the Client Index.
		/// </summary>
		/// <param name="iClientIndex">Client Index to Close</param>
		private static void CloseClientInfoConnection(int iClientIndex) {
			ClientInfo tempClientInfo = ClientInfoIndexToClientInfo(iClientIndex);
			clientInfoList.Remove(tempClientInfo);
			Log.AddClientText("Info client has disconnected.", tempClientInfo.Index);
		}

		/// <summary>
		/// Returns a Client object associated with a specific Client Index
		/// </summary>
		/// <param name="iClientInfoIndex">The Client Index being searched for.</param>
		/// <returns>Client Object</returns>
		private static ClientInfo ClientInfoIndexToClientInfo(int iClientInfoIndex) {
			for (int i = 0; i < clientInfoList.Count; i++) {
				if (((ClientInfo)clientInfoList[i]).Index == iClientInfoIndex) {
					return (ClientInfo)clientInfoList[i];
				}
			}
			return null;
		}


	}
}
