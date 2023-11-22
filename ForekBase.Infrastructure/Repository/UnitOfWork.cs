using ForekBase.Application.Common.Interfaces;
using ForekBase.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForekBase.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public ISurveyRepository Survey { get; private set; }
        public IQuestionRepository Question { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;

            Survey = new SurveyRepository(_db);

            Question = new QuestionRepository(_db);

        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
