



CREATE TABLE `kiado` (
 
  `id` int(2) NOT NULL,

  `nev` varchar(48) DEFAULT NULL,
  CONSTRAINT `pk_kiado` PRIMARY KEY (`id`)
);

CREATE TABLE `film` (

  `id` int(3) NOT NULL,

  `cim` varchar(121) DEFAULT NULL,

  `kiadasiev` int(11) DEFAULT NULL,

  `kocka` int(11) DEFAULT NULL,

  `szinese` tinyint(1) DEFAULT NULL,

  `kiadoid` int(2) DEFAULT NULL,
  CONSTRAINT `pk_film` PRIMARY KEY (`id`),
  CONSTRAINT fk_filmkiado FOREIGN KEY (`kiadoid`) REFERENCES `kiado` (`id`)
);

