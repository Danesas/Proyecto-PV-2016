Public Class Candidatos
    inherits Persona
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

    Private _dignidad As String
    Public Property Dignidad() As String
        Get
            Return _dignidad
        End Get
        Set(ByVal value As String)
            _dignidad = value
        End Set
    End Property
    
    Private _voto As Integer
    Public Property Voto() As String
        Get
            Return _voto
        End Get
        Set(ByVal value As String)
            _voto = value
        End Set
    End Property
    
    
    Public Sub New(nombre As String, apellido As String, edad As Integer, usuario As String, clave As String, dignidad As String, voto As Integer, rol As String)
        Me.Nombre = nombre
        Me.Apellido = apellido
        Me.Edad = edad
        Me.Usuario = usuario
        Me.Clave = clave
        Me.Dignidad = dignidad
        Me.Voto = voto
        Me.Rol = rol
    End Sub


    Public Overrides Function ToString() As String
        Return "nombre: " & Me.Nombre & " apellido: " & Me.Apellido
    End Function
End Class
