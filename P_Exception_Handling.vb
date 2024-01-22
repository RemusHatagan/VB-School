Module P_Exception_Handling

    ' Compilation errors : Errors in the "syntax"   (CRASHES PROGRAM)
    ' Logic errors : Errors in the "logic" of a program   (DO NOT CRASH PROGRAM)
    ' Run-time errors : Errors only found when the program is running, after it has been compiled

    Sub Main()

        Dim X As Integer

        ' Catching errors
        Try
            ' have a go at this ........

            Console.Write("Enter an integer > ")
            X = Console.ReadLine

        Catch ex As OverflowException
            ' if an exception occurs then do this .........
            MsgBox("You have not entered a number between 1 and 32 bits")
        Catch ex As InvalidCastException
            MsgBox("You have used some nun-numeric caracters Mr Conway!")
        End Try


        Console.ReadLine()
    End Sub


End Module
