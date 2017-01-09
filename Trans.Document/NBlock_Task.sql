USE [trans_home]
GO

/****** Object:  Table [dbo].[NBlock_Task]    Script Date: 2017/1/9 13:48:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[NBlock_Task](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[BlockCode] [nvarchar](50) NOT NULL DEFAULT (''),
	[FilePath] [nvarchar](1000) NOT NULL DEFAULT (''),
	[Status] [int] NOT NULL DEFAULT ((0)),
	[UploadLog] [nvarchar](1000) NOT NULL DEFAULT (''),
	[CoverStatus] [nvarchar](50) NOT NULL DEFAULT (''),
	[ErrorServer] [nvarchar](200) NOT NULL DEFAULT (''),
	[IsDel] [int] NOT NULL DEFAULT ((0)),
	[CreateTime] [datetime2](7) NOT NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


