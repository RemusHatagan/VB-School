Module H_String_Functions

    Sub Main()

        Dim LName As String
        Dim CAPLET As String = ""
        Dim Word As String
        Dim RevWord As String = ""
        Dim Choice As String = ""
        Dim FName As String

        Console.WriteLine("Welcome to the String Modifier !")
        Console.WriteLine("")
        DrawMenu(Choice)
        Select Case Choice
            Case Is = "1"
                Console.Write("Enter first Name > ")
                FName = Console.ReadLine()
                Console.Write("Enter last Name > ")
                LName = Console.ReadLine()
                Initials(FName, LName, CAPLET)
            Case Is = "2"
                Console.Write("Enter a word to be reversed > ")
                Word = Console.ReadLine()
                SwapEnds(Word, RevWord)
            Case Is = "3"
                Console.Write("Enter first Name > ")
                FName = Console.ReadLine()
                ContainsP(FName)
            Case Is = "4"
                Console.Write("Enter first Name > ")
                FName = Console.ReadLine()
                'SpellIt(FName)
                SpellItOutBetter(FName)
            Case Is = "5"
                Console.Write("Enter first Name > ")
                FName = Console.ReadLine()
                OnlyLetters(FName)
            Case Is = "6"
                Console.Write("Enter first Name > ")
                FName = Console.ReadLine()
                HideLetters(FName)
            Case Is = "7"
                ReverseIt()
            Case Is = "8"
                Console.Write("Enter first Name > ")
                FName = Console.ReadLine()
                CleanItUp(FName)


        End Select
        Console.ReadLine()
    End Sub

    Sub Initials(ByVal FName As String, ByVal LName As String, ByRef CAPLET As String)
        CAPLET = UCase(FName(0) & LName(0))
        Console.WriteLine("Initials are > " & CAPLET)
        Console.WriteLine("")
    End Sub

    Sub SwapEnds(ByVal Word As String, ByRef RevWord As String)
        RevWord = Right(Word, 1) & Mid(Word, 2, Len(Word) - 2) & Left(Word, 1)
        Console.WriteLine("The swapped ends word is " & RevWord)
        Console.WriteLine("")
    End Sub

    Sub ContainsP(ByVal FName As String)
        If InStr(UCase(FName), "P") > 0 Then
            Console.WriteLine("Your name contains a P")
            Console.WriteLine("")
        Else
            Console.WriteLine("Your name does not contain a P")
            Console.WriteLine("")
        End If
    End Sub

    Sub SpellIt(ByVal FName As String)
        For Looper = 1 To Len(FName)
            Console.Write(Mid(FName, Looper, 1) & " ")
        Next
        Console.WriteLine("")
    End Sub

    Sub SpellItOutBetter(ByVal FName As String)
        For Looper = 0 To (FName.Length - 1)
            Console.Write(FName(Looper) & " ")
        Next
    End Sub

    Sub OnlyLetters(ByVal FName As String)
        Dim LettersOnly As Boolean = True

        For Looper = 1 To Len(FName)
            If InStr("`1234567890-=\,./+_)(*&^%$£!;'#:~", Mid(FName, Looper, 1)) > 0 Then
                LettersOnly = False
            End If
        Next

        If LettersOnly = True Then
            Console.WriteLine("")
            Console.WriteLine("Your name is made up of only letters.")
            Console.WriteLine("")
        Else
            Console.WriteLine("Your name contains characters other than letters.")
            Console.WriteLine("")
        End If
    End Sub

    Sub HideLetters(ByVal FName As String)

        Console.Write("Your name hidden is > ")
        For Looper = 1 To Len(FName)
            Console.Write("*")
        Next
        Console.WriteLine("")
    End Sub

    Sub ReverseIt()
        Dim UserWord As String = ""
        Console.WriteLine("")
        Console.Write("Enter a word you wish to be reversed > ")
        UserWord = Console.ReadLine()
        Console.WriteLine("")
        Console.Write("Your word reversed is > ")
        For Looper = 0 To Len(UserWord) - 1
            Console.Write(Mid(UserWord, (Len(UserWord) - Looper), 1))
        Next
        Console.WriteLine("")
    End Sub

    Sub CleanItUp(ByVal FName As String)
        Console.WriteLine("")
        Dim NameChar As Char
        Dim ResultString As String = ""
        For Looper = 1 To Len(FName)
            NameChar = Mid(FName, Looper, 1)
            Select Case NameChar
                Case "A" To "Z", "a" To "z"
                    ResultString = ResultString & NameChar
            End Select
        Next
        Console.Write("Your name cleaned up is > " & ResultString)
    End Sub

    Sub DrawMenu(ByRef Choice As String)

        Console.WriteLine("1) Initials ")
        Console.WriteLine("2) SwapEnds ")
        Console.WriteLine("3) ContainsP ")
        Console.WriteLine("4) SpellItOut ")
        Console.WriteLine("5) OnlyLetters ")
        Console.WriteLine("6) HideLetters ")
        Console.WriteLine("7) ReverseIt ")
        Console.WriteLine("8) CleanItUp ")
        Console.WriteLine("")
        Console.Write("Please select your option > ")
        Choice = Console.ReadLine
    End Sub

End Module

'Sub Initials()

'    Dim MyFirstName As String
'    Dim MyLastName As String
'    Dim FirstInit As Char
'    Dim LastInit As Char
'    Dim FullInits As String

