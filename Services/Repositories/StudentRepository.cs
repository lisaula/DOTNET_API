using Entity_CodeFirst.context;
using Entity_CodeFirst.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        private SchoolContext db;

        public StudentRepository(SchoolContext dbContext)
        {
            db = dbContext;
        }
        public void DeleteEntity(int id)
        {
            var entity = db.Students.SingleOrDefault(x => x.StudentID == id);
            db.Students.Attach(entity);
            db.Students.Remove(entity);
            db.SaveChanges();
        }

        public IQueryable<Student> GelAllEntities()
        {
            var query = from b in db.Students select b;
            return query;
        }

        public Student GetById(int id)
        {
            return db.Students.SingleOrDefault( x => x.StudentID == id);
        }

        public void InsertEntity(Student entity)
        {
            db.Students.Add(entity);
            db.SaveChanges();
        }

        public void UpdateEntity(Student entity)
        {
            var student = db.Students.SingleOrDefault(x => x.StudentID == entity.StudentID);
            if(student != null)
            {
                db.Entry(student).CurrentValues.SetValues(entity);
                db.SaveChanges();
            }
        }
    }
}
