using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningCenter.ProductDatabase;

namespace LearningCenter.Repository
{
    public class DatabaseAccessor
    {
        private static readonly minicstructorEntities entities;

        static DatabaseAccessor()
        {
            entities = new minicstructorEntities();
            entities.Database.Connection.Open();
        }

        public static minicstructorEntities Instance
        {
            get
            {
                return entities;
            }
        }
    }
}
