using EducationalCenter.Common.Enums;

namespace EducationalCenter.BLL.Interfaces
{
    public interface ILoggerService
    {
        void GenerateRequestLog<TRequest>(TRequest? newRequest, LogType logType);

        void GenerateResponseLog<TRequest, TResponse>(TRequest newRequest, TResponse newResponse, LogType logType);
    }
}
