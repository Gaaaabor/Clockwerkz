﻿CREATE TABLE [Quartz].[CALENDARS] (
    [SCHED_NAME]    NVARCHAR (120)  NOT NULL,
    [CALENDAR_NAME] NVARCHAR (200)  NOT NULL,
    [CALENDAR]      VARBINARY (MAX) NOT NULL,
    CONSTRAINT [PK_CALENDARS] PRIMARY KEY CLUSTERED ([SCHED_NAME] ASC, [CALENDAR_NAME] ASC)
);

