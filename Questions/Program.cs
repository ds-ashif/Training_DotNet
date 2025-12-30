using System;

public class Program
{
    public static void Main()
    {
        HeightCategory();
        LargestOfThree();
        LeapYearChecker();
        QuadraticEquation();
        AdmissionEligibility();
        ElectricityBill();
        VowelOrConsonant();
        TriangleType();
        QuadrantFinder();
        GradeDescription();
        ValidDateCheck();
        ATMWithdrawal();
        ProfitLoss();
        RockPaperScissors();
        SimpleCalculator();
    }

    public static void HeightCategory()
    {
        int heightCm = int.Parse(Console.ReadLine());
        if (heightCm < 150) Console.WriteLine("Dwarf");
        else if (heightCm < 165) Console.WriteLine("Average");
        else if (heightCm <= 190) Console.WriteLine("Tall");
        else Console.WriteLine("Abnormal");
    }

    public static void LargestOfThree()
    {
        int firstValue = int.Parse(Console.ReadLine());
        int secondValue = int.Parse(Console.ReadLine());
        int thirdValue = int.Parse(Console.ReadLine());

        int maximumValue;
        if (firstValue > secondValue)
            maximumValue = firstValue > thirdValue ? firstValue : thirdValue;
        else
            maximumValue = secondValue > thirdValue ? secondValue : thirdValue;

        Console.WriteLine(maximumValue);
    }

    public static void LeapYearChecker()
    {
        int year = int.Parse(Console.ReadLine());
        if (year % 400 == 0 || (year % 4 == 0 && year % 100 != 0))
            Console.WriteLine("Leap Year");
        else
            Console.WriteLine("Not Leap Year");
    }

    public static void QuadraticEquation()
    {
        double coefficientA = double.Parse(Console.ReadLine());
        double coefficientB = double.Parse(Console.ReadLine());
        double coefficientC = double.Parse(Console.ReadLine());

        double discriminant = coefficientB * coefficientB - 4 * coefficientA * coefficientC;

        if (discriminant > 0)
        {
            double rootOne = (-coefficientB + Math.Sqrt(discriminant)) / (2 * coefficientA);
            double rootTwo = (-coefficientB - Math.Sqrt(discriminant)) / (2 * coefficientA);
            Console.WriteLine($"{rootOne} {rootTwo}");
        }
        else if (discriminant == 0)
        {
            double root = -coefficientB / (2 * coefficientA);
            Console.WriteLine(root);
        }
        else
        {
            Console.WriteLine("No Real Roots");
        }
    }

    public static void AdmissionEligibility()
    {
        int mathMarks = int.Parse(Console.ReadLine());
        int physicsMarks = int.Parse(Console.ReadLine());
        int chemistryMarks = int.Parse(Console.ReadLine());

        int totalMarks = mathMarks + physicsMarks + chemistryMarks;

        if (mathMarks >= 65 && physicsMarks >= 55 && chemistryMarks >= 50 &&
            (totalMarks >= 180 || mathMarks + physicsMarks >= 140))
            Console.WriteLine("Eligible");
        else
            Console.WriteLine("Not Eligible");
    }

    public static void ElectricityBill()
    {
        int unitsConsumed = int.Parse(Console.ReadLine());
        double billAmount;

        if (unitsConsumed <= 199)
            billAmount = unitsConsumed * 1.20;
        else if (unitsConsumed <= 400)
            billAmount = 199 * 1.20 + (unitsConsumed - 199) * 1.50;
        else if (unitsConsumed <= 600)
            billAmount = 199 * 1.20 + 201 * 1.50 + (unitsConsumed - 400) * 1.80;
        else
            billAmount = 199 * 1.20 + 201 * 1.50 + 200 * 1.80 + (unitsConsumed - 600) * 2.00;

        if (billAmount > 400)
            billAmount += billAmount * 0.15;

        Console.WriteLine(billAmount);
    }

    public static void VowelOrConsonant()
    {
        char inputCharacter = char.Parse(Console.ReadLine().ToLower());

        switch (inputCharacter)
        {
            case 'a':
            case 'e':
            case 'i':
            case 'o':
            case 'u':
                Console.WriteLine("Vowel");
                break;
            default:
                Console.WriteLine("Consonant");
                break;
        }
    }

