using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forum.Data.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureNoActionDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Topics_TopicId",
                table: "Comments");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "31F51212-AD5F-4830-A984-C52AF4004702",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "64fb391c-7f2d-4012-a39a-291df3ab81dc", "AQAAAAIAAYagAAAAECO0310IkyTAiuVB23Ui0YTINj5yf0jqKWyKMODZ0Hul9VKvAn1qhliS4+zC5R9eBw==", "dad9e798-365b-4637-95bd-5a53c23151a6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "382EE802-2DDC-4C96-917A-A5D6CE99E837",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2314b0e5-e73f-4017-929a-805437220de4", "AQAAAAIAAYagAAAAEJWniS2rNH5XLiyg2QAYJv+4cn0sPzgvPk6TbutSi+IjwMH+pBOjKh/+2zvOM7Pgcg==", "147e41da-d37e-4334-9f5d-17706bbc90dd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4F17ABDF-4A9C-4F0D-9EBC-36B847686A3C",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6631155d-8730-4fcf-aefa-60e4dbf32332", "AQAAAAIAAYagAAAAEHeVmTq9tvbfGFuWQpIsXxySFZRL6k/I3umrWmwLO1fGO930e73wpBtUaFk46LRAjA==", "f7e6c72f-7f29-4d69-b755-93ac43113df1" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 6, 14, 10, 18, 6, 87, DateTimeKind.Local).AddTicks(4516));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 6, 14, 10, 18, 6, 87, DateTimeKind.Local).AddTicks(4519));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 6, 14, 10, 18, 6, 87, DateTimeKind.Local).AddTicks(4521));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2024, 6, 14, 10, 18, 6, 87, DateTimeKind.Local).AddTicks(4522));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2024, 6, 14, 10, 18, 6, 87, DateTimeKind.Local).AddTicks(4533));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2024, 6, 14, 10, 18, 6, 87, DateTimeKind.Local).AddTicks(4535));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreationDate",
                value: new DateTime(2024, 6, 14, 10, 18, 6, 87, DateTimeKind.Local).AddTicks(4536));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreationDate",
                value: new DateTime(2024, 6, 14, 10, 18, 6, 87, DateTimeKind.Local).AddTicks(4538));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreationDate",
                value: new DateTime(2024, 6, 14, 10, 18, 6, 87, DateTimeKind.Local).AddTicks(4540));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 6, 14, 10, 18, 6, 87, DateTimeKind.Local).AddTicks(4292));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 6, 14, 10, 18, 6, 87, DateTimeKind.Local).AddTicks(4296));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 6, 14, 10, 18, 6, 87, DateTimeKind.Local).AddTicks(4298));

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Topics_TopicId",
                table: "Comments",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Topics_TopicId",
                table: "Comments");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "31F51212-AD5F-4830-A984-C52AF4004702",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d2069a30-3f54-42b7-b358-d038c0ae79cc", "AQAAAAIAAYagAAAAEJNy1GsU4zKAVE2UJtIXkWqk6XwYX2cPlsffMc5YPuZbH+l2bfyLeu5ZjtPRI0/U0g==", "c01c5439-11db-4812-853a-a27a3807bbe3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "382EE802-2DDC-4C96-917A-A5D6CE99E837",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ec5ebcbb-c13e-406a-b01e-d149d791541d", "AQAAAAIAAYagAAAAENuiMiPZpR2CsgeFjBGwabAQo2YrO31FMEh7LqleLhXSii4rSCLgwtAYDlfcwiJ98g==", "f422924a-5687-448a-8b04-21f65f9c5590" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4F17ABDF-4A9C-4F0D-9EBC-36B847686A3C",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2dff6c57-ba54-43ef-a043-7bfc17fb6cee", "AQAAAAIAAYagAAAAEHQ6Sa5e19CkMom6I4SiUZGAYRWkhdRJxU2FcbryMmYJBYh/8ImZIbAGkgpgT6lekQ==", "b78bd270-b8a2-4039-9c83-3b14187c4201" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 6, 11, 16, 58, 36, 867, DateTimeKind.Local).AddTicks(1679));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 6, 11, 16, 58, 36, 867, DateTimeKind.Local).AddTicks(1682));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 6, 11, 16, 58, 36, 867, DateTimeKind.Local).AddTicks(1685));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2024, 6, 11, 16, 58, 36, 867, DateTimeKind.Local).AddTicks(1687));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2024, 6, 11, 16, 58, 36, 867, DateTimeKind.Local).AddTicks(1694));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2024, 6, 11, 16, 58, 36, 867, DateTimeKind.Local).AddTicks(1696));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreationDate",
                value: new DateTime(2024, 6, 11, 16, 58, 36, 867, DateTimeKind.Local).AddTicks(1699));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreationDate",
                value: new DateTime(2024, 6, 11, 16, 58, 36, 867, DateTimeKind.Local).AddTicks(1701));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreationDate",
                value: new DateTime(2024, 6, 11, 16, 58, 36, 867, DateTimeKind.Local).AddTicks(1703));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 6, 11, 16, 58, 36, 867, DateTimeKind.Local).AddTicks(1602));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 6, 11, 16, 58, 36, 867, DateTimeKind.Local).AddTicks(1615));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 6, 11, 16, 58, 36, 867, DateTimeKind.Local).AddTicks(1618));

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Topics_TopicId",
                table: "Comments",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
