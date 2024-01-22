Module B1_Assignment2
    Sub Main()

        Dim FirstName As String
        Dim Age As Integer
        Dim Score As Single

        Console.WriteLine("Enter your first name > ")
        FirstName = Console.ReadLine
        Console.WriteLine("Hello " & FirstName)
        Console.WriteLine("How old are you ? > ")
        Age = Console.ReadLine
        Console.WriteLine("You are " & Age & " " & FirstName & ", nice age to be.")
        Console.WriteLine("In 5 years time you will be " & (Age + 5))
        Console.WriteLine("You are " & Age & " " & FirstName)
        Console.WriteLine("What is your average GCSE points score? > ")
        Score = Console.ReadLine
        Console.WriteLine("Wow, " & Score & " " & FirstName & ", that is good!")
        Console.WriteLine("Well, it is better than " & Score - 1)
        Console.WriteLine("But not as good as " & Score + 1 & " though!")
        Console.ReadLine()

    End Sub
End Module
