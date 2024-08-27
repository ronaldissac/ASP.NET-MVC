USE [omegabase]
GO

INSERT INTO [dbo].[Customer]
           ([CustomerName]
           ,[CustomerEmail]
           ,[CustomerPhone]
           ,[customerId]
           ,[CustomerPassword])
     VALUES
           ('Ronald Issac',
            'ronaldissac@123gmail.com'
           ,'9952791219'
           ,'ronald@123'
           ,'123'
            )
GO

select * from Customer
	CREATE PROCEDURE ValidateCustomer
		@customerid VARCHAR(50),
		@customerpass VARCHAR(50)
	AS
	BEGIN
		SET NOCOUNT ON;

		DECLARE @IsValid BIT;

		-- Check if the customer exists and the password matches
		IF EXISTS (SELECT 1 FROM [dbo].[Customer] WHERE [customerId] = @customerid AND [CustomerPassword] = @customerpass)
		BEGIN
			-- Update the LastLogin to the current time
			UPDATE [dbo].[Customer] SET [LastLogin] = GETDATE() WHERE [customerId] = @customerid;

			-- Customer is valid
			SET @IsValid = 1;
		END
		ELSE
		BEGIN
			-- Customer is not valid
			SET @IsValid = 0;
		END

		SELECT @IsValid AS IsValid;
	END

exec ValidateCustomer 'ronald@123','123'
exec ValidateCustomer 'ronald@123','123'
exec ValidateCustomer   