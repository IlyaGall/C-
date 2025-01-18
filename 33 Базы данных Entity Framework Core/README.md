# Работа с базой данных с помощью Entity Framework Core

* **object-relational mapping** – установление соответствия между структурой БД и моделями в приложении.

**Для чего:** чтобы при разработке бекэнда работать только с кодом, а всю работу с БД делегировать библиотеке.

**Требование**: состояние моделей должно однозначно соответствовать структуре БД

![img](https://github.com/IlyaGall/C-/blob/main/33%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20Entity%20Framework%20Core/IMG/1.JPG)

### Модель

![img](https://github.com/IlyaGall/C-/blob/main/33%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20Entity%20Framework%20Core/IMG/2.JPG)

### Какие модели мапить с помощью ОРМ

Виды моделей
1. Доменные модели (Entities), находятся в ядре
2. Модели логики (DTO), находятся в Domain Services
3. Модели для работы с клиентом, находятся в API (модели API)

![img](https://github.com/IlyaGall/C-/blob/main/33%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20Entity%20Framework%20Core/IMG/3.JPG)

### Какие модели мапить с помощью ОРМ

Виды моделей
1. Доменные модели (Entities), находятся в слое Data Access
2. Модели логики (DTO), находятся в слое Business Logic
3. Модели для работы с клиентом, находятся в API (модели API)

![img](https://github.com/IlyaGall/C-/blob/main/33%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20Entity%20Framework%20Core/IMG/4.JPG)

### Какие модели мапить с помощью ОРМ

![img](https://github.com/IlyaGall/C-/blob/main/33%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20Entity%20Framework%20Core/IMG/5.JPG)


## EF Core и его настройка


### Настройка EF
1. Добавить нугеты
* Microsoft.EntityFrameworkCore
* Microsoft.EntityFrameworkCore.Design
* Microsoft.EntityFrameworkCore.Tools

и другие нугеты EF в случае необходимости
2. Добавить код регистрации библиотек в IOC - контейнере
3. Указать Connection String

https://learn.microsoft.com/enus/dotnet/api/system.data.sqlclient.sqlconnection.connectionstring?view=dotnet-plat-ext7.0&viewFallbackFrom=net-6.0

### Context как главный объект работы с EF

Все взаимодействия кода с БД настраиваются через Context. Context реализует паттерн “репозиторий” Паттерн “репозиторий” – предоставление возможности работы с данными из хранилища как с коллекциями (https://martinfowler.com/eaaCatalog/repository.html)

Чтобы поработать с коллекцией объектов, нужно обратившись к контексту, вызвать или декларированную коллекцию или метод Set<>. Полученный DbSet и будет нужной коллекцией

Часто репозиторий в виде Context заворачивают в еще один репозитрий

### Класс контекста
Основные функции:
1. Содержит перечень коллекций моделей
2. Содержит конфигурацию моделей и настроек работы с ними (методы OnModelCreating и т.д.)

### Чтение и изменение данных через EF Core


### Операции над доменной моделью с помощью EF
CRUD
1. Обратиться к контексту, получить DbSet доменной модели
2. Выполнить одну из CRUD – операций
3. При необходимости вызвать метод сохранения в БД с пом. SaveChanges

### Статусы сущности

* Added: сущность отслеживается контекстом но пока не существует в БД
* Unchanged: сущность отслеживается контекстом, существует в БД, свойства не отличаются от соответствующих значений в БД
* Modified: сущность отслеживается контекстом, существует в БД, некоторые свойства отличаются от соответствующих значений в БД
* Deleted: сущность отслеживается контекстом, существует в БД, помечена для удаления в бд при следующем вызове SaveChanges
* Detached: сущность не отслеживается контекстом

### Linq

Language Integrated Query

Технология создания запросов средствами языка C#

### Отложенные запросы
Позволяют сформировать запрос динамически и только после этого выполнить его на сервере.
Реализуются объектами типа IQueryable.

## Миграции базы данных


### Работа с миграциями в EF Миграция это код, который:

1. Генерируется EF по нашей команде (migrations add) и содержит в себе те изменения, которые мы внесли в модель с момента последней миграции (проверка по Snapshot)
2. По нашей команде (database update) превращается в sql-скрипт и применяется к БД, если еще не была применена (проверка по MigrationHistory)

### Работа с миграциями в EF
* Используется утилита **dotnet-ef**
* Посмотреть версию: **dotnet ef -version**
* Установить версию: **dotnet tool install --global dotnet-ef --version 8.0.0**
* Удалить последнюю версию: **dotnet tool uninstall --global dotnet-ef**

### Работа с миграциями в EF
1. Сгенерировать миграцию
**dotnet ef migrations add Seeding --startup-project <стартовый проект> --project <проект с EF> --context <наименование контекста>**
2. Обновить БД
**dotnet ef database update --startup-project <стартовый проект> --project <проект с EF> --context <наименование контекста>**
3. Обновить БД до миграции
**dotnet ef database update Seeding --startup-project <стартовый проект> --project <проект с EF> --context <наименование контекста>**
4.Удалить последнюю миграцию
**dotnet ef migrations remove --startup-project <стартовый проект> --project <проект с EF> --context <наименование контекста>**
В Nuget команды немного отличаются


### Snapshot
Используется при генерации миграции чтобы определить изменения

До EF Core был в составе миграций, что приводило к потерям изменений при командной разработке.

Начиная с EF Core вынесли в отдельный файл. (те снепшоты которые остались в миграциях, не используются для сравнения).

### MigrationHistory

Используется при обновлении БД чтобы определить, какие миграции применять

### Применение миграций к БД

1. С помощью утилиты dotnet ef - database update - этот подход удобен для локальной разработки
2. Программно в коде - context.Database.Migrate() - этот подход удобен для локальной разработки
3. Генерируя sql скрипты dotnet ef migrations script - этот подход удобен для применения на стендах 

[Применение миграций к БД](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/applying?tabs=dotnet-core-cli)
### Migrate и Seeding

Migrate применяет миграции к БД

Seeding – операция заполнения БД начальными данными

[Seeding](https://learn.microsoft.com/en-us/ef/core/modeling/data-seeding)

## Конигурирование отношений и иерархий

### Конфигурирование отношений
1. [Один-к-одному](https://www.entityframeworktutorial.net/efcore/configure-one-to-one-relationship-usingfluent-api-in-ef-core.aspx)
2. [Один-ко-многим](https://www.entityframeworktutorial.net/efcore/configure-one-to-many-relationshipusing-fluent-api-in-ef-core.aspx)
3. [Многие-ко-многим](https://www.entityframeworktutorial.net/efcore/configure-many-to-manyrelationship-in-ef-core.aspx)

### Конфигурирование иерархий

1. Table-per-hierarchy (TPH) – по умолчанию
2. Table-Per-Type (TPT) - с EF 5
3. The table-per-concrete-type (TPC) – c EF 7

[описание](https://learn.microsoft.com/en-us/ef/core/modeling/inheritance)

![img](https://github.com/IlyaGall/C-/blob/main/33%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20Entity%20Framework%20Core/IMG/6.JPG)

## Оптимизация работы с EF

### Загрузка связанных данных
1. Eager loading – загрузка тех связанных данных, которые явно указаны с помощью Include (ThenInclude)
2. Lazy loading – загрузка всех связанных данных, но не сразу а при необходимости
3. Explicit loading – явная загрузка связанной сущности методом Load в коде

### Отслеживание изменений
1. Сущность получаемая из БД меняется и сохраняется в БД

![img](https://github.com/IlyaGall/C-/blob/main/33%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20Entity%20Framework%20Core/IMG/7.JPG)

2. Сущность получаемая из БД не сохраняется в БД а отдается клиенту

![img](https://github.com/IlyaGall/C-/blob/main/33%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20Entity%20Framework%20Core/IMG/8.JPG)

Чтобы не сохранить изменяемую сущность как новую EF «помнит» что она взята из БД с пом. механизма трекинга

### Отслеживание изменений
Трекинг потребляет дополнительную память и добавляет накладные расходы на обработку

Можно отключать с помощью AsNoTracking 

Преимущества AsNoTracking
1. Меньшее потребление памяти
2. Более быстрее прохождение запроса 

### Компиляция и кэширование
Дерево выражений компилируется в sql-запрос
Для ускорения происходит кэширование

![img](https://github.com/IlyaGall/C-/blob/main/33%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20Entity%20Framework%20Core/IMG/9.JPG)

В первом примере кэширование работать не будет
Чтобы исключить даже обращение в кэш, можно использовать скомпилированные
запросы EF.CompileAsyncQuery (но переходить к ним лучше после профилирования)

### Unit Of Work (Единица работы)

Обслуживает набор объектов, изменяемых в бизнес-транзакции (бизнесдействии) и управляет записью изменений и разрешением проблем конкуренции данных.

Когда необходимо писать и читать из БД, важно следить за тем, что вы изменили и если не изменили - не записывать данные в БД. Также необходимо вставлять данные о новых объектах и удалять данные о старых.

Реализация паттерна Unit of Work следит за всеми действиями приложения, которые могут изменить БД в рамках одного бизнес-действия. Когда бизнесдействие завершается, Unit of Work выявляет все изменения и вносит их в БД.

По факту требует отслеживания изменений в данных на уровне приложения и фиксации изменений в одной транзакции

[Справочник «Паттерны проектирования»](https://design-pattern.ru/patterns/unit-of-work.html)

### Список материалов для изучения

* [Repository](https://martinfowler.com/eaaCatalog/repository.html)
* https://learn.microsoft.com/en-us/ef/core/modeling/inheritance 
* https://www.entityframeworktutorial.net/efcore/configure-one-to-one-relationship-using-fluentapi-in-ef-core.aspx 
* https://www.entityframeworktutorial.net/efcore/configure-one-to-many-relationship-using-fluentapi-in-ef-core.aspx 
* https://www.entityframeworktutorial.net/efcore/configure-many-to-many-relationship-in-efcore.aspx 
* Мартин Фаулер. Архитектура корпоративных программных приложений





