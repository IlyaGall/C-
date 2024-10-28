# Введение в базы данных
## Встраиваемые и клиент-серверные СУБД

* Встраиваемые СУБД
1. Состоят из одного файла на диске
2. Нет системы пользователей
3. Работают очень быстро, так как это по факту просто файл на диске
4. Плохо масштабируемы
5. Решение для тестирования или для работы клиента с локальными данными
Примеры: SQLite

* Клиент-Серверные СУБД
1. Состоят из клиента и сервера
2. Разграничение доступа между пользователями
3. Клиент-серверная технология, то есть будут сетевые задержки
4. Легко масштабируемы
5. Возможна запись больших объемов данных
Примеры: MS SQL Server, PostgreSQL, Oracle Database


## SQL

SQL — простыми словами, это язык программирования структурированных запросов (SQL, Structured Query Language), который используется в качестве эффективного способа сохранения данных, поиска их частей, обновления, извлечения из базы и удаления.

### DDL – Data Definition Language

– это группа операторов определения данных. Другими словами, с помощью операторов, входящих в эту группы, мы определяем структуру базы данных и работаем с объектами этой базы, т.е. создаем, изменяем и удаляем их.
В эту группу входят следующие операторы:
* CREATE – используется для создания объектов базы данных;
* ALTER – используется для изменения объектов базы данных;
* DROP – используется для удаления объектов базы данных.

### DML – Data Manipulation Language

– это группа операторов для манипуляции данными. С помощью этих операторов мы можем добавлять, изменять, удалять и выгружать данные из базы, т.е. манипулировать ими.
В эту группу входят самые распространенные операторы языка SQL:
* SELECT – осуществляет выборку данных;
* INSERT – добавляет новые данные;
* UPDATE – изменяет существующие данные;
* DELETE – удаляет данные.


### DCL – Data Control Language

– группа операторов определения доступа к данным. Иными словами, это операторы для управления разрешениями, с помощью них мы можем разрешать или запрещать выполнение определенных операций над объектами базы данных.
Сюда входят:
* GRANT – предоставляет пользователю или группе разрешения на определённые операции с объектом;
* REVOKE – отзывает выданные разрешения;
* DENY– задаёт запрет, имеющий приоритет над разрешением.

### TCL – Transaction Control Language

– группа операторов для управления транзакциями. Транзакция – это команда или блок команд (инструкций), которые успешно завершаются как единое целое, при этом в базе данных все внесенные изменения фиксируются на постоянной основе или отменяются, т.е. все изменения, внесенные любой командой, входящей в транзакцию, будут отменены. Группа операторов TCL предназначена как раз для реализации и управления транзакциями. 
Сюда можно отнести:
* BEGIN TRANSACTION – служит для определения начала транзакции;
* COMMIT TRANSACTION – применяет транзакцию;
* ROLLBACK TRANSACTION – откатывает все изменения, сделанные в контексте текущей транзакции;
* SAVE TRANSACTION – устанавливает промежуточную точку сохранения внутри транзакции.

### Таблица

— это набор элементов данных (значений), использующий модель вертикальных столбцов (имеющих уникальное имя) и горизонтальных строк.
Ячейка — место, где строка и столбец пересекаются.
Таблица содержит определенное число столбцов, но может иметь любое количество строк.


## Типы данных

