using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AssettoCorsaSharedMemory
{
    public class StaticInfoEventArgs : EventArgs
    {
        public StaticInfoEventArgs(StaticInfo staticInfo)
        {
            this.StaticInfo = staticInfo;
        }

        public StaticInfo StaticInfo { get; private set; }
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    [Serializable]
    public struct StaticInfo
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
        public String smVersion;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
        public String acVersion;

        // session static info
        public int numberOfSessions;
        public int numCars;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public String carModel;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public String track;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public String playerName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public String playerSurname;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public String playerNick;

        public int sectorCount;

        // car static info
        public float maxTorque;
        public float maxPower;
        public int maxRpm;
        public float maxFuel;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] suspensionMaxTravel;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] tyreRadius;
    }
}