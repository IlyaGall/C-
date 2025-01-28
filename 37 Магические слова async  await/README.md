# Магические слова async / await

## Жизненный цикл Task


Что хранит в себе Task
● Метод которýй нужно вýполнитþ internal object m_action;
● Статус public TaskStatus status;
● Резулþтат internal TResult m_result;
● Список исклĀùений internal volatile TaskExceptionHolder m_exceptionsHolder; // в свойствах ContingentProperties


![img](https://github.com/IlyaGall/C-/blob/main/36%20%D0%90%D1%81%D0%B8%D0%BD%D1%85%D1%80%D0%BE%D0%BD%D0%BD%D1%8B%D0%B5%20%D0%BE%D0%BF%D0%B5%D1%80%D0%B0%D1%86%D0%B8%D0%B8/IMG/1.JPG)

## Статусы Task


