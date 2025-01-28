# Взаимодействие потоков

➔ Monitor
➔ CountdownEvent
➔ Barrier
➔ AutoResetEvent
➔ ManualResetEvent
➔ ManualResetEventSlim

## Monitor


## Процессý, потоки, синхронизациā

Процессý, потоки , разделāемýе ресурсý

![img](https://github.com/IlyaGall/C-/blob/main/39%20%D0%92%D0%B7%D0%B0%D0%B8%D0%BC%D0%BE%D0%B4%D0%B5%D0%B9%D1%81%D1%82%D0%B2%D0%B8%D0%B5%20%D0%BF%D0%BE%D1%82%D0%BE%D0%BA%D0%BE%D0%B2/IMG/1.JPG)

```c#

```

### CountdownEvent

![img](https://github.com/IlyaGall/C-/blob/main/39%20%D0%92%D0%B7%D0%B0%D0%B8%D0%BC%D0%BE%D0%B4%D0%B5%D0%B9%D1%81%D1%82%D0%B2%D0%B8%D0%B5%20%D0%BF%D0%BE%D1%82%D0%BE%D0%BA%D0%BE%D0%B2/IMG/2.JPG)

### Barrier

![img](https://github.com/IlyaGall/C-/blob/main/39%20%D0%92%D0%B7%D0%B0%D0%B8%D0%BC%D0%BE%D0%B4%D0%B5%D0%B9%D1%81%D1%82%D0%B2%D0%B8%D0%B5%20%D0%BF%D0%BE%D1%82%D0%BE%D0%BA%D0%BE%D0%B2/IMG/3.JPG)

![img](https://github.com/IlyaGall/C-/blob/main/39%20%D0%92%D0%B7%D0%B0%D0%B8%D0%BC%D0%BE%D0%B4%D0%B5%D0%B9%D1%81%D1%82%D0%B2%D0%B8%D0%B5%20%D0%BF%D0%BE%D1%82%D0%BE%D0%BA%D0%BE%D0%B2/IMG/4.JPG)

```c#

```

### AutoResetEvent

— примитив синхронизации, автоматически блокирующий движение следующих потоков после пропуска одного, находившегося в состоянии ожидания

![img](https://github.com/IlyaGall/C-/blob/main/39%20%D0%92%D0%B7%D0%B0%D0%B8%D0%BC%D0%BE%D0%B4%D0%B5%D0%B9%D1%81%D1%82%D0%B2%D0%B8%D0%B5%20%D0%BF%D0%BE%D1%82%D0%BE%D0%BA%D0%BE%D0%B2/IMG/5.JPG)


### ManualResetEvent

— примитив синхронизации, разрешающий движение всех ожидающих потоков после его “открытия”.  Движение запрещается только после закрытия вручную.

![img](https://github.com/IlyaGall/C-/blob/main/39%20%D0%92%D0%B7%D0%B0%D0%B8%D0%BC%D0%BE%D0%B4%D0%B5%D0%B9%D1%81%D1%82%D0%B2%D0%B8%D0%B5%20%D0%BF%D0%BE%D1%82%D0%BE%D0%BA%D0%BE%D0%B2/IMG/6.JPG)

### ManualResetEventSlim

## Дополнительные инструменты

➔ Interlocked
➔ Volatile

### Interlocked example

![img](https://github.com/IlyaGall/C-/blob/main/39%20%D0%92%D0%B7%D0%B0%D0%B8%D0%BC%D0%BE%D0%B4%D0%B5%D0%B9%D1%81%D1%82%D0%B2%D0%B8%D0%B5%20%D0%BF%D0%BE%D1%82%D0%BE%D0%BA%D0%BE%D0%B2/IMG/7.JPG)

### Volatile example

![img](https://github.com/IlyaGall/C-/blob/main/39%20%D0%92%D0%B7%D0%B0%D0%B8%D0%BC%D0%BE%D0%B4%D0%B5%D0%B9%D1%81%D1%82%D0%B2%D0%B8%D0%B5%20%D0%BF%D0%BE%D1%82%D0%BE%D0%BA%D0%BE%D0%B2/IMG/8.JPG)
