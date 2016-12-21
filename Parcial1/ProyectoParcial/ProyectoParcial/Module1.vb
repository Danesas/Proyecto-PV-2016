Module Module1

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
    Sub Main()

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
