Public Class LedStripRange
    Public Property Start As Integer
    Public Property Length As Integer
    Public Property LedState As LedStripDevice.LedState

    Public Sub New(start As Integer, length As Integer, ledState As LedStripDevice.LedState)
        Me.Start = start
        Me.Length = length
        Me.LedState = ledState
    End Sub
End Class
