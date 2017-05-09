using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCenter.Repository
{ 
    public interface IClassRepository
    {
        ClassModel[] ClassList();
        //ClassModel[] GetClass(int userId); 
    }

    public class ClassModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        //public string User { get; set; }
        
}

    class ClassRepository : IClassRepository
    {
        public ClassModel[] ClassList()
        {
            return DatabaseAccessor.Instance.Classes.Select(t => new ClassModel
            {
                Id = t.ClassId,
                Name = t.ClassName,
                Description = t.ClassDescription,
                Price = t.ClassPrice,
                //User = t.Users.ToString()
            }).ToArray();
        }

        /*
        public ClassModel GetClass(int userId)
        {
            return DatabaseAccessor.Instance.Classes.Where(t => t.Users == userId)
                .Select(t => new ClassModel {Id = t.ClassId, Description = t.ClassDescription })
                .ToArray();  
        }
        */
        
            
    }
}
