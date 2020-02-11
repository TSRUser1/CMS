IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetParticipantList' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetParticipantList
END
GO

/*************************************************************************
* Name				: SP_S_GetParticipantList
* Author			: Edwind
* Create date		: 1-Sep-2015
* Description		: Return participant list by name, country and sport
*************************************************************************/
CREATE PROCEDURE SP_S_GetParticipantList
(
	@s_FullName					nvarchar(MAX),
	@n_CountryID				int,
	@n_SportID					int
)
AS
BEGIN
	SELECT DISTINCT
		PT.ParticipantID,
		UPPER(PT.FullName) AS FullName,
		ISNULL(NULLIF(PT.CardPhotoPath,''), '~/img/player/avatar.png') AS [ParticipantImageFilePath],
		ISNULL(NULLIF(PT.CardPhotoPathThumbnail,''), '~/img/player/avatar.png') AS [ParticipantImageFilePathTB],
		TC.CountryID,
		TC.CountryName,
		TC.SmallIconFilePath,
		TC.FlagImageFilePath,
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
	INNER JOIN T_Sport  SP
	ON EV.SportID = SP.SportID
		AND EV.IsActive = 1
	WHERE PT.IsActive = 1
	AND (PT.FullName LIKE '%' + @s_FullName + '%' OR @s_FullName IS NULL OR @s_FullName = '')
	AND (PT.CountryID = @n_CountryID OR @n_CountryID IS NULL)
	AND (SP.SportID = @n_SportID OR @n_SportID IS NULL)
	AND MainCategoryId = 19
	ORDER BY TC.CountryName, FullName
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetParticipantList] TO USER
GO*/


