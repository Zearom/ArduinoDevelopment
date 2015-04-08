Imports System.LiehrIt.Arduino
Imports System.LiehrIt.Arduino.LedStripDevice

Public Class CarRendererCorvetteC7R
    Implements iCarLedRenderer

    Public Function getCarModel() As String Implements iCarLedRenderer.getCarModel
        Return "ks_corvette_c7r"
    End Function

    Public Sub OnEnd() Implements iCarLedRenderer.OnEnd

    End Sub

    Public Function OnIterate(device As LedStripDevice) As Integer Implements iCarLedRenderer.OnIterate
        '5400 -> grüne led
        '5500 -> grüne led
        '5600 -> grüne led
        '5700 -> grüne led
        '5800 -> rote led
        '5900 -> rote led
        '6050 -> rote led
        '6150 -> blaue led
        '6250 -> blaue led
        '6350 -> rote led

        If MonitoringData.EngineSpeed <= 5400 Then
            device.SetAllLeds(LedState.Off)
        ElseIf MonitoringData.EngineSpeed > 5400 And MonitoringData.EngineSpeed < 5500 Then
            device.Set({New LedStripRange(0, 2, LedState.Color1), New LedStripRange(2, 18, LedState.Off)})
        ElseIf MonitoringData.EngineSpeed >= 5500 And MonitoringData.EngineSpeed < 5600 Then
            device.Set({New LedStripRange(0, 4, LedState.Color1), New LedStripRange(4, 16, LedState.Off)})
        ElseIf MonitoringData.EngineSpeed >= 5600 And MonitoringData.EngineSpeed < 5700 Then
            device.Set({New LedStripRange(0, 6, LedState.Color1), New LedStripRange(6, 14, LedState.Off)})
        ElseIf MonitoringData.EngineSpeed >= 5700 And MonitoringData.EngineSpeed < 5800 Then
            device.Set({New LedStripRange(0, 8, LedState.Color1), New LedStripRange(8, 12, LedState.Off)})
        ElseIf MonitoringData.EngineSpeed >= 5800 And MonitoringData.EngineSpeed < 5900 Then
            device.Set({New LedStripRange(0, 8, LedState.Color1), New LedStripRange(8, 2, LedState.Color2), New LedStripRange(10, 10, LedState.Off)})
        ElseIf MonitoringData.EngineSpeed >= 5900 And MonitoringData.EngineSpeed < 6050 Then
            device.Set({New LedStripRange(0, 8, LedState.Color1), New LedStripRange(8, 4, LedState.Color2), New LedStripRange(12, 8, LedState.Off)})
        ElseIf MonitoringData.EngineSpeed >= 6050 And MonitoringData.EngineSpeed < 6150 Then
            device.Set({New LedStripRange(0, 8, LedState.Color1), New LedStripRange(8, 6, LedState.Color2), New LedStripRange(14, 6, LedState.Off)})
        ElseIf MonitoringData.EngineSpeed >= 6150 And MonitoringData.EngineSpeed < 6250 Then
            device.Set({New LedStripRange(0, 8, LedState.Color1), New LedStripRange(8, 6, LedState.Color2), New LedStripRange(14, 2, LedState.Color3), New LedStripRange(16, 4, LedState.Off)})
        ElseIf MonitoringData.EngineSpeed >= 6250 And MonitoringData.EngineSpeed < 6350 Then
            device.Set({New LedStripRange(0, 8, LedState.Color1), New LedStripRange(8, 6, LedState.Color2), New LedStripRange(14, 4, LedState.Color3), New LedStripRange(18, 2, LedState.Off)})
        ElseIf MonitoringData.EngineSpeed >= 6350 Then
            device.Set({New LedStripRange(0, 8, LedState.Color1), New LedStripRange(8, 6, LedState.Color2), New LedStripRange(14, 4, LedState.Color3), New LedStripRange(18, 2, LedState.Color2)})
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
