use Patitas;

-- Barrios
SET IDENTITY_INSERT dbo.Barrios ON
insert into dbo.Barrios(Id, Nombre)
values (1, 'Congreso'), (2, 'Palermo'), (3, 'Puerto Madero'), (4, 'Recoleta');
SET IDENTITY_INSERT dbo.Barrios OFF

-- Roles
SET IDENTITY_INSERT dbo.Roles ON
insert into dbo.Roles(Id, Nombre)
values (1, 'Administrador'), (2, 'Adoptante'), (3, 'Refugio'), (4, 'Veterinaria');
SET IDENTITY_INSERT dbo.Roles OFF

-- Usuarios
SET IDENTITY_INSERT dbo.Usuarios ON
insert into dbo.Usuarios(Id, NombreUsuario, Email, Password, FotoDePerfil, Telefono, Direccion, FechaCreacion, EstaActivo, Id_Barrio, Id_Rol)
values
(1, 'administrador', 'admin.patitas@gmail.com', 'asd123', null, null, null, GETDATE(), 1, 4, 1),
(2, 'adoptante.test', 'adoptante.test@gmail.com', 'asd123', null, null, null, GETDATE(), 1, 2, 2),
(3, 'san.pedro', 'refugio_sanpedro@gmail.com', 'asd123', null, '555-5555', 'Av. del Libertador 4101', GETDATE(), 0, 2, 3),
(4, 'cuidado_animal', 'cuidado_animal_oficial@gmail.com', 'asd123', null, '0800-7898-4658', 'Av. Hipólito Yrigoyen 1849', GETDATE(), 0, 1, 4),
(5, 'lionel-messi', 'messi10@outlook.com', 'asd123', null, null, null, GETDATE(), 1, 2, 2),
(6, 'el_arca_de_noe', 'el.arca.de.noe@outlook.com', 'asd123', null, '7894-1547', 'Moreno 1623', GETDATE(), 0, 1, 3),
(7, 'patas_unidas', 'patas_unidas@outlook.com', 'asd123', null, '3564-8879', 'Hipólito Yrigoyen 1849', GETDATE(), 1, 4, 3),
(8, 'santuario.animal', 'santuario.animal@gmail.com', 'asd123', null, '9894-6327', 'Av. San Juan 350', GETDATE(), 0, 3, 3),
(9, 'nuevas.oportunidades', 'nuevas.oportunidades@outlook.com', 'asd123', null, '5544-9878', 'Adolfo Alsina 940', GETDATE(), 0, 1, 3)
SET IDENTITY_INSERT dbo.Usuarios OFF

-- Administradores
insert into dbo.Administradores(Id, EsFundador)
values (1, 1);

-- Adoptantes
insert into dbo.Adoptantes(Id, Nombre, Apellido)
values (2, 'Adoptante', 'Test'), (5, 'Lionel', 'Messi');

-- Refugios
insert into dbo.Refugios(Id, Nombre, RazonSocial, NombreResponsable, ApellidoResponsable, DiasDeAtencion, HorarioApertura, HorarioCierre)
values
(3, 'San Pedro', 'Refugio San Pedro S.A.', 'José', 'Paradela', 'Lunes a Viernes', '09', '12'),
(6, 'El Arca de Noé', 'El Arca de Noé S.A.', 'Paola', 'Martínez', 'Martes, Miércoles, Jueves', '11', '14'),
(7, 'Patas Unidas', 'Patas Unidas S.A.', 'Esteban', 'Fernandez', 'Jueves, Viernes, Sábado', '10', '14'),
(8, 'Santuario Animal', 'Santuario Animal S.A.', 'Raúl', 'Pereira', 'Lunes a Viernes', '15', '18'),
(9, 'Nuevas Oportunidades', 'Nuevas Oportunidades S.A.', 'Josefina', 'Alsina', 'Domingo, Lunes, Martes', '09', '15')

-- Veterinarias
insert into dbo.Veterinarias(Id, Nombre, RazonSocial, Especialidades, FechaFundacion, DiasDeAtencion, HorarioApertura, HorarioCierre)
values (4, 'Cuidado Animal', 'Cuidado Animal S.A.', 'Vacunación, Cirugía, Ecografía, Peluquería', '2012-10-28', 'Lunes a viernes', 10, 20);

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
insert into dbo.Animales(Id, Nombre, Nacimiento, Genero, Fotografia, SituacionPrevia, Peso, Altura, Esterilizado, Desparasitado, FechaIngreso, EstaAdoptado, Id_Raza, Id_Refugio)
values
(1, 'Coco', 2022, 'M', 'https://localhost:7277/api/refugios/3/animales/images/animal_1.jpg', 'Fue rescatado de la calle', 25, 0.55, 0, 1, GETDATE(), 0, 1, 3),
(2, 'Toby', 2022, 'M', 'https://localhost:7277/api/refugios/3/animales/images/animal_2.jpg', 'Fue rescatado de la calle', 25, 0.55, 0, 1, GETDATE(), 0, 10, 3),
(3, 'Simba', 2022, 'M', 'https://localhost:7277/api/refugios/3/animales/images/animal_3.jpg', 'Fue rescatado de la calle', 25, 0.55, 0, 1, GETDATE(), 0, 5, 3),
(4, 'Max', 2022, 'M', 'https://localhost:7277/api/refugios/3/animales/images/animal_4.jpg', 'Fue rescatado de la calle', 25, 0.55, 0, 1, GETDATE(), 0, 14, 3),
(5, 'Mia', 2022, 'H', 'https://localhost:7277/api/refugios/3/animales/images/animal_5.jpg', 'Fue rescatada de la calle', 25, 0.55, 0, 1, GETDATE(), 0, 3, 3),
(6, 'Uma', 2022, 'H', 'https://localhost:7277/api/refugios/3/animales/images/animal_6.jpg', 'Fue rescatada de la calle', 25, 0.55, 0, 1, GETDATE(), 0, 8, 3),
(7, 'Morena', 2022, 'H', 'https://localhost:7277/api/refugios/3/animales/images/animal_7.jpg', 'Fue rescatada de la calle', 25, 0.55, 0, 1, GETDATE(), 0, 15, 3),
(8, 'Luna', 2022, 'H', 'https://localhost:7277/api/refugios/3/animales/images/animal_8.jpg', 'Fue rescatada de la calle', 25, 0.55, 0, 1, GETDATE(), 0, 12, 3);
SET IDENTITY_INSERT dbo.Animales OFF

-- Refugios asociados a Veterinarias
insert into dbo.VeterinariasAsignadasARefugios (Id_Veterinaria, Id_Refugio, FechaDeAsignacion)
values (4, 3, GETDATE());

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
insert into dbo.Comentarios (Id, Descripcion, FechaCreacion, EstaActivo, FechaEdicion, Nro_Estrellas, Id_Refugio, Id_Adoptante)
values
(1, 'Es un buen lugar, los animales se notaban bien cuidados.', GETDATE(), 1, null, 4, 3, 2),
(2, 'Todo el proceso se dió muy rápido y siempre fueron muy gentiles.', GETDATE(), 1, null, 5, 3, 5);
SET IDENTITY_INSERT dbo.Comentarios OFF