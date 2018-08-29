CREATE TABLE [dbo].[NBlock_Error](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[BlockCode] [nvarchar](100) NOT NULL DEFAULT (''),
	[Command] [nvarchar](100) NOT NULL DEFAULT (''),
	[SendTime] [datetime2](7) NOT NULL DEFAULT (getdate()),
	[Action] [nvarchar](max) NOT NULL DEFAULT (''),
	[IsDel] [int] NOT NULL DEFAULT ((0)),
	[CreateTime] [datetime2](7) NOT NULL DEFAULT (getdate()),
 CONSTRAINT [PK__NBlock_E] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
