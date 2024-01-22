Module K_Hangman_Game

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

        Dim Player1Name As String
        Dim Player2Name As String
        Dim PlayerChoice As String
        Dim WholeWord As String
        Dim GuessNum As Integer = 0

        Console.Clear()

        Player1Name = GetPlayerName("one")
        Player2Name = GetPlayerName("two")
        Console.WriteLine("")

        TheWord = GetAWord(Player1Name, "enter the mystery word > ")
        BlurredWord = BlurWord(TheWord)

        Dim WordInList As Boolean = FindWordInArray(TheWord, Dictionary)
        Dim AddWord As Boolean = DecisionOfWord(WordInList)
        If AddWord = True Then
            ReDim Preserve Dictionary(Dictionary.Length)
            Dictionary(Dictionary.Length - 1) = TheWord
            Dictionary = SortWords(Dictionary)
            WriteWordsToFile(Dictionary)
            Console.WriteLine("")
            Console.Write("Dictionary eddited. Your word has been added. Thank you!")
        End If

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
                CurrentLetter = GetGuessedLetter(Player2Name, Height)
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
                        WholeWord = GetAWord(Player2Name, "guess the whole word > ")
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
            If GuessNum >= 10 Then GameEnded = True

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
            DisplayWin(Player2Name, GuessNum)
        End If

        If GuessNum >= 10 Then
            Console.BackgroundColor = ConsoleColor.DarkRed
            Console.Clear()
            DisplayLoss(Player2Name, TheWord, Player1Name)
        End If

        Console.ReadLine()
    End Sub

    Function GetPlayerName(ByVal PlayerNumber) As String
        Dim Temp
        Console.Write("Player " & PlayerNumber & " enter your name > ")
        Temp = Console.ReadLine
        Return Temp
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

    Function GetGuessedLetter(ByVal Player2Name As String, ByVal Height As Integer) As Char
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

    Sub DisplayLoss(ByVal Player2Name As String, ByVal TheWord As String, ByVal Player1Name As String)
        Console.SetCursorPosition(0, 0)
        Console.WriteLine("")
        Console.WriteLine("Hard luck, " & Player2Name & ", " & "the word was " & TheWord)
        Console.WriteLine(Player1Name & " has won.")
        Console.WriteLine("Press ENTER to finish.")
    End Sub

    Sub DisplayWin(ByVal Player2Name As String, ByVal GuessNum As Integer)
        Console.SetCursorPosition(0, 1)
        Console.WriteLine("")
        Console.WriteLine("Congratulations, " & Player2Name & ", you guessed the word in " & GuessNum & " guesses.")
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

    Sub WriteWordsToFile(ByVal Dictionary() As String)

        FileOpen(1, "S:\DictionaryWords.txt", OpenMode.Output)

        For Looper = 0 To Dictionary.Length - 1
            If Looper < Dictionary.Length - 1 Then
                PrintLine(1, Dictionary(Looper)) ' Prints ONE element each line
            Else
                Print(1, Dictionary(Looper)) ' Prints ALL elements on one line
            End If
        Next

        FileClose(1)
    End Sub

    Function FindWordInArray(ByVal HiddenWord As String, ByVal Dictionary() As String) As Boolean
        Dim Looper As Integer = 0
        Do
            If Dictionary(Looper) = HiddenWord Then
                Return True
            End If
            Looper += 1
        Loop Until Looper = Dictionary.Length
        Return False
    End Function

    Function DecisionOfWord(ByVal WordInList As Boolean) As Boolean
        If WordInList = False Then
            Console.Write("The word you entered does not exist in the list. Would you like to add it? (Y/N) > ")
            Dim Choice As Char = UCase(Console.ReadLine())
            If Choice = "Y" Then
                Return True
            Else
                Return False
            End If
        Else
            Console.Write("The word is in the list and is legitemate.")
            Return False
        End If
    End Function

    Function SortWords(ByVal Dictionary() As String) As String()
        Dim Temp As String
        Dim SwapsMade As Boolean = True
        Dim CompsMade As Integer = 0
        Dim ArrayLength As Integer = Dictionary.Length - 2
        Do
            SwapsMade = False
            For Comparisons = 0 To ArrayLength
                CompsMade += 1
                If Dictionary(Comparisons) > Dictionary(Comparisons + 1) Then
                    Temp = Dictionary(Comparisons)
                    Dictionary(Comparisons) = Dictionary(Comparisons + 1)
                    Dictionary(Comparisons + 1) = Temp
                    SwapsMade = True

                End If
            Next
            ArrayLength -= 1
        Loop Until SwapsMade = False

        Return Dictionary
    End Function

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
End Module

'Sub DrawHangingMan(ByVal WrongGuesses As Byte)
'    If WrongGuesses = 10 Then _
'        Console.ForegroundColor = ConsoleColor.DarkRed
'    ' 1. Wrong Guess:- Base horizontal of gallows, 5 underscore characters
'    If WrongGuesses >= 1 Then
'        For looper = 50 To 54
'            Console.SetCursorPosition(looper, 7)
'            Console.Write("_")
'        Next
'    End If
'    ' 2. Wrong Guesses:- Long vertical of gallows, 7 x '|' symbol
'    If WrongGuesses >= 2 Then
'        For looper = 1 To 7
'            Console.SetCursorPosition(52, looper)
'            Console.Write("|")
'        Next
'    End If
'    ' 3. Wrong Guesses:- Top horizontal of gallows, 6 underscore characters
'    ' (alternative method from 1. above)
'    If WrongGuesses >= 3 Then
'        Console.SetCursorPosition(48, 0)
'        Console.Write("______")
'    End If
'    ' 4. Wrong Guesses:- Long vertical of rope, 2 x '|' symbol
'    ' (alternative method from 2. above)
'    If WrongGuesses >= 4 Then
'        Console.SetCursorPosition(50, 1)
'        Console.Write("|")
'        Console.SetCursorPosition(50, 2)
'        Console.Write("|")
'    End If

'    ' 5. to 10.  Wrong Guesses:- Individual body parts of the hanged man

'    If WrongGuesses >= 5 Then
'        Console.SetCursorPosition(50, 3)
'        Console.Write("O") ' HEAD
'        'Console.Write(Chr(2)) ' SMILEY FACE SYMBOL (may show as '?' at first)
'    End If
'    If WrongGuesses >= 6 Then
'        Console.SetCursorPosition(50, 4)
'        Console.Write("|") ' BODY 1
'        Console.SetCursorPosition(50, 5)
'        Console.Write("^") ' BODY 2
'    End If
'    If WrongGuesses >= 7 Then
'        Console.SetCursorPosition(49, 4)
'        Console.Write("<") ' LEFT ARM
'    End If
'    If WrongGuesses >= 8 Then
'        Console.SetCursorPosition(51, 4)
'        Console.Write(">") ' RIGHT ARM
'    End If
'    If WrongGuesses >= 9 Then
'        Console.SetCursorPosition(49, 5)
'        Console.Write("/") ' LEFT LEG
'    End If
'    If WrongGuesses >= 10 Then
'        Console.SetCursorPosition(51, 5)
'        Console.Write("\") ' RIGHT LEG
'        Console.ForegroundColor = ConsoleColor.Gray
'    End If
'    Console.WriteLine()
'End Sub