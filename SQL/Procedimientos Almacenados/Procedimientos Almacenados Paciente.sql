--PROCEDIMIENTOS ALMACENADOS DE PACIENTE--
--AGREGAR--
CREATE PROCEDURE PacienteAdd
    @Nombre VARCHAR(50),
    @Edad INT,
    @FechaNacimiento DATE,
    @Telefono VARCHAR(20)
AS
BEGIN
    INSERT INTO Paciente (Nombre, Edad, FechaNacimiento, Telefono)
    VALUES (@Nombre, @Edad, @FechaNacimiento, @Telefono);
END;

--ACTUALIZAR--

CREATE PROCEDURE PacienteUpdate
    @IdPaciente INT,
    @Nombre VARCHAR(50),
    @Edad INT,
    @FechaNacimiento DATE,
    @Telefono VARCHAR(20)
AS
BEGIN
    UPDATE Paciente
    SET Nombre = @Nombre, Edad = @Edad, FechaNacimiento = @FechaNacimiento, Telefono = @Telefono
    WHERE IdPaciente = @IdPaciente;
END;

--ELIMINAR--

CREATE PROCEDURE PacienteDelete
    @IdPaciente INT
AS
BEGIN
    DELETE FROM Paciente
    WHERE IdPaciente = @IdPaciente;
END;

--OBTENER INFORMACION POR ID--

CREATE PROCEDURE PacienteGetById
    @IdPaciente INT
AS
BEGIN
    SELECT * FROM Paciente
    WHERE IdPaciente = @IdPaciente;
END;

-- OBTENER LA INFORMACION DE TODOS LOS PACIENTES--

CREATE PROCEDURE PacienteGetAll
AS
BEGIN
    SELECT 
	
	IdPaciente,
	Nombre,
	Edad,
	FechaNacimiento,
	Telefono

	 FROM Paciente;
END;
