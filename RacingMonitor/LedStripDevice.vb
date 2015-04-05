Public Class LedStripDevice
    Public Enum LedState As Integer
        Off = 0
        Color1 = 1
        Color2 = 2
        Color3 = 3
    End Enum

    Private ledStates As ArrayList = New ArrayList
    Private serialPort As System.IO.Ports.SerialPort = Nothing

    Public Sub New(ledStripSize As Integer, serialPort As System.IO.Ports.SerialPort)
        For i As Integer = 0 To ledStripSize - 1
            ledStates.Add(LedState.Off)
        Next

        Me.serialPort = serialPort
    End Sub

    Public Property State(Optional index As Integer = 0) As LedState
        Get
            Return Me.ledStates(index)
        End Get
        Set(value As LedState)
            Me.ledStates(index) = value
        End Set
    End Property

    Public Function flushDisplay() As Boolean
        Dim result As Boolean = True
        If (Me.serialPort.IsOpen = False) Then
            Me.serialPort.Open()
        End If

        Me.serialPort.Write(Me.getDisplayByteArray(), 0, 6)

        Return result
    End Function

    Public Sub SetStates(values As LedState(), Optional restOfLedState As LedState = Nothing)
        For i As Integer = 0 To values.Length - 1
            Me.State(i) = values(i)
        Next

        If (Not IsNothing(restOfLedState) And (values.Length < Me.ledStates.Count)) Then
            For i As Integer = values.Length To Me.ledStates.Count
                Me.State(i - 1) = restOfLedState
            Next
        End If
    End Sub

    Public Sub SetAllLeds(ledState As LedState)
        For i As Integer = 0 To Me.ledStates.Count - 1
            ledStates(i) = ledState
        Next
    End Sub

    Public Function disconnect()
        If (Me.serialPort.IsOpen = True) Then
            Me.serialPort.Close()
        End If
    End Function

    Public Function getDisplayByteArray() As Byte()
        Dim result(6) As Byte
        Dim byteIndex As Integer = 0
        For i As Integer = 0 To ledStates.Count - 4 Step 4
            Dim bitArray As BitArray = New BitArray(8)
            bitArray.Set(0, Me.convertLedStateToBooleanArray(Me.ledStates(i))(0))
            bitArray.Set(1, Me.convertLedStateToBooleanArray(Me.ledStates(i))(1))
            bitArray.Set(2, Me.convertLedStateToBooleanArray(Me.ledStates(i + 1))(0))
            bitArray.Set(3, Me.convertLedStateToBooleanArray(Me.ledStates(i + 1))(1))
            bitArray.Set(4, Me.convertLedStateToBooleanArray(Me.ledStates(i + 2))(0))
            bitArray.Set(5, Me.convertLedStateToBooleanArray(Me.ledStates(i + 2))(1))
            bitArray.Set(6, Me.convertLedStateToBooleanArray(Me.ledStates(i + 3))(0))
            bitArray.Set(7, Me.convertLedStateToBooleanArray(Me.ledStates(i + 3))(1))
            result(byteIndex + 1) = convertBitArrayToByte(bitArray)

            byteIndex += 1
        Next

        result(0) = 2

        Return result
    End Function

    Private Function convertLedStateToBooleanArray(value As LedState) As Boolean()
        Select Case value
            Case LedState.Color1
                Return {True, False}
            Case LedState.Color2
                Return {False, True}
            Case LedState.Color3
                Return {True, True}
            Case Else
                Return {False, False}
        End Select
    End Function

    Private Function convertBitArrayToByte(value As BitArray) As Byte
        If (value.Length < 8) Then
            Throw New ArgumentException("Not enough bits to convert to one byte")
        End If

        Dim result(1) As Byte

        value.CopyTo(result, 0)

        Return result(0)
    End Function
End Class
