IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_U_UpdateMember' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_U_UpdateMember
END
GO

/*************************************************************************
* Name				: SP_U_UpdateMember
* Author			: Parakop
* Create date		: 13-Sep-2015
* Description		: Update member
*************************************************************************/
CREATE PROCEDURE [SP_U_UpdateMember]
(
	@n_MemberID   					INT,
	@b_Image						VARBINARY(MAX),
	@n_ModifiedBy					INT,
	@d_ModifiedDateTime				DATETIME
)
AS
BEGIN



	UPDATE ac_RegistrationDetails
	Set BarCode         = @b_Image		
	WHERE MemberID = @n_MemberID

	
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_U_UpdateMember] TO USER
GO*/