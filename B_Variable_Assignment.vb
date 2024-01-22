Module B_Variable_Assignment

    Sub Main()

        Dim MyAge As Byte
        Dim MyAgeInDogYears As Integer
        Dim MyFutureAge As Byte

        Console.WriteLine("Please enter your age in years > ")
        Console.WriteLine("")
        MyAge = Console.ReadLine ' ASSIGNMENT STATEMENT
        ' MyAge = 65 ' ASSIGNMENT STATEMENT

        Console.WriteLine("")
        Console.WriteLine("Your age is " & MyAge)
        MyAgeInDogYears = MyAge * 7
        Console.WriteLine("Your age in dog years is " & MyAgeInDogYears)
        MyFutureAge = MyAge + 5
        Console.WriteLine("Your age in 5 years time will be " & MyFutureAge)
        Console.ReadLine()

    End Sub
End Module
