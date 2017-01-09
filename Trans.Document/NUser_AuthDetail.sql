USE [trans_home]
GO

/****** Object:  Table [dbo].[NUser_AuthDetail]    Script Date: 2017/1/9 13:49:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[NUser_AuthDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[DetailName] [nvarchar](200) NOT NULL,
	[AllowList] [int] NOT NULL,
	[AllowSync] [int] NOT NULL,
	[AllowRoll] [int] NOT NULL,
	[SiteName] [nvarchar](50) NOT NULL,
	[IsDir] [int] NOT NULL,
	[IsDel] [int] NOT NULL,
	[CreateTime] [datetime2](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[UserID] ASC,
	[DetailName] ASC,
	[SiteName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[NUser_AuthDetail] ADD  DEFAULT ((0)) FOR [UserID]
GO

ALTER TABLE [dbo].[NUser_AuthDetail] ADD  DEFAULT ('') FOR [DetailName]
GO

ALTER TABLE [dbo].[NUser_AuthDetail] ADD  DEFAULT ((0)) FOR [AllowList]
GO

ALTER TABLE [dbo].[NUser_AuthDetail] ADD  DEFAULT ((0)) FOR [AllowSync]
GO

ALTER TABLE [dbo].[NUser_AuthDetail] ADD  DEFAULT ((0)) FOR [AllowRoll]
GO

ALTER TABLE [dbo].[NUser_AuthDetail] ADD  DEFAULT ('') FOR [SiteName]
GO

ALTER TABLE [dbo].[NUser_AuthDetail] ADD  DEFAULT ((0)) FOR [IsDir]
GO

ALTER TABLE [dbo].[NUser_AuthDetail] ADD  DEFAULT ((0)) FOR [IsDel]
GO

ALTER TABLE [dbo].[NUser_AuthDetail] ADD  DEFAULT (getdate()) FOR [CreateTime]
GO


