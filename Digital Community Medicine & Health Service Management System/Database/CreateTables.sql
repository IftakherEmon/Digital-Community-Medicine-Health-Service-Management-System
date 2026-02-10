CREATE TABLE Users (
    UserId INT IDENTITY PRIMARY KEY,
    Email NVARCHAR(150) UNIQUE NOT NULL,
    PasswordHash NVARCHAR(255) NOT NULL,
    Role NVARCHAR(50) NOT NULL,
    IsActive BIT DEFAULT 1,
    CreatedAt DATETIME DEFAULT GETDATE()
);

CREATE TABLE Admin (
    AdminId INT IDENTITY PRIMARY KEY,
    UserId INT UNIQUE,
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
);

CREATE TABLE ServiceLocation (
    LocationId INT IDENTITY PRIMARY KEY,
    Area NVARCHAR(150),
    City NVARCHAR(100),
    CreatedAt DATETIME DEFAULT GETDATE()
);

CREATE TABLE Clinic (
    ClinicId INT IDENTITY PRIMARY KEY,
    LocationId INT,
    ClinicName NVARCHAR(200),
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (LocationId) REFERENCES ServiceLocation(LocationId)
);

CREATE TABLE Patient (
    PatientId INT IDENTITY PRIMARY KEY,
    UserId INT UNIQUE,
    FullName NVARCHAR(150),
    Gender NVARCHAR(20),
    DateOfBirth DATE,
    Phone NVARCHAR(20),
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
);

CREATE TABLE PatientMedicalHistory (
    HistoryId INT IDENTITY PRIMARY KEY,
    PatientId INT,
    Description NVARCHAR(500),
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (PatientId) REFERENCES Patient(PatientId)
);

CREATE TABLE Doctor (
    DoctorId INT IDENTITY PRIMARY KEY,
    UserId INT UNIQUE,
    Specialization NVARCHAR(150),
    LicenseNumber NVARCHAR(100),
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
);

CREATE TABLE DoctorClinic (
    DoctorClinicId INT IDENTITY PRIMARY KEY,
    DoctorId INT,
    ClinicId INT,
    FOREIGN KEY (DoctorId) REFERENCES Doctor(DoctorId),
    FOREIGN KEY (ClinicId) REFERENCES Clinic(ClinicId)
);

CREATE TABLE DoctorAvailability (
    AvailabilityId INT IDENTITY PRIMARY KEY,
    DoctorId INT,
    DayOfWeek NVARCHAR(20),
    StartTime TIME,
    EndTime TIME,
    FOREIGN KEY (DoctorId) REFERENCES Doctor(DoctorId)
);

CREATE TABLE AppointmentSlot (
    SlotId INT IDENTITY PRIMARY KEY,
    AvailabilityId INT,
    SlotTime TIME,
    IsBooked BIT DEFAULT 0,
    FOREIGN KEY (AvailabilityId) REFERENCES DoctorAvailability(AvailabilityId)
);

CREATE TABLE Appointment (
    AppointmentId INT IDENTITY PRIMARY KEY,
    PatientId INT,
    DoctorId INT,
    SlotId INT,
    AppointmentDate DATE,
    Status NVARCHAR(50),
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (PatientId) REFERENCES Patient(PatientId),
    FOREIGN KEY (DoctorId) REFERENCES Doctor(DoctorId),
    FOREIGN KEY (SlotId) REFERENCES AppointmentSlot(SlotId)
);

CREATE TABLE Pharmacy (
    PharmacyId INT IDENTITY PRIMARY KEY,
    LocationId INT,
    PharmacyName NVARCHAR(200),
    IsActive BIT DEFAULT 1,
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (LocationId) REFERENCES ServiceLocation(LocationId)
);

CREATE TABLE Pharmacist (
    PharmacistId INT IDENTITY PRIMARY KEY,
    UserId INT UNIQUE,
    PharmacyId INT,
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (UserId) REFERENCES Users(UserId),
    FOREIGN KEY (PharmacyId) REFERENCES Pharmacy(PharmacyId)
);

CREATE TABLE MedicineCategory (
    CategoryId INT IDENTITY PRIMARY KEY,
    CategoryName NVARCHAR(100)
);

CREATE TABLE Medicine (
    MedicineId INT IDENTITY PRIMARY KEY,
    CategoryId INT,
    MedicineName NVARCHAR(150),
    Price DECIMAL(10,2),
    FOREIGN KEY (CategoryId) REFERENCES MedicineCategory(CategoryId)
);

CREATE TABLE PharmacyInventory (
    InventoryId INT IDENTITY PRIMARY KEY,
    PharmacyId INT,
    MedicineId INT,
    Quantity INT,
    FOREIGN KEY (PharmacyId) REFERENCES Pharmacy(PharmacyId),
    FOREIGN KEY (MedicineId) REFERENCES Medicine(MedicineId)
);

CREATE TABLE Prescription (
    PrescriptionId INT IDENTITY PRIMARY KEY,
    AppointmentId INT,
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (AppointmentId) REFERENCES Appointment(AppointmentId)
);

