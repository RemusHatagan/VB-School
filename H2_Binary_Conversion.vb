Module H2_Binary_Conversion
    Sub Main()
        Dim BinaryNumber As String = ""
        Dim DenaryNumber As String = ""
        Dim MenuChoice As Integer
        Dim ASCIIChar As Char
        Dim Key As Integer
        Dim NormalString As String = ""
        Dim EncryptedString As String = ""
        Dim EncChar As Integer

        Do
            Console.WriteLine("1) Binary To Denary")
            Console.WriteLine("2) Denary To Binary")
            Console.WriteLine("3) Binary to ASCII Character")
            Console.WriteLine("4) Denary To ASCII Character")
            Console.WriteLine("5) ASCII Character to Binary")                   'MENU CHOICES
            Console.WriteLine("6) ASCII Character to Denary")
            Console.WriteLine("7) Encrypt Caesar Cypher")
            Console.WriteLine("8) Decrypt Caesar Cypher")
            Console.WriteLine("11) EXIT")
            Console.WriteLine("")
            Console.Write("Enter your choice > ")
            MenuChoice = Console.ReadLine
            Console.Clear()

            Select Case MenuChoice
                Case 1
                    Console.WriteLine("1) Binary to denary")
                    Console.WriteLine("")
                    Do
                        BinaryInput(BinaryNumber)
                        If Len(BinaryNumber) <> 8 Then
                            Console.WriteLine("The binary number must be 8 bits long!")
                        End If
                    Loop Until Len(BinaryNumber) = 8
                    BinaryToDenary(BinaryNumber, DenaryNumber)
                    OutputBoth(BinaryNumber, DenaryNumber)

                Case 2
                    Console.WriteLine("2) Denary To Binary")
                    Console.WriteLine("")
                    Do
                        DenaryInput(DenaryNumber)
                        If DenaryNumber < 0 Or DenaryNumber > 255 Then
                            Console.WriteLine("The denary number must be between 0 & 255")
                        End If
                    Loop Until DenaryNumber >= 0 And DenaryNumber <= 255
                    DenaryToBinary(BinaryNumber, DenaryNumber)
                    OutputBoth(BinaryNumber, DenaryNumber)

                Case 3
                    Console.WriteLine("3) Binary to ASCII Character")
                    Console.WriteLine("")
                    Do
                        BinaryInput(BinaryNumber)
                        If Len(BinaryNumber) <> 8 Then
                            Console.WriteLine("The binary number must be 8 bits long!")
                        End If
                    Loop Until Len(BinaryNumber) = 8
                    BinaryToDenary(BinaryNumber, DenaryNumber)
                    ASCIIChar = Chr(DenaryNumber)
                    Console.WriteLine(BinaryNumber & " in binary is " & ASCIIChar & " in ASCII")

                Case 4
                    Console.WriteLine("4) Denary To ASCII Character")
                    Console.WriteLine("")
                    Do
                        DenaryInput(DenaryNumber)
                        If DenaryNumber < 0 Or DenaryNumber > 255 Then
                            Console.WriteLine("The denary number must be between 0 & 255")
                        End If
                    Loop Until DenaryNumber >= 0 And DenaryNumber <= 255
                    ASCIIChar = Chr(DenaryNumber)
                    Console.WriteLine(DenaryNumber & " in denary is " & ASCIIChar & " in ASCII")

                Case 5
                    Console.WriteLine("5) ASCII Character to Binary")
                    Console.WriteLine("")
                    Console.Write("Enter your ASCII Character > ")
                    ASCIIChar = Console.ReadLine
                    DenaryNumber = Asc(ASCIIChar)
                    DenaryToBinary(BinaryNumber, DenaryNumber)
                    Console.WriteLine(ASCIIChar & " in ASCII is " & BinaryNumber & " in binary")

                Case 6
                    Console.WriteLine("6) ASCII Character to Denary")
                    Console.WriteLine("")
                    Console.Write("Enter your ASCII Character > ")
                    ASCIIChar = Console.ReadLine
                    DenaryNumber = Asc(ASCIIChar)
                    Console.WriteLine(ASCIIChar & " in ASCII is " & DenaryNumber & " in denary")

                Case 7
                    Console.WriteLine("7) Encrypt Caesar Cypher")
                    Console.WriteLine("")
                    Console.Write("Enter the key you wish to shift by > ")
                    Key = Console.ReadLine
                    Console.Write("Enter the sentence you wish to encrypt > ")
                    NormalString = Console.ReadLine
                    Console.WriteLine("")
                    CaesarEncryption(Key, EncryptedString, NormalString, EncChar)

                Case 8
                    Console.WriteLine("8) Decrypt Caesar Cypher")
                    Console.WriteLine("")
                    Console.Write("Enter the key to decrypt > ")
                    Key = Console.ReadLine
                    Console.Write("Enter the sentence you wish to decrypt > ")
                    EncryptedString = Console.ReadLine
                    CaesarDecryption(Key, EncryptedString, NormalString, EncChar)

                Case 11
                    Console.WriteLine("11) EXIT")
                    Console.WriteLine("")
                    Console.Write("Press ENTER to exit > ")
            End Select
            Console.WriteLine("")
        Loop Until MenuChoice = 11

        Console.ReadLine()
    End Sub

    Sub BinaryInput(ByRef BinaryNumber As String)
        Console.Write("Enter your 8 digit binary number > ")
        BinaryNumber = Console.ReadLine
    End Sub

    Sub DenaryInput(ByRef DenaryNumber As String)
        Console.Write("Enter your Denary number between 0 & 255 > ")
        DenaryNumber = Console.ReadLine
    End Sub

    Sub BinaryToDenary(ByVal BinaryNumber As String, ByRef DenaryNumber As Integer)
        Dim BinaryChar As Char
        Dim PlaceValue As Integer
        Dim PlaceCounter As Integer = 7
        For looper = 1 To 8
            BinaryChar = Mid(BinaryNumber, looper, 1)
            PlaceValue = 2 ^ PlaceCounter
            If BinaryChar = "1" Then
                DenaryNumber = DenaryNumber + PlaceValue
            End If
            PlaceCounter -= 1
        Next
    End Sub

    Sub OutputBoth(ByVal BinaryNumber As String, ByVal DenaryNumber As Integer)
        Console.WriteLine("The Binary No is > " & BinaryNumber)
        Console.WriteLine("The Denary No is > " & DenaryNumber)
    End Sub

    Sub DenaryToBinary(ByRef BinaryNumber As String, ByVal DenaryNumber As Integer)

        BinaryNumber = ""

        For looper = 7 To 0 Step -1
            If DenaryNumber >= (2 ^ looper) Then
                BinaryNumber = BinaryNumber & "1"
                DenaryNumber = DenaryNumber - (2 ^ looper)
            Else
                BinaryNumber = BinaryNumber & "0"
            End If
        Next
    End Sub

    Sub CaesarEncryption(ByVal Key As Integer, ByRef EncryptedString As String, ByVal NormalString As String, ByRef EncChar As Integer)

        EncryptedString = ""

        For Looper = 1 To Len(NormalString)

            EncChar = Asc(Mid(NormalString, Looper, 1)) + Key
            EncryptedString = EncryptedString & Chr(EncChar)
        Next

        Console.WriteLine("Your encrypted sentence is > " & EncryptedString & " . The key is " & Key & ".")
    End Sub

    Sub CaesarDecryption(ByVal Key As Integer, ByRef EncryptedString As String, ByVal NormalString As String, ByRef EncChar As Integer)

        NormalString = ""
        For Looper = 1 To Len(EncryptedString)
            EncChar = Asc(Mid(EncryptedString, Looper, 1)) - Key
            NormalString = NormalString & Chr(EncChar)
        Next

        Console.WriteLine("Your decrypted sentence is > " & NormalString & " . The key is " & Key & ".")
    End Sub
End Module
