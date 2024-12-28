IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetDashboardProducts')
BEGIN
    EXEC('
    CREATE PROCEDURE [dbo].[GetDashboardProducts]
        @TopRows INT = 5
    AS
    BEGIN
        SET NOCOUNT ON;

        WITH RankedStatus AS (
            SELECT 
                info.CompanyName,
                info.ParentEnterpriseName,
                info.StatusId,
                info.Id,
                usr.FullName,
                stat.Status,
                ROW_NUMBER() OVER (PARTITION BY info.StatusId ORDER BY info.CreatedAt) AS RowNum
            FROM tbl_leads_information AS info
            INNER JOIN tbl_kam_users AS usr ON info.AssignedToId = usr.Id
            INNER JOIN tbl_status AS stat ON info.StatusId = stat.id
        )
        SELECT *
        FROM RankedStatus
        WHERE RowNum <= @TopRows;
    END
    ')
END
