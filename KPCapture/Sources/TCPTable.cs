using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;

namespace KPU.Sources
{
    public enum PacketAction
    {
        Send,
        Receive,
        Unknown,
    }

    public enum MIB_TCP_STATE
    {
        MIB_TCP_STATE_CLOSED,
        MIB_TCP_STATE_LISTEN,
        MIB_TCP_STATE_SYN_SENT,
        MIB_TCP_STATE_SYN_RCVD,
        MIB_TCP_STATE_ESTAB,
        MIB_TCP_STATE_FIN_WAIT1,
        MIB_TCP_STATE_FIN_WAIT2,
        MIB_TCP_STATE_CLOSE_WAIT,
        MIB_TCP_STATE_CLOSING,
        MIB_TCP_STATE_LAST_ACK,
        MIB_TCP_STATE_TIME_WAIT,
        MIB_TCP_STATE_DELETE_TCB
    }

    public enum TCP_TABLE_CLASS
    {
        TCP_TABLE_BASIC_LISTENER,
        TCP_TABLE_BASIC_CONNECTIONS,
        TCP_TABLE_BASIC_ALL,
        TCP_TABLE_OWNER_PID_LISTENER,
        TCP_TABLE_OWNER_PID_CONNECTIONS,
        TCP_TABLE_OWNER_PID_ALL,
        TCP_TABLE_OWNER_MODULE_LISTENER,
        TCP_TABLE_OWNER_MODULE_CONNECTIONS,
        TCP_TABLE_OWNER_MODULE_ALL
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MIB_TCPROW_OWNER_PID
    {
        public uint state;
        public uint localAddr;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] localPort;
        public uint remoteAddr;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] remotePort;
        public uint owningPid;

        public uint ProcessId
        {
            get { return owningPid; }
        }

        public IPAddress LocalAddress
        {
            get { return new IPAddress(localAddr); }
        }

        public ushort LocalPort
        {
            get
            {
                return BitConverter.ToUInt16(new byte[2] { localPort[1], localPort[0] }, 0);
            }
        }

        public IPAddress RemoteAddress
        {
            get { return new IPAddress(remoteAddr); }
        }

        public ushort RemotePort
        {
            get
            {
                return BitConverter.ToUInt16(new byte[2] { remotePort[1], remotePort[0] }, 0);
            }
        }

