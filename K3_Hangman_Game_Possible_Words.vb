Module K3_Hangman_Game_Possible_Words
    Sub Main()
        Randomize()
        Dim Dictionary() As String
        ImportDictionary(Dictionary)

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

        Dim TheWord As String = "HAPPY"
        Dim BlurredWord As String = "*A**Y"

        Dim Count As Integer = 0
        Dim PossibleLengths() As String
        PossibleLengths = CompareLengths(Dictionary, BlurredWord, PossibleLengths)
        Dim WordPossible As Boolean
        Dim ListOfPossiblewords() As String

        ReDim ListOfPossiblewords(0)
        ListOfPossiblewords = GetPossibleWords(ListOfPossiblewords, PossibleLengths, BlurredWord, Count, WordPossible)

        Console.Clear()

        PlayerName = GetPName()
        Console.WriteLine("")
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
            DisplayPossWords(ListOfPossiblewords)

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
                    Height -= 1

                Else
                    InvalidGuess = False
                    GuessedLetters = GuessedLetters & CurrentLetter
                End If
            Loop
            BlurredWord = UpdateBlurredWord(BlurredWord, CurrentLetter, TheWord)
            GuessNum += 1

            ReDim ListOfPossiblewords(0)
            ListOfPossiblewords = GetPossibleWords(ListOfPossiblewords, PossibleLengths, BlurredWord, Count, WordPossible)

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

    Sub ImportDictionary(ByRef Dictionary() As String)
        Dim Temp As String
        Dim NumOfWords As Integer = 0

        FileOpen(1, "s:\dictionarywords.txt", OpenMode.Input)

        Do While Not EOF(1)
            NumOfWords += 1
            ReDim Preserve Dictionary(NumOfWords)
            Temp = LineInput(1)
            Dictionary(NumOfWords - 1) = Temp
        Loop
        ReDim Preserve Dictionary(Dictionary.Length - 1)

        FileClose(1)

    End Sub

    Function CompareLengths(ByVal Dictionary() As String, ByVal BlurredWord As String, ByRef PossibleLengths() As String) As String()
        Dim TempWord As String
        Dim WordCount As Integer = 0
        For Looper = 0 To (Dictionary.Length - 1)
            TempWord = Dictionary(Looper)
            If Len(BlurredWord) = Len(TempWord) Then
                WordCount += 1
                ReDim Preserve PossibleLengths(WordCount)
                PossibleLengths(WordCount - 1) = Dictionary(Looper)
            End If
        Next
        Return PossibleLengths
    End Function

    Function PossibleWords(ByVal PossibleLengths() As String, ByVal BlurredWord As String, ByVal Repeats As Integer) As Boolean
        For Counter = 1 To Len(BlurredWord)
            If Mid(BlurredWord, Counter, 1) <> "*" Then
                For Looper = 1 To Len(BlurredWord)
                    If Mid(PossibleLengths(Repeats), Counter, 1) <> Mid(BlurredWord, Counter, 1) Then
                        Return False
                    End If
                Next
            End If
        Next
        Return True
    End Function

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

    Sub DisplayPossWords(ByVal ListOfPossibleWords() As String)
        Console.SetCursorPosition(0, 14)
        Console.WriteLine("Possible words : ")
        Console.WriteLine("")
        For Looper = 0 To ListOfPossibleWords.Length - 1
            Console.Write(ListOfPossibleWords(Looper) & " ")
        Next

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

    Function GetPossibleWords(ByRef ListOfPossibleWords() As String, ByVal PossibleLengths() As String, ByVal BlurredWord As String, ByRef Count As Integer, ByRef WordPossible As Boolean) As String()
        Count = 0
        ReDim ListOfPossibleWords(0)
        For Repeats = 0 To PossibleLengths.Length - 1
            WordPossible = PossibleWords(PossibleLengths, BlurredWord, Repeats)
            If WordPossible = True Then
                Count += 1
                ReDim Preserve ListOfPossibleWords(Count)
                ListOfPossibleWords(Count - 1) = PossibleLengths(Repeats)
            End If
        Next
        ReDim Preserve ListOfPossibleWords(ListOfPossibleWords.Length - 2)
        Return ListOfPossibleWords
    End Function
End Module
