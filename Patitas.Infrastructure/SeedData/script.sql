-- Barrios
SET IDENTITY_INSERT dbo.Barrios ON
insert into dbo.Barrios(Id, Nombre)
values (1, 'Congreso'), (2, 'Palermo'), (3, 'Puerto Madero'), (4, 'Recoleta');
SET IDENTITY_INSERT dbo.Barrios OFF

-- Roles
SET IDENTITY_INSERT dbo.RolesUsuario ON
insert into dbo.RolesUsuario(Id, Nombre)
values (1, 'Administrador'), (2, 'Adoptante'), (3, 'Refugio'), (4, 'Veterinaria');
SET IDENTITY_INSERT dbo.RolesUsuario OFF

-- Usuarios
SET IDENTITY_INSERT dbo.Usuarios ON
insert into dbo.Usuarios(Id, NombreUsuario, Email, Password, FechaCreacion, Id_Barrio, Id_RolUsuario)
values
(1, 'administrador', 'admin.patitas@gmail.com', 'asd123', GETDATE(), 4, 1),
(2, 'adoptante.test', 'adoptante.test@gmail.com', 'asd123', GETDATE(), 3, 2),
(3, 'san.pedro', 'refugio_sanpedro@gmail.com', 'asd123', GETDATE(), 2, 3),
(4, 'cuidado_animal', 'cuidado_animal_oficial@gmail.com', 'asd123', GETDATE(), 1, 4),
(5, 'lionel-messi', 'messi10@outlook.com', 'asd123', GETDATE(), 2, 2);
SET IDENTITY_INSERT dbo.Usuarios OFF

-- Administradores
insert into dbo.Administradores(Id, EsFundador)
values (1, 1);

-- Adoptantes
insert into dbo.Adoptantes(Id, Nombre, Apellido)
values (2, 'Adoptante', 'Test'), (5, 'Lionel', 'Messi');

-- Refugios
insert into dbo.Refugios(Id, Nombre, RazonSocial, NombreResponsable, ApellidoResponsable, HorarioApertura, HorarioCierre)
values (3, 'San Pedro', 'Refugio San Pedro S.A.', 'José', 'Paradela', '09', '12');

-- Veterinarias
insert into dbo.Veterinarias(Id, Nombre, RazonSocial, Especialidades, FechaFundacion, HorarioApertura, HorarioCierre)
values (4, 'Cuidado Animal', 'Cuidado Animal S.A.', 'Vacunación, Cirugía, Ecografía, Peluquería', '2012-10-28', 10, 20);

-- Especies
SET IDENTITY_INSERT dbo.Especies ON
insert into dbo.Especies(Id, Nombre)
values (1, 'Perro'), (2, 'Gato');
SET IDENTITY_INSERT dbo.Especies OFF

-- Razas
SET IDENTITY_INSERT dbo.Razas ON
insert into dbo.Razas(Id, Nombre, Id_Especie)
values
(1, 'Labrador Retriever', 1),
(2, 'Pastor Alemán', 1),
(3, 'Caniche', 1),
(4, 'Boxer', 1),
(5, 'Border Collie', 1),
(6, 'Dogo', 1),
(7, 'Pug', 1),
(8, 'Beagle', 1),
(9, 'Persa', 2),
(10, 'Siamés', 2),
(11, 'Ragdoll', 2),
(12, 'Maine coon', 2),
(13, 'Gato Andino', 2),
(14, 'Gato Montés', 2),
(15, 'Americano de pelo corto', 2);
SET IDENTITY_INSERT dbo.Razas OFF

-- Animales
SET IDENTITY_INSERT dbo.Animales ON
insert into dbo.Animales(Id, Nombre, Nacimiento, Genero, SituacionPrevia, Altura, Esterilizado, Desparasitado, FechaIngreso, EstaAdoptado, Id_Raza, Id_Refugio)
values
(1, 'Coco', 2022, 'M', 'Fue rescatado de la calle', 0.55, 0, 1, GETDATE(), 0, 1, 3),
(2, 'Toby', 2022, 'M', 'Fue rescatado de la calle', 0.55, 0, 1, GETDATE(), 0, 10, 3),
(3, 'Simba', 2022, 'M', 'Fue rescatado de la calle', 0.55, 0, 1, GETDATE(), 0, 5, 3),
(4, 'Max', 2022, 'M', 'Fue rescatado de la calle', 0.55, 0, 1, GETDATE(), 0, 14, 3),
(5, 'Mia', 2022, 'H', 'Fue rescatada de la calle', 0.55, 0, 1, GETDATE(), 0, 3, 3),
(6, 'Uma', 2022, 'H', 'Fue rescatada de la calle', 0.55, 0, 1, GETDATE(), 0, 8, 3),
(7, 'Morena', 2022, 'H', 'Fue rescatada de la calle', 0.55, 0, 1, GETDATE(), 0, 15, 3),
(8, 'Luna', 2022, 'H', 'Fue rescatada de la calle', 0.55, 0, 1, GETDATE(), 0, 12, 3);
SET IDENTITY_INSERT dbo.Animales OFF

-- Refugios asociados a Veterinarias
insert into dbo.VeterinariasAsignadasARefugios (Id_Veterinaria, Id_Refugio)
values (4, 3);

--select a.Nombre as 'Nombre del animal', a.Genero, r.Nombre as 'Refugio', r.RazonSocial
--from dbo.Animales as a inner join dbo.Refugios as r on a.Id_Refugio = r.Id

-- Estrellas de comentario (descripción)
insert into dbo.DetalleEstrellas (NroEstrella, Descripcion)
values
(1, 'Un desastre'),
(2, 'Poco recomendable'),
(3, 'Buen lugar'),
(4, 'Muy recomendable'),
(5, 'Excelente');

-- Comentarios
SET IDENTITY_INSERT dbo.Comentarios ON
insert into dbo.Comentarios (Id, Descripcion, FechaCreacion, EstaActivo, FechaEdicion, PendienteDeAprobacion, AprobadoPor_IdAdministrador, Nro_Estrellas, Id_Refugio, Id_Adoptante)
values
(1, 'Muy buen refugio, tremenda experiencia xD', GETDATE(), 1, null, 0, 1, 4, 3, 2),
(2, 'Todo el proceso se dió muy rápido y siempre fueron muy gentiles.', GETDATE(), 1, null, 0, 1, 5, 3, 5);
SET IDENTITY_INSERT dbo.Comentarios OFF
