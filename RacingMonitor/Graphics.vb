Imports System.Runtime.InteropServices

Namespace SharedMemoryApi

    Public Enum AC_STATUS As Integer
        AC_OFF = 0
        AC_REPLAY = 1
        AC_LIVE = 2
        AC_PAUSE = 3
    End Enum

    Public Enum AC_SESSION_TYPE As Integer
        AC_UNKNOWN = -1
        AC_PRACTICE = 0
        AC_QUALIFY = 1
        AC_RACE = 2
        AC_HOTLAP = 3
        AC_TIME_ATTACK = 4
        AC_DRIFT = 5
        AC_DRAG = 6
    End Enum


    Public Structure Graphics
        Public PacketId As Integer
        Public Status As AC_STATUS
        Public Session As AC_SESSION_TYPE
        <MarshalAs(UnmanagedType.LPWStr, SizeConst:=15)> _
        Public CurrentTime As String
        <MarshalAs(UnmanagedType.LPWStr, SizeConst:=15)> _
        Public LastTime As String
        <MarshalAs(UnmanagedType.LPWStr, SizeConst:=15)> _
        Public BestTime As String
        <MarshalAs(UnmanagedType.LPWStr, SizeConst:=15)> _
        Public Split As String
        Public CompletedLaps As Integer
        Public Position As Integer
        Public iCurrentTime As Integer
        Public iLastTime As Integer
        Public iBestTime As Integer
        Public SessionTimeLeft As Single
        Public DistanceTraveled As Single
        Public IsInPit As Integer
        Public CurrentSectorIndex As Integer
        Public LastSectorTime As Integer
        Public NumberOfLaps As Integer
        <MarshalAs(UnmanagedType.LPWStr, SizeConst:=33)> _
        Public TyreCompound As String

        Public ReplayTimeMultiplier As Single
        Public NormalizedCarPosition As Single
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=3)> _
        Public CarCoordinates As Single()
    End Structure
End Namespace
