Module H1_BinaryConversion
    Sub Main()

        Dim BinNum As String = ""
        Dim DenNum As Integer
        Dim Choice As Integer
        Dim BinChar As Char
        Dim FalseEntry As Boolean = False

        Console.WriteLine("Press 1 to convert from Binary to Denary.")
        Console.WriteLine("Press 2 to convert from Denary to Binary.")
        Console.Write("Enter choice > ")
        Choice = Console.ReadLine()

        If Choice = 1 Then
            Do
                FalseEntry = False
                GetBinNum(BinNum)
                If Len(BinNum) <> 8 Then
                    Console.WriteLine("Not long enough!")
                    FalseEntry = True
                End If                                                                          ' VALIDATION OF INPUT
                For looper = 1 To 8
                    BinChar = Mid(BinNum, looper, 1)
                    If InStr("01", BinChar) = 0 Then
                        Console.WriteLine("Incorrect Character ! Only 1s and 0s")
                        FalseEntry = True
                    End If
                Next

            Loop Until FalseEntry = False
            BinaryToDenary(BinNum, DenNum)
        End If

        If Choice = 2 Then
            Do Until DenNum > 0 And DenNum < 255
                GetDenNum(DenNum)
                DenaryToBinary(DenNum, BinNum)
            Loop
        End If
        Console.ReadLine()
    End Sub

    Sub GetDenNum(ByRef DenNum As Integer)
        Console.Write("Enter a denary number from 0 to 255 > ")
        DenNum = Console.ReadLine()
        Console.WriteLine("")
    End Sub

    Sub DenaryToBinary(ByVal DenNum As Integer, ByRef BinNum As String)
        Dim BinaryNum As Integer = 128
        BinNum = ""

        Do Until BinaryNum = 0
            If DenNum - BinaryNum < 0 Then
                BinNum = BinNum + "0"
            End If
            If DenNum - BinaryNum >= 0 Then
                BinNum = BinNum + "1"
                DenNum = DenNum - BinaryNum
            End If
            BinaryNum = BinaryNum / 2
        Loop
        Console.WriteLine(BinNum)

    End Sub

    Sub GetBinNum(ByRef BinNum As String)
        Console.Write("Enter an 8 bit binary number > ")
        BinNum = Console.ReadLine
        Console.WriteLine("")
    End Sub

    Sub BinaryToDenary(ByVal BinNum As String, ByRef DenNum As Integer)
        Dim BinaryNum As Integer = 128

        For Looper = 1 To 8
            If Mid(BinNum, Looper, 1) = 1 Then
                DenNum += BinaryNum
            End If
            BinaryNum /= 2
        Next
        Console.WriteLine(BinNum & " in denary is > " & DenNum)
    End Sub
End Module


