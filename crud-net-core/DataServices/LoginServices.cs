using crud_net_core.Model;
using System.Data;
using System.Data.SqlClient;

namespace crud_net_core.DataServices
{
    public class LoginServices
    {
        string connection;
        SqlConnection sqlConnection;

        public LoginServices()
        {
            connection = "Data Source=SA-TECH;Initial Catalog=net_crud;Integrated Security=True";
            sqlConnection = new SqlConnection(connection);
        }

        public LoginMaster GetLoginDetails(LoginBody loginBody)
        {
            LoginMaster loginDetails = new LoginMaster();
            using (SqlCommand cmd = new SqlCommand(
                "select * from LoginMaster where UserName = '" + loginBody.EmailId + "' and UserPassword = '" + loginBody.Password + "'",
                sqlConnection))
            {
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        loginDetails = new LoginMaster
                        {
                            LoginId = Convert.ToInt32(dt.Rows[0]["LoginId"]),
                            UserName = Convert.ToString(dt.Rows[0]["UserName"]),
                            UserPassword = Convert.ToString(dt.Rows[0]["UserPassword"]),
                            CreatedDate = Convert.ToString(dt.Rows[0]["CreatedDate"]),
                            CreatedBy = Convert.ToString(dt.Rows[0]["CreatedBy"]),
                        };
                    }

                }
            }
            return loginDetails;
        }

        public List<States> GetStates()
        {
            List<States> states = new List<States>();
            using (SqlCommand cmd = new SqlCommand("select * from States", sqlConnection))
            {
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        States state = new States
                        {
                            StateId = Convert.ToInt32(row["StateId"]),
                            StateName = Convert.ToString(row["StateName"]),
                        };
                        states.Add(state);
                    }
                }
            }
            return states;
        }

        public List<Cities> GetCities()
        {
            List<Cities> cities = new List<Cities>();
            using (SqlCommand cmd = new SqlCommand("select * from Cities", sqlConnection))
            {
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        Cities city = new Cities
                        {
                            CityId = Convert.ToInt32(row["CityId"]),
                            CityName = Convert.ToString(row["CityName"]),
                        };
                        cities.Add(city);
                    }
                }
            }
            return cities;
        }

    }
}
