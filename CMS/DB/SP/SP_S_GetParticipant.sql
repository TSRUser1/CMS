IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetParticipant' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetParticipant
END
GO

/*************************************************************************
* Name				: SP_S_GetParticipant
* Author			: DEV001
* Create date		: 26-Jul-2015
* Description		: Return participant detail
*************************************************************************/
CREATE PROCEDURE [SP_S_GetParticipant]
(
	@n_ParticipantID			int,
	@n_SportID					int,
	@n_EventID					int,
	@s_PassportNumber	        nvarchar(100),
	@s_FullName					nvarchar(100)

)
AS
BEGIN
	SELECT DISTINCT
	  PT.ParticipantID,
	  UPPER(PT.FullName) AS FullName,
	  PT.AccreditationNumber,
	  PT.FamilyName,
	  PT.GivenName,
	  PT.PassportNumber,
	  TC.CountryID,
	  TC.CountryName,
	  TC.FlagImageFilePath,
	  PT.DateOfBirth,
	  PT.GenderID,
	  PT.IPCNo,
	  --TS.SportName,
	  --TE.EventName,
	  CASE TRG.ReferenceName
		WHEN 'Men' THEN 'Male'
		WHEN 'Women' THEN 'Female'
		WHEN 'Mixed' THEN 'Mixed'
		ELSE ''
	  END AS Gender,
	  PT.Height,
	  PT.[Weight],
	  PT.CardPhotoPath,
	  PT.CardPhotoPathThumbnail,
	  PT.CardPhotoPathExternal,
	  PT.MainCategoryID
	FROM T_Participant PT
	INNER JOIN T_Country TC
	  ON PT.CountryID = TC.CountryID
	  AND TC.IsActive = 1
	LEFT JOIN T_Reference TRG
	  ON TRG.ReferenceInternalID = PT.GenderID
	  AND TRG.ReferenceCategoryID = 2
	WHERE PT.IsActive = 1
	AND (PT.ParticipantID = @n_ParticipantID OR @n_ParticipantID IS NULL)
	AND (PT.ParticipantID IN ( SELECT ParticipantID FROM 
								T_ParticipantInEvent
								WHERE EventID = @n_EventID
								AND IsActive = 1 ) OR @n_EventID IS NULL)
	AND (PT.ParticipantID IN ( SELECT PIE.ParticipantID
								FROM T_ParticipantInEvent AS PIE
								INNER JOIN T_Event AS E
								ON E.EventID = PIE.EventID
								AND E.IsActive = 1
								WHERE E.SportID = @n_SportID) OR @n_SportID IS NULL)
	AND (PT.FullName LIKE '%' + @s_FullName + '%' OR ISNULL(@s_FullName, '') = '')
	AND (PT.PassportNumber = @s_PassportNumber OR ISNULL(@s_PassportNumber, '') = '')
	ORDER BY FullName
	END
GO

SET QUOTED_IDENTIFIER OFF 

GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetParticipant] TO USER
GO*/