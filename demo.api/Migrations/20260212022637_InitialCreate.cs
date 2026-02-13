using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace demo.api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cityMasterTbl",
                columns: table => new
                {
                    cityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cityName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cityMasterTbl", x => x.cityId);
                });

            migrationBuilder.CreateTable(
                name: "countryMaster",
                columns: table => new
                {
                    countryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    countyName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countryMaster", x => x.countryId);
                });

            migrationBuilder.CreateTable(
                name: "districtMaster",
                columns: table => new
                {
                    districtId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    districtName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_districtMaster", x => x.districtId);
                });

            migrationBuilder.CreateTable(
                name: "empBankTbl",
                columns: table => new
                {
                    empBankId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    empId = table.Column<int>(type: "int", nullable: false),
                    bankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    accNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IfscCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empBankTbl", x => x.empBankId);
                });

            migrationBuilder.CreateTable(
                name: "empBasicTbl",
                columns: table => new
                {
                    empId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    empName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    empEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    empMobile = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empBasicTbl", x => x.empId);
                });

            migrationBuilder.CreateTable(
                name: "prodImageTbl",
                columns: table => new
                {
                    prodImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    prodId = table.Column<int>(type: "int", nullable: false),
                    imageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prodImageTbl", x => x.prodImageId);
                });

            migrationBuilder.CreateTable(
                name: "prodTbl",
                columns: table => new
                {
                    prodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    prodName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    shortName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false),
                    category = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prodTbl", x => x.prodId);
                });

            migrationBuilder.CreateTable(
                name: "stateMaster",
                columns: table => new
                {
                    stateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    countryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stateMaster", x => x.stateId);
                });

            migrationBuilder.CreateTable(
                name: "studentMasterTbl",
                columns: table => new
                {
                    studId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mobile = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pancard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    aadharcard = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentMasterTbl", x => x.studId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cityMasterTbl");

            migrationBuilder.DropTable(
                name: "countryMaster");

            migrationBuilder.DropTable(
                name: "districtMaster");

            migrationBuilder.DropTable(
                name: "empBankTbl");

            migrationBuilder.DropTable(
                name: "empBasicTbl");

            migrationBuilder.DropTable(
                name: "prodImageTbl");

            migrationBuilder.DropTable(
                name: "prodTbl");

            migrationBuilder.DropTable(
                name: "stateMaster");

            migrationBuilder.DropTable(
                name: "studentMasterTbl");
        }
    }
}
