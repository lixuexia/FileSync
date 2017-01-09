USE [trans_home]
GO

/****** Object:  Table [dbo].[NRoll_Action]    Script Date: 2017/1/9 13:49:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[NRoll_Action](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[RollCode] [nvarchar](50) NOT NULL DEFAULT (''),
	[ServerIP] [nvarchar](30) NOT NULL DEFAULT (''),
	[ServerPort] [int] NOT NULL DEFAULT ((0)),
	[ServerBakUri] [nvarchar](300) NOT NULL DEFAULT (''),
	[ServerAimUri] [nvarchar](300) NOT NULL DEFAULT (''),
	[SiteName] [nvarchar](50) NOT NULL DEFAULT (''),
	[Op] [nvarchar](30) NOT NULL DEFAULT (''),
	[IsUsed] [int] NOT NULL DEFAULT ((0)),
	[AutoRollBack] [int] NOT NULL DEFAULT ((0)),
	[BlockCode] [nvarchar](100) NOT NULL DEFAULT (''),
	[YearVal] [nvarchar](50) NOT NULL DEFAULT (''),
	[MonthVal] [nvarchar](50) NOT NULL DEFAULT (''),
	[DayVal] [nvarchar](50) NOT NULL DEFAULT (''),
	[IsDel] [int] NOT NULL CONSTRAINT [DF__NRoll_Act__IsDel__51300E55]  DEFAULT ((0)),
	[CreateTime] [datetime2](7) NOT NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


