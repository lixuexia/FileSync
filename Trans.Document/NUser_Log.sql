USE [trans_home]
GO

/****** Object:  Table [dbo].[NUser_Log]    Script Date: 2017/1/9 13:50:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[NUser_Log](
	[LogId] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL DEFAULT ((0)),
	[Action] [nvarchar](100) NOT NULL DEFAULT (''),
	[Content] [nvarchar](2000) NOT NULL DEFAULT (''),
	[IsDel] [int] NOT NULL DEFAULT ((0)),
	[CreateTime] [datetime2](7) NOT NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[LogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


