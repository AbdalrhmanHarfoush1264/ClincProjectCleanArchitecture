using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClincProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTablesForPatientsAndApointmentAndOther : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSchedules_ClinicDepartments_ClinicDepartmentId",
                table: "EmployeeSchedules");

            migrationBuilder.RenameColumn(
                name: "ClinicDepartmentId",
                table: "EmployeeSchedules",
                newName: "clinicDepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeSchedules_ClinicDepartmentId",
                table: "EmployeeSchedules",
                newName: "IX_EmployeeSchedules_clinicDepartmentId");

            migrationBuilder.CreateTable(
                name: "AppointmentStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientCases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateOnly>(type: "date", nullable: false),
                    EndTime = table.Column<DateOnly>(type: "date", nullable: true),
                    InProgress = table.Column<bool>(type: "bit", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AmountPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientCases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientCases_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeCreated = table.Column<DateOnly>(type: "date", nullable: false),
                    StartTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    EndTime = table.Column<TimeOnly>(type: "time", nullable: true),
                    PatientCaseId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    AppointmentStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_AppointmentStatuses_AppointmentStatusId",
                        column: x => x.AppointmentStatusId,
                        principalTable: "AppointmentStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_PatientCases_PatientCaseId",
                        column: x => x.PatientCaseId,
                        principalTable: "PatientCases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StatusHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusTime = table.Column<DateOnly>(type: "date", nullable: false),
                    details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppointmentStatusID = table.Column<int>(type: "int", nullable: false),
                    AppointmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatusHistories_AppointmentStatuses_AppointmentStatusID",
                        column: x => x.AppointmentStatusID,
                        principalTable: "AppointmentStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StatusHistories_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_AppointmentStatusId",
                table: "Appointments",
                column: "AppointmentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientCaseId",
                table: "Appointments",
                column: "PatientCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientCases_PatientId",
                table: "PatientCases",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusHistories_AppointmentId",
                table: "StatusHistories",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusHistories_AppointmentStatusID",
                table: "StatusHistories",
                column: "AppointmentStatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSchedules_ClinicDepartments_clinicDepartmentId",
                table: "EmployeeSchedules",
                column: "clinicDepartmentId",
                principalTable: "ClinicDepartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSchedules_ClinicDepartments_clinicDepartmentId",
                table: "EmployeeSchedules");

            migrationBuilder.DropTable(
                name: "StatusHistories");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "AppointmentStatuses");

            migrationBuilder.DropTable(
                name: "PatientCases");

            migrationBuilder.RenameColumn(
                name: "clinicDepartmentId",
                table: "EmployeeSchedules",
                newName: "ClinicDepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeSchedules_clinicDepartmentId",
                table: "EmployeeSchedules",
                newName: "IX_EmployeeSchedules_ClinicDepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSchedules_ClinicDepartments_ClinicDepartmentId",
                table: "EmployeeSchedules",
                column: "ClinicDepartmentId",
                principalTable: "ClinicDepartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
