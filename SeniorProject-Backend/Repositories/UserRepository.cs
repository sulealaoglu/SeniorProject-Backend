using Microsoft.Data.SqlClient;
using SeniorProject_Backend.Models;

namespace SeniorProject_Backend.Repositories
{
    public class UserRepository:IUserRepository
    {
        private string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            //_connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=SeniorProject-DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
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
                            ProgressLevel = Convert.ToInt32(reader["progress_level"])
                        };
                    }
                    else
                    {
                        return null; // Kullanıcı bulunamadı
                    }
                }
            }
        }
        public bool Register(User user)
        {
            string query = @"INSERT INTO [dbo].[users]
                        ([user_name]
                        ,[e_mail]
                        ,[cell_phone]
                        ,[user_password]
                        ,[first_name]
                        ,[last_name]
                        ,[gender]
                        ,[age]
                        ,[major]
                        ,[study_year]
                        ,[city]
                        ,[income]
                        ,[has_sickness]
                        ,[is_using_medicine]
                        ,[progress_level])
                    VALUES
                        (@UserName
                        ,@Email
                        ,@CellPhone
                        ,@UserPassword
                        ,@FirstName
                        ,@LastName
                        ,@Gender
                        ,@Age
                        ,@Major
                        ,@StudyYear
                        ,@City
                        ,@Income
                        ,@HasSickness
                        ,@IsUsingMedicine
                        ,@ProgressLevel)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserName", user.UserName);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@CellPhone", user.CellPhone);
                command.Parameters.AddWithValue("@UserPassword", user.UserPassword);
                command.Parameters.AddWithValue("@FirstName", user.FirstName);
                command.Parameters.AddWithValue("@LastName", user.LastName);
                command.Parameters.AddWithValue("@Gender", user.Gender);
                command.Parameters.AddWithValue("@Age", user.Age);
                command.Parameters.AddWithValue("@Major", user.Major);
                command.Parameters.AddWithValue("@StudyYear", user.StudyYear);
                command.Parameters.AddWithValue("@City", user.City);
                command.Parameters.AddWithValue("@Income", user.Income);
                command.Parameters.AddWithValue("@HasSickness", user.HasSickness);
                command.Parameters.AddWithValue("@IsUsingMedicine", user.IsUsingMedicine);
                command.Parameters.AddWithValue("@ProgressLevel", user.ProgressLevel);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool UserExist(string userName)
        {
            string query = "SELECT COUNT(*) FROM [dbo].[users] WHERE [user_name] = @UserName";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserName", userName);
                connection.Open();

                int count = (int)command.ExecuteScalar();
                return count > 0;
            }

        }
    }
}
