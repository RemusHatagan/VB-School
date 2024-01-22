Module O_Structures
    ' A structure allows you to collect together different data items that help represent a THING of some type, e.g. a person, a car, a country etc...
    ' NOTE : A structure must be declared at the top of a program
    ' NOTE : This is because it is a USER DEFINED DATA TYPE that does not exist in VB, so we have to 'teach' VB what it is before we can use it
    ' Here is a structure that might represent a person :

    Structure Person
        Dim SName As String
        Dim DOB As Date
        Dim Drives As Boolean
        Dim AvgScore As Single
    End Structure

    Sub Main()
        Dim MyPeople() As Person
        'ReDim MyPeople(3)
        'FillArrayInfantStyle(MyPeople)

        'LoadPeopleFromCSVFile(MyPeople)
        FillArrayCSVFile(MyPeople)
        MyPeople = SortPeopleBySurname(MyPeople)
        For Looper = 0 To MyPeople.Length - 1
            PrintPersonDetails(MyPeople(Looper))
        Next


        'PrintPersonDetails(Person1)

        Console.ReadLine()
    End Sub

    Function SortPeopleBySurname(ByVal MyPeople() As Person) As Person()

        Dim Temp As Person
        Dim SwapsMade As Boolean
        Dim ArrayLength As Integer = MyPeople.Length - 2
        Do
            SwapsMade = False
            For Comparisons = 0 To ArrayLength
                If MyPeople(Comparisons).SName > MyPeople(Comparisons + 1).SName Then
                    Temp = MyPeople(Comparisons)
                    MyPeople(Comparisons) = MyPeople(Comparisons + 1)
                    MyPeople(Comparisons + 1) = Temp
                    SwapsMade = True
                End If
            Next
            ArrayLength -= 1
        Loop Until SwapsMade = False

        Return MyPeople
    End Function

    Sub FillArrayInfantStyle(MyPeople() As Person)


        Dim Person1 As Person
        Person1.SName = "Hatagan"
        Person1.DOB = #9/16/2006#
        Person1.Drives = False
        Person1.AvgScore = 93.6
        MyPeople(0) = Person1

        Dim Person2 As Person
        Person2.SName = "Bloggs"
        Person2.DOB = #1/2/2023# ' or "1/2/2023"
        Person2.Drives = True
        Person2.AvgScore = 45.7
        MyPeople(1) = Person2

        Dim Person3 As Person
        Person3.SName = "Smith"
        Person3.DOB = #7/14/1980#
        Person3.Drives = True
        Person3.AvgScore = 67.2
        MyPeople(2) = Person3

        Dim Person4 As Person
        Person4.SName = "Zenda"
        Person4.DOB = #1/14/1914#
        Person4.Drives = False
        Person4.AvgScore = 21.4
        MyPeople(3) = Person4
    End Sub

    Sub PrintPersonDetails(ThePerson As Person)
        Console.Write(ThePerson.SName & " | " & ThePerson.DOB & " | " & ThePerson.Drives & " | " & ThePerson.AvgScore & vbNewLine)
    End Sub

    Sub FillArrayCSVFile(ByRef MyPeople() As Person)
        Dim WholeLine As String
        Dim NumOfPeople As Integer = 0
        ' open file
        FileOpen(1, "S:\PeopleInfo.txt", OpenMode.Input)

        Do While Not EOF(1)
            NumOfPeople += 1
            ReDim Preserve MyPeople(NumOfPeople)
            WholeLine = LineInput(1)


            Dim SplitLine() As String
            ReDim SplitLine(3)
            SplitLine = Split(WholeLine, ",")

            MyPeople(NumOfPeople - 1).SName = SplitLine(0)
            MyPeople(NumOfPeople - 1).DOB = SplitLine(1)
            MyPeople(NumOfPeople - 1).Drives = SplitLine(2)
            MyPeople(NumOfPeople - 1).AvgScore = SplitLine(3)
        Loop
        ReDim Preserve MyPeople(MyPeople.Length - 2)

        FileClose(1)
        ' close file
    End Sub

    Sub LoadPeopleFromCSVFile(ByRef MyPeople() As Person)

        ReDim MyPeople(4)
        Dim WholeLine As String
        Dim TempArray() As String
        Dim PersonCounter As Integer
        ' open the file called S:\People2024.txt

        FileOpen(1, "S:\PeopleInfo.txt", OpenMode.Input)
        ' loop around until we hit the end of the file
        Do Until EOF(1)
            WholeLine = LineInput(1)
            ' message box WholeLine
            TempArray = Split(WholeLine, ",")

            ' MsgBox(WholeLine)

            MyPeople(PersonCounter).SName = TempArray(0)
            MyPeople(PersonCounter).DOB = TempArray(1)
            MyPeople(PersonCounter).Drives = TempArray(2)
            MyPeople(PersonCounter).AvgScore = TempArray(3)

            PersonCounter += 1
        Loop
        ' end of loop here

        ' close the file
        FileClose(1)
    End Sub
End Module
