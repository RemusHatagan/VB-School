Module Z_Sandpit2

    Sub Main()

        Dim LetFreq As Integer = 0
        Dim Dictionary() As String = ReadWordsFromFile(Dictionary)
        Dim Alphabet As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        Dim Frequencies(25) As String
        Dim CurrLet As Integer = 1
        Dim Numbers(25) As Integer

        Console.Write("Enter the hidden word > ")
        Dim HiddenWord As String = UCase(Console.ReadLine())
        Dim WordInList As Boolean = FindWordInArray(HiddenWord, Dictionary)
        Dim AddWord As Boolean = DecisionOfWord(WordInList)

        If AddWord = True Then
            ReDim Preserve Dictionary(Dictionary.Length)
            Dictionary(Dictionary.Length - 1) = HiddenWord
            Dictionary = SortWords(Dictionary)
            WriteWordsToFile(Dictionary)
            Console.WriteLine("")
            Console.Write("Dictionary eddited. Your word has been added. Thank you!")
        End If

        For Looper = 0 To 25
            LetFreq = CountLetterInWord(Dictionary, CurrLet, Alphabet)
            Frequencies(Looper) = LetFreq & "," & Mid(Alphabet, Looper + 1, 1)
            CurrLet += 1
        Next

        SplitStrings(Frequencies, Numbers)
        SortArray(Frequencies, Numbers)
        WriteWordsToFile(Frequencies)


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
End Module