namespace InvigilatorsScheduling
{
    /// <summary>
    /// Represents a role assigned to a university employee.
    /// </summary>
    public abstract class Role : UniversityEmployee
    {
        /// <summary>
        /// Gets or sets the designation.
        /// </summary>
        public string Designation { get; set; }

        /// <summary>
        /// Gets or sets permissions associated with the role.
        /// </summary>
        public string Permissions { get; set; }
    }
}
