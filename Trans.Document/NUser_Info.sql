USE [trans_home]
GO

/****** Object:  Table [dbo].[NUser_Info]    Script Date: 2017/1/9 13:50:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[NUser_Info](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL CONSTRAINT [DF__User_Info__UserN__208CD6FA]  DEFAULT (''),
	[Password] [nvarchar](100) NOT NULL CONSTRAINT [DF__User_Info__Passw__2180FB33]  DEFAULT (''),
	[RefUserId] [int] NOT NULL CONSTRAINT [DF__User_Info__RefUs__22751F6C]  DEFAULT ((0)),
	[Status] [int] NOT NULL CONSTRAINT [DF_NUser_Info_Status]  DEFAULT ((0)),
	[IsDel] [int] NOT NULL CONSTRAINT [DF__User_Info__IsDel__236943A5]  DEFAULT ((0)),
	[CreateTime] [datetime2](7) NOT NULL CONSTRAINT [DF__User_Info__Creat__245D67DE]  DEFAULT (getdate()),
 CONSTRAINT [PK__User_Inf__1788CC4C1EA48E88] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


