# Сериализаøиā. Что ÿто?
## определение

Сериализаøиā

Ƃ ÿто проøесс преобразованиā обüекта в формат, которýй можно легко сохранитþ
или передатþ. Этот формат обýùно āвлāетсā двоиùнýм или текстовýм
представлением, которое сохранāет состоāние и даннýе обüекта. Преобразовав
обüект в serial формат, становитсā возможнýм сохранитþ его в файле, отправитþ по
сети или сохранитþ в базе даннýх.

[img](https://github.com/IlyaGall/C-/blob/main/50%20%D0%A1%D0%B5%D1%80%D0%B8%D0%B0%D0%BB%D0%B8%D0%B7%D0%B0%D1%86%D0%B8%D1%8F/img/1.JPG)

## Назнаùение
Основнаā øелþ сериализаøии Ƃ сохранение состоāниā обüекта на носителе или передаùа его по сети. Это важно длā разлиùнýх приложений, таких как:
1. Сохранение даннýх: сохранение состоāниā обüекта в файле или базе даннýх длā последуĀûего извлеùениā.
2. Свāзþ: отправка обüектов по сети между разлиùнýми системами или компонентами, вклĀùение удаленнýх вýзовов проøедур (RPC) и веб-служб.
3. Резервное копирование и восстановление: создание резервнýх копий обüектов и их восстановление по мере необходимости длā обеспеùениā øелостности и непрерýвности даннýх.

## Десериализаøиā
Десериализаøиā Ƃ ÿто проøесс преобразованиā сериализованнýх даннýх обратно в обüект.

Этот обратнýй проøесс берет сериализованнýй формат и реконструирует исходнýй обüект с его состоāнием и даннýми в øелости и сохранности.

Десериализаøиā имеет реúаĀûее знаùение длā:

● Чтениā сохраненнýх даннýх: загрузки ранее сохраненнýх обüектов из файла или базý даннýх длā восстановлениā их состоāниā.
● Приема даннýх: полуùениā сериализованнýх обüектов по сети и их реконструкøии длā исполþзованиā в приложениāх.
● Обмена даннýми: упроûениā обмена даннýми между разлиùнýми системами путем преобразованиā сериализованнýх даннýх в пригоднýе длā исполþзованиā обüектý.

## Поùему актуалþно
### 1. Сохранение даннýх

 Сохранение и загрузка состоāниā: сериализаøиā позволāет сохранāтþ состоāние обüекта в хранилиûе (например, файл или базу даннýх) и восстанавливатþ его позже, ùто важно длā приложений, которýм необходимо запоминатþ полþзователþские настройки, игровýе состоāниā или другие постоāннýе даннýе.

Резервное копирование и восстановление: помогает создаватþ резервнýе копии состоāний обüектов и восстанавливатþ их по мере необходимости, обеспеùиваā øелостностþ и непрерýвностþ даннýх.

[img](https://github.com/IlyaGall/C-/blob/main/50%20%D0%A1%D0%B5%D1%80%D0%B8%D0%B0%D0%BB%D0%B8%D0%B7%D0%B0%D1%86%D0%B8%D1%8F/img/2.JPG)

### 2. Передаùа даннýх

Сетеваā свāзþ: сериализаøиā исполþзуетсā длā отправки даннýх по сетāм. Например, в вебприложениāх даннýе ùасто сериализуĀтсā в JSON или XML перед отправкой клиенту или серверу.

Веб-сервисý: многие веб-сервисý, такие как RESTful API, исполþзуĀт форматý сериализаøии, такие как JSON и XML, длā свāзи между клиентами и серверами.

[img](https://github.com/IlyaGall/C-/blob/main/50%20%D0%A1%D0%B5%D1%80%D0%B8%D0%B0%D0%BB%D0%B8%D0%B7%D0%B0%D1%86%D0%B8%D1%8F/img/3.JPG)

### 3. Взаимодействие

Кроссплатформеннаā совместимостþ: сериализаøиā позволāет разлиùнýм системам (возможно, написаннýм на разнýх āзýках) обмениватþсā даннýми. Длā ÿтой øели úироко исполþзуĀтсā такие форматý, как JSON, XML и Protocol Buffers.

Микросервисý: в архитектурах микросервисов сервисý ùасто взаимодействуĀт посредством сериализованнýх сообûений, ùто обеспеùивает бесперебойное взаимодействие между сервисами.

[img](https://github.com/IlyaGall/C-/blob/main/50%20%D0%A1%D0%B5%D1%80%D0%B8%D0%B0%D0%BB%D0%B8%D0%B7%D0%B0%D1%86%D0%B8%D1%8F/img/4.JPG)

### 4. Оптимизаøиā производителþности

Эффективностþ: понимание разлиùнýх форматов сериализаøии помогает вýбратþ наиболее ÿффективнýй длā ваúего варианта исполþзованиā. Например, Protocol Buffers намного бýстрее и компактнее по сравнениĀ с JSON и XML.

Управление ресурсами: правилþнаā сериализаøиā может сократитþ обüем передаваемýх или хранимýх даннýх, оптимизируā исполþзование ресурсов.

[img](https://github.com/IlyaGall/C-/blob/main/50%20%D0%A1%D0%B5%D1%80%D0%B8%D0%B0%D0%BB%D0%B8%D0%B7%D0%B0%D1%86%D0%B8%D1%8F/img/5.JPG)

### 5. Безопасностþ

Безопаснаā обработка даннýх: знание недостатков определеннýх форматов сериализаøии (например, уāзвимостей в BinaryFormatter) помогает делатþ безопаснýй вýбор и избегатþ потенøиалþнýх рисков безопасности.

Проверка даннýх: сериализаøиā ùасто вклĀùает проверку форматов даннýх, ùто может бýтþ дополнителþнýм уровнем безопасности от некорректнýх или вредоноснýх даннýх.

[img](https://github.com/IlyaGall/C-/blob/main/50%20%D0%A1%D0%B5%D1%80%D0%B8%D0%B0%D0%BB%D0%B8%D0%B7%D0%B0%D1%86%D0%B8%D1%8F/img/6.JPG)

### 6. Гибкостþ и контролþ

Полþзователþскаā сериализаøиā: реализаøиā полþзователþской сериализаøии позволāет осуûествлāтþ деталþнýй контролþ над тем, как сериализуĀтсā и десериализуĀтсā обüектý, ùто может бýтþ критиùески важнýм длā сложнýх или конфиденøиалþнýх структур даннýх.

Версионирование: Правилþнýе методý сериализаøии могут обрабатýватþ версии, позволāā приложениāм развиватþсā, не наруúаā совместимости со старýми версиāми сериализованнýх даннýх.

[img](https://github.com/IlyaGall/C-/blob/main/50%20%D0%A1%D0%B5%D1%80%D0%B8%D0%B0%D0%BB%D0%B8%D0%B7%D0%B0%D1%86%D0%B8%D1%8F/img/7.JPG)


### 7. Реалþнýе приложениā

Корпоративнýе системý: Многие корпоративнýе системý в знаùителþной степени полагаĀтсā на сериализаøиĀ длā обмена даннýми между разлиùнýми службами и системами. 

Облаùнýе вýùислениā: Облаùнýе приложениā и службý ùасто исполþзуĀт сериализаøиĀ длā ÿффективного хранениā и извлеùениā даннýх.

[img](https://github.com/IlyaGall/C-/blob/main/50%20%D0%A1%D0%B5%D1%80%D0%B8%D0%B0%D0%BB%D0%B8%D0%B7%D0%B0%D1%86%D0%B8%D1%8F/img/8.JPG)

## Serialization Formats 

### Binary Serialization

ПлĀсý:
* Бýстрота: Двоиùнаā сериализаøиā, как правило, бýстрее текстовýх форматов, посколþку она напрāмуĀ преобразует обüектý в двоиùнуĀ форму.
* Эффективное хранение: Двоиùнýе даннýе занимаĀт менþúе места по сравнениĀ с текстовýми форматами, ùто делает их более ÿффективнýми длā хранениā.

Минусý:
* Зависимостþ от платформý: Двоиùнаā сериализаøиā ùасто зависит от платформý, то естþ даннýе, сериализованнýе на одной платформе, могут не поддаватþсā десериализаøии на другой.
* Неудобоùитаемостþ длā ùеловека: Двоиùнýе даннýе нелегко ùитаĀтсā ùеловеком, ùто затруднāет отладку и руùное редактирование.
* Риски безопасности: Двоиùнаā сериализаøиā может бýтþ подвержена уāзвимостāм безопасности, особенно если даннýе поступаĀт из ненадежнýх истоùников.

```C#
public class BinarySerializationExample
{
    public static void Main()
    {
        Person person = new Person { Name = "Alice", Age = 30 };
        BinaryFormatter formatter = new BinaryFormatter();
        using (Filestream stream = new Filestream("person.bin", FileMode.Create))
        {
             formatter.Serialize(stream, person);
        }
        using (FileStream stream = new FileStream("person.bin", FileMode.Open))
        {
           Person deserializedPerson = (Person)formatter. Deserialize(stream);
           Console.WriteLine($"{deserializedPerson.Name}, {deserializedPerson.Age}");
        }
    }
}
```

```C#
[Serializable]
public class Person
{
    public string Name { get; set; } public int Age { get; set; }
}
```

Уāзвимости:
* Удаленное вýполнение кода (RCE): BinaryFormatter может бýтþ исполþзован длā удаленного  вýполнениā кода, если ненадежнýе даннýе десериализуĀтсā. Злонамереннýе субüектý могут создатþ сериализованнуĀ полезнуĀ нагрузку, котораā при десериализаøии вýполнāет произволþнýй код в øелевой системе. Это особенно опасно в сøенариāх, где сериализованнýе даннýе полуùенý из ненадежнýх истоùников по сети.

* Небезопаснаā десериализаøиā: Десериализаøиā даннýх без надлежаûей проверки или безопасности может привести к разлиùнýм проблемам безопасности, вклĀùаā подделку даннýх, утеùку даннýх и повýúение привилегий. Злоумýúленники могут манипулироватþ сериализованнýми даннýми, ùтобý внедритþ вредоноснýй контент или изменитþ состоāние десериализованного обüекта.


Рекомендаøии:

* Избегайте исполþзованиā BinaryFormatter: уùитýваā присуûие ему риски безопасности, рекомендуетсā избегатþ исполþзованиā BinaryFormatter в новýх приложениāх. Microsoft обüāвила BinaryFormatter устаревúим и исклĀùила из .NET 8.0, рекомендует исполþзоватþ более безопаснýе алþтернативý.

* Исполþзование алþтернатив: рассмотрите возможностþ исполþзованиā современнýх и безопаснýх библиотек сериализаøии, таких как System.Text.Json, Newtonsoft.Json или Protocol Buffers (protobuf). Эти библиотеки обеспеùиваĀт луùúуĀ безопасностþ и производителþностþ.

* Проверка даннýх: если необходима десериализаøиā, убедитесþ, ùто даннýе проверенý и оùиûенý перед десериализаøией. Реализуйте проверки безопасности и исполþзуйте безопаснýе методý кодированиā длā снижениā рисков.

### XML Serialization
ПлĀсý:

* Человекоùитаемýй: XML основан на тексте и понāтен ùеловеку, ùто упроûает отладку и редактирование вруùнуĀ.
* Независимостþ от платформý: XML Ƃ ÿто стандартнýй формат, которýй можно исполþзоватþ на разнýх платформах и āзýках программированиā.
* Широкое исполþзование: XML úироко применāетсā во многих отраслāх длā обмена даннýми.

Минусý:
* Многословнýй: XML, как правило, более многословен, ùем другие форматý, ùто приводит к увелиùениĀ размера файлов.
* Медленнее: синтаксиùеский анализ и сериализаøиā XML обýùно медленнее по сравнениĀ с двоиùнýми форматами.

```C#
public class XMLSerializationExample
{
    public static void Main()
    {
        Person person = new Person { Name = "Alice", Age = 30 };
        XmlSerializer serializer = new XmlSerializer(typeof(Person));

        using (Streamwriter writer = new Streamwriter("person.xml"))
        {
            serializer.Serialize(writer, person);
        }
        using (StreamReader reader = new StreamReader("person.xml"))
        {
           Person deserializedPerson = (Person)serializer.Deserialize(reader);
           Console.WriteLine($"{deserializedPerson.Name}, {deserializedPerson.Age}");
        }

    }
}
```

```C#
[Serializable]
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}
```

### JSON Serialization
ПлĀсý:
* Человекоùитаемýй: JSON основан на тексте и удобен длā ùтениā ùеловеком, ùто упроûает понимание и отладку.
* Независимостþ от платформý: JSON Ƃ úироко распространеннýй стандарт, совместимýй со многими платформами и āзýками программированиā.
* Широкое исполþзование: JSON āвлāетсā фактиùеским стандартом обмена даннýми в вебсервисах и API.
Минусý:
* Менее ÿффективнýй: JSON менее ÿффективен с тоùки зрениā размера и скорости по сравнениĀ с двоиùнýми форматами.

```C#
public class JSONSerializationExample
{
public static void Main()
{
    Person person = new Person { Name = "Alice", Age = 30 }; 
    string jsonString = JsonSerializer.Serialize(person);
    Console.WriteLine(jsonString);

    Person deserializedPerson = JsonSerializer. Deserialize<Person>(jsonString); 
    Console.WriteLine($"{deserializedPerson.Name}, {deserializedPerson.Age}");
}
}
```

```C#
[Serializable]
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}
```

### SOAP Serialization
ПлĀсý:
* Расúирāемостþ: SOAP обладает вýсокой расúирāемостþĀ и поддерживает сложнýе типý даннýх и úаблонý свāзи.
* Стандартизирован длā веб-сервисов: SOAP Ƃ ÿто стандартизированнýй протокол, úироко исполþзуемýй в веб-сервисах корпоративного уровнā.
Минусý:
* Многословностþ: сообûениā SOAP оùенþ многословнý, ùто приводит к увелиùениĀ размера сообûений.
* Медленнее: анализ и обработка сообûений SOAP могут бýтþ медленнее по сравнениĀ с другими форматами.
* Менее популāрен сегоднā: с ростом популāрности служб RESTful и JSON SOAP стал менее популāрнýм.

```C#
public class SOAPSerializationExample
{
    public static void Main()
    {
        Person person = new Person { Name = "Alice", Age = 30 }; 
        SoapFormatter formatter = new SoapFormatter();

        using (FileStream stream = new FileStream("person.soap", FileMode.Create))
        {
            formatter.Serialize(stream, person);
        }
        using (FileStream stream = new FileStream("person.soap", FileMode.Open))
        {
            Person deserializedPerson = (Person)formatter. Deserialize(stream);
            Console. WriteLine($"{deserializedPerson.Name}, {deserializedPerson.Age}");
        }
    }
}
```

```C#
[Serializable]
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}
```
### Custom Serialization
ПлĀсý:
* Полнýй контролþ: Полþзователþскаā сериализаøиā обеспеùивает полнýй контролþ над тем, как сериализуĀтсā и десериализуĀтсā обüектý.
* Гибкостþ: Вý можете оптимизироватþ сериализаøиĀ длā конкретнýх слуùаев исполþзованиā и требований.
Минусý:
* Требуемýе усилиā: Реализаøиā полþзователþской сериализаøии требует болþúе усилий и
* пониманиā проøесса сериализаøии.

#### Поùему актуалþно
Гибкостþ и контролþ

Полþзователþскаā сериализаøиā: реализаøиā полþзователþской сериализаøии позволāет осуûествлāтþ деталþнýй контролþ над тем, как сериализуĀтсā и десериализуĀтсā обüектý, ùто может бýтþ критиùески важнýм длā сложнýх или конфиденøиалþнýх структур даннýх.

Версионирование: Правилþнýе методý сериализаøии могут обрабатýватþ версии, позволāā приложениāм развиватþсā, не наруúаā совместимости со старýми версиāми сериализованнýх даннýх.

[img](https://github.com/IlyaGall/C-/blob/main/50%20%D0%A1%D0%B5%D1%80%D0%B8%D0%B0%D0%BB%D0%B8%D0%B7%D0%B0%D1%86%D0%B8%D1%8F/img/9.JPG)



```C#
public class CustomSerializationExample
{
    public static void Main()
    {
        Person person = new Person { Name = "Alice", Age = 30 };

        IFormatter formatter = new BinaryFormatter();
        using (FileStream stream = new FileStream("person.custom", FileMode.Create))
        {
          formatter.Serialize(stream, person);
        }
        using (FileStream stream = new FileStream("person.custom", FileMode.Open))
        {
            Person deserializedPerson = (Person)formatter. Deserialize(stream);
            Console.WriteLine($"{deserializedPerson.Name}, {deserializedPerson.Age}");
        }
    }
  
}
```

```C#
[Serializable]
public class Person : ISerializable
{
    public string Name { get; set; }
    public int Age { get; set; }
    
    public Person() { }

    protected Person(SerializationInfo info, StreamingContext context)
    {
        Name = info.GetString("Name");
        Age = info.GetInt32("Age");
    }
    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.Addvalue("Name", Name);
        info.Addvalue("Age", Age);
    }
}

```

## Serializable атрибут

* [Serializable]: помеùает класс как сериализуемýй, позволāā сериализоватþ и десериализоватþ ÿкземплāрý класса.
* [DataContract] , [DataMember]: исполþзуĀтсā длā определениā контрактов даннýх в службах WCF (Windows Communication Foundation) длā сериализаøии и десериализаøии даннýх
* [JsonProperty] (Newtonsoft.Json or System.Text.Json.Serialization): позволāет указýватþ имена свойств JSON во времā сериализаøии и десериализаøии обüектов.

### Поùему некоторýе форматý требуĀт атрибута Serializable

* Двоиùнаā сериализаøиā (например, с исполþзованием BinaryFormatter) требует атрибута Serializable. Это свāзано с тем, ùто среде вýполнениā .NET требуетсā āвное разреúение на сериализаøиĀ внутреннего состоāниā обüектов, вклĀùаā закрýтýе полā. Без атрибута Serializable среда вýполнениā не может гарантироватþ безопасностþ и øелостностþ сериализованнýх даннýх, ùто может привести к непредсказуемому поведениĀ или уāзвимостāм безопасности.
Полþзователþскаā сериализаøиā:

* Полþзователþскаā сериализаøиā (например, реализаøиā ISerializable) также требует атрибута Serializable. Это позволāет разработùикам контролироватþ проøесс сериализаøии, настраиваā способ записи и ùтениā даннýх обüекта.
DataContractSerializer:

* DataContractSerializer, которýй ùасто исполþзуетсā длā сериализаøии XML и JSON более контролируемýм и гибким образом, требует атрибутов Serializable или DataContract, ùтобý пометитþ типý длā сериализаøии. Это помогает указатþ, какие ÿлементý сериализуĀтсā, и обеспеùивает поддержку управлениā версиāми.

* XmlSerializer не требует атрибута Serializable, посколþку он исполþзует обûедоступнýе свойства и полā длā сериализаøии. Ему не нужен доступ к закрýтýм ùленам, и он полагаетсā на более простой подход на основе отражениā. Это обеспеùивает болþúуĀ гибкостþ, но ознаùает, ùто закрýтýе даннýе не сериализуĀтсā по умолùаниĀ, и разработùикам необходимо āвно контролироватþ, ùто сериализуетсā ùерез открýтýе ùленý.

* JsonSerializer (System.Text.Json и Newtonsoft.Json):

* Сериализаторам JSON обýùно не требуетсā атрибут Serializable. Они полагаĀтсā на обûедоступнýе свойства и полā длā сериализаøии, подобно XmlSerializer. Эти сериализаторý исполþзуĀт отражение длā обнаружениā структурý обüектов и сериализаøии обûедоступнýх ùленов, ùто упроûает работу с классами POCO (Plain Old CLR Objects) без дополнителþнýх атрибутов.

## Проверки во времā вýполнениā и во времā

компилāøии Применение атрибута Serializable происходит во времā вýполнениā, а не во времā компилāøии.

Поùему?

● Гибкостþ
● Динамиùеское поведение
● Обратнаā совместимостþ
● Обработка оúибок

```C#
[Serializable]
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    [NonSerialized]
    private int secretCode; // This field will not be serialized
}

public Person(string name, int age, int secretCode)
{
    Name = name;
    Age = age;
    this.secretCode = secretCode;
}
```

## Интерфейсý
### ISerializable Interface
Назнаùение:

Интерфейс ISerializable позволāет обüекту управлāтþ собственнýми проøессами сериализаøии и десериализаøии. Это особенно полезно, когда вам нужно настраиваемое поведение во времā сериализаøии, например, управление закрýтýми полāми или управление версиāми.

Реализаøиā:

Чтобý реализоватþ интерфейс ISerializable, класс должен определитþ метод GetObjectData. Кроме того, класс должен предоставитþ спеøиалþнýй конструктор, которýй принимает параметрý SerializationInfo и StreamingContext длā десериализаøии.

```C#
// Special constructor for deserialization 
protected Person(SerializationInfo info, StreamingContext context)
{
    Name = info.GetString("Name");
    Age = info.GetInt32("Age");
    SecretCode = info.GetInt32("SecretCode");
}
// Method to control serialization
public void Get0bjectData(SerializationInfo info, StreamingContext context)
{
    info.AddValue("Name", Name);
    info.AddValue("Age", Age);
    info.AddValue("SecretCode", SecretCode);
}
```

### IFormatter Interface
Назнаùение:

Интерфейс IFormatter предоставлāет функøионалþнýе возможности длā форматированиā сериализованнýх обüектов. Он определāет методý сериализаøии и десериализаøии обüектов, предоставлāā разработùикам контролþ над форматом сериализаøии.

Реализаøиā:

● Serialize(Stream, Object): сериализует обüект и записýвает его в предоставленнýй поток.
● Deserialize(Stream): десериализует даннýе из предоставленного потока и восстанавливает исходнýй обüект.

## IFormatter Interface

```C#
public class SimpleFormatter : IFormatter
{
public SerializationBinder Binder { get; set; }
public StreamingContext kg2XWEHoEhQ { get; set; }
public ISurrogateSelector SurrogateSelector { get; set; }
public SimpleFormatter()
{
    kg2XWEHoEhQ = new StreamingContext(StreamingContextStates.All);
}
}
```

```C#
[Serializable]
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
    public override string Tostring()
    {
      return $"Name: {Name}, Age: {Age}";
    }
}
```

```C#
public void Serialize(Stream stream, object obj)
{
    using (StreamWriter writer = new StreamWriter(stream))
    {
    if (obj is Person person)
        {
            writer.WriteLine(person.Name);
            writer.WriteLine(person.Age);
        }
    }
}
public object Deserialize(Stream stream)
{
    using (StreamReader reader = new StreamReader(stream))
    {
      string name = reader.ReadLine();
      int age = int.Parse(reader.ReadLine());
      return new Person(name, age);
    }

}
```



```C#
public class CustomFormatterExample
{
    public static void Main()
    {
        Person person = new Person("Alice", 30);
        // Serialize the object   using custom formatter 
        IFormatter formatter = new SimpleFormatter();
        using (FileStream stream = new FileStream("person.txt", FileMode.Create))
        {
            formatter.Serialize(stream, person);
        }
        // Deserialize the object using custom formatter 
        using (FileStream stream = new FileStream("person.txt", FileMode.Open))
        {
             Person deserializedPerson = (Person)formatter.Deserialize(stream); 
             Console.WriteLine(deserializedPerson);
        }
    }
}
```

### Итоги
Интерфейс ISerializable

* Целþ: позволāет обüекту управлāтþ собственной сериализаøией и десериализаøией.
* Реализаøиā: требует метод GetObjectData и спеøиалþнýй конструктор длā десериализаøии.
* Вариант исполþзованиā: когда вам нужно настроитþ способ сериализаøии обüекта, например, вклĀùитþ закрýтýе полā или управлāтþ сложной логикой сериализаøии.

Интерфейс IFormatter

* Целþ: предоставлāет функøионалþностþ длā форматированиā сериализованнýх обüектов. 
* Методý: Serialize(Stream, Object) и Deserialize(Stream).
* Вариант исполþзованиā: когда вам нужно определитþ полþзователþский формат сериализаøии, например, фирменнýй двоиùнýй формат или упроûеннýй текстовýй формат.

## Стандартнýе средства

### BinaryFormatter (Deprecated)

BinaryFormatter исполþзуетсā длā двоиùной сериализаøии, преобразуā обüектý в двоиùнýй формат. Он сериализует все ÿлементý, вклĀùаā закрýтýе полā, обеспеùиваā полное и компактное представление обüектов. Удален по приùине уāзвимостей

### XmlSerializer
XmlSerializer исполþзуетсā длā сериализаøии XML, преобразуā обüектý в формат XML. Он сериализует обûедоступнýе свойства и полā, ùто делает его пригоднýм длā совместимого обмена даннýми.


### DataContractSerializer
DataContractSerializer исполþзуетсā длā сериализаøии XML и JSON. Он предоставлāет возможностþ сериализаøии и десериализаøии обüектов на основе контракта, ùто делает его пригоднýм длā сервис-ориентированнýх приложений.

```C#
[DataContract]
public class Person
{
    [DataMember]
    public string Name { get; set; }
    [DataMember]
    public int Age { get; set; }
}
```

```C#
public class DataContractSerializerExample
{
    public static void Main()
    {
        Person person = new Person { Name = "Alice", Age = 30 };
        DataContractSerializer serializer = new DataContractSerializer(typeof(Person));
        // Serialize the object to XML
        using (FileStream stream = new FileStream("person.xml", FileMode.Create))
        {
            serializer.WriteObject(stream, person);
        }
        // Deserialize the object from XML 
        using (FileStream stream = new FileStream("person.xml", FileMode.Open))
        {
            Person deserializedPerson = (Person)serializer.ReadObject(stream);
            Console.WriteLine($"{deserializedPerson.Name}, {deserializedPerson.Age}");
        }
    }

}
```

### JsonSerializer (System.Text.Json)
System.Text.Json.JsonSerializer Ƃ ÿто современнаā и ÿффективнаā библиотека длā сериализаøии JSON. Он вклĀùен в .NET Core 3.0 и более поздних версий и обеспеùивает вýсокуĀ производителþностþ и безопасностþ.

### Newtonsoft.Json

```C#
public class NewtonsoftJsonExample
{
    public static void Main()
    {
        Person person = new Person { Name = "Alice", Age = 30 };
        // Serialize the object to JSON 
        string jsonString = JsonConvert. Serialize0bject(person); Console.WriteLine(jsonString);
    
    
        // Deserialize the object from JSON
        Person deserializedPerson = JsonConvert.DeserializeObject<Person>(jsonString);
        Console.WriteLine($"{deserializedPerson.Name}, {deserializedPerson.Age}");
    }
}
```
### System.Text.Json vs Newtonsoft.Json

System.Text.Json
● Представлено в .NET Core 3.0.
● Встроеннаā библиотека в .NET Core и более поздних версиāх.
● Разработан, ùтобý бýтþ легким и производителþнýм.

 Newtonsoft.Json
● Стороннāā библиотека, также известнаā как Json.NET.
● Оùенþ популāрен и úироко исполþзуетсā в сообûестве .NET.
● Предоставлāет богатýй набор функøий и возможностей настройки.

#### Производителþностþ

System.Text.Json

● Как правило, бýстрее с тоùки зрениā сериализаøии и десериализаøии благодарā облегùенной конструкøии.
● Оптимизирован длā вýсокой производителþности, особенно в сøенариāх, где требуетсā минималþнаā настройка.
● Сравнителþнýе тестý ùасто показýваĀт, ùто System.Text.Json работает бýстрее в простýх слуùаāх исполþзованиā.

Newtonsoft.Json

● Немного медленнее, ùем System.Text.Json, особенно в простýх сøенариāх.
● Разниøа в производителþности может бýтþ незнаùителþной длā сложнýх задаù сериализаøии и десериализаøии, в которýх исполþзуĀтсā расúиреннýе функøии.

#### Возможности

System.Text.Json 

● Ограниùеннýй набор функøий по сравнениĀ с Newtonsoft.Json.
● Базовýе возможности сериализаøии и десериализаøии.
● Поддерживает полþзователþские конвертерý, но с менее интуитивно понāтнýм API.
● Отсутствие поддержки некоторýх сложнýх сøенариев, таких как полиморфнаā десериализаøиā, аннотаøии даннýх и более сложнаā настройка.

Newtonsoft.Json

● Богатýй набор функøий, вклĀùаā расúиреннýе параметрý сериализаøии и десериализаøии.
● Поддерживает полþзователþские преобразователи, преобразователи контрактов и расúиреннуĀ настройку.
● Предоставлāет такие функøии, как проверка схемý JSON, LINQ to JSON и надежнаā обработка оúибок.
● Расúиреннаā поддержка атрибутов длā управлениā поведением сериализаøии (например, JsonProperty, JsonIgnore).


## ProtoBuf

Что такое Proto (буферý протоколов)?

Protocol Buffers (Proto) Ƃ ÿто не зависāûий от āзýка и платформý, расúирāемýй механизм длā сериализаøии структурированнýх даннýх.

Разработаннýй Google, Proto исполþзуетсā длā определениā структур даннýх и их ÿффективной сериализаøии.

Основнýе характеристики:

* Компактностþ: буферý протоколов генерируĀт менþúие двоиùнýе представлениā по сравнениĀ с JSON или XML.
* Скоростþ: сериализаøиā и десериализаøиā вýполнāĀтсā бýстрее благодарā компактному двоиùному формату.
* Поддержка āзýков: поддерживает несколþко āзýков программированиā, вклĀùаā C#, Java, Python и другие.

```C#
syntax = "proto3";
message Person {
string name = 1;
int32 age = 2;
string email = 3;
}
```

```C#
syntax = "proto3";
service PersonService {
rpc GetPerson(PersonRequest) returns (PersonResponse);
}
message PersonRequest {
int32 id = 1;
}
message PersonResponse {
string name = 1;
int32 age = 2;
string email = 3;
}
```


```C#
public class Person : IMessage Person>
{
    // Generated code for serialization and deserialization
    // based on the .proto file definitions
    // Properties
    public string Name { get; set; }
    public int Age { get; set; }
    // Serialization and deserialization methods
    public void WriteTo(CodedOutputStream output)
    {
        output.WriteString(Name);
        output.WriteInt32(Age);
    }
   
    public int CalculateSize()
    {
        // Calculate size based on fields
        return CodedOutputStream.ComputeStringSize(Name) + CodedOutputStream.ComputeInt325
    }
    
    public void MergeFrom(CodedInputStream input)
    {
        // Deserialize fields
        Name = input.ReadString();
        Age = input.ReadInt32();
    }
    // Additional required methods omitted for brevity
}
```

```C#
public class ProtobufExample
{
    public static void Main()
    {
         Person person = new Person { Name = "Alice", Age = 30 };
        // Serialize the object
        using (FileStream stream = new FileStream("person.bin", FileMode.Create))
        {
             person.WriteTo(CodedOutputStream.CreateInstance(stream));
        }
        // Deserialize the object
        Person deserializedPerson = new Person();

        using (FileStream stream = new FileStream("person.bin", FileMode.Open))
        {
            deserializedPerson.MergeFrom(CodedInputStream.CreateInstance(stream));
        }
        Console. WriteLine($"{deserializedPerson. Name}, {deserializedPerson.Age}");
    }
 
}
```

### Поùему безопасен?
У BinaryFormatter естþ серþезнýе проблемý с безопасностþĀ из-за вклĀùениā информаøии о типе в сериализованнýе даннýе, способности реконструироватþ сложнýе графý обüектов и возможности удаленного вýполнениā кода посредством обратнýх вýзовов десериализаøии.

Protobuf снижает ÿти риски, исполþзуā предопределеннуĀ схему, избегаā информаøии о типах во времā вýполнениā, обеспеùиваā безопасностþ типов и ограниùиваā сложностþ десериализованнýх обüектов. Такаā конструкøиā делает Protobuf более безопаснýм вýбором длā двоиùной сериализаøии, особенно в сøенариāх, вклĀùаĀûих ненадежнýе даннýе.

### Список материалов длā изуùениā
1. https://learn.microsoft.com/ru-ru/dotnet/standard/serialization/
2. https://learn.microsoft.com/ru-ru/dotnet/standard/serialization/controlling-xml-serialization-using-attributes
3. https://www.newtonsoft.com/json/help/html/SerializingJSON.htm
4. https://protobuf.dev/getting-started/csharptutorial/


https://github.com/lents/Otus.Serialization

https://github.com/lents/CustomSerializer








