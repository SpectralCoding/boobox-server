using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using BooBox;

namespace BooBoxServer {
	public class ClientInfo {
		public Socket Socket;
		public int Index;
		public String Name;
		public String Version;
		public ConnectionStatus ConnectionStatus;
		public String DataBuffer;

		/// <summary>
		/// Public constructor for createing a Client object
		/// </summary>
		/// <param name="iSocket">Socket associated with the Client object</param>
		/// <param name="iClientInfoIndex">Index number of the associated Client object</param>
		public ClientInfo(Socket iSocket, int iClientInfoIndex) {
			Socket = iSocket;
			Index = iClientInfoIndex;
			ConnectionStatus = ConnectionStatus.Pending;
			OnClientConnect();
		}

		/// <summary>
		/// Triggered when the Client and Server have achieved a full TCP connection
		/// </summary>
		private void OnClientConnect() {

		}

		/// <summary>
		/// Sends data to associated Client
		/// </summary>
		/// <param name="Data">String containing the data to be sent to the client</param>
		public void Send(String Data) {
			if (Data.Length > 150) {
				Console.WriteLine("To ClientInfo " + Index + ":\t" + Data.Substring(0, 150) + "...");
			} else {
				Console.WriteLine("To ClientInfo " + Index + ":\t" + Data);
			}
			byte[] byteData = Encoding.UTF8.GetBytes(Data + "\x4");
			Socket.Send(byteData);
		}

		/// <summary>
		/// Triggered when data is recieved from the Client
		/// </summary>
		/// <param name="Data">Contains data sent from the Client</param>
		public void OnReceiveData(String Data) {
			DataBuffer = "";
			if (Data.Length > 1000) {
				Console.WriteLine("From ClientInfo " + Index + ":\t" + Data.Substring(0, 1000) + "...");
			} else {
				Console.WriteLine("From ClientInfo " + Index + ":\t" + Data);
			}
			//Protocol.ParseMessage(Data, this);
		}


	}
}
