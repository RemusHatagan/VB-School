Module O_Players_Exercise

    Structure Player
        Dim ID As Integer
        Dim Name As String
        Dim Weight As String
        Dim Age As Integer
    End Structure

    Dim MyPlayers() As Player

    Sub Main()
        ReDim MyPlayers(623)
        FillArrayFromCSVFile()
        MyPlayers = SortPlayersBySurname()
        For Looper = 0 To MyPlayers.Length - 1
            PrintPlayerDetails(MyPlayers(Looper))
        Next
        WriteToCSVFile()

        Console.ReadLine()
    End Sub

    Sub PrintPlayerDetails(ThePlayer As Player)
        Console.Write(ThePlayer.ID & " | " & ThePlayer.Name & " | " & ThePlayer.Weight & " | " & ThePlayer.Age & " | " & vbNewLine)
    End Sub

    Function SortPlayersBySurname() As Player()

        Dim Temp As Player
        Dim SwapsMade As Boolean
        Dim ArrayLength As Integer = MyPlayers.Length - 2
        Do
            SwapsMade = False
            For Comparisons = 0 To ArrayLength
                If MyPlayers(Comparisons).Name > MyPlayers(Comparisons + 1).Name Then
                    Temp = MyPlayers(Comparisons)
                    MyPlayers(Comparisons) = MyPlayers(Comparisons + 1)
                    MyPlayers(Comparisons + 1) = Temp
                    SwapsMade = True
                End If
            Next
            ArrayLength -= 1
        Loop Until SwapsMade = False

        Return MyPlayers
    End Function

    Sub FillArrayFromCSVFile()
        Dim WholeLine As String
        Dim PlayerCounter As Integer = 0
        ' open file


        Try
            FileOpen(1, "s:\Players2024.txt", OpenMode.Input)

            Do While Not EOF(1)
                WholeLine = LineInput(1)

                Dim SplitLine(3) As String
                SplitLine = Split(WholeLine, ",")

                MyPlayers(PlayerCounter).ID = SplitLine(0)
                MyPlayers(PlayerCounter).Name = SplitLine(1)
                MyPlayers(PlayerCounter).Weight = SplitLine(2)
                MyPlayers(PlayerCounter).Age = SplitLine(3)

                PlayerCounter += 1

            Loop
        Catch ex As IO.EndOfStreamException
            MsgBox(ex.Message)
        Catch ex As IO.FileNotFoundException
            MsgBox(ex.Message)
        Catch ex As IndexOutOfRangeException
            MsgBox(ex.Message)
        Finally         ' This happens even if an error has not occured
            FileClose(1)
        End Try

        ' close file
    End Sub

    Sub WriteToCSVFile()

        Dim CombinedDetails As String
        FileOpen(1, "s:\Top5Players.txt", OpenMode.Output)

        For Looper = 0 To 4
            CombinedDetails &= MyPlayers(Looper).ID & ","
            CombinedDetails &= MyPlayers(Looper).Name & ","
            CombinedDetails &= MyPlayers(Looper).Weight & ","
            CombinedDetails &= MyPlayers(Looper).Age

            If Looper < 4 Then
                PrintLine(1, CombinedDetails)
            Else
                Print(1, CombinedDetails)
            End If

            CombinedDetails = ""
        Next
        FileClose(1)
    End Sub

End Module
