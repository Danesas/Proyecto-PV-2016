Public Class Votante
    Inherits Persona

    Private _cedula As String
    Public Property Cedula() As String
        Get
            Return _cedula
        End Get
        Set(ByVal value As String)
            _cedula = value
        End Set
    End Property

    Public Sub New(nombre As String, apellido As String, edad As Integer, cedula As String, rol As String)

        Me.Nombre = nombre
        Me.Apellido = apellido
        Me.Edad = edad
        Me.Cedula = cedula
        Me.Rol = rol
    End Sub

    Public Overrides Function ToString() As String
        Return "nombre: " & Me.Nombre & " apellido: " & Me.Apellido & " edad: " & Me.Edad & " cedula: " & Me.Cedula
    End Function

End Class
