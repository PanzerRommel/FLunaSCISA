--PROCEDIMIENTOS ALMACENADOS PARA CITA--
--AGREGAR--

CREATE PROCEDURE CitaAdd
    @FechaCita DATE,
    @IdDoctor INT,
    @IdPaciente INT
AS
BEGIN
    INSERT INTO Cita (FechaCita, IdDoctor, IdPaciente)
    VALUES (@FechaCita, @IdDoctor, @IdPaciente);
END;


--ACTUALIZAR--

CREATE PROCEDURE CitaUpdate
    @IdCita INT,
    @FechaCita DATE,
    @IdDoctor INT,
    @IdPaciente INT
AS
BEGIN
    UPDATE Cita
    SET FechaCita = @FechaCita, IdDoctor = @IdDoctor, IdPaciente = @IdPaciente
    WHERE IdCita = @IdCita;
END;

--ELIMINAR--

CREATE PROCEDURE CitaDelete
    @IdCita INT
AS
BEGIN
    DELETE FROM Cita
    WHERE IdCita = @IdCita;
END;


--Obtener la información de una cita por ID--

CREATE PROCEDURE CitaGetById
    @IdCita INT
AS
BEGIN
    SELECT * FROM Cita
    WHERE IdCita = @IdCita;
END;

--Obtener la información de todas las citas--

CREATE PROCEDURE CitaGetAll
AS
BEGIN
    SELECT * FROM Cita;
END;
