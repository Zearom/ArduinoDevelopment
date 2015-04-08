Imports System.LiehrIt.Arduino
Imports System.LiehrIt.Arduino.LedStripDevice

Public Class CarRendererMcLarenMP412CGT3
    Implements iCarLedRenderer

    Public Function getCarModel() As String Implements iCarLedRenderer.getCarModel
        Return "mclaren_mp412c_gt3"
    End Function

    Public Sub OnEnd() Implements iCarLedRenderer.OnEnd

    End Sub

    Public Function OnIterate(device As LedStripDevice) As Integer Implements iCarLedRenderer.OnIterate
        '6100 --> grüne led
        '6250 --> grüne led
        '6400 --> grüne led
        '6500 --> grüne led
        '6600 --> rote led
        '6700 --> rote led
        '6800 --> rote led
        '6900 --> rote led
        '7100 --> 4 blaue leds
        '7450 --> Blau blinkend
        If MonitoringData.EngineSpeed <= 6100 Then
            device.SetAllLeds(LedState.Off)
        ElseIf MonitoringData.EngineSpeed > 6100 And MonitoringData.EngineSpeed < 6250 Then
            device.Set({New LedStripRange(4, 1, LedState.Color1), New LedStripRange(5, 15, LedState.Off)})
        ElseIf MonitoringData.EngineSpeed >= 6250 And MonitoringData.EngineSpeed < 6400 Then
            device.Set({New LedStripRange(4, 2, LedState.Color1), New LedStripRange(6, 14, LedState.Off)})
        ElseIf MonitoringData.EngineSpeed >= 6400 And MonitoringData.EngineSpeed < 6500 Then
            device.Set({New LedStripRange(4, 3, LedState.Color1), New LedStripRange(7, 13, LedState.Off)})
        ElseIf MonitoringData.EngineSpeed >= 6500 And MonitoringData.EngineSpeed < 6600 Then
            device.Set({New LedStripRange(4, 4, LedState.Color1), New LedStripRange(8, 12, LedState.Off)})
        ElseIf MonitoringData.EngineSpeed >= 6600 And MonitoringData.EngineSpeed < 6700 Then
            device.Set({New LedStripRange(4, 4, LedState.Color1), New LedStripRange(8, 1, LedState.Color2), New LedStripRange(9, 11, LedState.Off)})
        ElseIf MonitoringData.EngineSpeed >= 6700 And MonitoringData.EngineSpeed < 6800 Then
            device.Set({New LedStripRange(4, 4, LedState.Color1), New LedStripRange(8, 2, LedState.Color2), New LedStripRange(10, 10, LedState.Off)})
        ElseIf MonitoringData.EngineSpeed >= 6800 And MonitoringData.EngineSpeed < 6900 Then
            device.Set({New LedStripRange(4, 4, LedState.Color1), New LedStripRange(8, 3, LedState.Color2), New LedStripRange(11, 9, LedState.Off)})
        ElseIf MonitoringData.EngineSpeed >= 6900 And MonitoringData.EngineSpeed < 7100 Then
            device.Set({New LedStripRange(4, 4, LedState.Color1), New LedStripRange(8, 4, LedState.Color2), New LedStripRange(12, 8, LedState.Off)})
        ElseIf MonitoringData.EngineSpeed >= 7100 And MonitoringData.EngineSpeed < 7450 Then
            device.Set({New LedStripRange(4, 4, LedState.Color1), New LedStripRange(8, 4, LedState.Color2), New LedStripRange(12, 4, LedState.Color3), New LedStripRange(16, 4, LedState.Off)})
        ElseIf MonitoringData.EngineSpeed >= 7450 Then
            device.SetAllLeds(LedState.Color3)
        End If
        device.flushDisplay()
        Return 10
    End Function

    Public Sub OnStart() Implements iCarLedRenderer.OnStart

    End Sub

    Public Function OnColorConfig() As Drawing.Color() Implements iCarLedRenderer.OnColorConfig
        Return {Drawing.Color.FromArgb(0, 0, 10, 0), Drawing.Color.FromArgb(0, 10, 0, 0), Drawing.Color.FromArgb(0, 0, 0, 10)}
    End Function
End Class
