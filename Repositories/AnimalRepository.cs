using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using vue_cback_gregslist.Models;
using Dapper;
using MySql.Data.MySqlClient;

namespace vue_cback_gregslist.Repositories
{
    public class AnimalRepository
    {
        private readonly IDbConnection _db;

        public AnimalRepository(IDbConnection db)
        {
            _db = db;
        }

        // Find One Find Many add update delete
        public IEnumerable<Animal> GetAll()
        {
            return _db.Query<Animal>("SELECT * FROM sharpanimals");
        }

        public Animal GetById(int id)
        {
            return _db.QueryFirstOrDefault<Animal>($"SELECT * FROM sharpanimals WHERE id = {id}", id);
        }

        public Animal Add(Animal animal)
        {
            //INSERT INTO sharpanimals - inserts the arguments to the matching parameters(order is important), then executes a separate SELECT query to get the ID of the last inserted item, and then auto increments to get a new id(provided auto increment is set on the table).
            //the new { animal.Name.... etc} is the object constructor that will be used in the insert query.
            int id = _db.ExecuteScalar<int>($@"INSERT INTO sharpanimals (Title, AnimalName, Species, Breed, Age, Color, ListingDescription, ListingLocation, MedicalConcerns, ImageURL, Price)
                                            VALUES(@Title, @AnimalName, @Species, @Breed, @Age, @Color, @ListingDescription, @ListingLocation, @MedicalConcerns, @ImageURL, @Price);
                                            SELECT LAST_INSERT_ID()", new
            {
                animal.Title,
                animal.AnimalName,
                animal.Species,
                animal.Breed,
                animal.Age,
                animal.Color,
                animal.ListingDescription,
                animal.ListingLocation,
                animal.MedicalConcerns,
                animal.ImageURL,
                animal.Price
            });
            animal.Id = id;
            return animal;

        }

        public Animal GetOneByIdAndUpdate(int id, Animal animal)
        {
            //Queries for the first Animal that matches the id passed in. If it doesn't find it, it defaults to handle the error gracefully without crashing. If it finds the id, it updates the fields with the data you are sending.
            return _db.QueryFirstOrDefault<Animal>($@"
                UPDATE SharpAnimals SET  
                    CreatorId = @CreatorId,
                    Title = @Title,
                    AnimalName = @AnimalName,
                    Species = @Species,
                    Breed = @Breed,
                    Age = @Age,
                    Color = @Color,
                    ListingDescription = @ListingDescription,
                    ListingLocation = @ListingLocation,
                    MedicalConcerns = @MedicalConcerns,
                    ImageURL = @ImageURL,
                    Price = @Price
                WHERE Id = {id};
                SELECT * FROM SharpAnimals WHERE id = {id};", animal);
        }

        public string FindByIdAndRemove(int id)
        {
            var success = _db.Execute($@"
                DELETE FROM sharpanimals WHERE Id = {id}
            ", id);
            return success > 0 ? "success" : "umm that didnt work";
        }
    }
}