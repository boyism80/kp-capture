using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;

namespace KPU.Sources
{
    public enum UdpTableClass
    {
        UDP_TABLE_BASIC,
        UDP_TABLE_OWNER_PID,
        UDP_TABLE_OWNER_MODULE
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MIB_UDPROW_OWNER_PID
    {
        public uint localAddr;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] localPort;
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
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MIB_UDPTABLE_OWNER_PID
    {
        public uint dwNumEntries;
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.Struct, SizeConst = 1)]
        public MIB_UDPROW_OWNER_PID[] table;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MIB_UDP6ROW_OWNER_PID
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] localAddr;
        public uint localScopeId;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] localPort;
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
            get { return BitConverter.ToUInt16(localPort.Take(2).Reverse().ToArray(), 0); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MIB_UDP6TABLE_OWNER_PID
    {
        public uint dwNumEntries;
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.Struct, SizeConst = 1)]
        public MIB_UDP6ROW_OWNER_PID[] table;
    }

    public static class UDPTable
    {
        [DllImport("iphlpapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern uint GetExtendedUdpTable(IntPtr pUdpTable, ref int pdwSize, bool bOrder, int ulAf, UdpTableClass tableClass, uint reserved = 0);

        public const int AF_INET = 2;    // IP_v4 = System.Net.Sockets.AddressFamily.InterNetwork
        public const int AF_INET6 = 23;  // IP_v6 = System.Net.Sockets.AddressFamily.InterNetworkV6

        public static List<MIB_UDPROW_OWNER_PID> GetAllUDPConnections()
        {
            return GetUDPConnections<MIB_UDPROW_OWNER_PID, MIB_UDPTABLE_OWNER_PID>(AF_INET);
        }

        public static List<MIB_UDP6ROW_OWNER_PID> GetAllUDPv6Connections()
        {
            return GetUDPConnections<MIB_UDP6ROW_OWNER_PID, MIB_UDP6TABLE_OWNER_PID>(AF_INET6);
        }

        public static uint[] FindProcessId(Packet packet)
        {
            var list = new List<uint>();
            if (packet.IPHeader.Version == "IP v4")
            {
                var rows = UDPTable.GetAllUDPConnections().Where(row => ((row.LocalAddress.Equals(IPAddress.Parse("0.0.0.0")) || row.LocalAddress.Equals(packet.SourceAddress))      && row.LocalPort == packet.SourcePort) ||
                                                                          ((row.LocalAddress.Equals(IPAddress.Parse("0.0.0.0")) || row.LocalAddress.Equals(packet.DestinationAddress)) && row.LocalPort == packet.DestinationPort));
                foreach (var row in rows)
                    list.Add(row.ProcessId);
            }
            else
            {
                var rows = UDPTable.GetAllUDPv6Connections().Where(row => (row.LocalAddress.Equals(packet.SourceAddress) && row.LocalPort == packet.SourcePort) ||
                                                                            (row.LocalAddress.Equals(packet.DestinationAddress) && row.LocalPort == packet.DestinationPort));
                foreach (var row in rows)
                    list.Add(row.ProcessId);
            }

            return list.ToArray();
        }

        public static bool FindProcessUDPAddress(int pid, out IPAddress address, out int port)
        {
            foreach (var row in UDPTable.GetAllUDPConnections())
            {
                if (row.ProcessId != pid)
                    continue;

                address = row.LocalAddress;
                port = row.LocalPort;
                return true;
            }

            foreach (var row in UDPTable.GetAllUDPv6Connections())
            {
                if (row.ProcessId != pid)
                    continue;

                address = row.LocalAddress;
                port = row.LocalPort;
                return true;
            }

            address = IPAddress.None;
            port = 0;
            return false;
        }

        private static List<IPR> GetUDPConnections<IPR, IPT>(int ipVersion)//IPR = Row Type, IPT = Table Type
        {
            IPR[] tableRows;
            var buffSize = 0;
            var dwNumEntriesField = typeof(IPT).GetField("dwNumEntries");

            // how much memory do we need?
            var ret = GetExtendedUdpTable(IntPtr.Zero, ref buffSize, true, ipVersion, UdpTableClass.UDP_TABLE_OWNER_PID);
            var udpTablePtr = Marshal.AllocHGlobal(buffSize);

            try
            {
                ret = GetExtendedUdpTable(udpTablePtr, ref buffSize, true, ipVersion, UdpTableClass.UDP_TABLE_OWNER_PID);
                if (ret != 0)
                    return new List<IPR>();

                // get the number of entries in the table
                var table = (IPT)Marshal.PtrToStructure(udpTablePtr, typeof(IPT));
                var rowStructSize = Marshal.SizeOf(typeof(IPR));
                var numEntries = (uint)dwNumEntriesField.GetValue(table);

                // buffer we will be returning
                tableRows = new IPR[numEntries];

                var rowPtr = (IntPtr)((long)udpTablePtr + 4);
                for (int i = 0; i < numEntries; i++)
                {
                    var udpRow = (IPR)Marshal.PtrToStructure(rowPtr, typeof(IPR));
                    tableRows[i] = udpRow;
                    rowPtr = (IntPtr)((long)rowPtr + rowStructSize);   // next entry
                }
            }
            finally
            {
                // Free the Memory
                Marshal.FreeHGlobal(udpTablePtr);
            }

            return tableRows != null ? tableRows.ToList() : new List<IPR>();
        }
    }
}