CREATE TABLE PrescriptionMedicine (
    PrescriptionMedicineId INT IDENTITY PRIMARY KEY,
    PrescriptionId INT,
    MedicineId INT,
    Dosage NVARCHAR(100),
    FOREIGN KEY (PrescriptionId) REFERENCES Prescription(PrescriptionId),
    FOREIGN KEY (MedicineId) REFERENCES Medicine(MedicineId)
);

CREATE TABLE Cart (
    CartId INT IDENTITY PRIMARY KEY,
    PatientId INT UNIQUE,
    FOREIGN KEY (PatientId) REFERENCES Patient(PatientId)
);

CREATE TABLE CartItem (
    CartItemId INT IDENTITY PRIMARY KEY,
    CartId INT,
    MedicineId INT,
    Quantity INT,
    FOREIGN KEY (CartId) REFERENCES Cart(CartId),
    FOREIGN KEY (MedicineId) REFERENCES Medicine(MedicineId)
);

CREATE TABLE MedicineOrder (
    OrderId INT IDENTITY PRIMARY KEY,
    PatientId INT,
    TotalAmount DECIMAL(10,2),
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (PatientId) REFERENCES Patient(PatientId)
);

CREATE TABLE MedicineOrderItem (
    OrderItemId INT IDENTITY PRIMARY KEY,
    OrderId INT,
    MedicineId INT,
    Quantity INT,
    Price DECIMAL(10,2),
    FOREIGN KEY (OrderId) REFERENCES MedicineOrder(OrderId),
    FOREIGN KEY (MedicineId) REFERENCES Medicine(MedicineId)
);

CREATE TABLE OrderPrescription (
    OrderPrescriptionId INT IDENTITY PRIMARY KEY,
    OrderId INT,
    PrescriptionId INT,
    VerificationStatus NVARCHAR(20),
    VerifiedByPharmacistId INT,
    VerificationNotes NVARCHAR(500),
    VerifiedAt DATETIME,
    FOREIGN KEY (OrderId) REFERENCES MedicineOrder(OrderId),
    FOREIGN KEY (PrescriptionId) REFERENCES Prescription(PrescriptionId),
    FOREIGN KEY (VerifiedByPharmacistId) REFERENCES Pharmacist(PharmacistId)
);

CREATE TABLE OrderStatusHistory (
    HistoryId INT IDENTITY PRIMARY KEY,
    OrderId INT,
    Status NVARCHAR(50),
    ChangedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (OrderId) REFERENCES MedicineOrder(OrderId)
);

CREATE TABLE Payment (
    PaymentId INT IDENTITY PRIMARY KEY,
    OrderId INT,
    Amount DECIMAL(10,2),
    PaymentMethod NVARCHAR(50),
    PaymentDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (OrderId) REFERENCES MedicineOrder(OrderId)
);

CREATE TABLE FollowUpReminder (
    ReminderId INT IDENTITY PRIMARY KEY,
    PatientId INT,
    Message NVARCHAR(300),
    ReminderDate DATE,
    FOREIGN KEY (PatientId) REFERENCES Patient(PatientId)
);

CREATE TABLE Ambulance (
    AmbulanceId INT IDENTITY PRIMARY KEY,
    LocationId INT,
    VehicleNumber NVARCHAR(50),
    IsAvailable BIT DEFAULT 1,
    FOREIGN KEY (LocationId) REFERENCES ServiceLocation(LocationId)
);

CREATE TABLE EmergencyRequest (
    EmergencyId INT IDENTITY PRIMARY KEY,
    PatientId INT,
    LocationId INT,
    Status NVARCHAR(50),
    RequestedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (PatientId) REFERENCES Patient(PatientId),
    FOREIGN KEY (LocationId) REFERENCES ServiceLocation(LocationId)
);

CREATE TABLE DoctorReview (
    ReviewId INT IDENTITY PRIMARY KEY,
    DoctorId INT,
    PatientId INT,
    Rating INT,
    Comment NVARCHAR(300),
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (DoctorId) REFERENCES Doctor(DoctorId),
    FOREIGN KEY (PatientId) REFERENCES Patient(PatientId)
);

CREATE TABLE NotificationLog (
    NotificationId INT IDENTITY PRIMARY KEY,
    UserId INT,
    Message NVARCHAR(300),
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
);

CREATE TABLE Complaint (
    ComplaintId INT IDENTITY PRIMARY KEY,
    UserId INT,
    ComplaintType NVARCHAR(100),
    Description NVARCHAR(500),
    Status NVARCHAR(50),
    Priority NVARCHAR(50),
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
);

CREATE TABLE DiagnosticLab (
    LabId INT IDENTITY PRIMARY KEY,
    LocationId INT UNIQUE,
    LabName NVARCHAR(200),
    LicenseNumber NVARCHAR(100),
    IsActive BIT DEFAULT 1,
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (LocationId) REFERENCES ServiceLocation(LocationId)
);
