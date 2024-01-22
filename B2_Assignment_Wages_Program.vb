Module B2_Assignment_Wages_Program

    Sub Main()

        Dim WorkerName As String
        Dim NormalHoursWorked As Integer
        Dim OvertimeHoursWorked As Integer
        Dim NormalPayRate As Single
        Dim OvertimePayRate As Single
        Dim GrossWages As Single
        Dim NetWages As Single
        Dim TaxToPay As Single ' REAL NUMBERS
        Const TaxRate = 30 ' VARIABLE THAT DOESN'T CHANGE  

        Console.WriteLine("Enter your name > ")
        WorkerName = Console.ReadLine
        Console.WriteLine("Enter your normal hours worked this week > ")
        NormalHoursWorked = Console.ReadLine
        Console.WriteLine("Enter your overtime hours worked this week > ")
        OvertimeHoursWorked = Console.ReadLine
        Console.WriteLine("Enter your normal hourly rate of pay > ")
        NormalPayRate = Console.ReadLine

        OvertimePayRate = NormalPayRate * 1.5
        GrossWages = (NormalHoursWorked * NormalPayRate) + (OvertimeHoursWorked * OvertimePayRate)
        TaxToPay = (GrossWages / 100) * TaxRate
        NetWages = GrossWages - TaxToPay

        Console.WriteLine("")
        Console.WriteLine(WorkerName)
        Console.WriteLine("----------------------------------")
        Console.WriteLine("Pay before tax = " & GrossWages)
        Console.WriteLine("Tax due = " & TaxToPay)
        Console.WriteLine("Take home pay = " & NetWages)
        Console.ReadLine()



    End Sub

End Module
