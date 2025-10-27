using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Forms.Books
{

    public class Book
    {
        public int BookID { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int? PublishedYear { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public int AvailableQuantity { get; set; }
        public DateTime CreatedAt { get; set; }
    }


    public static class Books
    {
        // ===== Books =====
        public static List<Book> GetBooks()
        {
            var list = new List<Book>();
            try
            {
                using (var conn = Connection.GetConn())
                using (var cmd = new SqlCommand("sp_GetBooks", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            var b = new Book
                            {
                                ISBN = r.GetString(r.GetOrdinal("ISBN")),
                                BookID = r.GetInt32(r.GetOrdinal("BookID")),
                                Title = r.GetString(r.GetOrdinal("Title")),
                                Author = r.IsDBNull(r.GetOrdinal("Author")) ? null : r.GetString(r.GetOrdinal("Author")),
                                Publisher = r.IsDBNull(r.GetOrdinal("Publisher")) ? null : r.GetString(r.GetOrdinal("Publisher")),
                                PublishedYear = r.IsDBNull(r.GetOrdinal("PublishedYear")) ? (int?)null : r.GetInt32(r.GetOrdinal("PublishedYear")),
                                Category = r.IsDBNull(r.GetOrdinal("Category")) ? null : r.GetString(r.GetOrdinal("Category")),
                                Quantity = r.GetInt32(r.GetOrdinal("Quantity")),
                                AvailableQuantity = r.GetInt32(r.GetOrdinal("AvailableQuantity")),
                                CreatedAt = r.GetDateTime(r.GetOrdinal("CreatedAt"))
                            };
                            list.Add(b);
                        }
                    }
                    //conn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching books: {ex.Message}");
                throw;
            }
            return list;
        }


        public static void AddBook(Book b)
        {
            using (var conn = Connection.GetConn())
            using (var cmd = new SqlCommand("sp_AddBook", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ISBN", b.ISBN);
                cmd.Parameters.AddWithValue("@Title", b.Title);
                cmd.Parameters.AddWithValue("@Author", (object)b.Author ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Publisher", (object)b.Publisher ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@PublishedYear", (object)b.PublishedYear ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Category", (object)b.Category ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Quantity", b.Quantity);
                conn.Open(); cmd.ExecuteNonQuery(); 
                //conn.Close();
            }
        }

        public static void UpdateBook(Book b)
        {
            using (var conn = Connection.GetConn())
            using (var cmd = new SqlCommand("sp_UpdateBook", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BookID", b.BookID);
                cmd.Parameters.AddWithValue("@Title", b.Title);
                cmd.Parameters.AddWithValue("@Author", (object)b.Author ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Publisher", (object)b.Publisher ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@PublishedYear", (object)b.PublishedYear ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Category", b.Category);
                cmd.Parameters.AddWithValue("@Quantity", b.Quantity);
                conn.Open(); cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public static void DeleteBook(int bookId)
        {
            using (var conn = Connection.GetConn())
            using (var cmd = new SqlCommand("sp_DeleteBook", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BookID", bookId);
                conn.Open(); cmd.ExecuteNonQuery();
                //conn.Close();
            }
        }
    }
}
