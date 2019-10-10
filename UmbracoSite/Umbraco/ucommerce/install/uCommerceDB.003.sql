BEGIN TRAN

ALTER TABLE [dbo].[uCommerce_OrderNumberSerie] ADD [Deleted] BIT NOT NULL DEFAULT ((0))
ALTER TABLE [dbo].[uCommerce_Currency] ADD [Deleted] BIT NOT NULL DEFAULT ((0))
ALTER TABLE [dbo].[uCommerce_Country] ADD [Deleted] BIT NOT NULL DEFAULT ((0))
ALTER TABLE [dbo].[uCommerce_PurchaseOrder] ADD OrderGuid UNIQUEIDENTIFIER NOT NULL DEFAULT ((NEWID()))

COMMIT TRAN