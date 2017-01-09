USE [trans_home]
GO

/****** Object:  Table [dbo].[NUser_AuthSite]    Script Date: 2017/1/9 13:50:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[NUser_AuthSite](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL DEFAULT ((0)),
	[SiteName] [nvarchar](50) NOT NULL,
	[AllowList] [int] NOT NULL DEFAULT ((0)),
	[AllowSync] [int] NOT NULL DEFAULT ((0)),
	[AllowRoll] [int] NOT NULL DEFAULT ((0)),
	[IsDel] [int] NOT NULL DEFAULT ((0)),
	[CreateTime] [datetime2](7) NOT NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[UserID] ASC,
	[SiteName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


