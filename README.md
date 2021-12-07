# IreckonuCSVExport

Run below script to create a table in the database and change connection string from file \ireckonuassessment\CSVExport\Implementation\Database.cs

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AssessTable](
	[Key] [nchar](50) NULL,
	[ArtikelCode] [nchar](10) NULL,
	[ColorCode] [nchar](40) NULL,
	[Description] [nchar](40) NULL,
	[Price] [int] NULL,
	[DiscountPrice] [int] NULL,
	[DeliveredIn] [nchar](50) NULL,
	[Q1] [nchar](10) NULL,
	[Size] [int] NULL,
	[Color] [nchar](10) NULL
) ON [PRIMARY]
GO


