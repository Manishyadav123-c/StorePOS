// CREATE TABLE Users(
//  UserGuid UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
//  UserName NVARCHAR(50) UNIQUE,
//  PasswordHash NVARCHAR(300),
//  IsActive BIT DEFAULT 1,
//  CreatedOn DATETIME DEFAULT GETDATE()
// );

// CREATE TABLE Roles(
//  RoleGuid UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
//  RoleName NVARCHAR(50)
// );

// CREATE TABLE Modules(
//  ModuleGuid UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
//  ModuleName NVARCHAR(50)
// );

// CREATE TABLE UserRoleMapping(
//  MappingGuid UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
//  UserGuid UNIQUEIDENTIFIER,
//  RoleGuid UNIQUEIDENTIFIER
// );

// CREATE TABLE RoleModuleMapping(
//  MappingGuid UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
//  RoleGuid UNIQUEIDENTIFIER,
//  ModuleGuid UNIQUEIDENTIFIER
// );

// CREATE TABLE Sales(
//  SaleGuid UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
//  Amount DECIMAL(10,2),
//  CreatedOn DATETIME DEFAULT GETDATE()
// );
// INSERT INTO Roles VALUES (NEWID(),'Admin'),(NEWID(),'Employee');

// INSERT INTO Modules VALUES
// (NEWID(),'Dashboard'),
// (NEWID(),'Users'),
// (NEWID(),'Roles'),
// (NEWID(),'CreateSale');

// INSERT INTO Users VALUES(NEWID(),'admin','admin123',1,GETDATE());
// -- Author : Manish | Date : 29-12-2025 | Purpose : Login
// ALTER PROCEDURE [dbo].[sp_User_Login]
//     @UserName NVARCHAR(50)
// AS
// BEGIN
//     SET NOCOUNT ON;

//     /*
//       Purpose:
//       - Login user by username
//       - Return UserGuid, UserName, RoleName
//       - Handle users without role mapping safely
//     */

//     SELECT 
//         U.UserGuid,
//         U.UserName,
//         ISNULL(R.RoleName, 'User') AS RoleName
//     FROM Users U
//     LEFT JOIN UserRoleMapping UR 
//         ON U.UserGuid = UR.UserGuid
//     LEFT JOIN Roles R 
//         ON UR.RoleGuid = R.RoleGuid
//     WHERE 
//         U.UserName = @UserName
//         AND U.IsActive = 1;
// END;
// GO
// Search Option With this Name In Chat GPT Chat: - SQL STORED PROCEDURES

// -- Author: Manish | Date: 29-Dec-2025
// CREATE PROC sp_Role_List
// AS
// BEGIN
//  SELECT RoleGuid,RoleName FROM Roles ORDER BY RoleName
// END
// 📌 Role – Insert / UpdateCREATE PROC sp_Role_Save
//  CREATE PROC sp_Role_Save
// @RoleGuid UNIQUEIDENTIFIER,
// @RoleName NVARCHAR(50)
// AS
// BEGIN
//  IF EXISTS(SELECT 1 FROM Roles WHERE RoleGuid=@RoleGuid)
//   UPDATE Roles SET RoleName=@RoleName WHERE RoleGuid=@RoleGuid
//  ELSE
//   INSERT INTO Roles(RoleGuid,RoleName) VALUES(NEWID(),@RoleName)
// END
// 📌 User – List
// CREATE PROC sp_User_List
// AS
// BEGIN
//  SELECT U.UserGuid,U.UserName,R.RoleName
//  FROM Users U
//  JOIN UserRoleMapping UR ON U.UserGuid=UR.UserGuid
//  JOIN Roles R ON UR.RoleGuid=R.RoleGuid
// END
// 📌 User – Insert / Update
// ALTER PROCEDURE [dbo].[sp_User_Save]
//     @UserGuid UNIQUEIDENTIFIER = NULL,
//     @UserName NVARCHAR(50),
//     @PasswordHash NVARCHAR(200),
//     @RoleGuid UNIQUEIDENTIFIER
// AS
// BEGIN
//     SET NOCOUNT ON;

//     IF NOT EXISTS (SELECT 1 FROM Roles WHERE RoleGuid = @RoleGuid)
//     BEGIN
//         RAISERROR ('Invalid role', 16, 1);
//         RETURN;
//     END

//     DECLARE @FinalUserGuid UNIQUEIDENTIFIER;

//     IF @UserGuid IS NOT NULL 
//        AND EXISTS (SELECT 1 FROM Users WHERE UserGuid = @UserGuid)
//     BEGIN
//         UPDATE Users
//         SET UserName = @UserName
//         WHERE UserGuid = @UserGuid;

//         SET @FinalUserGuid = @UserGuid;
//     END
//     ELSE
//     BEGIN
//         SET @FinalUserGuid = NEWID();

//         INSERT INTO Users (UserGuid, UserName, PasswordHash, IsActive)
//         VALUES (@FinalUserGuid, @UserName, @PasswordHash, 1);
//     END

//     IF EXISTS (SELECT 1 FROM UserRoleMapping WHERE UserGuid = @FinalUserGuid)
//         UPDATE UserRoleMapping SET RoleGuid = @RoleGuid WHERE UserGuid = @FinalUserGuid;
//     ELSE
//         INSERT INTO UserRoleMapping (UserGuid, RoleGuid)
//         VALUES (@FinalUserGuid, @RoleGuid);
// END;



