using EducationalCenter.Common.Models;
using EducationalCenter.DataAccess.EF.Interfaces;

namespace EducationalCenter.DataAccess.EF.Repositories
{
    public class LogsRepository : BaseRepository<Log>, ILogsRepository
    {
        public LogsRepository(EducationalCenterContext context) : base(context)
        {

        }
    }
}
