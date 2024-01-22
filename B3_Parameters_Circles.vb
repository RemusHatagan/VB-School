Module B3_Parameters_Circles
    'A PARAMETER is a VARIABLE that can be PASSED into and sometimes out of a procedure of FUNCTION

    Dim Radius As Single

    Sub Main()

        Dim Diameter As Single
        Dim Circumference As Single
        Dim Area As Single
        Const Pi = 3.14
        Console.ForegroundColor = ConsoleColor.Magenta
        GetRadius()
        CalculateStats(Diameter, Circumference, Area, Pi)
        Console.WriteLine("")
        DisplayResults(Diameter, Circumference, Area)
        Console.ReadLine()

    End Sub

    Sub GetRadius()

        Console.Write("What is the radius? > ")
        Radius = Console.ReadLine

    End Sub

    Sub CalculateStats(ByRef Diameter As Single, ByRef Circumference As Single, ByRef Area As Single, ByRef Pi As Single)
        ' PASSING BY REFERENCE allows access to the memory location that the variable is stored in
        ' If you change the value of Radius here, it is CHANGED AT SOURCE

        Diameter = Radius * 2
        Circumference = Pi * 2 * Radius
        Area = Pi * Radius ^ 2 ' ^ means 'to the POWER OF  || * is MULTIPLICATION

    End Sub

    Sub DisplayResults(ByVal Diameter As Single, ByVal Circumference As Single, ByVal Area As Single)
        ' PASSING PARAMETERS BY VALUE allows access to A COPY OF THE VARIABLE'S SOURCE DATA
        ' If you change the value of Radius here, IT IS ALTERED HERE BUT NOT CHANGED AT SOURCE

        Console.WriteLine("For a circle with the radius > " & Radius)
        Console.WriteLine("|=~=|=~=|=~=|=~=|=~=|=~=|=~=|=~=|=~=|")
        Console.WriteLine("The diameter is > " & Diameter)
        Console.WriteLine("The area is > " & Area)
        Console.WriteLine("The circumference is > " & Circumference)
        Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-")

    End Sub

End Module

'CIRCLES PROGRAM

'' A PARAMETER is a VARIABLE that can be PASSED into
'' and sometimes out of a procedure OR FUNCTION
'Const Pi = 3.14
'Sub Main()
'    Dim Radius As Single
'    Dim Diameter As Single
'    Dim Circumference As Single
'    Dim Area As Single
'    GetTheRadius(Radius)
'    CalculateStats(Radius, Diameter, Circumference, Area)
'    DisplayResults(Radius, Diameter, Circumference, Area)
'    Console.ReadLine()
'End Sub
'Sub GetTheRadius(ByRef Radius As Single)
'    ' PASSING PARAMETERS BY REFERENCE allows access to the memory location that the variable is stored in
'    ' So, if you change the value of Radius here, it is CHANGED AT SOURCE
'    Console.WriteLine("What is the radius?")
'    Radius = Console.ReadLine()
'End Sub
'Sub CalculateStats(ByVal Radius As Single,
'                   ByRef Diameter As Single,
'                   ByRef Circumference As Single,
'                   ByRef Area As Single)
'    ' PASSING PARAMETERS BY VALUE allows access to A COPY OF THE VARIABLE'S SOURCE DATA
'    ' So, if you change the value of Radius here, IT IS ALTERED HERE BUT NOT CHANGED AT SOURCE
'    Area = Pi * Radius ^ 2 ' ^ means 'to the POWER of ...' ..... * means 'TIMES'
'    Diameter = Radius * 2
'    Circumference = Diameter * Pi
'End Sub
'Sub DisplayResults(ByVal Radius As Single,
'                   ByVal Diameter As Single,
'                   ByVal Circumference As Single,
'                   ByVal Area As Single)
'    Console.WriteLine("For a circle with the radius: " & Radius)
'    Console.WriteLine("====================================")
'    Console.WriteLine("The diameter is: " & Diameter)
'    Console.WriteLine("The area is: " & Area)
'    Console.WriteLine("The circumference is: " & Circumference)
'End Sub