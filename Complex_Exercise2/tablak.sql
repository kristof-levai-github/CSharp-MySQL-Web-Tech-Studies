CREATE TABLE boritas (
  id int NOT NULL,
  elnevezes varchar(255) NULL,
  PRIMARY KEY (id)
);

CREATE TABLE jatekosok (
  id int NOT NULL,
  nev varchar(255) NOT NULL,
  magassag int NULL,
  nemzetiseg char(3) NOT NULL,
  PRIMARY KEY (id)
);

CREATE TABLE meccsek (
  id int NOT NULL,
  datum date NULL,
  torna varchar(255) NULL,
  boritas_id int NOT NULL,
  gyoztes int NULL,
  vesztes int NULL,
  eredmeny varchar(255) NULL,
  gyoztes_eletkora float NULL,
  vesztes_eletkora float NULL,
  PRIMARY KEY (id),
  CONSTRAINT FK_meccsek_boritas_id FOREIGN KEY (boritas_id) REFERENCES boritas(id),
  CONSTRAINT FK_meccsek_jatekosok_id FOREIGN KEY (gyoztes) REFERENCES jatekosok(id),
  CONSTRAINT FK_meccsek_jatekosok_id2 FOREIGN KEY (vesztes) REFERENCES jatekosok(id)
);