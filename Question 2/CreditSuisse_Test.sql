
CREATE OR ALTER PROCEDURE sp_insert_trade
    @p_value DECIMAL(10,2),
    @p_client_sector VARCHAR(50)
AS
BEGIN
    BEGIN
        IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_NAME = 'Trades') 
            CREATE TABLE Trades (
                ID INT NOT NULL IDENTITY(1,1),
                TradeValue DECIMAL(10, 2),
                ClientSector VARCHAR(50),
                Date DATETIME,
                PRIMARY KEY (ID)
            );
        
        IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_NAME = 'TradesClassifications')
            CREATE TABLE TradesClassifications (
                ID INT NOT NULL IDENTITY(1,1),
                Category VARCHAR(15),
                TradeID INT NOT NULL,
                PRIMARY KEY (ID),
                FOREIGN KEY (TradeID) REFERENCES Trades(ID)
            );
        
    END
    BEGIN

        DECLARE @v_trade_id INT;
        DECLARE @v_trade_category VARCHAR(15);
        
        INSERT INTO Trades (TradeValue, ClientSector, [Date])
        VALUES (@p_value, @p_client_sector, GETDATE());

        SET @v_trade_id = SCOPE_IDENTITY();
        
        IF @p_client_sector = 'Public Sector' AND @p_value < 1000000 
            SET @v_trade_category = 'LOWRISK';
        ELSE IF @p_client_sector = 'Public Sector' AND @p_value > 1000000  
            SET @v_trade_category = 'MEDIUMRISK';
        ELSE IF @p_client_sector = 'Private Sector' AND @p_value > 1000000
            SET @v_trade_category = 'HIGHRISK';
        
        INSERT INTO TradesClassifications (Category, TradeID)
                VALUES (@v_trade_category, @v_trade_id);
        
    END
END

GO

EXEC sp_insert_trade 2000000.00, 'Private Sector';
EXEC sp_insert_trade 400000.00, 'Public Sector';
EXEC sp_insert_trade 500000.00, 'Public Sector';
EXEC sp_insert_trade 3000000.00, 'Public Sector';

GO

SELECT * FROM Trades
SELECT TradeID, Category FROM TradesClassifications
