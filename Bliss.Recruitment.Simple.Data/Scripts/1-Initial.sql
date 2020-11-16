USE Recruitment;
GO

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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201116010155_Initial')
BEGIN
    CREATE TABLE [Questions] (
        [QuestionId] int NOT NULL IDENTITY,
        [Description] nvarchar(max) NULL,
        [ImageUrl] nvarchar(max) NULL,
        [PublishedAt] datetime2 NOT NULL,
        [ThumbUrl] nvarchar(max) NULL,
        CONSTRAINT [PK_Questions] PRIMARY KEY ([QuestionId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201116010155_Initial')
BEGIN
    CREATE TABLE [Choices] (
        [ChoiceId] int NOT NULL IDENTITY,
        [Description] nvarchar(max) NULL,
        [Vote] int NOT NULL,
        [QuestionId] int NOT NULL,
        CONSTRAINT [PK_Choices] PRIMARY KEY ([ChoiceId]),
        CONSTRAINT [FK_Choices_Questions_QuestionId] FOREIGN KEY ([QuestionId]) REFERENCES [Questions] ([QuestionId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201116010155_Initial')
BEGIN
    CREATE INDEX [IX_Choices_QuestionId] ON [Choices] ([QuestionId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201116010155_Initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20201116010155_Initial', N'5.0.0');
END;
GO

COMMIT;
GO

