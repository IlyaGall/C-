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

