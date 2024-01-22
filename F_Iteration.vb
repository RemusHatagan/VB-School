Module F_Iteration
    Sub Main()

        'DefiniteIteration1()
        'DefiniteIteration2()
        'IndefiniteIteration1()
        'IndefiniteIteration2()
        Console.ReadLine()
    End Sub

    Sub DefiniteIteration1()
        ' When we know how many times to repeat things.
        For Looper = 1 To 10
            Console.WriteLine("The counter is now > " & Looper)
            WasteTime()
        Next
    End Sub


    Sub IndefiniteIteration1()
        Dim StopRepeating As Boolean = False ' not needed, Booleans are all false to start
        Dim PassWord As String = ""

        Do While StopRepeating = False ' loop termination CONDITION
            Console.Write("ENTER YOUR PASSWORD. (Put Caps Lock on.) > ")
            PassWord = Console.ReadLine()
            If PassWord = "LPBS" Then
                StopRepeating = True
                Console.WriteLine("")
                Console.WriteLine("Welcome to Langley Park Boys School !")
            End If
        Loop ' when StopRepeating = TRUE the program moves on past the loop

    End Sub

    Sub DefiniteIteration2()
        'sometimes you may want to count backwards in a definite iteration loop
        'in which case you have to start with the high number (10)
        'to count backwards to the loop limit, in this case a smaller number (1)
        'TO COUNT BACKWARDS you have to include a NEGATIVE STEP

        For Counter = 10 To 1 Step -1 ' counting backwards
            Console.WriteLine("The counter is now > " & Counter)
            WasteTime()
        Next
        Console.WriteLine("The loop has now finished. Press ENTER to continue.")
    End Sub

    Sub IndefiniteIteration2()
        Dim StopRepeating As Boolean = False ' Even if TRUE it will run at least once regardless
        Dim PassWord As String = ""
        Do 'no condition at this point, so code below must run at least once
            Console.Write("ENTER YOUR PASSWORD. (Put Caps Lock on.) > ")
            PassWord = Console.ReadLine()
            If PassWord = "LPBS" Then
                StopRepeating = True
                Console.WriteLine("")
                Console.WriteLine("Welcome to Langley Park Boys School !")
            End If
        Loop Until StopRepeating = True ' loop termination CONDITION
    End Sub

    Sub WasteTime()
        For Looper = 1 To 1000000000
            ' Doing nothing here.
        Next
    End Sub

    Sub WasteTime2()
        For Looper = 1 To 500000000
            ' Doing nothing here.
        Next
    End Sub

End Module
