Module H_Strings_Exam_Q2

    Sub Main()
        Dim FWord As String = ""
        Dim SWord As String = ""
        Dim canBeWritten As Boolean = True
        Dim Position As Integer
        Dim CurrChar As Char

        Console.Write("Enter the word you wish to create > ")
        FWord = LCase(Console.ReadLine())
        Console.Write("Enter the word you want to create from > ")
        SWord = LCase(Console.ReadLine())

        If Len(FWord) > Len(SWord) Then
            canBeWritten = False
        End If

        For Looper = 1 To Len(FWord)
            CurrChar = Mid(FWord, Looper, 1)
            Position = InStr(SWord, CurrChar)

            If Position <> 0 Then
                ' Remove the character from SWord so it can't be used again
                SWord = Left(SWord, Position - 1) & Right(SWord, (Len(SWord) - Position))
                ' SECOND METHOD
                ' SWord = SWord.Remove(Position - 1, 1)
            Else
                canBeWritten = False
                Exit For
            End If

        Next

        Console.WriteLine("")
        If canBeWritten = True Then
            Console.WriteLine("The first word can be written using the letters of the second word.")
        Else
            Console.WriteLine("The first word cannot be written using the letters of the second word.")
        End If

        Console.ReadLine()
    End Sub

End Module