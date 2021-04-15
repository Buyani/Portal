using Portal.Model.SubjectModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Portal.Service.Interfaces
{
    public interface ISubjectService
    {
        void CreateSubjectModel(SubjectModel model);
        void DeleteSubjectModel(SubjectModel model);
         void DeleteSubjectModel(SubjectViewModel model);
        void EditSubjectModel(SubjectModel model);
        IEnumerable<SubjectViewModel> GetAllSubjects();
        void SaveSubject();
    }
}