    public static void TriangleType()
    {
        int sideOne = int.Parse(Console.ReadLine());
        int sideTwo = int.Parse(Console.ReadLine());
        int sideThree = int.Parse(Console.ReadLine());

        if (sideOne == sideTwo && sideTwo == sideThree)
            Console.WriteLine("Equilateral");
        else if (sideOne == sideTwo || sideTwo == sideThree || sideOne == sideThree)
            Console.WriteLine("Isosceles");
        else
            Console.WriteLine("Scalene");
    }

    public static void QuadrantFinder()
    {
        int xCoordinate = int.Parse(Console.ReadLine());
        int yCoordinate = int.Parse(Console.ReadLine());

        if (xCoordinate > 0 && yCoordinate > 0) Console.WriteLine("Quadrant I");
        else if (xCoordinate < 0 && yCoordinate > 0) Console.WriteLine("Quadrant II");
        else if (xCoordinate < 0 && yCoordinate < 0) Console.WriteLine("Quadrant III");
        else if (xCoordinate > 0 && yCoordinate < 0) Console.WriteLine("Quadrant IV");
        else Console.WriteLine("On Axis");
    }

    public static void GradeDescription()
    {
        char grade = char.Parse(Console.ReadLine().ToUpper());

        switch (grade)
        {
            case 'E': Console.WriteLine("Excellent"); break;
            case 'V': Console.WriteLine("Very Good"); break;
            case 'G': Console.WriteLine("Good"); break;
            case 'A': Console.WriteLine("Average"); break;
            case 'F': Console.WriteLine("Fail"); break;
        }
    }

    public static void ValidDateCheck()
    {
        int day = int.Parse(Console.ReadLine());
        int month = int.Parse(Console.ReadLine());
        int year = int.Parse(Console.ReadLine());

        bool isLeapYear = year % 400 == 0 || (year % 4 == 0 && year % 100 != 0);
        int[] daysPerMonth = { 31, isLeapYear ? 29 : 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        if (month >= 1 && month <= 12 && day >= 1 && day <= daysPerMonth[month - 1])
            Console.WriteLine("Valid Date");
        else
            Console.WriteLine("Invalid Date");
    }

    public static void ATMWithdrawal()
    {
        bool isCardInserted = Console.ReadLine() == "1";
        bool isPinValid = Console.ReadLine() == "1";
        bool isBalanceSufficient = Console.ReadLine() == "1";

        if (isCardInserted)
        {
            if (isPinValid)
            {
                if (isBalanceSufficient)
                    Console.WriteLine("Transaction Successful");
                else
                    Console.WriteLine("Insufficient Balance");
            }
            else
                Console.WriteLine("Invalid Pin");
        }
        else
            Console.WriteLine("Insert Card");
    }

    public static void ProfitLoss()
    {
        double costPrice = double.Parse(Console.ReadLine());
        double sellingPrice = double.Parse(Console.ReadLine());

        if (sellingPrice > costPrice)
            Console.WriteLine(((sellingPrice - costPrice) / costPrice) * 100);
        else
            Console.WriteLine(((costPrice - sellingPrice) / costPrice) * 100);
    }

    public static void RockPaperScissors()
    {
        string firstPlayerChoice = Console.ReadLine();
        string secondPlayerChoice = Console.ReadLine();

        if (firstPlayerChoice == secondPlayerChoice)
            Console.WriteLine("Draw");
        else if ((firstPlayerChoice == "Rock" && secondPlayerChoice == "Scissors") ||
                 (firstPlayerChoice == "Scissors" && secondPlayerChoice == "Paper") ||
                 (firstPlayerChoice == "Paper" && secondPlayerChoice == "Rock"))
            Console.WriteLine("Player 1 Wins");
        else
            Console.WriteLine("Player 2 Wins");
    }

    public static void SimpleCalculator()
    {
        double firstNumber = double.Parse(Console.ReadLine());
        double secondNumber = double.Parse(Console.ReadLine());
        char operation = char.Parse(Console.ReadLine());

        switch (operation)
        {
            case '+': Console.WriteLine(firstNumber + secondNumber); break;
            case '-': Console.WriteLine(firstNumber - secondNumber); break;
            case '*': Console.WriteLine(firstNumber * secondNumber); break;
            case '/': Console.WriteLine(firstNumber / secondNumber); break;
        }
    }
}
