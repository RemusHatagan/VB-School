Module L_File_Handling

    Sub Main()
        'ReadFileEasy()
        'ReadFileHarder()
        'ReadFileBest()

        Dim TheValues() As Integer = {9, 6, 3, 2, 7, 5, 1, -5}
        WriteFile(TheValues)

        Console.ReadLine()
    End Sub

    Sub ReadFileEasy()
        Dim TheName As String

        FileOpen(1, "s:\testfile.txt", OpenMode.Input)

        For Looper = 1 To 5
            TheName = LineInput(1)
            Console.WriteLine(TheName)
        Next

        FileClose(1)
    End Sub

    Sub ReadFileHarder()
        Dim NumberOfNames As Integer
        Dim TheName As String

        FileOpen(1, "s:testfilev2.txt", OpenMode.Input)

        NumberOfNames = LineInput(1)

        For Looper = 1 To NumberOfNames
            TheName = LineInput(1)
            Console.WriteLine(TheName)
        Next

        FileClose(1)
    End Sub

    Sub ReadFileBest()
        Dim TheName As String
        Dim NumberOfNames As Integer

        FileOpen(1, "Z:\ICT\AS Computing\aqawords.txt", OpenMode.Input)

        Do While Not EOF(1) ' End Of file
            NumberOfNames += 1
            TheName = LineInput(1)
            Console.WriteLine(TheName)
        Loop
        Console.WriteLine(NumberOfNames)
        FileClose(1)
    End Sub

    Sub WriteFile(TheArray() As Integer)
        ' Take care when picking a file name
        ' OpenMode OUTPUT will WIPE the contents of a file
        ' then wait for data to be written to it
        FileOpen(1, "s:\OutputFile.txt", OpenMode.Output)

        For Looper = 0 To TheArray.Length - 1
            If Looper < TheArray.Length - 1 Then
                PrintLine(1, TheArray(Looper)) ' Prints ONE element each line
            Else
                Print(1, TheArray(Looper)) ' Prints ALL elements on one line
            End If
        Next
        FileClose(1)
    End Sub
End Module
