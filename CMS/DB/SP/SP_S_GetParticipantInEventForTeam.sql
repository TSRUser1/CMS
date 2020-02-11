IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetParticipantInEventForTeam' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetParticipantInEventForTeam
END
GO

/*************************************************************************
* Name				: SP_S_GetParticipantInEventForTeam
* Author			: DEV001
* Create date		: 26-Jul-2015
* Description		: Return participant in event
*************************************************************************/
CREATE PROCEDURE [SP_S_GetParticipantInEventForTeam]
(
	@n_CountryID				int,
	@n_EventID					int
)
AS
BEGIN
	SELECT DISTINCT
		PTIE.ParticipantInEventID,
		PT.ParticipantID,
		UPPER(PT.FullName) AS FullName,
		PT.FamilyName,
		PT.GivenName,
		PT.PassportNumber,
		TC.CountryID,
		TC.CountryName,
		TC.SmallIconFilePath,
		TC.FlagImageFilePath,
		SP.SportID,
		SP.SportName,
		CASE TRG.ReferenceName
		WHEN 'Men' THEN 'Male'
		WHEN 'Women' THEN 'Female'
		WHEN 'Mixed' THEN 'Mixed'
		ELSE ''
		END AS Gender,
		PT.AccreditationNumber
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
	INNER JOIN T_Sport  SP
	ON EV.SportID = SP.SportID
		AND EV.IsActive = 1
	LEFT JOIN T_Reference TRG
	  ON TRG.ReferenceInternalID = PT.GenderID
	  AND TRG.ReferenceCategoryID = 2
	WHERE PT.IsActive = 1
	AND (PT.CountryID = @n_CountryID OR @n_CountryID IS NULL)
	AND (EV.EventID = @n_EventID OR @n_EventID IS NULL)
	ORDER BY TC.CountryName, FullName
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetParticipantInEventForTeam] TO USER
GO*/