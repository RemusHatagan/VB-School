Module E_Random_Numbers
        Sub Main()
            Randomize()
            Dim TheRandNo As Integer
        TheRandNo = Int(8 * Rnd() + 1) ' Random only provides a fraction less than 1        ' INT TRUNCATES THE DECIMAL
            Console.WriteLine(TheRandNo)
            Console.ReadLine()
        End Sub
End Module
