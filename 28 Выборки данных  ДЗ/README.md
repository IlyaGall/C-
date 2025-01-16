# Введение в базы данных

[Источник](https://neon.tech/postgresql/postgresql-getting-started/load-postgresql-sample-database)

Создал бд через pg admin

![img](https://github.com/IlyaGall/C-/blob/main/28%20%D0%92%D1%8B%D0%B1%D0%BE%D1%80%D0%BA%D0%B8%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20%20%D0%94%D0%97/img/1.JPG)

Тоже самое можно сделать через консоль

```cmd

C:\Program Files\PostgreSQL\16\bin>psql -V
psql (PostgreSQL) 16.3

C:\Program Files\PostgreSQL\16\bin>psql -U postgres
psql (16.3)
ПРЕДУПРЕЖДЕНИЕ: Кодовая страница консоли (866) отличается от основной
                страницы Windows (1251).
                8-битовые (русские) символы могут отображаться некорректно.
                Подробнее об этом смотрите документацию psql, раздел
                "Notes for Windows users".
Введите "help", чтобы получить справку.

postgres=# CREATE DATABASE dvdrental;
ОШИБКА:  база данных "dvdrental" уже существует
postgres=# \l
```
                                                                  ╤яшёюъ срч фрээ√ї
     ╚ь      | ┬ырфхыхЎ | ╩юфшЁютър | ╧ЁютрщфхЁ ыюърыш |     LC_COLLATE      |      LC_CTYPE       | ыюъры№ ICU | ╧Ёртшыр ICU |     ╧Ёртр фюёЄєяр
-------------+----------+-----------+------------------+---------------------+---------------------+------------+-------------+-----------------------
 dvdrental   | postgres | UTF8      | libc             | Russian_Russia.1251 | Russian_Russia.1251 |            |             |
 postgres    | postgres | UTF8      | libc             | Russian_Russia.1251 | Russian_Russia.1251 |            |             |
 telegramBot | postgres | UTF8      | libc             | Russian_Russia.1251 | Russian_Russia.1251 |            |             |
 template0   | postgres | UTF8      | libc             | Russian_Russia.1251 | Russian_Russia.1251 |            |             | =c/postgres          +
             |          |           |                  |                     |                     |            |             | postgres=CTc/postgres
 template1   | postgres | UTF8      | libc             | Russian_Russia.1251 | Russian_Russia.1251 |            |             | =c/postgres          +
             |          |           |                  |                     |                     |            |             | postgres=CTc/postgres
(5 ёЄЁюъ)


postgres=#


![img](https://github.com/IlyaGall/C-/blob/main/28%20%D0%92%D1%8B%D0%B1%D0%BE%D1%80%D0%BA%D0%B8%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20%20%D0%94%D0%97/img/2.JPG)


## 2 Восстановите образец базы данных из файла tar

не вот так:

```pg_restore -U postgres -d dvdrental C:\gitHub\C-\28 Выборки данных  ДЗ\dvdrental\dvdrental.tar```

![img](https://github.com/IlyaGall/C-/blob/main/28%20%D0%92%D1%8B%D0%B1%D0%BE%D1%80%D0%BA%D0%B8%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20%20%D0%94%D0%97/img/4.JPG)


! в пути к файлу не должно быть кириллицы

```pg_restore -U postgres -d dvdrental C:\Users\Ilya\Desktop\dvdrental.tar```

![img](https://github.com/IlyaGall/C-/blob/main/28%20%D0%92%D1%8B%D0%B1%D0%BE%D1%80%D0%BA%D0%B8%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20%20%D0%94%D0%97/img/3.JPG)


### избавления от броблемы с кодировкой


```
C:\Program Files\PostgreSQL\16\bin>psql -U postgres
psql (16.3)
ПРЕДУПРЕЖДЕНИЕ: Кодовая страница консоли (866) отличается от основной
                страницы Windows (1251).
                8-битовые (русские) символы могут отображаться некорректно.
                Подробнее об этом смотрите документацию psql, раздел
                "Notes for Windows users".
Введите "help", чтобы получить справку.

postgres=# psql -d dvdrental -U postgres
postgres-# psql \! chcp 1251
Текущая кодовая страница: 1251
postgres-# exit
Введите \q для выхода.
postgres-# \q

C:\Program Files\PostgreSQL\16\bin>psql -U postgres
psql (16.3)
Введите "help", чтобы получить справку.

```

![img](https://github.com/IlyaGall/C-/blob/main/28%20%D0%92%D1%8B%D0%B1%D0%BE%D1%80%D0%BA%D0%B8%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20%20%D0%94%D0%97/img/5.JPG)

[источник](https://iu5bmstu.ru/index.php/PostgreSQL_-_Кириллица_в_psql_под_Windows)

```
psql -d ВАШАБАЗА -U ВАШЛОГИН
psql \! chcp 1251
```

```
psql -d dvdrental -U postgres 
psql \! chcp 1251
```

Переключение на локального пользователя

```
postgres=# \c dvdrental
Вы подключены к базе данных "dvdrental" как пользователь "postgres".
dvdrental=# \dt
```
              Список отношений
 Схема  |      Имя      |   Тип   | Владелец
--------+---------------+---------+----------
 public | actor         | таблица | postgres
 public | address       | таблица | postgres
 public | category      | таблица | postgres
 public | city          | таблица | postgres
 public | country       | таблица | postgres
 public | customer      | таблица | postgres
 public | film          | таблица | postgres
 public | film_actor    | таблица | postgres
 public | film_category | таблица | postgres
 public | inventory     | таблица | postgres
 public | language      | таблица | postgres
 public | payment       | таблица | postgres
 public | rental        | таблица | postgres
 public | staff         | таблица | postgres
 public | store         | таблица | postgres
(15 строк)


dvdrental=#

![img](https://github.com/IlyaGall/C-/blob/main/28%20%D0%92%D1%8B%D0%B1%D0%BE%D1%80%D0%BA%D0%B8%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20%20%D0%94%D0%97/img/6.JPG)

[источник](https://neon.tech/postgresql/postgresql-getting-started/load-postgresql-sample-database)

![img](https://github.com/IlyaGall/C-/blob/main/28%20%D0%92%D1%8B%D0%B1%D0%BE%D1%80%D0%BA%D0%B8%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20%20%D0%94%D0%97/img/7.JPG)



## SELECT

Оператор выбора данных
```sql
select *, name 
From countries
```
'*'- выбрать все
'name' -колонки  name
'countries' - из таблицы countries

### Что еще можно выбрать

* Select Distinct – выбор уникальных значений
* Count(field) – выбор количества значений записей field
* Max(field), min(field) – максимальное и минимальное значение
* Avg(field) – среднее значение

### Оператор
Where – фильтрация данных
* >, <, >=, <=, =, !=, <> - операторы сравнения
* Like, not like – оператор сравнения по маске строки
* In, not in – операторы вхождения значения в список
* And, or – условия и/или
* Between - промежуток

## Соединение таблиц

join Оператор соединения двух таблиц
```sql
select u.username, c.name
from users u
join countries c
on c.id = u.country_id
```
Выбрать поля username и country.name из таблиц Users и countries, где записи равны по полям countries.id и users.country_id

## Первичный и внешний ключ

![img](https://github.com/IlyaGall/C-/blob/main/28%20%D0%92%D1%8B%D0%B1%D0%BE%D1%80%D0%BA%D0%B8%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20%20%D0%94%D0%97/img/8.JPG)


### (inner) join

![img](https://github.com/IlyaGall/C-/blob/main/28%20%D0%92%D1%8B%D0%B1%D0%BE%D1%80%D0%BA%D0%B8%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20%20%D0%94%D0%97/img/9.JPG)

### Left join

![img](https://github.com/IlyaGall/C-/blob/main/28%20%D0%92%D1%8B%D0%B1%D0%BE%D1%80%D0%BA%D0%B8%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20%20%D0%94%D0%97/img/10.JPG)

### Outer join

![img](https://github.com/IlyaGall/C-/blob/main/28%20%D0%92%D1%8B%D0%B1%D0%BE%D1%80%D0%BA%D0%B8%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20%20%D0%94%D0%97/img/11.JPG)

## Group by

Оператор группировки данных с агрегатами
```sql
select u.username, count(c.id)
from users u
join comments c on c.user_id=u.id
group by u.username
```
Вывести username и количество комментариев, которые он написал. Записи группируем по username

![img](https://github.com/IlyaGall/C-/blob/main/28%20%D0%92%D1%8B%D0%B1%D0%BE%D1%80%D0%BA%D0%B8%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20%20%D0%94%D0%97/img/12.JPG)

## having

Тот же where, только для группировок
```sql
select u.username, count(c.id)
from users u
join comments c on c.user_id=u.id
group by u.username
having count(c.id)>1
```

![img](https://github.com/IlyaGall/C-/blob/main/28%20%D0%92%D1%8B%D0%B1%D0%BE%D1%80%D0%BA%D0%B8%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20%20%D0%94%D0%97/img/13.JPG)

## Порядок выполнения команд
1. FROM (выбор таблицы)
2. JOIN (комбинация с подходящими по условию данными из других таблиц)
3. WHERE (фильтрация строк)
4. GROUP BY (агрегирование данных)
5. HAVING (фильтрация агрегированных данных)
6. SELECT (возврат результирующего датасета)
7. DISTINCT (устранение повторяющихся и извлечение только уникальных строк)
8. ORDER BY (сортировка).
9. LIMIT (ограничение на количество возвращаемых строк)