        public MIB_TCP_STATE State
        {
            get { return (MIB_TCP_STATE)state; }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MIB_TCPTABLE_OWNER_PID
    {
        public uint dwNumEntries;
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.Struct, SizeConst = 1)]
        public MIB_TCPROW_OWNER_PID[] table;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MIB_TCP6ROW_OWNER_PID
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] localAddr;
        public uint localScopeId;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] localPort;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] remoteAddr;
        public uint remoteScopeId;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] remotePort;
        public uint state;
        public uint owningPid;

        public uint ProcessId
        {
            get { return owningPid; }
        }

        public long LocalScopeId
        {
            get { return localScopeId; }
        }

        public IPAddress LocalAddress
        {
            get { return new IPAddress(localAddr, LocalScopeId); }
        }

        public ushort LocalPort
        {
            get { return BitConverter.ToUInt16(localPort.Take(2).Reverse().ToArray(), 0); }
        }

        public long RemoteScopeId
        {
            get { return remoteScopeId; }
        }

        public IPAddress RemoteAddress
        {
            get { return new IPAddress(remoteAddr, RemoteScopeId); }
        }

        public ushort RemotePort
        {
            get { return BitConverter.ToUInt16(remotePort.Take(2).Reverse().ToArray(), 0); }
        }

        public MIB_TCP_STATE State
        {
            get { return (MIB_TCP_STATE)state; }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MIB_TCP6TABLE_OWNER_PID
    {
        public uint dwNumEntries;
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.Struct, SizeConst = 1)]
        public MIB_TCP6ROW_OWNER_PID[] table;
    }

    

    public static class TCPTable
    {
        [DllImport("iphlpapi.dll", SetLastError = true)]
        static extern uint GetExtendedTcpTable(IntPtr pTcpTable, ref int dwOutBufLen, bool sort, int ipVersion, TCP_TABLE_CLASS tblClass, uint reserved = 0);

        
        public const int AF_INET = 2;    // IP_v4 = System.Net.Sockets.AddressFamily.InterNetwork
        public const int AF_INET6 = 23;  // IP_v6 = System.Net.Sockets.AddressFamily.InterNetworkV6

        public static List<MIB_TCPROW_OWNER_PID> GetAllTCPConnections()
        {
            return GetTCPConnections<MIB_TCPROW_OWNER_PID, MIB_TCPTABLE_OWNER_PID>(AF_INET);
        }

        public static List<MIB_TCP6ROW_OWNER_PID> GetAllTCPv6Connections()
        {
            return GetTCPConnections<MIB_TCP6ROW_OWNER_PID, MIB_TCP6TABLE_OWNER_PID>(AF_INET6);
        }

        public static uint[] FindProcessId(Packet packet)
        {
            var list = new List<uint>();
            if (packet.IPHeader.Version == "IP v4")
            {
                var rows = TCPTable.GetAllTCPConnections().Where(row => (row.LocalAddress.Equals(packet.SourceAddress)      && row.LocalPort == packet.SourcePort) ||
                                                                          (row.LocalAddress.Equals(packet.DestinationAddress) && row.LocalPort == packet.DestinationPort));
                foreach (var row in rows)
                    list.Add(row.ProcessId);
            }
            else if (packet.IPHeader.Version == "IP v6")
            {
                var rows = TCPTable.GetAllTCPv6Connections().Where(row => (row.LocalAddress.Equals(packet.SourceAddress)      && row.LocalPort == packet.SourcePort) ||
                                                                            (row.LocalAddress.Equals(packet.DestinationAddress) && row.LocalPort == packet.DestinationPort));
                foreach (var row in rows)
                        list.Add(row.ProcessId);
            }
            else
            { }

            return list.ToArray();
        }

        public static PacketAction GetPacketAction(Channel channel, Packet packet)
        {
            if (packet.IPHeader.Version == "IP v4")
            {
                var rows = GetAllTCPConnections().Where(row => row.ProcessId == channel.Id).ToArray();
                foreach (var row in rows)
                {
                    if (row.LocalAddress.Equals(packet.SourceAddress) && row.LocalPort == packet.SourcePort)
                        return PacketAction.Send;

                    else if (row.LocalAddress.Equals(packet.DestinationAddress) && row.LocalPort == packet.DestinationPort)
                        return PacketAction.Receive;

                    else
                        continue;
                }
            }
            else if (packet.IPHeader.Version == "IP v6")
            {
                var rows = GetAllTCPv6Connections().Where(row => row.ProcessId == channel.Id).ToArray();
                foreach (var row in rows)
                {
                    if (row.LocalAddress.Equals(packet.SourceAddress) && row.LocalPort == packet.SourcePort)
                        return PacketAction.Send;

                    else if (row.LocalAddress.Equals(packet.DestinationAddress) && row.LocalPort == packet.DestinationPort)
                        return PacketAction.Receive;

                    else
                        continue;
                }
            }
            else
            {
            }

            return PacketAction.Unknown;
        }

        private static List<IPR> GetTCPConnections<IPR, IPT>(int ipVersion)//IPR = Row Type, IPT = Table Type
        {
            IPR[] tableRows;
            var buffSize = 0;
            var dwNumEntriesField = typeof(IPT).GetField("dwNumEntries");

            // how much memory do we need?
            var ret = GetExtendedTcpTable(IntPtr.Zero, ref buffSize, true, ipVersion, TCP_TABLE_CLASS.TCP_TABLE_OWNER_PID_ALL);
            var tcpTablePtr = Marshal.AllocHGlobal(buffSize);

            try
            {
                ret = GetExtendedTcpTable(tcpTablePtr, ref buffSize, true, ipVersion, TCP_TABLE_CLASS.TCP_TABLE_OWNER_PID_ALL);
                if (ret != 0)
                    return new List<IPR>();

                // get the number of entries in the table
                var table = (IPT)Marshal.PtrToStructure(tcpTablePtr, typeof(IPT));
                var rowStructSize = Marshal.SizeOf(typeof(IPR));
                var numEntries = (uint)dwNumEntriesField.GetValue(table);

                // buffer we will be returning
                tableRows = new IPR[numEntries];

                var rowPtr = (IntPtr)((long)tcpTablePtr + 4);
                for (int i = 0; i < numEntries; i++)
                {
                    var tcpRow = (IPR)Marshal.PtrToStructure(rowPtr, typeof(IPR));
                    tableRows[i] = tcpRow;
                    rowPtr = (IntPtr)((long)rowPtr + rowStructSize);   // next entry
                }
            }
            finally
            {
                // Free the Memory
                Marshal.FreeHGlobal(tcpTablePtr);
            }

            return tableRows != null ? tableRows.ToList() : new List<IPR>();
        }
    }
}
