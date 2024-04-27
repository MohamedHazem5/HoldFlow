namespace HoldFlow.BL.Managers
{
    public class ReportManager : Manager<Report>, IReportManager
    {
        public ReportManager(IReportRepository repository) : base(repository)
        {
        }

        // Implement manager methods here
    }
}