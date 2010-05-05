using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using BooBox;

namespace BooBoxServer {
	class ClientStream {
		public Socket Socket;
		public int Index;
		public ConnectionStatus ConnectionStatus;
		public String DataBuffer;

		/// <summary>
		/// Public constructor for createing a Client object
		/// </summary>
		/// <param name="iSocket">Socket associated with the Client object</param>
		/// <param name="iClientStreamIndex">Index number of the associated Client object</param>
		public ClientStream(Socket iSocket, int iClientStreamIndex) {
			Socket = iSocket;
			Index = iClientStreamIndex;
			ConnectionStatus = ConnectionStatus.Pending;
			OnClientConnect();
		}

		/// <summary>
		/// Triggered when the Client and Server have achieved a full TCP connection
		/// </summary>
		private void OnClientConnect() {

		}

		/// <summary>
		/// Sends raw byte[] data to a Client.
		/// </summary>
		/// <param name="Data">byte[] array containing the data to be sent.</param>
		public void Send(byte[] Data) {
			Socket.Send(Data);
		}

		/// <summary>
		/// Triggered when data is recieved from the Client
		/// </summary>
		/// <param name="Data">Contains data sent from the Client</param>
		public void OnReceiveData(String Data) {
			DataBuffer = "";
			if (Data.Length > 1000) {
				Console.WriteLine("From ClientStream " + Index + ":" + Data.Substring(0, 1000) + "...");
			} else {
				Console.WriteLine("From ClientStream " + Index + ":" + Data);
			}
			ParseMessage(Data);
		}

		public void ParseMessage(String Data) {
			char[] spaceDelim = new char[] { ' ' };
			String[] tokenData = Data.Split(spaceDelim, 2);
			switch (tokenData[0]) {
				case "STREAMSONG":
					Console.WriteLine(tokenData[1]);
					if (StreamManager.KeyIsValid(tokenData[1])) {
						SongInfo tempSI = StreamManager.GetAndRemoveKey(tokenData[1]);
						FileStream mp3FS = new FileStream(tempSI.FileName, FileMode.Open, FileAccess.Read);
						byte[] readBytes = new byte[mp3FS.Length];
						mp3FS.Read(readBytes, 0, Convert.ToInt32(mp3FS.Length));
						Send(readBytes);
					}
					Socket.Close();
					break;
			}
		}

	}
}
