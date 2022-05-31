using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using GetInvoice.Models;
using System.Net.Http;

namespace GetInvoice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        //Using Dependency Injection to access config from appsettings.json.

        private readonly IConfiguration _configuration;
        public CustomerController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        //API method to get a list of all customers
        [Route("api/Customer/GetAllCustomers")]
        [HttpGet]

        public JsonResult GetAllCustomers()
        {
            string query = @"
                            select CustomerId,Firstname,Lastname, Email, Phone_number,
                            Country_code, Gender, Balance FROM dbo.Customer";

            DataTable table = new DataTable();
            string connStr = _configuration.GetConnectionString("CustomerAPIDB");
            SqlDataReader reader;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    reader = command.ExecuteReader();
                    table.Load(reader);
                    reader.Close();
                    conn.Close();
                }
            }

            return new JsonResult(table);
        }

        //API method to get customer record by ID
        [HttpGet]

        public JsonResult GetCustomerById()
        {
            string query = @"
                            select CustomerId,Firstname,Lastname, Email, Phone_number,
                            Country_code, Gender, Balance FROM dbo.Customer";

            DataTable table = new DataTable();
            string connStr = _configuration.GetConnectionString("CustomerAPIDB");
            SqlDataReader reader;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    reader = command.ExecuteReader();
                    table.Load(reader);
                    reader.Close();
                    conn.Close();
                }
            }

            return new JsonResult(table);
        }

        //API method to get customer record by ID
        [HttpGet("{id}")]

        public JsonResult GetCustomerById(int id)
        {
            string query = @"
                            select CustomerId,Firstname,Lastname, Email, Phone_number,
                            Country_code, Gender, Balance FROM dbo.Customer where CustomerId = " +id;

            DataTable table = new DataTable();
            string connStr = _configuration.GetConnectionString("CustomerAPIDB");
            SqlDataReader reader;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    reader = command.ExecuteReader();
                    table.Load(reader);
                    reader.Close();
                    conn.Close();
                }
            }

            return new JsonResult(table);
        }

        //API method to create new customer
        [HttpPost]
        public JsonResult CreateCustomer(Customer customer)
        {

            string insertQuery1 = @"insert into dbo.Customer values('"
                                + customer.Salutation + "','" + customer.Initials + "','" + customer.FirstName + "','"
                                + customer.LastName + "','" + customer.Gender + "','" + customer.Email + "','"
                                + customer.Password + "','" + customer.CountryName + "','" + customer.CountryCode + "','"
                                + customer.PrimaryLanguage + "','" + customer.Balance + "','" + customer.PhoneNumber + "','" + customer.Currency + @"')";


            string insertQuery = "insert into dbo.Customer values(@Salutation,@Initials, @Firstname,@firstname_ascii,@Firstname_country_rank," +
                "@Firstname_country_frequency, @Lastname,@Lastname_ascii,@Lastname_country_rank, @Lastname_country_frequency, @Gender," +
                "@Email,@Customer_Password, @Country_code,@Country_code_alpha,@Country_name,@Primary_language,@Primary_language_code,@Balance,@Phone_number,@Currency)";





            string connStr = _configuration.GetConnectionString("CustomerAPIDB");

            using (SqlConnection conn = new SqlConnection(connStr))
            {

                using (SqlCommand command = new SqlCommand(insertQuery, conn))
                {


                    command.Parameters.AddWithValue("@Salutation", customer.Salutation);
                    command.Parameters.AddWithValue("@Initials", customer.Initials);
                    command.Parameters.AddWithValue("@Firstname", customer.FirstName);
                    command.Parameters.AddWithValue("@firstname_ascii", customer.FirstNameAscii);
                    command.Parameters.AddWithValue("@Firstname_country_rank", customer.FirstNameCountryRank);
                    command.Parameters.AddWithValue("@Firstname_country_frequency", customer.FirstNameCountryFrequency);



                    command.Parameters.AddWithValue("@Lastname", customer.LastName);
                    command.Parameters.AddWithValue("@Lastname_ascii", customer.LastNameAscii);
                    command.Parameters.AddWithValue("@Lastname_country_rank", customer.LastNameCountryRank);
                    command.Parameters.AddWithValue("@Lastname_country_frequency", customer.LastNameCountryFrequency);

                    command.Parameters.AddWithValue("@Gender", customer.Gender);
                    command.Parameters.AddWithValue("@Email", customer.Email);
                    command.Parameters.AddWithValue("@Customer_Password", customer.Password);
                    command.Parameters.AddWithValue("@Country_code", customer.CountryCode);

                    command.Parameters.AddWithValue("@Country_code_alpha", customer.CountryCodeAlpha);

                    command.Parameters.AddWithValue("@Country_name", customer.CountryName);
                    command.Parameters.AddWithValue("@Primary_language", customer.PrimaryLanguage);
                    command.Parameters.AddWithValue("@Primary_language_code", customer.PrimaryLanguageCode);
                    command.Parameters.AddWithValue("@Balance", customer.Balance);
                    command.Parameters.AddWithValue("@Phone_number", customer.PhoneNumber);
                    command.Parameters.AddWithValue("@Currency", customer.Currency);



                    conn.Open();
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }

            return new JsonResult("Customer record created successfully.");
        }

        //API method to create new customer
        [HttpPut("{id}")]
        public JsonResult UpdateCustomer(int id,Customer customer)
        {


            string columnAndValues = " Salutation =' " + customer.Salutation + " '," + "Initials =' " + customer.Initials + " '," + " Firstname=' " + customer.FirstName + " '," + "firstname_ascii =' " + customer.FirstNameAscii + " '," + "Firstname_country_rank = ' " + customer.FirstNameCountryRank + " ',"
                + "Firstname_country_frequency=' " + customer.FirstNameCountryFrequency + " '," + "Lastname=' " + customer.LastName + " '," + "Lastname_ascii=' " + customer.LastNameAscii + " '," + "Lastname_country_rank=' " + customer.LastNameCountryRank + " '," + " Lastname_country_frequency=' " + customer.LastNameCountryFrequency + " '," + " Gender=' " + customer.Gender + " ',"
                + "Email=' " + customer.Email + " '," + "Customer_Password=' " + customer.Password + " '," + " Country_code=' " + customer.CountryCode + " ',"
                + "Country_code_alpha=' " + customer.CountryCodeAlpha + " '," + "Country_name=' " + customer.CountryName + " '," + "Primary_language=' " + customer.PrimaryLanguage + " '," + "Primary_language_code=' " + customer.PrimaryLanguageCode + " '," + "Balance=' " + customer.Balance + " ',"
                + "Phone_number=' " + customer.PhoneNumber + " '," + "Currency= '" + customer.Currency + " '";
            ;
            string condition = " where CustomerId =  " + id;

            string updateQuery = "update customer set " + columnAndValues + condition;



            string connStr = _configuration.GetConnectionString("CustomerAPIDB");
            using (SqlConnection conn = new SqlConnection(connStr))
            {

                using (SqlCommand command = new SqlCommand(updateQuery, conn))
                {

                    conn.Open();
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }

            return new JsonResult("Customer record updated successfully.");
        }


        //API method to delete a customer record
        [HttpDelete("{id}")]

        public JsonResult DeleteCustomer(int id)
        {
            string deleteQuery = @"delete FROM dbo.Customer where CustomerId = " + id ;


            string connStr = _configuration.GetConnectionString("CustomerAPIDB");
            using (SqlConnection conn = new SqlConnection(connStr))
            {

                using (SqlCommand command = new SqlCommand(deleteQuery, conn))
                {

                    conn.Open();
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }


            return new JsonResult("Customer Record Deleted successfully");
        }
    }
}