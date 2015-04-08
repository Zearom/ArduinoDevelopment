Imports System.LiehrIt.Arduino
Imports System.LiehrIt.Arduino.LedStripDevice

Public Class CarRendererP452011
    Implements iCarLedRenderer

    Public Function getCarModel() As String Implements iCarLedRenderer.getCarModel
        Return "p4-5_2011"
    End Function

    Public Sub OnEnd() Implements iCarLedRenderer.OnEnd

    End Sub

    Public Function OnIterate(device As LedStripDevice) As Integer Implements iCarLedRenderer.OnIterate
        '<= 1500 --> alle leds off
        ' 1500 eine grüne led
        ' 4500 eine grüne led
        ' 5000 eine grüne led
        ' 6000 eine gelbe led
        ' 6500 eine gelbe led
        ' 7000 eine rote led
        ' 7500 eine rote led 
        ' 7900 eine rote led


        If MonitoringData.EngineSpeed <= 1500 Then
            device.SetAllLeds(LedState.Off)
        ElseIf MonitoringData.EngineSpeed > 1500 And MonitoringData.EngineSpeed < 4500 Then
            device.Set({New LedStripRange(2, 2, LedState.Color1), New LedStripRange(4, 2, LedState.Off), New LedStripRange(6, 2, LedState.Off), New LedStripRange(8, 2, LedState.Off), New LedStripRange(10, 2, LedState.Off), New LedStripRange(12, 2, LedState.Off), New LedStripRange(14, 2, LedState.Off), New LedStripRange(16, 2, LedState.Off)})
        ElseIf MonitoringData.EngineSpeed >= 4500 And MonitoringData.EngineSpeed < 5000 Then
            device.Set({New LedStripRange(2, 2, LedState.Color1), New LedStripRange(4, 2, LedState.Color1), New LedStripRange(6, 2, LedState.Off), New LedStripRange(8, 2, LedState.Off), New LedStripRange(10, 2, LedState.Off), New LedStripRange(12, 2, LedState.Off), New LedStripRange(14, 2, LedState.Off), New LedStripRange(16, 2, LedState.Off)})
        ElseIf MonitoringData.EngineSpeed >= 5000 And MonitoringData.EngineSpeed < 6000 Then
            device.Set({New LedStripRange(2, 2, LedState.Color1), New LedStripRange(4, 2, LedState.Color1), New LedStripRange(6, 2, LedState.Color1), New LedStripRange(8, 2, LedState.Off), New LedStripRange(10, 2, LedState.Off), New LedStripRange(12, 2, LedState.Off), New LedStripRange(14, 2, LedState.Off), New LedStripRange(16, 2, LedState.Off)})
        ElseIf MonitoringData.EngineSpeed >= 6000 And MonitoringData.EngineSpeed < 6500 Then
            device.Set({New LedStripRange(2, 2, LedState.Color1), New LedStripRange(4, 2, LedState.Color1), New LedStripRange(6, 2, LedState.Color1), New LedStripRange(8, 2, LedState.Color2), New LedStripRange(10, 2, LedState.Off), New LedStripRange(12, 2, LedState.Off), New LedStripRange(14, 2, LedState.Off), New LedStripRange(16, 2, LedState.Off)})
        ElseIf MonitoringData.EngineSpeed >= 6500 And MonitoringData.EngineSpeed < 7000 Then
            device.Set({New LedStripRange(2, 2, LedState.Color1), New LedStripRange(4, 2, LedState.Color1), New LedStripRange(6, 2, LedState.Color1), New LedStripRange(8, 2, LedState.Color2), New LedStripRange(10, 2, LedState.Color2), New LedStripRange(12, 2, LedState.Off), New LedStripRange(14, 2, LedState.Off), New LedStripRange(16, 2, LedState.Off)})
        ElseIf MonitoringData.EngineSpeed >= 7000 And MonitoringData.EngineSpeed < 7500 Then
            device.Set({New LedStripRange(2, 2, LedState.Color1), New LedStripRange(4, 2, LedState.Color1), New LedStripRange(6, 2, LedState.Color1), New LedStripRange(8, 2, LedState.Color2), New LedStripRange(10, 2, LedState.Color2), New LedStripRange(12, 2, LedState.Color3), New LedStripRange(14, 2, LedState.Off), New LedStripRange(16, 2, LedState.Off)})
        ElseIf MonitoringData.EngineSpeed >= 7500 And MonitoringData.EngineSpeed < 7900 Then
            device.Set({New LedStripRange(2, 2, LedState.Color1), New LedStripRange(4, 2, LedState.Color1), New LedStripRange(6, 2, LedState.Color1), New LedStripRange(8, 2, LedState.Color2), New LedStripRange(10, 2, LedState.Color2), New LedStripRange(12, 2, LedState.Color3), New LedStripRange(14, 2, LedState.Color3), New LedStripRange(16, 2, LedState.Off)})
        ElseIf MonitoringData.EngineSpeed >= 7900 Then
            device.Set({New LedStripRange(2, 2, LedState.Color1), New LedStripRange(4, 2, LedState.Color1), New LedStripRange(6, 2, LedState.Color1), New LedStripRange(8, 2, LedState.Color2), New LedStripRange(10, 2, LedState.Color2), New LedStripRange(12, 2, LedState.Color3), New LedStripRange(14, 2, LedState.Color3), New LedStripRange(16, 2, LedState.Color3)})
        End If
        device.flushDisplay()
        Return 10
    End Function

    Public Sub OnStart() Implements iCarLedRenderer.OnStart

    End Sub

    Public Function OnColorConfig() As Drawing.Color() Implements iCarLedRenderer.OnColorConfig
        Return {Drawing.Color.FromArgb(0, 10, 10, 10), Drawing.Color.FromArgb(0, 10, 10, 0), Drawing.Color.FromArgb(0, 0, 0, 10)}
    End Function
End Class
