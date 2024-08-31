
-- Create tables

CREATE TABLE Todos (
    task_id INT IDENTITY(1,1) PRIMARY KEY,   -- Auto-incrementing primary key
    name NVARCHAR(255) NOT NULL,             -- Task name, non-nullable
    description NVARCHAR(MAX),                -- Task description, nullable
    status INT NOT NULL,
    created_at DATETIME2 NOT NULL,        -- Use DATETIME2 for more precision compared to TIMESTAMP
    completed_at DATETIME2,               -- Same here, DATETIME2 instead of TIMESTAMP
    user_id INT NOT NULL
);
