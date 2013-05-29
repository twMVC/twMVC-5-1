using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using twMVC.Interface;
using twMVC.Repositories.EF;


namespace twMVC.Interface
{
    public interface IRandomEmployeeNameService
    {
        Employees GetEmployee();
    }
}
