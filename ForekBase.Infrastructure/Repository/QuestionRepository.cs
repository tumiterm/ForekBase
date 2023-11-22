using ForekBase.Application.Common.Interfaces;
using ForekBase.Domain.Entities;
using ForekBase.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForekBase.Infrastructure.Repository
{
    public class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        private readonly ApplicationDbContext _db;

        public QuestionRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db; 
        }


        //public void Save()
        //{
        //    _db.SaveChanges();
        //}


        public void Update(Question question)
        {
            _db.Questions.Update(question);
        }
    }
}
