﻿create view [dbo].[vwRo_Motivo_Prestamo]
as

SELECT     CodCatalogo, IdCatalogo, ca_descripcion, IdTipoCatalogo, ca_orden, ca_estado
FROM         dbo.ro_catalogo
WHERE     (IdTipoCatalogo = 15)