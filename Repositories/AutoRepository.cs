using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using vue_cback_gregslist.Models;
using Dapper;
using MySql.Data.MySqlClient;

namespace vue_cback_gregslist.Repositories
{
    public class AutoRepository
    {
        private readonly IDbConnection _db;

        public AutoRepository(IDbConnection db)
        {
            _db = db;
        }

        // Find One Find Many add update delete
        public IEnumerable<Auto> GetAll()
        {
            return _db.Query<Auto>("SELECT * FROM SharpAutos");
        }

        public Auto GetById(int id)
        {
            return _db.QueryFirstOrDefault<Auto>($"SELECT * FROM SharpAutos WHERE id = {id}", id);
        }

        public Auto Add(Auto auto)
        {
            //INSERT INTO SharpAutos - inserts the arguments to the matching parameters(order is important), then executes a separate SELECT query to get the ID of the last inserted item, and then auto increments to get a new id(provided auto increment is set on the table).
            //the new { Auto.Name.... etc} is the object constructor that will be used in the insert query.
            int id = _db.ExecuteScalar<int>(@"
                        INSERT INTO SharpAutos (Title, Make, Model, Color, AutoDescription, ImageURL, Price)
                        VALUES(@Title, @Make, @Model, @Color, @AutoDescription, @ImageURL, @Price);
                        SELECT LAST_INSERT_ID()", new
            {
                auto.Title,
                auto.Make,
                auto.Model,
                auto.Color,
                auto.AutoDescription,
                auto.ImageURL,
                auto.Price
            });
            auto.Id = id;
            return auto;
        }

        public Auto GetOneByIdAndUpdate(int id, Auto auto)
        {
            //Queries for the first Auto that matches the id passed in. If it doesn't find it, it defaults to handle the error gracefully without crashing. If it finds the id, it updates the fields with the data you are sending.
            return _db.QueryFirstOrDefault<Auto>($@"
                UPDATE SharpAutos SET  
                    Title = @Title,
                    Make = @Make,
                    Model = @Model,
                    Color = @Color,
                    AutoDescription = @AutoDescription,
                    ImageURL = @ImageURL,
                    Price = @Price
                WHERE Id = {id};
                SELECT * FROM SharpAutos WHERE id = {id};", auto);
        }

        public string FindByIdAndRemove(int id)
        {
            var success = _db.Execute($@"
                DELETE FROM SharpAutos WHERE Id = {id}
            ", id);
            return success > 0 ? "success" : "umm that didnt work";
        }
    }
}