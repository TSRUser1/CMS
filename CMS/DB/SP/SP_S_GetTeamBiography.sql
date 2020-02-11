IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetTeamBiography' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetTeamBiography
END
GO

/*************************************************************************
* Name				: SP_S_GetTeamBiography
* Author			: DEV001
* Create date		: 26-Jul-2015
* Description		: Return participant in event
*************************************************************************/
CREATE PROCEDURE [SP_S_GetTeamBiography]
(
	@n_TeamID			int
)
AS
BEGIN
	SELECT		pie.ParticipantID,
				UPPER(tp.FullName) AS FullName,
				TC.CountryID,
				TC.CountryName,
				TC.IconFilePath AS BigCountryImage,
				TP.DateOfBirth,
				ISNULL(NULLIF(TP.CardPhotoPathThumbnail,''), '~/img/player/avatar.png') AS CardPhotoPathThumbnail,
				pie.TeamID,
				pie.IsActive
    FROM dbo.T_ParticipantInEvent pie
	INNER JOIN dbo.T_Event e
	ON pie.EventID = e.EventID
	INNER JOIN dbo.T_Schedule s
	ON pie.EventID = s.EventID
	LEFT JOIN dbo.T_ParticipantInSchedule pis
	ON s.scheduleID = pis.scheduleID 
	AND pis.ParticipantID = pie.ParticipantID
	INNER JOIN T_Participant AS TP 
	ON pie.participantID = TP.ParticipantID
	AND TP.MainCategoryId = 19
	INNER JOIN T_Country AS TC 
	ON TP.CountryID = TC.CountryID
	WHERE pie.IsActive = 1
	AND(pie.TeamID = @n_TeamID)
	GROUP BY pie.ParticipantID,
			tp.FullName,
			TC.CountryID,
			TC.CountryName,
			TC.IconFilePath,
			TP.DateOfBirth,
			TP.CardPhotoPathThumbnail,
			pie.TeamID,
			pie.IsActive
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetTeamBiography] TO USER
GO*/