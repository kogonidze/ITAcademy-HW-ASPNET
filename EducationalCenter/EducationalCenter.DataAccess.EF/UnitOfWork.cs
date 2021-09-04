using EducationalCenter.DataAccess.EF.Interfaces;
using EducationalCenter.DataAccess.EF.Repositories;
using System;
using System.Threading.Tasks;

namespace EducationalCenter.DataAccess.EF
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly EducationalCenterContext _context;
        private IStudentRepository _studentRepository;
        private ITeacherRepository _teacherRepository;
        private IStudentGroupRepository _studentGroupRepository;
        private IFacultyRepository _facultyRepository;
        private IDepartmentRepository _departmentRepository;

        private bool disposed = false;

        public UnitOfWork(EducationalCenterContext context)
        {
            _context = context;
        }

        public IStudentRepository Students
        {
            get
            {
                if (_studentRepository == null)
                {
                    _studentRepository = new StudentRepository(_context);
                }

                return _studentRepository;
            }
        }

        public ITeacherRepository Teachers
        {
            get
            {
                if (_teacherRepository == null)
                {
                    _teacherRepository = new TeacherRepository(_context);
                }

                return _teacherRepository;
            }
        }

        public IStudentGroupRepository StudentGroups
        {
            get
            {
                if (_studentGroupRepository == null)
                {
                    _studentGroupRepository = new StudentGroupRepository(_context);
                }

                return _studentGroupRepository;
            }
        }

        public IFacultyRepository Faculties
        {
            get
            {
                if (_facultyRepository == null)
                {
                    _facultyRepository = new FacultyRepository(_context);
                }

                return _facultyRepository;
            }
        }

        public IDepartmentRepository Departments
        {
            get
            {
                if (_departmentRepository == null)
                {
                    _departmentRepository = new DepartmentRepository(_context);
                }

                return _departmentRepository;
            }
        }

        public async Task Complete()
        {
            await _context.SaveChangesAsync();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
