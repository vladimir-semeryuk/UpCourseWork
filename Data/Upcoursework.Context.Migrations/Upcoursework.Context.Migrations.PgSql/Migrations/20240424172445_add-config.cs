using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Upcoursework.Context.Migrations.PgSql.Migrations
{
    /// <inheritdoc />
    public partial class addconfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorSkill_Authors_AuthorsId",
                table: "AuthorSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorSkill_Skills_SkillsId",
                table: "AuthorSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorSubject_Authors_AuthorsId",
                table: "AuthorSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorSubject_Subjects_SubjectsId",
                table: "AuthorSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Authors_AuthorId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Buyers_BuyerId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Orders_OrderId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_Authors_AuthorId",
                table: "Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_Buyers_BuyerId",
                table: "Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Authors_AuthorId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Buyers_BuyerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Subjects_SubjectId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderSkill_Orders_OrdersId",
                table: "OrderSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderSkill_Skills_SkillsRequiredId",
                table: "OrderSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skills",
                table: "Skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Buyers",
                table: "Buyers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authors",
                table: "Authors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderSkill",
                table: "OrderSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthorSubject",
                table: "AuthorSubject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthorSkill",
                table: "AuthorSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "Subjects",
                newName: "subjects");

            migrationBuilder.RenameTable(
                name: "Skills",
                newName: "skills");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "orders");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "comments");

            migrationBuilder.RenameTable(
                name: "Buyers",
                newName: "buyers");

            migrationBuilder.RenameTable(
                name: "Authors",
                newName: "authors");

            migrationBuilder.RenameTable(
                name: "OrderSkill",
                newName: "skills_orders");

            migrationBuilder.RenameTable(
                name: "AuthorSubject",
                newName: "subjects_authors");

            migrationBuilder.RenameTable(
                name: "AuthorSkill",
                newName: "skills_authors");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "user_tokens");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "user_role_owners");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "user_logins");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "user_claims");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "user_roles");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "user_role_claims");

            migrationBuilder.RenameIndex(
                name: "IX_Subjects_Uid",
                table: "subjects",
                newName: "IX_subjects_Uid");

            migrationBuilder.RenameIndex(
                name: "IX_Skills_Uid",
                table: "skills",
                newName: "IX_skills_Uid");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_Uid",
                table: "orders",
                newName: "IX_orders_Uid");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_SubjectId",
                table: "orders",
                newName: "IX_orders_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_BuyerId",
                table: "orders",
                newName: "IX_orders_BuyerId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_AuthorId",
                table: "orders",
                newName: "IX_orders_AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_Uid",
                table: "comments",
                newName: "IX_comments_Uid");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_OrderId",
                table: "comments",
                newName: "IX_comments_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_BuyerId",
                table: "comments",
                newName: "IX_comments_BuyerId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_AuthorId",
                table: "comments",
                newName: "IX_comments_AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Buyers_Uid",
                table: "buyers",
                newName: "IX_buyers_Uid");

            migrationBuilder.RenameIndex(
                name: "IX_Authors_Uid",
                table: "authors",
                newName: "IX_authors_Uid");

            migrationBuilder.RenameIndex(
                name: "IX_OrderSkill_SkillsRequiredId",
                table: "skills_orders",
                newName: "IX_skills_orders_SkillsRequiredId");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorSubject_SubjectsId",
                table: "subjects_authors",
                newName: "IX_subjects_authors_SubjectsId");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorSkill_SkillsId",
                table: "skills_authors",
                newName: "IX_skills_authors_SkillsId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "user_role_owners",
                newName: "IX_user_role_owners_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "user_logins",
                newName: "IX_user_logins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "user_claims",
                newName: "IX_user_claims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "user_role_claims",
                newName: "IX_user_role_claims_RoleId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "subjects",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "skills",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "orders",
                type: "character varying(10000)",
                maxLength: 10000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "comments",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "buyers",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "authors",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "authors",
                type: "character varying(5000)",
                maxLength: 5000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_subjects",
                table: "subjects",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_skills",
                table: "skills",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orders",
                table: "orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_comments",
                table: "comments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_buyers",
                table: "buyers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_authors",
                table: "authors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_skills_orders",
                table: "skills_orders",
                columns: new[] { "OrdersId", "SkillsRequiredId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_subjects_authors",
                table: "subjects_authors",
                columns: new[] { "AuthorsId", "SubjectsId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_skills_authors",
                table: "skills_authors",
                columns: new[] { "AuthorsId", "SkillsId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_tokens",
                table: "user_tokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_role_owners",
                table: "user_role_owners",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_logins",
                table: "user_logins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_claims",
                table: "user_claims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_roles",
                table: "user_roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_role_claims",
                table: "user_role_claims",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_comments_authors_AuthorId",
                table: "comments",
                column: "AuthorId",
                principalTable: "authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_comments_buyers_BuyerId",
                table: "comments",
                column: "BuyerId",
                principalTable: "buyers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_comments_orders_OrderId",
                table: "comments",
                column: "OrderId",
                principalTable: "orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_authors_AuthorId",
                table: "Feedback",
                column: "AuthorId",
                principalTable: "authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_buyers_BuyerId",
                table: "Feedback",
                column: "BuyerId",
                principalTable: "buyers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_authors_AuthorId",
                table: "orders",
                column: "AuthorId",
                principalTable: "authors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_buyers_BuyerId",
                table: "orders",
                column: "BuyerId",
                principalTable: "buyers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_subjects_SubjectId",
                table: "orders",
                column: "SubjectId",
                principalTable: "subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_skills_authors_authors_AuthorsId",
                table: "skills_authors",
                column: "AuthorsId",
                principalTable: "authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_skills_authors_skills_SkillsId",
                table: "skills_authors",
                column: "SkillsId",
                principalTable: "skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_skills_orders_orders_OrdersId",
                table: "skills_orders",
                column: "OrdersId",
                principalTable: "orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_skills_orders_skills_SkillsRequiredId",
                table: "skills_orders",
                column: "SkillsRequiredId",
                principalTable: "skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_subjects_authors_authors_AuthorsId",
                table: "subjects_authors",
                column: "AuthorsId",
                principalTable: "authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_subjects_authors_subjects_SubjectsId",
                table: "subjects_authors",
                column: "SubjectsId",
                principalTable: "subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_claims_users_UserId",
                table: "user_claims",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_logins_users_UserId",
                table: "user_logins",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_role_claims_user_roles_RoleId",
                table: "user_role_claims",
                column: "RoleId",
                principalTable: "user_roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_role_owners_user_roles_RoleId",
                table: "user_role_owners",
                column: "RoleId",
                principalTable: "user_roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_role_owners_users_UserId",
                table: "user_role_owners",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_tokens_users_UserId",
                table: "user_tokens",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_authors_AuthorId",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_comments_buyers_BuyerId",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_comments_orders_OrderId",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_authors_AuthorId",
                table: "Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_buyers_BuyerId",
                table: "Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_authors_AuthorId",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_buyers_BuyerId",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_subjects_SubjectId",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_skills_authors_authors_AuthorsId",
                table: "skills_authors");

            migrationBuilder.DropForeignKey(
                name: "FK_skills_authors_skills_SkillsId",
                table: "skills_authors");

            migrationBuilder.DropForeignKey(
                name: "FK_skills_orders_orders_OrdersId",
                table: "skills_orders");

            migrationBuilder.DropForeignKey(
                name: "FK_skills_orders_skills_SkillsRequiredId",
                table: "skills_orders");

            migrationBuilder.DropForeignKey(
                name: "FK_subjects_authors_authors_AuthorsId",
                table: "subjects_authors");

            migrationBuilder.DropForeignKey(
                name: "FK_subjects_authors_subjects_SubjectsId",
                table: "subjects_authors");

            migrationBuilder.DropForeignKey(
                name: "FK_user_claims_users_UserId",
                table: "user_claims");

            migrationBuilder.DropForeignKey(
                name: "FK_user_logins_users_UserId",
                table: "user_logins");

            migrationBuilder.DropForeignKey(
                name: "FK_user_role_claims_user_roles_RoleId",
                table: "user_role_claims");

            migrationBuilder.DropForeignKey(
                name: "FK_user_role_owners_user_roles_RoleId",
                table: "user_role_owners");

            migrationBuilder.DropForeignKey(
                name: "FK_user_role_owners_users_UserId",
                table: "user_role_owners");

            migrationBuilder.DropForeignKey(
                name: "FK_user_tokens_users_UserId",
                table: "user_tokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_subjects",
                table: "subjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_skills",
                table: "skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orders",
                table: "orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_comments",
                table: "comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_buyers",
                table: "buyers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_authors",
                table: "authors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_tokens",
                table: "user_tokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_roles",
                table: "user_roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_role_owners",
                table: "user_role_owners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_role_claims",
                table: "user_role_claims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_logins",
                table: "user_logins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_claims",
                table: "user_claims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_subjects_authors",
                table: "subjects_authors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_skills_orders",
                table: "skills_orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_skills_authors",
                table: "skills_authors");

            migrationBuilder.RenameTable(
                name: "subjects",
                newName: "Subjects");

            migrationBuilder.RenameTable(
                name: "skills",
                newName: "Skills");

            migrationBuilder.RenameTable(
                name: "orders",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "comments",
                newName: "Comments");

            migrationBuilder.RenameTable(
                name: "buyers",
                newName: "Buyers");

            migrationBuilder.RenameTable(
                name: "authors",
                newName: "Authors");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "user_tokens",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "user_roles",
                newName: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "user_role_owners",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "user_role_claims",
                newName: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "user_logins",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "user_claims",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "subjects_authors",
                newName: "AuthorSubject");

            migrationBuilder.RenameTable(
                name: "skills_orders",
                newName: "OrderSkill");

            migrationBuilder.RenameTable(
                name: "skills_authors",
                newName: "AuthorSkill");

            migrationBuilder.RenameIndex(
                name: "IX_subjects_Uid",
                table: "Subjects",
                newName: "IX_Subjects_Uid");

            migrationBuilder.RenameIndex(
                name: "IX_skills_Uid",
                table: "Skills",
                newName: "IX_Skills_Uid");

            migrationBuilder.RenameIndex(
                name: "IX_orders_Uid",
                table: "Orders",
                newName: "IX_Orders_Uid");

            migrationBuilder.RenameIndex(
                name: "IX_orders_SubjectId",
                table: "Orders",
                newName: "IX_Orders_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_orders_BuyerId",
                table: "Orders",
                newName: "IX_Orders_BuyerId");

            migrationBuilder.RenameIndex(
                name: "IX_orders_AuthorId",
                table: "Orders",
                newName: "IX_Orders_AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_comments_Uid",
                table: "Comments",
                newName: "IX_Comments_Uid");

            migrationBuilder.RenameIndex(
                name: "IX_comments_OrderId",
                table: "Comments",
                newName: "IX_Comments_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_comments_BuyerId",
                table: "Comments",
                newName: "IX_Comments_BuyerId");

            migrationBuilder.RenameIndex(
                name: "IX_comments_AuthorId",
                table: "Comments",
                newName: "IX_Comments_AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_buyers_Uid",
                table: "Buyers",
                newName: "IX_Buyers_Uid");

            migrationBuilder.RenameIndex(
                name: "IX_authors_Uid",
                table: "Authors",
                newName: "IX_Authors_Uid");

            migrationBuilder.RenameIndex(
                name: "IX_user_role_owners_RoleId",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_user_role_claims_RoleId",
                table: "AspNetRoleClaims",
                newName: "IX_AspNetRoleClaims_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_user_logins_UserId",
                table: "AspNetUserLogins",
                newName: "IX_AspNetUserLogins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_user_claims_UserId",
                table: "AspNetUserClaims",
                newName: "IX_AspNetUserClaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_subjects_authors_SubjectsId",
                table: "AuthorSubject",
                newName: "IX_AuthorSubject_SubjectsId");

            migrationBuilder.RenameIndex(
                name: "IX_skills_orders_SkillsRequiredId",
                table: "OrderSkill",
                newName: "IX_OrderSkill_SkillsRequiredId");

            migrationBuilder.RenameIndex(
                name: "IX_skills_authors_SkillsId",
                table: "AuthorSkill",
                newName: "IX_AuthorSkill_SkillsId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Subjects",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Skills",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Orders",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(10000)",
                oldMaxLength: 10000);

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Comments",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "Buyers",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "Authors",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Authors",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(5000)",
                oldMaxLength: 5000);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skills",
                table: "Skills",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Buyers",
                table: "Buyers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authors",
                table: "Authors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthorSubject",
                table: "AuthorSubject",
                columns: new[] { "AuthorsId", "SubjectsId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderSkill",
                table: "OrderSkill",
                columns: new[] { "OrdersId", "SkillsRequiredId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthorSkill",
                table: "AuthorSkill",
                columns: new[] { "AuthorsId", "SkillsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorSkill_Authors_AuthorsId",
                table: "AuthorSkill",
                column: "AuthorsId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorSkill_Skills_SkillsId",
                table: "AuthorSkill",
                column: "SkillsId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorSubject_Authors_AuthorsId",
                table: "AuthorSubject",
                column: "AuthorsId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorSubject_Subjects_SubjectsId",
                table: "AuthorSubject",
                column: "SubjectsId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Authors_AuthorId",
                table: "Comments",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Buyers_BuyerId",
                table: "Comments",
                column: "BuyerId",
                principalTable: "Buyers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Orders_OrderId",
                table: "Comments",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_Authors_AuthorId",
                table: "Feedback",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_Buyers_BuyerId",
                table: "Feedback",
                column: "BuyerId",
                principalTable: "Buyers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Authors_AuthorId",
                table: "Orders",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Buyers_BuyerId",
                table: "Orders",
                column: "BuyerId",
                principalTable: "Buyers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Subjects_SubjectId",
                table: "Orders",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderSkill_Orders_OrdersId",
                table: "OrderSkill",
                column: "OrdersId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderSkill_Skills_SkillsRequiredId",
                table: "OrderSkill",
                column: "SkillsRequiredId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
