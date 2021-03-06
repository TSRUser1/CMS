IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetGeneralSchedule' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetGeneralSchedule
END
GO

/*************************************************************************
* Name				: SP_S_GetGeneralSchedule
* Author			: Edwind
* Create date		: 27-Aug-2015
* Description		: Return general schedule
*************************************************************************/
CREATE PROCEDURE SP_S_GetGeneralSchedule
(
	@n_SportID			int
)
AS
BEGIN
	DECLARE @s_Date3Dec NVARCHAR(9) = '12/3/2015',
			@s_Date4Dec NVARCHAR(9) = '12/4/2015',
			@s_Date5Dec NVARCHAR(9) = '12/5/2015',
			@s_Date6Dec NVARCHAR(9) = '12/6/2015',
			@s_Date7Dec NVARCHAR(9) = '12/7/2015',
			@s_Date8Dec NVARCHAR(9) = '12/8/2015',
			@s_Date9Dec NVARCHAR(9) = '12/9/2015'
	
	SELECT *
	FROM
	(
		SELECT
			-1 AS SportID,
			'CEREMONIES' AS SportName,
			'Ceremonies' AS SportCode,
			'' AS ImageFilePath,
			1  AS IsActive,
			GETDATE() AS CreatedDateTime,
			0 AS CreatedBy,
			GETDATE() AS ModifiedDateTime,
			0 AS ModifiedBy,
			1 AS [3Dec],
			'oc.png' AS [3DecImage],
			0 AS [4Dec],
			'' AS [4DecImage],
			0 AS [5Dec],
			'' AS [5DecImage],
			0 AS [6Dec],
			'' AS [6DecImage],
			0 AS [7Dec],
			'' AS [7DecImage],
			0 AS [8Dec],
			'' AS [8DecImage],
			1 AS [9Dec],
			'cc.png' as [9DecImage]
		UNION
		SELECT
			SP.SportID,
			SP.SportName,
			SP.SportCode,
			SP.ImageFilePath,
			SP.IsActive,
			SP.CreatedDateTime,
			SP.CreatedBy,
			SP.ModifiedDateTime,
			SP.ModifiedBy,
			CASE WHEN SC_03.SportID IS NOT NULL THEN 1 ELSE 0 END AS [3Dec],
			CASE WHEN SC_03.IsFinalCount > 0 THEN 'champion.png' ELSE 'empty.png' END AS [3DecImage],
			CASE WHEN SC_04.SportID IS NOT NULL THEN 1 ELSE 0 END AS [4Dec],
			CASE WHEN SC_04.IsFinalCount > 0 THEN 'champion.png' ELSE 'empty.png' END AS [4DecImage],
			CASE WHEN SC_05.SportID IS NOT NULL THEN 1 ELSE 0 END AS [5Dec],
			CASE WHEN SC_05.IsFinalCount > 0 THEN 'champion.png' ELSE 'empty.png' END AS [5DecImage],
			CASE WHEN SC_06.SportID IS NOT NULL THEN 1 ELSE 0 END AS [6Dec],
			CASE WHEN SC_06.IsFinalCount > 0 THEN 'champion.png' ELSE 'empty.png' END AS [6DecImage],
			CASE WHEN SC_07.SportID IS NOT NULL THEN 1 ELSE 0 END AS [7Dec],
			CASE WHEN SC_07.IsFinalCount > 0 THEN 'champion.png' ELSE 'empty.png' END AS [7DecImage],
			CASE WHEN SC_08.SportID IS NOT NULL THEN 1 ELSE 0 END AS [8Dec],
			CASE WHEN SC_08.IsFinalCount > 0 THEN 'champion.png' ELSE 'empty.png' END AS [8DecImage],
			CASE WHEN SC_09.SportID IS NOT NULL THEN 1 ELSE 0 END AS [9Dec],
			CASE WHEN SC_09.IsFinalCount > 0 THEN 'champion.png' ELSE 'empty.png' END AS [9DecImage]
		FROM T_Sport SP
		--table for 3rd Dec
		LEFT JOIN
		(
			SELECT 
				EV.SportID, 
				COUNT(CASE WHEN SC.IsMedalGame = 1 THEN 1 ELSE NULL END) as IsFinalCount
			FROM T_Schedule SC
			INNER JOIN T_Event EV
			ON SC.EventID = EV.EventID
			WHERE SC.IsActive = 1
			AND CAST(SC.ScheduleDateTime AS DATE) = @s_Date3Dec
			AND (SC.IsPublishSchedule <> 0 OR SC.IsPublishSchedule IS NULL)
			GROUP BY EV.SportID
		) SC_03
		ON SP.SportID = SC_03.SportID
		--table for 4th Dec
		LEFT JOIN
		(
			SELECT 
				EV.SportID, 
				COUNT(CASE WHEN SC.IsMedalGame = 1 THEN 1 ELSE NULL END) as IsFinalCount
			FROM T_Schedule SC
			INNER JOIN T_Event EV
			ON SC.EventID = EV.EventID
			WHERE SC.IsActive = 1
			AND CAST(SC.ScheduleDateTime AS DATE) = @s_Date4Dec
			AND (SC.IsPublishSchedule <> 0 OR SC.IsPublishSchedule IS NULL)
			GROUP BY EV.SportID
		) SC_04
		ON SP.SportID = SC_04.SportID
		--table for 5th Dec
		LEFT JOIN
		(
			SELECT 
				EV.SportID, 
				COUNT(CASE WHEN SC.IsMedalGame = 1 THEN 1 ELSE NULL END) as IsFinalCount
			FROM T_Schedule SC
			INNER JOIN T_Event EV
			ON SC.EventID = EV.EventID
			WHERE SC.IsActive = 1
			AND CAST(SC.ScheduleDateTime AS DATE) = @s_Date5Dec
			AND (SC.IsPublishSchedule <> 0 OR SC.IsPublishSchedule IS NULL)
			GROUP BY EV.SportID
		) SC_05
		ON SP.SportID = SC_05.SportID
		--table for 6th Dec
		LEFT JOIN
		(
			SELECT 
				EV.SportID, 
				COUNT(CASE WHEN SC.IsMedalGame = 1 THEN 1 ELSE NULL END) as IsFinalCount
			FROM T_Schedule SC
			INNER JOIN T_Event EV
			ON SC.EventID = EV.EventID
			WHERE SC.IsActive = 1
			AND CAST(SC.ScheduleDateTime AS DATE) = @s_Date6Dec
			AND (SC.IsPublishSchedule <> 0 OR SC.IsPublishSchedule IS NULL)
			GROUP BY EV.SportID
		) SC_06
		ON SP.SportID = SC_06.SportID
		--table for 7th Dec
		LEFT JOIN
		(
			SELECT 
				EV.SportID, 
				COUNT(CASE WHEN SC.IsMedalGame = 1 THEN 1 ELSE NULL END) as IsFinalCount
			FROM T_Schedule SC
			INNER JOIN T_Event EV
			ON SC.EventID = EV.EventID
			WHERE SC.IsActive = 1
			AND CAST(SC.ScheduleDateTime AS DATE) = @s_Date7Dec
			AND (SC.IsPublishSchedule <> 0 OR SC.IsPublishSchedule IS NULL)
			GROUP BY EV.SportID
		) SC_07
		ON SP.SportID = SC_07.SportID
		--table for 8th Dec
		LEFT JOIN
		(
			SELECT 
				EV.SportID, 
				COUNT(CASE WHEN SC.IsMedalGame = 1 THEN 1 ELSE NULL END) as IsFinalCount
			FROM T_Schedule SC
			INNER JOIN T_Event EV
			ON SC.EventID = EV.EventID
			WHERE SC.IsActive = 1
			AND CAST(SC.ScheduleDateTime AS DATE) = @s_Date8Dec
			AND (SC.IsPublishSchedule <> 0 OR SC.IsPublishSchedule IS NULL)
			GROUP BY EV.SportID
		) SC_08
		ON SP.SportID = SC_08.SportID
		--table for 9th Dec
		LEFT JOIN
		(
			SELECT 
				EV.SportID, 
				COUNT(CASE WHEN SC.IsMedalGame = 1 THEN 1 ELSE NULL END) as IsFinalCount
			FROM T_Schedule SC
			INNER JOIN T_Event EV
			ON SC.EventID = EV.EventID
			WHERE SC.IsActive = 1
			AND CAST(SC.ScheduleDateTime AS DATE) = @s_Date9Dec
			AND (SC.IsPublishSchedule <> 0 OR SC.IsPublishSchedule IS NULL)
			GROUP BY EV.SportID
		) SC_09
		ON SP.SportID = SC_09.SportID
		WHERE SP.IsActive = 1
		AND (SP.SportID = @n_SportID or @n_SportID is null)
	) a
	ORDER BY 
		CASE WHEN a.SportName = 'Ceremonies' THEN 0
		ELSE 1
		END,
	a.SportName
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetGeneralSchedule] TO USER
GO*/