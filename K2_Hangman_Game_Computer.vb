Module K2_Hangman_Game_Computer
    Sub Main()
        Randomize()
        Dim TheWord As String
        Dim BlurredWord As String
        Dim WordGuessed As Boolean = False
        Dim GameEnded As Boolean = False

        Dim GuessedLetters As String = ""
        Dim CurrentLetter As Char
        Dim Letter() As String

        Dim PlayerName As String
        Dim GuessNum As Integer = 0

        Dim LetFreq As Integer = 0
        Dim Dictionary() As String = ReadWordsFromFile(Dictionary)
        Dim Alphabet As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        Dim Frequencies(25) As String
        Dim CurrLet As Integer = 1
        Dim Numbers(25) As Integer

        PlayerName = GetPName()

        For Looper = 0 To 25
            LetFreq = CountLetterInWord(Dictionary, CurrLet, Alphabet)
            Frequencies(Looper) = LetFreq & "," & Mid(Alphabet, Looper + 1, 1)
            CurrLet += 1
        Next

        SplitStrings(Frequencies, Numbers)
        SortArray(Frequencies, Numbers)
        WriteWordsToFile(Frequencies)

        Console.WriteLine("")
        TheWord = GenerateMysteryWord(Dictionary)
        BlurredWord = BlurWord(TheWord)
        Console.Clear()

        Dim Height As Integer = 8

        Do While GameEnded = False
            Console.SetCursorPosition(0, 6)
            Console.WriteLine("The word is " & BlurredWord)
            DisplayUsedLetters(GuessedLetters)
            Console.SetCursorPosition(0, 0)

            Do While GuessNum < 10
                Letter = Split(Frequencies(GuessNum), ",")
                CurrentLetter = Letter(1)
                GuessedLetters = GuessedLetters & CurrentLetter

                Console.SetCursorPosition(0, 3)
                Console.Write("I guess ... " & CurrentLetter)
                BlurredWord = UpdateBlurredWord(BlurredWord, CurrentLetter, TheWord)
                Height += 1
                GuessNum += 1

                If BlurredWord = TheWord Then
                    Console.SetCursorPosition(0, 3)
                    Console.WriteLine("The word was " & TheWord)
                    WordGuessed = True
                End If

                If WordGuessed = True Then GameEnded = True
                If GuessNum >= 10 Then GameEnded = True

                DrawHangMan(GuessNum)

                Console.SetCursorPosition(0, 6)
                Console.WriteLine("The word is " & BlurredWord)

                DisplayUsedLetters(GuessedLetters)

                WasteTime2()
            Loop



            If GuessNum >= 10 Then GameEnded = True
        Loop

        WasteTime()



        Console.SetCursorPosition(0, 5)
        Console.Clear()

        If WordGuessed = True Then
            Console.ForegroundColor = ConsoleColor.Black
            Console.BackgroundColor = ConsoleColor.DarkGreen
            Console.Clear()
            DisplayLoss(PlayerName)
        End If

        If GuessNum >= 10 Then
            Console.BackgroundColor = ConsoleColor.DarkRed
            Console.Clear()
            DisplayWin(PlayerName)
        End If

        Console.ReadLine()

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

    Function CountLetterInWord(ByVal Dictionary() As String, ByVal CurrLet As Integer, ByVal Letters As String) As String
        Dim Temp As Integer = 0
        For Loops = 0 To Dictionary.Length - 1
            For Looper = 1 To Len(Dictionary(Loops))
                If Mid(Letters, CurrLet, 1) = Mid(Dictionary(Loops), Looper, 1) Then
                    Temp += 1
                End If
            Next
        Next
        Return Temp
    End Function

    Sub WriteWordsToFile(ByVal Frequencies() As String)

        FileOpen(1, "S:\Frequencies.txt", OpenMode.Output)

        For Looper = 0 To Frequencies.Length - 1
            If Looper < Frequencies.Length - 1 Then
                PrintLine(1, Frequencies(Looper)) ' Prints ONE element each line
            Else
                Print(1, Frequencies(Looper)) ' Prints ALL elements on one line
            End If
        Next

        FileClose(1)
    End Sub

    Sub SplitStrings(ByVal Frequencies() As String, ByRef Numbers() As Integer)

        Dim X() As String
        For Looper = 0 To Frequencies.Length - 1
            X = Split(Frequencies(Looper), ",")
            Numbers(Looper) = X(0)
        Next
    End Sub

    Sub SortArray(ByVal Frequencies() As String, ByVal Numbers() As Integer)
        Dim Temp As String
        Dim TempNum As Integer
        Dim SwapsMade As Boolean = True
        Dim ArrayLength As Integer = Numbers.Length - 2
        Do
            SwapsMade = False
            For Comparisons = 0 To ArrayLength
                If Numbers(Comparisons) < Numbers(Comparisons + 1) Then
                    Temp = Frequencies(Comparisons)
                    TempNum = Numbers(Comparisons)
                    Frequencies(Comparisons) = Frequencies(Comparisons + 1)
                    Numbers(Comparisons) = Numbers(Comparisons + 1)
                    Frequencies(Comparisons + 1) = Temp
                    Numbers(Comparisons + 1) = TempNum
                    SwapsMade = True

                End If
            Next
            ArrayLength -= 1
        Loop Until SwapsMade = False
    End Sub

    Function GetPName() As String
        Dim Temp
        Console.Write("Enter your name > ")
        Temp = Console.ReadLine
        Return Temp
    End Function

    Sub DisplayLoss(ByVal PlayerName As String)
        Console.SetCursorPosition(0, 0)
        Console.WriteLine("")
        Console.WriteLine("Hard luck, " & PlayerName & ", " & "the computer guessed the word!")
        Console.WriteLine("The computer has won.")
        Console.WriteLine("Press ENTER to finish.")
    End Sub

    Sub DisplayWin(ByVal PlayerName As String)
        Console.SetCursorPosition(0, 1)
        Console.WriteLine("")
        Console.WriteLine("Congratulations, " & PlayerName & ", the computer could not guess the word!")
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

    Function BlurWord(ByVal TheWord As String) As String
        Dim Temp
        For Looper = 1 To Len(TheWord)
            Temp = Temp & "_"
        Next
        Return Temp
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
