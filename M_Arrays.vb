Module M_Arrays
    ''Dim MyNames(4) As String '= {"Fred", "Bill", "Anne", "Jane", "Mary"}
    ' The BRACKETS indicate that this is an ARRAY
    Dim MyName As String
    Sub Main()
        Dim MyNames() As String
        'ReDim MyNames(4) 'Re-dimensions with the correct size
        'FillArrayInfantStyle(MyNames)
        'FillArrayPrimaryStyle(MyNames)
        'FillArrayFromFile(MyNames)
        'MyNames = FillArrayBabyStyle()
        'MyNames = FillArrayCurlyStyle()
        FillFromFileNumbers(MyNames)
        'MyNames = RemoveItemByName("Remus", MyNames)
        SortByName(MyNames)
        ShowArrayContent(MyNames)
        'RemoveItem2(2, MyNames)
        'FindItemByName("Remus", MyNames)
        'EraseFromArray(2, MyNames)
        'ShowArrayContent(MyNames)
        'AddToArray(MyNames)
        'EditItemAt(2, MyNames)
        'ShowArrayContentsBackwards(MyNames)
        Console.ReadLine()
    End Sub

    Sub FillArrayInfantStyle(ByVal MyNames() As String)
        MyNames(0) = "Fred"
        MyNames(1) = "Bill"
        MyNames(2) = "Anne"
        MyNames(3) = "Jane"
        MyNames(4) = "Mary"
    End Sub

    Sub FillArrayPrimaryStyle(ByVal MyNames() As String)
        For Looper = 0 To (MyNames.Length - 1)
            Console.Write("Enter next name > ")
            MyNames(Looper) = Console.ReadLine
        Next
    End Sub

    Sub FillArrayFromFile(ByVal MyNames() As String)

        FileOpen(1, "s:\testfile.txt", OpenMode.Input)
        For Looper = 0 To (MyNames.Length - 1)
            MyNames(Looper) = LineInput(1)
        Next
        FileClose(1)
    End Sub

    Sub ShowArrayContent(ByVal MyNames() As String)
        For Looper = 0 To (MyNames.Length - 1)
            Console.WriteLine(MyNames(Looper))
        Next
    End Sub

    Sub ShowArrayContentsBackwards(ByVal MyNames() As String)
        For Looper = MyNames.Length - 1 To 0 Step -1
            Console.WriteLine(MyNames(Looper))
        Next
    End Sub

    Sub FillFromFileNumbers(ByRef MyNames() As String)
        Dim CurrentWord As String
        Dim NumOfWords As Integer = 0

        FileOpen(1, "s:\testfile.txt", OpenMode.Input)

        Do While Not EOF(1)
            CurrentWord = LineInput(1)
            NumOfWords += 1
            ReDim Preserve MyNames(NumOfWords)
            MyNames((NumOfWords - 1)) = CurrentWord
        Loop
        ReDim Preserve MyNames(NumOfWords - 1)

        FileClose(1)
    End Sub

    Function AddToArray(ByRef MyNames() As String)
        Dim AddItem As String
        Console.Write("Enter new item > ")
        AddItem = Console.ReadLine
        ReDim Preserve MyNames(MyNames.Length)
        MyNames(MyNames.Length - 1) = AddItem
        Return MyNames
    End Function

    Function EraseFromArray(ByVal RemovedItem As Integer, ByRef MyNames() As String)
        For Looper = RemovedItem + 1 To MyNames.Length - 1
            MyNames(Looper - 1) = MyNames(Looper)
        Next
        ReDim Preserve MyNames(MyNames.Length - 2)
        Console.WriteLine("")
        Return MyNames
    End Function

    Function FillArrayBabyStyle() As String()
        'This function returns an ARRAY of strings
        ' .... hence as String() at the end of the INTERFACE (first line)
        ' If you are returning an arra but not passing one in,
        ' Then you HAVE TO make an array in THIS function
        Dim TempArray(4) As String
        TempArray(0) = "Fred"
        TempArray(1) = "Bil"
        TempArray(2) = "Anne"
        TempArray(3) = "Jane"
        TempArray(4) = "Mary"
        Return TempArray
    End Function

    Function FillArrayCurlyStyle() As String()
        Dim TempArray() As String = {"Fred", "Bill", "Anne", "Jane", "Mary"}
        Return TempArray
    End Function

    Sub EditItemAt(ByVal Position As Integer, ByRef MyNames() As String)
        Dim Permission As Char
        Dim Edited As String
        Console.Write("The current contents of index " & Position & " shows " & MyNames(Position) & ". Do you wish to edit this? (Y/N) > ")
        Permission = UCase(Console.ReadLine)
        If Permission = "Y" Then
            Console.Write("Enter edited contents > ")
            Edited = Console.ReadLine
            MyNames(Position) = Edited
            Console.WriteLine("Index " & Position & " updated to " & Edited & ". The array is ... ")
            ShowArrayContent(MyNames)
        ElseIf Permission = "N" Then
            Console.WriteLine("No item was changed. The array is ... ")
            ShowArrayContent(MyNames)
        End If
    End Sub

    Function RemoveItem2(ByVal Position As Integer, ByRef MyNames() As String) As String()
        Dim TempArray(MyNames.Length - 2)
        Dim Count As Integer

        For Looper = 0 To MyNames.Length - 1
            If Looper = Position Then
                Count = Looper - 1
            End If
            TempArray(Count) = MyNames(Looper)
            Count += 1
        Next

        For Looper = 0 To TempArray.Length - 1
            Console.WriteLine(TempArray(Looper))
        Next
    End Function

    Function FindItemByName(ByVal Name As String, ByVal MyNames() As String) As Integer
        Dim Value As Integer

        For Looper = 0 To MyNames.Length - 1
            If MyNames(Looper) = Name Then
                Value = Looper
            End If
        Next

        Console.WriteLine(Name & " is at postion " & Value + 1 & " (index 0) of the array.")
        Console.WriteLine("")
        Return Value
    End Function

    Function RemoveItemByName(ByVal Name As String, ByRef MyNames() As String) As String()
        Dim TempValue As Integer
        TempValue = FindItemByName(Name, MyNames)
        EraseFromArray(TempValue, MyNames)
        Return MyNames
    End Function

    Function SortByName(ByRef MyNames() As String) As String()
        Dim Temp As String
        For Repeats = 0 To (MyNames.Length - 2)
            For Comparisons = 0 To (MyNames.Length - 2)
                If MyNames(Comparisons) > MyNames(Comparisons + 1) Then
                    Temp = MyNames(Comparisons)
                    MyNames(Comparisons) = MyNames(Comparisons + 1)
                    MyNames(Comparisons + 1) = Temp
                End If
            Next
        Next
        Return MyNames
    End Function

End Module



