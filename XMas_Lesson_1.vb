Module XMas_Lesson_1
    ' make your own screen saver
    Dim RandXPos As Integer
    Dim RandYPos As Integer
    Dim RandBackCol As Integer
    Dim RandForeCol As Integer
    Dim RandLetterASCII As Integer
    Dim CheckArray(40, 132) As Boolean
    Dim PixelDetails(,,) As Integer
    Dim TheLimit As Integer = 40 * 132
    Dim PixelCounter As Integer
    Sub Main()
        Randomize()
        ReDim PixelDetails(40, 132, 2)
        ' console.readline()
        Console.SetBufferSize(133, 41)
        Console.SetWindowSize(133, 41)
        Do
            DrawOriginalScreen()
            'console.readline()
            System.Threading.Thread.Sleep(900)

            WipeRight()
            'console.readline()
            System.Threading.Thread.Sleep(900)

            ReDrawOriginalScreen()
            'console.readline()
            System.Threading.Thread.Sleep(900)

            WipeUpWards()
            'console.readline()
            System.Threading.Thread.Sleep(900)

            ReDrawOriginalScreen()
            'console.readline()
            System.Threading.Thread.Sleep(900)

            WipeDownWards()
            'console.readline()
            System.Threading.Thread.Sleep(900)

            ReDrawOriginalScreen()
            'console.readline()
            System.Threading.Thread.Sleep(900)

            WipeLeft()
            'console.readline()
            System.Threading.Thread.Sleep(900)

            ReDrawOriginalScreen()
            'console.readline()
            System.Threading.Thread.Sleep(900)
        Loop

        Console.ReadLine()
    End Sub
    Sub DrawOriginalScreen()
        Do
            RandXPos = Int(132 * Rnd())
            RandYPos = Int(40 * Rnd())
            If CheckArray(RandYPos, RandXPos) = False Then
                RandLetterASCII = Int(26 * Rnd() + 65)
                RandBackCol = Int(15 * Rnd() + 1)
                Do
                    RandForeCol = Int(15 * Rnd() + 1)
                Loop Until RandBackCol <> RandForeCol

                Console.ForegroundColor = RandForeCol
                Console.BackgroundColor = RandBackCol
                Console.SetCursorPosition(RandXPos, RandYPos)
                System.Threading.Thread.Sleep(1)
                Console.Write(Chr(RandLetterASCII))
                CheckArray(RandYPos, RandXPos) = True
                PixelDetails(RandYPos, RandXPos, 0) = RandLetterASCII
                PixelDetails(RandYPos, RandXPos, 1) = RandBackCol
                PixelDetails(RandYPos, RandXPos, 2) = RandForeCol
                PixelCounter += 1
            End If
        Loop Until PixelCounter = TheLimit
    End Sub
    Sub ReDrawOriginalScreen()
        Console.BackgroundColor = ConsoleColor.DarkYellow
        For XLoop = 0 To 131
            For YLoop = 0 To 39
                Console.SetCursorPosition(XLoop, YLoop)
                RandLetterASCII = PixelDetails(YLoop, XLoop, 0)
                Console.BackgroundColor = PixelDetails(YLoop, XLoop, 1)
                Console.ForegroundColor = PixelDetails(YLoop, XLoop, 2)
                System.Threading.Thread.Sleep(2)
                Console.Write(Chr(RandLetterASCII))
                'Console.Write(" ")
            Next
        Next
    End Sub
    Sub WipeUpWards()
        Console.BackgroundColor = ConsoleColor.Blue
        For YLoop = 40 To 0 Step -1
            For XLoop = 0 To 132
                Console.SetCursorPosition(XLoop, YLoop)
                System.Threading.Thread.Sleep(2)
                Console.Write(" ")
            Next
        Next
    End Sub
    Sub WipeRight()
        Console.BackgroundColor = ConsoleColor.DarkYellow
        For XLoop = 0 To 132
            For YLoop = 0 To 40
                Console.SetCursorPosition(XLoop, YLoop)
                System.Threading.Thread.Sleep(2)
                Console.Write(" ")
            Next
        Next
    End Sub

    Sub WipeDownWards()
        Console.BackgroundColor = ConsoleColor.Magenta
        For YLoop = 0 To 40
            For XLoop = 0 To 132
                Console.SetCursorPosition(XLoop, YLoop)
                System.Threading.Thread.Sleep(2)
                Console.Write(" ")
            Next
        Next
    End Sub

    Sub WipeLeft()
        Console.BackgroundColor = ConsoleColor.Gray
        For XLoop = 132 To 0 Step -1
            For YLoop = 0 To 40
                Console.SetCursorPosition(XLoop, YLoop)
                System.Threading.Thread.Sleep(2)
                Console.Write(" ")
            Next
        Next
    End Sub

End Module