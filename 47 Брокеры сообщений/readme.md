# Брокеры сообщений на примере RabbitMQ 

## Взаимодействия между микросервисами

Основные способы взаимодействий между сервисами в микросервисной архитектуре:
1. Синхронное взаимодействие 

Отправитель ждет от получателя ответ на запрос.
Например, HTTP

2. Асинхронное взаимодействие
Отправитель не ждет от получателя ответ на запрос.
AMQP (Advanced Message Queuing Protocol)

![img](https://github.com/IlyaGall/C-/blob/main/47%20%D0%91%D1%80%D0%BE%D0%BA%D0%B5%D1%80%D1%8B%20%D1%81%D0%BE%D0%BE%D0%B1%D1%89%D0%B5%D0%BD%D0%B8%D0%B9/img/1.JPG)

1. Синхронное взаимодействие Отправитель ждет ответ на запрос Например, HTTP


![img](https://github.com/IlyaGall/C-/blob/main/47%20%D0%91%D1%80%D0%BE%D0%BA%D0%B5%D1%80%D1%8B%20%D1%81%D0%BE%D0%BE%D0%B1%D1%89%D0%B5%D0%BD%D0%B8%D0%B9/img/2.JPG)

2. Асинхронное взаимодействие Отправитель не ждет ответа на запрос.
AMQP (Advanced Message Queuing Protocol)

![img](https://github.com/IlyaGall/C-/blob/main/47%20%D0%91%D1%80%D0%BE%D0%BA%D0%B5%D1%80%D1%8B%20%D1%81%D0%BE%D0%BE%D0%B1%D1%89%D0%B5%D0%BD%D0%B8%D0%B9/img/3.JPG)

## Брокер сообщений

Сервис, который принимает сообщения от клиента и осуществляет их маршрутизацию и постановку во временное хранилище (очередь/лог) по принципу FIFO.

## AMQP

AMQP – протокол, позволяющий приложениям обмениваться сообщениями через специальные сервисы – посредники, называемые брокерами сообщений.
(https://www.rabbitmq.com/tutorials/amqp-concepts.html)

## Основные функции брокера

1. Обеспечение возможности асинхронной обработки сообщений, достигающееся наличием очередей

![img](https://github.com/IlyaGall/C-/blob/main/47%20%D0%91%D1%80%D0%BE%D0%BA%D0%B5%D1%80%D1%8B%20%D1%81%D0%BE%D0%BE%D0%B1%D1%89%D0%B5%D0%BD%D0%B8%D0%B9/img/4.JPG)

2. Централизованная маршрутизация

![img](https://github.com/IlyaGall/C-/blob/main/47%20%D0%91%D1%80%D0%BE%D0%BA%D0%B5%D1%80%D1%8B%20%D1%81%D0%BE%D0%BE%D0%B1%D1%89%D0%B5%D0%BD%D0%B8%D0%B9/img/5.JPG)

## PUSH и PULL архитектуры брокеров

![img](https://github.com/IlyaGall/C-/blob/main/47%20%D0%91%D1%80%D0%BE%D0%BA%D0%B5%D1%80%D1%8B%20%D1%81%D0%BE%D0%BE%D0%B1%D1%89%D0%B5%D0%BD%D0%B8%D0%B9/img/6.JPG)

## Очередь и лог

![img](https://github.com/IlyaGall/C-/blob/main/47%20%D0%91%D1%80%D0%BE%D0%BA%D0%B5%D1%80%D1%8B%20%D1%81%D0%BE%D0%BE%D0%B1%D1%89%D0%B5%D0%BD%D0%B8%D0%B9/img/7.JPG)


Очередь является временным хранилищем, лог - постоянным

Лог может только дополняться

Сообщения персистентны

Сообщения неизменяемы

### Не очередь, а лог

![img](https://github.com/IlyaGall/C-/blob/main/47%20%D0%91%D1%80%D0%BE%D0%BA%D0%B5%D1%80%D1%8B%20%D1%81%D0%BE%D0%BE%D0%B1%D1%89%D0%B5%D0%BD%D0%B8%D0%B9/img/8.JPG)

Очередь могут читать несколько физических консьюмеров, но не могут несколько логических

![img](https://github.com/IlyaGall/C-/blob/main/47%20%D0%91%D1%80%D0%BE%D0%BA%D0%B5%D1%80%D1%8B%20%D1%81%D0%BE%D0%BE%D0%B1%D1%89%D0%B5%D0%BD%D0%B8%D0%B9/img/9.JPG)

Лог могут читать несколько логических консьюмеров, но не могут несколько физических

Решение

![img](https://github.com/IlyaGall/C-/blob/main/47%20%D0%91%D1%80%D0%BE%D0%BA%D0%B5%D1%80%D1%8B%20%D1%81%D0%BE%D0%BE%D0%B1%D1%89%D0%B5%D0%BD%D0%B8%D0%B9/img/10.JPG)

Решением для очереди является создание копии очереди для каждого логического консьюмера

![img](https://github.com/IlyaGall/C-/blob/main/47%20%D0%91%D1%80%D0%BE%D0%BA%D0%B5%D1%80%D1%8B%20%D1%81%D0%BE%D0%BE%D0%B1%D1%89%D0%B5%D0%BD%D0%B8%D0%B9/img/11.JPG)


Решением для лога является разбиение лога на части (НЕ копии) называемые партициями

Порядок сообщений

В очереди сообщения идут по порядку, а при обработке физическими консьюмерами порядок нарушается 

Решение – синхронизация в логическом консьюмере (напрмер стейтмашина)

**То есть встроенного решения нет**

В логе сообщения идут по порядку но при отправке в разные партиции порядок нарушается

Решение – отправлять сообщения, относящиеся к одной и той же сущности, в одну партицию

**То есть встроенное решение есть**

## Клиентские библиотеки для работы с брокерами

Rebbit:

Библиотеки для работы в .Net
- RabbitMQ.Client
- Masstransit.RabbitMQ
- NServiceBus
- EasyNetQ
- …

Kafka:

- Confluent Kafka Client
- …

## Виды гарантий доставки

* 0.No guarantee – нет гарантий доставки
* 1.At most once (0 или 1 раз) – есть вероятность что сообщение будет потеряно
* 2.At least once (1 и более раз) – есть гарантия доставки (самый распространенный), но есть вероятность дублирования
* 3.Exactly once (строго 1 раз) – есть гарантия доставки и отсутствия дублирования. Сложно гарантировать, обеспечивается в основном с помощью паттернов инбокс, аутбокс и тд

1. No guarantee
- Реализуется установкой автоподтверждения доставки в true.
- Сохранили в бд, не закоммитили, испытали сбой – обработается дважды
- Не сохранили в бд, закоммитили, испытали сбой – не обработается
- Недетерминированное поведение системы
2. At most once
- Реализуется установкой автоподтверждения доставки в false, подтверждение делается перед
- логической обработкой.
- Закоммитили, сохранили в бд – обработается один раз
- Закоммитили, испытали сбой, не сохранили в бд – не обработается
3. At least once
- Реализуется установкой автоподтверждения доставки в false, подтверждение делается после обработки.
- Сохранили в бд, закоммитили – обработается один раз
- Сохранили в бд, испытали сбой, не закоммитили, повторили – обработается больше одного раза
4. Exactly once
- Реализуется созданием кастомного хранилища офсетов (Custom offset manager)

## RabbitMQ

RabbitMQ реализован на очередях

![img](https://github.com/IlyaGall/C-/blob/main/47%20%D0%91%D1%80%D0%BE%D0%BA%D0%B5%D1%80%D1%8B%20%D1%81%D0%BE%D0%BE%D0%B1%D1%89%D0%B5%D0%BD%D0%B8%D0%B9/img/12.JPG)


### Подключение помощью RabbitMQ.Client

![img](https://github.com/IlyaGall/C-/blob/main/47%20%D0%91%D1%80%D0%BE%D0%BA%D0%B5%D1%80%D1%8B%20%D1%81%D0%BE%D0%BE%D0%B1%D1%89%D0%B5%D0%BD%D0%B8%D0%B9/img/13.JPG)

```C#
var cf = new ConnectionFactory();
var conn = cf.newConnection();
// the .NET client calls channels "models"
var ch = conn.CreateModel();
// do some work
// close the channel when it is no Longer needed
ch.Close();
```

### Основные понятия

![img](https://github.com/IlyaGall/C-/blob/main/47%20%D0%91%D1%80%D0%BE%D0%BA%D0%B5%D1%80%D1%8B%20%D1%81%D0%BE%D0%BE%D0%B1%D1%89%D0%B5%D0%BD%D0%B8%D0%B9/img/14.JPG)

* Publisher (отправитель) – сервис, отправляющий сообщение
* Consumer (потребитель) – сервис, принимающий сообщение
* Exchange (обменник) – маршрутизатор, определяющий, в какую очередь должно быть отправлено сообщение
* Queue (очередь) – место, где хранятся уже отправленные но еще не принятые сообщения по принципу FIFO

### Адресно-маршрутная информация сообщения

1. Наименование обменника (exchange)
2. Маршрутный ключ (routing key)
3. Хедеры (headers)

Nuget: RabbitMQ.Client

```c#
channel.BasicPublish(exchange: exchangeName,
    routingKey: "cars.2",
    basicProperties: null,
    body: body);
```
## Виды Exchange

1. Direct
2. Fanout
3. Topic
4. Headers


### Direct Exchange

![img](https://github.com/IlyaGall/C-/blob/main/47%20%D0%91%D1%80%D0%BE%D0%BA%D0%B5%D1%80%D1%8B%20%D1%81%D0%BE%D0%BE%D0%B1%D1%89%D0%B5%D0%BD%D0%B8%D0%B9/img/15.JPG)

### Fanout Exchange

![img](https://github.com/IlyaGall/C-/blob/main/47%20%D0%91%D1%80%D0%BE%D0%BA%D0%B5%D1%80%D1%8B%20%D1%81%D0%BE%D0%BE%D0%B1%D1%89%D0%B5%D0%BD%D0%B8%D0%B9/img/16.JPG)

### Topic Exchange

![img](https://github.com/IlyaGall/C-/blob/main/47%20%D0%91%D1%80%D0%BE%D0%BA%D0%B5%D1%80%D1%8B%20%D1%81%D0%BE%D0%BE%D0%B1%D1%89%D0%B5%D0%BD%D0%B8%D0%B9/img/17.JPG)

### Headers Exchange

![img](https://github.com/IlyaGall/C-/blob/main/47%20%D0%91%D1%80%D0%BE%D0%BA%D0%B5%D1%80%D1%8B%20%D1%81%D0%BE%D0%BE%D0%B1%D1%89%D0%B5%D0%BD%D0%B8%D0%B9/img/18.JPG)

![img](https://github.com/IlyaGall/C-/blob/main/47%20%D0%91%D1%80%D0%BE%D0%BA%D0%B5%D1%80%D1%8B%20%D1%81%D0%BE%D0%BE%D0%B1%D1%89%D0%B5%D0%BD%D0%B8%D0%B9/img/19.JPG)

#### Панель администрирования Rebbit

![img](https://github.com/IlyaGall/C-/blob/main/47%20%D0%91%D1%80%D0%BE%D0%BA%D0%B5%D1%80%D1%8B%20%D1%81%D0%BE%D0%BE%D0%B1%D1%89%D0%B5%D0%BD%D0%B8%D0%B9/img/20.JPG)

### Настройки количества неподтвержденных сообщений в очереди

* PrefetchSize – объем (в байтах) сообщений
* PrefetchCount – количество сообщений
* Global – применяется ли ко всем консьюмерам или только к данному

### Настройки очереди

```c#
/// <summary>
/// Declares o queve. See the <a href=" https://www.robbitmg.com/queves.html ">Queves quide</a> to learn more. 
/// </summary>
/// <param name="queve">The name of the queue. Pass an empty string to make the server generate aname.</param>
/// <param name="duroble">Should this queve will survive a broker restart?</param>
/// <param name="exclusive">Should this queue use be limited to its declaring connection? Such a queve will be deleted when its decloring connection closes.
/// <param name="autoDelete">Should this queue be auto-deleted when its last consumer (if any) unsubscribes?</param> 
/// <param name="arguments">Optianal; additional queue arguments, e.g. "x-queue-type"</param> 
[AmqpMethodDoNotImplement( namespaceName null)]
QueveDeclare0k queueDeclare(string queue, bool durable, bool exclusive,
    bool autoDelete, IDictionary<string, object> arguments);
```

* Durable – должна ли очередь сохраниться после перезапуска брокера
* Exclusive – должна ли очередь удалиться после закрытия коннекта
* Autodelete – должна ли очередь удалиться после отписки от нее консьюмера

### Настройка контейнера с Rabbit

https://hub.docker.com/_/rabbitmq

1. Добавить в docker-compose в блок services:

rabbit:

    image: rabbitmq:3-management
    restart: always
    hostname: rabbitmqhost
    environment:RABBITMQ_DEFAULT_USER:
guest
    RABBITMQ_DEFAULT_PASS:
guest
    volumes: 
    - rabbitmq_data:/var/lib/rabbitmq
    ports: 
    - "5672:5672"
    - "15672:15672"


2. Добавить в docker-compose в блок volumes:

rabbitmq_data: 

3. Добавить в данные подключения в appsettings.json, например:

"RmqSettings":{
"Host":"localhost",
"VHost":"/",
"Login":"guest",
"Password":"guest"
},

4. Считать данные из пункта 3 при инициализации клиентской библиотеки

## Masstransit как удобная надстройка для RabbitMQ

nuget:

* MassTransit
* MassTransit.RabbitMQ

https://masstransit-project.com/getting-started/

Поддерживает RabbitMQ, ActiveMQ, Azure Service Bus и т.д


Что нужно знать чтобы отправить сообщение с помощью RabbitMQ.Client:
- Наименование обменника
- Маршрутный ключ

Что нужно знать чтобы отправить сообщение с помощью Masstransit:
- Имя очереди
- Тип сообщения

### Способы передачи сообщений в Masstransit

Три способа передачи сообщений:

1. Publish – асинхронное, его получает тот, кто подписан на данный тип сообщений
2. Send – асинхронное, его получает только тот, кто подписан на очередь с данным наименованием

### Механизм повторной обработки (Retry) сообщений в Masstransit

```C#
e.UseMessageRetry(r =>
{
    r. Handle<ArgumentNullException>();
    r. Ignore(typeof(InvalidOperationException), typeof(InvalidCastException));
    r.Ignore<ArgumentException>(t => t.ParamName == "orderTotal");
});
```

События, не обработанные повторно, попадают в Fault - очереди

|Policy|Description|
|------|-----------|
| None | No retry (Нет повторной попытки)  |
| Immediate (Немедленный) |  Retry immediately, up to the retry limit (Повторите попытку немедленно, до достижения лимита повторных попыток) |
| Interval | Retry after a fixed delay, up to the retry limit (Повторите попытку после фиксированной задержки, вплоть до лимита повторных попыток) |
| Intervals | Retry after a delay, for each interval specified (Повторите попытку после задержки для каждого указанного интервала) |
| Exponential | Retry after an exponentially increasing delay, up to the retry limit (Повторить попытку после экспоненциально увеличивающейся задержки, вплоть до лимита повторных попыток) |
| Incremental | Retry after a steadily increasing delay, up to the retry limit (Повторите попытку после постоянно увеличивающейся задержки, вплоть до лимита повторных попыток) |

## Kafka

Kafka реализована на логах

![img](https://github.com/IlyaGall/C-/blob/main/47%20%D0%91%D1%80%D0%BE%D0%BA%D0%B5%D1%80%D1%8B%20%D1%81%D0%BE%D0%BE%D0%B1%D1%89%D0%B5%D0%BD%D0%B8%D0%B9/img/21.JPG)

Kafka PULL - модель

Почему выбрана PULL-модель

Механизм подтверждения получения (ask) подразумевает наличие статусов сообщения и их обработку, а это накладные расходы

Недостаток PULL в том что потребитель вынужден постоянно запрашивать сообщения компенсируется наличием периода ожидания сообщения.

![img](https://github.com/IlyaGall/C-/blob/main/47%20%D0%91%D1%80%D0%BE%D0%BA%D0%B5%D1%80%D1%8B%20%D1%81%D0%BE%D0%BE%D0%B1%D1%89%D0%B5%D0%BD%D0%B8%D0%B9/img/22.JPG)

### Инструменты работы с кафкой

1. Command line interface 

* https://docs.confluent.io/kafka/operations-tools/kafka-tools.html
* https://docs.confluent.io/platform/current/installation/configuration/index.html

![img](https://github.com/IlyaGall/C-/blob/main/47%20%D0%91%D1%80%D0%BE%D0%BA%D0%B5%D1%80%D1%8B%20%D1%81%D0%BE%D0%BE%D0%B1%D1%89%D0%B5%D0%BD%D0%B8%D0%B9/img/23.JPG)

2. Клиентские приложения, например

* Offset explorer https://www.kafkatool.com/
* Kafka-ui https://docs.kafka-ui.provectus.io/

3. Клиентская библиотека Confluent-Kafka client
https://github.com/confluentinc/confluent-kafka-dotnet

![img](https://github.com/IlyaGall/C-/blob/main/47%20%D0%91%D1%80%D0%BE%D0%BA%D0%B5%D1%80%D1%8B%20%D1%81%D0%BE%D0%BE%D0%B1%D1%89%D0%B5%D0%BD%D0%B8%D0%B9/img/24.JPG)


### Установка

Ссылка на образ https://hub.docker.com/r/confluentinc/cp-kafka

```C#
zookeeper:
container name: zookeeper
image: confluentinc/cp-zookeeper:7.3.2 ports:
- "2181:2181" environment:
ZOOKEEPER SERVER ID: '1' ZOOKEEPER SERVERS: 'zookeeper:2888:3888' ZOOKEEPER CLIENT PORT: '2181'
ZOOKEEPER PEER PORT: '2888'
zookeeper leader port: "3888"
ZOOKEEPER INIT LIMIT: '10'
ZOOKEEPER SYNC LIMIT: '5'
ZOOKEEPER MAX CLIENT CONNS:
'5'

```

```C#
kafka-broker-1:
image: confluentinc/cp-kafka:7.3.2 container name: kafka-broker-1
depends on:
zookeeper
ports:
"29091:29091"
environment:
KAFKA BROKER ID:
KAFKA BROKER RACK:
KAFKA_zookEEPER_CONNECT: zookeeper: 2181
KAFKA LISTENERS: INSIDE://0.0.0.0:9091,OUTSIDE://0.0.0.0:29091
KAFKA ADVERTISED LISTENERS: INSIDE://kafka-broker-1:9091,OUTSIDE://localhost:29091
KAFKA INTER BROKER LISTENER NAME: INSIDE
KAFKA LISTENER SECURITY PROTOCOL MAP: INSIDE: PLAINTEXT,OUTSIDE: PLAINTEXT
#KAFKA_CREATE_TOPICS: "my-topic:1:1"
KAFKA DEAULT REPLICATION FACTOR: '2" volumes:
kafka broker 1 data:/var/lib/kafka/data
kafka_broker_l_logs:/var/lib/kafka/logs
```
### Данные для подключения

Перечисленные через запятую адреса брокеров
```C#

"kafkaOptions": {
    "BootstrapServers" : "localhost:29091,localhost:29092, localhost:29093"
}
```
### Топик

Топик - именованный контейнер, содержащий похожие сообщения

Содержит сообщения в виде логов, каждый отдельный лог называется партицией

Topic является логическим понятием, физически сообщения располагаются в партициях

Топик заказов, топик отправок, топик уведомлений и т.п.

![img](https://github.com/IlyaGall/C-/blob/main/47%20%D0%91%D1%80%D0%BE%D0%BA%D0%B5%D1%80%D1%8B%20%D1%81%D0%BE%D0%BE%D0%B1%D1%89%D0%B5%D0%BD%D0%B8%D0%B9/img/25.JPG)

### Чтение сообщений из очереди

Как консьюмер понимает, с какого сообщения начать чтение?

![img](https://github.com/IlyaGall/C-/blob/main/47%20%D0%91%D1%80%D0%BE%D0%BA%D0%B5%D1%80%D1%8B%20%D1%81%D0%BE%D0%BE%D0%B1%D1%89%D0%B5%D0%BD%D0%B8%D0%B9/img/26.JPG)

### Offset


Offset показывает, с какой позиции данный Consumer Group должен читать сообщения

![img](https://github.com/IlyaGall/C-/blob/main/47%20%D0%91%D1%80%D0%BE%D0%BA%D0%B5%D1%80%D1%8B%20%D1%81%D0%BE%D0%BE%D0%B1%D1%89%D0%B5%D0%BD%D0%B8%D0%B9/img/27.JPG)

### Consumer group

![img](https://github.com/IlyaGall/C-/blob/main/47%20%D0%91%D1%80%D0%BE%D0%BA%D0%B5%D1%80%D1%8B%20%D1%81%D0%BE%D0%BE%D0%B1%D1%89%D0%B5%D0%BD%D0%B8%D0%B9/img/28.JPG)

### Стратегии партицирования с ключом

1. Round robin

Например, партиции 1 и 2. Каждое приходящее сообщение распределяется по очереди в эти партиции, т.е. 1,2,1,2,1,2…

2. Явное определение партиции

Например, имеется 100 отделов, сообщения нужно распределить по ним. Принимают стратегию если номер отдела <50, отправляют в партицию 1, иначе – в 2

3. Key-defined (key-hash % n) (по умолчанию)– вычисляется хэш ключа партиция вычисляется как key-hash % n. Стратегия подразделяется далее по виду алгоритма хэширования

### Если сообщение не содержит ключа,
1. До 2.4 отправлялось через Round robin
2. Начиная с 2.4 отправляется также Round robin, но батчем - называется «sticky partitioner» (целевая партиция не меняется пока не наполнится батч или не исчерпается время linger.ms)

![img](https://github.com/IlyaGall/C-/blob/main/47%20%D0%91%D1%80%D0%BE%D0%BA%D0%B5%D1%80%D1%8B%20%D1%81%D0%BE%D0%BE%D0%B1%D1%89%D0%B5%D0%BD%D0%B8%D0%B9/img/29.JPG)

Список материалов для изучения:

1. [Об устройстве RMQ](https://www.rabbitmq.com/tutorials/amqp-concepts.html)
2. [О библиотеке RMQ.Client](https://www.rabbitmq.com/dotnet-api-guide.html)
3. [О кафке коротко](https://medium.com/codex/asynchronous-communication-whydoeskafka-use-a-pull-based-message-consumer-442c19a70f58)
4. [Короткое но информативное видео о кафке](https://youtu.be/Ch5VhJzaoaI?si=sNsRj72itoKdnCr_)
5. [Более длинное и сложное, но на русском](https://youtu.be/-AZOi3kP9Js?si=b8wylQ4Rtp4RC-Ro)
6. [Библиотека Kafka.Confluent, примеры реализации. См.ReadMe снизу](https://github.com/confluentinc/confluent-kafka-dotnet)







