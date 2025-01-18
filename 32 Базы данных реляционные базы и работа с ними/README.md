# Базы данных: реляционные базы и работа с ними

## Базы данных: реляционные базы и работа с ними

### Причины медленных запросов

* Отсутствие индексации: Сканирует целые таблицы вместо использования индексов.
* Слишком много объединений: Избыточные или ненужные объединения увеличивают сложность.
* Большие наборы результатов: Запросы возвращают больше данных, чем необходимо.
* Плохо написанный SQL: Неэффективные запросы или плохой синтаксис могут снизить производительность.

### Методы оптимизации запросов

* Индексирование: используйте правильные типы индексов для ускорения доступа к данным.
* *Избегайте SELECT: указывайте только необходимые столбцы.
* Ограничение объединений: упрощайте запросы, сокращая количество объединений.
* Используйте предложения WHERE: фильтруйте данные как можно тщательнее.
* Используйте кэширование запросов: сохраняйте часто выполняемые запросы для более быстрого доступа.

### Мониторинг производительности запросов
* Используйте EXPLAIN в SQL для анализа планов выполнения запросов.
* Такие инструменты, как SQL Profiler или pgAdmin, помогают отслеживать медленные запросы.
* Отслеживайте время ответа: ищите медленно выполняющиеся запросы, которые превышают пороговые значения.
* Регулярно просматривайте журналы запросов для потенциальных оптимизаций.

### Лучшие практики оптимизации запросов
* Регулярно проверяйте и обновляйте индексы на основе использования запросов.
* Избегайте вложенных подзапросов; используйте объединения, где это возможно.
* Batch обновления и удаления для уменьшения блокировок.
* Тестируйте запросы в реальных сценариях перед развертыванием.
* Постоянно отслеживайте медленные запросы и снижение производительности.

## Выбор типов индексов для оптимизации запросов

### Почему индексы важны?
* Индексы позволяют быстрее извлекать данные без сканирования всей таблицы.
* Они действуют как «таблица содержания» для вашей базы данных.
* Индексы сокращают время запроса, особенно для больших наборов данных.
* Плохая индексация может замедлить вставки, обновления и удаления.


