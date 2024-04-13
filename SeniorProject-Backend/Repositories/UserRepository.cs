using Microsoft.Data.SqlClient;
using SeniorProject_Backend.Models;
using System.Data;
using System.Data.Common;

namespace SeniorProject_Backend.Repositories
{
    public class UserRepository:IUserRepository
    {
        private string _connectionString;
        private readonly IConfiguration _configuration;

        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = @"Data Source=DESKTOP-BUTN7E4;Initial Catalog=SeniorProjectDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        }

        public User GetUser(string userName,string password)
        {
            User user = new User();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM USERS WHERE user_name=@UserName AND user_password=@Password", con);
                cmd.Parameters.AddWithValue("@UserName", userName);
                cmd.Parameters.AddWithValue("@Password", password);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new User
                        {
                            UserName = reader["user_name"].ToString(),
                            Email = reader["e_mail"].ToString(),
                            CellPhone = reader["cell_phone"].ToString(),
                            UserPassword = reader["user_password"].ToString(),
                            FirstName = reader["first_name"].ToString(),
                            LastName = reader["last_name"].ToString(),
                            Gender = reader["gender"].ToString(),
                            Age = Convert.ToInt32(reader["age"]),
                            Major = reader["major"].ToString(),
                            StudyYear = reader["study_year"].ToString(),
                            City = reader["city"].ToString(),
                            Income = Convert.ToInt32(reader["income"]),
                            HasSickness = reader["has_sickness"].ToString(),
                            IsUsingMedicine = reader["is_using_medicine"].ToString(),
                            ProgressLevel = reader["progress_level"].ToString()
                        };
                    }
                    else
                    {
                        return null; // Kullanıcı bulunamadı
                    }
                }
            }
        }


    }
}
