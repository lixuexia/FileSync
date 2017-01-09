USE [trans_home]
GO

/****** Object:  Table [dbo].[NBlock_Info]    Script Date: 2017/1/9 13:47:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[NBlock_Info](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BlockCode] [nvarchar](200) NOT NULL DEFAULT (''),
	[Status] [int] NOT NULL DEFAULT ((0)),
	[StartTime] [datetime2](7) NOT NULL DEFAULT (getdate()),
	[UploadSuccess] [datetime2](7) NOT NULL DEFAULT ('1900-01-01'),
	[BackupSuccess] [datetime2](7) NOT NULL DEFAULT ('1900-01-01'),
	[CoverSuccess] [datetime2](7) NOT NULL DEFAULT ('1900-01-01'),
	[CancelTime] [datetime2](7) NOT NULL DEFAULT ('1900-01-01'),
	[ErrorFinishTime] [datetime2](7) NOT NULL DEFAULT ('1900-01-01'),
	[CoverStatus] [nvarchar](200) NOT NULL DEFAULT (''),
	[UploadLog] [nvarchar](max) NOT NULL DEFAULT (''),
	[ActionMark] [nvarchar](100) NOT NULL DEFAULT (''),
	[IsDel] [int] NOT NULL CONSTRAINT [DF_NBlock_Info_IsDel]  DEFAULT ((0)),
	[CreateTime] [datetime2](7) NOT NULL CONSTRAINT [DF_NBlock_Info_CreateTime]  DEFAULT (getdate()),
 CONSTRAINT [PK_NBlock_Info] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


