CREATE TABLE [dbo].[Users] (
    [id]           INT            IDENTITY (1, 1) NOT NULL,
    [name]         NVARCHAR (100) NOT NULL,
    [username]     NVARCHAR (50)  NOT NULL,
    [password]     NVARCHAR (255) NOT NULL,
    [account_type] NVARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    UNIQUE NONCLUSTERED ([username] ASC)
);

