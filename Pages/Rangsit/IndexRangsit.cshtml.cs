using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace inventorySystem.Pages.Rangsit
{
    public class IndexRangsitModel : PageModel
    {
        public List<StockInfo> ListStocks = new List<StockInfo>();

        public void OnGet()
        {
            try
            {
                String connectionString = "Server=tcp:invertory2547.database.windows.net,1433;Initial Catalog=inventory;Persist Security Info=False;User ID=suphet;Password={Atom1111};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM stocks WHERE storeid=1";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                StockInfo stockInfo = new StockInfo();
                                stockInfo.itemid = "" + reader.GetInt32(0);
                                stockInfo.item = reader.GetString(1);
                                stockInfo.storeid = reader.GetString(2);
                                stockInfo.supplier = reader.GetString(3);
                                stockInfo.amount = reader.GetString(4);
                                stockInfo.create_at = reader.GetString(5).ToString();

                                ListStocks.Add(stockInfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }        

    public class StockInfo
    {
        public String itemid;
        public String item;
        public String storeid;
        public String Supplier;
        public String amount;
        public String create_at;
        internal string supplier;
    }


}
