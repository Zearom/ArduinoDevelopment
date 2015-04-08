Imports System.LiehrIt.Arduino
Imports System.LiehrIt.Arduino.LedStripDevice

Public Class CarRendererBmwM235i
    Implements iCarLedRenderer

    Public Function getCarModel() As String Implements iCarLedRenderer.getCarModel
        Return "ks_bmw_m235i_racing"
    End Function

    Public Sub OnEnd() Implements iCarLedRenderer.OnEnd

    End Sub

    Public Function OnIterate(device As LedStripDevice) As Integer Implements iCarLedRenderer.OnIterate
        '5100 --> zwei grüne leds
        '5500 --> zwei grüne leds
        '5800 --> zwei gelbe leds
        '6200 --> zwei rote leds
        '6500 --> zwei rote leds
        '6600 --> *blindend* --> alles rot
        If MonitoringData.EngineSpeed < 5100 Then
            device.SetAllLeds(LedState.Off)
        ElseIf MonitoringData.EngineSpeed >= 5100 And MonitoringData.EngineSpeed < 5500 Then
            device.Set({New LedStripRange(0, 2, LedState.Color1), New LedStripRange(2, 16, LedState.Off), New LedStripRange(18, 2, LedState.Color1)})
        ElseIf MonitoringData.EngineSpeed >= 5500 And MonitoringData.EngineSpeed < 5800 Then
            device.Set({New LedStripRange(0, 4, LedState.Color1), New LedStripRange(4, 12, LedState.Off), New LedStripRange(16, 4, LedState.Color1)})
        ElseIf MonitoringData.EngineSpeed >= 5800 And MonitoringData.EngineSpeed < 6200 Then
            device.Set({New LedStripRange(0, 4, LedState.Color1), New LedStripRange(4, 2, LedState.Color2), New LedStripRange(6, 8, LedState.Off), New LedStripRange(14, 2, LedState.Color2), New LedStripRange(16, 4, LedState.Color1)})
        ElseIf MonitoringData.EngineSpeed >= 6200 And MonitoringData.EngineSpeed < 6500 Then
            device.Set({New LedStripRange(0, 4, LedState.Color1), New LedStripRange(4, 2, LedState.Color2), New LedStripRange(6, 2, LedState.Color3), New LedStripRange(8, 4, LedState.Off), New LedStripRange(12, 2, LedState.Color3), New LedStripRange(14, 2, LedState.Color2), New LedStripRange(16, 4, LedState.Color1)})
        ElseIf MonitoringData.EngineSpeed >= 6500 And MonitoringData.EngineSpeed < 6650 Then
            device.Set({New LedStripRange(0, 4, LedState.Color1), New LedStripRange(4, 2, LedState.Color2), New LedStripRange(6, 8, LedState.Color3), New LedStripRange(14, 2, LedState.Color2), New LedStripRange(16, 4, LedState.Color1)})
        ElseIf MonitoringData.EngineSpeed >= 6650 Then
            device.SetAllLeds(LedState.Color3)
        End If
        device.flushDisplay()


        Return 10
    End Function

    Public Sub OnStart() Implements iCarLedRenderer.OnStart

    End Sub

    Public Function OnColorConfig() As Drawing.Color() Implements iCarLedRenderer.OnColorConfig
        Return {Drawing.Color.FromArgb(0, 0, 10, 0), Drawing.Color.FromArgb(0, 10, 10, 0), Drawing.Color.FromArgb(0, 0, 0, 10)}
    End Function
End Class
