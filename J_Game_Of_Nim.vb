Module J_Game_Of_Nim

    Sub Main()

        Randomize()

        Dim Player1Name As String = ""
        Dim Player2Name As String = ""
        Dim PlayerName As String = ""

        Dim PileATotal As Integer = 0
        Dim PileBTotal As Integer = 0
        Dim PileCTotal As Integer = 0

        Dim PlayerMove As String = ""
        Dim PlayerMoveLetter As String = ""
        Dim PlayerMoveNumber As Integer = 0
        Dim WinnerDecided As Boolean = False

        Dim InvalidLetter As Boolean = True
        Dim InvalidNumber As Boolean = True
        Dim InvalidLength As Boolean = True
        Dim TooSmallNum As Boolean = True
        Dim CurrentPlayer As Integer = 1
        Dim InvalidMove As Boolean = True
        Dim Height As Integer = 0

        PileATotal = GetAPileTotal()
        PileBTotal = GetAPileTotal()
        PileCTotal = GetAPileTotal()

        Height = CompareTotals(PileATotal, PileBTotal, PileCTotal, Height)

        Player1Name = GetPlayerName("1")
        Player2Name = GetPlayerName("2")
        Console.Clear()

        Console.WriteLine("")
        DisplayAllTotals(PileATotal, PileBTotal, PileCTotal, Height)
        ' ALTERNATE DISPLAYING
        'Console.WriteLine(ShowAllPileTotals(PileATotal, PileBTotal, PileCTotal))

        Do While WinnerDecided = False

            Height = CompareTotals(PileATotal, PileBTotal, PileCTotal, Height)

            Console.WriteLine("")
            If CurrentPlayer = 1 Then PlayerName = Player1Name
            If CurrentPlayer = 2 Then PlayerName = Player2Name
            Console.WriteLine(PlayerName & "'s turn.")

            Do While InvalidMove = True
                PlayerMove = GetPlayerMove()
                PlayerMoveLetter = GetPileLetter(PlayerMove)
                PlayerMoveNumber = GetPileNumber(PlayerMove)
                InvalidMove = ValidationMethod(InvalidLetter, InvalidNumber, InvalidLength, TooSmallNum, PlayerMoveLetter, PlayerMoveNumber, PileATotal, PileBTotal, PileCTotal, PlayerMove)
            Loop
            MakePlayerMove(PlayerMoveLetter, PlayerMoveNumber, PileATotal, PileBTotal, PileCTotal)
            Console.WriteLine("")
            Console.WriteLine(PlayerName & " has taken " & PlayerMoveNumber & " from Pile " & UCase(PlayerMoveLetter))
            WasteTime()
            Console.Clear()
            Console.WriteLine("")
            Height = CompareTotals(PileATotal, PileBTotal, PileCTotal, Height)
            DisplayAllTotals(PileATotal, PileBTotal, PileCTotal, Height)
            ' ALTERNATE DISPLAYING
            'Console.WriteLine(ShowAllPileTotals(PileATotal, PileBTotal, PileCTotal))
            WinnerDecided = SomeoneHasWon(PileATotal, PileBTotal, PileCTotal)
            If WinnerDecided = True Then
                Console.WriteLine(PlayerName & " has won!")
                Console.WriteLine("")
                Console.WriteLine("Press 'ENTER' to EXIT. ")
            End If

            If CurrentPlayer = 1 Then
                CurrentPlayer = 2
                InvalidMove = True
            Else
                CurrentPlayer = 1
                InvalidMove = True
            End If
        Loop

        Console.ReadLine()
    End Sub

    Function GetPlayerName(PlayerNumber) As String
        Dim Temp
        Console.Write("Player " & PlayerNumber & " enter your name > ")
        Temp = Console.ReadLine
        Return Temp
    End Function

    Function GetAPileTotal() As Integer
        Return Int(9 * Rnd() + 1)
    End Function

    Function GetPlayerMove() As String
        Dim Temp
        Console.Write("Enter your move (Pile first then amount i.e. (A4)) > ")
        Temp = Console.ReadLine
        Return Temp
    End Function

    Function GetPileLetter(ByVal PlayerMove As String) As String
        Return Left(PlayerMove, 1)
    End Function

    Function GetPileNumber(ByVal PlayerMove As String) As Integer
        Return Right(PlayerMove, 1)
    End Function

    Function IsInvalidLetter(ByVal PlayerMoveLetter As String) As Boolean
        Select Case UCase(PlayerMoveLetter)
            Case "A" To "C"
                Return False
            Case Else
                Console.WriteLine("Invalid letter !")
                Return True
        End Select
    End Function

    Function IsInvalidNumber(ByVal PlayerMoveNumber As Integer) As Boolean
        Select Case UCase(PlayerMoveNumber)
            Case "1" To "9"
                Return False
            Case Else
                Console.WriteLine("Invalid number!")
                Return True
        End Select
    End Function

    Function IsInvalidLength(ByVal PlayerMove As String) As Boolean
        If Len(PlayerMove) <> 2 Then
            Return True
            Console.WriteLine("Invalid length !")
        Else
            Return False
        End If
    End Function

    Function NumberNotSmallEnough(ByVal PlayerMoveLetter As String, ByVal PlayerMoveNumber As Integer, ByVal PileATotal As Integer, ByVal PileBTotal As Integer, ByVal PileCTotal As Integer) As Boolean

        If UCase(PlayerMoveLetter) = "A" Then
            If PlayerMoveNumber > PileATotal Then
                Console.WriteLine("Number is too big!")
                Return True
            ElseIf PlayerMoveNumber = 0 Then
                Return True
            Else
                Return False
            End If

        ElseIf UCase(PlayerMoveLetter) = "B" Then
            If PlayerMoveNumber > PileBTotal Then
                Console.WriteLine("Number is too big!")
                Return True
            ElseIf PlayerMoveNumber = 0 Then
                Return True
            Else
                Return False
            End If

        ElseIf UCase(PlayerMoveLetter) = "C" Then
            If PlayerMoveNumber > PileCTotal Then
                Console.WriteLine("Number is too big!")
                Return True
            ElseIf PlayerMoveNumber = 0 Then
                Return True
            Else
                Return False
            End If
        End If
    End Function

    Function ShowAllPileTotals(ByVal PileATotal As Integer, ByVal PileBTotal As Integer, ByVal PileCTotal As Integer) As String
        Console.WriteLine("A) " & PileATotal)
        Console.WriteLine("B) " & PileBTotal)
        Console.WriteLine("C) " & PileCTotal)
    End Function

    Sub MakePlayerMove(ByVal PlayerMoveLetter As String, ByVal PlayerMoveNumber As Integer, ByRef PileATotal As Integer, ByRef PileBTotal As Integer, ByRef PileCTotal As Integer)
        Select Case UCase(PlayerMoveLetter)
            Case "A"
                PileATotal = PileATotal - PlayerMoveNumber
            Case "B"
                PileBTotal = PileBTotal - PlayerMoveNumber
            Case "C"
                PileCTotal = PileCTotal - PlayerMoveNumber
        End Select
    End Sub

    Function SomeoneHasWon(ByVal PileATotal As Integer, ByVal PileBTotal As Integer, ByVal PileCTotal As Integer) As Boolean
        If PileATotal + PileBTotal + PileCTotal = 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Function ValidationMethod(ByRef InvalidLetter As Boolean, ByRef InvalidNumber As Boolean, ByRef InvalidLength As Boolean, ByRef TooSmallNum As Boolean, ByVal PlayerMoveLetter As Char, ByVal PlayerMoveNumber As Integer, ByVal PileATotal As Integer, ByVal PileBTotal As Integer, ByVal PileCTotal As Integer, ByVal PlayerMove As String) As Boolean

        InvalidLetter = IsInvalidLetter(PlayerMoveLetter)
        InvalidNumber = IsInvalidNumber(PlayerMoveNumber)
        InvalidLength = IsInvalidLength(PlayerMove)
        TooSmallNum = NumberNotSmallEnough(PlayerMoveLetter, PlayerMoveNumber, PileATotal, PileBTotal, PileCTotal)

        If InvalidLetter = True Or InvalidNumber = True Or InvalidLength = True Or TooSmallNum = True Then
            Return True
        Else
            Return False
        End If
    End Function

    Function DisplayPileTotal(ByVal PileTotal As Integer, ByVal PileLetter As String, ByVal Width As Integer, ByVal Height As Integer)

        Console.SetCursorPosition(Width, Height + 1)
        Console.WriteLine(PileLetter)
        Dim Pos As Integer

        For Looper = PileTotal To 1 Step -1
            Pos = Height - Looper
            Console.SetCursorPosition(Width, Pos)
            Console.WriteLine("_")
        Next

    End Function

    Function CompareTotals(ByVal PileATotal As Integer, ByVal PileBTotal As Integer, ByVal PileCTotal As Integer, ByRef Height As Integer)

        If PileATotal > PileBTotal And PileATotal > PileCTotal Then
            Height = PileATotal
        ElseIf PileBTotal > PileATotal And PileBTotal > PileCTotal Then
            Height = PileBTotal
        ElseIf PileCTotal > PileATotal And PileCTotal > PileBTotal Then
            Height = PileCTotal
        End If
        Return Height
    End Function

    Function DisplayAllTotals(ByVal PileATotal As Integer, ByVal PileBTotal As Integer, ByVal PileCTotal As Integer, ByVal Height As Integer)
        DisplayPileTotal(PileATotal, "A", 10, Height)
        DisplayPileTotal(PileBTotal, "B", 20, Height)
        DisplayPileTotal(PileCTotal, "C", 30, Height)
        Console.WriteLine("")
    End Function