![img](https://github.com/IlyaGall/C-/blob/main/27%20%D0%92%D0%B2%D0%B5%D0%B4%D0%B5%D0%BD%D0%B8%D0%B5%20%D0%B2%20%D0%B1%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85/img/1.JPG)

[Ссылка на типы данных](https://learn.microsoft.com/ru-ru/sql/t-sql/data-types/data-types-transact-sql?view=sql-server-ver15)

### CRUD операции

![img](https://github.com/IlyaGall/C-/blob/main/27%20%D0%92%D0%B2%D0%B5%D0%B4%D0%B5%D0%BD%D0%B8%D0%B5%20%D0%B2%20%D0%B1%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85/img/2.JPG)


#### Список материалов для изучения
* https://www.zeluslugi.ru/info-czentr/it-glossary/term-sql
* http://sqlfiddle.com/#!18
* https://dbfiddle.uk/?rdbms=sqlserver_2019&fiddle=40ab0943ccf98937ca28227d17cce023
* https://tproger.ru/translations/sql-recap/
* http://www.sql-tutorial.ru/ru/content.html
* https://metanit.com/sql/sqlserver/1.1.php
* https://docs.microsoft.com/ru-ru/sql/t-sql/language-reference?view=sql-server-ver15
* https://db-engines.com/en/system/Microsoft+SQL+Server%3BOracle%3BPostgreSQL
* https://habr.com/ru/post/564390/
* https://proglib.io/p/sql-cheat-sheet


## практика

```sql
select @@version;
```

| (No column name) |
| :----------------|
| Microsoft SQL Server 2022 (RTM) - 16.0.1000.6 (X64) <br>	Oct  8 2022 05:58:25 <br>	Copyright (C) 2022 Microsoft Corporation<br>	Express Edition (64-bit) on Windows Server 2019 Standard 10.0 \<X64> (Build 17763: ) (Hypervisor)<br> |

```sql
--Напишите скрипт создания таблицы, которую раньше никто не создавал. В таблице должно быть не менее 5 полей
Create Table Persons
  (
  Id int,
  Name varchar(100),
  LastName varchar(255),
  Email varchar(50),
  Phone varchar(10),
  DepartmantId int 
  )
```

```sql
select * from Persons
```

| Id | Name | LastName | Email | Phone | DepartmantId |
| --:|:----|:--------|:-----|:-----|------------:|
```sql
--Напишите скрипт удаления столбца.
alter table Persons drop column LastName
  --Напишите скрипт добавления нового столбца.
alter table Persons add Age int
select * from Persons
```

| Id | Name | Email | Phone | DepartmantId | Age |
| --:|:----|:-----|:-----|------------:|---:|


```sql
-- Напишите скрипт добавления 5 строк в таблицу.
insert into Persons(id, Name,Email,Phone,Age,DepartmantId) values
(0,'Ivan','Nope','1231231231', 100,0),
(1,'Petr','123@mail.ru','1221231231', 10,0),
(2,'Artur','N@gmail.com','555123', 5,1),
(3,'Dima','111@ss.com','999-1', 3,2),
(4,'Ilya','fox@com.com','8888-', 50,1)
-- Напишите скрипт вывода всех 5 строк.
select * from Persons 
```

| Id | Name | Email | Phone | DepartmantId | Age |
| --:|:----|:-----|:-----|------------:|---:|
| 0 | Ivan | Nope | 1231231231 | 0 | 100 |
| 1 | Petr | 123@mail.ru | 1221231231 | 0 | 10 |
| 2 | Artur | N@gmail.com | 555123 | 1 | 5 |
| 3 | Dima | 111@ss.com | 999-1 | 2 | 3 |
| 4 | Ilya | fox@com.com | 8888- | 1 | 50 |

```sql
-- Напишите скрипт вывода части строк по условию(лёгкий)
select * from Persons where age>3
```
| Id | Name | Email | Phone | DepartmantId | Age |
| --:|:----|:-----|:-----|------------:|---:|
| 0 | Ivan | Nope | 1231231231 | 0 | 100 |
| 1 | Petr | 123@mail.ru | 1221231231 | 0 | 10 |
| 2 | Artur | N@gmail.com | 555123 | 1 | 5 |
| 4 | Ilya | fox@com.com | 8888- | 1 | 50 |


```sql
-- Напишите скрипт вывода части строк по условию(тяжелый)
select AVG(Age) from Persons Where Name Like '%a%'   
```

| (No column name) |
| ----------------:|
| 39 |

```sql
--Напишите скрипт удаления части данных по условию.
delete Persons where Phone like '%5%'
select * from Persons
```

| Id | Name | Email | Phone | DepartmantId | Age |
| --:|:----|:-----|:-----|------------:|---:|
| 0 | Ivan | Nope | 1231231231 | 0 | 100 |
| 1 | Petr | 123@mail.ru | 1221231231 | 0 | 10 |
| 3 | Dima | 111@ss.com | 999-1 | 2 | 3 |
| 4 | Ilya | fox@com.com | 8888- | 1 | 50 |


```sql
Create Table Departmant
  (
  Id int,
  Name varchar(100)
  )

```

```sql
insert into Departmant(Id, Name) values (0,'Shool'), (1, 'test'), (2,'HotDog')
select * from Departmant
select * from Persons
```

| Id | Name |
| --:|:----|
| 0 | Shool |
| 1 | test |
| 2 | HotDog |

| Id | Name | Email | Phone | DepartmantId | Age |
| --:|:----|:-----|:-----|------------:|---:|
| 0 | Ivan | Nope | 1231231231 | 0 | 100 |
| 1 | Petr | 123@mail.ru | 1221231231 | 0 | 10 |
| 3 | Dima | 111@ss.com | 999-1 | 2 | 3 |
| 4 | Ilya | fox@com.com | 8888- | 1 | 50 |


```sql
select p.Name, p.Age from Persons as p
join Departmant as d on d.Id = p.DepartmantId
where d.Name ='Shool' 
  Order by age
-- выбрать школьников (имя и возраст) в порядке возрастания
```
| Name | Age |
| :----|---:|
| Petr | 10 |
| Ivan | 100 |

[fiddle](https://dbfiddle.uk/ztcTsirk)
