Module G_String_Functions
    Sub Main()

        Dim MyString As String
        Dim LeftBit As String
        Dim RightBit As String
        Dim HowLong As Byte
        Dim SingleLetter As Char
        Dim UString As String
        Dim LString As String
        Dim CapString As String

        Console.WriteLine("Type in your last name")
        MyString = Console.ReadLine()

        HowLong = Len(MyString)
        LeftBit = Left(MyString, 1)
        RightBit = Right(MyString, 2)
        SingleLetter = Mid(MyString, 3, 1)
        UString = UCase(MyString)
        LString = LCase(MyString)
        CapString = UCase(Left(MyString, 1)) & LCase(Right(MyString, (Len(MyString) - 1)))

        Console.WriteLine("The number of characters in the name is: " & HowLong)
        Console.WriteLine("The first letter is: " & LeftBit)
        Console.WriteLine("The last two letters are: " & RightBit)
        Console.WriteLine("The third letter is: " & SingleLetter)
        Console.WriteLine("The name in capital letters is: " & UString)
        Console.WriteLine("The name in small letters is: " & LString)
        Console.WriteLine("The name in small letters with a leading capital is: " & CapString)
        Console.ReadLine()
    End Sub
End Module
