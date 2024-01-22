Module G_Guess_The_Number
    Sub Main()
        Randomize()

        Dim ThoughtNumber As Integer
        Dim GuessedNumber As Integer
        Dim GuessedCorrectly As Boolean = False
        Dim GuessCounter As Integer
        Dim NumRange As Integer
        Dim Temperature As String = ""
        Dim Difference As Integer
        Dim NumScaleFactor As Integer

        Range(NumRange)
        Limit(GuessCounter)
        GetThoughtNumb(ThoughtNumber, NumRange, GuessCounter)
        WasteTime()
        Console.WriteLine(ThoughtNumber)

        Do Until GuessedCorrectly = True
            GetGuessedNum(GuessedNumber)
            GuessCounter -= 1
            TempHinting(Temperature, ThoughtNumber, GuessedNumber, Difference, NumRange, NumScaleFactor)
            If GuessCounter = 0 Then
                Console.WriteLine("You have 0 guesses left.")
                Console.WriteLine("You have run out of guesses, the number was " & ThoughtNumber & ".")
                Console.WriteLine("Press ENTER to end this game.")
                Stop
            End If
            CompareNumbs(ThoughtNumber, GuessedNumber, GuessedCorrectly)
            DisplayAnswer(GuessedCorrectly, GuessCounter, Temperature)
            'ReportResultsSoFar(GuessedCorrectly, GuessCounter, ThoughtNumber, GuessedNumber)
        Loop

        Console.ReadLine()
    End Sub

    Sub GetThoughtNumb(ByRef ThoughtNumber As Integer, ByVal NumRange As Integer, ByVal GuessCounter As Integer)
        ThoughtNumber = Int(NumRange * Rnd() + 1)
        Console.WriteLine("I am thinking of a number between 1 and " & NumRange & ".")
        Console.WriteLine("You have " & GuessCounter & " guesses to find it.")
        Console.WriteLine("")
    End Sub

    Sub GetGuessedNum(ByRef GuessedNumber As Integer)
        Console.Write("Enter your guess > ")
        GuessedNumber = Console.ReadLine()
    End Sub

    Sub CompareNumbs(ByVal ThoughtNumber As Integer, ByVal GuessedNumber As Integer, ByRef GuessedCorrectly As Boolean)
        If GuessedNumber = ThoughtNumber Then
            GuessedCorrectly = True
        End If
    End Sub

    Sub DisplayAnswer(ByVal GuessedCorrectly As Boolean, ByVal GuessCounter As Integer, ByVal Temperature As String)
        If GuessedCorrectly = False Then
            Console.WriteLine("Incorrect guess ...")
            Console.WriteLine("You are ...... " & Temperature)
            Console.WriteLine("You have " & GuessCounter & " guesses left.")
            Console.WriteLine("")
        End If
        If GuessedCorrectly = True Then
            Console.WriteLine("You have guessed the number.")
            Console.WriteLine("Press ENTER to end this game.")
        End If
    End Sub

    Sub Range(ByRef NumRange As Integer)
        Console.Write("Enter your limit for the number range > ")
        NumRange = Console.ReadLine()
    End Sub

    Sub Limit(ByRef GuessCounter As Integer)
        Console.Write("Enter your limit for the number of guesses > ")
        GuessCounter = Console.ReadLine()
    End Sub

    Sub TempHinting(ByRef Temperature As String, ByVal ThoughtNumber As Integer, ByVal GuessedNumber As Integer, ByRef Difference As Integer, ByVal NumRange As Integer, ByRef NumScaleFactor As Integer)

        NumScaleFactor = NumRange / 10
        Select Case Math.Abs(GuessedNumber - ThoughtNumber)
            Case Is <= 2 * NumScaleFactor
                Temperature = "HOT"
            Case Is <= 4 * NumScaleFactor
                Temperature = "WARM"                'SCALES TEMPERATURE HINTING BASED ON RANGE
            Case Is <= 6 * NumScaleFactor
                Temperature = "COLD"
            Case Is >= 7 * NumScaleFactor
                Temperature = "FREEZING"
        End Select

    End Sub

    Sub ReportResultsSoFar(ByVal GuessedCorrectly As Boolean, ByVal GuessCounter As Integer, ByVal ThoughtNumber As Integer, ByVal GuessedNumber As Integer)
        Console.WriteLine("")
        Console.WriteLine("You have had " & guesscounter & " guesses.")
        If guessedcorrectly = True Then
            Console.WriteLine("......... and you have now guessed the number !")
            Console.WriteLine("")
            Console.WriteLine("GAME OVER ......... press ENTER to finish . ")
            Console.ReadLine()
        Else
            Console.WriteLine("......... and you have still not guessed the number !")
            Console.WriteLine("")

        End If
    End Sub

