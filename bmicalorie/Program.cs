using System;

class BMICalorieGame
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the BMI & Calorie Calculator Game!");
        
        // Input Height and Weight
        Console.Write("Enter your height in meters (e.g., 1.75): ");
        double height = Convert.ToDouble(Console.ReadLine());
        
        Console.Write("Enter your weight in kilograms (e.g., 70): ");
        double weight = Convert.ToDouble(Console.ReadLine());

        // BMI Calculation
        double bmi = CalculateBMI(height, weight);
        Console.WriteLine($"\nYour BMI is: {bmi:F2}");
        DisplayBMICategory(bmi);
        
        // Input for calorie calculation
        Console.WriteLine("\nNow, let's calculate your daily calorie needs.");
        Console.Write("Enter your age: ");
        int age = Convert.ToInt32(Console.ReadLine());
        
        Console.Write("Enter your gender (M/F): ");
        char gender = Char.ToUpper(Convert.ToChar(Console.ReadLine()));

        Console.WriteLine("Select your activity level: ");
        Console.WriteLine("1 - Sedentary (little or no exercise)");
        Console.WriteLine("2 - Lightly active (light exercise/sports 1-3 days/week)");
        Console.WriteLine("3 - Moderately active (moderate exercise/sports 3-5 days/week)");
        Console.WriteLine("4 - Very active (hard exercise/sports 6-7 days a week)");
        int activityLevel = Convert.ToInt32(Console.ReadLine());
        
        // Calorie Calculation
        double dailyCalories = CalculateCalorieNeeds(weight, height, age, gender, activityLevel);
        Console.WriteLine($"\nYour estimated daily calorie needs are: {dailyCalories:F0} calories.");

        Console.WriteLine("\nThank you for playing the BMI & Calorie Calculator Game!");
    }

    // Method to calculate BMI
    static double CalculateBMI(double height, double weight)
    {
        return weight / (height * height);
    }

    // Method to display BMI category
    static void DisplayBMICategory(double bmi)
    {
        if (bmi < 18.5)
        {
            Console.WriteLine("You are underweight.");
        }
        else if (bmi >= 18.5 && bmi <= 24.9)
        {
            Console.WriteLine("You are in the normal weight range.");
        }
        else if (bmi >= 25 && bmi <= 29.9)
        {
            Console.WriteLine("You are overweight.");
        }
        else
        {
            Console.WriteLine("You are in the obese category.");
        }
    }

    // Method to calculate daily calorie needs based on height, weight, age, gender, and activity level
    static double CalculateCalorieNeeds(double weight, double height, int age, char gender, int activityLevel)
    {
        double bmr;
        
        // Calculate Basal Metabolic Rate (BMR) using the Mifflin-St Jeor Equation
        if (gender == 'M')
        {
            bmr = 10 * weight + 6.25 * height * 100 - 5 * age + 5;
        }
        else // Female
        {
            bmr = 10 * weight + 6.25 * height * 100 - 5 * age - 161;
        }
        
        // Adjust BMR based on activity level
        double activityMultiplier = 1.2; // Default to sedentary
        switch (activityLevel)
        {
            case 1: activityMultiplier = 1.2; break;    // Sedentary
            case 2: activityMultiplier = 1.375; break;  // Lightly active
            case 3: activityMultiplier = 1.55; break;   // Moderately active
            case 4: activityMultiplier = 1.725; break;  // Very active
        }
        
        return bmr * activityMultiplier;
    }
}
