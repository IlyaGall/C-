# SOLID. Что это?

## Как расшифровать SOLID
1) Single responsibility — принцип единственной ответственности
2) Open-closed — принцип открытости / закрытости
3) Liskov substitution — принцип подстановки Барбары Лисков
4) Interface segregation — принцип разделения интерфейса
5) Dependency inversion — принцип инверсии зависимостей

## Симптомы плохого кода
1) Он замедляет работу
2) Он плохо читаемый, непонятный
3) Fragility. Изменения в одном месте ломают что-то в куче других мест
4) Rigid. Любое небольшое изменение влечет за собой массу изменений повсюду
5) Невозможность переиспользовать подходящий код, так как он делает ещё много чего неподходящего и приходится писать заново


## Single responsibility


Принцип единственной ответственности

«Каждый программный модуль должен иметь только одну причину для изменения».

```C#
public class UserService
{
    public void Register(string email, string password) 
    {
        if (!ValidateEmail(email))
            throw new ValidationException("Email is not an email");
            var user = new User(email, password);
            SendEmail(new MailMessage(" mysite@nowhere.com ", email) { Subject="HEllo foo" });

        public virtual bool ValidateEmail(string email)
        {
            return email.Contains("@");
        }
        public bool SendEmail(MailMessage message)
        {
            _smtpClient.Send(message);
        }
    }
}
```

## Open/Closed Principle

Принцип открытости / закрытости
«Модули должны быть открыты для расширения, но закрыты для модификаций».


## The Liskov Substitution Principle

Принцип подстановки Барбары Лисков Производные классы должны быть доступны через интерфейс базового класса, при этом пользователю не обязательно знать разницу.

### Принцип подстановки Барбары Лисков
Функции, которые используют ссылки на базовые классы, должны иметь возможность использовать объекты производных классов, не зная об этом.

Предусловия в подклассе не могут быть усилены.  Постусловия в подклассе не могут быть ослаблены.


Это критерий, который описывает правильное использование полиморфизма и, в частности, наследования.

=> у нас правильная иерархия типов

![img](https://github.com/IlyaGall/C-/blob/main/46%20%D0%9F%D1%80%D0%B8%D0%BD%D1%86%D0%B8%D0%BF%D1%8B%20SOLID/Img/1.JPG)

## Interface Segregation Principle (ISP)

Принцип разделения интерфейса 
Клиенты не должны быть вынуждены реализовывать интерфейсы, которые они не используют.

Вместо одного толстого интерфейса предпочтительнее использовать множество небольших интерфейсов, основанных на группах методов, каждый из которых обслуживает один подмодуль.

## Dependency Inversion Principle 

Принцип инверсии зависимостей

Высокоуровневые компоненты не должны зависеть от низкоуровневых компонент. И те, и те должны зависеть от абстракций.
Абстракции не должны зависеть от деталей. Детали должны зависеть от абстракций.

![img](https://github.com/IlyaGall/C-/blob/main/46%20%D0%9F%D1%80%D0%B8%D0%BD%D1%86%D0%B8%D0%BF%D1%8B%20SOLID/Img/2.JPG)


### Вопросы
* Какой принцип гласит: «У класса должна быть только одна причина для изменения»?
    - Принцип единой ответственности (SRP)

* Что означает «открыто для расширения, закрыто для модификации» в контексте принципа открытости/закрытости (OCP)? 
    - Классы должны быть спроектированы так, чтобы можно было добавлять новые функциональные возможности без изменения существующего кода.

*  Какой принцип гласит: «Объекты суперкласса должны быть заменямы объектами его подклассов без ущерба для корректности программы»?
    -  Принцип замены Лискова (LSP).

* Что означает разделение интерфейсов в контексте принципа разделения интерфейсов (ISP)?
    -   Интерфейсы не должны предоставлять ненужные методы реализующим классам.

*   Какой принцип гласит: «Модули высокого уровня не должны зависеть от модулей низкого уровня. Оба должны зависеть от абстракций»?
    - Принцип инверсии зависимостей (DIP).

* Какова роль абстракций в контексте принципа инверсии зависимостей (DIP)?
    - Абстракции должны позволять модулям высокого уровня зависеть от них, а не от конкретных реализаций.

* Что из следующего лучше всего описывает принцип единой ответственности (SRP)?
    - У класса должна быть только одна причина для изменения.

* Как можно реализовать принцип открытости/закрытости (OCP) на практике? 
    -  Обеспечивая возможность добавления новых функций без изменения существующего кода.

*  Какой принцип гласит: «Клиенты не должны зависеть от интерфейсов, которые они не используют»?
    - Принцип разделения интерфейсов (ISP).

* Как можно провести рефакторинг класса, чтобы он соответствовал принципу единой ответственности (SRP)? 
    - Обеспечивая, чтобы у каждого класса была только одна причина для изменения.