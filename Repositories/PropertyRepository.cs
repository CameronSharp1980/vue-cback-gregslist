using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using vue_cback_gregslist.Models;
using Dapper;
using MySql.Data.MySqlClient;

namespace vue_cback_gregslist.Repositories
{
    public class PropertyRepository
    {
        private readonly IDbConnection _db;

        public PropertyRepository(IDbConnection db)
        {
            _db = db;
        }

        // Find One Find Many add update delete
        public IEnumerable<Property> GetAll()
        {
            return _db.Query<Property>("SELECT * FROM SharpProperties");
        }

        public Property GetById(int id)
        {
            return _db.QueryFirstOrDefault<Property>($"SELECT * FROM SharpProperties WHERE id = {id}", id);
        }

        public Property Add(Property property)
        {
            //INSERT INTO SharpProperties - inserts the arguments to the matching parameters(order is important), then executes a separate SELECT query to get the ID of the last inserted item, and then auto increments to get a new id(provided auto increment is set on the table).
            //the new { Property.Name.... etc} is the object constructor that will be used in the insert query.
            System.Console.WriteLine("Property in repo: " + property);
            int id = _db.ExecuteScalar<int>(@"
                        INSERT INTO sharpproperties (Title, Zoning, SquareFootage, YearBuilt, Color, ListingDescription, ListingLocation, ImageURL, Price)
                        VALUES(@Title, @Zoning, @SquareFootage, @YearBuilt, @Color, @ListingDescription, @ListingLocation, @ImageURL, @Price);
                        SELECT LAST_INSERT_ID()", new
            {
                property.CreatorId,
                property.Title,
                property.Zoning,
                property.SquareFootage,
                property.YearBuilt,
                property.Color,
                property.ListingDescription,
                property.ListingLocation,
                property.ImageURL,
                property.Price
            });
            property.Id = id;
            return property;

        }

        public Property GetOneByIdAndUpdate(int id, Property property)
        {
            //Queries for the first Property that matches the id passed in. If it doesn't find it, it defaults to handle the error gracefully without crashing. If it finds the id, it updates the fields with the data you are sending.
            return _db.QueryFirstOrDefault<Property>($@"
                UPDATE SharpProperties SET  
                    Title = @Title,
                    Zoning = @Zoning,
                    Squarefootage = @Squarefootage,
                    Color = @Color,
                    PropertyDescription = @PropertyDescription,
                    ImageURL = @ImageURL,
                    Price = @Price
                WHERE Id = {id};
                SELECT * FROM SharpProperties WHERE id = {id};", property);
        }

        public string FindByIdAndRemove(int id)
        {
            var success = _db.Execute($@"
                DELETE FROM SharpProperties WHERE Id = {id}
            ", id);
            return success > 0 ? "success" : "umm that didnt work";
        }
    }
}