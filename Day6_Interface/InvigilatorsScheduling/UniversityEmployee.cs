namespace InvigilatorsScheduling
{
    /// <summary>
    /// Abstract base class representing a university employee.
    /// </summary>
    public abstract class UniversityEmployee
    {
        /// <summary>
        /// Gets or sets the employee ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the employee name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the role of the employee.
        /// </summary>
        /// <returns>Role name</returns>
        public abstract string GetRole();
    }
}
