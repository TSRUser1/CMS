IF EXISTS 
(
	SELECT	* 
	FROM	sys.objects 
	WHERE	type = 'P' 
			AND	name = 'SP_U_UpdateZoneAccessColorCode' 
			AND schema_name(schema_id) = 'dbo'
)
BEGIN
	DROP  PROCEDURE  SP_U_UpdateZoneAccessColorCode
END
GO

/*************************************************************************
* Name				: SP_U_UpdateZoneAccessColorCode
* Author			: Parakop
* Create date		: 13-Sep-2015
* Description		: Update member
*************************************************************************/
CREATE PROCEDURE [SP_U_UpdateZoneAccessColorCode]
(
	@n_Id   					INT,
	@b_ColorImage						VARBINARY(MAX)
)
AS
BEGIN



	UPDATE ac_ZoneAccess
	Set ColorImage = @b_ColorImage		
	WHERE Id = @n_Id

	
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
GRANT EXEC ON [dbo].[SP_U_UpdateZoneAccessColorCode] TO USER
GO*/