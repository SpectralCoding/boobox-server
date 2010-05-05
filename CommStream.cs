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
	public static class CommStream {
		private static Socket listeningSock;
		private static int SocketCounter = 0;
		private static ArrayList clientStreamList = ArrayList.Synchronized(new ArrayList());
		private static AsyncCallback asyncWorkerCallBack;

		/// <summary>
		/// Starts the Server listening on Config.Instance.CommStreamPort.
		/// </summary>
		public static void StartListening() {
			listeningSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			listeningSock.Bind(new IPEndPoint(IPAddress.Any, Config.Instance.CommStreamPort));
			listeningSock.Listen(4);
			listeningSock.BeginAccept(new AsyncCallback(OnClientConnect), null);
			Log.AddStatusText("Stream server now listening on port " + Config.Instance.CommStreamPort.ToString() + ".");
		}

		/// <summary>
		/// Triggered when a Client attempts to Connect. Accepts the connection and begins waiting for Data
		/// </summary>
		/// <param name="asyn">Associated IAsyncResult object</param>
		private static void OnClientConnect(IAsyncResult asyn) {
			ClientStream tempClientStream = new ClientStream(listeningSock.EndAccept(asyn), SocketCounter);
			clientStreamList.Add(tempClientStream);
			WaitForData(tempClientStream);
			Interlocked.Increment(ref SocketCounter);
			Log.AddClientText("Info client has connected.", tempClientStream.Index);
			listeningSock.BeginAccept(new AsyncCallback(OnClientConnect), null);
		}

		private class SocketPacket {
			public Socket Socket;
			public byte[] DataBuffer = new byte[Config.Instance.DataBufferSize];
			public int ClientIndex;
			public ClientStream ClientStream;
			/// <summary>
			/// Constructor which starts a SocketPacket based on a Client object.
			/// </summary>
			/// <param name="iServer">Associated Client object</param>
			public SocketPacket(ClientStream iClientStream) {
				Socket = iClientStream.Socket;
				ClientIndex = iClientStream.Index;
				ClientStream = iClientStream;
			}
		}

		/// <summary>
		/// An always-active function that waits for the client to send data to the server. Eventually trigers OnDataReceived().
		/// </summary>
		/// <param name="waitClientStream">Associated ClientStream object</param>
		private static void WaitForData(ClientStream waitClientStream) {
			if (asyncWorkerCallBack == null) { asyncWorkerCallBack = new AsyncCallback(OnDataReceived); }
			SocketPacket tempSocketPacket = new SocketPacket(waitClientStream);
			waitClientStream.Socket.BeginReceive(
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
				if (receiveLen == 0) { CloseClientStreamConnection(SocketPacket.ClientIndex); } else {
					char[] receiveCharsOld = new char[receiveLen];
					int charLength = Encoding.UTF8.GetChars(SocketPacket.DataBuffer, 0, receiveLen, receiveCharsOld, 0);
					char[] receiveChars = new char[charLength];
					Array.Copy(receiveCharsOld, receiveChars, charLength);
					String receiveData = new String(receiveChars);
					SocketPacket.ClientStream.DataBuffer += receiveData;
					// See if multiple messages were sent in the same packet, if so call OnReceiveData for all of them.
					if (Functions.OccurancesInString(SocketPacket.ClientStream.DataBuffer, "\x4") >= 1) {
						String[] splitIncommingData = SocketPacket.ClientStream.DataBuffer.Split(("\x4").ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
						for (int i = 0; i < splitIncommingData.Length; i++) {
							SocketPacket.ClientStream.DataBuffer = SocketPacket.ClientStream.DataBuffer.Remove(0, splitIncommingData[i].Length + 1);
							ClientStreamIndexToClientInfo(SocketPacket.ClientIndex).OnReceiveData(splitIncommingData[i]);
						}
					}
					if (SocketPacket.ClientStream.Socket.Connected == true) {
						WaitForData(ClientStreamIndexToClientInfo(SocketPacket.ClientIndex));
					}
				}
			} catch (ObjectDisposedException) {
				CloseClientStreamConnection(SocketPacket.ClientIndex);
			} catch (NullReferenceException) {
				CloseClientStreamConnection(SocketPacket.ClientIndex);
			} catch (SocketException Se) {
				if (Se.ErrorCode == 10054) {
					CloseClientStreamConnection(SocketPacket.ClientIndex);
				}
			}
		}

		/// <summary>
		/// Closes a server connection based on the Client Index.
		/// </summary>
		/// <param name="iClientIndex">Client Index to Close</param>
		private static void CloseClientStreamConnection(int iClientIndex) {
			ClientStream tempClientStream = ClientStreamIndexToClientInfo(iClientIndex);
			clientStreamList.Remove(tempClientStream);
			Log.AddClientText("Stream client has disconnected.", tempClientStream.Index);
		}

		/// <summary>
		/// Returns a Client object associated with a specific Client Index
		/// </summary>
		/// <param name="iClientStreamIndex">The Client Index being searched for.</param>
		/// <returns>Client Object</returns>
		private static ClientStream ClientStreamIndexToClientInfo(int iClientStreamIndex) {
			for (int i = 0; i < clientStreamList.Count; i++) {
				if (((ClientStream)clientStreamList[i]).Index == iClientStreamIndex) {
					return (ClientStream)clientStreamList[i];
				}
			}
			return null;
		}


	}
}
