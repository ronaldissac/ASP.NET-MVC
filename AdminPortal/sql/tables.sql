----------------------Create the ExportTable------------------------------------------
CREATE TABLE Export
(
    ID INT IDENTITY,
    ProductName VARCHAR(30),
    Quantity INT,
    FromLocation VARCHAR(MAX),
    ToLocation VARCHAR(MAX),
    FileData VARBINARY(MAX),
    FileName NVARCHAR(30),
    CreatedDate DATETIME DEFAULT GETDATE(),
	Track NVARCHAR(16) CONSTRAINT PK PRIMARY KEY
);

------------------------------INSERT EXPORT(Procedure)--------------------------
CREATE PROCEDURE AddExport
    @ProductName VARCHAR(30),
    @Quantity INT,
    @FromLocation VARCHAR(MAX),
    @ToLocation VARCHAR(MAX),
    @FileData VARBINARY(MAX),
    @FileName NVARCHAR(30),
	@Track NVARCHAR(30)
AS
BEGIN
    INSERT INTO Export (ProductName, Quantity, FromLocation, ToLocation, FileData, FileName,Track)
    VALUES (@ProductName, @Quantity, @FromLocation, @ToLocation, @FileData, @FileName,@Track);
END;
------------------------------------DISPLAY EXPORT(Procedure)----------------------
CREATE PROCEDURE GetExportData
    @TrackID VARCHAR(50)
AS
BEGIN
    SELECT ProductName, Quantity, FromLocation, ToLocation, FileData,CreatedDate
    FROM export
    WHERE track = @TrackID;
END;
select * from Export_Status
--------------------------------------------------Create Table Export_Status--------------------------------------------------------------------
CREATE TABLE Export_Status (
  FromLocation NVARCHAR(MAX),
  ToLocation NVARCHAR(MAX),
  Payment INT,
  Location NVARCHAR(50),
  Estimation INT,
  Track NVARCHAR(16),
  FOREIGN KEY (Track) REFERENCES Export(Track),
  Status NVARCHAR(30),
  vessel Nvarchar(30),
  
);

----------------------------------------------Update_status Procedure-------------------------------------------------------------------------------
CREATE PROCEDURE Update_Status (
  @FromLocation NVARCHAR(MAX),
  @ToLocation NVARCHAR(MAX),
  @Payment INT,
  @Location NVARCHAR(50),
  @Estimation INT,
  @Status NVARCHAR(30),
  @TrackID NVARCHAR(16)
)
AS
BEGIN
  -- Check if the TrackID exists in the Export table
  IF EXISTS (
    SELECT 1
    FROM Export
    WHERE Track = @TrackID
  )
  BEGIN
    -- Update the Status table with the provided values
    UPDATE Export_Status
    SET FromLocation = @FromLocation,
        ToLocation = @ToLocation,
        Payment = @Payment,
        Location = @Location,
        Estimation = @Estimation,
        Status = @Status

    WHERE Track = @TrackID;

    -- Insert the local variables into the Update_Export table
    INSERT INTO Export_Status (FromLocation, ToLocation, Payment, Location, Estimation, Status, Track)
    VALUES (@FromLocation, @ToLocation, @Payment, @Location, @Estimation, @Status, @TrackID);
  END
  ELSE
  BEGIN
    -- TrackID does not exist, handle the error or perform any necessary actions
    -- For example, you can raise an error message
    RAISERROR('Invalid TrackID. The TrackID does not exist in the Export table.', 16, 1)
  END
END

-------------------Login Cerdentials------------------------------------------------------------------

CREATE TABLE AdminTable (
    UserID NVARCHAR(50) PRIMARY KEY,
    Password VARCHAR(50)
);

insert into AdminTable  values ('ron@16', 2002)
select * FROM admintable

CREATE TABLE UserTable (
    UserID NVARCHAR(50) PRIMARY KEY,
    Password VARCHAR(50)
);

insert into UserTable values ('ronald',200216)

CREATE PROCEDURE ValidateLogin
    @UserType VARCHAR(50),
    @UserID VARCHAR(50),
    @Password VARCHAR(50),
    @IsValid BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    IF @UserType = 'Admin'
    BEGIN
        IF EXISTS (SELECT 1 FROM AdminTable WHERE UserID = @UserID AND Password = @Password)
            SET @IsValid = 1;
        ELSE
            SET @IsValid = 0;
    END
    ELSE IF @UserType = 'User'
    BEGIN
        IF EXISTS (SELECT 1 FROM UserTable WHERE UserID = @UserID AND Password = @Password)
            SET @IsValid = 1;
        ELSE
            SET @IsValid = 0;
    END
    ELSE
    BEGIN
        SET @IsValid = 0;
    END
END

----------------- Create BL--------------------------------------------------------------

CREATE TABLE BL (Track nvarchar(16) pro,Status varchar(50),FromLocation varchar(max),ToLocation varchar(max),Payment int,Estimation int,Vessel nvarchar(max),Location varchar(50),BLNumber nvarchar(max))
alter table BL
Add column 
select * from BL
select * from Export_Status