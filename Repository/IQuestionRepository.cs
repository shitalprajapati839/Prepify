using Prepify.Models;

namespace Prepify.Repository
{
    public interface IQuestionRepository
    {
        IEnumerable<Question> GetAll();
        IEnumerable<Question> GetByCategory(int categoryId);
        Question Get(int id);
        void Add(Question q);
        void Update(Question q);
        void Delete(int id);
        void Save();
    }
}
