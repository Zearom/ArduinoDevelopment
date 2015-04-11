Imports System.IO.Ports
Imports System.LiehrIt.Arduino.LedStripDevice
Imports System.LiehrIt.Arduino
Imports System.Reflection

Public Class ArduinoShiftLedController
    Implements iController

    Private SerialPort1 As System.IO.Ports.SerialPort = New System.IO.Ports.SerialPort
    Private device As LedStripDevice = Nothing
    Private lastEngineSpeed As Integer = -1
    Private lastGear As Integer = -1
    Private lastCar As String = ""
    Private carRenderer As Hashtable = Nothing

    Private Sub SearchCarRendererClasses()
        Dim currentAssembly As Assembly = Assembly.GetCallingAssembly()
        For Each type As Type In currentAssembly.GetTypes
            Dim interfaceType As Type = Nothing

            Try
                interfaceType = type.GetInterface("RacingMonitor.iCarLedRenderer")
            Catch ex As Exception
                interfaceType = Nothing
            End Try

            If (Not IsNothing(interfaceType)) Then
                LoadCarRenderer(type.FullName)
            End If
        Next
    End Sub

    Private Sub LoadCarRenderer(className As String)
        Dim currentAssembly As Assembly = Assembly.GetCallingAssembly()
        Dim currentCarRenderer As iCarLedRenderer = Activator.CreateInstance(currentAssembly.GetType(className))
        Me.carRenderer.Add(currentCarRenderer.getCarModel, currentCarRenderer)
    End Sub

    Public Sub OnStart() Implements iController.OnStart
        Me.carRenderer = New Hashtable

        SearchCarRendererClasses()

        SerialPort1.Close()
        SerialPort1.PortName = "com4" 'change com port to match your Arduino port
        SerialPort1.BaudRate = 9600
        SerialPort1.DataBits = 8
        SerialPort1.Parity = Parity.None
        SerialPort1.StopBits = StopBits.One
        SerialPort1.Handshake = Handshake.None
        SerialPort1.Encoding = System.Text.Encoding.Default 'very important!
        SerialPort1.Open()

        device = New LedStripDevice(20, SerialPort1)
        device.SetAllLeds(LedState.Off)
        device.EnableDuplicateCheck = True
    End Sub

    Public Sub OnEnd() Implements iController.OnEnd
        device.disconnect()
    End Sub

    Public Function OnIterate() As Integer Implements iController.OnIterate
            Dim graph As Integer = Math.Ceiling(MonitoringData.EngineSpeed / MonitoringData.MaxEngineSpeed * 80)
            CType(Me.carRenderer(MonitoringData.Car), iCarLedRenderer).OnIterate(Me.device)

            If (lastCar <> MonitoringData.Car) Then
                Dim colorConfig As System.Drawing.Color() = CType(Me.carRenderer(MonitoringData.Car), iCarLedRenderer).OnColorConfig()
                device.SetColors(colorConfig(0), colorConfig(1), colorConfig(2))
                lastCar = MonitoringData.Car
            End If

            lastEngineSpeed = MonitoringData.EngineSpeed
            lastGear = MonitoringData.GearBoxGear

        Return 15
    End Function
End Class
