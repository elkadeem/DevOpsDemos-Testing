IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220322104556_InitaialMigration')
BEGIN
    CREATE TABLE [Customers] (
        [ID] int NOT NULL IDENTITY,
        [Name] nvarchar(100) NOT NULL,
        [Email] nvarchar(100) NOT NULL,
        [Phone] nvarchar(15) NOT NULL,
        [Department] nvarchar(max) NOT NULL,
        [ManagerId] int NOT NULL,
        CONSTRAINT [PK_Customers] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220322104556_InitaialMigration')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Department', N'Email', N'ManagerId', N'Name', N'Phone') AND [object_id] = OBJECT_ID(N'[Customers]'))
        SET IDENTITY_INSERT [Customers] ON;
    EXEC(N'INSERT INTO [Customers] ([ID], [Department], [Email], [ManagerId], [Name], [Phone])
    VALUES (1, N''Department'', N''elkadim@email.com'', 0, N''Wael Elkadim'', N''01324213'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Department', N'Email', N'ManagerId', N'Name', N'Phone') AND [object_id] = OBJECT_ID(N'[Customers]'))
        SET IDENTITY_INSERT [Customers] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220322104556_InitaialMigration')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Department', N'Email', N'ManagerId', N'Name', N'Phone') AND [object_id] = OBJECT_ID(N'[Customers]'))
        SET IDENTITY_INSERT [Customers] ON;
    EXEC(N'INSERT INTO [Customers] ([ID], [Department], [Email], [ManagerId], [Name], [Phone])
    VALUES (2, N''Department'', N''amohamed@email.com'', 0, N''Ahmed Mohamed'', N''01322213'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Department', N'Email', N'ManagerId', N'Name', N'Phone') AND [object_id] = OBJECT_ID(N'[Customers]'))
        SET IDENTITY_INSERT [Customers] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220322104556_InitaialMigration')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Department', N'Email', N'ManagerId', N'Name', N'Phone') AND [object_id] = OBJECT_ID(N'[Customers]'))
        SET IDENTITY_INSERT [Customers] ON;
    EXEC(N'INSERT INTO [Customers] ([ID], [Department], [Email], [ManagerId], [Name], [Phone])
    VALUES (3, N''Department'', N''alimohamed@email.com'', 0, N''Ali Mohamed'', N''01324223'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Department', N'Email', N'ManagerId', N'Name', N'Phone') AND [object_id] = OBJECT_ID(N'[Customers]'))
        SET IDENTITY_INSERT [Customers] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220322104556_InitaialMigration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220322104556_InitaialMigration', N'6.0.3');
END;
GO

COMMIT;
GO

