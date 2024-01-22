Module Z_Sandpit3
    Sub Main()
        Randomize()
        Dim Dictionary() As String
        ImportDictionary(Dictionary)


        Dim BlurredWord As String = "*A**Y"

        Dim Count As Integer = 0
        Dim PossibleLengths() As String
        PossibleLengths = CompareLengths(Dictionary, BlurredWord, PossibleLengths)
        Dim WordPossible As Boolean
        Dim ListOfPossiblewords() As String

        For Repeats = 0 To PossibleLengths.Length - 1
            WordPossible = PossibleWords(PossibleLengths, BlurredWord, Repeats)
            If WordPossible = True Then
                Count += 1
                ReDim Preserve ListOfPossiblewords(Count)
                ListOfPossiblewords(Count - 1) = PossibleLengths(Repeats)
            End If
        Next
        ReDim Preserve ListOfPossiblewords(ListOfPossiblewords.Length - 2)

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
End Module
