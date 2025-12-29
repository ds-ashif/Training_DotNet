using System;
using Day7_MultipleInheritance;

#region Program Entry Point

/// <summary>
/// Entry point of the application.
/// Demonstrates multiple inheritance using interfaces in C#.
/// </summary>
class Program
{
    /// <summary>
    /// Main method where execution begins.
    /// </summary>
    static void Main()
    {
        // Object creation
        Bird1 bird = new Bird1();

        // Calling methods implemented from multiple interfaces
        bird.Fly();
        bird.Eat();
        bird.Swim();
        bird.Walk();
        bird.Chirp();

        Console.WriteLine("--------------------");

        // Interface reference demonstrating polymorphism
        IBird1 birdRef = bird;
        birdRef.Fly();
        birdRef.Eat();
    }
}

#endregion
