using DVDWebApi.Data.DataInterfaces;
using DVDWebApi.Models;
using DVDWebApi.Models.Queries;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DVDWebApi.Data.ADO
{
    public class DvdRepositoryADO : IDvdRepository
    {
        public void Delete(int dvdId)
        {
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdsDelete", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DvdId", dvdId);

                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }


        public Dvd GetById(int dvdId)
        {
            Dvd dvd = null;

            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdsSelect", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DvdId", dvdId);

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        dvd = new Dvd();
                        dvd.DvdId = (int)dr["DvdId"];
                        dvd.Title = dr["Title"].ToString();
                        dvd.ReleaseYear = (int)dr["ReleaseYear"];
                        dvd.Director = dr["Director"].ToString();
                        dvd.Rating = dr["Rating"].ToString();
                        dvd.Notes = dr["Notes"].ToString();
                    }
                }

                return dvd;
            }
        }

        public List<Dvd> GetAll()
        {
            List<Dvd> dvds = new List<Dvd>();

            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdsSelectAll", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();

                //DvdId, Title, ReleaseYear, Director, Rating, Notes
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd row = new Dvd();

                        row.DvdId = (int)dr["DvdId"]; //Convert.ToInt32(); ??
                        row.Title = dr["Title"].ToString();
                        row.ReleaseYear = (int)dr["ReleaseYear"];
                        row.Director = dr["Director"].ToString();
                        row.Rating = dr["Rating"].ToString();
                        row.Notes = dr["Notes"].ToString();

                        dvds.Add(row);
                    }
                }
            }

            return dvds;
        }

        public void Insert(Dvd dvd)
        {
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdsInsert", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@DvdId", SqlDbType.Int);

                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@Title", dvd.Title);
                cmd.Parameters.AddWithValue("@ReleaseYear", dvd.ReleaseYear);
                cmd.Parameters.AddWithValue("@Director", dvd.Director);
                cmd.Parameters.AddWithValue("@Rating", dvd.Rating);
                cmd.Parameters.AddWithValue("@Notes", dvd.Notes);

                conn.Open();

                cmd.ExecuteNonQuery();

                dvd.DvdId = (int)param.Value;
            }
        }

        public IEnumerable<Dvd> Search(ListingSearchParameters parameters)
        {
            List<Dvd> dvds = new List<Dvd>();

            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                string query = "SELECT TOP 12 DvdId, Title, ReleaseYear, Director, Rating, Notes FROM " +
                    "Dvds WHERE 1 = 1";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                if (!string.IsNullOrEmpty(parameters.Title))
                {
                    query += "AND Title LIKE @Title ";
                    cmd.Parameters.AddWithValue("@Title", parameters.Title + '%');
                }

                if (parameters.ReleaseYear.HasValue)
                {
                    query += "AND ReleaseYear = @ReleaseYear";
                    cmd.Parameters.AddWithValue("@ReleaseYear", parameters.ReleaseYear.Value);
                }

                if (!string.IsNullOrEmpty(parameters.Director))
                {
                    query += "AND Director LIKE @Director ";
                    cmd.Parameters.AddWithValue("@Director", parameters.Director + '%');
                }

                if (!string.IsNullOrEmpty(parameters.Rating))
                {
                    query += "AND Rating LIKE @Rating ";
                    cmd.Parameters.AddWithValue("@Rating", parameters.Rating + '%');
                }

                query += "ORDER BY Title DESC";
                cmd.CommandText = query;

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd row = new Dvd();

                        row.DvdId = (int)dr["DvdId"];
                        row.Title = dr["Title"].ToString();
                        row.ReleaseYear = (int)dr["ReleaseYear"];
                        row.Director = dr["Director"].ToString();
                        row.Rating = dr["Rating"].ToString();

                        dvds.Add(row);
                    }
                }
            }

            return dvds;
        }

        public void Update(Dvd dvd)
        {
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdsUpdate", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DvdId", dvd.DvdId);
                cmd.Parameters.AddWithValue("@Title", dvd.Title);
                cmd.Parameters.AddWithValue("@ReleaseYear", dvd.ReleaseYear);
                cmd.Parameters.AddWithValue("@Director", dvd.Director);
                cmd.Parameters.AddWithValue("@Rating", dvd.Rating);
                cmd.Parameters.AddWithValue("@Notes", dvd.Notes);

                conn.Open();

                cmd.ExecuteNonQuery();
            }


        }
    }
}
