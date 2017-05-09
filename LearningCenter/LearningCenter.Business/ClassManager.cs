using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningCenter.Repository;

namespace LearningCenter.Business
{
    public interface IClassManager
    {
        ClassModel[] ClassList();
    }

    public class ClassModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }

    class ClassManager : IClassManager
    {
        private readonly IClassRepository classRepository;

        public ClassManager(IClassRepository classRepository)
        {
            this.classRepository = classRepository;
        }

        public ClassModel[] ClassList()
        {
            return classRepository.ClassList().Select(t => new ClassModel
            {
                Id = t.Id,
                Name = t.Name,
                Description = t.Description,
                Price = t.Price
            }).ToArray();
        }
    }
}
