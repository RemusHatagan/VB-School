Imports System.Math
Module I_User_Defined_Functions
    ' A function always 'RETURNS' a result
    ' Where as a PROCEDURE performs a TASK
    Sub Main()
        Dim MyInteger As Integer
        Dim MyRealNumber As Single

        MyInteger = GetInt()
        MyRealNumber = GetReal()

        Console.WriteLine("The integer is > " & MyInteger)
        Console.WriteLine("The real number is > " & MyRealNumber)

        Console.WriteLine("The integer SQUARED is > " & SquareIt(MyInteger))
        Console.WriteLine("The integer CUBED is > " & CubeIt(MyInteger))
        Console.WriteLine("The decimal HALVED is > " & HalveIt(MyRealNumber))
        Console.WriteLine("The decimal NEGATED is > " & NegateIt(MyRealNumber))
        Console.WriteLine("The decimal AS A POSITIVE NUMBER is > " & PositiveIt(MyRealNumber))
        Console.WriteLine("The decimal WITH SIGN SWITCHED is > " & SwitchSigns(MyRealNumber))
        Console.WriteLine("The decimal's SQUARE ROOT is > " & SquareRootIt(MyRealNumber))
        Console.WriteLine("Is the decimal ZERO? > " & IsZero(MyRealNumber))
        Console.WriteLine("Is the decimal NEGATIVE? > " & IsNegative(MyRealNumber))
        Console.WriteLine("Is the decimal POSITIVE? > " & IsPositive(MyRealNumber))
        Console.ReadLine()
    End Sub

    Function GetInt() As Integer '< This is the RETURNED data type
        Dim Temp As Integer ' Same type as the returned data
        Console.Write("Enter a whole number > ")
        Temp = Console.ReadLine
        Return Temp
    End Function

    Function GetReal() As Single
        Dim Temp As Single ' Same type as the returned data
        Console.Write("Enter a decimal number > ")
        Temp = Console.ReadLine
        Return Temp
    End Function

    Function SquareIt(ByVal MyInteger As Integer) As Integer
        Return MyInteger ^ 2            ' SHORTENED WAY
    End Function

    Function CubeIt(ByVal MyInteger As Integer) As Integer
        CubeIt = MyInteger ^ 3           ' SHORTENED WAY
    End Function

    Function HalveIt(ByVal MyRealNumber As Single) As Single
        Dim Temp As Single
        Temp = MyRealNumber / 2
        Return Temp
    End Function

    Function NegateIt(ByVal MyRealNumber As Single) As Single
        If MyRealNumber > 0 Then
            Return MyRealNumber * -1
        Else
            Return MyRealNumber
        End If
    End Function

    Function PositiveIt(ByVal MyRealNumber As Single)
        Return Abs(MyRealNumber)
    End Function

    Function SwitchSigns(ByVal MyRealNumber As Single) As Single
        Return MyRealNumber * -1
    End Function

    Function SquareRootIt(ByVal MyRealNumber As Single) As Single
        Return Sqrt(MyRealNumber)
    End Function

    Function IsZero(ByVal MyRealNumber As Single) As Boolean
        If MyRealNumber = 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Function IsNegative(ByVal MyRealNumber As Single) As Boolean
        If MyRealNumber < 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Function IsPositive(ByVal MyRealNumber As Single) As Boolean
        If MyRealNumber > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Module
