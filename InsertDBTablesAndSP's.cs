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
// CREATE PROC sp_User_Login @UserName NVARCHAR(50)
// AS
// BEGIN
//  SELECT U.UserGuid,U.UserName,R.RoleName
//  FROM Users U
//  JOIN UserRoleMapping UR ON U.UserGuid=UR.UserGuid
//  JOIN Roles R ON UR.RoleGuid=R.RoleGuid
//  WHERE U.UserName=@UserName AND U.IsActive=1
// END
// CREATE PROC sp_GetModulesByUser @UserGuid UNIQUEIDENTIFIER
// AS
// BEGIN
//  SELECT M.ModuleName FROM Modules M
//  JOIN RoleModuleMapping RM ON M.ModuleGuid=RM.ModuleGuid
//  JOIN UserRoleMapping UR ON RM.RoleGuid=UR.RoleGuid
//  WHERE UR.UserGuid=@UserGuid
// END

// Search Option With this Name In Chat GPT Chat: - SQL STORED PROCEDURES

// -- Author: Manish | Date: 29-Dec-2025
// CREATE PROC sp_Role_List
// AS
// BEGIN
//  SELECT RoleGuid,RoleName FROM Roles ORDER BY RoleName
// END
// 📌 Role – Insert / UpdateCREATE PROC sp_Role_Save
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
// CREATE PROC sp_User_Save
// @UserGuid UNIQUEIDENTIFIER=NULL,
// @UserName NVARCHAR(50),
// @PasswordHash NVARCHAR(200),
// @RoleGuid UNIQUEIDENTIFIER
// AS
// BEGIN
//  IF EXISTS(SELECT 1 FROM Users WHERE UserGuid=@UserGuid)
//   UPDATE Users SET UserName=@UserName WHERE UserGuid=@UserGuid
//  ELSE
//  BEGIN
//   DECLARE @NewGuid UNIQUEIDENTIFIER=NEWID()
//   INSERT INTO Users(UserGuid,UserName,PasswordHash)
//   VALUES(@NewGuid,@UserName,@PasswordHash)
//   INSERT INTO UserRoleMapping VALUES(NEWID(),@NewGuid,@RoleGuid)
//  END
// END

