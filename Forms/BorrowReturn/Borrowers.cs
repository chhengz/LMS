using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Forms.BorrowReturn
{
    public class BorrowReturn
    {
        public int TransactionID { get; set; }
        public int BookID { get; set; }
        public string BorrowerName { get; set; }
        public string BorrowerContact { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string Status { get; set; }
        public int StaffID { get; set; }

        public string BookTitle { get; set; }   // Added for display
        public string StaffName { get; set; }   // Added for display
    }


    public static class Borrowers
    {
        // ===================== GET ALL BORROWERS =====================
        public static List<BorrowReturn> GetBorrowRecords()
        {
            var list = new List<BorrowReturn>();
            using (var conn = Connection.GetConn())
            using (var cmd = new SqlCommand("sp_GetBorrowRecords", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();

                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        var s = new BorrowReturn
                        {
                            TransactionID = r.GetInt32(r.GetOrdinal("TransactionID")),
                            BookTitle = r.GetString(r.GetOrdinal("BookTitle")),
                            BorrowerName = r.GetString(r.GetOrdinal("BorrowerName")),
                            BorrowDate = r.GetDateTime(r.GetOrdinal("BorrowDate")),
                            DueDate = r.GetDateTime(r.GetOrdinal("DueDate")),
                            ReturnDate = r.IsDBNull(r.GetOrdinal("ReturnDate")) ? (DateTime?)null : r.GetDateTime(r.GetOrdinal("ReturnDate")),
                            Status = r.GetString(r.GetOrdinal("Status")),
                            StaffName = r.GetString(r.GetOrdinal("StaffName"))
                        };
                        list.Add(s);
                    }
                }
                conn.Close();
            }
            return list;
        }


        // ===================== BORROW BOOK =====================
        public static void BorrowBook(int bookId, string borrowerName, string borrowerContact, DateTime dueDate, int staffId)
        {
            using (var conn = Connection.GetConn())
            using (var cmd = new SqlCommand("sp_BorrowBook", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BookID", bookId);
                cmd.Parameters.AddWithValue("@BorrowerName", borrowerName);
                cmd.Parameters.AddWithValue("@BorrowerContact", (object)borrowerContact ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DueDate", dueDate);
                cmd.Parameters.AddWithValue("@StaffID", staffId);
                conn.Open(); cmd.ExecuteNonQuery(); conn.Close();
            }
        }

        // ===================== RETURN BOOK =====================
        public static void ReturnBook(int transactionId)
        {
            using (var conn = Connection.GetConn())
            using (var cmd = new SqlCommand("sp_ReturnBook", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TransactionID", transactionId);
                conn.Open(); cmd.ExecuteNonQuery(); conn.Close();
            }
        }

        // ===================== REMOVE =====================
        public static void RemoveBorrowRecord(int transactionId)
        {
            using (var conn = Connection.GetConn())
            using (var cmd = new SqlCommand("sp_RemoveBorrowRecord", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TransactionID", transactionId);
                conn.Open(); cmd.ExecuteNonQuery(); conn.Close();
            }
        }
    }
}
