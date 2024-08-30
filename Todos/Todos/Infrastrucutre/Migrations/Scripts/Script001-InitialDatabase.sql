
-- Create tables

CREATE TABLE Todos (
	task_id UNIQUEIDENTIFIER PRIMARY KEY,  -- UUID in SQL Server is represented as UNIQUEIDENTIFIER
    name NVARCHAR(255) NOT NULL,          -- Use NVARCHAR for variable-length strings
    description NVARCHAR(MAX),            -- TEXT is not supported in SQL Server, use NVARCHAR(MAX)
    status INT NOT NULL,
    created_at DATETIME2 NOT NULL,        -- Use DATETIME2 for more precision compared to TIMESTAMP
    completed_at DATETIME2,               -- Same here, DATETIME2 instead of TIMESTAMP
    user_id INT NOT NULL
);