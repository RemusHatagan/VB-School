Module N_2D_Arrays
    Dim Board(,) As String ' 3 x 3 2D array of strings
    Sub Main()
        Randomize()
        ReDim Board(2, 2)
        FillArray()
        ShowArray()
        Console.ReadLine()
    End Sub

    Sub ShowArray()
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

    Sub FillArray()
        For YLooper = 0 To 2 ' Going down 1 row at a time
            For XLooper = 0 To 2 ' Going across 1 column at a time
                Board(YLooper, XLooper) = Int(10 * Rnd())
            Next
        Next
    End Sub
End Module
