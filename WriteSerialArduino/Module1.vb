Imports System.IO.Ports

Module Module1

    Sub Main()
        Dim SerialPort1 As System.IO.Ports.SerialPort = New System.IO.Ports.SerialPort

        SerialPort1.Close()
        SerialPort1.PortName = "com3" 'change com port to match your Arduino port
        SerialPort1.BaudRate = 19200
        SerialPort1.DataBits = 8
        SerialPort1.Parity = Parity.None
        SerialPort1.StopBits = StopBits.One
        SerialPort1.Handshake = Handshake.None
        SerialPort1.Encoding = System.Text.Encoding.Default 'very important!

        While True
            Console.Write(">")

            Dim byteLength As Integer = 8

            Dim currentCommand As String = Console.ReadLine()
            Console.WriteLine(String.Format("Sending ""{0}""", currentCommand))

            If (currentCommand = "seq") Then
                SerialPort1.Open()
                SerialPort1.Write(Module1.getLed(False, False, False, False, False, False, False, False, False, False, False), 0, byteLength)
                Threading.Thread.Sleep(200)
                SerialPort1.Write(Module1.getLed(True, False, False, False, False, False, False, False, False, False, False), 0, byteLength)
                Threading.Thread.Sleep(200)
                SerialPort1.Write(Module1.getLed(True, True, False, False, False, False, False, False, False, False, False), 0, byteLength)
                Threading.Thread.Sleep(200)
                SerialPort1.Write(Module1.getLed(True, True, True, False, False, False, False, False, False, False, False), 0, byteLength)
                Threading.Thread.Sleep(200)
                SerialPort1.Write(Module1.getLed(True, True, True, True, False, False, False, False, False, False, False), 0, byteLength)
                Threading.Thread.Sleep(200)
                SerialPort1.Write(Module1.getLed(True, True, True, True, True, False, False, False, False, False, False), 0, byteLength)
                Threading.Thread.Sleep(200)
                SerialPort1.Write(Module1.getLed(True, True, True, True, True, True, False, False, False, False, False), 0, byteLength)
                Threading.Thread.Sleep(200)
                SerialPort1.Write(Module1.getLed(True, True, True, True, True, True, True, False, False, False, False), 0, byteLength)
                Threading.Thread.Sleep(200)
                SerialPort1.Write(Module1.getLed(True, True, True, True, True, True, True, True, False, False, False), 0, byteLength)
                Threading.Thread.Sleep(200)
                SerialPort1.Write(Module1.getLed(True, True, True, True, True, True, True, True, True, False, False), 0, byteLength)
                Threading.Thread.Sleep(200)
                SerialPort1.Write(Module1.getLed(True, True, True, True, True, True, True, True, True, True, False), 0, byteLength)
                Threading.Thread.Sleep(200)
                SerialPort1.Write(Module1.getLed(True, True, True, True, True, True, True, True, True, True, True), 0, byteLength)
                Threading.Thread.Sleep(200)
                SerialPort1.Write(Module1.getLed(False, False, False, False, False, False, False, False, False, False, False), 0, byteLength)
                SerialPort1.Close()
            ElseIf currentCommand = "seq0" Then
                SerialPort1.Open()
                For i As Integer = 0 To 10
                    SerialPort1.Write(Module1.getLed(False, False, False, False, False, False, False, False, False, False, False), 0, byteLength)
                    Threading.Thread.Sleep(10)
                    SerialPort1.Write(Module1.getLed(True, False, False, False, False, False, False, False, False, False, False), 0, byteLength)
                    Threading.Thread.Sleep(10)
                    SerialPort1.Write(Module1.getLed(False, True, False, False, False, False, False, False, False, False, False), 0, byteLength)
                    Threading.Thread.Sleep(10)
                    SerialPort1.Write(Module1.getLed(False, False, True, False, False, False, False, False, False, False, False), 0, byteLength)
                    Threading.Thread.Sleep(10)
                    SerialPort1.Write(Module1.getLed(False, False, False, True, False, False, False, False, False, False, False), 0, byteLength)
                    Threading.Thread.Sleep(10)
                    SerialPort1.Write(Module1.getLed(False, False, False, False, True, False, False, False, False, False, False), 0, byteLength)
                    Threading.Thread.Sleep(10)
                    SerialPort1.Write(Module1.getLed(False, False, False, False, False, True, False, False, False, False, False), 0, byteLength)
                    Threading.Thread.Sleep(10)
                    SerialPort1.Write(Module1.getLed(False, False, False, False, False, False, True, False, False, False, False), 0, byteLength)
                    Threading.Thread.Sleep(10)
                    SerialPort1.Write(Module1.getLed(False, False, False, False, False, False, False, True, False, False, False), 0, byteLength)
                    Threading.Thread.Sleep(10)
                    SerialPort1.Write(Module1.getLed(False, False, False, False, False, False, False, False, True, False, False), 0, byteLength)
                    Threading.Thread.Sleep(10)
                    SerialPort1.Write(Module1.getLed(False, False, False, False, False, False, False, False, False, True, False), 0, byteLength)
                    Threading.Thread.Sleep(10)
                    SerialPort1.Write(Module1.getLed(False, False, False, False, False, False, False, False, False, False, True), 0, byteLength)
                    Threading.Thread.Sleep(10)
                    SerialPort1.Write(Module1.getLed(False, False, False, False, False, False, False, False, False, True, False), 0, byteLength)
                    Threading.Thread.Sleep(10)
                    SerialPort1.Write(Module1.getLed(False, False, False, False, False, False, False, False, True, False, False), 0, byteLength)
                    Threading.Thread.Sleep(10)
                    SerialPort1.Write(Module1.getLed(False, False, False, False, False, False, False, True, False, False, False), 0, byteLength)
                    Threading.Thread.Sleep(10)
                    SerialPort1.Write(Module1.getLed(False, False, False, False, False, False, True, False, False, False, False), 0, byteLength)
                    Threading.Thread.Sleep(10)
                    SerialPort1.Write(Module1.getLed(False, False, False, False, False, True, False, False, False, False, False), 0, byteLength)
                    Threading.Thread.Sleep(10)
                    SerialPort1.Write(Module1.getLed(False, False, False, False, True, False, False, False, False, False, False), 0, byteLength)
                    Threading.Thread.Sleep(10)
                    SerialPort1.Write(Module1.getLed(False, False, False, True, False, False, False, False, False, False, False), 0, byteLength)
                    Threading.Thread.Sleep(10)
                    SerialPort1.Write(Module1.getLed(False, False, True, False, False, False, False, False, False, False, False), 0, byteLength)
                    Threading.Thread.Sleep(10)
                    SerialPort1.Write(Module1.getLed(False, True, False, False, False, False, False, False, False, False, False), 0, byteLength)
                    Threading.Thread.Sleep(10)
                    SerialPort1.Write(Module1.getLed(True, False, False, False, False, False, False, False, False, False, False), 0, byteLength)
                Next

                SerialPort1.Close()
            ElseIf currentCommand = "b" Then
                SerialPort1.Open()
                SerialPort1.Write(Module1.getLed(False, False, False, False, False, False, False, False, False, False, False), 0, 3)
                SerialPort1.Close()
            ElseIf currentCommand = "b0" Then
                SerialPort1.Open()
                SerialPort1.Write(Module1.getLed(True, True, True, False, False, False, False, False, False, False, False), 0, 3)
                SerialPort1.Close()
            ElseIf currentCommand = "b1" Then
                SerialPort1.Open()
                SerialPort1.Write(Module1.getLed(True, True, True, True, True, True, True, False, False, False, False), 0, 3)
                SerialPort1.Close()
            ElseIf currentCommand = "b2" Then
                SerialPort1.Open()
                SerialPort1.Write(Module1.getLed(True, True, True, True, True, True, True, True, True, True, False), 0, 3)
                SerialPort1.Close()
            ElseIf currentCommand = "b3" Then
                SerialPort1.Open()
                SerialPort1.Write(Module1.getLed(True, True, True, True, True, True, True, True, True, True, True), 0, 3)
                SerialPort1.Close()
            Else
                SerialPort1.Open()
                SerialPort1.Write(currentCommand)
                SerialPort1.Close()
            End If





            If currentCommand = "!quit" Then

                Exit While
            End If
        End While
    End Sub

    Public Function getLed(green1 As Boolean, green2 As Boolean, green3 As Boolean, orange1 As Boolean, orange2 As Boolean, orange3 As Boolean, orange4 As Boolean, red1 As Boolean, red2 As Boolean, red3 As Boolean, blue1 As Boolean) As Byte()
        Dim buffer(7) As Byte

        buffer(0) = Module1.getLedRow(green1, green2, green3, orange1, orange2, orange3, orange4, red1)
        buffer(1) = Module1.getLedRow(red2, red3, False, False, False, False, False, False)
        buffer(2) = Module1.getLedRow(blue1, blue1, blue1, blue1, blue1, blue1, blue1, blue1)
        buffer(3) = Module1.getLedRow(False, False, False, False, False, False, False, False)
        buffer(4) = Module1.getLedRow(False, False, False, False, False, False, False, False)
        buffer(5) = Module1.getLedRow(False, False, False, False, False, False, False, False)
        buffer(6) = Module1.getLedRow(False, False, False, False, False, False, False, False)
        buffer(7) = Module1.getLedRow(False, False, False, False, False, False, False, False)

        Return buffer
    End Function

    Public Function getLedRow(led1 As Boolean, led2 As Boolean, led3 As Boolean, led4 As Boolean, led5 As Boolean, led6 As Boolean, led7 As Boolean, led8 As Boolean) As Byte
        Dim result As Int16 = 0

        If led1 Then
            result += 1
        End If
        If led2 Then
            result += 2
        End If
        If led3 Then
            result += 4
        End If
        If led4 Then
            result += 8
        End If
        If led5 Then
            result += 16
        End If
        If led6 Then
            result += 32
        End If
        If led7 Then
            result += 64
        End If
        If led8 Then
            result += 128
        End If

        Return Convert.ToByte(result)
    End Function

End Module
