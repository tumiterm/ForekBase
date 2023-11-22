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
    public class SurveyRepository : Repository<Survey>, ISurveyRepository
    {
        private readonly ApplicationDbContext _db;

        public SurveyRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db; 
        }


        public void Save()
        {
            _db.SaveChanges();
        }


        public void Update(Survey survey)
        {
            _db.Surveys.Update(survey);
        }
    }
}
