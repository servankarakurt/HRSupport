-- Employees table
CREATE TABLE Employees (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(256) NOT NULL UNIQUE,
    Phone NVARCHAR(50) NULL,
    Department NVARCHAR(100) NULL,
    Position NVARCHAR(100) NULL,
    HireDate DATETIME2 NOT NULL,
    IsActive BIT NOT NULL DEFAULT(1),
    Type INT NOT NULL,
    PasswordHash NVARCHAR(500) NULL
);

-- Interns table
CREATE TABLE Interns (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeId INT NOT NULL UNIQUE,
    University NVARCHAR(200) NULL,
    Department NVARCHAR(100) NULL,
    Grade INT NULL,
    StartDate DATETIME2 NOT NULL,
    EndDate DATETIME2 NOT NULL,
    MentorId INT NULL,
    Notes NVARCHAR(MAX) NULL,
    CONSTRAINT FK_Intern_Employee FOREIGN KEY (EmployeeId) REFERENCES Employees(Id),
    CONSTRAINT FK_Intern_Mentor FOREIGN KEY (MentorId) REFERENCES Employees(Id)
);

-- LeaveRequests table
CREATE TABLE LeaveRequests (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeId INT NOT NULL,
    LeaveType INT NOT NULL,
    StartDate DATETIME2 NOT NULL,
    EndDate DATETIME2 NOT NULL,
    Description NVARCHAR(MAX) NULL,
    Status INT NOT NULL DEFAULT(0),
    CreatedDate DATETIME2 NOT NULL DEFAULT(GETUTCDATE()),
    ProcessDate DATETIME2 NULL,
    RejectionReason NVARCHAR(MAX) NULL,
    CONSTRAINT FK_Leave_Employee FOREIGN KEY (EmployeeId) REFERENCES Employees(Id)
);
