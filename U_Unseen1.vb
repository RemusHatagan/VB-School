Module U_Unseen1
    Sub Main()
        Console.Write("Enter a denary number you want to convert to binary > ")
        Dim Number As Integer = Console.ReadLine
        Dim BinaryString As String
        Dim DividedNum As Integer = Number
        Do
            BinaryString = (DividedNum Mod 2) & BinaryString
            DividedNum = DividedNum \ 2
        Loop Until DividedNum / 2 = 0
        Console.WriteLine(Number & " in binary is : " & BinaryString)
        Console.ReadLine()
    End Sub
End Module