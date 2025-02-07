using crud_net_core.Model;
using System.Data;
using System.Data.SqlClient;

namespace crud_net_core.DataServices
{
    public class MasterDataServices
    {
        string connection;
        SqlConnection sqlConnection;

        public MasterDataServices()
        {
            connection = "Data Source=SA-TECH;Initial Catalog=net-crud;Integrated Security=True";
            sqlConnection = new SqlConnection(connection);
        }

        public List<Countries> GetCountries()
        {
            List<Countries> countries = new List<Countries>();
            using (SqlCommand cmd = new SqlCommand("select * from Countries", sqlConnection))
            {
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        Countries Country = new Countries
                        {
                            CountryId = Convert.ToInt32(row["CountryId"]),
                            CountryName = Convert.ToString(row["CountryName"]),
                        };
                        countries.Add(Country);
                    }
                }
            }
            return countries;
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
