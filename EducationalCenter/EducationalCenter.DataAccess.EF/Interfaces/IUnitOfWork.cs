using System.Threading.Tasks;

namespace EducationalCenter.DataAccess.EF.Interfaces
{
    public interface IUnitOfWork
    {
        IStudentRepository Students { get; }
        ITeacherRepository Teachers { get; }
        Task Complete();
        void Dispose();
    }
}
