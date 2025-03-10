# Деревья и кучи 


## Терминология

Граф – структура, состоящая из набора объектов, имеющих связи

Объекты называются вершинами (узлами) Связи называются ребрами 

![Image alt](https://github.com/IlyaGall/C-/blob/main/15%20%D0%94%D0%B5%D1%80%D0%B5%D0%B2%D1%8C%D1%8F%20%D0%B8%20%D0%BA%D1%83%D1%87%D0%B8/img/1.PNG)


**Дерево** – ориентированный связный ациклический граф
Вершины (узлы) соединяются ветвями (ребрами). Направление от родителя к дочерней вершине обозначается стрелкой Число ребер = (число вершин) – 1
Между любыми парами вершин один и только один путь


![Image alt](https://github.com/IlyaGall/C-/blob/main/15%20%D0%94%D0%B5%D1%80%D0%B5%D0%B2%D1%8C%D1%8F%20%D0%B8%20%D0%BA%D1%83%D1%87%D0%B8/img/2.PNG)

Родительские и дочерние вершины:
**Сестры** – две вершины с общим родителем
**Потомки** – дочерние вершины дочерних вершин
**Предки** – родительские вершины родительских вершин

**Степень вершины** – количество дочерних узлов у вершины
**Степень дерева**– максимальная степень входящих в него вершин
**Бинарное дерево** – дерево степени 2

**Терминальная (листовая) вершина** – вершина без дочерних узлов
**Внутренняя вершина** – вершина, содержащая хотя бы 1 дочерний узел
**Корневая вершина (корень)** – вершина без родителей

**Один единственный узел** – тоже дерево, этот узел и корень, и терминальный.
В любом дереве, где больше 1 вершины, можно выделить поддерево.

**Глубина (уровень) вершины**– количество ветвей от этой вершины до корня. Глубина корня = 0

**Высота вершины** – количество ветвей от нее до листа по самому длинному пути
**Высота дерева** = высота корневой вершины

В упорядоченном дерево расположение дочерних деревьев имеет значение 

На практике деревья обычно упорядочены

**Полное дерево** – дерево, в котором любая вершина не имеет дочерних или их количество равно степени дерева

![Image alt](https://github.com/IlyaGall/C-/blob/main/15%20%D0%94%D0%B5%D1%80%D0%B5%D0%B2%D1%8C%D1%8F%20%D0%B8%20%D0%BA%D1%83%D1%87%D0%B8/img/3.PNG)

**Завершенное дерево** – дерево, в котором заполнены все уровни кроме, возможно, самого нижнего, где вершины сдвинуты влево

**Идеальное бинарное дерево** – дерево, в котором все внутренние вершины имеют по две дочерних и все листья находятся на одном уровне

## Свойства бинарного дерева

Кол-во ветвей B = N – 1, где N – кол-во вершин

В идеальном бинарном дереве:
![Image alt](https://github.com/IlyaGall/C-/blob/main/15%20%D0%94%D0%B5%D1%80%D0%B5%D0%B2%D1%8C%D1%8F%20%D0%B8%20%D0%BA%D1%83%D1%87%D0%B8/img/5.PNG)


![Image alt](https://github.com/IlyaGall/C-/blob/main/15%20%D0%94%D0%B5%D1%80%D0%B5%D0%B2%D1%8C%D1%8F%20%D0%B8%20%D0%BA%D1%83%D1%87%D0%B8/img/4.PNG)

## Сбаллансированное дерево
**Сбаллансированное дерево** – дерево, в котором для каждого узла высоты его подузлов отличаются не более чем на 1

![Image alt](https://github.com/IlyaGall/C-/blob/main/15%20%D0%94%D0%B5%D1%80%D0%B5%D0%B2%D1%8C%D1%8F%20%D0%B8%20%D0%BA%D1%83%D1%87%D0%B8/img/6.PNG)


## Алгоритмическая сложность
Проход от корня до листьев
* для сбаллансированных деревьев за O(log N)
* для несбаллансированных – O(N)
Проход всего дерева – О(N)

![Image alt](https://github.com/IlyaGall/C-/blob/main/15%20%D0%94%D0%B5%D1%80%D0%B5%D0%B2%D1%8C%D1%8F%20%D0%B8%20%D0%BA%D1%83%D1%87%D0%B8/img/7.PNG)

![Image alt](https://github.com/IlyaGall/C-/blob/main/15%20%D0%94%D0%B5%D1%80%D0%B5%D0%B2%D1%8C%D1%8F%20%D0%B8%20%D0%BA%D1%83%D1%87%D0%B8/img/8.PNG)

![Image alt](https://github.com/IlyaGall/C-/blob/main/15%20%D0%94%D0%B5%D1%80%D0%B5%D0%B2%D1%8C%D1%8F%20%D0%B8%20%D0%BA%D1%83%D1%87%D0%B8/img/9.PNG)


## Как можно представить дерево в программе

* Через объекты и ссылки между ними
* Узлы – объекты, ветви - ссылки между объектами
* Через массивы
### Представление узлов с помощью объектов
![Image alt](https://github.com/IlyaGall/C-/blob/main/15%20%D0%94%D0%B5%D1%80%D0%B5%D0%B2%D1%8C%D1%8F%20%D0%B8%20%D0%BA%D1%83%D1%87%D0%B8/img/10.PNG)

### Представление дерева в виде массива

* Через массивы (эффективен только для ~полных деревьев)
1.Корневой узел записывается 0м элементом массива
2.Его дочерние узлы - 1 и 2 элементы массива
3.Далее номера узлов в массиве рассчитываются поформулам
* 2i+1 (левый дочерний)
* 2i+2 (правый дочерний)
где i – номер узлового в массиве

![Image alt](https://github.com/IlyaGall/C-/blob/main/15%20%D0%94%D0%B5%D1%80%D0%B5%D0%B2%D1%8C%D1%8F%20%D0%B8%20%D0%BA%D1%83%D1%87%D0%B8/img/11.PNG)

![Image alt](https://github.com/IlyaGall/C-/blob/main/15%20%D0%94%D0%B5%D1%80%D0%B5%D0%B2%D1%8C%D1%8F%20%D0%B8%20%D0%BA%D1%83%D1%87%D0%B8/img/12.PNG)

## Операции

Операции над произвольными деревьями

1.Обход
«Перемещение» по всем вершинам дерева в определенном порядке, чтобы выполнить с каждой вершиной некоторое действие.

Зачем может понадобиться:
* Перечислить все вершины
* Найти вершину по какому-то критерию
* Найти вершину, к которой добавить новую дочернюю вершину
* И т.д.

## Варианты обхода дерева

![Image alt](https://github.com/IlyaGall/C-/blob/main/15%20%D0%94%D0%B5%D1%80%D0%B5%D0%B2%D1%8C%D1%8F%20%D0%B8%20%D0%BA%D1%83%D1%87%D0%B8/img/13.PNG)

Реализуется через рекурсию O(n) Не требует расходов памяти

![Image alt](https://github.com/IlyaGall/C-/blob/main/15%20%D0%94%D0%B5%D1%80%D0%B5%D0%B2%D1%8C%D1%8F%20%D0%B8%20%D0%BA%D1%83%D1%87%D0%B8/img/14.PNG)

Реализуется через очереди O(n) Требует расходов памяти


* Pre-order: вершина -> левый -> правый
* In-order: левый -> вершина -> правый
* Post-order: левый -> правый -> вершина

![Image alt](https://github.com/IlyaGall/C-/blob/main/15%20%D0%94%D0%B5%D1%80%D0%B5%D0%B2%D1%8C%D1%8F%20%D0%B8%20%D0%BA%D1%83%D1%87%D0%B8/img/15.PNG)

Алгоритмическая сложность одинакова In-order для BST извлекает в отсортированном порядке

# Упорядоченные деревья

**Упорядоченное дерево** - дерево, построение которого выполнено в соответствии с некоторым порядком
Бинарное дерево поиска (Binary Search Tree, BST) – бинарное упорядоченное дерево, в котором содержимое узла больше содержимого левого подузла и не больше содержимого правого подузла

![Image alt](https://github.com/IlyaGall/C-/blob/main/15%20%D0%94%D0%B5%D1%80%D0%B5%D0%B2%D1%8C%D1%8F%20%D0%B8%20%D0%BA%D1%83%D1%87%D0%B8/img/16.PNG)

## Операции над BST
Операции над BST:
1. Совершить обход
2. Добавить элемент
3. Найти элемент
4. Удалить элемент

Добавить элемент
1. Двигаясь от корня поочередно сравниваем элемент с вершинами и добавляем в виде листа

Найти элемент
1. Двигаясь от корня поочередно сравниваем искомый элемент с вершинами доходим таким образом до цели

Удалить вершину
1. Лист удаляется без дополнительных действий
2. Вершина с одним дочерним удаляется, при этом создается ветвь от ее родителя к ее дочернему напрямую
3. Вершина с двумя дочерними меняется местами или с наименьшей дочерней справа или с наибольшей дочерней слева. Далее эта дочерняя удаляется (пункт 1)

Алгоритмическая сложность операций в BST

![Image alt](https://github.com/IlyaGall/C-/blob/main/15%20%D0%94%D0%B5%D1%80%D0%B5%D0%B2%D1%8C%D1%8F%20%D0%B8%20%D0%BA%D1%83%D1%87%D0%B8/img/17.PNG)

## Куча

Куча (англ. Heap) – древовидная структура данных, в которой для любой пары родительского (Р) и дочернего (Д) узла выполняется неравенство:
Значение в Р >= значения в Д

(Значение в Р <= значения в Д)

В первом случае куча называется  максимальной, во втором - минимальной

![Image alt](https://github.com/IlyaGall/C-/blob/main/15%20%D0%94%D0%B5%D1%80%D0%B5%D0%B2%D1%8C%D1%8F%20%D0%B8%20%D0%BA%D1%83%D1%87%D0%B8/img/18.PNG)


## Используемые операции
* Добавление элементов
* Извлечение верхнего элемента

## Добавление нового элемента
![Image alt](https://github.com/IlyaGall/C-/blob/main/15%20%D0%94%D0%B5%D1%80%D0%B5%D0%B2%D1%8C%D1%8F%20%D0%B8%20%D0%BA%D1%83%D1%87%D0%B8/img/19.PNG)

1. Добавить элемент в конец текущего уровня кучи
2. Перестроить кучу поочередно меняя местами элементы в случае необходимости

## Удаление корневого элемента

![Image alt](https://github.com/IlyaGall/C-/blob/main/15%20%D0%94%D0%B5%D1%80%D0%B5%D0%B2%D1%8C%D1%8F%20%D0%B8%20%D0%BA%D1%83%D1%87%D0%B8/img/20.PNG)

1. Поменять местами корневой элемент и последний
2. Удалить последний элемент
3. Перестроить кучу (в случае необходимости) начиная с нового корневого элемента

Алгоритмическая сложность операций

1. Удаление корневого элемента - O(logN)
2. Добавление нового элемента - O(logN)

## Применения кучи
* Очереди с приоритетом
* Пирамидальная сортировка

Реализуется поочередным удалением корневого элемента

![Image alt](https://github.com/IlyaGall/C-/blob/main/15%20%D0%94%D0%B5%D1%80%D0%B5%D0%B2%D1%8C%D1%8F%20%D0%B8%20%D0%BA%D1%83%D1%87%D0%B8/img/21.PNG)

![Image alt](https://github.com/IlyaGall/C-/blob/main/15%20%D0%94%D0%B5%D1%80%D0%B5%D0%B2%D1%8C%D1%8F%20%D0%B8%20%D0%BA%D1%83%D1%87%D0%B8/img/22.PNG)


## Пирамидальная сортировка (Heap Sort)

У вас есть массив или список объектов, которые хочется отсортировать
1) Постройте из них кучу, последовательно добавляя каждый элемент в кучу.
Сложность O(N*logN), т.к. N элементов добавляем в кучу, а одна операция
добавления в кучу – O(logN)
2) Последовательно удалением корней этой кучи постройте новый список. Он
будет уже отсортирован согласно определению Кучи.
Сложность O(N*logN) , т.к. N элементов удаляем из кучи, а одна операция
удаления из кучи – O(logN)
Итоговая сложность: O(N*logN)


## Пирамидальная сортировка (Heap Sort)

Реализация алгоритма для работы с массивом как с кучей:
1. Исключив из перебора узлы последнего уровня, пройти остальные узлы в обратном
порядке с последовательностью действий для каждого:
* а) выбрать узел с максимальным значением из тройки: узел, его левый и его правый дочерние узлы (УМ)
* б) если значение УМ не совпадает со значением текущего узла (ТУ), поменять ТУ и УМ местами
* в) повторить пункты 
* а)б) для ТУ в его новой позиции 