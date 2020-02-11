IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetParticipantInTeam' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetParticipantInTeam
END
GO

/*************************************************************************
* Name				: SP_S_GetParticipantInTeam
* Author			: Edwind
* Create date		: 1-Sep-2015
* Description		: Return participant details by teamID
*************************************************************************/
CREATE PROCEDURE SP_S_GetParticipantInTeam
(
	@n_TeamID			int
)
AS
BEGIN
	
	SELECT 
		PTIE.ParticipantInEventID,
		PT.ParticipantID,
		UPPER(PT.FullName) AS FullName,
		PT.FamilyName,
		PT.GivenName,
		PT.PassportNumber,
		TC.CountryID,
		TC.CountryName,
		TC.FlagImageFilePath,
		PT.DateOfBirth,
		CASE TRG.ReferenceName 
		WHEN 'Men' THEN 'Male' 
		WHEN 'Women' THEN 'Female'
		ELSE '' 
		END AS Gender,
		PT.[Height],
		PT.[Weight],
		SP.SportID,
		SP.SportName,
		PT.AccreditationNumber
	FROM T_Participant PT
	INNER JOIN T_Country TC
	ON PT.CountryID = TC.CountryID
		AND TC.IsActive = 1
	INNER JOIN T_ParticipantInEvent  PTIE
	ON PT.ParticipantID = PTIE.ParticipantID
		AND PTIE.IsActive = 1
		AND PTIE.TeamID = @n_TeamID
	INNER JOIN T_Event  EV
	ON PTIE.EventID = EV.EventID
		AND EV.IsActive = 1
	INNER JOIN T_Sport  SP
	ON EV.SportID = SP.SportID
		AND EV.IsActive = 1
	LEFT JOIN T_Reference TRG
	ON TRG.ReferenceInternalID = PT.GenderID 
		AND TRG.ReferenceCategoryID = 2
	WHERE PT.IsActive = 1
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetParticipantDetail] TO USER
GO*/


