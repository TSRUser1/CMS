IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetParticipantBiography' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetParticipantBiography
END
GO

/*************************************************************************
* Name				: SP_S_GetParticipantBiography
* Author			: Edwind
* Create date		: 1-Sep-2015
* Description		: Return participant biography by participantid
*************************************************************************/
CREATE PROCEDURE [dbo].[SP_S_GetParticipantBiography]
(
	@n_ParticipantID			int
)
AS
BEGIN
	SELECT 
		PT.ParticipantID,
		ISNULL(NULLIF(PT.CardPhotoPath,''), '~/img/player/avatar-big.jpg') AS [ParticipantImageFilePath],
		UPPER(PT.FullName) AS FullName,
		TC.CountryID,
		TC.CountryName,
		TC.IconFilePath AS FlagImageFilePath,
		PT.DateOfBirth,
		CASE TRG.ReferenceName 
		WHEN 'Men' THEN 'Male' 
		WHEN 'Women' THEN 'Female'
		ELSE '' 
		END AS Gender,
		PT.[Height],
		PT.[Weight],
		SP.SportID,
		SP.SportName
	FROM T_Participant PT
	INNER JOIN T_Country TC
	ON PT.CountryID = TC.CountryID
		AND TC.IsActive = 1
	INNER JOIN T_ParticipantInEvent  PTIE
	ON PT.ParticipantID = PTIE.ParticipantID
		AND PTIE.IsActive = 1
	INNER JOIN T_Event  EV
	ON PTIE.EventID = EV.EventID
		AND EV.IsActive = 1
	LEFT JOIN T_Sport  SP
	ON EV.SportID = SP.SportID
		AND EV.IsActive = 1
	LEFT JOIN T_Reference TRG
	ON TRG.ReferenceInternalID = PT.GenderID 
		AND TRG.ReferenceCategoryID = 2
	WHERE PT.IsActive = 1
	AND (PT.ParticipantID = @n_ParticipantID OR @n_ParticipantID IS NULL)
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetParticipantBiography] TO USER
GO*/