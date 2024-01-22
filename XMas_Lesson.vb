Module XMas_Lesson
    ' Make your own screen saver
    Dim randxpos As Integer
    Dim randypos As Integer
    Dim checkarray(41, 133) As Boolean
    Dim counter As Integer = 0
    Dim temp As Integer
    Dim Limit As Integer = 40 * 132

    Sub Main()
        Randomize()
        Console.SetBufferSize(133, 41)
        Console.SetWindowSize(133, 41)

        ' Run the screen saver
        RunScreenSaver()

        Console.ReadLine()
    End Sub


    Sub RunScreenSaver()
        Do
            Console.ForegroundColor = Int(15 * Rnd()) + 1 ' Set random foreground color

            randxpos = Int(133 * Rnd()) ' Generate random x position
            randypos = Int(40 * Rnd())  ' Generate random y position

            If checkarray(randypos, randxpos) = False Then
                Console.SetCursorPosition(randxpos, randypos)

                ' Generate a random uppercase letter (ASCII values 65 to 90)
                temp = 25 * Rnd() + 65
                Console.Write(Chr(temp))

                checkarray(randypos, randxpos) = True
                counter += 1
            End If
        Loop Until counter = Limit ' Break out of the loop when the entire console is filled
    End Sub
End Module