﻿CREATE TABLE [Quartz].[SIMPROP_TRIGGERS] (
    [SCHED_NAME]    NVARCHAR (120)  NOT NULL,
    [TRIGGER_NAME]  NVARCHAR (150)  NOT NULL,
    [TRIGGER_GROUP] NVARCHAR (150)  NOT NULL,
    [STR_PROP_1]    NVARCHAR (512)  NULL,
    [STR_PROP_2]    NVARCHAR (512)  NULL,
    [STR_PROP_3]    NVARCHAR (512)  NULL,
    [INT_PROP_1]    INT             NULL,
    [INT_PROP_2]    INT             NULL,
    [LONG_PROP_1]   BIGINT          NULL,
    [LONG_PROP_2]   BIGINT          NULL,
    [DEC_PROP_1]    NUMERIC (13, 4) NULL,
    [DEC_PROP_2]    NUMERIC (13, 4) NULL,
    [BOOL_PROP_1]   BIT             NULL,
    [BOOL_PROP_2]   BIT             NULL,
    [TIME_ZONE_ID]  NVARCHAR (80)   NULL,
    CONSTRAINT [PK_SIMPROP_TRIGGERS] PRIMARY KEY CLUSTERED ([SCHED_NAME] ASC, [TRIGGER_NAME] ASC, [TRIGGER_GROUP] ASC),
    CONSTRAINT [FK_SIMPROP_TRIGGERS_TRIGGERS] FOREIGN KEY ([SCHED_NAME], [TRIGGER_NAME], [TRIGGER_GROUP]) REFERENCES [Quartz].[TRIGGERS] ([SCHED_NAME], [TRIGGER_NAME], [TRIGGER_GROUP]) ON DELETE CASCADE
);

