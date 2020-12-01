using Project.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLayer.Interface
{
    public interface IEmployee
    {
         IEnumerable<EmployeeModel> GetAllData();
         void Create(EmployeeModel model);
         void Edit(EmployeeModel model);
         void Delete(int id);
         EmployeeModel GetSingleData(int id);
         void SaveChange();
        
    }
}
