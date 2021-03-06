IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetLeagueForIndividual' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetLeagueForIndividual
END
GO

/*************************************************************************
* Name				: SP_S_GetLeagueForIndividual
* Author			: Ramani
* Create date		: 18-Oct-2015
* Description		: Return League for Individual
*************************************************************************/
CREATE PROCEDURE [dbo].[SP_S_GetLeagueForIndividual]
(
	@n_EventID			int,
	@s_GroupCode		nvarchar(100)
)
AS
BEGIN

SELECT
	NULL as ParticipantInEventID,
	@n_EventID AS EventID,
	@s_GroupCode AS GroupCode,
	NULL as ParticipantID,
	'Lg Name' as FullName,
	NULL as CountryID,
	NULL as CountryName,
	NULL as IconFilePath,
	NULL as LeagueID,
	0 AS Rank,
	'' AS League1,
	'' AS League2,
	'' AS League3,
	'' AS League4,
	'' AS League5,
	'' AS League6,
	'' AS League7,
	'' AS League8,
	'' AS League9,
	'' AS League10,
	'' AS League11,
	'' AS League12,
	'' AS League13,
	'' AS League14,
	'' AS League15,
	'' AS League16,
	'' AS League17,
	'' AS League18,
	'' AS League19,
	'' AS League20
	WHERE NOT EXISTS( SELECT *
			FROM
				T_League TL
				INNER JOIN T_LeagueInParticipantInEvent TLP ON TL.LeagueID = TLP.LeagueID
			WHERE 
				TLP.EventID = @n_EventID 
				AND TL.Rank = 0 
				AND (TLP.GroupCode = @s_GroupCode OR @s_GroupCode IS NULL)	)
UNION
SELECT 
	NULL as ParticipantInEventID,
	TLP.EventID,
	TLP.GroupCode,
	NULL as ParticipantID,
	NULL as FullName,
	NULL as CountryID,
	NULL as CountryName,
	NULL as IconFilePath,
	TL.LeagueID,
	ISNULL(TL.Rank,1) AS Rank,
	TL.League1,
	TL.League2,
	TL.League3,
	TL.League4,
	TL.League5,
	TL.League6,
	TL.League7,
	TL.League8,
	TL.League9,
	TL.League10,
	TL.League11,
	TL.League12,
	TL.League13,
	TL.League14,
	TL.League15,
	TL.League16,
	TL.League17,
	TL.League18,
	TL.League19,
	TL.League20
FROM
	T_League TL
	INNER JOIN T_LeagueInParticipantInEvent TLP ON TL.LeagueID = TLP.LeagueID
WHERE 
	TLP.EventID = @n_EventID 
	AND TL.Rank = 0 
	AND (TLP.GroupCode = @s_GroupCode OR @s_GroupCode IS NULL)
UNION
SELECT DISTINCT 
	TPIE.ParticipantInEventID
	,TS.EventID
	,TS.GroupCode
	,TP.ParticipantID
	,TP.FullName
	,TC.CountryID
	,TC.CountryName
	,TC.IconFilePath AS IconFilePath
	,TL.LeagueID
	,ISNULL(TL.Rank,1) AS Rank
	,TL.League1
	,TL.League2
	,TL.League3
	,TL.League4
	,TL.League5
	,TL.League6
	,TL.League7
	,TL.League8
	,TL.League9
	,TL.League10
	,TL.League11
	,TL.League12
	,TL.League13
	,TL.League14
	,TL.League15
	,TL.League16
	,TL.League17
	,TL.League18
	,TL.League19
	,TL.League20
FROM 
	T_Schedule TS
	LEFT JOIN T_ParticipantInSchedule TPIS ON TPIS.ScheduleID = TS.ScheduleID
	LEFT JOIN T_Participant TP ON TP.ParticipantID = TPIS.ParticipantID
	LEFT JOIN T_Country TC ON TC.CountryID = TP.CountryID
	LEFT JOIN T_ParticipantInEvent TPIE ON TPIE.ParticipantID = TP.ParticipantID AND TPIE.IsActive = 1 AND TPIE.EventID = @n_EventID
	LEFT JOIN T_LeagueInParticipantInEvent TLIE ON TPIE.ParticipantInEventID = TLIE.ParticipantInEventID
	LEFT JOIN T_League TL ON TL.LeagueID = TLIE.LeagueID
WHERE
	TS.EventID = @n_EventID
	AND (TS.GroupCode = @s_GroupCode OR @s_GroupCode IS NULL)
	AND TS.IsActive = 1
	AND TPIS.IsActive = 1
	--AND TS.IsPublishStartList = 1
	AND TS.PlayFormatID = 2
	--AND Rank <> 0
ORDER BY
	Rank
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetLeagueForIndividual] TO USER
GO*/
