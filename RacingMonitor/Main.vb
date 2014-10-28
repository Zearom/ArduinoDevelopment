Imports System.Threading

Public Class Main
    Private displayThread As Thread = Nothing

    Public Sub New()
        Me.displayThread = New Thread(AddressOf DoDisplayThread)
    End Sub

    Public Sub Main()
        Dim arduinoController As ArduinoShiftLedController = New ArduinoShiftLedController
        displayThread.Start(arduinoController)

        While True
            MonitoringData.EngineSpeed = Convert.ToInt32(Console.ReadLine)
        End While

        MonitoringData.State = -1
    End Sub

    Public Sub DoDisplayThread(controller As iController)
        controller.OnStart()

        While True
            Dim delay As Integer = controller.OnIterate()

            If delay < 0 Then
                Exit While
            ElseIf delay < 10 Then
                delay = 10
            End If

            Thread.Sleep(delay)
        End While


        controller.OnEnd()
    End Sub
End Class
