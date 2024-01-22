Module C_Two_Numbers

    Sub Main()

        ' DECLARING VARIABLES
        Dim Num1 As Single
        Dim Num2 As Single
        Dim Total As Single
        Dim Average As Single
        Dim Biggest As Single
        Dim Smallest As Single
        Dim BothEqual As Boolean = False

        'CALLING FUNCTIONS
        GetNumbers(Num1, Num2)
        Calculations(Num1, Num2, Total, Average, Biggest, Smallest, BothEqual)
        Display(Num1, Num2, Total, Average, Biggest, Smallest, BothEqual)
        Console.ReadLine()

    End Sub

    Sub GetNumbers(ByRef Num1 As Single, ByRef Num2 As Single)

        'RETRIEVING NUMBERS
        Console.Write("Enter the first number > ")
        Num1 = Console.ReadLine
        Console.Write("Enter the second number > ")
        Num2 = Console.ReadLine

    End Sub

    Sub Calculations(ByVal Num1 As Single, ByVal Num2 As Single, ByRef Total As Single, ByRef Average As Single, ByRef Biggest As Single, ByRef Smallest As Single, ByRef BothEqual As Boolean)

        'CALCULATIONS
        Total = Num1 + Num2
        Average = (Num1 + Num2) / 2

        'SELECTIONS
        If Num1 > Num2 Then
            Biggest = Num1
            Smallest = Num2
        ElseIf Num2 > Num1 Then
            Biggest = Num2
            Smallest = Num1
        Else
            If Num1 = Num2 Then
                BothEqual = True
                Biggest = Num1
                Smallest = Num2
            End If
        End If

    End Sub

    Sub Display(ByVal Num1 As Single, ByVal Num2 As Single, ByVal Total As Single, ByVal Average As Single, ByVal Biggest As Single, ByVal Smallest As Single, ByVal BothEqual As Boolean)

        'DISPLAY STATISTICS
        Console.WriteLine("")
        Console.WriteLine("The two numbers were " & Num1 & " and " & Num2)
        Console.WriteLine("The total is > " & Total)
        Console.WriteLine("The average is > " & Average)
        Console.WriteLine("The largest value is > " & Biggest)
        Console.WriteLine("The smallest value is > " & Smallest)

        'COMPARISON DISPLAY
        If BothEqual = True Then
            Console.WriteLine("The numbers ARE the same as each other")
        Else
            Console.WriteLine("The number ARE NOT the same as each other")
        End If

    End Sub

End Module