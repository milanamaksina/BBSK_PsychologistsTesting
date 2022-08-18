using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBSK_PsychologistsTesting.Options
{
    public class DataCleaning
    {
        public void Clean()
        {
            string connectionString = @"Server=80.78.240.16;Database=BBSK_PsychoDb4;User Id=Student;Password=qwe!23;";
            using (SqlConnection connection = new SqlConnection(connectionString)) 
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandText = "delete from dbo.[Order]";
                command.ExecuteNonQuery();
                command.Connection = connection;

                command.CommandText = "delete from dbo.[ApplicationForPsychologistSearch]";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[Client]";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[Comment]";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[Education]";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[Manager]";
                command.ExecuteNonQuery();


                command.CommandText = "delete from dbo.[Problem]";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[ProblemPsychologist]";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[Psychologist]";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[PsychologistTherapyMethod]";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[Shedule]";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[TherapyMethod]";
                command.ExecuteNonQuery();
                connection.Close();

            }

        }        
    }             
}
