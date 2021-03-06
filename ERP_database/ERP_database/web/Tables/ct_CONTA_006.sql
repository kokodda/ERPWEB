﻿CREATE TABLE [web].[ct_CONTA_006] (
    [IdUsuario]            VARCHAR (50)    NOT NULL,
    [IdEmpresa]            INT             NOT NULL,
    [IdCtaCble]            VARCHAR (20)    NOT NULL,
    [pc_Cuenta]            VARCHAR (1000)  NOT NULL,
    [IdCtaCblePadre]       VARCHAR (20)    NULL,
    [EsCtaUtilidad]        BIT             NOT NULL,
    [IdNivelCta]           INT             NOT NULL,
    [IdGrupoCble]          VARCHAR (5)     NOT NULL,
    [gc_GrupoCble]         VARCHAR (50)    NOT NULL,
    [gc_estado_financiero] VARCHAR (50)    NOT NULL,
    [gc_Orden]             INT             NOT NULL,
    [EsCuentaMovimiento]   BIT             NOT NULL,
    [Naturaleza]           VARCHAR (2)     NOT NULL,
    [Enero]                NUMERIC (18, 2) NOT NULL,
    [Febrero]              NUMERIC (18, 2) NOT NULL,
    [Marzo]                NUMERIC (18, 2) NOT NULL,
    [Abril]                NUMERIC (18, 2) NOT NULL,
    [Mayo]                 NUMERIC (18, 2) NOT NULL,
    [Junio]                NUMERIC (18, 2) NOT NULL,
    [Julio]                NUMERIC (18, 2) NOT NULL,
    [Agosto]               NUMERIC (18, 2) NOT NULL,
    [Septiembre]           NUMERIC (18, 2) NOT NULL,
    [Octubre]              NUMERIC (18, 2) NOT NULL,
    [Noviembre]            NUMERIC (18, 2) NOT NULL,
    [Diciembre]            NUMERIC (18, 2) NOT NULL,
    [Total]                NUMERIC (18, 2) NOT NULL,
    CONSTRAINT [PK_ct_CONTA_006_1] PRIMARY KEY CLUSTERED ([IdUsuario] ASC, [IdEmpresa] ASC, [IdCtaCble] ASC)
);

