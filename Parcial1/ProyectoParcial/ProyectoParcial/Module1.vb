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
        Usu
        Vot
        Out
    End Enum

    Enum OpLogin
        User = 1
        Pass
        Out
    End Enum
    
    Enum OpAdministrador
        Dig = 1
        Can
        Res
        List
        Out
    End Enum

    Enum OpLoginVot
        Ced = 1
        Out
    End Enum
    
    Enum OpVotar
        Ced = 1
        Out
    End Enum

    Enum OpCandidato
        Result = 1
        Out
    End Enum
     
    Dim path As String = "..\..\personas.xml" 
    
    Sub Main()
        
        limpiarArreglos()
        guardarDatos(path, administradores, candidatos, votantes)
        mostrarDatos(administradores, candidatos, votantes)
        Dim op As String = ""
        Dim opcion As Byte

        Do
            MenuPrincipal()

            op = Console.ReadLine()

            Try
                opcion = CByte(op)
            Catch ex As OverflowException
                opcion = 255
            Catch ex As Exception
                opcion = OpMain.Invalid
            End Try

            Console.WriteLine("Usted ha ingresado: {0}", op)
            Console.ReadLine()

            Select Case opcion
                Case OpMain.Usu
                    Console.WriteLine("Iniciar Usuario")
                    ManejarLogin()
                Case OpMain.Vot
                    Console.WriteLine("Iniciar Votante")
                    ManejarLoginVot()
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
        Console.WriteLine("Menú Login")
        Console.WriteLine("{0}. Iniciar Usuario", CInt(OpMain.Usu))
        Console.WriteLine("{0}. Iniciar Votante", CInt(OpMain.Vot))
        Console.WriteLine("{0}. Salir", CInt(OpMain.Out))
    End Sub

    Sub MenuLogin()
        Console.WriteLine("{0}. Ingresar Usuario", CInt(OpLogin.User))
        Console.WriteLine("{0}. Ingresar Clave", CInt(OpLogin.Pass))
        Console.WriteLine("{0}. Regresar al menú principal", CInt(OpLogin.Out))
    End Sub

    Sub MenuLoginVot()
        Console.WriteLine("{0}. Ingresar Su Cédula de Identidad", CInt(OpLoginVot.Ced))
        Console.WriteLine("{0}. Regresar al menú principal", CInt(OpLoginVot.Out))
    End Sub

    Sub MenuCan()
        Console.WriteLine("{0}. Mostrar Resultados", CInt(OpCandidato.Result))
        Console.WriteLine("{0}. Regresar al menú principal", CInt(OpCandidato.Out))
    End Sub

    Sub MenuAdm()
        Console.WriteLine("Administrador")
        Console.WriteLine("{0}. Agregar Dignidad", CInt(OpAdministrador.Dig))
        Console.WriteLine("{0}. Agregar Candidato", CInt(OpAdministrador.Can))
        Console.WriteLine("{0}. Mostrar Resultado", CInt(OpAdministrador.Res))
        Console.WriteLine("{0}. Lista Candidatos", CInt(OpAdministrador.List))
        Console.WriteLine("{0}. Regresar al menú principal", CInt(OpAdministrador.Out))
    End Sub
    
    Sub ManejarLogin()
        Dim op As String = ""
        Dim opcion As Byte
        Dim pass As String

        Do
            MenuLogin()

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
                Case OpLogin.User
                    Console.WriteLine("Usuario:")
                    user = Console.ReadLine()
                Case OpLogin.Pass
                    Console.WriteLine("Clave: ")
                    pass = Console.ReadLine()

                    For Each a As Administrador In administradores

                        For Each c As Candidatos In candidatos

                            If pass = c.Clave Then
                                Console.WriteLine("contraseña correcta")
                                If user = c.Usuario Then
                                    ManejarCan()
                                    Exit For
                                End If
                            End If

                        Next

                        If pass = a.Clave Then
                            Console.WriteLine("contraseña correcta")
                            If user = a.Usuario Then
                                ManejarAdm()
                                Exit For
                            End If
                        End If

                    Next
                    Console.WriteLine("usuario o contraseña incorrecta")

                Case OpLogin.Out
                    Console.WriteLine("Volver al menú principal")

                Case Else
                    Console.WriteLine("XXXXX OPCION INVALIDA XXXXX")
            End Select
        Loop Until opcion = OpLogin.Out
    End Sub

    Sub ManejarLoginVot()
        Dim op As String = ""
        Dim opcion As Byte
        Dim ced As String = ""

        Do
            MenuLoginVot()

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
                Case OpLoginVot.Ced
                    Console.WriteLine("Cedula:")
                    ced = Console.ReadLine()


                    For Each v As Votante In votantes
                        For Each hechos As Votante In votoshecho
                            If ced = hechos.Cedula Then
                                Console.WriteLine("Usted ya ha votado")
                                ManejarLoginVot()
                            End If
                        Next
                        If ced = v.Cedula Then
                            Console.WriteLine("usuario correcto")
                            Console.WriteLine("Bienvenido: " & v.Nombre)
                            votoshecho.Add(v)
                            MenuVotar()
                        End If

                    Next

                    Console.WriteLine("usuario incorrecto")

                Case OpLoginVot.Out
                    Console.WriteLine("Volver al menú principal")
                    Main()
                Case Else
                    Console.WriteLine("XXXXX OPCION INVALIDA XXXXX")

            End Select
        Loop Until opcion = OpLoginVot.Out
    End Sub

    Sub ManejarCan()
        Dim op As String = ""
        Dim opcion As Byte
        Dim resultados As String

        Do
            MenuCan()

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
                Case OpCandidato.Result
                    Console.WriteLine("Mostrar Resultados")
                    resultados = Console.ReadLine()
                    mostrarResultadoCand(dignidades, candidatos, user)

                Case OpCandidato.Out
                    Console.WriteLine("Volver al menú principal")
                    Main()

                Case Else
                    Console.WriteLine("XXXXX OPCION INVALIDA XXXXX")
            End Select
        Loop Until opcion = OpCandidato.Out
    End Sub

    Private Sub ListaCandidatos(dignidades As ArrayList, candidatos As ArrayList)
        limpiarArreglos()
        guardarDatos(path, personas, administradores, votantes, candidatos, dignidades)
        For Each d As Dignidad In dignidades
            Console.WriteLine(d.NombreDig)
            For Each c As Candidatos In candidatos
                If (c.Dignidad = d.NombreDig) Then
                    Console.WriteLine(c.Nombre & " " & c.Apellido)
                End If
            Next
        Next
    End Sub

    Private Sub limpiarArreglos()
        personas.Clear()
        administradores.Clear()
        votantes.Clear()
        candidatos.Clear()
        dignidades.Clear()
    End Sub

    Private Sub MenuVotar()
        Dim votar As Integer
        Dim num As Integer = 1
        For Each d As Dignidad In dignidades
            Console.WriteLine(d.NombreDig)
            For Each c As Candidatos In candidatos
                If (c.Dignidad = d.NombreDig) Then
                    Console.WriteLine("{0}. " & c.Nombre & " " & c.Apellido & " ", CStr(num))
                    num = 1 + num
                End If
            Next

            Console.WriteLine("{0}. Blanco", num)
            Console.WriteLine("{0}. Nulo", num + 1)
            num = 1
            votar = Console.ReadLine()
            votar = votar + cont

            For Each c As Candidatos In candidatos
                If (c.Dignidad = d.NombreDig) Then
                    cont = cont + 1
                    If votar = cont Then
                        votado = c.Nombre
                        Console.WriteLine(votado)
                        cont = votar + cont
                        Exit For
                    End If
                End If
            Next
            AgregarVoto(path, votado)
        Next
    End Sub

End Module
