USE omegabase

SELECT * FROM Booking

ALTER TABLE BOOKING
Alter COLUMN CustomerID varchar(50)

CREATE TABLE Numbers
(ID INT PRIMARY KEY IDENTITY(1,1),TypeofNumber VARCHAR(30),SeqNo varchar(30))
Drop table Numbers
SELECT * FROM Numbers

INSERT INTO Numbers
(TypeofNumber,SeqNo) VALUES
('BookingRefNo','BKCOKOS00')

UPDATE Numbers
SET SEQNO='BKCOKOS000'
WHERE TypeofNumber='BookingRefNo'