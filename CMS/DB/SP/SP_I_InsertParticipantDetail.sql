IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_I_InsertParticipantDetail' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_I_InsertParticipantDetail
END
GO

/*************************************************************************
* Name				: SP_I_InsertParticipantDetail
* Author			: DEV001
* Create date		: 25-Aug-2015
* Description		: Insert Participant detail
*************************************************************************/
CREATE PROCEDURE [SP_I_InsertParticipantDetail]
(
	@s_FullName	  				nvarchar(100),
    @s_FamilyName	   			nvarchar(100),
	@s_GivenName				nvarchar(100),
    @n_Height					decimal(4,0),
    @n_Weight					decimal(4,0),
	@s_AccreditationNumber		nvarchar(100),
	@d_DateOfBirth				datetime,
    @n_GenderID					int,
    @n_CountryID				int,
    @s_PassportNumber			nvarchar(50),
	@n_MainCategoryID			int,
	@s_CardPhotoPath			nvarchar(MAX),
	@s_CardPhotoPathThumbnail	nvarchar(MAX),
	@s_CardPhotoPathExternal    nvarchar(MAX),
    @n_IsActive					int,
    @d_CreatedDateTime			datetime,
    @n_CreatedBy				int,
	@s_IPCNo					nvarchar(100),
	@n_ParticipantID			int output
)
AS
BEGIN
INSERT INTO dbo.T_Participant
           (FullName
           ,FamilyName
		   ,GivenName
		   ,Height
		   ,[Weight]
		   ,AccreditationNumber
		   ,DateOfBirth
           ,GenderID
           ,CountryID
           ,PassportNumber
		   ,MainCategoryId
		   ,CardPhotoPath
		   ,CardPhotoPathThumbnail
		   ,CardPhotoPathExternal
		   ,IPCNo
           ,IsActive
           ,CreatedDateTime
           ,CreatedBy
           ,ModifiedDateTime
           ,ModifiedBy)
     VALUES
           (@s_FullName
           ,@s_FamilyName
		   ,@s_GivenName
		   ,@n_Height
		   ,@n_Weight
		   ,@s_AccreditationNumber
		   ,@d_DateOfBirth
           ,@n_GenderID
           ,@n_CountryID
           ,@s_PassportNumber
		   ,@n_MainCategoryID
		   ,NULLIF(@s_CardPhotoPath,'')
		   ,NULLIF(@s_CardPhotoPathThumbnail,'')
		   ,NULLIF(@s_CardPhotoPathExternal,'')
		   ,@s_IPCNo
           ,@n_IsActive
           ,@d_CreatedDateTime
           ,@n_CreatedBy
           ,@d_CreatedDateTime
           ,@n_CreatedBy)

	SELECT @@IDENTITY AS ParticipantID
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_I_InsertParticipantDetail] TO USER
GO*/