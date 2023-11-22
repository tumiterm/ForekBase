using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForekBase.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        ISurveyRepository Survey {  get; }
        IQuestionRepository Question { get; }
        void Save();

    }
}
