Module A_Program_Flow

    Sub Main() ' THE PROGRAM FLOW STARTS HERE

        Console.WriteLine("Hello World!")
        Console.WriteLine("Press ENTER to continue > ")
        Console.ReadLine()
        MrPeters() ' JUMP TO LINE NUMBER 17
        Console.WriteLine("Hello World! AGAIN")
        Console.WriteLine("Press ANY KEY to continue > ")
        Console.ReadKey()
        Console.WriteLine("ENDING PROGRAM ... ")
        Console.Read()

    End Sub ' THIS MEANS "THIS IS THE END OF THE PROGRAM" 

    Sub MrPeters()

        MrNash() ' JUMP TO LINE NUMBER 26
        Console.WriteLine("Hello Mr. Peters")
        Console.WriteLine("Press ENTER to continue > ")
        Console.ReadLine()

    End Sub ' THIS MEANS "GO BACK TO WHERE YOU CAME FROM"  --  JUMP TO LINE NUMBER 9

    Sub MrNash()

        Console.WriteLine("Hello Mr. Nash")
        Console.WriteLine("Press ENTER to continue > ")
        Console.ReadLine()

    End Sub ' JUMP TO LINE NUMBER 20

End Module
