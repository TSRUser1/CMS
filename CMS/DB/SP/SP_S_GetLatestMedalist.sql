IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetLatestMedalist' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetLatestMedalist
END
GO

/*************************************************************************
* Name				: SP_S_GetLatestMedalist
* Author			: Edwind
* Create date		: 30-Sep-2015
* Description		: Return latest medalist
*************************************************************************/
CREATE PROCEDURE [dbo].[SP_S_GetLatestMedalist]
(
	@n_SportID			int,
	@n_CountryID		int,
	@d_Date				datetime
)
AS
BEGIN
	SELECT TOP 5
		TS.ScoreID,
		PT.ParticipantID,
		UPPER(PT.FullName) AS FullName,
		ISNULL(NULLIF(PT.CardPhotoPath,''), '~/img/player/avatar-big.jpg') AS ParticipantImageFilePath,
		TC.CountryID,
		TC.CountryName,
		TC.IconFilePath AS FlagImageFilePath,
		SP.SportID,
		SP.SportName,
		SP.ImageFilePath AS SportImageFilePath,
		SC.ScheduleDateTime
	FROM T_Score TS WITH (NOLOCK)
	INNER JOIN T_ScoreInParticipantInSchedule SIPIS WITH (NOLOCK)
	ON TS.ScoreID = SIPIS.ScoreID
	INNER JOIN T_ParticipantInSchedule PTIS WITH (NOLOCK)
	ON SIPIS.ParticipantInScheduleID = PTIS.ParticipantInScheduleID
	AND PTIS.IsActive = 1
	INNER JOIN T_Schedule SC WITH (NOLOCK)
	ON PTIS.ScheduleID = SC.ScheduleID
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
		AND TMedal.ReferenceCode = 'GOLD'
		AND TMedal.IsActive = 1
	WHERE TS.IsActive = 1
	AND (SP.SportID = @n_SportID OR @n_SportID IS NULL)
	AND (CAST(SC.ScheduleDateTime AS DATE) = CAST(@d_Date AS DATE) OR @d_Date IS NULL)
	AND (TC.CountryID = @n_CountryID OR @n_CountryID IS NULL)
	ORDER BY SC.ScheduleDateTime DESC
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetLatestMedalist] TO USER
GO*/