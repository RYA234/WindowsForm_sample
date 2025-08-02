

Public Structure Customer
        Public ReadOnly Property Id As Long
        Public ReadOnly Property Name As String

        Public Sub New(id As Long, name As String)
            Me.Id = id
            Me.Name = name
        End Sub
    End Structure
