USE TEMPDB
GO

/******************************** Create DB *******************************/
IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'Scrumer')
	BEGIN
	CREATE DATABASE [Scrumer]  ON (NAME = N'Scrumer_Data', FILENAME = N'V:\Software\DB\SQLServer\DBFile\MSSQL11\Scrumer_Data.MDF' , SIZE = 5, FILEGROWTH = 10%) LOG ON (NAME = N'Scrumer_Log', FILENAME = N'V:\Software\DB\SQLServer\DBFile\MSSQL11\Scrumer_Log.LDF' , SIZE = 3, FILEGROWTH = 10%)
	COLLATE SQL_Latin1_General_CP1_CI_AS
	END
GO
/******************************** Create DB *******************************/

USE Scrumer
GO

/************************** Create db login user  begin *****************************/
if not exists (select * from master.dbo.syslogins where loginname = N'scrum')
BEGIN
	declare @logindb nvarchar(132), @loginlang nvarchar(132) select @logindb = N'Scrumer', @loginlang = N'us_english'
	if @logindb is null or not exists (select * from master.dbo.sysdatabases where name = @logindb)
		select @logindb = N'master'
	if @loginlang is null or (not exists (select * from master.dbo.syslanguages where name = @loginlang) and @loginlang <> N'us_english')
		select @loginlang = @@language
	exec sp_addlogin N'scrum', 'abc!111111', @logindb, @loginlang
END
GO

if not exists (select * from dbo.sysusers where name = N'scrum')
BEGIN 
	EXEC sp_grantdbaccess N'scrum', N'scrum'   -- first is syslogins, second is sysusers which is security account.
	
	exec sp_addrolemember N'db_owner', N'scrum' -- Add  role db_owner to sysusers scrum
	
END
GO

/************************** Create db login user  end *****************************/

/************** Table USER_LOGIN  begin **************************/
IF NOT EXISTS(SELECT TOP 1 1 FROM sys.tables t WITH(NOLOCK)
WHERE SCHEMA_NAME(schema_id) = 'DBO' AND OBJECT_NAME(object_id) ='USER_LOGIN' AND type = 'U')
BEGIN
	 CREATE TABLE [DBO].USER_LOGIN ( 
	 ID INT IDENTITY(1,1)  NOT NULL,
	 NAME NVARCHAR(100)  NULL,
	 MOBILE NVARCHAR(100) NULL,
	 PASSWORD NVARCHAR(100) NOT NULL,
	 SUB_PASSWORD NVARCHAR(100) NOT NULL,
	 CREATE_DATE Datetime NOT NULL,
	 UPDATE_DATE Datetime NULL
)
	 PRINT 'CREATE TABLE DBO.USER_LOGIN Success!'
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM sys.tables t WITH(NOLOCK) 
JOIN sys.indexes i ON t.object_id = i.object_id AND i.is_primary_key = 1 WHERE SCHEMA_NAME(t.schema_id) = 'DBO' AND OBJECT_NAME(t.object_id) ='USER_LOGIN' AND t.type = 'U')
BEGIN
	 ALTER TABLE DBO.USER_LOGIN ADD CONSTRAINT PK_USER_LOGIN  PRIMARY KEY CLUSTERED  (ID ASC)WITH (PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
	 PRINT 'Created primary key PK_USER_LOGIN on table DBO.USER_LOGIN'
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM sys.tables t WITH(NOLOCK)
JOIN sys.indexes i ON t.object_id = i.object_id AND i.name = 'IDX_USER_LOGIN_Name'
WHERE SCHEMA_NAME(t.schema_id) = 'DBO' AND OBJECT_NAME(t.object_id) ='USER_LOGIN' AND t.type = 'U')
BEGIN
	 CREATE NONCLUSTERED INDEX [IDX_USER_LOGIN_Name]  ON [DBO].[USER_LOGIN] ([NAME] ASC)WITH (PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, ONLINE=ON, MAXDOP=0) ON [PRIMARY]
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM sys.tables t WITH(NOLOCK)
JOIN sys.indexes i ON t.object_id = i.object_id AND i.name = 'IDX_USER_LOGIN_Mobile'
WHERE SCHEMA_NAME(t.schema_id) = 'DBO' AND OBJECT_NAME(t.object_id) ='USER_LOGIN' AND t.type = 'U')
BEGIN
	 CREATE NONCLUSTERED INDEX [IDX_USER_LOGIN_Mobile]  ON [DBO].[USER_LOGIN] ([MOBILE] ASC)WITH (PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, ONLINE=ON, MAXDOP=0) ON [PRIMARY]
