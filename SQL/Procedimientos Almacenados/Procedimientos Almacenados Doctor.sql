--PROCEDIMIENTOS ALMACENADOS DE DOCTOR--
--AGREGAR--
CREATE PROCEDURE DoctorAdd
    @Nombre VARCHAR(100),
    @Especialidad VARCHAR(50)
AS
BEGIN
    INSERT INTO Doctor (Nombre, Especialidad)
    VALUES (@Nombre, @Especialidad);
END;

--ACTUALIZAR--

CREATE PROCEDURE DoctorUpdate
    @IdDoctor INT,
    @NuevoNombre VARCHAR(100),
    @NuevaEspecialidad VARCHAR(50)
AS
BEGIN
    UPDATE Doctor
    SET Nombre = @NuevoNombre, Especialidad = @NuevaEspecialidad
    WHERE IdDoctor = @IdDoctor;
END;

--ELIMINAR--

CREATE PROCEDURE DoctorDelete
    @IdDoctor INT
AS
BEGIN
    DELETE FROM Doctor
    WHERE IdDoctor = @IdDoctor;
END;

--OBTENER INFORMACION POR ID--

CREATE PROCEDURE DoctorGetById
    @IdDoctor INT
AS
BEGIN
    SELECT 

	IdDoctor,
	Nombre,
	Especialidad
	 FROM Doctor
    WHERE IdDoctor = @IdDoctor;
END;

-- OBTENER LA INFORMACION DE TODOS LOS DOCTORES--

CREATE PROCEDURE DoctorGetAll
AS
SELECT
	IdDoctor,
	Nombre,
	Especialidad
FROM Doctor