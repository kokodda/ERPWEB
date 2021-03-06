﻿CREATE VIEW [web].[VWFAC_018]
AS
SELECT nc.IdEmpresa, nc.IdSucursal, nc.IdBodega, nc.IdNota, s.Su_Descripcion, nc.no_fecha, nc.IdCliente, t.IdTipoNota, t.No_Descripcion, 
                  CASE WHEN nc.NaturalezaNota = 'SRI' THEN nc.Serie1 + '-' + nc.Serie2 + '-' + nc.NumNota_Impresa ELSE CAST(NC.IdNota AS VARCHAR(20)) END AS NumNota, p.pe_nombreCompleto, p.pe_cedulaRuc, ISNULL(ncx.Valor_Aplicado, 0) 
                  AS ValorAplicado, 
                  (CASE WHEN ncx.vt_tipoDoc = 'FACT' THEN f.vt_serie1 + '-' + f.vt_serie2 + '-' + f.vt_NumFactura ELSE CASE WHEN nd.NaturalezaNota = 'SRI' THEN nd.Serie1 + '-' + nd.Serie2 + '-' + nd.NumNota_Impresa ELSE 
				  ISNULL(ND.CODNOTA, CAST(nd.IdNota AS varchar(20))) END END) AS NumDocumentoAplica, ncx.NumDocumento AS NumDocumentoReemplazo, ncd.SubtotalSinIVAConDscto AS Subtotal0, ncd.SubtotalIVAConDscto AS SubtotalIVA, ncd.ValorIVA, ncd.Total, nc.Estado, 
                  CASE WHEN nc.Estado = 'I' THEN 'ANULADAS' ELSE 'ACTIVAS' END AS NomEstado, CASE WHEN nc.Estado = 'I' THEN 2 ELSE 1 END AS Orden, nc.CreDeb, nc.NaturalezaNota
FROM     dbo.fa_notaCreDeb AS nc LEFT OUTER JOIN
                  dbo.fa_notaCreDeb_x_fa_factura_NotaDeb AS ncx ON nc.IdEmpresa = ncx.IdEmpresa_nt AND nc.IdSucursal = ncx.IdSucursal_nt AND nc.IdBodega = ncx.IdBodega_nt AND nc.IdNota = ncx.IdNota_nt INNER JOIN
                  dbo.fa_cliente AS c ON nc.IdEmpresa = c.IdEmpresa AND nc.IdCliente = c.IdCliente INNER JOIN
                  dbo.tb_persona AS p ON c.IdPersona = p.IdPersona LEFT OUTER JOIN
                  dbo.fa_TipoNota AS t ON t.IdEmpresa = nc.IdEmpresa AND t.IdTipoNota = nc.IdTipoNota INNER JOIN
                  dbo.tb_sucursal AS s ON s.IdEmpresa = nc.IdEmpresa AND s.IdSucursal = nc.IdSucursal LEFT OUTER JOIN
                  dbo.fa_factura AS f ON ncx.IdEmpresa_fac_nd_doc_mod = f.IdEmpresa AND f.IdSucursal = ncx.IdSucursal_fac_nd_doc_mod AND f.IdBodega = ncx.IdBodega_fac_nd_doc_mod AND f.IdCbteVta = ncx.IdCbteVta_fac_nd_doc_mod AND 
                  f.vt_tipoDoc = ncx.vt_tipoDoc LEFT OUTER JOIN
                  dbo.fa_notaCreDeb AS nd ON ncx.IdEmpresa_fac_nd_doc_mod = nd.IdEmpresa AND ncx.IdSucursal_fac_nd_doc_mod = nd.IdSucursal AND ncx.IdBodega_fac_nd_doc_mod = nd.IdBodega AND ncx.IdCbteVta_fac_nd_doc_mod = nd.IdNota AND 
                  ncx.vt_tipoDoc = nd.CodDocumentoTipo LEFT OUTER JOIN
                  dbo.fa_notaCreDeb_resumen AS ncd ON nc.IdEmpresa = ncd.IdEmpresa AND nc.IdSucursal = ncd.IdSucursal AND nc.IdBodega = ncd.IdBodega AND nc.IdNota = ncd.IdNota