End Module

'Module J_Nim
'    Sub Main()
'        Dim Player1Name As String
'        Dim Player2Name As String

'        Dim CurrentPlayer As String

'        Dim PileATotal As Byte
'        Dim PileBTotal As Byte
'        Dim PileCTotal As Byte
'        Dim PlayerMove As String
'        Dim PlayerMoveLetter As Char
'        Dim PlayerMoveNumber As Byte

'        Player1Name = GetPlayerName()
'        Player2Name = GetPlayerName()

'        PileATotal = GetAPileStartingTotal()
'        PileBTotal = GetAPileStartingTotal()
'        PileCTotal = GetAPileStartingTotal()
'        ShowAllPileTotals(PileATotal, PileBTotal, PileCTotal)
'        CurrentPlayer = Player1Name
'        Do
'            PlayerMove = GetPlayerMove(CurrentPlayer)
'            ' BEFORE PROCEEDING WE NEED TO CHECK THE CORRECTNESS OF THE MOVE ENTERED

'            If MoveIsValid(PlayerMove) = True Then


'                PlayerMoveLetter = GetPileLetterFromMove(PlayerMove)
'                PlayerMoveNumber = GetNumberToTakeFromMove(PlayerMove)

'                If PlayerMoveLetter = "A" Then
'                    ' NOW WE MUST CHECK IF THE NUMBER TO TAKE FROM PILE A IS SMALL ENOUGH
'                    If NumberIsSmallEnough(PlayerMoveNumber, PileATotal) Then
'                        ' IF IT IS SMALL ENOUGH WE CAN MAKE THIS MOVE
'                        PileATotal = MakePlayerMove(PileATotal, PlayerMoveNumber)
'                    End If
'                End If

