Imports System.LiehrIt.Arduino
Imports System.LiehrIt.Arduino.LedStripDevice

Public Class CarRendererNissanGTRGT3
    Implements iCarLedRenderer

    Public Function getCarModel() As String Implements iCarLedRenderer.getCarModel
        Return "ks_nissan_gtr_gt3"
    End Function

    Public Sub OnEnd() Implements iCarLedRenderer.OnEnd

    End Sub

    Public Function OnIterate(device As LedStripDevice) As Integer Implements iCarLedRenderer.OnIterate
        '2100 --> Grüne LED
        '4500 --> Grüne LED
        '5000 --> Grüne LED
        '6000 --> Gelbe LED
        '6500 --> Gelbe LED
        '6900 --> drei rote LEDs (blinkend)
        If MonitoringData.EngineSpeed < 2100 Then
            device.SetAllLeds(LedState.Off)
        ElseIf MonitoringData.EngineSpeed >= 2100 And MonitoringData.EngineSpeed < 4500 Then
            device.Set({New LedStripRange(0, 20, LedState.Off), New LedStripRange(2, 2, LedState.Color1)})
        ElseIf MonitoringData.EngineSpeed >= 4500 And MonitoringData.EngineSpeed < 5000 Then
            device.Set({New LedStripRange(0, 20, LedState.Off), New LedStripRange(2, 4, LedState.Color1)})
        ElseIf MonitoringData.EngineSpeed >= 5000 And MonitoringData.EngineSpeed < 6000 Then
            device.Set({New LedStripRange(0, 20, LedState.Off), New LedStripRange(2, 6, LedState.Color1)})
        ElseIf MonitoringData.EngineSpeed >= 6000 And MonitoringData.EngineSpeed < 6500 Then
            device.Set({New LedStripRange(0, 20, LedState.Off), New LedStripRange(2, 6, LedState.Color1), New LedStripRange(8, 2, LedState.Color2)})
        ElseIf MonitoringData.EngineSpeed >= 6500 And MonitoringData.EngineSpeed < 6900 Then
            device.Set({New LedStripRange(0, 20, LedState.Off), New LedStripRange(2, 6, LedState.Color1), New LedStripRange(8, 4, LedState.Color2)})
        ElseIf MonitoringData.EngineSpeed >= 6900 Then
            device.Set({New LedStripRange(0, 20, LedState.Off), New LedStripRange(2, 6, LedState.Color1), New LedStripRange(8, 4, LedState.Color2), New LedStripRange(12, 6, LedState.Color3)})
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
