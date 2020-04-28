CREATE OR ALTER PROCEDURE Hospital.GetPatientInfo
   @FirstName NVARCHAR(64),
   @LastName NVARCHAR(64),
   @BirthDate DATETIME
AS

SELECT CI.PhoneNumber, CI.Email, CI.AddressLine, P.Sex
FROM Hospital.ContactInfo CI
    INNER JOIN Hospital.Patient P ON P.ContactInfoID = CI.ContactInfoID
WHERE CI.FirstName = @FirstName AND CI.LastName = @LastName AND CONVERT(VARCHAR, P.BirthDate, 101) = CONVERT(VARCHAR, @BirthDate, 101)
    AND CI.IsRemoved = 0 AND P.IsRemoved = 0;
GO




CREATE OR ALTER PROCEDURE Hospital.GetDoctorInfo
   @FirstName NVARCHAR(64),
   @LastName NVARCHAR(64),
   @Unit NVARCHAR(64)
AS

SELECT CI.PhoneNumber, CI.Email, CI.AddressLine, D.PracticeStartDate, D.Degree
FROM Hospital.ContactInfo CI
    INNER JOIN Hospital.Doctor D ON D.ContactInfoID = CI.ContactInfoID
WHERE CI.FirstName = @FirstName AND CI.LastName = @LastName AND D.Unit = @Unit
    AND CI.IsRemoved = 0 AND D.IsRemoved = 0;
GO




CREATE OR ALTER PROCEDURE Hospital.GetPatientEmergencyContactInfo
   @FirstName NVARCHAR(64),
   @LastName NVARCHAR(64),
   @BirthDate DATETIME
AS

SELECT ECI.FirstName, ECI.LastName, ECI.PhoneNumber, ECI.Email, ECI.AddressLine
FROM Hospital.ContactInfo CI
    INNER JOIN Hospital.Patient P ON P.ContactInfoID = CI.ContactInfoID
    INNER JOIN Hospital.ContactInfo ECI ON ECI.ContactInfoID = P.EmergencyContactInfoID
WHERE CI.FirstName = @FirstName AND CI.LastName = @LastName AND CONVERT(VARCHAR, P.BirthDate, 101) = CONVERT(VARCHAR, @BirthDate, 101)
    AND CI.IsRemoved = 0 AND P.IsRemoved = 0 AND ECI.IsRemoved = 0;
GO




CREATE OR ALTER PROCEDURE Hospital.GetPatientStays
   @FirstName NVARCHAR(64),
   @LastName NVARCHAR(64),
   @BirthDate DATETIME
AS

SELECT PS.AdmittanceDate, PS.DischargeDate, PS.Unit, PS.RoomNumber
FROM Hospital.ContactInfo CI
    INNER JOIN Hospital.Patient P ON P.ContactInfoID = CI.ContactInfoID
    INNER JOIN Hospital.PatientStay PS ON PS.PatientID = P.PatientID
WHERE CI.FirstName = @FirstName AND CI.LastName = @LastName AND CONVERT(VARCHAR, P.BirthDate, 101) = CONVERT(VARCHAR, @BirthDate, 101)
    AND CI.IsRemoved = 0 AND P.IsRemoved = 0 AND PS.IsRemoved = 0
ORDER BY PS.AdmittanceDate DESC;
GO




CREATE OR ALTER PROCEDURE Hospital.GetHospitalConditionHistory
   @ConditionName NVARCHAR(64)
AS

WITH Doctors(DoctorID, FirstName, LastName, Degree) AS
(
    SELECT D.DoctorID, CI.FirstName, CI.LastName, D.Degree
    FROM Hospital.ContactInfo CI
        INNER JOIN Hospital.Doctor D ON D.ContactInfoID = CI.ContactInfoID
    WHERE CI.IsRemoved = 0 AND D.IsRemoved = 0
)
SELECT PS.AdmittanceDate, PS.DischargeDate, PS.PatientID, D.FirstName, D.LastName, D.Degree,
    COUNT(PS.PatientStayID) OVER(
        PARTITION BY YEAR(PS.AdmittanceDate)
        ORDER BY PS.AdmittanceDate DESC
        ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) AS YtdCases
FROM Hospital.Condition C
    INNER JOIN Hospital.PatientStayCondtion PSC ON PSC.ConditionID = C.ConditionID
    INNER JOIN Hospital.PatientStay PS ON PS.PatientStayID = PSC.PatientStayID
    INNER JOIN Hospital.PatientStayDoctor PSD ON PSD.PatientStayID = PS.PatientStayID
    INNER JOIN Doctors D ON D.DoctorID = PSD.DoctorID
WHERE C.CommonName = @ConditionName AND C.IsRemoved = 0 AND PSC.IsRemoved = 0 AND PS.IsRemoved = 0 AND PSD.IsRemoved = 0
GROUP BY PS.PatientStayID, PS.AdmittanceDate, PS.DischargeDate, PS.PatientID, D.FirstName, D.LastName, D.Degree
ORDER BY PS.AdmittanceDate DESC;
GO




CREATE OR ALTER PROCEDURE Hospital.GetDoctorConditionHistory
   @FirstName NVARCHAR(64),
   @LastName NVARCHAR(64),
   @Unit NVARCHAR(64)
AS

WITH DoctorPatientStays(PatientStayID) AS
(
    SELECT PSD.PatientStayID
    FROM Hospital.ContactInfo CI
        INNER JOIN Hospital.Doctor D ON D.ContactInfoID = CI.ContactInfoID
        INNER JOIN Hospital.PatientStayDoctor PSD ON PSD.DoctorID = D.DoctorID
    WHERE CI.FirstName = @FirstName AND CI.LastName = @LastName AND D.Unit = @Unit
        AND CI.IsRemoved = 0 AND D.IsRemoved = 0 AND PSD.IsRemoved = 0
)
SELECT C.CommonName, T.Name AS TreatmentName, DATEDIFF(day, PS.DischargeDate, PS.AdmittanceDate) AS LengthOfStay
FROM DoctorPatientStays DPS
    INNER JOIN Hospital.PatientStay PS ON PS.PatientStayID = DPS.PatientStayID
    INNER JOIN Hospital.PatientStayCondtion PSC ON PSC.PatientStayID = PS.PatientStayID
    INNER JOIN Hospital.Condition C ON C.ConditionID = PSC.ConditionID
    INNER JOIN Hospital.PatientStayTreatment PST ON PST.PatientStayID = PS.PatientStayID
    INNER JOIN Hospital.Treatment T ON T.TreatmentID = PST.TreatmentID
WHERE PS.IsRemoved = 0 AND PSC.IsRemoved = 0 AND C.IsRemoved = 0 AND PST.IsRemoved = 0 AND T.IsRemoved = 0
GROUP BY PS.PatientStayID, C.CommonName, T.Name, PS.DischargeDate, PS.AdmittanceDate
ORDER BY C.CommonName, T.Name;
GO




EXEC Hospital.GetPatientInfo N'Cade', N'Barrett', '2009-05-21'
EXEC Hospital.GetDoctorInfo N'Lance', N'Mccarthy', N'Emergency'
EXEC Hospital.GetPatientEmergencyContactInfo N'Cade', N'Barrett', '2009-05-21'
EXEC Hospital.GetPatientStays N'Harrison', N'Stephens', '1998-09-12'
EXEC Hospital.GetHospitalConditionHistory N'Coronary Artery Disease'
EXEC Hospital.GetDoctorConditionHistory N'Kylie', N'Ramos', N'Family Practice'