Module B3_Assignment_Wages_Program

    ' Global variables exist in all subroutines - Declared at "top" of code - Use memory throughout program - Opens variables to accidentally change
    ' Local variables exist in the sub it is declared in - Declared "locally" to a sub - Memory re-claimed at END SUB
    ' Parameters are variables that can be passed into, (and sometims outside of) a sub-procedure

    Sub Main()

        Console.ForegroundColor = ConsoleColor.Green

        Dim WorkerName As String = ""
        Dim NormalHoursWorked As Integer
        Dim OvertimeHoursWorked As Integer ' Whole number
        Dim NormalPayRate As Single
        Dim OvertimePayRate As Single
        Dim GrossWages As Single ' A real number
        Dim NetWages As Single
        Dim TaxToPay As Single
        Const TaxRate = 30 ' Variable that does not vary

        Inputs(WorkerName, NormalHoursWorked, OvertimeHoursWorked, NormalPayRate)
        Calculations(NormalPayRate, NormalHoursWorked, OvertimeHoursWorked, TaxToPay, GrossWages, NetWages, OvertimePayRate, TaxRate) ' 
        Display(WorkerName, GrossWages, TaxToPay, NetWages)

    End Sub

    Sub Inputs(ByRef WorkerName As String, ByRef NormalHoursWorked As Integer, ByRef OvertimeHoursWorked As Integer, ByRef NormalPayRate As Single)

        Console.WriteLine("Enter your name > ")
        WorkerName = Console.ReadLine
        Console.WriteLine("Enter your normal hours worked this week > ")
        NormalHoursWorked = Console.ReadLine
        Console.WriteLine("Enter your overtime hours worked this week > ")
        OvertimeHoursWorked = Console.ReadLine
        Console.WriteLine("Enter your normal hourly rate of pay > ")
        NormalPayRate = Console.ReadLine

    End Sub

    Sub Calculations(ByRef NormalPayRate As Single, ByRef NormalHoursWorked As Integer, ByRef OvertimeHoursWorked As Integer, ByRef TaxToPay As Integer, ByRef GrossWages As Single, ByRef NetWages As Single, ByRef OvertimePayRate As Single, ByRef TaxRate As Integer)

        OvertimePayRate = NormalPayRate * 1.5
        GrossWages = (NormalHoursWorked * NormalPayRate) + (OvertimeHoursWorked * OvertimePayRate)
        TaxToPay = (GrossWages / 100) * TaxRate
        NetWages = GrossWages - TaxToPay


    End Sub

    Sub Display(ByVal WorkerName As String, ByVal GrossWages As Single, ByVal TaxToPay As Single, ByVal NetWages As Single)

        Console.WriteLine("")
        Console.WriteLine(WorkerName)
        Console.WriteLine("----------------------------------")
        Console.WriteLine("Pay before tax = " & GrossWages)
        Console.WriteLine("Tax due = " & TaxToPay)
        Console.WriteLine("Take home pay = " & NetWages)
        Console.ReadLine()

    End Sub

End Module

'WAGES PROGRAM

'' GLOBAL VARIABLES are declared here
'' They exist throughout the running of the WHOLE PROGRAM and can be ACCESSED FROM ANY SUB-PROCEDURE
'' They can be EXPENSIVE IN TERMS OF MEMORY USED as they may not need to exist all of the time.
'Const TaxRate = 30
'' A CONSTANT is a variable that can be 'set' once.
'' It helps make the code more READABLE and
'' it makes a program easier to maintain, in that you only need to alter one line
'' and the change (e.g. to TaxRate) carries through the whole program.
'Sub Main()
'    ' LOCAL VARIABLES are declared here
'    ' They ONLY EXIST DURING THE PROCEDURE THAT THEY ARE DECLARED IN and CAN'T BE ACCESSED FROM ELSEWHERE
'    ' They can SAVE ON MEMORY USAGE as THE SPACE THEY USE IS FREED UP at the end of the procedure.
'    Dim WorkerName As String
'    Dim NormalHoursWorked, OvertimeHoursWorked As Byte
'    Dim NormalPayRate, OvertimePayRate, GrossWages, NetWages, TaxToPay As Single
'    GetInputs(WorkerName,
'              NormalHoursWorked,
'              OvertimeHoursWorked,
'              NormalPayRate)
'    CalculateWages(NormalPayRate,
'                   OvertimePayRate,
'                   NormalHoursWorked,
'                   OvertimeHoursWorked,
'                   NetWages,
'                   GrossWages,
'                   TaxToPay)
'    DisplayTaxAndWage(WorkerName,
'                      NormalPayRate,
'                      GrossWages,
'                      NetWages,
'                      TaxToPay)
'    Console.ReadLine()
'End Sub
'Sub GetInputs(ByRef WorkerName As String,
'              ByRef NormalHoursWorked As Byte,
'              ByRef OvertimeHoursWorked As Byte,
'              ByRef NormalPayRate As Single)
'    Console.WriteLine("Please enter worker's name")
'    WorkerName = Console.ReadLine
'    Console.WriteLine("Please enter normal hours worked")
'    NormalHoursWorked = Console.ReadLine
'    Console.WriteLine("Please enter overtime hours worked")
'    OvertimeHoursWorked = Console.ReadLine
'    Console.WriteLine("Please enter normal rate of pay")
'    NormalPayRate = Console.ReadLine
'End Sub
'Sub CalculateWages(ByVal NormalPayRate As Single,
'                    ByRef OvertimePayrate As Single,
'                    ByVal NormalHoursWorked As Byte,
'                    ByVal OvertimeHoursWorked As Byte,
'                    ByRef NetWages As Single,
'                    ByRef GrossWages As Single,
'                    ByRef TaxToPay As Single)
'    OvertimePayrate = NormalPayRate * 1.5
'    GrossWages = (NormalHoursWorked * NormalPayRate) + (OvertimeHoursWorked * OvertimePayrate)
'    TaxToPay = GrossWages / 100 * TaxRate
'    NetWages = GrossWages - TaxToPay
'End Sub
'Sub DisplayTaxAndWage(ByVal WorkerName As String,
'                      ByVal NormalPayRate As Single,
'                      ByVal GrossWages As Single,
'                      ByVal NetWages As Single,
'                      ByVal TaxToPay As Single)
'    Console.WriteLine("********************************")
'    Console.WriteLine(WorkerName)
'    Console.WriteLine("Pay before tax:- " & GrossWages)
'    Console.WriteLine("Tax due:- " & TaxToPay)
'    Console.WriteLine("Take home pay:- " & NetWages)
'    Console.WriteLine("********************************")
'End Sub