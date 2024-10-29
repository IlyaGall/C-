# Введение в базы данных

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


```pg_restore -U postgres -d dvdrental C:\gitHub\C-\28 Выборки данных  ДЗ\dvdrental\dvdrental.tar```
! в пути к файлу не должно быть кириллицы
```pg_restore -U postgres -d dvdrental C:\Users\Ilya\Desktop\dvdrental.tar```

![img](https://github.com/IlyaGall/C-/blob/main/28%20%D0%92%D1%8B%D0%B1%D0%BE%D1%80%D0%BA%D0%B8%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20%20%D0%94%D0%97/img/3.JPG)
