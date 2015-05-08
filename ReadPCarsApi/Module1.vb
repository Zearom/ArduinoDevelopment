Imports System.IO

Module Module1

    Sub Main()
        Dim pcarsApiFile As System.IO.MemoryMappedFiles.MemoryMappedFile = System.IO.MemoryMappedFiles.MemoryMappedFile.OpenExisting("$pcars$")
        Dim physicObject As IO.MemoryMappedFiles.MemoryMappedViewStream = pcarsApiFile.CreateViewStream()
        Dim reader As BinaryReader = New BinaryReader(physicObject)
        Dim bytes As Byte() = reader.ReadBytes(1)
    End Sub

End Module
