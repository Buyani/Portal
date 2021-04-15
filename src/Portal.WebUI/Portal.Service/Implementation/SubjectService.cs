using AutoMapper;
using Portal.Data.Entities;
using Portal.Data.Infrastructure.Interfaces;
using Portal.Data.Repository.Interfaces;
using Portal.Model.SubjectModels;
using Portal.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;


namespace Portal.Service.Implementation
{
    public class SubjectService : ISubjectService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SubjectService(ISubjectRepository SubjectModelRepository, IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void CreateSubjectModel(SubjectModel model)
        {
            _unitOfWork.Subjects.Add(_mapper.Map<Subject>(model));
            SaveSubject();
        }
        public void DeleteSubjectModel(SubjectModel model)
        {
            _unitOfWork.Subjects.Delete(_mapper.Map<Subject>(model));
            SaveSubject();
        }
        public void DeleteSubjectModel(SubjectViewModel model)
        {
            _unitOfWork.Subjects.Delete(_mapper.Map<Subject>(model));
            SaveSubject();
        }
        public void EditSubjectModel(SubjectModel model)
        {
            _unitOfWork.Subjects.Update(_mapper.Map<Subject>(model));
            SaveSubject();
        }
        public IEnumerable<SubjectViewModel> GetAllSubjects()
        {
            var list = _unitOfWork.Subjects.GetAll().ToList();
            return (IEnumerable<SubjectViewModel>)list.Select(_mapper.Map<Subject, SubjectViewModel>).ToList();
        }
        public void SaveSubject()
        {
            _unitOfWork.Complete();
        }
    }
}
