Imports System.LiehrIt.Arduino
Imports System.LiehrIt.Arduino.LedStripDevice

Public Class CarRendererFerrariLaFerrari
    Implements iCarLedRenderer

    Public Function getCarModel() As String Implements iCarLedRenderer.getCarModel
        Return "ferrari_laferrari"
    End Function

    Public Sub OnEnd() Implements iCarLedRenderer.OnEnd

    End Sub

    Public Function OnIterate(device As LedStripDevice) As Integer Implements iCarLedRenderer.OnIterate

        '5500 -> rote LED
        '6500 -> rote LED
        '7000 -> rote LED
        '7800 -> rote LED
        '8800 -> rote LED

        If MonitoringData.EngineSpeed < 5500 Then
            device.SetAllLeds(LedState.Off)
        ElseIf MonitoringData.EngineSpeed >= 5500 And MonitoringData.EngineSpeed < 6500 Then
            device.Set({New LedStripRange(0, 20, LedState.Off), New LedStripRange(1, 2, LedState.Color1)})
        ElseIf MonitoringData.EngineSpeed >= 6500 And MonitoringData.EngineSpeed < 7000 Then
            device.Set({New LedStripRange(0, 20, LedState.Off), New LedStripRange(1, 2, LedState.Color1), New LedStripRange(5, 2, LedState.Color1)})
        ElseIf MonitoringData.EngineSpeed >= 7000 And MonitoringData.EngineSpeed < 7800 Then
            device.Set({New LedStripRange(0, 20, LedState.Off), New LedStripRange(1, 2, LedState.Color1), New LedStripRange(5, 2, LedState.Color1), New LedStripRange(9, 2, LedState.Color1)})
        ElseIf MonitoringData.EngineSpeed >= 7800 And MonitoringData.EngineSpeed < 8800 Then
            device.Set({New LedStripRange(0, 20, LedState.Off), New LedStripRange(1, 2, LedState.Color1), New LedStripRange(5, 2, LedState.Color1), New LedStripRange(9, 2, LedState.Color1), New LedStripRange(13, 2, LedState.Color1)})
        ElseIf MonitoringData.EngineSpeed >= 8800 Then
            device.Set({New LedStripRange(0, 20, LedState.Off), New LedStripRange(1, 2, LedState.Color1), New LedStripRange(5, 2, LedState.Color1), New LedStripRange(9, 2, LedState.Color1), New LedStripRange(13, 2, LedState.Color1), New LedStripRange(17, 2, LedState.Color1)})
        End If
        device.flushDisplay()


        Return 10
    End Function

    Public Sub OnStart() Implements iCarLedRenderer.OnStart

    End Sub

    Public Function OnColorConfig() As Drawing.Color() Implements iCarLedRenderer.OnColorConfig
        Return {Drawing.Color.FromArgb(0, 30, 0, 0), Drawing.Color.FromArgb(0, 0, 0, 0), Drawing.Color.FromArgb(0, 0, 0, 0)}
    End Function
End Class
