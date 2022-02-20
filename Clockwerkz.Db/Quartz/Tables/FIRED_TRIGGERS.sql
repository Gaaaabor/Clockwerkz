﻿CREATE TABLE [Quartz].[FIRED_TRIGGERS] (
    [SCHED_NAME]        NVARCHAR (120) NOT NULL,
    [ENTRY_ID]          NVARCHAR (140) NOT NULL,
    [TRIGGER_NAME]      NVARCHAR (150) NOT NULL,
    [TRIGGER_GROUP]     NVARCHAR (150) NOT NULL,
    [INSTANCE_NAME]     NVARCHAR (200) NOT NULL,
    [FIRED_TIME]        BIGINT         NOT NULL,
    [SCHED_TIME]        BIGINT         NOT NULL,
    [PRIORITY]          INT            NOT NULL,
    [STATE]             NVARCHAR (16)  NOT NULL,
    [JOB_NAME]          NVARCHAR (150) NULL,
    [JOB_GROUP]         NVARCHAR (150) NULL,
    [IS_NONCONCURRENT]  BIT            NULL,
    [REQUESTS_RECOVERY] BIT            NULL,
    CONSTRAINT [PK_FIRED_TRIGGERS] PRIMARY KEY CLUSTERED ([SCHED_NAME] ASC, [ENTRY_ID] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IDX_FT_INST_JOB_REQ_RCVRY]
    ON [Quartz].[FIRED_TRIGGERS]([SCHED_NAME] ASC, [INSTANCE_NAME] ASC, [REQUESTS_RECOVERY] ASC);


GO
CREATE NONCLUSTERED INDEX [IDX_FT_G_J]
    ON [Quartz].[FIRED_TRIGGERS]([SCHED_NAME] ASC, [JOB_GROUP] ASC, [JOB_NAME] ASC);


GO
CREATE NONCLUSTERED INDEX [IDX_FT_G_T]
    ON [Quartz].[FIRED_TRIGGERS]([SCHED_NAME] ASC, [TRIGGER_GROUP] ASC, [TRIGGER_NAME] ASC);
