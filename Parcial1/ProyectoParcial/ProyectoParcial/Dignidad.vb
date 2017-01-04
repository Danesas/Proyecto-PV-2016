Public Class Dignidad

    Private _nombreDig As String
    Public Property NombreDig() As String
        Get
            Return _nombreDig
        End Get
        Set(ByVal value As String)
            _nombreDig = value
        End Set
    End Property

    Public Sub New(nombreDig As String)
        Me.NombreDig = nombreDig
    End Sub

    Public Overrides Function ToString() As String
        Return "nombre: " & Me.NombreDig
    End Function

End Class
