IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Marcas] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] varchar(300) NOT NULL,
    CONSTRAINT [PK_Marcas] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Patrimonios] (
    [Id] uniqueidentifier NOT NULL,
    [MarcaId] uniqueidentifier NOT NULL,
    [Nome] varchar(200) NOT NULL,
    [Descricao] varchar(1000) NULL,
    CONSTRAINT [PK_Patrimonios] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Patrimonios_Marcas_MarcaId] FOREIGN KEY ([MarcaId]) REFERENCES [Marcas] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Patrimonios_MarcaId] ON [Patrimonios] ([MarcaId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200824183618_Initial', N'3.1.7');

GO

