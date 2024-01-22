Module M2_Linear_Search
    Sub Main()
        Dim TheValues() As Integer = {9, 6, 3, 2, 7, 5, 1}
        Dim inList As Boolean
        Dim position As Integer

        inList = LinearSearch(TheValues, 4)
        position = LinearSearch2(TheValues, 4)
        Console.WriteLine(position)

        Console.ReadLine()
    End Sub

    Function LinearSearch(TheArray() As Integer, Target As Integer) As Boolean

        ' Checking to see if an item is IN THE LIST/ARRAY
        Dim Looper As Integer = 0
        Do
            If TheArray(Looper) = Target Then
                Return True
            End If
            Looper += 1
        Loop Until Looper = TheArray.Length
        Return False
    End Function

    Function LinearSearch2(TheArray() As Integer, Target As Integer) As Integer

        ' Checking to see if an item is IN THE LIST/ARRAY and returning the positon
        Dim Looper As Integer = 0
        Do
            If TheArray(Looper) = Target Then
                Return Looper
            End If
            Looper += 1
        Loop Until Looper = TheArray.Length
        Return -1
    End Function

End Module
