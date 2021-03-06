IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_S_GetAllMember' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_S_GetAllMember
END
GO

/*************************************************************************
* Name				: SP_S_GetAllMember
* Author			: Parakop
* Create date		: 13-Sep-2015
* Description		: Return member
*************************************************************************/
CREATE PROCEDURE SP_S_GetAllMember
AS
BEGIN
	
	SELECT MemberID
	  FROM ac_RegistrationDetails
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_S_GetAllMember] TO USER
GO*/
