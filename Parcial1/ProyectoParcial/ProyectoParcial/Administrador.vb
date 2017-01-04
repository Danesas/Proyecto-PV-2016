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

    Private _clave As String
    Public Property Clave() As String
        Get
            Return _clave
        End Get
        Set(ByVal value As String)
            _clave = value
        End Set
    End Property

    Sub New(usuario As String, clave As String)
        _usuario = usuario
        _clave = clave
    End Sub

    Public Sub New(nombre As String, apellido As String, edad As Integer, usuario As String, clave As String, rol As String)
        Me.Nombre = nombre
        Me.Apellido = apellido
        Me.Edad = edad
        Me.Usuario = usuario
        Me.Clave = clave
        Me.Rol = rol
    End Sub

    Public Overrides Function ToString() As String
        Return "nombre: " & Me._nombre & " apellido: " & Me._apellido
    End Function
    
End Class
