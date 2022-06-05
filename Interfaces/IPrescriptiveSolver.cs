using HRAnalyticsPrescriptiveAPI.Entities;

namespace HRAnalyticsPrescriptiveAPI.Interfaces
{
    public interface IPrescriptiveSolver
    {
        SolverResult Solve(Input argInput);
    }
}
