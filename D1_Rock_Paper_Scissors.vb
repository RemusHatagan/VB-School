Module D1_Rock_Paper_Scissors

    Sub Main()

        Console.ForegroundColor = ConsoleColor.DarkMagenta
        Console.WriteLine("Welcome to the fabulous game of Rock, Paper, Scissors !!!")
        Console.WriteLine("~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~")

        Dim PlayerOneName As String = ""
        Dim PlayerTwoName As String = ""
        Dim PlayerOneObjectChoice As Integer
        Dim PlayerTwoObjectChoice As Integer
        Dim PlayerOneObjectName As String = ""
        Dim PlayerTwoObjectName As String = ""
        Dim WinMessage As String = ""

        GetAName(PlayerOneName, "one")   ' GETTING NAMES
        GetAName(PlayerTwoName, "two")

        GetInputs(PlayerOneObjectChoice, PlayerOneName)    ' GETTING CHOICES 
        GetInputs(PlayerTwoObjectChoice, PlayerTwoName)

        ChoicesConversion(PlayerOneObjectChoice, PlayerOneObjectName) ' GETTING OBJECT NAME
        ChoicesConversion(PlayerTwoObjectChoice, PlayerTwoObjectName)

        WinningDecision(WinMessage, PlayerOneObjectChoice, PlayerTwoObjectChoice, PlayerOneName, PlayerTwoName, PlayerOneObjectName, PlayerTwoObjectName) ' DECIDING WINNER
        Console.WriteLine(WinMessage)
        Console.ReadLine()
    End Sub

    Sub GetInputs(ByRef AnyChoice As Integer, ByRef AnyName As String)
        Console.Write(AnyName & ", enter your choice (1 = Rock, 2 = Paper, 3 = Scissors) > ") ' PLAYER CHOICE INSERTED
        AnyChoice = Console.ReadLine
        Console.Clear()
    End Sub

    Sub GetAName(ByRef AnyName As String, ThePlayer As String)
        Console.Write("Player " & ThePlayer & ", please enter your name > ") ' NAME INSERTED
        AnyName = Console.ReadLine
    End Sub

    Sub ChoicesConversion(ByVal ObjectChoice As Integer, ByRef ObjectName As String)
        Select Case ObjectChoice
            Case 1
                ObjectName = "Rock"
            Case 2
                ObjectName = "Paper"
            Case 3
                ObjectName = "Scissors"
        End Select
    End Sub

    Sub WinningDecision(ByRef WinMessage As String, ByVal PlayerOneObjectChoice As Integer, ByVal PlayerTwoObjectChoice As Integer, ByVal PlayerOneName As String, ByVal PlayerTwoName As String, ByVal PlayerOneObjectName As String, ByVal PlayerTwoObjectName As String)


        Select Case PlayerOneObjectChoice & PlayerTwoObjectChoice
            Case 1 & 2
                WinMessage = (PlayerTwoName & " wins because PAPER beats ROCK")
            Case 1 & 3
                WinMessage = (PlayerOneName & " wins because ROCK beats SCISSORS")
            Case 2 & 1
                WinMessage = (PlayerOneName & " wins because PAPER beats ROCK")
            Case 2 & 3
                WinMessage = (PlayerTwoName & " wins because SCISSORS beat PAPER")
            Case 3 & 2
                WinMessage = (PlayerOneName & " wins because SCISSORS beat PAPER")
            Case 3 & 1
                WinMessage = (PlayerTwoName & " wins because ROCK beats SCISSORS")
        End Select

        If PlayerOneObjectChoice = PlayerTwoObjectChoice Then
            WinMessage = ("The game is a draw as both players picked " & PlayerOneObjectName) ' CHOICES FOR P1 AND P2 ARE EQUAL 
        End If
        If PlayerOneObjectChoice < 1 Or PlayerOneObjectChoice > 3 Or PlayerTwoObjectChoice < 1 Or PlayerTwoObjectChoice > 3 Then
            WinMessage = ("ERROR - VALUE OUTSIDE PARAMETERS")                                             'CHOICES FOR P1 OR P2 OUTSIDE ACCEPTED
        End If
    End Sub

End Module