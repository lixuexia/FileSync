USE [trans_home]
GO

/****** Object:  Table [dbo].[NBlock_Trace]    Script Date: 2017/1/9 13:48:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[NBlock_Trace](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL CONSTRAINT [DF__NBlock_Tr__Title__0A9D95DB]  DEFAULT (''),
	[Site] [nvarchar](200) NOT NULL CONSTRAINT [DF__NBlock_Tra__Site__0B91BA14]  DEFAULT (''),
	[Description] [nvarchar](max) NOT NULL CONSTRAINT [DF__NBlock_Tr__Descr__0C85DE4D]  DEFAULT (''),
	[BlockCode] [nvarchar](200) NOT NULL CONSTRAINT [DF__NBlock_Tr__Block__0D7A0286]  DEFAULT (''),
	[YearVal] [nvarchar](50) NOT NULL CONSTRAINT [DF__NBlock_Tr__YearV__0E6E26BF]  DEFAULT (''),
	[MonthVal] [nvarchar](50) NOT NULL CONSTRAINT [DF__NBlock_Tr__Month__0F624AF8]  DEFAULT (''),
	[DayVal] [nvarchar](50) NOT NULL CONSTRAINT [DF__NBlock_Tr__DayVa__10566F31]  DEFAULT (''),
	[IsDel] [int] NOT NULL CONSTRAINT [DF__NBlock_Tr__IsDel__114A936A]  DEFAULT ((0)),
	[CreateTime] [datetime2](7) NOT NULL CONSTRAINT [DF__NBlock_Tr__Creat__123EB7A3]  DEFAULT (getdate()),
 CONSTRAINT [PK__NBlock_T__3214EC2708B54D69] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


