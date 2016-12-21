Module Module1

    Dim nombre As String = ""
    Dim apellido As String = ""
    Dim edad As Integer = 0
    Dim usuario As String = ""
    Dim clave As String = ""
    Dim dignidad As String = ""
    Dim cedula As String = ""
    Dim administradores = New ArrayList()
    Dim candidatos = New ArrayList()
    Dim votantes = New ArrayList()
    Dim a1 As Administrador
    Dim c1 As Candidatos
    Dim v1 As Votante
     
     Enum OpMain
        Invalid
        Adm
        Vot
        Can
        Out
    End Enum

    Enum OpLoginAdm
        User = 1
        Pass
        Out
    End Enum

    Enum OpLoginVot
        Ced = 1
        Out
    End Enum

    Enum OpLoginCan
        User = 1
        Pass
        Dig
        Out
    End Enum
     
    Dim path As String = "..\..\personas.xml" 
    
    Sub Main()
        guardarDatos(path, administradores, candidatos, votantes)
        mostrarDatos(administradores, candidatos, votantes)
        Dim op As String = ""
        Dim opcion As Byte

        Do
            MenuPrincipal()

            op = Console.ReadLine()

            Try
                opcion = CByte(op) 'Byte.parse()
            Catch ex As OverflowException
                opcion = 255
            Catch ex As Exception
                opcion = OpMain.Invalid
            End Try



            Console.WriteLine("Usted ha ingresado: {0}", op)
            Console.ReadLine()

            Select Case opcion
                Case OpMain.Adm
                    Console.WriteLine("Administrador")
                    ManejarLoginAdm()
                Case OpMain.Vot
                    Console.WriteLine("Votante")
                    ManejarLoginVot()
                Case OpMain.Can
                    Console.WriteLine("Candidato")
                    ManejarLoginCan()
                Case OpMain.Out
                    Console.WriteLine("Cerrando Aplicación")
                Case Else
                    Console.WriteLine("XXXXX OPCION INVALIDA XXXXX")
            End Select
        Loop Until opcion = OpMain.Out
        Console.WriteLine("Gracias, bye")
        Console.ReadLine()

    End Sub
    
    Private Sub guardarDatos(path As String, administradores As ArrayList, candidatos As ArrayList, votantes As ArrayList)
        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load(path)
        Dim raiz As XmlNodeList = xmlDoc.GetElementsByTagName("persona")
        For Each nodo As XmlNode In raiz
            'administradores = New ArrayList()
            candidatos = New ArrayList()
            votantes = New ArrayList()
            For Each personas As XmlNode In nodo.ChildNodes

                For Each persona As XmlNode In personas.ChildNodes
                    If nodo.HasChildNodes Then

                        If persona.Name = "nombre" Then
                            nombre = persona.FirstChild.InnerText
                        End If
                        If persona.Name = "apellido" Then
                            apellido = persona.InnerText
                        End If
                        If persona.Name = "edad" Then
                            edad = persona.InnerText
                        End If
                        If persona.Name = "usuario" Then
                            usuario = persona.InnerText
                        End If
                        If persona.Name = "clave" Then
                            clave = persona.InnerText
                        End If

                        If persona.Name = "cedula" Then
                            cedula = persona.InnerText
                        End If

                        If persona.Name = "dignidad" Then
                            dignidad = persona.InnerText
                        End If

                    End If


                Next
                Dim roles As XmlNodeList = xmlDoc.GetElementsByTagName("rol")
                For Each rol As XmlNode In roles

                    For Each child As XmlNode In rol.ChildNodes
                        If rol.Attributes("tipo").Value = "Administrador" Then
                            a1 = New Administrador(nombre, apellido, edad, usuario, clave)
                            administradores.Add(a1)

                        End If
                    Next
                    For Each child As XmlNode In rol.ChildNodes
                        If rol.Attributes("tipo").Value = "Candidato" Then
                            c1 = New Candidatos(nombre, apellido, edad, usuario, clave, dignidad)
                            candidatos.Add(c1)

                        End If
                    Next
                    For Each child As XmlNode In rol.ChildNodes
                        If rol.Attributes("tipo").Value = "Votante" Then
                            v1 = New Votante(nombre, apellido, edad, cedula)
                            votantes.Add(v1)

                        End If
                    Next
                Next

                Next

        Next

            For Each a As Votante In votantes
                Console.WriteLine("Administrador")
                Console.WriteLine(a)
            Next
            For Each c As Candidatos In candidatos
                Console.WriteLine(c)
            Next
            For Each v As Votante In votantes
                Console.WriteLine(v)
            Next
    End Sub

    Private Sub mostrarDatos(administradores As ArrayList, candidatos As ArrayList, votantes As ArrayList)
        administradores = New ArrayList()
        candidatos = New ArrayList()
        votantes = New ArrayList()
        For Each a As Administrador In administradores
            Console.WriteLine(a)
        Next
        For Each c As Candidatos In candidatos
            Console.WriteLine(c)
        Next
        For Each v As Votante In votantes
            Console.WriteLine(v)
        Next
    End Sub
     
     
     Sub MenuPrincipal()
        Console.WriteLine("{0}. Administrador", CInt(OpMain.Adm))
        Console.WriteLine("{0}. Votante", CInt(OpMain.Vot))
        Console.WriteLine("{0}. Candidato", CInt(OpMain.Can))
        Console.WriteLine("{0}. Regresar al menú principal", CInt(OpMain.Out))
    End Sub

    Sub MenuLoginAdm()
        Console.WriteLine("{0}. Ingresar Usuario", CInt(OpLoginAdm.User))
        Console.WriteLine("{0}. Ingresar Clave", CInt(OpLoginAdm.Pass))
        Console.WriteLine("{0}. Regresar al menú principal", CInt(OpLoginAdm.Out))
    End Sub

    Sub MenuLoginVot()
        Console.WriteLine("{0}. Ingresar Su Cédula de Identidad", CInt(OpLoginVot.Ced))
        Console.WriteLine("{0}. Regresar al menú principal", CInt(OpLoginVot.Out))
    End Sub
    
    Sub ManejarLoginAdm()
        Dim op As String = ""
        Dim opcion As Byte
        Dim user As String
        Dim pass As String
        Do
            MenuLoginAdm()

            op = Console.ReadLine()
            opcion = CByte(op) 'Byte.parse()

            Console.WriteLine("Usted ha ingresado: {0}", op)
            Console.ReadLine()

            Select Case opcion
                Case OpLoginAdm.User
                    Console.WriteLine("Usuario:")
                    user = Console.ReadLine()
                    'Console.WriteLine("usuario correcto")
                    For Each a As Administrador In administradores

                        If user = a.Usuario Then
                            Console.WriteLine("usuario correcto")
                            Exit For
                        Else
                            Console.WriteLine("usuario incorrecto")

                        End If

                    Next
                Case OpLoginAdm.Pass
                    Console.WriteLine("Clave")
                    pass = Console.ReadLine()
                Case OpLoginAdm.Out
                    Console.WriteLine("Volver al menú principal")
                Case Else
                    Console.WriteLine("XXXXX OPCION INVALIDA XXXXX")
            End Select
        Loop Until opcion = OpLoginAdm.Out
    End Sub

    Sub ManejarLoginVot()
        Dim op As String = ""
        Dim opcion As Byte
        Dim user As String
        Do
            MenuLoginVot()

            op = Console.ReadLine()
            opcion = CByte(op) 'Byte.parse()

            Console.WriteLine("Usted ha ingresado: {0}", op)
            Console.ReadLine()

            Select Case opcion
                Case OpLoginVot.Ced
                    Console.WriteLine("Cedula:")
                    user = Console.ReadLine()
                Case OpLoginVot.Out
                    Console.WriteLine("Volver al menú principal")
                Case Else
                    Console.WriteLine("XXXXX OPCION INVALIDA XXXXX")
            End Select
        Loop Until opcion = OpLoginVot.Out
    End Sub

End Module
