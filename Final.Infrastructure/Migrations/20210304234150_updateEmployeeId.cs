using Microsoft.EntityFrameworkCore.Migrations;

namespace Final.Infrastructure.Migrations
{
    public partial class updateEmployeeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interaction_Employee_EmployeeId",
                table: "Interaction");

            migrationBuilder.DropIndex(
                name: "IX_Interaction_ClientId_EmpId",
                table: "Interaction");

            migrationBuilder.DropColumn(
                name: "EmpId",
                table: "Interaction");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Interaction",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Interaction_ClientId_EmployeeId",
                table: "Interaction",
                columns: new[] { "ClientId", "EmployeeId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Interaction_Employee_EmployeeId",
                table: "Interaction",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interaction_Employee_EmployeeId",
                table: "Interaction");

            migrationBuilder.DropIndex(
                name: "IX_Interaction_ClientId_EmployeeId",
                table: "Interaction");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Interaction",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "EmpId",
                table: "Interaction",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Interaction_ClientId_EmpId",
                table: "Interaction",
                columns: new[] { "ClientId", "EmpId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Interaction_Employee_EmployeeId",
                table: "Interaction",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
