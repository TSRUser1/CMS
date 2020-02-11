IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_U_UpdateParticipantDetail' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_U_UpdateParticipantDetail
END
GO

/*************************************************************************
* Name				: SP_U_UpdateParticipantDetail
* Author			: DEV001
* Create date		: 22-Aug-2015
* Description		: Update Schedule detail
*************************************************************************/
CREATE PROCEDURE [SP_U_UpdateParticipantDetail]
(
	@n_ParticipantID			int,
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
    @n_IsActive					int,
	@n_ModifiedBy				int,
	@d_ModifiedDateTime			datetime,
	@s_IPCNo					nvarchar(100),
	@s_CardPhotoPath			NVARCHAR(MAX),
	@s_CardPhotoPathThumbnail	NVARCHAR(MAX),
	@s_CardPhotoPathExternal	NVARCHAR(MAX)
)
AS
BEGIN
	UPDATE dbo.T_Participant
	   SET FullName = ISNULL(@s_FullName, FullName)
		  ,FamilyName = ISNULL(@s_FamilyName, FamilyName)
		  ,GivenName = ISNULL(@s_GivenName, GivenName)
		  ,Height = ISNULL(@n_Height, Height)
		  ,[Weight] = ISNULL(@n_Weight, [Weight])
		  ,AccreditationNumber = ISNULL(@s_AccreditationNumber, AccreditationNumber)
		  ,DateOfBirth = ISNULL(@d_DateOfBirth, DateOfBirth)
		  ,GenderID = ISNULL(@n_GenderID, GenderID)
		  ,CountryID = ISNULL(@n_CountryID, CountryID)
		  ,PassportNumber = ISNULL(@s_PassportNumber, PassportNumber)
		  ,MainCategoryID = ISNULL(@n_MainCategoryID, MainCategoryID)
		  ,IsActive = @n_IsActive
		  ,ModifiedDateTime = @d_ModifiedDateTime
		  ,ModifiedBy = @n_ModifiedBy
		  ,IPCNo = ISNULL(@s_IPCNo, IPCNo)
		  ,CardPhotoPath = ISNULL(@s_CardPhotoPath, CardPhotoPath)
		  ,CardPhotoPathThumbnail = ISNULL(@s_CardPhotoPathThumbnail, CardPhotoPathThumbnail)
		  ,CardPhotoPathExternal = ISNULL(@s_CardPhotoPathExternal, CardPhotoPathExternal)
	 WHERE ParticipantID = @n_ParticipantID
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_U_UpdateParticipantDetail] TO USER
GO*/