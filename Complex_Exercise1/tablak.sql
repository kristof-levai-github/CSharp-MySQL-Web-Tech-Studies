CREATE TABLE lista (
  listanev varchar(20) NOT NULL,
  admin_mail varchar(40) DEFAULT NULL,
  zart boolean DEFAULT NULL,
  PRIMARY KEY (listanev)
);

CREATE TABLE tag (
  tag_mail varchar(40) NOT NULL,
  tagnev varchar(40) DEFAULT NULL,
  PRIMARY KEY (tag_mail)
);

CREATE TABLE listatag (
  tag_mail varchar(40) DEFAULT NULL,
  listanev varchar(20) DEFAULT NULL,
  feliratkozas datetime DEFAULT NULL,
  leiratkozas datetime DEFAULT NULL,
  PRIMARY KEY (tag_mail, listanev),
  CONSTRAINT FK_listatag_lista FOREIGN KEY (listanev)
  REFERENCES lista (listanev),
  CONSTRAINT FK_listatag_tag FOREIGN KEY (tag_mail)
  REFERENCES tag (tag_mail)
);