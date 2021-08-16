﻿using EducationalCenter.DataAccess.EF.Interfaces;
using EducationalCenter.DataAccess.EF.Repositories;
using System;
using System.Threading.Tasks;

namespace EducationalCenter.DataAccess.EF
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly EducationalCenterContext _context;
        private IStudentRepository _studentRepository;

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