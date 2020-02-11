IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetMultiMedallist' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetMultiMedallist
END
GO

/*************************************************************************
* Name				: SP_S_GetMultiMedallist
* Author			: Edwind
* Create date		: 8-Oct-2015
* Description		: Return multi medallist
*************************************************************************/
CREATE PROCEDURE [dbo].[SP_S_GetMultiMedallist]
(
	@n_SportID			int,
	@n_CountryID		int,
	@d_Date				datetime,
	@s_Medal			nvarchar(max)
)
AS
BEGIN

	DECLARE @l_n_SportID			int,
			@l_n_CountryID			int,
			@l_d_Date				datetime,
			@l_s_Medal				nvarchar(max)

	SET @l_n_SportID = @n_SportID
	SET @l_n_CountryID = @n_CountryID
	SET @l_d_Date = @d_Date
	SET @l_s_Medal = @s_Medal

	SELECT
		RANK() OVER (ORDER BY MedalTable.[TotalGold] DESC, MedalTable.[TotalSilver] DESC, MedalTable.[TotalBronze] DESC) AS [Rank],
		MedalTable.*
	FROM
	(
		SELECT
			SP.SportID,
			SP.SportName,
			SP.ImageFilePath AS [SportImageFilePath],
			PT.ParticipantID,
			ISNULL(NULLIF(PT.CardPhotoPath,''), '~/img/player/avatar-big.jpg') AS ParticipantImageFilePath,
			UPPER(PT.FullName) AS FullName,
			CAST(CAST(SC.ScheduleDateTime AS DATE) AS NVARCHAR(10)) AS ScheduleDate,
			SC.ScheduleDateTime,
			EV.EventID,
			EV.EventName,
			TMedal.ReferenceName AS [Medal],
			TMedal.ReferenceCode AS [MedalCode],
			CASE TMedal.ReferenceCode 
				WHEN 'GOLD' THEN '~/img/medal/gold.png'
				WHEN 'SILVER' THEN '~/img/medal/silver.png'
				WHEN 'BRONZE' THEN '~/img/medal/bronze.png'
			ELSE NULL
			END AS [MedalIconFilePath],
			COUNT(*) OVER (PARTITION BY PT.ParticipantID) AS [Total],
			COUNT(CASE TMedal.ReferenceCode WHEN 'GOLD' THEN 1 ELSE NULL END) OVER (PARTITION BY PT.ParticipantID) AS [TotalGold],
			COUNT(CASE TMedal.ReferenceCode WHEN 'SILVER' THEN 1 ELSE NULL END) OVER (PARTITION BY PT.ParticipantID) AS [TotalSilver],
			COUNT(CASE TMedal.ReferenceCode WHEN 'BRONZE' THEN 1 ELSE NULL END) OVER (PARTITION BY PT.ParticipantID) AS [TotalBronze],
			TC.CountryID,
			TC.CountryName,
			TC.SmallIconFilePath,
			TC.IconFilePath
		FROM T_Score TS WITH (NOLOCK)
		INNER JOIN T_ScoreInParticipantInSchedule AS SIPIS WITH (NOLOCK)
		ON SIPIS.ScoreID = TS.ScoreID
		INNER JOIN T_ParticipantInSchedule PTIS WITH (NOLOCK)
		ON  (
				SIPIS.ParticipantInScheduleID = PTIS.ParticipantInScheduleID
				OR (SIPIS.ScheduleID = PTIS.ScheduleID AND SIPIS.TeamID = PTIS.TeamID)
			)
			AND PTIS.IsActive = 1
		INNER JOIN T_Schedule SC WITH (NOLOCK)
		ON PTIS.ScheduleID = SC.ScheduleID
			AND SC.IsMedalGame = 1
			AND SC.IsActive = 1
		INNER JOIN T_Event EV WITH (NOLOCK)
		ON SC.EventID = EV.EventID
			AND EV.IsActive = 1
		INNER JOIN T_Sport SP WITH (NOLOCK)
		ON EV.SportID = SP.SportID
			AND SP.IsActive = 1
		INNER JOIN T_Participant PT WITH (NOLOCK)
		ON PTIS.ParticipantID = PT.ParticipantID
			AND PT.IsActive = 1
		INNER JOIN T_Country TC WITH (NOLOCK)
		ON PT.CountryID = TC.CountryID
			AND TC.IsActive = 1
		INNER JOIN T_Reference TMedal WITH (NOLOCK)
		ON TS.MedalID = TMedal.ReferenceInternalID
			AND TMedal.ReferenceCategoryID = 6
			AND TMedal.IsActive = 1
		WHERE TS.IsActive = 1
		AND (SP.SportID = @l_n_SportID OR @l_n_SportID IS NULL)
		AND (CAST(SC.ScheduleDateTime AS DATE) = CAST(@l_d_Date AS DATE) OR @l_d_Date IS NULL)
		AND (TC.CountryID = @l_n_CountryID OR @l_n_CountryID IS NULL)
		AND (TMedal.ReferenceCode = @l_s_Medal OR @l_s_Medal IS NULL)
	) MedalTable
	ORDER BY MedalTable.SportName, MedalTable.EventName, 
	CASE	WHEN MedalTable.[MedalCode] = 'GOLD' THEN 0
			WHEN MedalTable.[MedalCode] = 'SILVER' THEN 1
			WHEN MedalTable.[MedalCode] = 'BRONZE' THEN 2
			ELSE 4
	END
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetMultiMedallist] TO USER
GO*/