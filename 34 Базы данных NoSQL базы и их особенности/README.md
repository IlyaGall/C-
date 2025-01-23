# Базы данных: NoSQL базы и их особенности

## От реляционных СУБД к NoSQL СУБД

![img](https://github.com/IlyaGall/C-/blob/main/34%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20NoSQL%20%D0%B1%D0%B0%D0%B7%D1%8B%20%D0%B8%20%D0%B8%D1%85%20%D0%BE%D1%81%D0%BE%D0%B1%D0%B5%D0%BD%D0%BD%D0%BE%D1%81%D1%82%D0%B8/IMG/1.JPG)

### Интересные факты о термине NoSQL

![img](https://github.com/IlyaGall/C-/blob/main/34%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20NoSQL%20%D0%B1%D0%B0%D0%B7%D1%8B%20%D0%B8%20%D0%B8%D1%85%20%D0%BE%D1%81%D0%BE%D0%B1%D0%B5%D0%BD%D0%BD%D0%BE%D1%81%D1%82%D0%B8/IMG/2.JPG)

### Сравнение SQL и NoSQL СУБД


| Описание | SQL | NoSQL |
| -------- | --- | ----- |
| CУБД | реляционная | не-реляционная или распределенная |
| Схема данных | Зафиксированная или статическая предопределенная | динамическая |
| Хранилище данных | БД не ориентирована на иерархическое, распределенное хранилище данных | БД ориентированы на иерархическое, распределенное хранилище данных |
| Масштабируемость | вертикальная | горизонтальная |
| Принципы построения | ACID | BASE |

### ACID принципы в транзакционной системе
* Atomicity - атомарность транзакций
* Consistency - согласованность данных базы после завершения транзакций
* Isolation - изолированность транзакций
* Durability - долговечность данных, независимо от внутренних или внешних сбоев

![img](https://github.com/IlyaGall/C-/blob/main/34%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20NoSQL%20%D0%B1%D0%B0%D0%B7%D1%8B%20%D0%B8%20%D0%B8%D1%85%20%D0%BE%D1%81%D0%BE%D0%B1%D0%B5%D0%BD%D0%BD%D0%BE%D1%81%D1%82%D0%B8/IMG/3.JPG)

### BASE принципы работы NoSQL СУБД
* **Basically available** - базовая доступность - каждый запрос гарантированно завершается (успешно или безуспешно)
* **Soft state** - гибкое состояние - состояние системы может меняться с течением времени, даже без ввода новых данных
* **Eventually consistent** - данные могут быть некоторое время рассогласованы, но приходят к согласованному состоянию через некоторое конечное время

### книги

![img](https://github.com/IlyaGall/C-/blob/main/34%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20NoSQL%20%D0%B1%D0%B0%D0%B7%D1%8B%20%D0%B8%20%D0%B8%D1%85%20%D0%BE%D1%81%D0%BE%D0%B1%D0%B5%D0%BD%D0%BD%D0%BE%D1%81%D1%82%D0%B8/IMG/4.JPG)

* Martin Fowler “NoSQL Distilled: A Brief Guide to the Emerging World of Polyglot Persistence”
* Eric Evans “Domain Driven Design”


### Паттерн “Агрегат” 

Совокупность взаимосвязанных объектов, которые мы воспринимаем как единое целое с точки зрения изменения данных, называется АГРЕГАТОМ (AGGREGATE). У каждого АГРЕГАТА есть корневой объект и есть граница. Граница определяет, что находится внутри АГРЕГАТА. Корневой объект - это один конкретный объект - СУЩНОСТЬ (ENTITY), содержащийся в АГРЕГАТЕ. Корневой объект - единственный член АГРЕГАТА, на который могут ссылаться внешние объекты, в то время как объекты, заключенные внутри границы, могут ссылаться друг на друга как угодно. СУЩНОСТИ, отличные от корневого объекта, локально индивидуальны, но различаться они должны только в пределах АГРЕГАТА, поскольку никакие внешние объекты все равно не могут их видеть вне контекста корневой СУЩНОСТИ

![img](https://github.com/IlyaGall/C-/blob/main/34%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20NoSQL%20%D0%B1%D0%B0%D0%B7%D1%8B%20%D0%B8%20%D0%B8%D1%85%20%D0%BE%D1%81%D0%BE%D0%B1%D0%B5%D0%BD%D0%BD%D0%BE%D1%81%D1%82%D0%B8/IMG/5.JPG)


### Паттерн “Агрегат”

![img](https://github.com/IlyaGall/C-/blob/main/34%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20NoSQL%20%D0%B1%D0%B0%D0%B7%D1%8B%20%D0%B8%20%D0%B8%D1%85%20%D0%BE%D1%81%D0%BE%D0%B1%D0%B5%D0%BD%D0%BD%D0%BE%D1%81%D1%82%D0%B8/IMG/6.JPG)

* Единая сущность в доменной модели
* Поиск данных по ключу (возможно через индекс)
* Единица хранения данных
* Простота ORM

### CAP теорема Эрика Брюера
Эвристическое утверждение о том, что в любой реализации распределённых вычислений возможно обеспечить не более двух из трёх следующих свойств:
* согласованность данных (consistency) — во всех вычислительных узлах в один момент времени данные не противоречат друг другу
* доступность (availability) — любой запрос к распределённой системе завершается корректным откликом, однако без гарантии, что ответы всех узлов системы совпадают
* устойчивость к разделению ( partition tolerance) — расщепление распределённой системы на несколько изолированных секций не приводит к некорректности отклика от каждой из секций.

![img](https://github.com/IlyaGall/C-/blob/main/34%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20NoSQL%20%D0%B1%D0%B0%D0%B7%D1%8B%20%D0%B8%20%D0%B8%D1%85%20%D0%BE%D1%81%D0%BE%D0%B1%D0%B5%D0%BD%D0%BD%D0%BE%D1%81%D1%82%D0%B8/IMG/7.JPG)

### CAP теорема Эрика Брюера

![img](https://github.com/IlyaGall/C-/blob/main/34%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20NoSQL%20%D0%B1%D0%B0%D0%B7%D1%8B%20%D0%B8%20%D0%B8%D1%85%20%D0%BE%D1%81%D0%BE%D0%B1%D0%B5%D0%BD%D0%BD%D0%BE%D1%81%D1%82%D0%B8/IMG/8.JPG)

### PACELC теорема - расширение CAP теоремы

В случае разделения сети (P) в распределенной компьютерной системе необходимо выбирать между доступностью (A) и согласованностью (C) (согласно теореме CAP), но в любом случае, даже если система работает нормально в отсутствии разделения (E), нужно выбирать между :
* задержками (Latency)
* согласованностью (Consistency)

![img](https://github.com/IlyaGall/C-/blob/main/34%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20NoSQL%20%D0%B1%D0%B0%D0%B7%D1%8B%20%D0%B8%20%D0%B8%D1%85%20%D0%BE%D1%81%D0%BE%D0%B1%D0%B5%D0%BD%D0%BD%D0%BE%D1%81%D1%82%D0%B8/IMG/9.JPG)

### Фрагментация

![img](https://github.com/IlyaGall/C-/blob/main/34%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20NoSQL%20%D0%B1%D0%B0%D0%B7%D1%8B%20%D0%B8%20%D0%B8%D1%85%20%D0%BE%D1%81%D0%BE%D0%B1%D0%B5%D0%BD%D0%BD%D0%BE%D1%81%D1%82%D0%B8/IMG/10.JPG)

![img](https://github.com/IlyaGall/C-/blob/main/34%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20NoSQL%20%D0%B1%D0%B0%D0%B7%D1%8B%20%D0%B8%20%D0%B8%D1%85%20%D0%BE%D1%81%D0%BE%D0%B1%D0%B5%D0%BD%D0%BD%D0%BE%D1%81%D1%82%D0%B8/IMG/11.JPG)

### Репликации
* репликация основной копии или ведущийведомый

![img](https://github.com/IlyaGall/C-/blob/main/34%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20NoSQL%20%D0%B1%D0%B0%D0%B7%D1%8B%20%D0%B8%20%D0%B8%D1%85%20%D0%BE%D1%81%D0%BE%D0%B1%D0%B5%D0%BD%D0%BD%D0%BE%D1%81%D1%82%D0%B8/IMG/12.JPG)

* одноранговая или симметричная репликация

![img](https://github.com/IlyaGall/C-/blob/main/34%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20NoSQL%20%D0%B1%D0%B0%D0%B7%D1%8B%20%D0%B8%20%D0%B8%D1%85%20%D0%BE%D1%81%D0%BE%D0%B1%D0%B5%D0%BD%D0%BD%D0%BE%D1%81%D1%82%D0%B8/IMG/13.JPG)

### CRUD операции на SQL и NoSQL СУБД

![img](https://github.com/IlyaGall/C-/blob/main/34%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20NoSQL%20%D0%B1%D0%B0%D0%B7%D1%8B%20%D0%B8%20%D0%B8%D1%85%20%D0%BE%D1%81%D0%BE%D0%B1%D0%B5%D0%BD%D0%BD%D0%BE%D1%81%D1%82%D0%B8/IMG/14.JPG)

### Типы NoSQL СУБД
* Ключ - значение
* Документо-ориентированные
* Графовые
* Колоночные

![img](https://github.com/IlyaGall/C-/blob/main/34%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20NoSQL%20%D0%B1%D0%B0%D0%B7%D1%8B%20%D0%B8%20%D0%B8%D1%85%20%D0%BE%D1%81%D0%BE%D0%B1%D0%B5%D0%BD%D0%BD%D0%BE%D1%81%D1%82%D0%B8/IMG/15.JPG)


### Типы NoSQL СУБД : Ключ - значение

Ключ-значение – под каждым ключом что-то лежит, пока не запросим – не узнаем что именно 

* Redis
* DynamoDB
* Memcached

![img](https://github.com/IlyaGall/C-/blob/main/34%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20NoSQL%20%D0%B1%D0%B0%D0%B7%D1%8B%20%D0%B8%20%D0%B8%D1%85%20%D0%BE%D1%81%D0%BE%D0%B1%D0%B5%D0%BD%D0%BD%D0%BE%D1%81%D1%82%D0%B8/IMG/16.JPG)


### Типы NoSQL СУБД : Документно-ориентированная

Документно-ориентированная БД - аналог ключ-значение, но в качестве значений используется объекты в определенном формате (JSON, XML):
* Одиночные операции в CRUD выполняются гораздо быстрее
* Можно делать запросы к содержимому записи, не извлекая данных целиком
(сходство с RDBMS)


* MongoDB
* LiteDB
* CouchDB
* Elasticsearch

![img](https://github.com/IlyaGall/C-/blob/main/34%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20NoSQL%20%D0%B1%D0%B0%D0%B7%D1%8B%20%D0%B8%20%D0%B8%D1%85%20%D0%BE%D1%81%D0%BE%D0%B1%D0%B5%D0%BD%D0%BD%D0%BE%D1%81%D1%82%D0%B8/IMG/17.JPG)

### Типы NoSQL СУБД : Графовые БД

Графовые БД – единицы хранения: Узлы и ребра(связи). Запрос – обход данных от узла к узлу по ребрам на заданную глубину. Используются для хранения, управления, составления запросов к сложным тесно взаимосвязанным группам данных (социальные сети, сервисы рекомендаций, графы значений, логистика, геоинформационные системы).

* Neo4j
* OrientDb
* Titan

![img](https://github.com/IlyaGall/C-/blob/main/34%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20NoSQL%20%D0%B1%D0%B0%D0%B7%D1%8B%20%D0%B8%20%D0%B8%D1%85%20%D0%BE%D1%81%D0%BE%D0%B1%D0%B5%D0%BD%D0%BD%D0%BE%D1%81%D1%82%D0%B8/IMG/18.JPG)

### Типы NoSQL СУБД : Колоночные БД

Колоночные базы данных – данные хранятся в ячейках, сгруппированных в колонки Применяются в веб-индексировании, рекламе, телекоммуникациях, аналитических система и т.п.

* Cassandra
* Hbase
* Google BigTable

![img](https://github.com/IlyaGall/C-/blob/main/34%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20NoSQL%20%D0%B1%D0%B0%D0%B7%D1%8B%20%D0%B8%20%D0%B8%D1%85%20%D0%BE%D1%81%D0%BE%D0%B1%D0%B5%D0%BD%D0%BD%D0%BE%D1%81%D1%82%D0%B8/IMG/19.JPG)

### NoSQL СУБД : дополнительная информация

[NoSQL Database](https://hostingdata.co.uk/nosql-database/)

[популярность бд](https://db-engines.com/en/ranking)

### NoSQL СУБД : как начать использовать

* Установить локально
* Поднять локально в контейнере (Docker)
* Использовать облачный сервис 

## Redis


Redis
* Ключ-значение
* Хранит данные в оперативной памяти, при необходимости может сохранять данные на диске
* Доступ по общему паролю или без него
* Без ключа данные не получить
* https://hub.docker.com/u/redis - офицальный образ Docker
* https://hub.docker.com/r/redis/redis-stack
* Хранилище структурированных данных
* Работа с различными типами данных
* Обычно используется как кэш но может использоваться как полноценное хранилище для небольших проектов или брокер очередей
* Отлично документированная СУБД
* Поддерживает широкий спектр языков программирования

![img](https://github.com/IlyaGall/C-/blob/main/34%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20NoSQL%20%D0%B1%D0%B0%D0%B7%D1%8B%20%D0%B8%20%D0%B8%D1%85%20%D0%BE%D1%81%D0%BE%D0%B1%D0%B5%D0%BD%D0%BD%D0%BE%D1%81%D1%82%D0%B8/IMG/20.JPG)

### Redis -кэширование

![img](https://github.com/IlyaGall/C-/blob/main/34%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20NoSQL%20%D0%B1%D0%B0%D0%B7%D1%8B%20%D0%B8%20%D0%B8%D1%85%20%D0%BE%D1%81%D0%BE%D0%B1%D0%B5%D0%BD%D0%BD%D0%BE%D1%81%D1%82%D0%B8/IMG/21.JPG)


### Redis - брокер очередей

![img](https://github.com/IlyaGall/C-/blob/main/34%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20NoSQL%20%D0%B1%D0%B0%D0%B7%D1%8B%20%D0%B8%20%D0%B8%D1%85%20%D0%BE%D1%81%D0%BE%D0%B1%D0%B5%D0%BD%D0%BD%D0%BE%D1%81%D1%82%D0%B8/IMG/22.JPG)

### MongoDB

* Популярная документо-ориентированная БД
* Хранение данные в формате BSON
* Использование JavaScript для написания функций и запросов
* Возможность выполнения операций, аналогичных операциям в реляционных СУБД
* Поддержка хранимых процедур на JavaScript
* Валидация полей документов
* Возможность репликации
* Встроенная работа с гео-координатами
* Хорошо документированная СУБД
* Поддерживает широкий спектр языков программирования
* https://hub.docker.com/_/mongo
* https://www.mongodb.com/docs/drivers/csharp/current/

### MongoDB схема данных

![img](https://github.com/IlyaGall/C-/blob/main/34%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20NoSQL%20%D0%B1%D0%B0%D0%B7%D1%8B%20%D0%B8%20%D0%B8%D1%85%20%D0%BE%D1%81%D0%BE%D0%B1%D0%B5%D0%BD%D0%BD%D0%BE%D1%81%D1%82%D0%B8/IMG/23.JPG)

### MongoDB - операция выборка


![img](https://github.com/IlyaGall/C-/blob/main/34%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20NoSQL%20%D0%B1%D0%B0%D0%B7%D1%8B%20%D0%B8%20%D0%B8%D1%85%20%D0%BE%D1%81%D0%BE%D0%B1%D0%B5%D0%BD%D0%BD%D0%BE%D1%81%D1%82%D0%B8/IMG/24.JPG)

### MongoDB - паттерн Map Reduce - пайплайны аггрегации

![img](https://github.com/IlyaGall/C-/blob/main/34%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20NoSQL%20%D0%B1%D0%B0%D0%B7%D1%8B%20%D0%B8%20%D0%B8%D1%85%20%D0%BE%D1%81%D0%BE%D0%B1%D0%B5%D0%BD%D0%BD%D0%BE%D1%81%D1%82%D0%B8/IMG/25.JPG)

### MongoDB код С#
![img](https://github.com/IlyaGall/C-/blob/main/34%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20NoSQL%20%D0%B1%D0%B0%D0%B7%D1%8B%20%D0%B8%20%D0%B8%D1%85%20%D0%BE%D1%81%D0%BE%D0%B1%D0%B5%D0%BD%D0%BD%D0%BE%D1%81%D1%82%D0%B8/IMG/26.JPG)

### MongoDB - шардирование

![img](https://github.com/IlyaGall/C-/blob/main/34%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20NoSQL%20%D0%B1%D0%B0%D0%B7%D1%8B%20%D0%B8%20%D0%B8%D1%85%20%D0%BE%D1%81%D0%BE%D0%B1%D0%B5%D0%BD%D0%BD%D0%BE%D1%81%D1%82%D0%B8/IMG/27.JPG)

### MongoDB - репликация

![img](https://github.com/IlyaGall/C-/blob/main/34%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20NoSQL%20%D0%B1%D0%B0%D0%B7%D1%8B%20%D0%B8%20%D0%B8%D1%85%20%D0%BE%D1%81%D0%BE%D0%B1%D0%B5%D0%BD%D0%BD%D0%BE%D1%81%D1%82%D0%B8/IMG/28.JPG)

http://thesecretlivesofdata.com/raft/ - наглядная иллюстрация алгоритма репликации данных между нодами в распределенной системе(используется в MongoDB) https://www.mongodb.com/docs/manual/replication/

### LiteDB

* Документо-ориентированная
* Standalone СУБД, не требует установки и конфигурирования
* Легковесная
* Позволяет быстро начать работать с документо-ориентированным хранилищем
* https://www.litedb.org/

### Cassandra

* Колонко-ориентированное хранилище
* Не реляционная отказоустойчивая распределенная СУБД
* Гибридное NoSQL решение , сочетает модель хранения на основе столбцов с моделью key-value
* Рассчитана на создание крупномасштабных надежных хранилищ, представленных в виде хеш
* Разработана на Java в 2008 году
* Наиболее удобная база данных для кластеризации
* Единственная база данных, где скорость записи выше скорости чтения (около 80-360 МБ/с на узел)

### Cassandra - модель данных
* Столбец или колонка (column) – ячейка с данными, включающая 3 части: имя (column name)
в виде массива байтов, метку времени (timestamp) и само значение (value) также в виде байтового массива;
* Строка или запись (row) – именованная коллекция столбцов;
* Семейство столбцов (column family) – именованная коллекция строк;
* Пространство ключей (keyspace) – группа из нескольких семейств столбцов, собранных вместе.



![img](https://github.com/IlyaGall/C-/blob/main/34%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20NoSQL%20%D0%B1%D0%B0%D0%B7%D1%8B%20%D0%B8%20%D0%B8%D1%85%20%D0%BE%D1%81%D0%BE%D0%B1%D0%B5%D0%BD%D0%BD%D0%BE%D1%81%D1%82%D0%B8/IMG/29.JPG)


![img](https://github.com/IlyaGall/C-/blob/main/34%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20NoSQL%20%D0%B1%D0%B0%D0%B7%D1%8B%20%D0%B8%20%D0%B8%D1%85%20%D0%BE%D1%81%D0%BE%D0%B1%D0%B5%D0%BD%D0%BD%D0%BE%D1%81%D1%82%D0%B8/IMG/30.JPG)

* Столбец или колонка (column) – ячейка с данными, включающая 3 части: имя (column name) в виде массива байтов, метку времени (timestamp) и само значение (value) также в виде байтового массива;
* Строка или запись (row) – именованная коллекция столбцов;
* Семейство столбцов (column family) – именованная коллекция строк;
* Пространство ключей (keyspace) – группа из нескольких семейств столбцов, собранных вместе.

### Cassandra - создание пространства ключей

![img](https://github.com/IlyaGall/C-/blob/main/34%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20NoSQL%20%D0%B1%D0%B0%D0%B7%D1%8B%20%D0%B8%20%D0%B8%D1%85%20%D0%BE%D1%81%D0%BE%D0%B1%D0%B5%D0%BD%D0%BD%D0%BE%D1%81%D1%82%D0%B8/IMG/31.JPG)

![img](https://github.com/IlyaGall/C-/blob/main/34%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20NoSQL%20%D0%B1%D0%B0%D0%B7%D1%8B%20%D0%B8%20%D0%B8%D1%85%20%D0%BE%D1%81%D0%BE%D0%B1%D0%B5%D0%BD%D0%BD%D0%BE%D1%81%D1%82%D0%B8/IMG/32.JPG)

![img](https://github.com/IlyaGall/C-/blob/main/34%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20NoSQL%20%D0%B1%D0%B0%D0%B7%D1%8B%20%D0%B8%20%D0%B8%D1%85%20%D0%BE%D1%81%D0%BE%D0%B1%D0%B5%D0%BD%D0%BD%D0%BE%D1%81%D1%82%D0%B8/IMG/33.JPG)


![img](https://github.com/IlyaGall/C-/blob/main/34%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20NoSQL%20%D0%B1%D0%B0%D0%B7%D1%8B%20%D0%B8%20%D0%B8%D1%85%20%D0%BE%D1%81%D0%BE%D0%B1%D0%B5%D0%BD%D0%BD%D0%BE%D1%81%D1%82%D0%B8/IMG/34.JPG)

### Neo4j
* Графовая база данных
* Свободное поле объектов
* Объекты соединяются определенными типами связей


![img](https://github.com/IlyaGall/C-/blob/main/34%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20NoSQL%20%D0%B1%D0%B0%D0%B7%D1%8B%20%D0%B8%20%D0%B8%D1%85%20%D0%BE%D1%81%D0%BE%D0%B1%D0%B5%D0%BD%D0%BD%D0%BE%D1%81%D1%82%D0%B8/IMG/35.JPG)

![img](https://github.com/IlyaGall/C-/blob/main/34%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20NoSQL%20%D0%B1%D0%B0%D0%B7%D1%8B%20%D0%B8%20%D0%B8%D1%85%20%D0%BE%D1%81%D0%BE%D0%B1%D0%B5%D0%BD%D0%BD%D0%BE%D1%81%D1%82%D0%B8/IMG/36.JPG)


Список материалов для изучения
1. https://en.wikipedia.org/wiki/Database
2. https://en.wikipedia.org/wiki/Internet
3. https://en.wikipedia.org/wiki/Strozzi_NoSQL
4. https://www.geeksforgeeks.org/difference-between-sql-and-nosql/?ref=ml_lbp
5. https://phoenixnap.com/kb/acid-vs-base
6. https://ru.wikipedia.org/wiki/ACID
7. https://habr.com/ru/articles/555920/
8. https://www.yuji.page/acid/
9. https://cloud.yandex.ru/blog/posts/2022/10/nosql
10. https://ru.wikipedia.org/wiki/%D0%A2%D0%B5%D0%BE%D1%80%D0%B5%D0%BC%D0%B0_CAP
11. https://www.infoq.com/articles/cap-twelve-years-later-how-the-rules-have-changed/
12. https://habr.com/ru/articles/328792/
13. https://ru.wikipedia.org/wiki/%D0%A2%D0%B5%D0%BE%D1%80%D0%B5%D0%BC%D0%B0_PACELC
14. https://bigdataschool.ru/blog/cap-and-pacelc-in-kafka.html
15. https://web-creator.ru/articles/partitioning_replication_sharding
16. https://dzen.ru/a/ZElAFXc8MhP8ZU5K
17. https://martinfowler.com/books/nosql.html
18. https://www.diva-portal.org/smash/get/diva2:1681550/FULLTEXT01.pdf
19. https://learn.microsoft.com/ru-ru/dotnet/architecture/cloud-native/relational-vs-nosql-data
20. https://highload.guide/blog/NoSQL-quick-facts.html
21. https://hostingdata.co.uk/nosql-database/
22. https://db-engines.com/en/ranking
23. https://coderlessons.com/articles/java/osnovnye-kliuchi-mongodb-vash-drug
24. https://www.mongodb.com/docs/manual/tutorial/getting-started/
25. https://www.mongodb.com/docs/manual/sharding/
26. https://www.mongodb.com/docs/manual/replication/
27. http://thesecretlivesofdata.com/raft
28. https://www.postgresql.eu/events/pgconfeu2017/sessions/session/1596/slides/29/Distributed%20Computing%20on%20PostgreSQL.pdf
29. https://habr.com/ru/companies/piter/articles/275633/
30. https://xebia.com/blog/microservices-coupling-vs-autonomy/https://redis.io/
32. https://hub.docker.com/u/redis
33. https://habr.com/ru/companies/wunderfund/articles/685894/
34. https://www.mongodb.com/
35. https://www.litedb.org/
36. https://cassandra.apache.org/_/quickstart.html
37. https://www.cockroachlabs.com/
38. https://habr.com/ru/companies/flant/articles/327640/
39. https://devathon.com/blog/cockroachdb-vs-mysql-vs-postgresql-vs-mongodb-vs-cassandra/
40. https://blog.yakunin.dev/cockroachdb-postgresql/
41. https://www.digitalocean.com/community/tutorials/understanding-database-sharding
42. https://www.cockroachlabs.com/blog/limits-of-the-cap-theorem/
43. https://jepsen.io/consistency
44. http://www.cs.umd.edu/~abadi/papers/abadi-pacelc.pdf
45. https://redis.io/docs/latest/develop/data-types/streams/
46. https://github.com/neelabalan/mongodb-sample-dataset/tree/main
47. https://www.geeksforgeeks.org/datatypes-in-mongodb/
48. https://www.mongodb.com/docs/manual/reference/bson-types/
49. https://www.mongodb.com/docs/manual/core/views/create-view/




