Imports System.Threading
Imports System.IO
Imports AssettoCorsaSharedMemory
Imports System.Runtime.InteropServices

Public Class Main
    Private displayThread As Thread = Nothing

    Public Sub New()
        Me.displayThread = New Thread(AddressOf DoDisplayThread)
    End Sub

    Public Sub Main()
        Dim arduinoController As ArduinoShiftLedController = New ArduinoShiftLedController
        displayThread.Start(arduinoController)

        Try
            Dim statsFile As System.IO.MemoryMappedFiles.MemoryMappedFile = System.IO.MemoryMappedFiles.MemoryMappedFile.OpenExisting("Local\acpmf_physics")
            Dim graphicsFile As System.IO.MemoryMappedFiles.MemoryMappedFile = System.IO.MemoryMappedFiles.MemoryMappedFile.OpenExisting("Local\acpmf_graphics")
            Dim staticFile As System.IO.MemoryMappedFiles.MemoryMappedFile = System.IO.MemoryMappedFiles.MemoryMappedFile.OpenExisting("Local\acpmf_static")

            'FIXME
            'TODO
            While True
                Dim dataObject As Physics = CType(GetDataFromSharedMemory(statsFile, GetType(Physics)), Physics)

                Dim staticObject As StaticInfo = CType(GetDataFromSharedMemory(staticFile, GetType(StaticInfo)), StaticInfo)
                Dim graphicObject As Graphics = CType(GetDataFromSharedMemory(graphicsFile, GetType(Graphics)), Graphics)
                MonitoringData.MaxEngineSpeed = staticObject.maxRpm
                MonitoringData.EngineSpeed = dataObject.Rpms
                MonitoringData.GearBoxGear = dataObject.Gear
                MonitoringData.Car = staticObject.carModel
                'ks_bmw_m235i_racing
                'p4-5_2011

                Console.WriteLine(String.Format("{0}|{1}|{2}|{3}", dataObject.WheelAngularSpeed(0), dataObject.WheelAngularSpeed(1), dataObject.WheelAngularSpeed(2), dataObject.WheelAngularSpeed(3)))

                Thread.Sleep(15)
            End While
        Catch ex As Exception
            DoDemo()
        End Try

        MonitoringData.State = -1
    End Sub

    Public Sub DoDemo()
        MonitoringData.MaxEngineSpeed = 8000
        MonitoringData.GearBoxGear = 2
        MonitoringData.Car = "mclaren_mp412c_gt3"
        Dim baseSleep As Integer = 25
        For i As Integer = 4000 To MonitoringData.MaxEngineSpeed Step 100
            MonitoringData.EngineSpeed = i
            MonitoringData.GearBoxGear = 2
            Thread.Sleep(baseSleep * 2)
        Next
        MonitoringData.GearBoxGear = 1
        Thread.Sleep(250)
        For i As Integer = 5500 To MonitoringData.MaxEngineSpeed Step 50
            MonitoringData.EngineSpeed = i
            MonitoringData.GearBoxGear = 3
            Thread.Sleep(baseSleep * 2)
        Next
        MonitoringData.GearBoxGear = 1
        Thread.Sleep(250)
        For i As Integer = 5500 To MonitoringData.MaxEngineSpeed Step 50
            MonitoringData.EngineSpeed = i
            MonitoringData.GearBoxGear = 4
            Thread.Sleep(baseSleep * 3)
        Next
        MonitoringData.GearBoxGear = 1
        Thread.Sleep(250)
        For i As Integer = 5500 To MonitoringData.MaxEngineSpeed Step 50
            MonitoringData.EngineSpeed = i
            MonitoringData.GearBoxGear = 5
            Thread.Sleep(baseSleep * 4)
        Next
        MonitoringData.GearBoxGear = 1
        Thread.Sleep(250)
        For i As Integer = 5500 To MonitoringData.MaxEngineSpeed Step 50
            MonitoringData.EngineSpeed = i
            MonitoringData.GearBoxGear = 6
            Thread.Sleep(baseSleep * 5)
        Next
        MonitoringData.GearBoxGear = 1
        Thread.Sleep(250)
        For i As Integer = 5500 To MonitoringData.MaxEngineSpeed Step 50
            MonitoringData.EngineSpeed = i
            MonitoringData.GearBoxGear = 7
            Thread.Sleep(baseSleep * 6)
        Next
        Thread.Sleep(60 * 1000)
    End Sub

    Public Function GetDataFromSharedMemory(source As System.IO.MemoryMappedFiles.MemoryMappedFile, resultType As Type) As Object
        Dim physicObject As IO.MemoryMappedFiles.MemoryMappedViewStream = source.CreateViewStream()
        Dim reader As BinaryReader = New BinaryReader(physicObject)

        Dim sizeOfPhysic As Integer = System.Runtime.InteropServices.Marshal.SizeOf(resultType)
        Dim bytes As Byte() = reader.ReadBytes(sizeOfPhysic)
        Dim handle As GCHandle = GCHandle.Alloc(bytes, GCHandleType.Pinned)

        Dim result As Object = Marshal.PtrToStructure(handle.AddrOfPinnedObject(), resultType)

        handle.Free()

        Return result
    End Function

    Public Sub DoDisplayThread(controller As iController)
        controller.OnStart()

        While True
            Dim delay As Integer = controller.OnIterate()

            If delay < 0 Then
                Exit While
            ElseIf delay < 10 Then
                delay = 10
            End If

            Thread.Sleep(delay)
        End While


        controller.OnEnd()
    End Sub
End Class
