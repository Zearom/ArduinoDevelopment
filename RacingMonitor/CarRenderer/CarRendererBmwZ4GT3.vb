Imports System.LiehrIt.Arduino
Imports System.LiehrIt.Arduino.LedStripDevice

Public Class CarRendererBmwMZ4
    Implements iCarLedRenderer

    Public Function getCarModel() As String Implements iCarLedRenderer.getCarModel
        Return "bmw_z4_gt3"
    End Function

    Public Sub OnEnd() Implements iCarLedRenderer.OnEnd

    End Sub

    Public Function OnIterate(device As LedStripDevice) As Integer Implements iCarLedRenderer.OnIterate
        If MonitoringData.EngineSpeed < 7300 Then
            device.SetAllLeds(LedState.Off)
        ElseIf MonitoringData.EngineSpeed >= 7300 And MonitoringData.EngineSpeed < 7410 Then
            device.Set({New LedStripRange(0, 2, LedState.Color1), New LedStripRange(2, 18, LedState.Off)})
        ElseIf MonitoringData.EngineSpeed >= 7410 And MonitoringData.EngineSpeed < 7520 Then
            device.Set({New LedStripRange(0, 4, LedState.Color1), New LedStripRange(4, 16, LedState.Off)})
        ElseIf MonitoringData.EngineSpeed >= 7520 And MonitoringData.EngineSpeed < 7630 Then
            device.Set({New LedStripRange(0, 6, LedState.Color1), New LedStripRange(6, 14, LedState.Off)})
        ElseIf MonitoringData.EngineSpeed >= 7630 And MonitoringData.EngineSpeed < 7740 Then
            device.Set({New LedStripRange(0, 6, LedState.Color1), New LedStripRange(6, 2, LedState.Color2), New LedStripRange(8, 12, LedState.Off)})
        ElseIf MonitoringData.EngineSpeed >= 7740 And MonitoringData.EngineSpeed < 7850 Then
            device.Set({New LedStripRange(0, 6, LedState.Color1), New LedStripRange(6, 4, LedState.Color2), New LedStripRange(10, 10, LedState.Off)})
        ElseIf MonitoringData.EngineSpeed >= 7850 And MonitoringData.EngineSpeed < 7960 Then
            device.Set({New LedStripRange(0, 6, LedState.Color1), New LedStripRange(6, 6, LedState.Color2), New LedStripRange(12, 8, LedState.Off)})
        ElseIf MonitoringData.EngineSpeed >= 7960 And MonitoringData.EngineSpeed < 8070 Then
            device.Set({New LedStripRange(0, 6, LedState.Color1), New LedStripRange(6, 8, LedState.Color2), New LedStripRange(14, 6, LedState.Off)})
        ElseIf MonitoringData.EngineSpeed >= 8070 And MonitoringData.EngineSpeed < 8180 Then
            device.Set({New LedStripRange(0, 6, LedState.Color1), New LedStripRange(6, 8, LedState.Color2), New LedStripRange(14, 2, LedState.Color3), New LedStripRange(16, 4, LedState.Off)})
        ElseIf MonitoringData.EngineSpeed >= 8180 And MonitoringData.EngineSpeed < 8290 Then
            device.Set({New LedStripRange(0, 6, LedState.Color1), New LedStripRange(6, 8, LedState.Color2), New LedStripRange(14, 4, LedState.Color3), New LedStripRange(18, 2, LedState.Off)})
        ElseIf MonitoringData.EngineSpeed >= 8290 And MonitoringData.EngineSpeed < 8400 Then
            device.Set({New LedStripRange(0, 6, LedState.Color1), New LedStripRange(6, 8, LedState.Color2), New LedStripRange(14, 6, LedState.Color3)})
        ElseIf MonitoringData.EngineSpeed > 8400 Then
            device.SetAllLeds(LedState.Color3)
        End If
        device.flushDisplay()
        Return 10
    End Function

    Public Sub OnStart() Implements iCarLedRenderer.OnStart

    End Sub

    Public Function OnColorConfig() As Drawing.Color() Implements iCarLedRenderer.OnColorConfig
        Return {Drawing.Color.FromArgb(0, 10, 0), Drawing.Color.FromArgb(10, 10, 0), Drawing.Color.FromArgb(10, 0, 0)}
    End Function
End Class
