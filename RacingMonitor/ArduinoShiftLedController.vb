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
    End Sub

    Public Sub OnEnd() Implements iController.OnEnd
        device.disconnect()
    End Sub

    Public Function OnIterate() As Integer Implements iController.OnIterate
        If lastEngineSpeed <> MonitoringData.EngineSpeed Or lastGear <> MonitoringData.GearBoxGear Then
            Dim graph As Integer = Math.Ceiling(MonitoringData.EngineSpeed / MonitoringData.MaxEngineSpeed * 80)
            CType(Me.carRenderer(MonitoringData.Car), iCarLedRenderer).OnIterate(Me.device)

            If (lastCar <> MonitoringData.Car) Then
                Dim colorConfig As System.Drawing.Color() = CType(Me.carRenderer(MonitoringData.Car), iCarLedRenderer).OnColorConfig()
                device.SetColors(colorConfig(0), colorConfig(1), colorConfig(2))
                lastCar = MonitoringData.Car
            End If

            lastEngineSpeed = MonitoringData.EngineSpeed
            lastGear = MonitoringData.GearBoxGear
        End If

        Return 10
    End Function

    Public Function getLed(green1 As Boolean, green2 As Boolean, green3 As Boolean, orange1 As Boolean, orange2 As Boolean, orange3 As Boolean, orange4 As Boolean, red1 As Boolean, red2 As Boolean, red3 As Boolean, blue1 As Boolean, gear As Integer, graph As Integer) As Byte()
        Dim buffer(7) As Byte

        Dim gearBits As BitArray = New BitArray(New Byte() {CType(gear, Byte)})
        Dim graphBits As BitArray = New BitArray(New Byte() {CType(graph, Byte)})

        buffer(0) = Me.getLedRow(green1, green2, green3, orange1, orange2, orange3, orange4, red1)
        'buffer(1) = Me.getLedRow(red2, red3, False, False, True, True, True, False)
        buffer(1) = Me.createByte(gearBits(0), gearBits(1), gearBits(2), gearBits(3), False, False, red3, red2)
        buffer(2) = Me.getLedRow(blue1, blue1, blue1, blue1, blue1, blue1, blue1, blue1)
        buffer(3) = Me.createByte(graphBits(0), graphBits(1), graphBits(2), graphBits(3), graphBits(4), graphBits(5), graphBits(6), graphBits(7))
        buffer(4) = Me.getLedRow(False, False, False, False, False, False, False, False)
        buffer(5) = Me.getLedRow(False, False, False, False, False, False, False, False)
        buffer(6) = Me.getLedRow(False, False, False, False, False, False, False, False)
        buffer(7) = Me.getLedRow(False, False, False, False, False, False, False, False)

        Return buffer
    End Function

    Public Function createByte(v1 As Boolean, v2 As Boolean, v3 As Boolean, v4 As Boolean, v5 As Boolean, v6 As Boolean, v7 As Boolean, v8 As Boolean) As Byte
        Dim result As Int16 = 0

        If v1 Then
            result += 1
        End If
        If v2 Then
            result += 2
        End If
        If v3 Then
            result += 4
        End If
        If v4 Then
            result += 8
        End If
        If v5 Then
            result += 16
        End If
        If v6 Then
            result += 32
        End If
        If v7 Then
            result += 64
        End If
        If v8 Then
            result += 128
        End If

        Return Convert.ToByte(result)
    End Function

    Public Function getLedRow(led1 As Boolean, led2 As Boolean, led3 As Boolean, led4 As Boolean, led5 As Boolean, led6 As Boolean, led7 As Boolean, led8 As Boolean) As Byte
        Dim result As Int16 = 0

        If led8 Then
            result += 1
        End If
        If led7 Then
            result += 2
        End If
        If led6 Then
            result += 4
        End If
        If led5 Then
            result += 8
        End If
        If led4 Then
            result += 16
        End If
        If led3 Then
            result += 32
        End If
        If led2 Then
            result += 64
        End If
        If led1 Then
            result += 128
        End If

        Return Convert.ToByte(result)
    End Function
End Class
