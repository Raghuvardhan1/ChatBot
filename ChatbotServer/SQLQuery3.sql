CREATE TABLE [dbo].[OrdersTbls] (
    [order_id]    INT        NOT NULL,
    [customer_id] INT        NOT NULL,
    [monitor_id]  INT        NULL,
    [timestamp]   DATETIME NULL,
    CONSTRAINT [PK_OrdersTbls] PRIMARY KEY CLUSTERED ([order_id] ASC),
    CONSTRAINT [FK_OrdersTbl_CustomersTbl] FOREIGN KEY ([customer_id]) REFERENCES [dbo].[CustomersTbls] ([id]),
    CONSTRAINT [FK_OrdersTbl_MonitorsTbl] FOREIGN KEY ([monitor_id]) REFERENCES [dbo].[MonitorsTbls] ([monitor_id])
);


GO
CREATE NONCLUSTERED INDEX [IX_FK_OrdersTbl_CustomersTbl]
    ON [dbo].[OrdersTbls]([customer_id] ASC);

GO
CREATE TABLE [dbo].[InterestsTbls] (
    [id]          INT        NOT NULL,
    [customer_id] INT        NOT NULL,
    [monitor_id]  INT        NULL,
    [timestamp]   DATETIME NULL,
    CONSTRAINT [PK_InterestsTbls] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_InterestsTbl_CustomersTbl] FOREIGN KEY ([customer_id]) REFERENCES [dbo].[CustomersTbls] ([id]),
    CONSTRAINT [FK_InterestsTbl_MonitorsTbl] FOREIGN KEY ([monitor_id]) REFERENCES [dbo].[MonitorsTbls] ([monitor_id])
);


GO
CREATE NONCLUSTERED INDEX [IX_FK_InterestsTbls_CustomersTbls]
    ON [dbo].[InterestsTbls]([customer_id] ASC);
