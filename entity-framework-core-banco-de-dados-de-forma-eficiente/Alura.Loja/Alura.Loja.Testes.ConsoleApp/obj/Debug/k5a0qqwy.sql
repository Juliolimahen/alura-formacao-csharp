EXEC sp_rename N'Produtos.Preco', N'PrecoUnitario', N'COLUMN';

GO

ALTER TABLE [Produtos] ADD [Unidade] nvarchar(max);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170531184057_Unidade', N'1.1.2');

GO

