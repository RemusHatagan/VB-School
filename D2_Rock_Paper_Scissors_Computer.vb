Module D2_Rock_Paper_Scissors_Computer
    Sub Main()
        Console.ForegroundColor = ConsoleColor.Magenta
        Console.WindowHeight = 45                                           ' SETTINGS FOR CONSOLE
        Console.WindowWidth = 60

        Randomize()
        Dim PChoice As Integer
        Dim ComputerChoice As Integer
        Dim WinMessage As String = ""
        Dim ObjectName As String = ""
        ComputerChoice = Int(3 * Rnd() + 1)
        GetInputs(PChoice)
        ChoicesConversion(PChoice, ObjectName)
        DrawVS()
        ChoicesConversion(ComputerChoice, ObjectName)
        Console.WriteLine("")
        Console.WriteLine("The computer chose " & ObjectName)
        Console.WriteLine("~+~+~+~+~+~+~+~+~+~+~+~+~+~+~+")
        WinningDecision(PChoice, ComputerChoice, WinMessage)
        Console.WriteLine(WinMessage)
        Console.ReadLine()
    End Sub
    Sub GetInputs(ByRef PChoice As Integer)
        Console.Write("Enter your choice (1 = Rock, 2 = Paper, 3 = Scissors) > ")
        PChoice = Console.ReadLine()
    End Sub
    Sub WinningDecision(ByVal PChoice As Integer, ByVal ComputerChoice As Integer, ByRef WinMessage As String)
        Select Case PChoice & ComputerChoice
            Case 1 & 2
                WinMessage = ("Computer wins because PAPER beats ROCK")
            Case 1 & 3
                WinMessage = ("You win because ROCK beats SCISSORS")
            Case 2 & 1
                WinMessage = ("You win because PAPER beats ROCK")
            Case 2 & 3
                WinMessage = ("Computer wins because SCISSORS beat PAPER")
            Case 3 & 2
                WinMessage = ("You win because SCISSORS beat PAPER")
            Case 3 & 1
                WinMessage = ("Computer wins because ROCK beats SCISSORS")
            Case Else                                                                                                               ' CHOICES ARE THE SAME
                If PChoice = 1 Then
                    WinMessage = ("The game is a draw as both players picked Rock")
                ElseIf PChoice = 2 Then
                    WinMessage = ("The game is a draw as both players picked Paper")
                ElseIf PChoice = 3 Then
                    WinMessage = ("The game is a draw as both players picked Scissors")
                End If
        End Select
        If PChoice < 1 Or PChoice > 3 Then
            WinMessage = ("ERROR - VALUE OUTSIDE PARAMETERS")                                             'CHOICES FOR P1 OR P2 OUTSIDE ACCEPTED
        End If
    End Sub
    Sub ChoicesConversion(ByVal AnyChoice As Integer, ByRef ObjectName As String)
        Select Case AnyChoice
            Case 1
                ObjectName = "Rock"
                DrawRock()
            Case 2
                ObjectName = "Paper"
                DrawPaper()
            Case 3
                ObjectName = "Scissors"
                DrawScissors()
        End Select
    End Sub

    Sub DrawRock()
        Console.WriteLine()
        Console.WriteLine("          _    ,-,    _")
        Console.WriteLine("   ,--, /: :\/': :`\/: :\")
        Console.WriteLine("  |`;  ' `,'   `.;    `: |")
        Console.WriteLine("  |    |     |  '  |     |.")
        Console.WriteLine("  | :  |     |     |     ||")
        Console.WriteLine("  | :. |  :  |  :  |  :  | \")
        Console.WriteLine("   \__/: :.. : :.. | :.. |  )")
        Console.WriteLine("       `---',\___/,\___/ /'")
        Console.WriteLine("             `==._ .. . /'")
        Console.WriteLine("                  `-::-'")
        Console.WriteLine()
    End Sub

    Sub DrawPaper()
        Console.WriteLine()
        Console.WriteLine("  _______________________")
        Console.WriteLine("=(__    ___      __     _)=")
        Console.WriteLine("  |                     |")
        Console.WriteLine("  |                     |")
        Console.WriteLine("  |                     |")
        Console.WriteLine("  |                     |")
        Console.WriteLine("  |                     |")
        Console.WriteLine("  |                     |")
        Console.WriteLine("  |                     |")
        Console.WriteLine("  |                     |")
        Console.WriteLine("  |                     |")
        Console.WriteLine("  |__    ___   __    ___|")
        Console.WriteLine("=(_______________________)=")
        Console.WriteLine()
    End Sub

    Sub DrawScissors()
        Console.WriteLine()
        Console.WriteLine("    ,---.          ")
        Console.WriteLine("   / ,-. \          ")
        Console.WriteLine("   \ `-' _`-------------.   ")
        Console.WriteLine("    >--.(_)-------------->   ")
        Console.WriteLine("   / ,-.`-=============='   ")
        Console.WriteLine("   \ `-' / ")
        Console.WriteLine("    `---'       ")
        Console.WriteLine()
    End Sub

    Sub DrawVS()
        Console.WriteLine("**      **  ********")
        Console.WriteLine("/**     /** **////// ")
        Console.WriteLine("/**     /**/**       ")
        Console.WriteLine("//**    ** /*********")
        Console.WriteLine("//**  **  ////////**")
        Console.WriteLine("//****          /**")
        Console.WriteLine("//**     ******** ")
        Console.WriteLine("//     //////// ")
    End Sub

End Module