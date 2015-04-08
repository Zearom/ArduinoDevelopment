Imports System.LiehrIt.Arduino

Public Interface iCarLedRenderer
    Function getCarModel() As String
    Sub OnStart()
    Sub OnEnd()
    Function OnIterate(device As LedStripDevice) As Integer
    Function OnColorConfig() As System.Drawing.Color()
End Interface
