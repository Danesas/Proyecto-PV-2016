Module Module1

    Dim contador As Integer = 1
    Dim con As Integer = 1
    Dim votado As String = ""
    Dim cont As Integer = 0
    Dim temp As String = ""
    Dim user As String
    Dim rol As String = ""
    Dim nombre As String = ""
    Dim nombreDig As String = ""
    Dim apellido As String = ""
    Dim edad As Integer = 0
    Dim usuario As String = ""
    Dim clave As String = ""
    Dim dignidad As String = ""
    Dim cedula As String = ""
    Dim personas = New ArrayList()
    Dim votoshecho = New ArrayList()
    Dim administradores = New ArrayList()
    Dim candidatos = New ArrayList()
    Dim votantes = New ArrayList()
    Dim dignidades = New ArrayList()
    Dim a1 As Administrador
    Dim c1 As Candidatos
    Dim v1 As Votante
    Dim d1 As Dignidad
     
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
    
    Private Sub guardarDatos(path As String, personas As ArrayList, administradores As ArrayList, votantes As ArrayList, candidatos As ArrayList, dignidades As ArrayList)
        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load(path)
        Dim raiz As XmlNodeList = xmlDoc.GetElementsByTagName("persona")
        For Each nodo As XmlNode In raiz

            For Each persona As XmlNode In nodo.ChildNodes
                If nodo.HasChildNodes Then

                    If persona.Name = "nombre" Then
                        nombre = persona.InnerText
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
                    If persona.Name = "voto" Then
                        voto = persona.InnerText
                    End If
                    If persona.Name = "rol" Then
                        rol = persona.InnerText
                        If rol = "Administrador" Then
                            a1 = New Administrador(nombre, apellido, edad, usuario, clave, rol)
                            administradores.Add(a1)
                            personas.Add(a1)
                        End If

                        If rol = "Votante" Then
                            v1 = New Votante(nombre, apellido, edad, cedula, rol)
                            votantes.Add(v1)
                            personas.Add(v1)
                        End If

                        If rol = "Candidato" Then
                            c1 = New Candidatos(nombre, apellido, edad, usuario, clave, dignidad, voto, rol)
                            candidatos.Add(c1)
                            personas.Add(c1)
                        End If

                    End If

                End If
            Next
        Next
        Dim raiz2 As XmlNodeList = xmlDoc.GetElementsByTagName("dignidad")
        For Each nodo As XmlNode In raiz2

            For Each dignidad As XmlNode In nodo.ChildNodes
                If nodo.HasChildNodes Then
                    If dignidad.Name = "nombre" Then
                        nombreDig = dignidad.InnerText
                        d1 = New Dignidad(nombreDig)
                        dignidades.Add(d1)
                    End If
                End If
            Next

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


    Private Sub AgregarDignidad(path As String, texto As String)
        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load(path)
        Dim recintos As XmlNodeList = xmlDoc.GetElementsByTagName("recinto")
        For Each rec As XmlNode In recintos
            Console.WriteLine(rec.Name)
            Dim dignidad As XmlNode
            Dim nombre As XmlNode

            dignidad = xmlDoc.CreateElement("dignidad")
            nombre = xmlDoc.CreateElement("nombre")
            rec.AppendChild(dignidad)
            dignidad.AppendChild(nombre)
            nombre.InnerText = texto
        Next
        xmlDoc.Save(path)
    End Sub


    Private Sub AgregarCandidato(path As String, textoNombre As String, textoApellido As String, textoEdad As String, textoUsuario As String, textoClave As String, textoDignidad As String)
        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load(path)
        Dim recintos As XmlNodeList = xmlDoc.GetElementsByTagName("recinto")
        For Each rec As XmlNode In recintos
            Console.WriteLine(rec.Name)
            Dim persona As XmlNode
            Dim nombre As XmlNode
            Dim apellido As XmlNode
            Dim edad As XmlNode
            Dim usuario As XmlNode
            Dim clave As XmlNode
            Dim dignidad As XmlNode
            Dim voto As XmlNode
            Dim rol As XmlNode

            persona = xmlDoc.CreateElement("persona")
            nombre = xmlDoc.CreateElement("nombre")
            apellido = xmlDoc.CreateElement("apellido")
            edad = xmlDoc.CreateElement("edad")
            usuario = xmlDoc.CreateElement("usuario")
            clave = xmlDoc.CreateElement("clave")
            dignidad = xmlDoc.CreateElement("dignidad")
            voto = xmlDoc.CreateElement("voto")
            rol = xmlDoc.CreateElement("rol")

            rec.AppendChild(persona)
            persona.AppendChild(nombre)
            persona.AppendChild(apellido)
            persona.AppendChild(edad)
            persona.AppendChild(usuario)
            persona.AppendChild(clave)
            persona.AppendChild(dignidad)
            persona.AppendChild(voto)
            persona.AppendChild(rol)

            nombre.InnerText = textoNombre
            apellido.InnerText = textoApellido
            edad.InnerText = textoEdad
            usuario.InnerText = textoUsuario
            clave.InnerText = textoClave
            dignidad.InnerText = textoDignidad
            voto.InnerText = 0
            rol.InnerText = "Candidato"

        Next
        xmlDoc.Save(path)
    End Sub
    Private Sub mostrarResultado(dignidades As ArrayList, candidatos As ArrayList)
        limpiarArreglos()
        guardarDatos(path, personas, administradores, votantes, candidatos, dignidades)
        For Each d As Dignidad In dignidades
            Console.WriteLine(d.NombreDig)
            For Each c As Candidatos In candidatos
                If (c.Dignidad = d.NombreDig) Then
                    Console.WriteLine(c.Nombre & " " & CStr(c.Voto))
                End If
            Next
        Next
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


    Private Sub mostrarResultadoCand(dignidades As ArrayList, candidatos As ArrayList, usuario As String)
        limpiarArreglos()
        guardarDatos(path, personas, administradores, votantes, candidatos, dignidades)
        For Each c1 As Candidatos In candidatos
            If c1.Usuario = user Then
                temp = c1.Dignidad
            End If
        Next

        For Each d As Dignidad In dignidades
            If (d.NombreDig = temp) Then
                Console.WriteLine(d.NombreDig)
                For Each c As Candidatos In candidatos
                    If (c.Dignidad = d.NombreDig) Then
                        Console.WriteLine(c.Nombre & " " & CStr(c.Voto))
                    End If
                Next
            End If
        Next
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

    Private Sub AgregarVoto(path As String, votado As String)
        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load(path)
        Dim raiz2 As XmlNodeList = xmlDoc.GetElementsByTagName("persona")
        For Each nodo As XmlNode In raiz2
            For Each persona As XmlNode In nodo.ChildNodes
                If nodo.HasChildNodes Then
                    If persona.Name = "nombre" Then
                        If persona.InnerText = votado Then
                            'Console.WriteLine(persona.InnerText)
                            Dim p As XmlElement = nodo
                            p("voto").InnerText += con
                        End If
                    End If
                End If
            Next
        Next
        xmlDoc.Save(path)
    End Sub

End Module
