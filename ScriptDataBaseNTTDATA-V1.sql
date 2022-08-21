-- DROP SCHEMA dbo;

CREATE SCHEMA dbo;
-- nttdata.dbo.Clients definition

-- Drop table

-- DROP TABLE nttdata.dbo.Clients;

CREATE TABLE nttdata.dbo.Clients (
	IdClient uniqueidentifier NOT NULL,
	UserName nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Password nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Status int NOT NULL,
	Name nvarchar(150) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Address nvarchar(150) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Telephone nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Gender int NOT NULL,
	Age int NOT NULL,
	CONSTRAINT PK_Clients PRIMARY KEY (IdClient)
);


-- nttdata.dbo.[__EFMigrationsHistory] definition

-- Drop table

-- DROP TABLE nttdata.dbo.[__EFMigrationsHistory];

CREATE TABLE nttdata.dbo.[__EFMigrationsHistory] (
	MigrationId nvarchar(150) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	ProductVersion nvarchar(32) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CONSTRAINT PK___EFMigrationsHistory PRIMARY KEY (MigrationId)
);


-- nttdata.dbo.BankAccounts definition

-- Drop table

-- DROP TABLE nttdata.dbo.BankAccounts;

CREATE TABLE nttdata.dbo.BankAccounts (
	IdBankAccount uniqueidentifier NOT NULL,
	IdUsuario uniqueidentifier NOT NULL,
	BankAccountNumber nvarchar(16) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	BankAccountType int NOT NULL,
	BankAccountBalance decimal(18,2) NOT NULL,
	BankAccountAvailableBalance decimal(18,2) NOT NULL,
	BankAccountStatus int NOT NULL,
	CONSTRAINT PK_BankAccounts PRIMARY KEY (IdBankAccount),
	CONSTRAINT FK_BankAccounts_Clients_IdUsuario FOREIGN KEY (IdUsuario) REFERENCES nttdata.dbo.Clients(IdClient) ON DELETE CASCADE
);
 CREATE NONCLUSTERED INDEX IX_BankAccounts_IdUsuario ON dbo.BankAccounts (  IdUsuario ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;


-- nttdata.dbo.Transactions definition

-- Drop table

-- DROP TABLE nttdata.dbo.Transactions;

CREATE TABLE nttdata.dbo.Transactions (
	IdTransaction uniqueidentifier NOT NULL,
	IdBankAccount uniqueidentifier NOT NULL,
	TransactionDate datetime2 NOT NULL,
	TransactionType int NOT NULL,
	TransactionValue decimal(18,2) NOT NULL,
	CONSTRAINT PK_Transactions PRIMARY KEY (IdTransaction),
	CONSTRAINT FK_Transactions_BankAccounts_IdBankAccount FOREIGN KEY (IdBankAccount) REFERENCES nttdata.dbo.BankAccounts(IdBankAccount) ON DELETE CASCADE
);
 CREATE NONCLUSTERED INDEX IX_Transactions_IdBankAccount ON dbo.Transactions (  IdBankAccount ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;
