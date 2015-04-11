Imports System.LiehrIt.Arduino
Imports System.LiehrIt.Arduino.LedStripDevice

Public Class CarRendererMcLarenMP412CGT3
    Implements iCarLedRenderer

    Public Function getCarModel() As String Implements iCarLedRenderer.getCarModel
        Return "mclaren_mp412c_gt3"
    End Function

    Public Sub OnEnd() Implements iCarLedRenderer.OnEnd

    End Sub

    Private lastState As Integer = -1
    Private durationState As Integer = 0

    Private Function isNewState(state As Integer) As Boolean
        Dim result As Boolean = False
        If (lastState = state) Then
            durationState += 1
        Else
            lastState = state
            durationState = 0
            result = True
        End If
        Return result
    End Function


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
        If MonitoringData.EngineSpeed < 6100 Then
            isNewState(0)
            device.Set({New LedStripRange(0, 20, LedState.Off)})
        ElseIf MonitoringData.EngineSpeed >= 6100 And MonitoringData.EngineSpeed < 6250 Then
            isNewState(1)
            device.Set({New LedStripRange(0, 20, LedState.Off), New LedStripRange(8, 1, LedState.Color1)})
        ElseIf MonitoringData.EngineSpeed >= 6250 And MonitoringData.EngineSpeed < 6400 Then
            isNewState(2)
            device.Set({New LedStripRange(0, 20, LedState.Off), New LedStripRange(8, 2, LedState.Color1)})
        ElseIf MonitoringData.EngineSpeed >= 6400 And MonitoringData.EngineSpeed < 6500 Then
            isNewState(3)
            device.Set({New LedStripRange(0, 20, LedState.Off), New LedStripRange(8, 3, LedState.Color1)})
        ElseIf MonitoringData.EngineSpeed >= 6500 And MonitoringData.EngineSpeed < 6600 Then
            isNewState(4)
            device.Set({New LedStripRange(0, 20, LedState.Off), New LedStripRange(8, 4, LedState.Color1)})
        ElseIf MonitoringData.EngineSpeed >= 6600 And MonitoringData.EngineSpeed < 6700 Then
            isNewState(5)
            device.Set({New LedStripRange(0, 20, LedState.Off), New LedStripRange(8, 4, LedState.Color1), New LedStripRange(12, 1, LedState.Color2)})
        ElseIf MonitoringData.EngineSpeed >= 6700 And MonitoringData.EngineSpeed < 6800 Then
            isNewState(6)
            device.Set({New LedStripRange(0, 20, LedState.Off), New LedStripRange(8, 4, LedState.Color1), New LedStripRange(12, 2, LedState.Color2)})
        ElseIf MonitoringData.EngineSpeed >= 6800 And MonitoringData.EngineSpeed < 6900 Then
            isNewState(7)
            device.Set({New LedStripRange(0, 20, LedState.Off), New LedStripRange(8, 4, LedState.Color1), New LedStripRange(12, 3, LedState.Color2)})
        ElseIf MonitoringData.EngineSpeed >= 6900 And MonitoringData.EngineSpeed < 7100 Then
            isNewState(8)
            device.Set({New LedStripRange(0, 20, LedState.Off), New LedStripRange(8, 4, LedState.Color1), New LedStripRange(12, 4, LedState.Color2)})
        ElseIf MonitoringData.EngineSpeed >= 7100 And MonitoringData.EngineSpeed < 7450 Then
            isNewState(9)
            device.Set({New LedStripRange(0, 20, LedState.Off), New LedStripRange(8, 4, LedState.Color1), New LedStripRange(12, 4, LedState.Color2), New LedStripRange(16, 4, LedState.Color3)})
        ElseIf MonitoringData.EngineSpeed >= 7450 Then
            If isNewState(10) Then
                device.Set({New LedStripRange(0, 20, LedState.Off), New LedStripRange(8, 4, LedState.Color1), New LedStripRange(12, 4, LedState.Color2), New LedStripRange(16, 4, LedState.Color3)})
            Else
                If (((Me.durationState / 5) Mod 2) = 0) Then
                    device.Set({New LedStripRange(0, 20, LedState.Off), New LedStripRange(8, 4, LedState.Color1), New LedStripRange(12, 4, LedState.Color2), New LedStripRange(16, 4, LedState.Color3)})
                    'device.Set({New LedStripRange(8, 12, LedState.Color2)})
                ElseIf (((Me.durationState / 5) Mod 2) = 1) Then
                    device.Set({New LedStripRange(0, 20, LedState.Off), New LedStripRange(8, 4, LedState.Color1), New LedStripRange(12, 4, LedState.Color2), New LedStripRange(16, 4, LedState.Off)})
                    'device.Set({New LedStripRange(8, 12, LedState.Off)})
                End If
            End If
        End If

        If (MonitoringData.GearBoxGear = 0) Then
            'reverse
            device.Set({New LedStripRange(0, 6, LedState.Off), New LedStripRange(0, 1, LedState.Color2)})
        ElseIf (MonitoringData.GearBoxGear = 1) Then
            device.Set({New LedStripRange(0, 6, LedState.Off), New LedStripRange(0, 1, LedState.Color3)})
        ElseIf (MonitoringData.GearBoxGear = 2) Then
            device.Set({New LedStripRange(0, 6, LedState.Off), New LedStripRange(0, 1, LedState.Color1)})
        ElseIf (MonitoringData.GearBoxGear = 3) Then
            device.Set({New LedStripRange(0, 6, LedState.Off), New LedStripRange(0, 2, LedState.Color1)})
        ElseIf (MonitoringData.GearBoxGear = 4) Then
            device.Set({New LedStripRange(0, 6, LedState.Off), New LedStripRange(0, 3, LedState.Color1)})
        ElseIf (MonitoringData.GearBoxGear = 5) Then
            device.Set({New LedStripRange(0, 6, LedState.Off), New LedStripRange(0, 4, LedState.Color1)})
        ElseIf (MonitoringData.GearBoxGear = 6) Then
            device.Set({New LedStripRange(0, 6, LedState.Off), New LedStripRange(0, 5, LedState.Color1)})
        ElseIf (MonitoringData.GearBoxGear = 7) Then
            device.Set({New LedStripRange(0, 6, LedState.Off), New LedStripRange(0, 6, LedState.Color2)})
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
