using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace WebAgent.Pages.Client
{
    public class BuyModel : PageModel
    {
        public Products pr = new Products();
        public String errorMessage = "";
        public String successMessage = "";
		public void OnGet()
        {
            String id = Request.Query["id"];
            try
            {
				String connectionString = "Data Source=(local)\\SQLEXPRESS;Initial Catalog=MobilePhone;Integrated Security=True";
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "Select * from Product WHERE ProductID=@id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                pr.id = reader.GetString(0);
                                pr.name = reader.GetString(1);
								pr.price = reader.GetInt32(2);
								pr.quantity = reader.GetInt32(3);
							}
                        }
                    }
				}
			}
			catch (Exception ex) 
            {
				errorMessage = ex.Message;
				return;
			}
        }

        public void OnPost() 
        {
            pr.id = Request.Form["id"];
            pr.name = Request.Form["name"];
            pr.price = int.Parse(Request.Form["price"]);
            pr.quantity = int.Parse(Request.Form["quantity"]);
            if(pr.id.Length == 0 || pr.name.Length == 0)
            {
                errorMessage = "All fields are required";
                return;
            }

            try
            {
				String connectionString = "Data Source=(local)\\SQLEXPRESS;Initial Catalog=MobilePhone;Integrated Security=True";
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					String sqlinsert = "INSERT INTO ProductAgent " +
									"(ProductID, ProductName, ProductPrice, ProductQuantity) VALUES " +
									"(@ProductID, @ProductName, @ProductPrice, @ProductQuantity)";

					using (SqlCommand command = new SqlCommand(sqlinsert, connection))
					{

						command.Parameters.AddWithValue("@ProductID", pr.id);
						command.Parameters.AddWithValue("@ProductName", pr.name);
						command.Parameters.AddWithValue("@ProductPrice", pr.price);
						command.Parameters.AddWithValue("@ProductQuantity", pr.quantity);

						command.ExecuteNonQuery();
					}
				}
			}
			catch (Exception ex)
            {
				errorMessage = ex.Message;
				return;
			}

			try
			{
				String connectionString = "Data Source=(local)\\SQLEXPRESS;Initial Catalog=MobilePhone;Integrated Security=True";
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					String sqlupdate = "UPDATE Product " + 
						"SET ProductQuantity = ((SELECT ProductQuantity FROM Product WHERE ProductID=@id) - @quantity) " + 
						"WHERE ProductID = @id";

					using (SqlCommand command = new SqlCommand(sqlupdate, connection))
					{

						command.Parameters.AddWithValue("@id", pr.id);
						command.Parameters.AddWithValue("@name", pr.name);
						command.Parameters.AddWithValue("@price", pr.price);
						command.Parameters.AddWithValue("@quantity", pr.quantity);
						
						command.ExecuteNonQuery();
					}
				}
			}
			catch(Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }
			Response.Redirect("/Client/Payment");
		}
    }
}
