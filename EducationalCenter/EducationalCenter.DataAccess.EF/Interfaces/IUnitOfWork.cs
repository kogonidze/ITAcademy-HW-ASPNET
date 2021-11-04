using System.Threading.Tasks;

namespace EducationalCenter.DataAccess.EF.Interfaces
{
    public interface IUnitOfWork
    {
        IStudentRepository Students { get; }

        ITeacherRepository Teachers { get; }

        IStudentGroupRepository StudentGroups { get; }

        IFacultyRepository Faculties { get; }

        IDepartmentRepository Departments { get; }

        ICourseRepository Courses { get; }

        ILogsRepository Logs { get; }

        Task Complete();

        void Dispose();
    }
}
