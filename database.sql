-- Base de données du cabinet médical (SQL Server).
-- Schéma reconstitué à partir des requêtes de l'application :
-- adaptez les types si votre base d'origine est différente.

IF DB_ID('gestion_hopital') IS NULL
    CREATE DATABASE gestion_hopital;
GO

USE gestion_hopital;
GO

CREATE TABLE MEDECIN (
    id_MEDECIN INT IDENTITY(1,1) PRIMARY KEY,
    cin_med    NVARCHAR(20)  NOT NULL UNIQUE,
    nom_med    NVARCHAR(100) NOT NULL,
    tel_med    NVARCHAR(20)  NULL
);

CREATE TABLE PATIENT (
    id_PATIENT INT IDENTITY(1,1) PRIMARY KEY,
    cin_pat    NVARCHAR(20)  NOT NULL UNIQUE,
    nom_pat    NVARCHAR(100) NOT NULL,
    tel_pat    NVARCHAR(20)  NULL
);

CREATE TABLE MEDICAMENT (
    nom_medoc NVARCHAR(100) NOT NULL PRIMARY KEY
);

CREATE TABLE CONSULTATION (
    id_CONSULTATION INT IDENTITY(1,1) PRIMARY KEY,
    prix_cons       DECIMAL(10,2) NOT NULL,
    date_cons       DATETIME      NOT NULL,
    id_PATIENT      INT NOT NULL REFERENCES PATIENT(id_PATIENT),
    id_MEDECIN      INT NOT NULL REFERENCES MEDECIN(id_MEDECIN)
);
GO

-- Médecin de démonstration pour pouvoir se connecter (nom + CIN).
INSERT INTO MEDECIN (cin_med, nom_med, tel_med) VALUES (N'AB12345', N'admin', N'0600000000');
GO
