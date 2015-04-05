Imports System.IO.Ports

Module Module1

    Sub Main()
        Dim SerialPort1 As System.IO.Ports.SerialPort = New System.IO.Ports.SerialPort

        SerialPort1.Close()
        SerialPort1.PortName = "com4" 'change com port to match your Arduino port
        SerialPort1.BaudRate = 9600
        SerialPort1.DataBits = 8
        SerialPort1.Parity = Parity.None
        SerialPort1.StopBits = StopBits.One
        SerialPort1.Handshake = Handshake.None
        SerialPort1.Encoding = System.Text.Encoding.Default 'very important!

        Dim device As LedStripDevice = New LedStripDevice(20, SerialPort1)

        While True


            Console.Write(">")

            Dim byteLength As Integer = 4

            Dim currentCommand As String = Console.ReadLine()
            Console.WriteLine(String.Format("Sending ""{0}""", currentCommand))




            If (currentCommand = "seq") Then
                device.SetAllLeds(LedStripDevice.LedState.Off)
                device.flushDisplay()
                Threading.Thread.Sleep(200)
                device.SetAllLeds(LedStripDevice.LedState.Color1)
                device.flushDisplay()
                Threading.Thread.Sleep(200)
                device.SetAllLeds(LedStripDevice.LedState.Color2)
                device.flushDisplay()
                Threading.Thread.Sleep(200)
                device.SetAllLeds(LedStripDevice.LedState.Color3)
                device.flushDisplay()
                Threading.Thread.Sleep(5000)
                device.SetAllLeds(LedStripDevice.LedState.Off)
                device.flushDisplay()
            ElseIf (currentCommand = "seq1") Then
                For delay As Integer = 50 To 5 Step -5
                    device.SetAllLeds(LedStripDevice.LedState.Off)
                    device.flushDisplay()

                    For i As Integer = 2 To 19
                        If (i < 8) Then
                            device.State(i) = (LedStripDevice.LedState.Color1)
                        ElseIf (i < 14) Then
                            device.State(i) = (LedStripDevice.LedState.Color2)
                        Else
                            device.State(i) = (LedStripDevice.LedState.Color3)
                        End If
                        device.flushDisplay()
                        Threading.Thread.Sleep(delay)
                    Next

                    Threading.Thread.Sleep(200)

                    For i As Integer = 19 To 2 Step -1
                        device.State(i) = (LedStripDevice.LedState.Off)
                        device.flushDisplay()
                        Threading.Thread.Sleep(delay)
                    Next
                Next

            Else
                device.State(0) = LedStripDevice.LedState.Color1
                device.State(1) = LedStripDevice.LedState.Color2
                device.State(2) = LedStripDevice.LedState.Color3
                device.State(3) = LedStripDevice.LedState.Off
                device.State(4) = LedStripDevice.LedState.Color3
                device.State(5) = LedStripDevice.LedState.Color2
                device.State(6) = LedStripDevice.LedState.Color1
                device.flushDisplay()
            End If
            If currentCommand = "!quit" Then
                device.disconnect()
                Exit While
            End If
        End While
    End Sub
End Module
