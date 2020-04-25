CREATE SCHEMA Hospital;
GO

-- CAUTION: Drops tables created by the wizard
DROP TABLE IF EXISTS Hospital.PatientStayTreatement_Data_FULL;
DROP TABLE IF EXISTS Hospital.PatientStayCondition_Data_FULL;
DROP TABLE IF EXISTS Hospital.PatientStayDoctor_Data_FULL;
DROP TABLE IF EXISTS Hospital.PatientStay_Data_FULL;
DROP TABLE IF EXISTS Hospital.Treatment_Data_FULL;
DROP TABLE IF EXISTS Hospital.Condition_Data_FULL;
DROP TABLE IF EXISTS Hospital.Doctor_Data_Full;
DROP TABLE IF EXISTS Hospital.Patients_Data_FULL;
DROP TABLE IF EXISTS Hospital.Contacts_Data_Full;
GO

DROP TABLE IF EXISTS Hospital.PatientStayTreatment;
DROP TABLE IF EXISTS Hospital.PatientStayCondtion;
DROP TABLE IF EXISTS Hospital.PatientStayDoctor;
DROP TABLE IF EXISTS Hospital.PatientStay;
DROP TABLE IF EXISTS Hospital.Treatment;
DROP TABLE IF EXISTS Hospital.Condition;
DROP TABLE IF EXISTS Hospital.Doctor;
DROP TABLE IF EXISTS Hospital.Patient;
DROP TABLE IF EXISTS Hospital.ContactInfo;

CREATE TABLE Hospital.ContactInfo
(
   ContactInfoID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
   FirstName NVARCHAR(64) NOT NULL,
   LastName NVARCHAR(64) NOT NULL,
   PhoneNumber NVARCHAR(64) NOT NULL UNIQUE,
   Email NVARCHAR(64) NOT NULL UNIQUE,
   AddressLine NVARCHAR(64) NOT NULL,
   City NVARCHAR(64) NOT NULL,
   [State] NVARCHAR(64) NOT NULL,
   ZipCode NVARCHAR(64) NOT NULL,
   Country NVARCHAR(64) NOT NULL,
   IsRemoved INT NOT NULL,
   CreatedOn DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET()),
   UpdatedOn DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET())
);

CREATE TABLE Hospital.Patient
(
    PatientID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    ContactInfoID INT NOT NULL UNIQUE FOREIGN KEY
        REFERENCES Hospital.ContactInfo(ContactInfoID),
    EmergencyContactInfoID INT NOT NULL FOREIGN KEY
        REFERENCES Hospital.ContactInfo(ContactInfoID),
    BirthDate DATETIME NOT NULL,
    Sex INT NOT NULL,
    IsRemoved INT NOT NULL,
    CreatedOn DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET()),
    UpdatedOn DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET())
);

CREATE TABLE Hospital.Doctor
(
    DoctorID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    ContactInfoID INT NOT NULL UNIQUE FOREIGN KEY
        REFERENCES Hospital.ContactInfo(ContactInfoID),
    PracticeStartDate DATETIME NOT NULL,
    Degree NVARCHAR(64) NOT NULL,
    Unit NVARCHAR(64) NOT NULL,
    IsRemoved INT NOT NULL,
    CreatedOn DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET()),
    UpdatedOn DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET())
);

CREATE TABLE Hospital.Condition
(
    ConditionID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    CommonName NVARCHAR(64) NOT NULL,
    TechnicalName NVARCHAR(64) NOT NULL UNIQUE,
    IsRemoved INT NOT NULL,
    CreatedOn DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET()),
    UpdatedOn DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET())
);

CREATE TABLE Hospital.Treatment
(
    TreatmentID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    [Name] NVARCHAR(64) NOT NULL,
    ApplicationFrequency NVARCHAR(64) NOT NULL,
    ApplicationType NVARCHAR(64) NOT NULL,
    IsRemoved INT NOT NULL,
    CreatedOn DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET()),
    UpdatedOn DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET())
);

CREATE TABLE Hospital.PatientStay
(
    PatientStayID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    PatientID  INT NOT NULL FOREIGN KEY
        REFERENCES Hospital.Patient(PatientID),
    AdmittanceDate DATETIME NOT NULL,
    DischargeDate DATETIME NOT NULL,
    Unit NVARCHAR(64) NOT NULL,
    RoomNumber INT NOT NULL,
    IsRemoved INT NOT NULL,
    CreatedOn DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET()),
    UpdatedOn DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET())
);

CREATE TABLE Hospital.PatientStayDoctor
(
    PatientStayID INT NOT NULL FOREIGN KEY
        REFERENCES Hospital.PatientStay(PatientStayID),
    DoctorID INT NOT NULL FOREIGN KEY
        REFERENCES Hospital.Doctor(DoctorID),
    IsRemoved INT NOT NULL,
    CreatedOn DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET()),
    UpdatedOn DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET()),
    PRIMARY KEY (PatientStayID, DoctorID)
);

CREATE TABLE Hospital.PatientStayCondtion
(
    PatientStayID INT NOT NULL FOREIGN KEY
        REFERENCES Hospital.PatientStay(PatientStayID),
    ConditionID INT NOT NULL FOREIGN KEY
        REFERENCES Hospital.Condition(ConditionID),
    IsRemoved INT NOT NULL,
    CreatedOn DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET()),
    UpdatedOn DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET()),
    PRIMARY KEY (PatientStayID, ConditionID)
);

CREATE TABLE Hospital.PatientStayTreatment
(
    PatientStayID INT NOT NULL FOREIGN KEY
        REFERENCES Hospital.PatientStay(PatientStayID),
    TreatmentID INT NOT NULL FOREIGN KEY
        REFERENCES Hospital.Treatment(TreatmentID),
    IsRemoved INT NOT NULL,
    CreatedOn DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET()),
    UpdatedOn DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET()),
    PRIMARY KEY (PatientStayID, TreatmentID)
);
GO