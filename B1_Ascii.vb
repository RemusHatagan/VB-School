Module B1_Ascii
    Sub Main()
        Dim UserInput As Char = ""
        Dim ASCIICode As Integer
        GetInputs(UserInput)
        Calculate(UserInput, ASCIICode)
        Output(UserInput, ASCIICode)
        Console.ReadLine()
    End Sub

    Sub GetInputs(ByRef UserInput As Char)
        Console.Write("Enter the character > ")
        UserInput = Console.ReadLine()
    End Sub

    Sub Calculate(ByVal UserInput As Char, ByRef ASCIICode As Integer)
        ASCIICode = Asc(UserInput)
    End Sub

    Sub Output(ByVal UserInput As Char, ByVal ASCIICode As Integer)
        Console.WriteLine(UserInput & " in ASCII is " & ASCIICode)
    End Sub
End Module
