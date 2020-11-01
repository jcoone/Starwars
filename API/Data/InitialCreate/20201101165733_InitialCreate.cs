using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.InitialCreate
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Crafts",
                columns: table => new
                {
                    url = table.Column<string>(maxLength: 50, nullable: false),
                    name = table.Column<string>(maxLength: 50, nullable: false),
                    model = table.Column<string>(maxLength: 50, nullable: false),
                    manufacturer = table.Column<string>(maxLength: 500, nullable: false),
                    cost_in_credits = table.Column<int>(nullable: false),
                    length = table.Column<short>(nullable: false),
                    max_atmosphering_speed = table.Column<short>(nullable: false),
                    crew = table.Column<string>(maxLength: 50, nullable: false),
                    passengers = table.Column<string>(maxLength: 50, nullable: false),
                    cargo_capacity = table.Column<int>(nullable: false),
                    consumables = table.Column<string>(maxLength: 50, nullable: false),
                    hyperdrive_rating = table.Column<short>(nullable: false),
                    MGLT = table.Column<short>(nullable: false),
                    starship_class = table.Column<string>(maxLength: 50, nullable: false),
                    created = table.Column<DateTime>(type: "datetime", nullable: false),
                    edited = table.Column<DateTime>(type: "datetime", nullable: false),
                    VehicleType = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spaceships", x => x.url);
                });

            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    url = table.Column<string>(maxLength: 50, nullable: false),
                    title = table.Column<string>(maxLength: 200, nullable: false),
                    episode_id = table.Column<short>(nullable: false),
                    opening_crawl = table.Column<string>(maxLength: 1000, nullable: false),
                    director = table.Column<string>(maxLength: 100, nullable: false),
                    producer = table.Column<string>(maxLength: 100, nullable: false),
                    release_date = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    created = table.Column<DateTime>(type: "datetime", nullable: false),
                    edited = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.url);
                });

            migrationBuilder.CreateTable(
                name: "FilmsToSpecies",
                columns: table => new
                {
                    FilmUrl = table.Column<string>(maxLength: 50, nullable: false),
                    SpeciesUrl = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmsToSpecies", x => new { x.FilmUrl, x.SpeciesUrl });
                });

            migrationBuilder.CreateTable(
                name: "FilmToCraft",
                columns: table => new
                {
                    CraftUrl = table.Column<string>(maxLength: 50, nullable: false),
                    FilmUrl = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmToCraft", x => new { x.CraftUrl, x.FilmUrl });
                });

            migrationBuilder.CreateTable(
                name: "Peoples",
                columns: table => new
                {
                    url = table.Column<string>(maxLength: 50, nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false),
                    height = table.Column<short>(nullable: true),
                    mass = table.Column<short>(nullable: true),
                    hair_color = table.Column<string>(maxLength: 50, nullable: true),
                    skin_color = table.Column<string>(maxLength: 100, nullable: true),
                    eye_color = table.Column<string>(maxLength: 200, nullable: true),
                    birth_year = table.Column<string>(maxLength: 50, nullable: true),
                    gender = table.Column<string>(maxLength: 50, nullable: true),
                    homeworld = table.Column<string>(maxLength: 50, nullable: true),
                    created = table.Column<DateTime>(type: "datetime", nullable: false),
                    edited = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peoples", x => x.url);
                });

            migrationBuilder.CreateTable(
                name: "PersonToCraft",
                columns: table => new
                {
                    PersonUrl = table.Column<string>(maxLength: 50, nullable: false),
                    CraftUrl = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonToCraft", x => new { x.PersonUrl, x.CraftUrl });
                });

            migrationBuilder.CreateTable(
                name: "Planets",
                columns: table => new
                {
                    url = table.Column<string>(maxLength: 50, nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false),
                    rotation_period = table.Column<short>(nullable: false),
                    orbital_period = table.Column<short>(nullable: false),
                    diameter = table.Column<int>(nullable: false),
                    gravity = table.Column<string>(maxLength: 50, nullable: false),
                    terrain = table.Column<string>(maxLength: 50, nullable: false),
                    surface_water = table.Column<short>(nullable: false),
                    population = table.Column<string>(maxLength: 50, nullable: true),
                    created = table.Column<DateTime>(type: "datetime", nullable: false),
                    edited = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planets", x => x.url);
                });

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    url = table.Column<string>(maxLength: 50, nullable: false),
                    name = table.Column<string>(maxLength: 50, nullable: false),
                    classification = table.Column<string>(maxLength: 50, nullable: false),
                    designation = table.Column<string>(maxLength: 50, nullable: false),
                    average_height = table.Column<short>(nullable: false),
                    skin_colors = table.Column<string>(maxLength: 100, nullable: true),
                    hair_colors = table.Column<string>(maxLength: 100, nullable: true),
                    eye_colors = table.Column<string>(maxLength: 100, nullable: true),
                    average_lifespan = table.Column<short>(nullable: true),
                    homeworld = table.Column<string>(maxLength: 50, nullable: true),
                    created = table.Column<DateTime>(type: "datetime", nullable: false),
                    edited = table.Column<DateTime>(type: "datetime", nullable: false),
                    language = table.Column<string>(unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.url);
                });

            migrationBuilder.CreateTable(
                name: "SpeciesToPeople",
                columns: table => new
                {
                    SpeciesUrl = table.Column<string>(maxLength: 50, nullable: false),
                    PeopleUrl = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeciesToPeople", x => new { x.SpeciesUrl, x.PeopleUrl });
                });

            migrationBuilder.CreateTable(
                name: "FilmToPeople",
                columns: table => new
                {
                    FilmUrl = table.Column<string>(maxLength: 50, nullable: false),
                    PeopleUrl = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmToPeople", x => new { x.FilmUrl, x.PeopleUrl });
                    table.ForeignKey(
                        name: "FK_FilmToPeople_Films",
                        column: x => x.FilmUrl,
                        principalTable: "Films",
                        principalColumn: "url",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FilmToPeople_Peoples",
                        column: x => x.PeopleUrl,
                        principalTable: "Peoples",
                        principalColumn: "url",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlanetsToFilms",
                columns: table => new
                {
                    PlanetUrl = table.Column<string>(maxLength: 50, nullable: false),
                    FilmsUrl = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanetsToFilms", x => new { x.PlanetUrl, x.FilmsUrl });
                    table.ForeignKey(
                        name: "FK_PlanetsToFilms_Films",
                        column: x => x.FilmsUrl,
                        principalTable: "Films",
                        principalColumn: "url",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlanetsToFilms_Planets",
                        column: x => x.PlanetUrl,
                        principalTable: "Planets",
                        principalColumn: "url",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmToPeople_PeopleUrl",
                table: "FilmToPeople",
                column: "PeopleUrl");

            migrationBuilder.CreateIndex(
                name: "IX_PlanetsToFilms_FilmsUrl",
                table: "PlanetsToFilms",
                column: "FilmsUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Crafts");

            migrationBuilder.DropTable(
                name: "FilmsToSpecies");

            migrationBuilder.DropTable(
                name: "FilmToCraft");

            migrationBuilder.DropTable(
                name: "FilmToPeople");

            migrationBuilder.DropTable(
                name: "PersonToCraft");

            migrationBuilder.DropTable(
                name: "PlanetsToFilms");

            migrationBuilder.DropTable(
                name: "Species");

            migrationBuilder.DropTable(
                name: "SpeciesToPeople");

            migrationBuilder.DropTable(
                name: "Peoples");

            migrationBuilder.DropTable(
                name: "Films");

            migrationBuilder.DropTable(
                name: "Planets");
        }
    }
}
