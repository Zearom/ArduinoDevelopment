Imports System.LiehrIt.Arduino
Imports System.LiehrIt.Arduino.LedStripDevice

Public Class CarRendererFerrari458GT2
    Implements iCarLedRenderer

    Public Function getCarModel() As String Implements iCarLedRenderer.getCarModel
        Return "ferrari_458_gt2"
    End Function

    Public Sub OnEnd() Implements iCarLedRenderer.OnEnd

    End Sub

    Public Function OnIterate(device As LedStripDevice) As Integer Implements iCarLedRenderer.OnIterate
        '6100 --> grüne led
        '6200 --> grüne led
        '6300 --> grüne led
        '6400 --> grüne led
        '6500 --> grüne led
        '6600 --> rote led
        '6700 --> rote led
        '6800 --> rote led
        '7150 --> Blinkend


        If MonitoringData.EngineSpeed <= 6100 Then
            device.SetAllLeds(LedState.Off)
        ElseIf MonitoringData.EngineSpeed > 6100 And MonitoringData.EngineSpeed < 6200 Then
            device.Set({New LedStripRange(0, 2, LedState.Off), New LedStripRange(2, 2, LedState.Color1), New LedStripRange(4, 16, LedState.Off)})
        ElseIf MonitoringData.EngineSpeed >= 6200 And MonitoringData.EngineSpeed < 6300 Then
            device.Set({New LedStripRange(0, 2, LedState.Off), New LedStripRange(2, 4, LedState.Color1), New LedStripRange(6, 14, LedState.Off)})
        ElseIf MonitoringData.EngineSpeed >= 6300 And MonitoringData.EngineSpeed < 6400 Then
            device.Set({New LedStripRange(0, 2, LedState.Off), New LedStripRange(2, 6, LedState.Color1), New LedStripRange(8, 12, LedState.Off)})
        ElseIf MonitoringData.EngineSpeed >= 6400 And MonitoringData.EngineSpeed < 6500 Then
            device.Set({New LedStripRange(0, 2, LedState.Off), New LedStripRange(2, 8, LedState.Color1), New LedStripRange(10, 10, LedState.Off)})
        ElseIf MonitoringData.EngineSpeed >= 6500 And MonitoringData.EngineSpeed < 6600 Then
            device.Set({New LedStripRange(0, 2, LedState.Off), New LedStripRange(2, 10, LedState.Color1), New LedStripRange(12, 8, LedState.Off)})
        ElseIf MonitoringData.EngineSpeed >= 6600 And MonitoringData.EngineSpeed < 6700 Then
            device.Set({New LedStripRange(0, 2, LedState.Off), New LedStripRange(2, 10, LedState.Color1), New LedStripRange(12, 2, LedState.Color2), New LedStripRange(14, 6, LedState.Off)})
        ElseIf MonitoringData.EngineSpeed >= 6700 And MonitoringData.EngineSpeed < 6800 Then
            device.Set({New LedStripRange(0, 2, LedState.Off), New LedStripRange(2, 10, LedState.Color1), New LedStripRange(12, 4, LedState.Color2), New LedStripRange(16, 4, LedState.Off)})
        ElseIf MonitoringData.EngineSpeed >= 6800 And MonitoringData.EngineSpeed < 7150 Then
            device.Set({New LedStripRange(0, 2, LedState.Off), New LedStripRange(2, 10, LedState.Color1), New LedStripRange(12, 6, LedState.Color2), New LedStripRange(18, 2, LedState.Off)})
        ElseIf MonitoringData.EngineSpeed >= 7150 Then
            device.Set({New LedStripRange(0, 20, LedState.Color3)})
        End If
        device.flushDisplay()
        Return 10
    End Function

    Public Sub OnStart() Implements iCarLedRenderer.OnStart

    End Sub

    Public Function OnColorConfig() As Drawing.Color() Implements iCarLedRenderer.OnColorConfig
        Return {Drawing.Color.FromArgb(0, 0, 10, 0), Drawing.Color.FromArgb(0, 10, 0, 0), Drawing.Color.FromArgb(0, 30, 0, 0)}
    End Function
End Class
