using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace RoleSample.Models
{
    public class Repository : IRepository
    {
        public IEnumerable<MenuItemModel> GetAllMenu()
        {
            //取得組態檔案中對應的連線字串
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            List<string> test = new List<string>();

            List<MenuItemModel> menuItem = new List<MenuItemModel>();

            //成功登入後，顯示MENU內容
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select * from AspNetMenu"))
                {
                    cmd.Connection = cn;
                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        try
                        {
                            while (dr.Read())
                            {
                                MenuItemModel item = new MenuItemModel();

                                item.Id = Convert.ToInt32(dr["Id"].ToString());
                                item.Parent = Convert.ToInt32(dr["Parent"].ToString());
                                item.Order = Convert.ToInt32(dr["Order"].ToString());
                                item.Name = dr["Name"].ToString();
                                item.RoleName = dr["RoleId"].ToString();

                                menuItem.Add(item);
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.ToString());
                        }
                        return menuItem;
                    }
                }
            }
        }
    }
}