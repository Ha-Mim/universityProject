using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBookApp.DAL.DAO;

namespace PhoneBookApp.DAL.DLL
{
    class PhoneBookDbGateway
    {
        public string ConnectionString = ConfigurationManager.ConnectionStrings["connectionStringForContactDb"].ConnectionString;
        public SqlConnection ASqlConnection { set; get; }
        public SqlCommand ASqlCommand =new SqlCommand();

        public PhoneBookDbGateway()
        {
            ASqlConnection = new SqlConnection(ConnectionString);
        }

        public void Save(PhoneBook aBook)
        {
            string query = "INSERT INTO tbl_phone_book VALUES('" + aBook.Name + "' , '" + aBook.MobileNo + "','"+aBook.Details+"')";
            ASqlConnection.Open();
            ASqlCommand = new SqlCommand(query, ASqlConnection);
            ASqlCommand.ExecuteNonQuery();
            ASqlConnection.Close();
        }
        public PhoneBook Find(string mobileNo)
        {

            string query = "SELECT *FROM tbl_phone_book WHERE mobileNo='" + mobileNo + "'";
            ASqlConnection.Open();
            ASqlCommand = new SqlCommand(query, ASqlConnection);
            SqlDataReader aSqlDataReader = ASqlCommand.ExecuteReader();

            if (aSqlDataReader.HasRows)
            {
                aSqlDataReader.Read();
                PhoneBook aBook = new PhoneBook();

                aBook.MobileNo = aSqlDataReader["mobileNo"].ToString();

                aSqlDataReader.Close();
                ASqlConnection.Close();

                return aBook;
            }
            else
            {
                aSqlDataReader.Close();
                ASqlConnection.Close();
                return null;
            }

        }
        public List<PhoneBook> GetAll()
        {
            string query = "SELECT *FROM tbl_phone_book";
            ASqlConnection.Open();
            ASqlCommand = new SqlCommand(query, ASqlConnection);
            SqlDataReader aSqlDataReader = ASqlCommand.ExecuteReader();

            List<PhoneBook> books = new List<PhoneBook>();

            while (aSqlDataReader.Read())
            {

                PhoneBook aBook = new PhoneBook();
                aBook.Id = (int)aSqlDataReader["id"];
                aBook.Name = aSqlDataReader["name"].ToString();
                aBook.MobileNo = aSqlDataReader["mobileNo"].ToString();
                aBook.Details = aSqlDataReader["details"].ToString();
                books.Add(aBook);
            }
            aSqlDataReader.Close();
            ASqlConnection.Close();

            return books;
        }
    }
}
