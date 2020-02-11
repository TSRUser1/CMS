IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetPartcipantAndStatistic' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetPartcipantAndStatistic
END
GO

/*************************************************************************
* Name				: SP_S_GetPartcipantAndStatistic
* Author			: Ramani Ganason
* Create date		: 01-Oct-2015
* Description		: Return Single Participant And Statistic for Schedule
*************************************************************************/
CREATE PROCEDURE [SP_S_GetPartcipantAndStatistic]
(
	@n_ScheduleID			int
)
AS
BEGIN
		SELECT	PIC.ParticipantInScheduleID
			  ,PIC.ScheduleID
			  ,PIC.TeamID
			  ,PIC.ParticipantID
			  ,UPPER(TP.FullName) AS FullName
			  ,TP.FamilyName
			  ,TP.AccreditationNumber
			  ,TP.DateOfBirth
			  ,TP.CountryID
			  ,TC.CountryNameShort AS CountryName
			  ,TC.IconFilePath AS CountryImage
			  ,TS.StatisticID
			  ,TS.Statistic1
			  ,TS.Statistic2
			  ,TS.Statistic3
			  ,TS.Statistic4
			  ,TS.Statistic5
			  ,TS.Statistic6
			  ,TS.Statistic7
			  ,TS.Statistic8
			  ,TS.Statistic9
			  ,TS.Statistic10
			  ,PIC.IsActive
			  ,PIC.CreatedBy
			  ,PIC.CreatedDateTime
			  ,PIC.ModifiedBy
			  ,PIC.ModifiedDateTime
		FROM	T_ParticipantInSchedule AS PIC
		LEFT JOIN T_Participant AS TP ON PIC.ParticipantID = TP.ParticipantID
		LEFT JOIN T_Country AS TC ON TP.CountryID = TC.CountryID
		LEFT JOIN T_Statistic AS TS ON TS.StatisticID = PIC.StatisticID AND TS.IsActive = 1
		WHERE	PIC.ScheduleID = @n_ScheduleID and PIC.IsActive = 1
		ORDER BY PIC.SortID, TP.CountryID
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetPartcipantAndStatistic] TO USER
GO*/