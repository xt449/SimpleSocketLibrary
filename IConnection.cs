﻿using System;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSocketLibrary
{
    public interface IConnection
    {
        public event EventHandler StatusConnected;
        public event EventHandler StatusDisconnected;
        public event EventHandler<byte[]> DataReceivedAsBytes;
        public event EventHandler<string> DataReceivedAsString;

        public bool Connected { get; }

        public Encoding Encoding { get; }

        /// <summary>
        /// This can run forever if the endpoint is not online.<br/>
        /// Use <see cref="StatusConnected"/> to determine when the connection is made.
        /// </summary>
        public void ConnectAsync();

        public void Disconnect();

        public ValueTask SendBytesAsync(Memory<byte> buffer);

        public ValueTask SendStringAsync(string text);
    }
}
