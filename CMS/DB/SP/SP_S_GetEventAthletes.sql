IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetEventAthletes' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetEventAthletes
END
GO

/*************************************************************************
* Name				: SP_S_GetEventAthletes
* Author			: Edwind
* Create date		: 8-Sep-2015
* Description		: Return event athletes 
*************************************************************************/
CREATE PROCEDURE [dbo].[SP_S_GetEventAthletes]
(
	@n_EventID			int
)
AS
BEGIN
	
	SELECT DISTINCT
		TE.EventID,
		PT.ParticipantID,
		ISNULL(NULLIF(PT.CardPhotoPath,''), '~/img/player/avatar-big.jpg') AS ParticipantImageFilePath,
		UPPER(PT.FullName) AS FullName,
		PT.DateOfBirth,
		TC.CountryID,
		TC.CountryName,
		TC.IconFilePath AS FlagImageFilePath,
		--BibNumberTable.BibNumber,
		PT.CountryID
	FROM T_ParticipantInEvent PTIE
	INNER JOIN T_Event TE
	ON PTIE.EventID = TE.EventID
		AND TE.IsActive = 1
	INNER JOIN T_Participant PT
	ON PTIE.ParticipantID = PT.ParticipantID
		AND PT.MainCategoryId = 19
		AND PT.IsActive = 1
	INNER JOIN T_Country TC
	ON PT.CountryID = TC.CountryID
		AND TC.IsActive = 1
	--LEFT JOIN 
	--(
	--	SELECT *
	--	FROM
	--	(
	--		SELECT  
	--			RANK() OVER (PARTITION BY SC.EventID, PTIS.ParticipantID ORDER BY PTIS.ParticipantInscheduleID DESC) AS RowNum,
	--			SC.EventID,
	--			PTIS.ParticipantID,
	--			PTIS.BibNumber
	--		FROM T_ParticipantInschedule PTIS
	--		INNER JOIN T_Schedule SC
	--		ON PTIS.ScheduleID = SC.ScheduleID 
	--			AND SC.IsActive = 1
	--		WHERE PTIS.BibNumber IS NOT NULL
	--		AND PTIS.IsActive = 1
	--	) BibNumberTable
	--	WHERE BibNumberTable.RowNum = 1
	--) BibNumberTable
	--ON PT.ParticipantID = BibNumberTable.ParticipantID
	--	AND TE.EventID = BibNumberTable.EventID
	WHERE PTIE.IsActive = 1
	AND (TE.EventID = @n_EventID OR @n_EventID IS NULL)
	ORDER BY PT.CountryID
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetEventAthletes] TO USER
GO*/