'                ' NOW THE SAME FOR PILE B AND C
'                If PlayerMoveLetter = "B" Then
'                    If NumberIsSmallEnough(PlayerMoveNumber, PileBTotal) Then
'                        PileBTotal = MakePlayerMove(PileBTotal, PlayerMoveNumber)
'                    End If
'                End If

'                If PlayerMoveLetter = "C" Then
'                    If NumberIsSmallEnough(PlayerMoveNumber, PileCTotal) Then
'                        PileCTotal = MakePlayerMove(PileCTotal, PlayerMoveNumber)
'                    End If

'                End If
'                ReportPlayerMove(CurrentPlayer, PlayerMoveLetter, PlayerMoveNumber)
'                ShowAllPileTotals(PileATotal, PileBTotal, PileCTotal)
'                ' Swap player to the other one

'                If CurrentPlayer = Player1Name Then
'                    CurrentPlayer = Player2Name
'                Else
'                    CurrentPlayer = Player1Name
'                End If

'            Else
'                ' IF THE MOVE WAS NOT VALID THEN TELL THE PLAYER THAT IS HAS BEEN IGNORED
'                Console.WriteLine("This is not a valid move - NO ACTION TAKEN")

'            End If
'        Loop Until SomeOneHasWon(PileATotal, PileBTotal, PileCTotal) = True

