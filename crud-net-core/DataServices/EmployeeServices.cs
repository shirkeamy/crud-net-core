using crud_net_core.Model;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Runtime.Intrinsics.Arm;

namespace crud_net_core.DataServices
{
    public class EmployeeServices
    {
        string connection;
        SqlConnection sqlConnection;

        public EmployeeServices()
        {
            connection = "Data Source=SA-TECH;Initial Catalog=net-crud;Integrated Security=True";
            sqlConnection = new SqlConnection(connection);
        }

        public List<Employees> GetEmployees()
        {
            List<Employees> employeeList = new List<Employees>();
            using (SqlCommand cmd = new SqlCommand("select * from Employees", sqlConnection))
            {
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        Employees employee = new Employees
                        {
                            EmployeeId = Convert.ToInt32(row["EmployeeId"]),
                            FirstName = Convert.ToString(row["FirstName"]),
                            MiddleName = Convert.ToString(row["MiddleName"]),
                            LastName = Convert.ToString(row["LastName"]),
                            DateOfBirth = Convert.ToDateTime(row["DateOfBirth"]),
                            IsActive = Convert.ToBoolean(row["IsActive"]),
                            EmailId = Convert.ToString(row["EmailId"]),
                            CountryId = Convert.ToInt32(row["CountryId"]),
                            StateId = Convert.ToInt32(row["StateId"]),
                            CityId = Convert.ToInt32(row["CityId"]),
                            Address = Convert.ToString(row["Address"])
                        };
                        employeeList.Add(employee);
                    }
                }
            }
            return employeeList;
        }

        public Employees GetEmployee(int EmployeeId)
        {
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Employees WHERE EmployeeId = " + EmployeeId, sqlConnection))
            {
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    Employees employee = new Employees();
                    if (dt.Rows.Count > 0)
                    {
                        employee = new Employees
                        {
                            EmployeeId = Convert.ToInt32(dt.Rows[0]["EmployeeId"]),
                            FirstName = Convert.ToString(dt.Rows[0]["FirstName"]),
                            MiddleName = Convert.ToString(dt.Rows[0]["MiddleName"]),
                            LastName = Convert.ToString(dt.Rows[0]["LastName"]),
                            DateOfBirth = Convert.ToDateTime(dt.Rows[0]["DateOfBirth"]),
                            IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"]),
                            EmailId = Convert.ToString(dt.Rows[0]["EmailId"]),
                            CountryId = Convert.ToInt32(dt.Rows[0]["CountryId"]),
                            StateId = Convert.ToInt32(dt.Rows[0]["StateId"]),
                            CityId = Convert.ToInt32(dt.Rows[0]["CityId"]),
                            Address = Convert.ToString(dt.Rows[0]["Address"])
                        };

                    }
                    return employee;
                }
            }
        }

        public int InsertEmployee(Employee employees)
        {
            int res = 0;
            using (SqlCommand cmd = new SqlCommand(
                @"INSERT INTO Employees
                    ([FirstName], [MiddleName], [LastName], [DateOfBirth], [IsActive],
                     [EmailId], [CountryId], [StateId], [CityId], [Address])
                     VALUES
                     ('" + employees.FirstName + "','" + employees.MiddleName + "', '" + employees.LastName + "','" + employees.DateOfBirth + "'," + (employees.IsActive ? 1 : 0) + ",'" + employees.EmailId + "'," + employees.CountryId + "," + employees.StateId + "," + employees.CityId + ",'" + employees.Address + "')", sqlConnection))
            {
                cmd.CommandType = CommandType.Text;
                sqlConnection.Open();
                res = cmd.ExecuteNonQuery();
                sqlConnection.Close();
            }
            return res;
        }

        public int UpdateEmployee(int employeeId, Employee employees)
        {
            int res = 0;
            using (SqlCommand cmd = new SqlCommand(
                        @"UPDATE Employees SET" +
                         "[FirstName]='" + employees.FirstName + "'," +
                         "[MiddleName]='" + employees.MiddleName + "'," +
                         "[LastName]='" + employees.LastName + "'," +
                         "[DateOfBirth]='" + employees.DateOfBirth + "'," +
                         "[IsActive]=" + (employees.IsActive ? 1 : 0) + "," +
                         "[EmailId]='" + employees.EmailId + "'," +
                         "[CountryId]=" + employees.CountryId + "," +
                         "[StateId]=" + employees.StateId + "," +
                         "[CityId]=" + employees.CityId + "," +
                         "[Address]='" + employees.Address + "'" +
                         "WHERE EmployeeId = " + employeeId
                , sqlConnection))
            {
                cmd.CommandType = CommandType.Text;
                sqlConnection.Open();
                res = cmd.ExecuteNonQuery();
                sqlConnection.Close();
            }
            return res;
        }
        
        public int DeleteEmployee(int employeeId)
        {
            int res = 0;
            using (SqlCommand cmd = new SqlCommand(
                        @"DELETE FROM Employees WHERE EmployeeId = " + employeeId
                , sqlConnection))
            {
                cmd.CommandType = CommandType.Text;
                sqlConnection.Open();
                res = cmd.ExecuteNonQuery();
                sqlConnection.Close();
            }
            return res;
        }
    }
}
