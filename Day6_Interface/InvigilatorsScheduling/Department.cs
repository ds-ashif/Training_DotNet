namespace InvigilatorsScheduling
{
    /// <summary>
    /// Represents an academic department within the university.
    /// </summary>
    /// <remarks>
    /// A department is associated with a Head of Department (HOD)
    /// and is responsible for managing academic activities.
    /// </remarks>
    public class Department
    {
        /// <summary>
        /// Gets or sets the department name.
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// Gets or sets the department code.
        /// </summary>
        public string DepartmentCode { get; set; }

        /// <summary>
        /// Gets or sets the HOD of the department.
        /// </summary>
        public Hod DepartmentHod { get; set; }
    }
}