'        DisplayWinner(CurrentPlayer)
'        Console.ReadLine()
'    End Sub
'    Function SomeOneHasWon(ByVal PileA As Byte, ByVal PileB As Byte, ByVal PileC As Byte) As Boolean
'        If PileA = 0 And PileB = 0 And PileC = 0 Then
'            Return True
'        Else
'            Return False
'        End If
'    End Function
'    Function GetPlayerName() As String
'        Dim ThePlayerName As String
'        Console.WriteLine("Next player, please enter your name")
'        ThePlayerName = Console.ReadLine
'        Return ThePlayerName
'    End Function
'    Function GetAPileStartingTotal() As Byte
'        Dim ThePilesize As Byte
'        ThePilesize = Int(9 * Rnd() + 1)
'        Return ThePilesize
'    End Function
'    Function GetPlayerMove(ThePlayerName As String) As String
'        Dim ThePlayerMove As String
'        Console.WriteLine(ThePlayerName & " , please enter your move")
'        ThePlayerMove = Console.ReadLine
'        Return ThePlayerMove
'    End Function
'    Function GetPileLetterFromMove(TheWholeMove As String) As Char
'        Return Left(TheWholeMove, 1)
'    End Function
'    Function GetNumberToTakeFromMove(TheWholeMove As String) As Byte
'        Return Right(TheWholeMove, 1)
'    End Function
'    Function MakePlayerMove(PileTotal As Byte, HowManyToRemove As Byte) As Byte
'        Return PileTotal - HowManyToRemove
'    End Function
'    Sub ShowAllPileTotals(PileATotal As Byte, PileBTotal As Byte, PileCTotal As Byte)
'        Console.WriteLine(PileATotal & " " & PileBTotal & " " & PileCTotal)
'    End Sub
'    Sub DisplayWinner(ByVal TheWinnerName As String)
'        Console.WriteLine()
'        Console.WriteLine("The winner is:- " & TheWinnerName)
'        Console.WriteLine()
'    End Sub

'    Sub ReportPlayerMove(ByVal ThePlayerName As String, _
'                         ByVal ThePileLetter As Char, _
'                         ByVal TheNumberTaken As Byte)
'        Console.SetCursorPosition(0, 15)
'        Console.Write(ThePlayerName & " takes " & TheNumberTaken & " from Pile " & ThePileLetter & vbTab(30))
'    End Sub

'    Function NumberIsSmallEnough(ByVal TheNumber As Byte, ByVal ThePile As Byte) As Boolean
'        If ThePile >= TheNumber Then
'            Return True
'        Else
'            Console.WriteLine("The number is too big to take from this pile - YOU HAVE WASTED A TURN")
'            Return False
'        End If
'    End Function

'    Function MoveIsCorrectLength(ByVal TheMove As String) As Boolean
'        If Len(TheMove) = 2 Then
'            Return True
'        Else
'            Return False
'        End If
'    End Function

'    Function IsValidNumber(ByVal TheNumberChar As Char) As Boolean
'        If Asc(TheNumberChar) > 48 And _
'            Asc(TheNumberChar) <= 57 Then
'            Return True
'        Else
'            Return False
'        End If
'    End Function

'    Function IsValidLetter(ByVal TheLetterChar As Char) As Boolean
'        If Asc(TheLetterChar) > 64 _
'            And Asc(TheLetterChar) <= 67 Then
'            Return True
'        Else
'            Return False
'        End If
'    End Function

'    Function MoveIsValid(ByVal TheMove As String) As Boolean
'        If MoveIsCorrectLength(TheMove) = False Then
'            Console.WriteLine("Incorrect length to the move.")
'            Return False ' this exits the function IMMEDIATELY, (so the rest of the function is ignored)
'        End If
'        ' if prog reaches here TheMove has 2 chars
'        If Not IsValidLetter(Left(TheMove, 1)) Then
'            Console.WriteLine("Incorrect letter in the move.")
'            Return False
'        End If
'        ' if prog reaches here TheMove has 2 chars and the first is a valid letter
'        If Not IsValidNumber(Right(TheMove, 1)) Then
'            Console.WriteLine("Incorrect number in the move.")
'            Return False
'        End If
'        ' if prog reaches here TheMove has 2 chars, first is valid letter, second is valid number
'        Return True
'    End Function
'End Module