![img](https://github.com/IlyaGall/C-/blob/main/32%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20%D1%80%D0%B5%D0%BB%D1%8F%D1%86%D0%B8%D0%BE%D0%BD%D0%BD%D1%8B%D0%B5%20%D0%B1%D0%B0%D0%B7%D1%8B%20%D0%B8%20%D1%80%D0%B0%D0%B1%D0%BE%D1%82%D0%B0%20%D1%81%20%D0%BD%D0%B8%D0%BC%D0%B8/IMG/1.JPG)

### Типы индексов
* Кластеризованный индекс: Сортирует и сохраняет строки физически в таблице.
* Некластеризованный индекс: Отдельная структура от таблицы, как указатель на данные.
* Составной индекс: Индексирует по нескольким столбцам для сложных запросов.
* Уникальный индекс: Гарантирует отсутствие дубликатов значений в столбце.

![img](https://github.com/IlyaGall/C-/blob/main/32%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20%D1%80%D0%B5%D0%BB%D1%8F%D1%86%D0%B8%D0%BE%D0%BD%D0%BD%D1%8B%D0%B5%20%D0%B1%D0%B0%D0%B7%D1%8B%20%D0%B8%20%D1%80%D0%B0%D0%B1%D0%BE%D1%82%D0%B0%20%D1%81%20%D0%BD%D0%B8%D0%BC%D0%B8/IMG/2.JPG)

### Индексы - кластеризованные
* Кластеризованные индексы сортируют и хранят записи в таблицах или представлениях на основе их ключевых значений. Этими значениями являются столбцы, включенные в определение индекса. Существует только один кластеризованный индекс для каждой таблицы, так как записи в таблице могут храниться в единственном порядке.
* Записи в таблице хранятся в порядке сортировки только в том случае, если таблица содержит кластеризованный индекс. Если у таблицы есть кластеризованный индекс, то таблица называется кластеризованной. Если у таблицы нет кластеризованного индекса, то строки данных хранятся в неупорядоченной структуре, которая называется кучей (heap file, не путать со структурой данных).

### Индексы - некластеризованные
* Некластеризованные индексы имеют структуру, отдельную от основной структуры хранения таблицы. В некластеризованном индексе содержатся значения ключа некластеризованного индекса, и каждая запись значения ключа содержит указатель на строку данных, содержащую значение ключа.
* Указатель из строки индекса в некластеризованном индексе, который указывает на строку данных, называется указателем строки. Структура указателя строки зависит от того, хранятся ли страницы данных в куче или в кластеризованной таблице. Для кучи указатель строки является указателем на строку. Для кластеризованной таблицы указатель строки данных является ключом кластеризованного индекса.
* Вы можете добавить неключевые столбцы на конечный уровень некластеризованного индекса, чтобы обойти существующее ограничение на ключи индексов и выполнять полностью индексированные запросы.


### B-деревья

![img](https://github.com/IlyaGall/C-/blob/main/32%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20%D1%80%D0%B5%D0%BB%D1%8F%D1%86%D0%B8%D0%BE%D0%BD%D0%BD%D1%8B%D0%B5%20%D0%B1%D0%B0%D0%B7%D1%8B%20%D0%B8%20%D1%80%D0%B0%D0%B1%D0%BE%D1%82%D0%B0%20%D1%81%20%D0%BD%D0%B8%D0%BC%D0%B8/IMG/3.JPG)

### Хеш-индексы

![img](https://github.com/IlyaGall/C-/blob/main/32%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20%D1%80%D0%B5%D0%BB%D1%8F%D1%86%D0%B8%D0%BE%D0%BD%D0%BD%D1%8B%D0%B5%20%D0%B1%D0%B0%D0%B7%D1%8B%20%D0%B8%20%D1%80%D0%B0%D0%B1%D0%BE%D1%82%D0%B0%20%D1%81%20%D0%BD%D0%B8%D0%BC%D0%B8/IMG/4.JPG)

### Block Range Index (BRIN) 

![img](https://github.com/IlyaGall/C-/blob/main/32%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20%D1%80%D0%B5%D0%BB%D1%8F%D1%86%D0%B8%D0%BE%D0%BD%D0%BD%D1%8B%D0%B5%20%D0%B1%D0%B0%D0%B7%D1%8B%20%D0%B8%20%D1%80%D0%B0%D0%B1%D0%BE%D1%82%D0%B0%20%D1%81%20%D0%BD%D0%B8%D0%BC%D0%B8/IMG/5.JPG)

### GIN

![img](https://github.com/IlyaGall/C-/blob/main/32%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20%D1%80%D0%B5%D0%BB%D1%8F%D1%86%D0%B8%D0%BE%D0%BD%D0%BD%D1%8B%D0%B5%20%D0%B1%D0%B0%D0%B7%D1%8B%20%D0%B8%20%D1%80%D0%B0%D0%B1%D0%BE%D1%82%D0%B0%20%D1%81%20%D0%BD%D0%B8%D0%BC%D0%B8/IMG/6.JPG)

### GIST

![img](https://github.com/IlyaGall/C-/blob/main/32%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20%D1%80%D0%B5%D0%BB%D1%8F%D1%86%D0%B8%D0%BE%D0%BD%D0%BD%D1%8B%D0%B5%20%D0%B1%D0%B0%D0%B7%D1%8B%20%D0%B8%20%D1%80%D0%B0%D0%B1%D0%BE%D1%82%D0%B0%20%D1%81%20%D0%BD%D0%B8%D0%BC%D0%B8/IMG/7.JPG)

### Лучшие практики индексирования
* Индексируйте селективные столбцы: столбцы с высокой степенью изменчивости (например, идентификаторы клиентов).
* Избегайте индексирования небольших столбцов с низкой степенью изменчивости (например, пол, логические значения).
* Не индексируйте чрезмерно: слишком много индексов замедляют операции записи.
* Регулярно отслеживайте и перестраивайте индексы по мере изменения данных.

### Работа с планом запроса

![img](https://github.com/IlyaGall/C-/blob/main/32%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20%D1%80%D0%B5%D0%BB%D1%8F%D1%86%D0%B8%D0%BE%D0%BD%D0%BD%D1%8B%D0%B5%20%D0%B1%D0%B0%D0%B7%D1%8B%20%D0%B8%20%D1%80%D0%B0%D0%B1%D0%BE%D1%82%D0%B0%20%D1%81%20%D0%BD%D0%B8%D0%BC%D0%B8/IMG/8.JPG)

## Join, Group by

### inner Join
* Объединяет столбцы двух таблиц по общему признаку
* Если не удалось сопоставить – в результирующую выборку не попадает
```SQL
SELECT p.id, p.name, ps.id, ps.name
FROM persons p
INNER JOIN positions ps ON ps.id = p.post_id
```

![img](https://github.com/IlyaGall/C-/blob/main/32%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20%D1%80%D0%B5%D0%BB%D1%8F%D1%86%D0%B8%D0%BE%D0%BD%D0%BD%D1%8B%D0%B5%20%D0%B1%D0%B0%D0%B7%D1%8B%20%D0%B8%20%D1%80%D0%B0%D0%B1%D0%BE%D1%82%D0%B0%20%D1%81%20%D0%BD%D0%B8%D0%BC%D0%B8/IMG/9.JPG)


### Left Join

* Объединяет столбцы двух таблиц по общему признаку
* Если не удалось сопоставить – по всем выбранным столбцам правой таблицы подставляется null
```SQL
SELECT p.id, p.name, ps.id, ps.name
FROM persons p
LEFT JOIN positions ps ON ps.id = p.post_id
```
![img](https://github.com/IlyaGall/C-/blob/main/32%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20%D1%80%D0%B5%D0%BB%D1%8F%D1%86%D0%B8%D0%BE%D0%BD%D0%BD%D1%8B%D0%B5%20%D0%B1%D0%B0%D0%B7%D1%8B%20%D0%B8%20%D1%80%D0%B0%D0%B1%D0%BE%D1%82%D0%B0%20%D1%81%20%D0%BD%D0%B8%D0%BC%D0%B8/IMG/10.JPG)

### Right Join
* То же, что и Left Join, но порядок таблиц другой
* Обычно вместо него используют Left Join, поменяв таблицы местами
```SQL
SELECT p.id, p.name, ps.id, ps.name
FROM persons p
RIGHT JOIN positions ps ON ps.id = p.post_id

```
![img](https://github.com/IlyaGall/C-/blob/main/32%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20%D1%80%D0%B5%D0%BB%D1%8F%D1%86%D0%B8%D0%BE%D0%BD%D0%BD%D1%8B%D0%B5%20%D0%B1%D0%B0%D0%B7%D1%8B%20%D0%B8%20%D1%80%D0%B0%D0%B1%D0%BE%D1%82%D0%B0%20%D1%81%20%D0%BD%D0%B8%D0%BC%D0%B8/IMG/11.JPG)

### Left Outer Join

```SQL
* Объединяет столбцы двух таблиц по различающемуся признаку
* В выборку попадают только те строки левой таблицы, для которых нет сопоставления из
второй
SELECT p.id, p.name, ps.id, ps.name
FROM persons p
LEFT JOIN positions ps ON ps.id = p.post_id
WHERE ps.id IS NULL
```
![img](https://github.com/IlyaGall/C-/blob/main/32%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20%D1%80%D0%B5%D0%BB%D1%8F%D1%86%D0%B8%D0%BE%D0%BD%D0%BD%D1%8B%D0%B5%20%D0%B1%D0%B0%D0%B7%D1%8B%20%D0%B8%20%D1%80%D0%B0%D0%B1%D0%BE%D1%82%D0%B0%20%D1%81%20%D0%BD%D0%B8%D0%BC%D0%B8/IMG/12.JPG)

### Group By + Having
* Group By группирует выборку по признакам
* Having – похож на Where, но применяется к результату группировки
* Where нельзя использовать с агрегирующими функциями

![img](https://github.com/IlyaGall/C-/blob/main/32%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20%D1%80%D0%B5%D0%BB%D1%8F%D1%86%D0%B8%D0%BE%D0%BD%D0%BD%D1%8B%D0%B5%20%D0%B1%D0%B0%D0%B7%D1%8B%20%D0%B8%20%D1%80%D0%B0%D0%B1%D0%BE%D1%82%D0%B0%20%D1%81%20%D0%BD%D0%B8%D0%BC%D0%B8/IMG/13.JPG)

## ADO.NET Что это?

### ADO.NET
ADO.NET по-прежнему остается актуальной и широко используемой технологией доступа к данным в приложениях .NET.

Он предоставляет набор классов для автономного доступа к источникам данных, таким как базы данных и XML-файлы.
ADO.NET является частью .NET Framework и .NET Core/.NET 5+ (теперь называемой просто .NET) и остается основополагающей технологией доступа к данным. Хотя появились новые технологии и платформы доступа к данным, такие как Entity Framework (EF) и Dapper, ADO.NET далеко не устарел.

* **Производительность**: ADO.NET предлагает детальный контроль над взаимодействием с базой данных, который может быть более эффективным для определенных сценариев с высокой производительностью по сравнению с инструментами ORM (объектно-реляционное сопоставление), такими какEntity Framework.
* **Гибкость**: он предоставляет возможность выполнять необработанные SQLзапросы, хранимые процедуры и обрабатывать сложные транзакции, предлагая больший контроль над операциями с базой данных.

* **Легкость**: для приложений, не требующих накладных расходов на ORM, ADO.NET может быть более простым и понятным выбором.
* **Совместимость**: ADO.NET совместим с широким спектром поставщиков данных, что делает его универсальным для доступа к различным типам баз данных.
* **Зрелая и стабильная**. Будучи зрелой технологией, ADO.NET имеет хорошо зарекомендовавший себя и стабильный API с обширной документацией и поддержкой сообщества.

### Список команд


|№| команда | описание |
------------------------
|1.| SqlConnection | Подключение к БД с использованием Connection String|
|2.| SqlCommand | Команда (обертка над запросом) для отправки на сервер Позволяет также подставлять параметры в запрос |
|3.| SqlTransaction | Транзакция для выполнения нескольких запросов как единого целого |
|4.| SqlDataReader | Удобное средство для чтения множества строк из БД |
|5.| DataSet | Редко используемое (узкоспециализированное) средство для чтения таблицы БД иоперирования с ней оффлайн |

#### ExecuteScalar
ExecuteScalar — это метод в ADO.NET, который используется для выполнения запроса SQL и возврата первого столбца первой строки в наборе результатов, возвращаемом запросом. Любые другие столбцы и строки игнорируются. Этот метод обычно используется, когда вы хотите получить одно значение из базы данных, например число, сумму или значение определенного столбца из одной записи.

![img](https://github.com/IlyaGall/C-/blob/main/32%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20%D1%80%D0%B5%D0%BB%D1%8F%D1%86%D0%B8%D0%BE%D0%BD%D0%BD%D1%8B%D0%B5%20%D0%B1%D0%B0%D0%B7%D1%8B%20%D0%B8%20%D1%80%D0%B0%D0%B1%D0%BE%D1%82%D0%B0%20%D1%81%20%D0%BD%D0%B8%D0%BC%D0%B8/IMG/14.JPG)

#### ADO.NET async 

* SqlConnection.OpenAsync()
* SqlCommand.ExecuteNonQueryAsync()
* SqlCommand.ExecuteReaderAsync()
* SqlCommand.ExecuteScalarAsync()
* SqlDataReader.ReadAsync()

### Преимущества и недостатки ADO.NET
+ Использование чистого SQL (Спорно, так как изменение название столбца приводит к фотальным последсвиям)
+ Полный контроль за отправляемыми запросами
- Конвертация “C#-объект <-> SQL-представление” целиком на разработчике
- IDE не поможет с переименованиями
- Компилятор не поможет с контролем типов

### Когда использовать ADO.NET

Сложные транзакции, требующие детального контроля над соединением, командами и транзакциями.

Ситуации, когда разработчику необходимо использовать расширенные функции поставщика базы данных.

Обширных пользовательских манипуляций с данными и тонкой настройки производительности на уровне взаимодействия с базой данных.

Минимальные внешние зависимости, поскольку ADO.NET является частью .NET Framework.

```c#
using Npgsql;

public class Ado(string cs)
{
    private readonly string _cs = cs;

    public void GetVersion()
    {
        using (var connection = new NpgsqlConnection(_cs))
        {
            connection.Open();

            var sql = "SELECT version()";

            using var cmd = new NpgsqlCommand(sql, connection);

            var version = cmd.ExecuteScalar().ToString();

            Console.WriteLine($"PostgreSQL version: {version}");
        }
    }

    public void CreateClientsTable()
    {
        using var connection = new NpgsqlConnection(_cs);
        connection.Open();

        var sql = @"
CREATE SEQUENCE clients_id_seq;

CREATE TABLE clients
(
    id              BIGINT                      NOT NULL    DEFAULT NEXTVAL('clients_id_seq'),
    first_name      CHARACTER VARYING(255)      NOT NULL,
    last_name       CHARACTER VARYING(255)      NOT NULL,
    middle_name     CHARACTER VARYING(255),
    email           CHARACTER VARYING(255)      NOT NULL,
  
    CONSTRAINT clients_pkey PRIMARY KEY (id),
    CONSTRAINT clients_email_unique UNIQUE (email)
);

CREATE INDEX clients_last_name_idx ON clients(last_name);
CREATE UNIQUE INDEX clients_email_unq_idx ON clients(lower(email));
";

        using var cmd = new NpgsqlCommand(sql, connection);

        var affectedRowsCount = cmd.ExecuteNonQuery().ToString();

        Console.WriteLine($"Created CLIENTS table. Affected rows count: {affectedRowsCount}");
    }

    public void CreateDepositsTable()
    {
        using var connection = new NpgsqlConnection(_cs);
        connection.Open();

        var sql = @"
CREATE SEQUENCE deposits_id_seq;

CREATE TABLE deposits
(
    id              BIGINT                      NOT NULL    DEFAULT NEXTVAL('deposits_id_seq'),
    client_id       BIGINT                      NOT NULL,
    created_at      TIMESTAMP WITH TIME ZONE    NOT NULL,    
  
    CONSTRAINT deposits_pkey PRIMARY KEY (id),
    CONSTRAINT deposits_fk_client_id FOREIGN KEY (client_id) REFERENCES clients(id) ON DELETE CASCADE
);
";

        using var cmd = new NpgsqlCommand(sql, connection);

        var affectedRowsCount = cmd.ExecuteNonQuery().ToString();

        Console.WriteLine($"Created DEPOSITS table. Affected rows count: {affectedRowsCount}");
    }

    public void InsertClientsSimple()
    {
        using var connection = new NpgsqlConnection(_cs);
        connection.Open();

        var firstName = "Иван";
        var lastName = "Иванов";
        var sql = $@"
INSERT INTO clients(first_name, last_name, middle_name, email) 
VALUES ('{firstName}', '{lastName}', 'Иванович', 'ivan@mail.ru');
";

        using var cmd = new NpgsqlCommand(sql, connection);

        var affectedRowsCount = cmd.ExecuteNonQuery().ToString();

        Console.WriteLine($"Insert into CLIENTS table. Affected rows count: {affectedRowsCount}");
    }

    public void InsertClientsWithParams()
    {
        using var connection = new NpgsqlConnection(_cs);
        connection.Open();

        var sql = @"
INSERT INTO clients(first_name, last_name, middle_name, email) 
VALUES (:first_name, :last_name, :middle_name, :email);
";

        using var cmd = new NpgsqlCommand(sql, connection);
        var parameters = cmd.Parameters;
        parameters.Add(new NpgsqlParameter("first_name", "Константин"));
        parameters.Add(new NpgsqlParameter("last_name", "Константинов"));
        parameters.Add(new NpgsqlParameter("middle_name", "Константинович"));
        parameters.Add(new NpgsqlParameter("email", "konst@rambler.ru"));

        var affectedRowsCount = cmd.ExecuteNonQuery().ToString();

        Console.WriteLine($"Insert into CLIENTS table. Affected rows count: {affectedRowsCount}");
    }

    public void InsertClientsMultipleCommands()
    {
        using var connection = new NpgsqlConnection(_cs);
        connection.Open();

        var sql = @"
INSERT INTO clients(first_name, last_name, middle_name, email) 
VALUES (:first_name, :last_name, :middle_name, :email);
";

        using var cmd1 = new NpgsqlCommand(sql, connection);
        var parameters = cmd1.Parameters;
        parameters.Add(new NpgsqlParameter("first_name", "Иван"));
        parameters.Add(new NpgsqlParameter("last_name", "Петров"));
        parameters.Add(new NpgsqlParameter("middle_name", "Петрович"));
        parameters.Add(new NpgsqlParameter("email", "petr@yandex.ru"));

        var affectedRowsCount = cmd1.ExecuteNonQuery().ToString();

        Console.WriteLine($"Insert into CLIENTS table. Affected rows count: {affectedRowsCount}");

        sql = @"
SELECT first_name, last_name, middle_name, email FROM clients
WHERE first_name<>:first_name
";

        using var cmd2 = new NpgsqlCommand(sql, connection);
        parameters = cmd2.Parameters;
        parameters.Add(new NpgsqlParameter("first_name", "Иван"));

        var reader = cmd2.ExecuteReader();
        while (reader.Read())
        {
            var firstName = reader.GetString(0);
            var lastName = reader.GetString(1);
            var middleName = reader.GetString(2);
            var email = reader.GetString(3);

            Console.WriteLine($"Read: [firstName={firstName},lastName={lastName},middleName={middleName},email={email}]");
        }
    }

    public void Transaction()
    {
        using var connection = new NpgsqlConnection(_cs);
        connection.Open();

        using var transaction = connection.BeginTransaction();
        try
        {
            var sql = @"
INSERT INTO clients(first_name, last_name, middle_name, email) 
VALUES (:first_name, :last_name, :middle_name, :email)
RETURNING id;
";

            using var cmd1 = new NpgsqlCommand(sql, connection);
            var parameters = cmd1.Parameters;
            parameters.Add(new NpgsqlParameter("first_name", "Александр"));
            parameters.Add(new NpgsqlParameter("last_name", "Александров"));
            parameters.Add(new NpgsqlParameter("middle_name", "Александрович"));
            parameters.Add(new NpgsqlParameter("email", "alex@yandex.ru"));

            var clientId = (long)cmd1.ExecuteScalar();
            Console.WriteLine($"Insert into CLIENTS table. ClientId = {clientId}");

            // Специально кидаем исключение
            //throw new ApplicationException("Deliberate exception");

            sql = @"
INSERT INTO deposits(client_id, created_at) 
VALUES (:client_id, :created_at);
";

            using var cmd2 = new NpgsqlCommand(sql, connection);
            parameters = cmd2.Parameters;
            parameters.Add(new NpgsqlParameter("client_id", clientId));
            parameters.Add(new NpgsqlParameter("created_at", DateTime.Now));

            var affectedRowsCount = cmd2.ExecuteNonQuery().ToString();

            Console.WriteLine($"Insert into DEPOSITS table. Affected rows count: {affectedRowsCount}");

            transaction.Commit();
        }
        catch (Exception e)
        {
            transaction.Rollback();
            Console.WriteLine($"Rolled back the transaction");
            return;
        }
    }


```

## ORM. Что это?
ORM (Object-Relational Mapping): объектно-реляционное отображение — технология программирования, которая связывает базы данных с концепциями объектно-ориентированных языков программирования, создавая «виртуальную объектную базу данных».

ORM объединяет по своей сути различные парадигмы объектноориентированного программирования, где сущности представлены в виде классов и объектов, и реляционных баз данных, где данные хранятся в таблицах со строками и столбцами

### Какие модели маппит ORM

![img](https://github.com/IlyaGall/C-/blob/main/32%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20%D1%80%D0%B5%D0%BB%D1%8F%D1%86%D0%B8%D0%BE%D0%BD%D0%BD%D1%8B%D0%B5%20%D0%B1%D0%B0%D0%B7%D1%8B%20%D0%B8%20%D1%80%D0%B0%D0%B1%D0%BE%D1%82%D0%B0%20%D1%81%20%D0%BD%D0%B8%D0%BC%D0%B8/IMG/15.JPG)

![img](https://github.com/IlyaGall/C-/blob/main/32%20%D0%91%D0%B0%D0%B7%D1%8B%20%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85%20%D1%80%D0%B5%D0%BB%D1%8F%D1%86%D0%B8%D0%BE%D0%BD%D0%BD%D1%8B%D0%B5%20%D0%B1%D0%B0%D0%B7%D1%8B%20%D0%B8%20%D1%80%D0%B0%D0%B1%D0%BE%D1%82%D0%B0%20%D1%81%20%D0%BD%D0%B8%D0%BC%D0%B8/IMG/16.JPG)

### Преимущества и недостатки ORM

**Преимущества**
* **Простота**: ORM предоставляет простой интерфейс для работы с базой данных, который может быть понятным любому программисту. ORM скрывает сложности SQL-запросов, позволяя работать с данными на более высоком уровне абстракции.
* **Переносимость**: ORM может работать с различными СУДБ, что делает его более переносимым, чем SQL. Это позволяет разработчикам легко переносить свое приложение на другую СУБД без изменения кода.
* **Сопровождаемость**: ORM может значительно упростить сопровождение приложения, так как изменения в структуре базы данных могут быть внесены непосредственно в код ORM, а не в каждый SQL-запрос.
* **Безопасность**: ORM может предотвратить SQL-инъекции, поскольку ORM автоматически экранирует данные, которые передаются в базу данных.


**Недостатки**
* **Сложность**: ORM может быть сложным для понимания, особенно для новых разработчиков. ORM требует определенных знаний и опыта, чтобы использовать его эффективно.
* **Производительность**: ORM может быть менее эффективным, чем работа с SQL напрямую. ORM должен обрабатывать запросы и преобразовывать их в SQL, что может замедлить производительность.
* **Ограничения**: ORM может иметь ограничения в отношении того, какие запросы могут быть выполнены. В случае, когда нужно выполнить сложный запрос или использовать специфичные функции базы данных, может потребоваться написание SQL-запроса напрямую.

## Dapper

### Что такое Dapper

Легкий микро-ORM, разработанный Stack Overflow, известный своей простотой и производительностью. Позволяет разработчикам выполнять необработанные SQL-запросы и сопоставлять результаты запросов с объектами с минимальными издержками.

### пример

```C#
using Dapper;
using Npgsql;

public class DBDapper(string connectionString)
{
    private string _cs = connectionString;

    public void DapperUpsert()
    {
        using var connection = new NpgsqlConnection(connectionString);
        connection.Open();
        using NpgsqlTransaction transaction = connection.BeginTransaction();

        var clientDapperEntity = new ClientDapperEntity
        {
            Id = 100_000L,
            FirstName = "Вася",
            LastName = "Петров",
            MiddleName = "Петрович",
            Email = "petr@rambler.ru"
        };

        ClientDapperEntity existingClient = connection.QueryFirstOrDefault<ClientDapperEntity>(
                @"SELECT 
                        id,
                        first_name FirstName,
                        last_name LastName,
                        middle_name MiddleName,
                        email
                      FROM clients WHERE clients.id=@LookUpId",
                new
                {
                    LookUpId = clientDapperEntity.Id,
                },
                transaction);

        if (existingClient != null)
        {
            int affectedRowsCount = connection.Execute
            (@"UPDATE clients SET 
                    first_name = @FirstName,
                    last_name = @LastName,
                    middle_name = @MiddleName,
                    email = @Email
                   WHERE clients.id=@ToUpdateId",
                new
                {
                    ToUpdateId = existingClient.Id,
                    clientDapperEntity.FirstName,
                    clientDapperEntity.LastName,
                    clientDapperEntity.MiddleName,
                    clientDapperEntity.Email,
                },
                transaction);

            Console.WriteLine($"Dapper Update CLIENTS table: {affectedRowsCount} rows");
        }
        else
        {
            long newId = connection.QueryFirst<long>
            (@"INSERT INTO clients(id, first_name, last_name, middle_name, email) " +
             @"VALUES(@Id, @FirstName, @LastName, @MiddleName, @Email) " +
             @"RETURNING id",
                clientDapperEntity,
                transaction);

            Console.WriteLine($"Dapper Insert into CLIENTS table: {newId}");
        }

        transaction.Commit();
    }

    // Dapper: Joins
    public void JoinDapper()
    {
        using var connection = new NpgsqlConnection(connectionString);
        connection.Open();

        // multi mapping with Dapper
        IEnumerable<DepositDapperEntity> joinedDeposits = connection.Query<DepositDapperEntity, ClientDapperEntity, DepositDapperEntity>(
            @"SELECT 
                    d.id,
                    d.client_id ClientId,
                    d.created_at CreatedAt,
                    c.id,
                    c.first_name FirstName,
                    c.last_name LastName,
                    c.middle_name MiddleName,
                    c.email
                FROM deposits d
                JOIN clients c on c.id = d.client_id
                ORDER BY c.last_name",

            (deposit, client) =>
            {
                deposit.Client = client;
                return deposit;
            },

            splitOn: "Id" // optional
        );
        var joinedDeposit = joinedDeposits.First();

        Console.WriteLine($"Joined deposit: {joinedDeposit}");
    }
}
```

### Преимущества Dapper 

* быстрый
* позволяет использовать хранимые процедуры
* видно какой именно SQL запрос вы исполняете

### Сценарии использования Dapper 

* приложения, критичные к производительности, которым требуется детальный контроль над взаимодействием с базой данных.
* когда требуются сложные запросы или оптимизация базы данных

## OLAP OLTP

### Виды БД по назначению

* OLTP
    ○ OnLine Transaction Processing
    ○ Для оперативного учета: удобной вставки/обновления данных

### Виды БД по назначению


* OLTP
    ○ OnLine Transaction Processing
    ○ Для оперативного учета: удобной вставки/обновления данных
* OLAP
    ○ OnLine Analytical Processing
    ○ Для аналитики собранных данных
* Если смешивать два этих назначения в одной БД, то
    ○ Вставка может быть
    ○ медленной (много индексов)
    ○ неудобной (таблицы могут быть заточены под аналитику)
* Построение аналитических отчетов может быть
    ○ медленным (мало индексов)
    ○ сложным (структура таблиц заточена под вставку, сложная для анализа)
    ○ затормаживать работу базы данных для вставки актуальных данных
* Часто данные из OLTP БД реплицируются (копируются) в OLAP БД, где их уже спокойно анализируют аналитики.

### Список материалов для изучения
1. [Learn Dapper](https://www.learndapper.com/)
2. [LINQ to DB](https://linq2db.github.io/)
3. [404](https://learn.microsoft.com/enus/dotnet/api/system.data.sqlclient.sqlconnection.connectionstring?view=dotnet-plat-ext7.0&viewFallbackFrom=net-6.0)
4. [Репозиторий](https://martinfowler.com/eaaCatalog/repository.html)
5. [Entity](https://learn.microsoft.com/en-us/ef/core/modeling/inheritance)
6. [Entity тутория по связям](https://www.entityframeworktutorial.net/efcore/configure-many-to-many-relationship-in-ef-core.aspx)
7. Мартин Фаулер. Архитектура корпоративных программных приложений 
8. [ссылка на репозиторий](https://gitlab.com/aa.gerasimenko/otus.csharppro.db)