END
GO
/************** Table USER_LOGIN  end ****/


/************** Table USER_SHADOW  begin (sensitive info, like pwd, currently we just store them in USER_LOGIN table for demo) **************************/

IF NOT EXISTS(SELECT TOP 1 1 FROM sys.tables t WITH(NOLOCK)
WHERE SCHEMA_NAME(schema_id) = 'DBO' AND OBJECT_NAME(object_id) ='USER_SHADOW' AND type = 'U')
BEGIN
	 CREATE TABLE [DBO].USER_SHADOW ( 
	 USER_LOGIN_ID  INT NOT NULL,
	 PASSWORD NVARCHAR(100) NOT NULL,
	 SUB_PASSWORD NVARCHAR(100) NOT NULL,
	 UPDATE_DATE Datetime NOT NULL
)
	 PRINT 'CREATE TABLE DBO.USER_SHADOW Success!'
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM sys.tables t WITH(NOLOCK) 
JOIN sys.indexes i ON t.object_id = i.object_id AND i.is_primary_key = 1 WHERE SCHEMA_NAME(t.schema_id) = 'DBO' AND OBJECT_NAME(t.object_id) ='USER_SHADOW' AND t.type = 'U')
BEGIN
	 ALTER TABLE DBO.USER_SHADOW ADD CONSTRAINT PK_USER_SHADOW  PRIMARY KEY CLUSTERED  (USER_LOGIN_ID ASC)WITH (PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
	 PRINT 'Created primary key PK_USER_SHADOW on table DBO.USER_SHADOW'
END
GO

/************** Table USER_SHADOW  end ********/

/************** Table USER_DETAIL  begin **************************/


/************** Table USER_DETAIL  end *****/


/************** Table SYSTEM_CONFIG  begin **************************/

IF NOT EXISTS(SELECT TOP 1 1 FROM sys.tables t WITH(NOLOCK)
WHERE SCHEMA_NAME(schema_id) = 'DBO' AND OBJECT_NAME(object_id) ='SYSTEM_CONFIG' AND type = 'U')
BEGIN
	 CREATE TABLE [DBO].SYSTEM_CONFIG ( 
	 ID  INT IDENTITY(1,1)  NOT NULL,
	 [TYPE] INT NOT NULL,
	 NAME NVARCHAR(100)  NULL,
	 [VALUE] NVARCHAR(500) NULL,
	 CREATE_DATE Datetime NOT NULL
)
	 PRINT 'CREATE TABLE DBO.SYSTEM_CONFIG Success!'
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM sys.tables t WITH(NOLOCK) 
JOIN sys.indexes i ON t.object_id = i.object_id AND i.is_primary_key = 1 WHERE SCHEMA_NAME(t.schema_id) = 'DBO' AND OBJECT_NAME(t.object_id) ='SYSTEM_CONFIG' AND t.type = 'U')
BEGIN
	 ALTER TABLE DBO.SYSTEM_CONFIG ADD CONSTRAINT PK_SYSTEM_CONFIG  PRIMARY KEY CLUSTERED  (ID ASC)WITH (PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
	 PRINT 'Created primary key PK_SYSTEM_CONFIG on table DBO.SYSTEM_CONFIG'
END
GO
-- init data
IF NOT EXISTS (SELECT 1 FROM DBO.SYSTEM_CONFIG WHERE NAME = 'ms_sql_connection_string')
BEGIN
INSERT INTO DBO.SYSTEM_CONFIG([TYPE],NAME,[VALUE],CREATE_DATE)
SELECT 1,'ms_sql_connection_string','Data Source=localhost;Initial Catalog=scrumer;User ID=scrum;Password=abc!111111;Persist Security Info=False;',GETDATE()
END
GO
/************** Table SYSTEM_CONFIG  end ******/

/************** Table DOWNLOAD_FILE  begin **************************/
IF NOT EXISTS(SELECT TOP 1 1 FROM sys.tables t WITH(NOLOCK)
WHERE SCHEMA_NAME(schema_id) = 'DBO' AND OBJECT_NAME(object_id) ='DOWNLOAD_FILE' AND type = 'U')
BEGIN
	 CREATE TABLE [DBO].DOWNLOAD_FILE ( 
	 ID  INT IDENTITY(1,1)   NOT NULL,
	 FILE_NAME NVARCHAR(500) NOT NULL,
	 LOCAL_DIR NVARCHAR(1000)  NULL,
	 FILE_VERSION NVARCHAR(50) NULL,
	 FILE_CONTENT image NULL,
	 CREATE_DATE Datetime NOT NULL,
	 UPDATE_DATE Datetime NULL,
	 UPDATE_BY NVARCHAR(50) NULL
)
	 PRINT 'CREATE TABLE DBO.DOWNLOAD_FILE Success!'
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM sys.tables t WITH(NOLOCK) 
JOIN sys.indexes i ON t.object_id = i.object_id AND i.is_primary_key = 1 WHERE SCHEMA_NAME(t.schema_id) = 'DBO' AND OBJECT_NAME(t.object_id) ='DOWNLOAD_FILE' AND t.type = 'U')
BEGIN
	 ALTER TABLE DBO.DOWNLOAD_FILE ADD CONSTRAINT PK_DOWNLOAD_FILE  PRIMARY KEY CLUSTERED  (ID ASC)WITH (PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
	 PRINT 'Created primary key PK_DOWNLOAD_FILE on table DBO.DOWNLOAD_FILE'
END
GO

/************** Table DOWNLOAD_FILE  end *******/


/************** Table PROJECT  begin **************************/
IF NOT EXISTS(SELECT TOP 1 1 FROM sys.tables t WITH(NOLOCK)
WHERE SCHEMA_NAME(schema_id) = 'DBO' AND OBJECT_NAME(object_id) ='PROJECT' AND type = 'U')
BEGIN
	 CREATE TABLE [DBO].PROJECT ( 
	 ID INT IDENTITY(1,1)  NOT NULL,
	 NAME NVARCHAR(100) NOT NULL,
	 CONTENT NVARCHAR(MAX)  NULL,
	 CREATE_DATE Datetime NOT NULL,
	 UPDATE_DATE Datetime NULL,
	 UPDATE_BY NVARCHAR(50) NULL
)
	 PRINT 'CREATE TABLE DBO.PROJECT Success!'
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM sys.tables t WITH(NOLOCK) 
JOIN sys.indexes i ON t.object_id = i.object_id AND i.is_primary_key = 1 WHERE SCHEMA_NAME(t.schema_id) = 'DBO' AND OBJECT_NAME(t.object_id) ='PROJECT' AND t.type = 'U')
BEGIN
	 ALTER TABLE DBO.PROJECT ADD CONSTRAINT PK_PROJECT  PRIMARY KEY CLUSTERED  (ID ASC)WITH (PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
	 PRINT 'Created primary key PK_PROJECT on table DBO.PROJECT success!'
END
GO

/************** Table STORY  end *****/


/************** Table STORY begin **************************/
IF NOT EXISTS(SELECT TOP 1 1 FROM sys.tables t WITH(NOLOCK)
WHERE SCHEMA_NAME(schema_id) = 'DBO' AND OBJECT_NAME(object_id) ='STORY' AND type = 'U')
BEGIN
	 CREATE TABLE [DBO].STORY ( 
	 ID INT IDENTITY(1,1)  NOT NULL,
	 NAME NVARCHAR(100) NOT NULL,
	 PROJECT_ID INT NULL,
	 LINK_URL NVARCHAR(200) NULL,
	 CONTENT NVARCHAR(MAX)  NULL,
	 DEVELOPER NVARCHAR(50) NULL,
	 QA NVARCHAR(50) NULL,
	 POINT FLOAT  NULL,
	 DEV_PLAN_TIME FLOAT NULL,
	 DEV_SPEND_TIME FLOAT NULL,
	 QA_PLAN_TIME FLOAT NULL,
	 QA_SPEND_TIME FLOAT NULL,
	 ISD_COUNT INT NULL,
	 CREATE_DATE Datetime NOT NULL,
	 CREATE_BY NVARCHAR(50) NULL,
	 UPDATE_DATE Datetime NULL,
	 UPDATE_BY NVARCHAR(50) NULL
)
	 PRINT 'CREATE TABLE DBO.STORY Success!'
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM sys.tables t WITH(NOLOCK) 
JOIN sys.indexes i ON t.object_id = i.object_id AND i.is_primary_key = 1 WHERE SCHEMA_NAME(t.schema_id) = 'DBO' AND OBJECT_NAME(t.object_id) ='STORY' AND t.type = 'U')
BEGIN
	 ALTER TABLE DBO.STORY ADD CONSTRAINT PK_STORY  PRIMARY KEY CLUSTERED  (ID ASC)WITH (PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
	 PRINT 'Created primary key PK_STORY on table DBO.STORY success!'
END
GO

/************** Table STORY  end *****/

/************** Table GROOM_ROOM  begin **************************/
IF NOT EXISTS(SELECT TOP 1 1 FROM sys.tables t WITH(NOLOCK)
WHERE SCHEMA_NAME(schema_id) = 'DBO' AND OBJECT_NAME(object_id) ='GROOM_ROOM' AND type = 'U')
BEGIN
	 CREATE TABLE [DBO].GROOM_ROOM ( 
	 ID INT IDENTITY(1,1)  NOT NULL,
	 NAME NVARCHAR(100) NOT NULL,
	 DESCRIPTION NVARCHAR(500)  NULL,
	 ROOM_KEY NVARCHAR(50) NULL,
	 ROOM_STATUS INT NOT NULL DEFAULT(0),-- 0 Not Use, 1 Using
	 ROOM_OWNER_ID INT NOT NULL DEFAULT(0),-- 0 means no user hold this room,
	 CREATE_DATE Datetime NOT NULL,
	 UPDATE_DATE Datetime NULL,
	 UPDATE_BY NVARCHAR(50) NULL
)
	 PRINT 'CREATE TABLE DBO.GROOM_ROOM Success!'
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM sys.tables t WITH(NOLOCK) 
JOIN sys.indexes i ON t.object_id = i.object_id AND i.is_primary_key = 1 WHERE SCHEMA_NAME(t.schema_id) = 'DBO' AND OBJECT_NAME(t.object_id) ='GROOM_ROOM' AND t.type = 'U')
BEGIN
	 ALTER TABLE DBO.GROOM_ROOM ADD CONSTRAINT PK_GROOM_ROOM  PRIMARY KEY CLUSTERED  (ID ASC)WITH (PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
	 PRINT 'Created primary key PK_GROOM_ROOM on table DBO.GROOM_ROOM success!'
END
GO

-- Create Unique non clustered index for room name 
IF NOT EXISTS(SELECT TOP 1 1 FROM sys.tables t WITH(NOLOCK)
JOIN sys.indexes i ON t.object_id = i.object_id AND i.name = 'UQ_IDX_GROOM_ROOM_NAME'
WHERE SCHEMA_NAME(t.schema_id) = 'DBO' AND OBJECT_NAME(t.object_id) ='GROOM_ROOM' AND t.type = 'U')
BEGIN
    CREATE UNIQUE INDEX [UQ_IDX_GROOM_ROOM_NAME] ON [DBO].[GROOM_ROOM] ([NAME] ASC)WITH (PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, ONLINE=ON, MAXDOP=0) ON [PRIMARY]
END
GO

/************** Table GROOM_ROOM  end *****/

/************** Table GROOM_POKER_RESULT  begin **************************/
IF NOT EXISTS(SELECT TOP 1 1 FROM sys.tables t WITH(NOLOCK)
WHERE SCHEMA_NAME(schema_id) = 'DBO' AND OBJECT_NAME(object_id) ='GROOM_POKER_RESULT' AND type = 'U')
BEGIN
	 CREATE TABLE [DBO].GROOM_POKER_RESULT ( 
	 ID INT IDENTITY(1,1)  NOT NULL,
	 ROOM_ID INT NOT NULL,
	 STORY_ID INT NOT NULL,
	 REMARK NVARCHAR(500) NULL,
	 POINT FLOAT NOT NULL,
	 MIN_POINT FLOAT NOT NULL,
	 MAX_POINT FLOAT NOT NULL,
	 CREATE_DATE Datetime NOT NULL,
	 UPDATE_DATE Datetime NULL,
	 UPDATE_BY NVARCHAR(50) NULL
)
	 PRINT 'CREATE TABLE DBO.GROOM_POKER_RESULT Success!'
END
GO

IF NOT EXISTS(SELECT TOP 1 1 FROM sys.tables t WITH(NOLOCK) 
JOIN sys.indexes i ON t.object_id = i.object_id AND i.is_primary_key = 1 WHERE SCHEMA_NAME(t.schema_id) = 'DBO' AND OBJECT_NAME(t.object_id) ='GROOM_POKER_RESULT' AND t.type = 'U')
BEGIN
	 ALTER TABLE DBO.GROOM_POKER_RESULT ADD CONSTRAINT PK_GROOM_POKER_RESULT  PRIMARY KEY CLUSTERED  (ID ASC)WITH (PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
	 PRINT 'Created primary key PK_GROOM_POKER_RESULT on table DBO.GROOM_POKER_RESULT success!'
END
GO

/************** Table GROOM_POKER_RESULT  end *****/
