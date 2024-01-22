Module N1_XandOs
    Sub Main()
        Randomize()
        Dim Board(2, 2) As String
        Dim UserMove As String = ""
        Dim Start As Integer = Int(Rnd() * 2 + 1)
        Dim Symbol As Char = ""
        Dim XCoord As Char = ""
        Dim YCoord As Char = ""
        Dim ValidMove As Boolean = False
        Dim GameHasEnded As Boolean
        Dim Counter As Integer = 0

        Board = SetUpBoard(Board)
        Show2DArray(Board)

        Do While GameHasEnded = False Or Counter < 9
            If Start = 1 Then Symbol = "X"
            If Start = 2 Then Symbol = "O"

            ValidMove = False
            Do Until ValidMove = True
                UserMove = GetUserGo(Symbol)
                XCoord = GetXCoord(UserMove)
                YCoord = GetYCoord(UserMove)
                ValidMove = MoveValid(UserMove, Board, XCoord, YCoord)
            Loop

            Board = UpdateBoard(Board, XCoord, YCoord, Symbol)
            Show2DArray(Board)

            ' Check for a winner after each move
            If CheckForWinner(Board, Symbol, Val(XCoord), Val(YCoord)) Then
                Console.WriteLine(Symbol & " wins!")
                GameHasEnded = True
                Exit Do
            End If

            Counter += 1

            ' Check for a draw
            If Counter = 9 AndAlso Not GameHasEnded Then
                Console.WriteLine("The game is a draw!")
                GameHasEnded = True
                Exit Do
            End If


            ' Update the Start variable based on the current player's symbol
            If Symbol = "X" Then
                Start = 2
            Else
                Start = 1
            End If

        Loop

        Console.ReadLine()
    End Sub

    Sub Show2DArray(ByVal Board(,) As String)
        For YLooper = 0 To 2 ' Going down 1 row at a time
            For XLooper = 0 To 2 ' Going across 1 column at a time
                Console.Write("| ")
                Console.Write(Board(YLooper, XLooper))
                Console.Write(" | ")
            Next
            Console.WriteLine()
            Console.WriteLine(" ---------------")
        Next
    End Sub

    Function SetUpBoard(ByRef Board(,) As String) As String(,)
        For YLooper = 0 To 2 ' Going down 1 row at a time
            For XLooper = 0 To 2 ' Going across 1 column at a time
                Board(YLooper, XLooper) = "-"
            Next
        Next
        Return Board
    End Function

    Function GetUserGo(ByVal Symbol As String) As String
        Console.WriteLine("")
        Console.Write(Symbol & " enter reference for your move ( e.g. 02 (0 Across, 2 Down) > ")
        Dim Temp As String = Console.ReadLine()
        Return Temp
    End Function

    Function GetXCoord(ByVal UserMove As String) As Char
        Dim temp As Char = Left(UserMove, 2)
        Return temp
    End Function

    Function GetYCoord(ByVal UserMove As String) As Char
        Dim temp As Char = Right(UserMove, 1)
        Return temp
    End Function

    Function MoveValid(ByVal UserMove As String, ByVal Board(,) As String, ByVal XCoord As Char, ByVal YCoord As Char) As Boolean
        Dim Temp As Boolean = True

        If Len(UserMove) <> 2 Then
            Console.WriteLine("Invalid reference length.")
            Temp = False
            Return Temp
        End If

        Dim XVal As Integer = Val(XCoord)
        Dim YVal As Integer = Val(YCoord)

        If XVal > 2 Then
            Console.WriteLine("Incorrect digit in reference.")
            Temp = False
            Return Temp
        End If

        If YVal > 2 Then
            Console.WriteLine("Incorrect digit in reference.")
            Temp = False
            Return Temp
        End If

        If Board(YVal, XVal) = "X" Or Board(YVal, XVal) = "O" Then
            Console.WriteLine("Reference already used.")
            Temp = False
            Return Temp
        End If
        Return Temp
    End Function

    Function UpdateBoard(ByRef Board(,) As String, ByVal XCoord As Char, ByVal YCoord As Char, ByVal Symbol As Char) As String(,)
        Dim X As Integer = Val(XCoord)
        Dim Y As Integer = Val(YCoord)

        Board(Y, X) = Symbol
        Return Board
    End Function

    Function CheckForWinner(ByVal Board(,) As String, ByVal Symbol As Char, ByVal X As Integer, ByVal Y As Integer) As Boolean
        ' Check for a win in the row
        If Board(Y, 0) = Symbol AndAlso Board(Y, 1) = Symbol AndAlso Board(Y, 2) = Symbol Then
            Return True
        End If

        ' Check for a win in the column
        If Board(0, X) = Symbol AndAlso Board(1, X) = Symbol AndAlso Board(2, X) = Symbol Then
            Return True
        End If

        ' Check for a win in the diagonal (if applicable)
        If X = Y AndAlso Board(0, 0) = Symbol AndAlso Board(1, 1) = Symbol AndAlso Board(2, 2) = Symbol Then
            Return True
        End If

        If X + Y = 2 AndAlso Board(0, 2) = Symbol AndAlso Board(1, 1) = Symbol AndAlso Board(2, 0) = Symbol Then
            Return True
        End If

        Return False
    End Function
End Module
