using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Xml;

namespace WebAgent.Pages.Client
{
    public class IndexModel : PageModel
    {
        public List<Products> lp = new List<Products>();

        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source=(local)\\SQLEXPRESS;Initial Catalog=MobilePhone;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM Product";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Products pr = new Products();
								pr.id = reader.GetString(0);
								pr.name = reader.GetString(1);
								pr.price = reader.GetInt32(2);
								pr.quantity = reader.GetInt32(3);

                                lp.Add(pr);
                            }
                        }
                    }
                }
            } catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }
    }

    public class Products
    {
        public String id;
        public String name;
        public int price;
        public int quantity;
    }
}
