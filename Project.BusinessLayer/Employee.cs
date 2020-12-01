using Project.BusinessLayer.Interface;
using Project.BusinessModel;
using Project.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLayer
{
    public class Employee : IEmployee
    {
        EmployeeEntities _context = null;

        public EntityState ModelState { get; private set; }

        public Employee()
        {
            _context = new EmployeeEntities();
        }

        public IEnumerable<EmployeeModel> GetAllData()
        {
            return _context.Emps.Select(x => new EmployeeModel(){ 
                Id = x.Id,
                Name = x.Name,
                Age = x.Age
            }).ToList();
        }
        public void Create(EmployeeModel model)
        {
            Emp emp = new Emp()
            {
                Id = model.Id,
                Name = model.Name,
                Age = model.Age
            };

           _context.Emps.Add(emp);
            SaveChange();
        }
        public void Edit(EmployeeModel model)
        {
            Emp emp = new Emp()
            {
                Id = model.Id,
                Name = model.Name,
                Age = model.Age
            };

            _context.Entry(emp).State = EntityState.Modified;
            SaveChange();
        }
        public EmployeeModel GetSingleData(int id)
        {
            EmployeeModel data = _context.Emps
                .Where(x => x.Id == id)
                .Select(x => new EmployeeModel(){
                    Id = x.Id,
                    Name = x.Name,
                    Age = x.Age
                }).FirstOrDefault();


            return data;
        }


        public void Delete(int id)
        {
            var data = _context.Emps.Where(x => x.Id == id).FirstOrDefault();
            _context.Emps.Remove(data);
            SaveChange();
        }
        public void SaveChange()
        {
            _context.SaveChanges();
        }

    }
}
