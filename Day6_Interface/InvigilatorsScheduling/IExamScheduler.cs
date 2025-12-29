namespace InvigilatorsScheduling
{
    /// <summary>
    /// Defines exam scheduling and invigilator assignment operations.
    /// </summary>
    public interface IExamScheduler
    {
        /// <summary>
        /// Schedules an examination.
        /// </summary>
        /// <param name="exam">Exam to be scheduled</param>
        void ScheduleExam(Exam exam);

        /// <summary>
        /// Assigns an invigilator to an exam.
        /// </summary>
        /// <param name="exam">Exam details</param>
        /// <param name="mentor">Mentor assigned as invigilator</param>
        void AssignInvigilator(Exam exam, Mentor mentor);
    }
}
