using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoleSample.Models
{
    public interface IRepository
    {
        IEnumerable<MenuItemModel> GetAllMenu();
    }
}