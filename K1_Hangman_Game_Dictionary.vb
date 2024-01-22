Module K1_Hangman_Game_Dictionary
    Sub Main()
        Randomize()

        Dim Dictionary() As String = ReadWordsFromFile(Dictionary)
        Dim TheWord As String
        Dim BlurredWord As String
        Dim WordGuessed As Boolean = False
        Dim GameEnded As Boolean = False

        Dim GuessedLetters As String = ""
        Dim CurrentLetter As Char
        Dim AlreadyGuessed As Boolean = True
        Dim InvalidGuess As Boolean = True

        Dim PlayerName As String
        Dim PlayerChoice As String
        Dim WholeWord As String
        Dim GuessNum As Integer = 0

        Console.Clear()

        PlayerName = GetPName()
        Console.WriteLine("")
        TheWord = GenerateMysteryWord(Dictionary)
        BlurredWord = BlurWord(TheWord)
        Console.Clear()

        Dim Height As Integer = 8

        Do While GameEnded = False

            InvalidGuess = True
            AlreadyGuessed = True
            Console.SetCursorPosition(0, 6)
            Console.WriteLine("The word is " & BlurredWord)
            DisplayUsedLetters(GuessedLetters)
            Console.SetCursorPosition(0, 0)
            Console.WriteLine("Type '?' to guess the whole word or reveal the answer.")

            Do While InvalidGuess = True
                CurrentLetter = GetGuessedLetter(Height)
                If CurrentLetter = "?" Then
                    Console.SetCursorPosition(0, Height)
                    Console.Write("Press 1 to enter the word, or 2 to reveal the answer > ")
                    PlayerChoice = Console.ReadKey.KeyChar

                    If PlayerChoice = 2 Then
                        GameEnded = True
                        WordGuessed = False
                        GuessNum = 10
                    End If

                    If PlayerChoice = 1 Then
                        Console.SetCursorPosition(0, (Height + 1))
                        WholeWord = GetAWord(PlayerName, "guess the whole word > ")
                        Console.WriteLine("")

                        If WholeWord = TheWord Then
                            GameEnded = True
                            WordGuessed = True
                        Else
                            GameEnded = True
                            WordGuessed = False
                            GuessNum = 10
                        End If
                    End If
                End If

                AlreadyGuessed = AlreadyHadLetter(GuessedLetters, CurrentLetter)
                If AlreadyGuessed = True Then
                    Height += 1
                    Console.SetCursorPosition(0, Height)
                    Console.WriteLine("Letter already guessed.")
                    InvalidGuess = True
                    Height += 1

                Else
                    InvalidGuess = False
                    GuessedLetters = GuessedLetters & CurrentLetter
                End If
            Loop
            BlurredWord = UpdateBlurredWord(BlurredWord, CurrentLetter, TheWord)
            Height += 1
            GuessNum += 1

            If BlurredWord = TheWord Then
                Console.SetCursorPosition(0, 3)
                Console.WriteLine("The word was " & TheWord)
                WordGuessed = True
            End If

            If WordGuessed = True Then GameEnded = True
            If GuessNum > 10 Then GameEnded = True

            DrawHangMan(GuessNum)
        Loop

        Console.SetCursorPosition(0, 6)
        Console.WriteLine("The word is " & BlurredWord)
        DisplayUsedLetters(GuessedLetters)

        WasteTime()


        Console.SetCursorPosition(0, 5)
        Console.Clear()

        If WordGuessed = True Then
            Console.ForegroundColor = ConsoleColor.Black
            Console.BackgroundColor = ConsoleColor.DarkGreen
            Console.Clear()
            DisplayWin(PlayerName, GuessNum)
        End If

        If GuessNum > 10 Then
            Console.BackgroundColor = ConsoleColor.DarkRed
            Console.Clear()
            DisplayLoss(PlayerName, TheWord)
        End If

        Console.ReadLine()
    End Sub

    Function GetPName() As String
        Dim Temp
        Console.Write("Enter your name > ")
        Temp = Console.ReadLine
        Return Temp
    End Function

    Sub DisplayLoss(ByVal PlayerName As String, ByVal TheWord As String)
        Console.SetCursorPosition(0, 0)
        Console.WriteLine("")
        Console.WriteLine("Hard luck, " & PlayerName & ", " & "the word was " & TheWord)
        Console.WriteLine("The computer has won.")
        Console.WriteLine("Press ENTER to finish.")
    End Sub

    Sub DisplayWin(ByVal PlayerName As String, ByVal GuessNum As Integer)
        Console.SetCursorPosition(0, 1)
        Console.WriteLine("")
        Console.WriteLine("Congratulations, " & PlayerName & ", you guessed the word in " & GuessNum & " guesses.")
    End Sub

    Function ReadWordsFromFile(ByRef Dictionary() As String) As String()

        FileOpen(1, "S:\DictionaryWords.txt", OpenMode.Input)

        Dim CurrentWord As String
        Dim NumOfWords As Integer = 0

        Do While Not EOF(1)
            CurrentWord = LineInput(1)
            NumOfWords += 1
            ReDim Preserve Dictionary(NumOfWords)
            Dictionary((NumOfWords - 1)) = CurrentWord
        Loop
        ReDim Preserve Dictionary(NumOfWords - 1)

        FileClose(1)
        Return Dictionary

    End Function

    Function GenerateMysteryWord(ByVal Dictionary() As String) As String
        Dim temp As String
        Dim randnum As Integer = Int(Rnd() * Dictionary.Length - 1) + 1
        temp = Dictionary(randnum)
        Return temp
    End Function

    Function GetAWord(ByVal PlayerName As String, ByVal Reference As String) As String
        Dim Temp As String
        Dim Accepted As Boolean = False
        Do
            Console.Write(PlayerName & ", " & Reference)
            Temp = UCase(Console.ReadLine)
            For Looper = 1 To Len(Temp)
                If InStr("0123456789`¬!£$%^&*()_+{}~@[]'#/.,<>|?", Mid(Temp, Looper, 1)) = 0 Then Accepted = True
                If InStr("0123456789`¬!£$%^&*()_+{}~@[]'#/.,<>|?", Mid(Temp, Looper, 1)) <> 0 Then Accepted = False
            Next
        Loop Until Accepted = True
        Console.WriteLine("")
        Return Temp
    End Function

    Function BlurWord(ByVal TheWord As String) As String
        Dim Temp
        For Looper = 1 To Len(TheWord)
            Temp = Temp & "_"
        Next
        Return Temp
    End Function

    Function GetGuessedLetter(ByVal Height As Integer) As Char
        Dim Temp As Char
        Do
            Console.SetCursorPosition(0, Height)
            Console.Write("Enter your next guessed letter > ")
            Temp = UCase(Console.ReadKey.KeyChar)
        Loop Until InStr("ABCDEFGHIJKLMNOPQRSTUVWXYZ?", Temp) > 0
        Return Temp
    End Function

    Function AlreadyHadLetter(ByVal GuessedLetters As String, ByVal CurrentLetter As String) As Boolean
        If InStr(GuessedLetters, CurrentLetter) = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Function UpdateBlurredWord(ByVal BlurredWord As String, ByVal CurrentLetter As String, ByVal TheWord As String) As String

        For Looper = 1 To Len(TheWord)
            If CurrentLetter = Mid(TheWord, Looper, 1) Then
                Mid(BlurredWord, Looper, 1) = CurrentLetter
            End If
        Next
        UpdateBlurredWord = BlurredWord
    End Function

    Sub DisplayUsedLetters(ByVal GuessedLetters)
        Console.SetCursorPosition(26, 6)
        Console.WriteLine("Used letters : " & GuessedLetters)
    End Sub

    Sub DrawHangMan(ByVal GuessNum As Integer)
        If GuessNum > 0 Then
            Console.SetCursorPosition(60, 13)
            Console.Write("_____")
        End If

        If GuessNum > 1 Then
            For Looper = 1 To 6
                Console.SetCursorPosition(65, (14 - Looper))
                Console.Write("|")
            Next
        End If

        If GuessNum > 2 Then
            Console.SetCursorPosition(60, 7)
            Console.Write("_____")
        End If

        If GuessNum > 3 Then
            Console.SetCursorPosition(60, 8)
            Console.Write("|")
        End If

        If GuessNum > 4 Then
            Console.SetCursorPosition(60, 9)
            Console.Write("O")
        End If


        If GuessNum > 5 Then
            Console.SetCursorPosition(60, 10)
            Console.Write("|")
        End If


        If GuessNum > 6 Then
            Console.SetCursorPosition(59, 11)
            Console.Write("/")
        End If

        If GuessNum > 7 Then
            Console.SetCursorPosition(61, 11)
            Console.Write("\")
        End If

        If GuessNum > 8 Then
            Console.SetCursorPosition(59, 10)
            Console.Write("-")
        End If

        If GuessNum > 9 Then
            Console.SetCursorPosition(61, 10)
            Console.Write("-")
        End If
    End Sub

End Module
