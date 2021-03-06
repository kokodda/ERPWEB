﻿CREATE VIEW dbo.vwct_CentroCosto
AS
SELECT dbo.ct_CentroCosto.IdEmpresa, dbo.ct_CentroCosto.IdCentroCosto, dbo.ct_CentroCosto.IdCentroCostoPadre, dbo.ct_CentroCosto.IdNivel, dbo.ct_CentroCosto.cc_Descripcion, dbo.ct_CentroCosto.EsMovimiento, 
                  dbo.ct_CentroCosto.Estado, dbo.ct_CentroCostoNivel.nv_Descripcion, ct_CentroCosto_1.cc_Descripcion AS cc_Descripcion_Padre
FROM     dbo.ct_CentroCosto INNER JOIN
                  dbo.ct_CentroCostoNivel ON dbo.ct_CentroCosto.IdEmpresa = dbo.ct_CentroCostoNivel.IdEmpresa AND dbo.ct_CentroCosto.IdNivel = dbo.ct_CentroCostoNivel.IdNivel LEFT OUTER JOIN
                  dbo.ct_CentroCosto AS ct_CentroCosto_1 ON dbo.ct_CentroCosto.IdEmpresa = ct_CentroCosto_1.IdEmpresa AND dbo.ct_CentroCosto.IdCentroCostoPadre = ct_CentroCosto_1.IdCentroCosto
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwct_CentroCosto';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[12] 2[27] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ct_CentroCosto"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 247
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ct_CentroCostoNivel"
            Begin Extent = 
               Top = 4
               Left = 340
               Bottom = 134
               Right = 549
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ct_CentroCosto_1"
            Begin Extent = 
               Top = 120
               Left = 706
               Bottom = 250
               Right = 915
            End
            DisplayFlags = 280
            TopColumn = 2
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 10
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwct_CentroCosto';



