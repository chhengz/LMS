using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS
{
    public class Staff
    {
        public int StaffID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; }
        //public Staff() { }
    }


    public static class Staffs
    {
        // ===================== GET ALL STAFF =====================
        public static List<Staff> GetStaff()
        {
            var list = new List<Staff>();
            using (var conn = Connection.GetConn())
            using (var cmd = new SqlCommand("sp_GetStaff", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();

                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        var s = new Staff();
                        s.StaffID = r.GetInt32(r.GetOrdinal("StaffID"));
                        s.FullName = r.GetString(r.GetOrdinal("FullName"));
                        s.Email = r.GetString(r.GetOrdinal("Email"));
                        s.Phone = r.IsDBNull(r.GetOrdinal("Phone")) ? null : r.GetString(r.GetOrdinal("Phone"));
                        s.Username = r.IsDBNull(r.GetOrdinal("Username")) ? null : r.GetString(r.GetOrdinal("Username"));
                        s.Password = r.IsDBNull(r.GetOrdinal("Password")) ? null : r.GetString(r.GetOrdinal("Password"));
                        s.Role = r.IsDBNull(r.GetOrdinal("Role")) ? null : r.GetString(r.GetOrdinal("Role"));
                        s.CreatedAt = r.GetDateTime(r.GetOrdinal("CreatedAt"));
                        list.Add(s);
                    }
                }
            }
            return list;
        }

        // ===================== LOGIN STAFF =====================
        public static async Task<Staff> GetStaffByLoginAsync(string username, string password)
        {
            using (var conn = Connection.GetConn())
            {
                await conn.OpenAsync();
                string query = "SELECT TOP 1 StaffID, FullName, Role, username, password FROM Staff WHERE username = @user AND CAST(password AS VARCHAR(MAX)) = @pass;";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@user", username);
                    cmd.Parameters.AddWithValue("@pass", password);

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new Staff
                            {
                                StaffID = int.Parse(reader["StaffID"].ToString()),
                                Username = reader["Username"].ToString(),
                                Password = reader["Password"].ToString(),
                                FullName = reader["FullName"].ToString(),
                                Role = reader["Role"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }

        // ===================== ADD NEW STAFF =====================
        public static void AddStaff(Staff s)
        {
            using (var conn = Connection.GetConn())
            using (var cmd = new SqlCommand("sp_AddStaff", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FullName", s.FullName);
                cmd.Parameters.AddWithValue("@Email", s.Email);
                cmd.Parameters.AddWithValue("@Phone", (object)s.Phone ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@U", (object)s.Username ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@P", (object)s.Password ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Role", (object)s.Role ?? DBNull.Value);
                conn.Open(); cmd.ExecuteNonQuery(); conn.Close();
            }
        }

        // ===================== UPDATE =====================
        public static void UpdateStaff(Staff s)
        {
            using (var conn = Connection.GetConn())
            using (var cmd = new SqlCommand("sp_UpdateStaff", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StaffID", s.StaffID);
                cmd.Parameters.AddWithValue("@FullName", s.FullName);
                cmd.Parameters.AddWithValue("@Email", s.Email);
                cmd.Parameters.AddWithValue("@Phone", (object)s.Phone ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@U", (object)s.Username ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@P", (object)s.Password ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Role", (object)s.Role ?? DBNull.Value);
                conn.Open(); cmd.ExecuteNonQuery(); conn.Close();
            }
        }

        // ===================== DELETE =====================
        public static void DeleteStaff(int staffId)
        {
            using (var conn = Connection.GetConn())
            using (var cmd = new SqlCommand("sp_DeleteStaff", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StaffID", staffId);
                conn.Open(); cmd.ExecuteNonQuery(); conn.Close();
            }
        }

    }
}
