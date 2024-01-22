Module M1_Bubble_Sort
    Sub Main()
        Dim TheValues() As Integer = {9, 6, 3, 2, 7, 5, 1}

        TheValues = BubbleSort3(TheValues)
        DisplayArray(TheValues)

        Console.ReadLine()
    End Sub

    Function BubbleSort(TheArray() As Integer) As Integer()
        Dim Temp As Integer

        For Repeats = 0 To (TheArray.Length - 2)
            For Comparisons = 0 To (TheArray.Length - 2)
                If TheArray(Comparisons) > TheArray(Comparisons + 1) Then
                    Temp = TheArray(Comparisons)
                    TheArray(Comparisons) = TheArray(Comparisons + 1)
                    TheArray(Comparisons + 1) = Temp
                End If
            Next
        Next

        Return TheArray
    End Function

    Function BubbleSort2(TheArray() As Integer) As Integer()
        Dim Temp As Integer
        Dim SwapsMade As Boolean = True
        Dim CompsMade As Integer = 0

        'For Repeats = 0 To (TheArray.Length - 2)
        Do
            SwapsMade = False
            For Comparisons = 0 To (TheArray.Length - 2)
                CompsMade += 1
                If TheArray(Comparisons) > TheArray(Comparisons + 1) Then
                    Temp = TheArray(Comparisons)
                    TheArray(Comparisons) = TheArray(Comparisons + 1)
                    TheArray(Comparisons + 1) = Temp
                    SwapsMade = True
                End If
            Next
        Loop Until SwapsMade = False
        'Next

        Return TheArray
    End Function

    Function BubbleSort3(TheArray() As Integer) As Integer()
        Dim Temp As Integer
        Dim SwapsMade As Boolean
        Dim ArrayLength As Integer = TheArray.Length - 2
        Do
            SwapsMade = False
            For Comparisons = 0 To ArrayLength
                If TheArray(Comparisons) > TheArray(Comparisons + 1) Then
                    Temp = TheArray(Comparisons)
                    TheArray(Comparisons) = TheArray(Comparisons + 1)
                    TheArray(Comparisons + 1) = Temp
                    SwapsMade = True
                End If
            Next
            ArrayLength -= 1
        Loop Until SwapsMade = False

        Return TheArray
    End Function

    Sub DisplayArray(ByVal TheArray() As Integer)
        For Looper = 0 To TheArray.Length - 1
            Console.Write(TheArray(Looper) & " ")
        Next
    End Sub

End Module
