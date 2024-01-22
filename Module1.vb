Module Module1
    Dim Choice As String
    Sub Main()


        Do
            menu()
            Select Case UCase(Choice)
                Case "A"
                    A()
                Case "B"
                    B()
                Case "C"
                    C()
                Case "D"
                    D()
                Case "E"
                    E()
                Case "F"
                    F()
                Case "G"
                    G()
                Case Else

            End Select
        Loop Until UCase(Choice) = "X"

    End Sub
    Sub Pattern()
        Dim patternHeight As Integer = 1
        Dim patternWidth As Integer = Console.WindowWidth

        For i As Integer = 0 To patternHeight - 1
            For j As Integer = 0 To patternWidth - 1
                If (i + j) Mod 2 = 0 Then
                    Console.Write("X")
                Else
                    Console.Write("O")
                End If
            Next
        Next
    End Sub
    Sub Menu()


        Console.BackgroundColor = ConsoleColor.DarkBlue
        Console.ForegroundColor = ConsoleColor.Yellow
        Console.Clear()
        Pattern()


        Console.WriteLine("KS5 Driving Licence Term 1a")
        Pattern()
        Console.WriteLine("SELECT YOUR MENU OPTION:")
        Console.WriteLine("-----A: Variable declaration, constant declaration, assignment, concatenation")
        Console.WriteLine("-----B: Use Of Parameters")
        Console.WriteLine("-----C: Arithmetic Opperators")
        Console.WriteLine("-----D: Selection")
        Console.WriteLine("-----E: Nested Selection")
        Console.WriteLine("-----F: Random Numbers")
        Console.WriteLine("-----G: String Handling")

        Console.WriteLine("-----X: EXIT")
        Choice = Console.ReadLine

        ' Reset console colors
        Console.ResetColor()

    End Sub

    Sub A()
        Console.Clear()
        Pattern()
        Console.WriteLine("-----A: InputOutputConcatenation")
        Pattern()

        Dim Firstname As String = "Peter"
        Dim Lastname As String = "Shilton"
        Dim SpecialOccassion As String = "Birthday"
        Dim JobTitle As String = "Head Teacher"
        Dim Salary As Decimal = 54000.0

        'These tasks focus on taking user input, manipulating strings by concatenating them, and then presenting the results as output.
        ' They help you practice handling text input and output in Visual Basic, which is a fundamental skill for working with user 
        'interfaces and data processing in VB applications.

        Console.WriteLine("")

        'Task 1 - Name Concatenation:
        'Concatenate the two names and display the full name as output. 
        'For example, if the user enters "John" for the first name and "Doe" 
        'for the last name, the program should output "John Doe."

        Console.WriteLine("Task 1 - Name Concatenation")
        Console.WriteLine("")

        Console.WriteLine(Firstname & " " & Lastname)
        Console.WriteLine("")

        'Task 2 - Email Address Generator:
        'Create a program that takes the user's first name and last name as input 
        'and generates an email address based on a predefined format (e.g., firstname.lastname@LPSB.co.uk). 
        'Display the generated email address as output.

        Console.WriteLine("Task 2 - Email Address Generator")
        Console.WriteLine("")

        Console.WriteLine(LCase(Firstname) & "." & LCase(Lastname) & "LPSB.co.uk")
        Console.WriteLine("")

        'Task 3 - Greeting Card Generator:
        'Create a program that asks the user to enter their name and a special occasion (e.g., birthday, anniversary). 
        'Then, generate a personalized greeting card message that includes their name and the occasion

        Console.WriteLine("Task 3 - Greeting Card Generator")
        Console.WriteLine("")

        Console.WriteLine("Hello " & Firstname & " " & Lastname & ", hope you have fun on your " & SpecialOccassion & " !!")
        Console.WriteLine("")

        'Task 4 - Employee Information Display:
        'Build an application to input details of employees such as name, job title, and salary. 
        'Concatenate this information into a formatted string and display it in a list or on a form.

        Console.WriteLine("Task 4 - Employee Information Display")
        Console.WriteLine("")

        Console.WriteLine("")
        Console.WriteLine("Employee Information" & vbNewLine & " " & vbNewLine & "Name - " & Firstname & " " & Lastname & vbNewLine & "Job Title - " & JobTitle & vbNewLine & "Salary - " & Salary)
        Console.WriteLine("")

        'Task 5 - Age Calculator:
        'Create a program that asks the user to enter their birth year as an integer 
        'and their name as a string. Calculate their age and display a message like 
        '"Hello, [Name]! You are [Age] years old."

        Console.WriteLine("Task 5 - Age Calculator")
        Console.WriteLine("")

        Dim Birthyear As Integer
        Console.Write("Enter your birth year > ")
        Birthyear = Console.ReadLine
        Console.WriteLine("Hello, " & Firstname & "! You are " & (2023 - Birthyear) & " years old.")
        Console.WriteLine("")

        'Task 6 - Simple Calculator with Strings:
        'Create a basic calculator program that takes two numbers as integers and asks the 
        'user for an arithmetic operation as a string (e.g., "+", "-", "*", "/"). Perform 
        'the operation and display the result as a string.

        Console.WriteLine("Task 6 - Simple Calculator with Strings")
        Console.WriteLine("")

        Dim FirstNumber As Integer
        Dim SecondNumber As Integer
        Dim Sum As Single
        Dim Choice As String
        Console.Write("Enter your first number > ")
        FirstNumber = Console.ReadLine
        Console.Write("Enter your second number > ")
        SecondNumber = Console.ReadLine
        Console.Write("Select if you wish to do additon '+', subtraction '-', multiplication '*' or division '/'. > ")
        Choice = Console.ReadLine
        Select Case Choice
            Case "+"
                Sum = FirstNumber + SecondNumber
            Case "-"
                Sum = FirstNumber - SecondNumber
            Case "*"
                Sum = FirstNumber * SecondNumber
            Case "/"
                Sum = FirstNumber / SecondNumber
            Case Else
                Console.WriteLine("Invalid Operation")
        End Select
        Console.WriteLine(FirstNumber & " " & Choice & " " & SecondNumber & " = " & Sum)
        Console.WriteLine("")

        'Task 7 - User Profile:
        'Create a user profile program where users can input their name (string), age (integer), 
        'and favorite hobby (string). Display this information in a formatted message, e.g., 
        '"Name: John, Age: 30, Hobby: Tennis."

        Console.WriteLine("Task 7 - User Profile")
        Console.WriteLine("")

        Dim Name As String
        Dim Age As String
        Dim Hobby As String

        Console.Write("Enter your name > ")
        Name = Console.ReadLine
        Console.WriteLine("")
        Console.Write("Enter your age > ")
        Age = Console.ReadLine
        Console.WriteLine("")
        Console.Write("Enter your hobby > ")
        Hobby = Console.ReadLine
        Console.WriteLine("")
        Console.WriteLine("Name : " & Name & ", Age : " & Age & ", Hobby : " & Hobby & ".")
        Console.WriteLine("")

        Console.ReadLine()
    End Sub ' Finished

    Sub B()
        Console.Clear()
        Pattern()
        Console.WriteLine("-----B: Parameters")
        Pattern()
        'Complete all of (A: •variable declaration, constant declaration, assignment, concatenation) tasks without the use of any global variable. 
        Console.WriteLine("Completed in Section A")

        Console.ReadLine()
    End Sub ' Finished

    Sub C()
        Console.Clear()
        Pattern()
        Console.WriteLine("-----C: Arithmetic Opperators")
        Pattern()
        'These tasks focus on arithmetic operations, including addition, subtraction, multiplication, 
        'and division, and they require user input for various calculations in a Visual Basic application.

        'Task 1 - Area(Calculator):
        'Build a program that calculates the area of different geometric shapes, such as a rectangle, 
        'circle, or triangle. Prompt the user to select a shape, enter the necessary dimensions, 
        'and then calculate and display the area.

        Console.WriteLine("Task 1 - Area Calculator ")
        Console.WriteLine("")

        Dim Choice As String
        Dim Length As Single
        Dim Width As Single
        Dim Height As Single
        Dim Area As Single
        Dim Pi As Single = 3.14

        Console.Write("Enter 'R' for rectangle, 'T' for triangle, 'S' for square or 'C' for circle > ")
        Choice = Console.ReadLine
        Console.WriteLine("")

        Select Case UCase(Choice)
            Case Is = "R"
                Console.Write("Enter the length > ")
                Length = Console.ReadLine
                Console.WriteLine("")
                Console.Write("Enter the width > ")
                Width = Console.ReadLine
                Console.WriteLine("")
                Area = Length * Width
                Console.WriteLine("The area of your rectangle is > " & Area & " units squared.")
            Case Is = "T"
                Console.Write("Enter the length > ")
                Length = Console.ReadLine
                Console.WriteLine("")
                Console.Write("Enter the height > ")
                Height = Console.ReadLine
                Console.Write("")
                Area = 0.5 * Length * Height
                Console.WriteLine("The area of your triangle is > " & Area & " units squared.")
            Case Is = "C"
                Console.Write("Enter the radius > ")
                Length = Console.ReadLine
                Console.WriteLine("")
                Area = Pi * Length * Length
                Console.WriteLine("The area of your circle is > " & Area & " units squared.")
            Case Is = "S"
                Console.Write("Enter the length > ")
                Length = Console.ReadLine
                Console.WriteLine("")
                Area = Length * Length
                Console.WriteLine("The area of your square is > " & Area & " units squared.")
        End Select

        Console.WriteLine("")

        'Task 2 - Conversion(Tool):
        'Build a unit conversion program that allows users to convert between different units, such as converting miles to kilometers,
        'Bits into Bytes, or inches to centimeters. Prompt the user for the value and units to convert, and then display the converted result.

        Console.WriteLine("Task 2 - Conversion Tool ")
        Console.WriteLine("")

        Console.Write("Enter the value to convert > ")
        Dim inputValue As Double = Convert.ToDouble(Console.ReadLine())

        Console.Write("Enter the units to convert from > ")
        Dim fromUnits As String = Console.ReadLine().ToLower()

        Console.Write("Enter the units to convert to > ")
        Dim toUnits As String = Console.ReadLine().ToLower()

        Dim result As Double

        Select Case fromUnits
            Case "miles"
                Select Case toUnits
                    Case "kilometers"
                        result = inputValue * 1.60934
                    Case Else
                        Console.WriteLine("Invalid units for conversion.")
                        result = 0
                End Select
            Case "kilometers"
                Select Case toUnits
                    Case "miles"
                        result = inputValue / 1.60934
                    Case Else
                        Console.WriteLine("Invalid units for conversion.")
                        result = 0
                End Select

            Case "bits"
                Select Case toUnits
                    Case "bytes"
                        result = inputValue / 8
                    Case Else
                        Console.WriteLine("Invalid units for conversion.")
                        result = 0
                End Select
            Case "bytes"
                Select Case toUnits
                    Case "bits"
                        result = inputValue * 8
                    Case Else
                        Console.WriteLine("Invalid units for conversion.")
                        result = 0
                End Select

            Case "inches"
                Select Case toUnits
                    Case "centimeters"
                        result = inputValue * 2.54
                    Case Else
                        Console.WriteLine("Invalid units for conversion.")
                        result = 0
                End Select
            Case "centimeters"
                Select Case toUnits
                    Case "inches"
                        result = inputValue / 2.54
                    Case Else
                        Console.WriteLine("Invalid units for conversion.")
                        result = 0
                End Select

            Case Else
                Console.WriteLine("Invalid units for conversion.")
                result = 0
        End Select

        Console.WriteLine(inputValue & " " & fromUnits & "is equal to " & result & " " & toUnits)
        Console.WriteLine("")

    'Task 3 - Temperature Conversion:
    'Create a temperature conversion program that allows users to convert between Celsius and Fahrenheit. 
    'Users should input a temperature value and select the conversion direction. Perform the conversion and display the result.

        Console.WriteLine("Task 3 - Temperature Conversion")
        Console.WriteLine("")

        Console.Write("Enter the value to convert > ")
        Dim temp As Double = Convert.ToDouble(Console.ReadLine())

        Console.Write("Do you wish to convert to Celsius or Fahrenheit? (C/F) > ")
        Dim conversion As Char = UCase(Console.ReadLine())
        Dim convertTemp As Double

        Select Case conversion
            Case "C"
                convertTemp = (temp - 32) * 5 / 9
                Console.WriteLine(temp & " degrees Fahrenheit is equal to " & convertTemp & " degrees Celsius.")
            Case "F"
                convertTemp = (temp * 9 / 5) + 32
                Console.WriteLine(temp & " degrees Celsius is equal to " & convertTemp & " degrees Fahrenheit.")
        End Select


        Console.ReadLine()
    End Sub ' Finished

    Sub D()
        Console.Clear()
        Pattern()
        Console.WriteLine("-----D: Selection")
        Pattern()

        'These tasks focus on using simple conditional statements (If-Then) to make decisions based on user input. 
        'They are good exercises for practicing basic selection logic in Visual Basic.

        'Task 1 - Grading System:
        'Create a program that takes a student's test score as input and uses conditional statements to determine 
        'and display their corresponding grade (e.g., A, B, C, D, F) based on a predefined grading scale.

        Console.WriteLine("Task 1 - Grading System")
        Console.WriteLine("")

        Console.Write("Enter the score of the student > ")
        Dim score As Integer = Console.ReadLine()
        Console.Write("Enter the number of marks > ")
        Dim marknum As Integer = Console.ReadLine()
        Dim GradePer As Single
        Dim Grade As Char
        GradePer = (score / marknum) * 100

        Select Case GradePer
            Case Is <= 20
                Grade = "F"
                Console.WriteLine(score & " out of " & marknum & " is a Grade " & Grade & ".")
            Case Is <= 30
                Grade = "E"
                Console.WriteLine(score & " out of " & marknum & " is a Grade " & Grade & ".")
            Case Is <= 40
                Grade = "D"
                Console.WriteLine(score & " out of " & marknum & " is a Grade " & Grade & ".")
            Case Is <= 50
                Grade = "C"
                Console.WriteLine(score & " out of " & marknum & " is a Grade " & Grade & ".")
            Case Is <= 70
                Grade = "B"
                Console.WriteLine(score & " out of " & marknum & " is a Grade " & Grade & ".")
            Case Is <= 85
                Grade = "A"
                Console.WriteLine(score & " out of " & marknum & " is a Grade " & Grade & ".")
        End Select
        Console.WriteLine("")

        'Task 2 - Age(Classifier)
        'Develop a program that prompts the user to enter their age and then uses conditional statements to 
        'classify them into one of several categories (e.g., child, teenager, adult, senior citizen).

        Console.WriteLine("Task 2 - Age Classifier")
        Console.WriteLine("")

        Console.Write("Enter your age > ")
        Dim Age As Integer = Console.ReadLine
        Dim AgeClass As String = ""

        Select Case Age
            Case Is <= 12
                AgeClass = "Child"
            Case Is > 12
                AgeClass = "Teenager"
            Case Is >= 18
                AgeClass = "Adult"
            Case Is >= 60
                AgeClass = "Senior"
        End Select

        Console.WriteLine("You are " & Age & ". You are classified as a " & AgeClass)
        Console.WriteLine("")

        'Task 3 - Number(Comparison)
        'Write a program that takes two numbers as input and uses conditional statements to determine and 
        'display which number is larger or if they are equal.

        Console.WriteLine("Task 3 - Number Comparison")
        Console.WriteLine("")

        Console.Write("Enter first number > ")
        Dim Num1 As Integer = Console.ReadLine
        Console.Write("Enter second number > ")
        Dim Num2 As Integer = Console.ReadLine

        Select Case Num1
            Case Is > Num2
                Console.WriteLine("Number 1 (" & Num1 & ") is greater than Number 2 (" & Num2 & ").")
            Case Is < Num2
                Console.WriteLine("Number 2 (" & Num2 & ") is greater than Number 1 (" & Num1 & ").")
            Case Is = Num2
                Console.WriteLine("Number 1 (" & Num1 & ") is the same as Number 2 (" & Num2 & ").")
            Case Else
                Console.WriteLine("Error")
        End Select
        Console.WriteLine("")

        'Task 4 - Voting(Eligibility)
        'Create a program that asks the user to input their age. Based on their age, use conditional 
        'statements to determine and display whether they are eligible to vote in an election.

        Console.WriteLine("Task 4 - Voting Eligibility")
        Console.WriteLine("")

        Console.Write("Enter your age > ")
        Age = Console.ReadLine()

        If Age >= 18 Then Console.WriteLine("You can vote." & vbNewLine)
        If Age < 18 Then Console.WriteLine("You cannot vote." & vbNewLine)

        Console.WriteLine("")

        'Task  5 - Even or Odd Number:
        'Design a program that takes an integer as input and uses conditional statements to determine and 
        'Display whether the number is even or odd.

        Console.WriteLine("Task  5 - Even or Odd Number")
        Console.WriteLine("")

        Console.Write("Enter a number > ")
        Dim Number1 As Integer = Console.ReadLine

        If Number1 Mod 2 = 0 Then
            Console.WriteLine(Number1 & " is even.")
        Else
            Console.WriteLine(Number1 & " is odd.")
        End If
        Console.WriteLine("")

        Console.ReadLine()
    End Sub ' Finished

    Sub E()
        Console.Clear()
        Pattern()
        Console.WriteLine("-----E: NestedSelection & Iteration")
        Pattern()
        'These tasks involve using nested If-Then-Else statements to make more complex decisions based on user input or other conditions. 

        'Task 1 - Student Grade Classification:
        'Create a program that takes a student's test score, name and target Grade as input and uses nested selection to 
        'classify them into different Grade categories (e.g., A, B, C, D, F) based on a grading scale, 
        'and then provide additional comments (e.g., "Above your target" "Met your target," "Below your target") based on the Grade.
        ' GRADING SCALE = >30=E >40=D >50=C >60=B >70=A >80=A*

        Console.WriteLine("Task 1 - Student Grade Classification")
        Console.WriteLine("")

        Console.Write("Enter your name > ")
        Dim StudentName As String = Console.ReadLine
        Console.Write("Enter your score > ")
        Dim StudentScore As Integer = Console.ReadLine
        Console.Write("Enter your target grade > ")
        Dim StudentTargetGrade As Char = UCase(Console.ReadLine)
        Dim StudentGrade As String

        If StudentScore <= 20 Then
            StudentGrade = "F"
        ElseIf StudentScore <= 40 Then
            StudentGrade = "D"
        ElseIf StudentScore <= 60 Then
            StudentGrade = "C"
        ElseIf StudentScore <= 80 Then
            StudentGrade = "B"
        Else
            StudentGrade = "A"
        End If

        If Asc(StudentGrade) > Asc(StudentTargetGrade) Then
            Console.WriteLine("You are below your target grade.")
        ElseIf Asc(StudentGrade) < Asc(StudentTargetGrade) Then
            Console.WriteLine("You are above your target grade.")
        Else
            Console.WriteLine("You have met your target grade.")
        End If

        Console.WriteLine("")
        'Task2 - Discount Calculator for Online Shopping:
        'Develop a program that takes the total purchase amount (integer) and the customer's membership status (string: "Regular" or "Premium") as input.
        'Process the data to calculate discounts based on the membership status using nested selection. Display the discounted total.
        'Input: Total Purchase Amount (integer), Membership Status (string)
        'Processing: Calculate discounts based on membership status.
        'Output: Display the discounted total.

        Console.WriteLine("Task2 - Discount Calculator for Online Shopping")
        Console.WriteLine("")

        Console.Write("Enter the total purchase amount > ")
        Dim PurchaseAmount As Integer = Console.ReadLine
        Console.Write("Enter membership status (Regular or Premium) > ")
        Dim MembershipStatus As String = UCase(Console.ReadLine)

        Dim Discount As Single = 0.05
        If MembershipStatus = "PREMIUM" Then
            Discount = 0.1
        End If

        Dim DiscountedPrice As Single = PurchaseAmount * (1 - Discount)
        Dim TotalDiscount As Single = PurchaseAmount - DiscountedPrice
        Console.WriteLine("")
        Console.WriteLine("You have to pay : " & DiscountedPrice & " . You have saved : " & TotalDiscount)
        Console.WriteLine("")


        'Task 3 - Age Classifier with Age Group:
        'Create a program that takes a person's age (integer) as input. Process the age to classify the person as a child, teenager, adult, or senior, 
        'and then use nested selection to determine the specific age group (e.g., "Young Teenager" for ages 13-15). Display both the general classification and the age group.
        'Input:  Age(Of Integer)()
        'Processing: Classify age and determine age group.
        'Output: Display the age classification and age group.

        Console.WriteLine("Task 3 - Age Classifier with Age Group")
        Console.WriteLine("")

        Console.Write("Enter your age > ")
        Dim Age As Integer = Console.ReadLine
        Dim AgeGroup As String = ""
        Dim AgeClass As String = ""

        If Age <= 12 Then
            AgeGroup = "Child"
            If Age <= 3 Then
                AgeClass = "Toddler"
            ElseIf Age <= 10 Then
                AgeClass = "Preteen"
            Else
                AgeClass = "Young Teen"
            End If
        ElseIf Age <= 18 Then
            AgeGroup = "Teenager"
            If Age <= 13 Then
                AgeClass = "New Teen"
            Else
                AgeClass = "Young Teen"
            End If
        ElseIf Age <= 28 Then
            AgeGroup = "Young Adult"
            If Age <= 18 Then
                AgeClass = "Pre Adult"
            Else
                AgeClass = "Adult"
            End If
        ElseIf Age <= 45 Then
            AgeGroup = "Adult"
            If Age <= 30 Then
                AgeClass = "Fully Adult"
            Else
                AgeClass = "Aging Adult"
            End If
        ElseIf Age > 45 Then
            AgeGroup = "Senior"
            If Age <= 55 Then
                AgeClass = "Old Adult"
            Else
                AgeClass = "Senior"
            End If
        End If

        Console.WriteLine("You are a " & AgeGroup & ". At your age, you are classified as " & AgeClass)
        Console.WriteLine("")


        'Task 4 - Multiplication(Table)
        'Design a program that takes an integer (n) as input and generates the multiplication table for that number from 1 to 10. 
        'Use a loop to perform the calculations and display the table.
        'Input: Integer (n)
        'Processing: Generate the multiplication table for n using a loop.
        'Output: Display the multiplication table.


        Console.WriteLine("Task 4 - Multiplication(Table)")
        Console.WriteLine("")

        Console.Write("For what number would you like to see the multiplication table? > ")
        Dim Number As Integer = Console.ReadLine
        For Looper = 1 To 10
            Console.WriteLine(Number & " x " & Looper & " = " & Number * Looper)
        Next
        Console.WriteLine("")


        'Task 5 - Number(Summation)
        'Create a program that asks the user to input a positive integer. Then, use a loop to calculate and display the sum of all integers from 1 to the entered number.
        'Input: Positive Integer
        'Processing: Sum all integers from 1 to the entered number using a loop.
        'Output: Display the sum.

        Console.WriteLine("Task 5 - Number(Summation)")
        Console.WriteLine("")

        Console.Write("Enter a positive integer > ")
        Dim PosInt As Integer = Console.ReadLine
        Dim Sum As Integer
        For Looper = 1 To PosInt
            Sum = Sum + Looper
        Next
        Console.WriteLine("The sum of all numbers from 1 to " & PosInt & " is " & Sum)
        Console.WriteLine("")


        'Task 6 - Number Guessing Game:
        'Create a simple number guessing game where the program generates a random number, and the user has to guess it. 
        'Use a loop to allow the user multiple attempts. Display a win or lose message as the output.
        'Input:  User(guesses(Of Integer))
        'Processing: Generate a random number and compare it to the user's guesses using a loop.
        'Output: Display a win or lose message.

        Console.WriteLine("Task 6 - Number Guessing Game")
        Console.WriteLine("")

        Randomize()
        Dim Guess As Integer
        Console.Write("Enter the highest number >")
        Dim RandNum As Integer = Int(Rnd() * Console.ReadLine + 1)
        Console.Write("Enter the number of guesses > ")
        Dim Guesses As Integer = Console.ReadLine
        Console.WriteLine("")
        For Looper = 1 To Guesses
            Console.Write("Enter the number >")
            Guess = Console.ReadLine
            Console.WriteLine("")
            If Guess = RandNum Then
                Console.WriteLine("You have guessed the number!")
                Exit For
            Else
                Console.WriteLine("You have not guessed the number.")
                Guesses -= 1
                Console.WriteLine("You have " & Guesses & " guesses left.")
            End If
            Console.WriteLine("")
        Next
        If Guesses = 0 Then Console.WriteLine("You did not manage to guess the number.")

        Console.ReadLine()

    End Sub ' Finished

    Sub F()
        Console.Clear()
        Pattern()
        Console.WriteLine("-----F: Random numbers")
        Pattern()

        'Task 1 - Dice Rolling Simulator:
        'Input: Prompt the user to roll a six-sided die.
        'Processing: Simulate the roll by generating a random number between 1 and 6.
        'Output: Display the result of the simulated dice roll.

        Console.WriteLine("Task 1 - Dice Rolling Simulator")
        Console.WriteLine("")

        Randomize()
        Console.WriteLine("Press ENTER to roll the dice")
        Console.ReadKey()
        Console.WriteLine("Dice Rolling...")
        For Looper = 1 To 1000000000
        Next
        Dim DiceNum As Integer = Int(6 * Rnd() + 1)
        Console.WriteLine("Dice rolled. The number is " & DiceNum & vbNewLine)

        'Task 2 - Random Password Generator:
        'Input: Request the desired password length from the user.
        'Processing: Generate a random password of the specified length using a combination of letters, numbers, and symbols.
        'Output: Display the generated password.

        Console.WriteLine("Task 2 - Random Password Generator")
        Console.WriteLine("")

        Dim Characters As String = "1234567890poiuytrewqasdfghjklmnbvcxzZXCVBNMLKJHGFDSAQWERTYUIOP!£$%^&*()_-=+[]{};:'@#~,<.>/?\|"
        Dim CurrChar As String = ""
        Dim Password As String = ""

        Console.Write("Enter the length of the password > ")
        Dim Length As Integer = Console.ReadLine

        For Looper = 1 To Length
            Dim Random As Integer = Int(Len(Characters) * Rnd() + 1)
            CurrChar = Mid(Characters, Random, 1)
            Password = Password & CurrChar
        Next
        Console.WriteLine("The " & Length & " character password generated is > " & Password & " .")
        Console.WriteLine("")

        'Task 3 - Random Quote Generator:
        'Input: Load a list of inspirational quotes or facts.
        'Processing: Randomly select a quote or fact from the list.
        'Output: Display the selected quote or fact to the user.

        Console.WriteLine("Task 3 - Random Quote Generator")
        Console.WriteLine("")

        Dim Quotes() As String = {}
        FileOpen(1, "s:\Inspirational Quotes.txt", OpenMode.Input)
        Dim Quote As String = ""
        Dim QuoteNum As Integer = 0
        Do While Not EOF(1)
            Quote = LineInput(1)
            QuoteNum += 1
            ReDim Preserve Quotes(QuoteNum)
            Quotes(QuoteNum - 1) = Quote
        Loop
        ReDim Preserve Quotes(QuoteNum - 1)
        FileClose(1)

        Console.WriteLine(Quotes(Int(QuoteNum * Rnd())))
        Console.WriteLine("")

        'Task 4 - Lottery Number Picker:
        'Input: Ask the user for the number of lottery numbers they want to generate.
        'Processing: Generate the specified number of unique random lottery numbers.
        'Output: Display the list of lottery numbers to the user.

        Console.WriteLine("Task 4 - Lottery Numer Picker")
        Console.WriteLine("")

        Console.Write("Enter the number of lottery numbers you wish to generate > ")
        Dim GenNum As Integer = Console.ReadLine()
        Console.WriteLine("Generating numbers..")
        Console.WriteLine("")
        Console.Write("The numbers generated are > ")

        Dim NumList(GenNum - 1) As Integer

        For Looper = 1 To GenNum
            Dim OK As Boolean = False
            Do
                Dim Num As Integer = Int((59 * Rnd()) + 1)
                If NumList.Contains(Num) Then
                    OK = False
                Else
                    OK = True
                    NumList(Looper - 1) = Num
                    Console.Write(Num & " ")
                End If
            Loop Until OK

        Next

        Console.WriteLine("")

        Console.ReadLine()
    End Sub ' Finished

    Sub G()
        Console.Clear()
        Pattern()
        Console.WriteLine("-----G: String Functions")
        Pattern()

        'Task 1 - Calculate String Length
        'Write a Visual Basic program that takes a user input string and calculates and displays the length of the input string.

        Console.WriteLine("Task 1 - Calculate String Length")
        Console.Write("Enter your string of text > ")
        Dim UserString As String = Console.ReadLine
        Dim StringLength As Integer = Len(UserString)
        Console.WriteLine("")
        Console.WriteLine("Your string is " & StringLength & " characters long.")
        Console.WriteLine("")

        'Task 2 - Password Strength Checker
        'Design a VB.NET program that checks the strength of a password. The user should enter a password, 
        'and the program should determine the length of the password and display whether it is weak, moderate, or strong based on length criteria.
        'Weak: Less than 6 characters
        'Moderate: Between 6 and 10 characters
        'Strong: More than 10 characters

        Console.WriteLine("Task 2 - Password Strength Checker")
        Console.WriteLine("")

        Console.Write("Enter the password to check the strength > ")
        Dim Password As String = Console.ReadLine
        Dim Strength As String = ""

        If Len(Password) < 6 Then
            Strength = "Weak"
        ElseIf Len(Password) >= 6 Then
            Strength = "Moderate"
        ElseIf Len(Password) >= 10 Then
            Strength = "Strong"
        End If

        Console.WriteLine("Your password is " & Strength)
        Console.WriteLine("")

        'Task 3 Password input
        'have a variable called password and set it to "Password"
        'Get the user to enter their password
        'If the password they enter is less than 8 characters long, Tell the user "password must be at least 8 characters". 
        'Get them to keep entering the password until it is 8 or more characters
        'once it is 8 or more characters long,  If it is correct then say "logged in" otherwise "Incorrect Password"

        Console.WriteLine("Task 3 - Password Input")
        Console.WriteLine("")
        Dim UserPass As String = ""
        Dim PassLength As Integer = 0
        Password = "Password"
        Do
            Console.Write("Enter your password > ")
            UserPass = Console.ReadLine
            PassLength = Len(UserPass)
            If PassLength > 8 Then Console.WriteLine("Password must be at least 8 characters >")
        Loop Until PassLength >= 8

        Console.WriteLine("")

        If UserPass = Password Then
            Console.WriteLine("Logged in .")
        Else
            Console.WriteLine("Incorrect password . ")
        End If

        Console.ReadLine()
    End Sub ' Finished

End Module
