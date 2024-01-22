Module H_Strings_Exam_Q

    Sub Main()

        Dim Password As String
        Dim Score As Integer = 0
        Dim PassChar As Char
        Dim PrevChar As Char
        Dim UppCase As Boolean = False
        Dim LoCaseNum As Integer = 0
        Dim HasNum As Boolean = False
        Dim NonAlph As Boolean = False

        Do While Score < 5
            Score = 0
            Console.Write("Please enter your password > ")
            Password = Console.ReadLine()

            For Looper = 1 To Len(Password)
                PassChar = Mid(Password, Looper, 1)
                Select Case PassChar
                    Case "A" To "Z"
                        UppCase = True
                    Case "a" To "z"                'LOWER / UPPER CASE LETTERS AND NUMBERS INCLUDED
                        LoCaseNum += 1
                    Case "0" To "9"
                        HasNum = True
                    Case Else
                        NonAlph = True
                End Select
            Next

            If Len(Password) > 7 Then
                Score += 1
            End If
            If UppCase = True Then
                Score += 1
            End If
            If LoCaseNum > 4 Then
                Score += 1
            End If
            If HasNum = True Then
                Score += 1
            End If
            If NonAlph = True Then
                Score += 1
            End If

            For Looper = 1 To Len(Password)
                PassChar = Mid(Password, (Looper + 1), 1)  'Character before and after present character
                PrevChar = Mid(Password, Looper, 1)
                If PassChar = PrevChar Then
                    Score -= 1
                End If
            Next

            If Score = 5 Then
                Console.WriteLine("")
                Console.WriteLine("The password " & Password & " scores " & Score & " points.")
                Console.WriteLine("Your password is strong. Press ENTER to end")
            Else
                Console.WriteLine("")
                Console.WriteLine("Score too low, try again. Press ENTER to try again")
            End If

            Console.ReadLine()
        Loop

    End Sub

End Module
