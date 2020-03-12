IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Autores] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] varchar(200) NOT NULL,
    [Sexo] varchar(100) NULL,
    [Email] varchar(100) NULL,
    [DataNascimento] datetime2 NOT NULL,
    [PaisOrigem] varchar(50) NOT NULL,
    [CPF] varchar(11) NULL,
    CONSTRAINT [PK_Autores] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Obras] (
    [Id] uniqueidentifier NOT NULL,
    [AutorId] uniqueidentifier NOT NULL,
    [Nome] varchar(200) NOT NULL,
    [Descricao] varchar(240) NOT NULL,
    [DataPublicacao] datetime2 NOT NULL,
    [DataExposicao] datetime2 NOT NULL,
    CONSTRAINT [PK_Obras] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Obras_Autores_AutorId] FOREIGN KEY ([AutorId]) REFERENCES [Autores] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Obras_AutorId] ON [Obras] ([AutorId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200305183013_Initial', N'2.2.6-servicing-10079');

GO

