using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        String connection = "Server= localhost; port = 3307; user = root; password = 12345678@Abc; database= dbtest;CharSet=utf8";
        /*
         * API GET
         * Lấy toàn bộ dữ liệu khách hàng
         * @param: customer[]
         * auth: NTNgoc
         * Created date: 4/6/2020
         * ***/
        // GET: api/Customer
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            var customers = new List<Customer>();
            //Khởi tạo đối tượng MySQL connection
            MySqlConnection conn = new MySqlConnection(connection);
            //Khởi tạo dối tượng MySQLCommand thao tác với csdl
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbtest.getCustomer";
            // Mở kết nối
            conn.Open();
            // Chạy Procedure
            MySqlDataReader mysqlDataReader = cmd.ExecuteReader();
            //Xử lí dữ liệu trả về
            while (mysqlDataReader.Read())
            {
                var customer = new Customer();
                for (int i = 0; i < mysqlDataReader.FieldCount; i++)
                {
                    // Lấy tên cột dữ liệu đang đọc
                    var colName = mysqlDataReader.GetName(i);
                    // Lấy giá trị ô 
                    var value = mysqlDataReader.GetValue(i);
                    // Map property với tên cột dữ liệu
                    var property = customer.GetType().GetProperty(colName);
                    // Gán dữ liệu nếu property đúng với tên cột 
                    if (property != null && value != DBNull.Value)
                    {
                        property.SetValue(customer, value);
                    }
                }
                // Thêm đối tượng vào list
                customers.Add(customer);
            }
            conn.Close();
            return customers;
        }

        // GET: api/Customer/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        /*
         * API POST
         * Cất 1 đối tượng Customer  vào CSDL
         * @param: customer{}
         * Auth: NTNgoc
         * Created date: 5/6/2020
         * **/        
        // POST: api/Customer
        [HttpPost]
        public int Post([FromBody] Customer customer)
        {
            // Khởi tạo MySQL connection
            MySqlConnection conn = new MySqlConnection(connection);
            //KHởi tạo MySQL Command tương tác với CSDL
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //Khai báo procedure dùng
            cmd.CommandText = "dbtest.addCustomer";
            // Mở kết nối
            conn.Open();
            // Gán giá trị input
            cmd.Parameters.AddWithValue("customerCode", customer.customerCode);
            cmd.Parameters.AddWithValue("customerName", customer.customerName);
            cmd.Parameters.AddWithValue("city", customer.city);
            cmd.Parameters.AddWithValue("birthday", customer.birthday);
            cmd.Parameters.AddWithValue("mobile", customer.mobile);
            // Thực hiện add
            var result = cmd.ExecuteNonQuery();
            conn.Close();
            return result;

        }
        /*
         * API PUT
         * Sửa 1 đối tượng trên database
         * @params: ID khách hàng cần sửa, đối tượng sửa mới
         * Auth: NTNgoc
         * Created date: 5/6/2020
         * **/
        // PUT: api/Customer/5
        [HttpPut("{customerID}")]
        public int Put( [FromBody] Customer customer)    
        {
            // Khởi tạo đối tượng MySQLConecttion
            MySqlConnection conn = new MySqlConnection(connection);
            // Khởi tạo đối tượng MySQLCommand tương tác với CSDL
            MySqlCommand cmd = conn.CreateCommand();
            //Khai báo Procedure sử dụng
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbtest.editCustomer";
            // Mở kết nối 
            conn.Open();
            // Lấy dữ liệu input
            cmd.Parameters.AddWithValue("customerID", customer.customerID);
            cmd.Parameters.AddWithValue("customerCode", customer.customerCode);
            cmd.Parameters.AddWithValue("customerName", customer.customerName);
            cmd.Parameters.AddWithValue("city", customer.city);
            cmd.Parameters.AddWithValue("birthday", customer.birthday);
            cmd.Parameters.AddWithValue("mobile", customer.mobile);
            //Thực thi Procedure
            var res = cmd.ExecuteNonQuery();
            // Đóng kết nối
            conn.Close();
            return res;

        }
        /*
         * API DELETE
         * Xóa 1 đối tượng khỏi database
         * @param: customerID
         * Auth: NTNgoc
         * Created date: 5/6/2020
         * **/
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public int Delete(Guid id)
        {
            // Khởi tạo đối tượng MySQLConnection
            MySqlConnection conn = new MySqlConnection(connection);
            // Khởi tạo đói tượng MySQLCommand tương tác với CSDL
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            // Khai báo proceudure sử dụng
            cmd.CommandText = "dbtest.deleteCustomer";
            // Mở kết nối
            conn.Open();
            // Gán giá trị ID của khách hàng cần xóa
            cmd.Parameters.AddWithValue("customerID", id);
            // Thực thi xóa
            var result = cmd.ExecuteNonQuery();
            conn.Close();
            return result;
        }
    }
}
