CREATE OR ALTER PROCEDURE Hospital.GetPatient
   @FirstName NVARCHAR(64),
   @LastName NVARCHAR(64)
AS

SELECT  CI.FirstName, CI.LastName, CI.PhoneNumber, CI.Email, P.BirthDate, P.Sex
FROM Hospital.Patient P
    INNER JOIN Hospital.ContactInfo CI ON CI.ContactInfoID = P.ContactInfoID
WHERE CI.FirstName = @FirstName AND CI.LastName = @LastName AND CI.IsRemoved = 0 AND P.IsRemoved = 0
ORDER BY CI.LastName, CI.FirstName;

EXEC Hospital.GetPatient N'Cade', N'Barrett';
GO






CREATE OR ALTER PROCEDURE Hospital.GetDoctor
   @FirstName NVARCHAR(64),
   @LastName NVARCHAR(64)
AS

SELECT CI.FirstName, CI.LastName, CI.PhoneNumber, CI.Email, D.PracticeStartDate, D.Degree, D.Unit
FROM Hospital.Doctor D
    INNER JOIN Hospital.ContactInfo CI ON CI.ContactInfoID = D.ContactInfoID
WHERE CI.FirstName = @FirstName AND CI.LastName = @LastName AND CI.IsRemoved = 0 AND D.IsRemoved = 0
ORDER BY CI.LastName, CI.FirstName;

EXEC Hospital.GetDoctor N'Lance', N'Mccarthy';
GO





CREATE OR ALTER PROCEDURE Hospital.GetPatientStays
   @PatientID INT
AS

SELECT P.PatientID, PS.AdmittanceDate, PS.DischargeDate, PS.RoomNumber, PS.Unit
FROM Hospital.Patient P
    INNER JOIN Hospital.PatientStay PS ON PS.PatientID = P.PatientID
WHERE P.PatientID = @PatientID AND P.IsRemoved = 0 AND PS.IsRemoved = 0
ORDER BY PS.AdmittanceDate DESC;

EXEC Hospital.GetPatientStays 114;
GO






CREATE OR ALTER PROCEDURE Hospital.GetPatientConditions
   @FirstName NVARCHAR(64),
   @LastName NVARCHAR(64)
AS

SELECT CI.FirstName, CI.LastName, C.CommonName, C.TechnicalName
FROM Hospital.Patient P
    INNER JOIN Hospital.ContactInfo CI ON CI.ContactInfoID = P.ContactInfoID
    INNER JOIN Hospital.PatientStay PS ON PS.PatientID = P.PatientID
    INNER JOIN Hospital.PatientStayCondtion PSC ON PSC.PatientStayID = PS.PatientStayID
    INNER JOIN Hospital.Condition C ON C.ConditionID = PSC.ConditionID
WHERE CI.FirstName = @FirstName AND CI.LastName = @LastName AND CI.IsRemoved = 0 AND P.IsRemoved = 0
    AND PS.IsRemoved = 0 AND PSC.IsRemoved = 0 AND C.IsRemoved = 0
ORDER BY CI.LastName, CI.FirstName, C.CommonName;

EXEC Hospital.GetPatientConditions N'Garrison', N'Ramos';
GO






CREATE OR ALTER PROCEDURE Hospital.GetHospitalConditionHistory
   @Name NVARCHAR(64)
AS

WITH GetDoctor(DoctorID, FirstName, LastName, Degree) AS
(
    SELECT D.DoctorID, CI.FirstName, CI.LastName, D.Degree
    FROM Hospital.Doctor D
        INNER JOIN Hospital.ContactInfo CI ON D.ContactInfoID = CI.ContactInfoID
    WHERE D.IsRemoved = 0 AND CI.IsRemoved = 0
)
SELECT C.TechnicalName, PS.PatientID, PS.AdmittanceDate, PS.DischargeDate, D.FirstName, D.LastName, D.Degree
FROM Hospital.Condition C
    INNER JOIN Hospital.PatientStayCondtion PSC ON PSC.ConditionID = C.ConditionID
    INNER JOIN Hospital.PatientStay PS ON PS.PatientStayID = PSC.PatientStayID
    INNER JOIN Hospital.PatientStayDoctor PSD ON PSD.PatientStayID = PS.PatientStayID
    INNER JOIN GetDoctor D ON D.DoctorID = PSD.DoctorID
WHERE C.TechnicalName = @Name AND C.IsRemoved = 0 AND PSC.IsRemoved = 0 AND PS.IsRemoved = 0 AND PSD.IsRemoved = 0
GROUP BY C.TechnicalName, PS.PatientID, PS.AdmittanceDate, PS.DischargeDate, D.FirstName, D.LastName, D.Degree
ORDER BY C.TechnicalName, PS.PatientID, PS.AdmittanceDate, PS.DischargeDate, D.FirstName, D.LastName, D.Degree;

EXEC Hospital.GetHospitalConditionHistory N'Atherosclerotic heart disease';
GO






CREATE OR ALTER PROCEDURE Hospital.GetDoctorConditionHistory
   @FirstName NVARCHAR(64),
   @LastName NVARCHAR(64)
AS

SELECT CI.FirstName, CI.LastName, C.TechnicalName, T.Name, DATEDIFF(day, PS.DischargeDate, PS.AdmittanceDate) AS LengthOfStay
FROM Hospital.ContactInfo CI 
    INNER JOIN Hospital.Doctor D ON D.ContactInfoID = CI.ContactInfoID
    INNER JOIN Hospital.PatientStayDoctor PSD ON PSD.DoctorID = D.DoctorID
    INNER JOIN Hospital.PatientStay PS ON PS.PatientStayID = PSD.PatientStayID
    INNER JOIN Hospital.PatientStayCondtion PSC ON PSC.PatientStayID = PS.PatientStayID
    INNER JOIN Hospital.Condition C ON C.ConditionID = PSC.ConditionID
    INNER JOIN Hospital.PatientStayTreatment PST ON PST.PatientStayID = PS.PatientStayID
    INNER JOIN Hospital.Treatment T ON T.TreatmentID = PST.TreatmentID
WHERE CI.FirstName = @FirstName AND CI.LastName = @LastName AND CI.IsRemoved = 0 AND D.IsRemoved = 0 AND PSD.IsRemoved = 0
    AND PS.IsRemoved = 0 AND PSC.IsRemoved = 0 AND C.IsRemoved = 0 AND PST.IsRemoved = 0 AND T.IsRemoved = 0
GROUP BY CI.FirstName, CI.LastName, C.TechnicalName, T.Name, DATEDIFF(day, PS.DischargeDate, PS.AdmittanceDate)
ORDER BY CI.FirstName, CI.LastName, C.TechnicalName, T.Name, LengthOfStay;

EXEC Hospital.GetDoctorConditionHistory N'Lance', N'Mccarthy';
GO