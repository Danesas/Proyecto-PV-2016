Public Class Persona
    Private _nombre As String
    Public Property Nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

    Private _apellido As String
    Public Property Apellido() As String
        Get
            Return _apellido
        End Get
        Set(ByVal value As String)
            _apellido = value
        End Set
    End Property

    Private _edad As Integer
    Public Property Edad() As Integer
        Get
            Return _edad
        End Get
        Set(ByVal value As Integer)
            _edad = value
        End Set
    End Property

End Class
