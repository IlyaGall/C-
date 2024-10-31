create sequence countries_id_seq;

CREATE TABLE public.countries
(
   id integer NOT NULL DEFAULT nextval('countries_id_seq'::regclass),
   name character varying(1024) COLLATE pg_catalog."default" NOT NULL,
   CONSTRAINT countries_pkey PRIMARY KEY (id)
);

TABLESPACE pg_default;

ALTER TABLE public.countries
   OWNER to postgres;

INSERT INTO public.countries(
    name)
   VALUES ('Russia'), ('USA'),('France');

CREATE SEQUENCE users_id_seq START WITH 1; 

CREATE TABLE public.users
(
   id integer NOT NULL DEFAULT nextval('users_id_seq'::regclass),
   username character varying(1024) COLLATE pg_catalog."default" NOT NULL,
   email character varying(1024) COLLATE pg_catalog."default" NOT NULL,
   age integer NOT NULL,
   country_id integer,
   CONSTRAINT user_primary_key PRIMARY KEY (id),
   CONSTRAINT fk_country_user FOREIGN KEY (country_id)
       REFERENCES public.countries (id) MATCH SIMPLE
       ON UPDATE NO ACTION
       ON DELETE NO ACTION
);

TABLESPACE pg_default;

ALTER TABLE public.users OWNER to postgres;

insert into users(username, email, age, country_id)
values('afet', 'afet@yandex.ru', 40, 1),
('apushkin', 'apushkin@mail.ru', 35, 1),
('mtwain', 'mtwain@gmail.com', 70, 2),
('aduma', 'aduma@gmail.fr', 70, 3);

-- добавляю сообщения
-- Table: public.comments

-- DROP TABLE public.comments;
CREATE SEQUENCE comments_id_seq START WITH 1; 

CREATE TABLE public.comments
(
   id integer NOT NULL DEFAULT nextval('comments_id_seq'::regclass),
   user_id integer NOT NULL,
   text text COLLATE pg_catalog."default",
   date timestamp with time zone,
   CONSTRAINT comments_pkey PRIMARY KEY (id),
   CONSTRAINT "FK_user_comment" FOREIGN KEY (user_id)
       REFERENCES public.users (id) MATCH SIMPLE
       ON UPDATE NO ACTION
       ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE public.comments
   OWNER to postgres;

insert into comments(user_id, text, date)
values (4, 'something in french', '2020-04-03T14:30'),
( 2,'мой дядя самых честных правил', '2019-03-03T14:30'),
( 2,'когда не в шутку занемог', '2019-12-10T14:30'),
( 1,'Еще сообщения', '2019-12-11T14:30');

-- SELECT простой
select * from countries

-- SELECT с where
select id, name
from countries
where id = 2

-- SELECT отдельных колонок
select id, name
from countries
where id != 2

insert into countries (name) values('RUSSIA');
insert into countries (name) values('RUSSIA');

-- SELECT по маске
   select id, name
from countries
where name like '%S%';

select id, name
from countries
where name in ('France', 'USA1111' );

-- SELECT уникальных значений
select distinct name From countries

-- SELECT с сортировкой по полю name и id по убыванию
select * from countries
order by  name desc,id desc

select * From countries
where name='RUSSIA' and id=4;

select * From countries
where name='RUSSIA' or id=1;

-- JOIN простой
select c.name, u.username
from countries as c
join users as u on u.country_id=c.id;

select c.name as "Название страны", u.username as "Пользователь"
from countries  c
join users  u on u.country_id=c.id

-- LEFT JOIN (из Countries)
select c.name as "Название страны", u.username as "Пользователь"
from countries  c
left outer join users  u on u.country_id=c.id

select  u.username as "Пользователь", c.name as "Название страны"
from users  u
right outer join countries  c on u.country_id=c.id

select c.name as "Название страны", u.username as "Пользователь"
from countries  c
cross join users  u ;

alter table countries add column sokr text;
alter table users add column csokr text;

update countries set sokr='ru' where id in (1, 4, 5);
update countries set sokr='fr' where id in (3);
update countries set sokr='us' where id in (2);
update users set csokr='us' where id in (3);
update users set csokr='fr' where id in (4);
update users set csokr='ru' where id in (1, 2);

select c.name as "Название страны", u.username as "Пользователь", csokr, sokr
from countries  c
join users  u on u.csokr=c.sokr and u.country_id=c.id;

select c.name as "Название страны",
u.username as "Пользователь",
cc.text as "Комментарий"
from countries  c
join users  u on  u.country_id=c.id
left join comments cc on cc.user_id = u.id;

select u.username, count(c.id)
from users u
left join comments c on c.user_id= u.id
group by u.username, u.id, u.country_id

select c.name, min(u.age)
from users u
join countries c on c.id=u.country_id
group by  c.name

select c.name as "Название страны",

max(cc.date)
from countries  c
join users  u on  u.country_id=c.id
left join comments cc on cc.user_id = u.id
group by c.name;

-- Мега запрос
select distinct c.name, count(cc.*)
from countries c
join users u on u.country_id =c.id
join comments cc on cc.user_id = u.id
where c.id>1
group by c.name
having count(cc.*)>0
order by c.name desc
limit 1
