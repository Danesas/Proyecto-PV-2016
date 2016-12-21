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

Public Sub New(nombre As String, apellido As String, edad As Integer, usuario As String, clave As String)
        Me.Nombre = nombre
        Me.Apellido = apellido
        Me.Edad = edad
        Me.Usuario = usuario
        Me.Clave = clave
    End Sub

    Public Overrides Function ToString() As String
        Return "nombre: " & Me._nombre & " apellido: " & Me._apellido
    End Function
