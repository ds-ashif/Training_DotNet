using System;

namespace MultipleInheritanceExample
{
    #region VegEater Class

    /// <summary>
    /// Represents an entity that consumes vegetarian food.
    /// </summary>
    /// <remarks>
    /// Implements the <see cref="IVegEater"/> interface.
    /// </remarks>
    public class VegEater : IVegEater
    {
        /// <inheritdoc/>
        public void EatVeg()
        {
            Console.WriteLine("Eating Vegetables");
        }

        /// <inheritdoc/>
        public void GetTaste()
        {
            Console.WriteLine("veg is rank 1");
        }
    }

    #endregion

    #region NonVegEater Class

    /// <summary>
    /// Represents an entity that consumes non-vegetarian food.
    /// </summary>
    /// <remarks>
    /// Implements the <see cref="INonVegEater"/> interface.
    /// </remarks>
    public class NonVegEater : INonVegEater
    {
        /// <inheritdoc/>
        public void EatNonVeg()
        {
            Console.WriteLine("Eating NonVeg");
        }

        /// <inheritdoc/>
        public void GetTaste()
        {
            Console.WriteLine("Non veg is rank 2");
        }
    }

    #endregion

    #region Visitor Class

    /// <summary>
    /// Represents a visitor capable of consuming both
    /// vegetarian and non-vegetarian food.
    /// </summary>
    /// <remarks>
    /// Demonstrates multiple inheritance in C# using interfaces.
    /// </remarks>
    public class Visitor : IVegEater, INonVegEater
    {
        /// <inheritdoc/>
        public void EatNonVeg()
        {
            Console.WriteLine("User is nonveg eater");
        }

        /// <inheritdoc/>
        public void EatVeg()
        {
            Console.WriteLine("User is veg eater");
        }

        /// <summary>
        /// Internal vegetarian eater instance.
        /// </summary>
        IVegEater v = new VegEater();

        /// <summary>
        /// Stores vegetarian taste preference.
        /// </summary>
        string vtaste = v.GetTaste();

        /// <summary>
        /// Internal non-vegetarian eater instance.
        /// </summary>
        INonVegEater n = new NonVegEater();

        /// <summary>
        /// Stores non-vegetarian taste preference.
        /// </summary>
        string nvtaste = n.GetTaste();
    }

    #endregion
}
