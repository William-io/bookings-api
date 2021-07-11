using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookings.Migrations
{
    public partial class PopuledDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Categories(Title) Values('Hotels')");
            migrationBuilder.Sql("Insert into Categories(Title) Values('BeachHouse')");
            migrationBuilder.Sql("Insert into Categories(Title) Values('Houses')");
            migrationBuilder.Sql("Insert into Categories(Title) Values('Cars')");

            migrationBuilder.Sql("Insert into Hotels(Name, Rating, Rooms, Price, Gym, Pool, Date, CategoryId) Values('Quay-Bearch', 4, 42, 320.90, true, true, now(), (Select CategoryId from Categories where Title='Hotels'))");
            migrationBuilder.Sql("Insert into Hotels(Name, Rating, Rooms, Price, Gym, Pool, Date, CategoryId) Values('Parque dos Reis', 4, 42, 500.90, true, true, now(), (Select CategoryId from Categories where Title = 'BeachHouse'))");
            migrationBuilder.Sql("Insert into Hotels(Name, Rating, Rooms, Price, Gym, Pool, Date, CategoryId) Values('Monte Gordo', 4, 42, 150.90, true, false, now(), (Select CategoryId from Categories where Title = 'Hotels'))");
            migrationBuilder.Sql("Insert into Cars(Make, CurrentSpeed, Color, Fuel, Price, Date, CategoryId) Values('BMW', 45, 'Silver', 'Diesel', 100.0, now(), (Select CategoryId from Categories where Title = 'Cars'))");
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Categories");
            migrationBuilder.Sql("Delete from Hotels");
        }
    }
}