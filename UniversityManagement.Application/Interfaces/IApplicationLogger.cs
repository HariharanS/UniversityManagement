using System;
namespace UniversityManagement.Application.Interfaces
{
    /// <summary>
    /// Application logger.
    /// </summary>
    public interface IApplicationLogger<T>
    {
        void LogWarning(string message, params object[] args);
        void LogInformation(string message, params object[] args);
    }
}
