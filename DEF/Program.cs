using System;

public interface IMathOperation
{
    double Compute(double first, double second);
    string OperationTitle { get; }
}

public abstract class MathOperation : IMathOperation
{
    public abstract string OperationTitle { get; }
    public abstract double Compute(double first, double second);
}

public class AddOperation : MathOperation
{
    public override string OperationTitle => "Sum";
    public override double Compute(double first, double second) => first + second;
}

public class SubtractOperation : MathOperation
{
    public override string OperationTitle => "Difference";
    public override double Compute(double first, double second) => first - second;
}

public class MultiplyOperation : MathOperation
{
    public override string OperationTitle => "Product";
    public override double Compute(double first, double second) => first * second;
}

public class DivideOperation : MathOperation
{
    public override string OperationTitle => "Quotient";
    public override double Compute(double first, double second)
    {
        if (second == 0)
        {
            Console.WriteLine("Cannot divide by zero");
            return double.NaN;
        }
        return first / second;
    }
}

public class MathCalculator
{
    public double PerformCalculation(IMathOperation operation, double x, double y)
    {
        return operation.Compute(x, y);
    }
}

public class CalculatorApp
{
    static void RunCalculator()
    {
        MathCalculator calculator = new MathCalculator();

        Console.Write("Enter first value: ");
        double num1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter second value: ");
        double num2 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("\nAvailable operations:");
        Console.WriteLine("A - Add numbers");
        Console.WriteLine("S - Subtract numbers");
        Console.WriteLine("M - Multiply numbers");
        Console.WriteLine("D - Divide numbers");
        Console.Write("Select operation: ");

        string selection = Console.ReadLine().ToUpper();
        IMathOperation chosenOperation = null;

        switch (selection)
        {
            case "A":
                chosenOperation = new AddOperation();
                break;
            case "S":
                chosenOperation = new SubtractOperation();
                break;
            case "M":
                chosenOperation = new MultiplyOperation();
                break;
            case "D":
                chosenOperation = new DivideOperation();
                break;
            default:
                Console.WriteLine("Invalid selection");
                return;
        }

        double calculationResult = calculator.PerformCalculation(chosenOperation, num1, num2);

        Console.WriteLine($"\nOperation: {chosenOperation.OperationTitle}");
        Console.WriteLine($"Output: {calculationResult}");
    }

    static void Main()
    {
        RunCalculator();
    }
}