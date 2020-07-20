--
-- Base de datos: `bdpeliculas`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `genero`
--

CREATE TABLE `genero` (
  `IdGenero` int(11) NOT NULL,
  `Nombre` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `genero`
--

INSERT INTO `genero` (`IdGenero`, `Nombre`) VALUES
(1, 'Acción');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `pelicula`
--

CREATE TABLE `pelicula` (
  `IdPelicula` int(11) NOT NULL,
  `Nombre` varchar(45) NOT NULL,
  `FechaEstreno` date NOT NULL,
  `DuracionMinutos` int(11) NOT NULL,
  `Sinopsis` varchar(45) NOT NULL,
  `IdGenero` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `pelicula`
--

INSERT INTO `pelicula` (`IdPelicula`, `Nombre`, `FechaEstreno`, `DuracionMinutos`, `Sinopsis`, `IdGenero`) VALUES
(1, 'Avengers: Endgame', '2020-04-26', 182, 'Los Vengadores restantes deben encontrar una ', 1);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `genero`
--
ALTER TABLE `genero`
  ADD PRIMARY KEY (`IdGenero`);

--
-- Indices de la tabla `pelicula`
--
ALTER TABLE `pelicula`
  ADD PRIMARY KEY (`IdPelicula`),
  ADD KEY `fk_Pelicula_Genero_idx` (`IdGenero`);

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `pelicula`
--
ALTER TABLE `pelicula`
  ADD CONSTRAINT `fk_Pelicula_Genero` FOREIGN KEY (`IdGenero`) REFERENCES `genero` (`IdGenero`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;
