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

        Dim statsFile As System.IO.MemoryMappedFiles.MemoryMappedFile = System.IO.MemoryMappedFiles.MemoryMappedFile.OpenExisting("Local\acpmf_physics")

        While True


            Dim physicObject As IO.MemoryMappedFiles.MemoryMappedViewStream = statsFile.CreateViewStream()
            Dim reader As BinaryReader = New BinaryReader(physicObject)

            Dim sizeOfPhysic As Integer = System.Runtime.InteropServices.Marshal.SizeOf(GetType(Physics))
            Dim bytes As Byte() = reader.ReadBytes(sizeOfPhysic)
            Dim handle As GCHandle = GCHandle.Alloc(bytes, GCHandleType.Pinned)
            Dim dataObject As Physics = CType(Marshal.PtrToStructure(handle.AddrOfPinnedObject(), GetType(Physics)), Physics)

            MonitoringData.EngineSpeed = dataObject.Rpms
            MonitoringData.GearBoxGear = dataObject.Gear

            If MonitoringData.MaxEngineSpeed < dataObject.Rpms Then
                MonitoringData.MaxEngineSpeed = dataObject.Rpms
                Console.WriteLine(MonitoringData.EngineSpeed)
            End If

            handle.Free()
            Thread.Sleep(10)
        End While

        MonitoringData.State = -1
    End Sub

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
