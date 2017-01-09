USE [trans_home]
GO

/****** Object:  Table [dbo].[NBlock_Error]    Script Date: 2017/1/9 13:46:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[NBlock_Error](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[BlockCode] [nvarchar](100) NOT NULL CONSTRAINT [DF__NBlock_Er__Block__17036CC0]  DEFAULT (''),
	[Command] [nvarchar](100) NOT NULL CONSTRAINT [DF__NBlock_Er__Comma__17F790F9]  DEFAULT (''),
	[SendTime] [datetime2](7) NOT NULL CONSTRAINT [DF__NBlock_Er__SendT__18EBB532]  DEFAULT (getdate()),
	[Action] [nvarchar](max) NOT NULL CONSTRAINT [DF__NBlock_Er__Actio__19DFD96B]  DEFAULT (''),
	[IsDel] [int] NOT NULL CONSTRAINT [DF__NBlock_Er__IsDel__1AD3FDA4]  DEFAULT ((0)),
	[CreateTime] [datetime2](7) NOT NULL CONSTRAINT [DF__NBlock_Er__Creat__1BC821DD]  DEFAULT (getdate()),
 CONSTRAINT [PK__NBlock_E__3214EC27151B244E] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


