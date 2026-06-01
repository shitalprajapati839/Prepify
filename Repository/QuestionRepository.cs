using Microsoft.EntityFrameworkCore;
using Prepify.Models;

namespace Prepify.Repository
{
    public class QuestionRepository: IQuestionRepository
    {
        private readonly ApplicationDbContext _context;

        public QuestionRepository(ApplicationDbContext context)
        {
            _context = context;
            
        }

        public void Add(Question q)
        {
            _context.Questions.Add(q);
        }

        public Question Get(int id)
        {
            return _context.Questions.Find(id);
        }

        public IEnumerable<Question> GetAll()
        {
            return _context.Questions.Include(q => q.Category).ToList();
        }

        public IEnumerable<Question> GetByCategory(int categoryId)
        {
            return _context.Questions.Where(q => q.CategoryId == categoryId).ToList();
        }

        void IQuestionRepository.Update(Question q)
        {
            var existing = _context.Questions.Find(q.QuestionId);

            if (existing != null)
            {
                existing.Title = q.Title;
                existing.Answer = q.Answer;
                existing.CategoryId = q.CategoryId;
            }
        }


       

        void IQuestionRepository.Delete(int id)
        {
            var question = _context.Questions.Find(id);

            if (question != null)
            {
                _context.Questions.Remove(question);
            }   

        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
