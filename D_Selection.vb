Module D_Selection

    Sub Main()

        'StandardIF()
        'BlockIF()
        SelectCase()
        Console.ReadLine()

    End Sub

    Sub StandardIF()

        ' here we have 1 CONDITION to TEST
        ' and 2 possible resulting actions
        ' if the condition is true then do the 'THEN' part
        ' if it is false, do the 'ELSE' part

        Dim TeamName As String = "Arsenal"
        If TeamName = "Arsenal" Then Console.WriteLine("Good team") Else Console.WriteLine("Bad team")

    End Sub

    Sub BlockIF()

        ' here we have 1 CONDITION to TEST
        ' and 2 possible resulting SEQUENCES of actions
        ' if the condition is true then do the 'THEN' BLOCK
        ' if it is false, do the 'ELSE' BLOCK

        Dim TeamName As String = "Chelsea"
        If TeamName = "Arsenal" Then
            Console.WriteLine("Good team")
            Console.WriteLine("Come on you Gunners")
            Console.WriteLine("We're gonna win the league")
        Else
            If TeamName = "Chelsea" Then ' NESTED 'IF' statement
                Console.WriteLine("Really?!?!?!?!")
            End If
            Console.WriteLine("Bad team")
            Console.WriteLine("Try supporting Arsenal")
        End If

    End Sub

    Sub SelectCase()
        Dim TeamName As String = "Arsenal"
        Select Case TeamName ' all conditions tested against the VALUE OF TeamName
            ' think of it like "IF TeamName is ......"
            Case "Forest"
                Console.WriteLine("Good team")
            Case "Palace"
                Console.WriteLine("Bad team")
                Console.WriteLine("Try supporting Arsenal")
            Case "Chelsea"
                Console.WriteLine("Really??!!!")
            Case Else
                Console.WriteLine("Who are ya!!!!")
        End Select
    End Sub

    Sub SelectCase2()
        Dim MyAge As Byte = 17
        Select Case MyAge
            ' Compare MyAge to the following CASES
            Case Is = 18 ' MyAge is exactly 18

            Case Is > 16 ' MyAge more than 16

            Case 12, 45, 67 ' MyAge is 12 OR 45 OR 67

            Case 18 To 65 ' MyAge is between 18 and 65
        End Select
    End Sub
End Module