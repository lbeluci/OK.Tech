CREATE TABLE [PriceLists] (
    [Id] uniqueidentifier NOT NULL,
    [Name] VARCHAR(200) NOT NULL,
    [Active] bit NOT NULL,
    CONSTRAINT [PK_PriceLists] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210512230921_PriceList', N'3.1.14');

GO

