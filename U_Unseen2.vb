Module U_Unseen2
    Sub Main()
        Dim isPrime As Boolean = True
        Dim UserNum As Integer
        Dim UserInput As Char
        Do
            isPrime = True
            Console.Write("Enter an integer number > ")
            UserNum = Console.ReadLine
            If UserNum = 1 Then isPrime = False
            For Looper = 2 To UserNum - 1
                If UserNum Mod Looper = 0 Then
                    isPrime = False
                End If
            Next
            If isPrime = True Then Console.WriteLine(UserNum & " is a prime number.")
            If isPrime = False Then Console.WriteLine(UserNum & " is not a prime number.")
            Console.WriteLine("")
            Console.Write("Would you like to test another number? (Y/N) > ")
            UserInput = UCase(Console.ReadLine)
        Loop Until UserInput = "N"
        Console.ReadLine()
    End Sub
End Module