End Module

'' mr peters code

'Sub main()
'    Dim thoughtnumber As Byte
'    Dim guessednumber As Byte
'    Dim guessedcorrectly As Boolean
'    Dim guesscounter As Byte
'    Dim temperatureword As String
'    Dim guesslimit As Byte
'    Dim roundlimit As Byte = 3


'    getguesslimit(guesslimit)

'    For looper = 1 To roundlimit
'        console.writeline("round " & looper)

'        getthoughtnumber(thoughtnumber)

'        Do
'            getguessednumber(guessednumber)
'            comparenumbers(thoughtnumber, guessednumber, guessedcorrectly)
'            guesscounter = guesscounter + 1

'            If thoughtnumber <> guessednumber Then
'                gettemperature(thoughtnumber,
'                                guessednumber,
'                                temperatureword)
'            End If
'            displayresultssofar(guesscounter,
'                                guessedcorrectly,
'                                temperatureword)
'        Loop Until guessedcorrectly = True Or guesscounter = guesslimit
'        If guessedcorrectly = True Then
'            console.writeline("well done,you win")
'        Else
'            console.writeline("hard luck, good thing we weren't playing for money")
'        End If
'        console.writeline("game over ...... press enter to finish")
'    Next

'    console.readline()
'End Sub


'Sub getthoughtnumber(ByRef thoughtnumber As Byte)
'    thoughtnumber = int(10 * rnd()) + 1
'    console.writeline("i am thinking of a number between 1 and 10.")
'End Sub


'Sub getguessednumber(ByRef guessednumber As Byte)
'    console.writeline("enter your guess")
'    guessednumber = console.readline
'End Sub
'Sub getguesslimit(ByRef guessedlimit As Byte)
'    console.writeline("enter the limit for guesses")
'    guessedlimit = console.readline
'End Sub


'Sub comparenumbers(ByVal thoughtnumber As Byte, _
'                   ByVal guessednumber As Byte, _
'                   ByRef guessedcorrectly As Boolean)
'    If thoughtnumber = guessednumber Then
'        guessedcorrectly = True
'    End If
'End Sub
'Sub displayresultssofar(ByVal guesscounter As Byte, _
'                        ByVal guessedcorrectly As Boolean,
'                        ByVal temperatureword As String)

'    If guessedcorrectly = False Then
'        console.writeline("you are " & temperatureword)
'    End If

'    console.writeline("you have had " & guesscounter & " guesses.")
'    If guessedcorrectly = True Then
'        console.writeline("..... and you have now guessed the number!")
'    Else
'        console.writeline("..... and you have still not guessed the number yet!")
'    End If
'End Sub
'Sub gettemperature(thoughtnumber As Integer,
'                   guessednumber As Integer,
'                   ByRef temperatureword As String)
'    Dim difference As Integer

'    difference = math.abs(thoughtnumber - guessednumber)
'    ' abs() is a function that turns a negative value positive
'    Select Case difference
'        Case Is = 1, 2
'            temperatureword = "hot"
'        Case Is = 3, 4
'            temperatureword = "warm"
'        Case Else
'            temperatureword = "cold"
'    End Select
'End Sub