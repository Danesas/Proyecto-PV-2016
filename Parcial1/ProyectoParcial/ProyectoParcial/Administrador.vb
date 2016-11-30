Public Class Administrador
    Inherits Persona

    Private _usuario As String
    Public Property Usuario() As String
        Get
            Return _usuario
        End Get
        Set(ByVal value As String)
            _usuario = value
        End Set
    End Property

    Private clave As String
    Public Property NewProperty() As String
        Get
            Return clave
        End Get
        Set(ByVal value As String)
            clave = value
        End Set
    End Property
End Class
