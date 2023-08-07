/* 1. feladat:*/
CREATE DATABASE noitenisz CHARACTER SET="UTF8" COLLATE="UTF8_hungarian_ci";
/* 3. feladat:*/
SELECT `jatekosok`.`nev`
FROM `jatekosok`
WHERE `jatekosok`.`nemzetiseg` = 'HUN';
/* 4. feladat:*/
SELECT `jatekosok`.`nev` AS név, `meccsek`.`gyoztes_eletkora` AS életkor FROM `meccsek`, `jatekosok` WHERE `meccsek`.`gyoztes`=`jatekosok`.`id` ORDER BY `meccsek`.`gyoztes_eletkora` DESC LIMIT 1
/* 5. feladat:*/
SELECT `torna` FROM `meccsek` GROUP BY torna HAVING COUNT(torna)>100 ORDER BY `torna` ASC