'    Console.WriteLine("Type in your first name")
'    MyFirstName = Console.ReadLine()
'    Console.WriteLine("Type in your last name")
'    MyLastName = Console.ReadLine()
'    FirstInit = Left(MyFirstName, 1)
'    LastInit = Left(MyLastName, 1)
'    FullInits = FirstInit & LastInit
'    Console.WriteLine("The initials are: " & FullInits)

'End Sub

'Sub SwapEnds()

'    Dim TheWord As String
'    Dim EndsSwappedWord As String
'    Dim LeftPart As String ' You may not need these 3 variables
'    Dim RightPart As String
'    Dim MiddlePart As String

'    Console.WriteLine("Enter the word")
'    TheWord = Console.ReadLine
'    LeftPart = Left(TheWord, 1)
'    RightPart = Right(TheWord, 1)
'    MiddlePart = Mid(TheWord, 2, Len(TheWord) - 2)
'    EndsSwappedWord = RightPart & MiddlePart & LeftPart

'     ALTERNATIVELY (not using so many variables)

'    EndsSwappedWord = Right(TheWord, 1) & Mid(TheWord, 2, Len(TheWord) - 2) & Left(TheWord, 1)
'    Console.WriteLine("The new word is " & EndsSwappedWord)

'End Sub

'Sub ContainsP()

'    Dim MyString As String
'    Dim PStartsAt As Integer
'    Console.WriteLine("Type in your text")
'    MyString = Console.ReadLine()
'    PStartsAt = InStr(MyString, "p")

'    If PStartsAt = 0 Then
'        Console.WriteLine("There are no 'p's in this text.")
'    Else
'        Console.WriteLine("The text contains at least one 'p'")
'    End If

'End Sub

'Sub SpellItOut()

'    Dim MyString As String
'    Dim Looper As Integer
'    Dim NextCharacter As Char

'    Console.WriteLine("Type in your text")
'    MyString = Console.ReadLine()

'    For Looper = 1 To Len(MyString)
'        NextCharacter = Mid(MyString, Looper, 1)
'        Console.WriteLine(NextCharacter)
'        Console.ReadLine()
'    Next

'End Sub

'Sub OnlyLetters()

'    Dim MyString As String
'    Dim Looper As Integer
'    Dim NextCharacter As Char
'    Dim LettersOnly As Boolean = True

'    Console.WriteLine("Type in your text")
'    MyString = Console.ReadLine()

'    For Looper = 1 To Len(MyString)
'        NextCharacter = Mid(MyString, Looper, 1)
'        If InStr("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz", NextCharacter) = 0 Then
'            LettersOnly = False
'        End If
'    Next
'    If LettersOnly = True Then
'        Console.WriteLine("Only contains alphabetic characters")
'    Else
'        Console.WriteLine("Contains some non-alphabetic characters")
'    End If

'End Sub

'Sub HideLetters()

'    Dim MyString As String
'    Dim Looper As Integer
'    Dim FinalString As String

'    Console.WriteLine("Type in your text")
'    MyString = Console.ReadLine()

'    For Looper = 1 To Len(MyString)
'        FinalString = FinalString & "*"
'    Next

'    Console.WriteLine("The hidden text is: " & FinalString)

'End Sub

'Sub ReverseIt()

'    Dim MyString As String
'    Dim Looper As Integer
'    Dim NextCharacter As Char
'    Dim FinalString As String

'    Console.WriteLine("Type in your text")
'    MyString = Console.ReadLine()

'    For Looper = 1 To Len(MyString)
'        ' counting FORWARDS from the LEFT-hand side of the string
'        NextCharacter = Mid(MyString, Looper, 1)
'        ' select next character
'        FinalString = NextCharacter & FinalString
'        ' glue the next character onto the LEFT-hand side of the new string
'    Next

'    Console.WriteLine("The reversed text is: " & FinalString)

'End Sub

'Sub ReverseItALTERNATIVE()

'    Dim MyString As String
'    Dim Looper As Integer
'    Dim NextCharacter As Char
'    Dim FinalString As String

'    Console.WriteLine("Type in your text")
'    MyString = Console.ReadLine()

'    For Looper = Len(MyString) To 1 Step -1
'        ' counting BACKWARDS from the RIGHT-hand side of the string
'        NextCharacter = Mid(MyString, Looper, 1)
'        ' select next character
'        FinalString = FinalString & NextCharacter
'        ' glue the next character onto the RIGHT-hand side of the new string
'    Next

'    Console.WriteLine("The reversed text is: " & FinalString)

'End Sub

'Sub CleanItUp()

'    Dim MyString As String
'    Dim Looper As Integer
'    Dim NextCharacter As Char
'    Dim FinalString As String

'    Console.WriteLine("Type in your text")
'    MyString = Console.ReadLine()

'    For Looper = 1 To Len(MyString)
'        NextCharacter = Mid(MyString, Looper, 1)
'        If InStr("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz", NextCharacter) <> 0 Then
'            FinalString = FinalString & NextCharacter
'        End If
'    Next

'    Console.WriteLine("The cleaned up text is: " & FinalString)

'End Sub

'Sub CleanItUpBETTER()

'    Dim MyString As String
'    Dim Looper As Integer
'    Dim NextCharacter As Char
'    Dim FinalString As String

'    Console.WriteLine("Type in your text")
'    MyString = Console.ReadLine()

'    For Looper = 1 To Len(MyString)
'        NextCharacter = Mid(MyString, Looper, 1)
'        Select Case NextCharacter
'            Case "A" To "Z", "a" To "z"
'                FinalString = FinalString & NextCharacter
'        End Select
'    Next

'    Console.WriteLine("The cleaned up text is: " & FinalString)

'End Sub