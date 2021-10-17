# LasyDI
Упрощенная версия Zenject с реализацией DI и IoC, для внутренней разработки.

## Оглавление

<details>
<summary>Список глав</summary>

- [Введение](#Введение)
- [Документация](#Документация)
- [Знакомство с LasyDI API](#Знакомство-с-LasyDI-API)
    - [Project Context](#Project-Context)
    - [Scene Context](#Scene-Context)
    - [Installer](#Installer)
    - [Hello World](#Hello-World-Example)
    - [Внедрение зависимостей](#Внедрение-зависимостей)
    - [Связывание](#Связывание)
        - [Bind](#Bind)
        - [Настройка](#Настройка)
            - [Общее](#Общее)
            - [Работа с параметрами](#Работа-с-параметрами)
            - [Работа с абстракцией](#Работа-с-абстракцией)
            - [Работа с Unity](#Работа-с-Unity)
- [Примечание](#Примечание)


</details>

## Введение

LasyDI является упрощенной реализацией Zenject для работы с DI и IoC в среде Unity. Предназначена для быстрого “погружения” в разработку с использованием концепции DI и IoC. 

## Документация

- [LasyDI Общий концепт](https://drive.google.com/file/d/1OdIwK7-O2hIVJSBxtZjyR4al_4AqMZu3/view?usp=sharing) 
- [LasyDI Диаграмма Классов](https://drive.google.com/file/d/1sMltTYFAQrTW0ct4QIYRo5yYQsKM5a7i/view?usp=sharing)

## Установка

__[GitHub Release](https://github.com/blackroomgames/LasyDI/releases)__

* Перейти по ссылке
* Выбрать актуальный релизный билд **LasyDI.vX.X.unitypackage**
* Установить Unity пакет в свой проект
* Использовать LasyDI


# Знакомство с LasyDI API

## Project Context

Project Context представлен в виде префаба с одноименным компонентом в папке Resources `Assets\LasyDI\Resources\ProjectContext.prefab`. 
Основная задача создание длительных связей в проекте. 
Создается автоматически при старте игровой сессии и инициализирует все объекты [Installer](#Installer), что помещены в соответствующие поля.

## Scene Context

Scene Context представлен объектом на сцене с одноименным компонентом. 
Основная задача создание связей в рамках одной сцены. После выгрузки сцены, все связи удаляются. 
Пользователь самостоятельно создает данный объект на сцене. 
При старте сцены автоматически инициализирует все объекты [Installer](#Installer), что помещены в соответствующие поля.

## Installer

Пользователь LasyDI может инициализировать связи используя один из вариантов объекта инициализации:
* MonoInstaller
* ScriptableObjectInstaller
Для этого в реализации абстрактного метода `OnInstall()` необходимо произвести [связывание](#Связывание) объектов в контейнер.

## Hello World Example

```csharp
using LasyDI;
using UnityEngine;

public sealed class HelloWorldInstaller : MonoInstaller
{
    public override void OnInstall()
    {
        // добавляем в контейнер связь на класс Logger
        LasyContainer.Bind<Logger>()                    
                    // указываем, что при создание объекта, будет передана строка “Hello World” 
                    .WithParameters("Hello World!")
                    // указываем, что объект класса Logger будет создан сразу после инициализации (после отработки ProjectContext или SceneContext)     
                    .IsAutoCreated()
                    // указываем, что объект должен существовать в единичном экземпляре                    
                    .AsSingle();                        
    }
}

public sealed class Logger
{
    public Logger(string message)
    {
        Debug.Log(message);
    }
}
```
* Не забываем указать ссылку на Installer в нужное поле объектов ProjectContext или SceneContext


## Внедрение зависимостей

LasyDI реализовано внедрение зависимостей через конструктор или метод помеченный атрибутом `[Inject]`

1 - **.Net класс - конструктор**
```csharp
public class SomeClass
{
    // При таком способе внедрение, поля могут быть readonly
    private readonly ITestLink _testLink;
    private Object1 _object1;

    public SomeClass(ITestLink testLink, Object1 object1)
    {
        _testLink = testLink;
        _object1 = object1;
    }
}
```

2 - **.Net класс - метод с атрибутом `[Inject]`**
```csharp
public class SomeClass
{
    private ITestLink _testLink;
    private Object1 _object1;

    [Inject]
    public void Construct(ITestLink testLink, Object1 object1)
    {
        _testLink = testLink;
        _object1 = object1;
    }
}
```

3 - **MonoBehaviour классы - метод с атрибутом `[Inject]`**
```csharp
public class SomeMonoClass : MonoBehaviour
{
    private ITestLink _testLink;
    private Object1 _object1;

    [Inject]
    public void Construct(ITestLink testLink, Object1 object1)
    {
        _testLink = testLink;
        _object1 = object1;
    }
}
```

# Связывание
LasyDI поддерживает 4 основных типа связывания.
Рекомендуется работать через интерфейсы и абстракции для поддержания принципа DIP.
Нельзя создать зависимость от абстрактного класса или интерфейса.

```csharp
using LasyDI;
using UnityEngine;

public sealed class TestInstaller : MonoInstaller
{
    public override void OnInstall()
    {
        LasyContainer.Bind<AbstractClass>();    //будет ошибка
        LasyContainer.Bind<ISomeInterface>();   //будет ошибка
        LasyContainer.Bind<SomeClass>();        //допустимо
    }
}

public abstract class AbstractClass
{
    //...
}

public interface ISomeInterface
{
    //...
}

public class SomeClass : AbstractClass, ISomeClass
{
    //...
}
```

## Bind

1 - **Связывание через конкретный тип объекта**

```csharp
    LasyContainer.Bind<SomeClass>();
```

2 - **Связывание через абстракцию объекта (интерфейс или абстрактный класс)**

```csharp
    LasyContainer.Bind<ISomeClass, SomeClass>();
    LasyContainer.Bind<AbstractClass, SomeClass>();
```
* Важно! Для объекта реципиента необходимо указывать, конкретный тип объекта реализации абстракции, подробнее в [Работа с абстракцией](#Работа-с-абстракцией).

3 - **Создание пула и связывание через конкретный тип объекта**

```csharp
    using LasyDI;
    using LasyDI.Pool;

    //создание зависимости через пулл
    LasyContainer.BindPool<SomePool, SomeClass>();

    //класс пула объектов типа SomeClass
    public class SomePool : BasePoolObjectDI<SomeClass>
    {
        //...
    }
    //объект который будет извлекать из пула
    public class SomeClass
    {
        //...
    } 
```
* Важно! Объектом пула не может быть абстрактный класс или интерфейс, как указывалось в [Связывание](#Связывание)

## Настройка

### Общее

1 - **Задать в настройках определенную реализацию объекта.**

```csharp
    var someClassImplementation = new SomeClass();

    LasyContainer.Bind<SomeClass>()
                 .WhereInstance(someClassImplementation);
```
Актуально и для наследников.

```csharp
    public class SomeClassChild : SomeClass {}

    var someClassImplementation = new SomeClassChild();

    LasyContainer.Bind<SomeClass>()
                 .WhereInstance(someClassImplementation);
```

2 - **Указать, что создаем объект сразу после связывания в контейнере**

```csharp
    LasyContainer.Bind<SomeClass>()
                 .IsAutoCreated();
```
Объект указанного типа создаться сразу после окончания инициализации [Project Context](#Project-Context) или [Scene Context](#Scene-Context).

3 - **Указать тип связи для зависимости - единичный объект**

```csharp
    LasyContainer.Bind<SomeClass>()
                 .AsSingle();
```
Указываем, что для любого реципиента зависимости будет существовать один объект связанного типа.

4 - **Указать тип связи для зависимости - новый объект (по-умолчанию)**

```csharp
    LasyContainer.Bind<SomeClass>()
                 .AsTransit();
```
Указываем, что для любого реципиента зависимости будет создавать новый объект связанного типа.

### Работа с параметрами

Если связанный тип имеет в конструкторе или методе помеченным атрибутом `[Inject]`,
параметры, что не имеют связь в LasyDI, то необходимо указать параметры через метод `WithParameters<T1...T6>()`

* Важно! Максимально число указанных параметров, не может быть больше 6.

```csharp
    public class SomeClass
    {
        //...
        public SomeClass(int i, string s)
        {
            //...
        }
    }

    LasyContainer.Bind<SomeClass>()
                 .WithParameters("test", 123);
                 //аналогично что и  :
                 //.WithParameters(123, "test");
```

* Важно! Если у параметров уникальные сигнатуры, то порядок не имеет значение. Однако, если сигнатуры совпадают, то порядок указанных параметров важен.

```csharp
    public class SomeClass
    {
        //...
        public SomeClass(int i_1, int i_2, string s)
        {
            Debug.Log($"{i_1} | {i_2} | {s}");
            //case - 1
            // Output : 100 | 200 | test
            //case - 2
            // Output : 200 | 100 | test
        }
    }

    //case - 1
    LasyContainer.Bind<SomeClass>()
                 .WithParameters(100, 200, "test");

    //case - 2
    LasyContainer.Bind<SomeClass>()
                 .WithParameters(200, "test", 100);
```

### Работа с абстракцией

Если в сигнатуре конструктора или метода помеченным атрибутом `[Inject]`, есть абстрактные или интерфейс параметры, 
то необходимо указать тип, который будет реализовывать данную абстракцию или интерфейс. 
Для начала работы с абстракциями нужно воспользоваться методом `WhereAbstraction<I>()` во время настройки связности.

Далее необходимо указать откуда будет браться зависимость:
* `FromImplementation<T1...T6>()` - из конкретной реализации абстракции, которую передаем в качестве параметра.
* `FromContainer<T1...T6>` - из контейнера, с учетом всех связанных зависимостей объекта.

1 - **Пример моно-сигнатурной абстракции**

* Есть класс `SomeClass` у него есть зависимость от интерфейса `ISomeInterface`

```csharp
    public class SomeClass
    {
        //...
        public SomeClass(ISomeInterface interfaceObject){}
    }   
```

* Есть два класса, что реализует интерфейс `ISomeInterface`

```csharp
    public class InterfaceClass_1 : ISomeInterface
    {
        //...
    }

    public class InterfaceClass_2 : ISomeInterface
    {
        //...
    }   
```

* На этапе инициализации связей, необходимо указать для класса `SomeClass` зависимость от конкретного типа, что реализует интерфейс `ISomeInterface`

```csharp
    LasyContainer.Bind<InterfaceClass_1>().AsSingle();
    var interfaceObject2 = new InterfaceClass_2();

    LasyContainer.Bind<SomeClass>()
                    .WhereAbstraction<ISomeInterface>()
                    .FromContainer<InterfaceClass_1>();     //зависимость берется из контейнера
    //или
    LasyContainer.Bind<SomeClass>()
                    .WhereAbstraction<ISomeInterface>()
                    .FromImplementation(interfaceObject2);  //зависимость берется из реализации
```

* Как и в [Работа с параметрами](#Работа-с-параметрами) если в конструкторе класса, имеется более двух одинаковых моно-сигнатур абстракции, 
то важен порядок определения типов реализации абстракции. 

```csharp
    public class SomeClass
    {
        //...
        public SomeClass(ISomeInterface interfaceObject1, ISomeInterface interfaceObject2){}
    }  

    LasyContainer.Bind<SomeClass>()
                    .WhereAbstraction<ISomeInterface>()
                    .FromContainer<InterfaceClass_1, InterfaceClass_2>(); 
    //не тоже самое, что и
    LasyContainer.Bind<SomeClass>()
                    .WhereAbstraction<ISomeInterface>()
                    .FromContainer<InterfaceClass_2, InterfaceClass_1>(); 
```

2 - **Пример мульти-сигнатурной абстракции**

* Есть класс `SomeClass` у него есть зависимость от интерфейса `ISomeInterface` и `IOtherInterface`

```csharp
    public class SomeClass
    {
        //...
        public SomeClass(ISomeInterface someInterfaceObject, IOtherInterface otherInterfaceObject){}
    }  
```

* Есть два класса, что реализует интерфейс `ISomeInterface` и `IOtherInterface`

```csharp
    public class SomeInterfaceClass : ISomeInterface
    {
        //...
    }

    public class OtherInterfaceClass : IOtherInterface
    {
        //...
    }
```

* На этапе инициализации связей, необходимо указать для класса `SomeClass` зависимость от конкретного типа, что реализует интерфейс `ISomeInterface` и `IOtherInterface`

```csharp
    LasyContainer.Bind<SomeInterfaceClass>().AsSingle();
    LasyContainer.Bind<OtherInterfaceClass>().AsSingle();

    LasyContainer.Bind<SomeClass>()
                    //указываем зависимость от первой абстракции
                    .WhereAbstraction<ISomeInterface>()
                    .FromContainer<SomeInterfaceClass>()
                    //указываем зависимость от второй абстракции 
                    .WhereAbstraction<IOtherInterface>()
                    .FromContainer<OtherInterfaceClass>()
```

### Работа с Unity

Все объекты реципиенты среды Unity с связью в LasyDI, должны иметь метод-конструктор помеченным атрибутом `[Inject]` с модификатором доступа - `public`. 
Рекомендуется выбирать название метода максимально схожим в его функциональности, как вариант - `Construct()`


1 - **Указать реализацию для связи из объекта-префаба**

```csharp
    LasyContainer.Bind<SomeClass>()
                .FromPrefab("префаб объекта с компонентом - прямая ссылка");
```

Данный метод настройки связи, задает префаб для создания объекта на сцене и внедрение зависимости в данный объект.

2 - **Указать реализацию для связи из объекта-префаба, через подгрузку из ресурсов**

```csharp
    LasyContainer.Bind<SomeClass>()
                .FromPrefabInResources("путь к перфабу в Resources");
```
Данный метод производит поиск в папке Resources, при условии, что объект был найден, производит настройку связи. 

* Важно! Так как происходит поиск через Resources, то скорость работы зависит от иерархии и наполнения папки Resources. 
  Имеется высокий шанс ошибки связанной с неверным путем к нужному ресурсу.

3 - **Найти объект на сцене и задать реализацию связи**

```csharp
    LasyContainer.Bind<SomeClass>()
                .FromGameObjectOnScene();
```

Производиться поиск объекта на сцене с соответствующим типом. Необходимо использовать только с [Scene Context](#Scene-Context) 
Внедрение зависимости происходит в найденном объекте и во всех последующих копиях, если используется тип связи `AsTransit()`

4 - **Найти объект на сцене и использовать его, как префаб**

```csharp
    LasyContainer.Bind<SomeClass>()
                .FromGameObjectOnSceneLikePrefab();
```

Производиться поиск объекта на сцене с соответствующим типом. Необходимо использовать только с [Scene Context](#Scene-Context) 
Внедрение зависимости происходит только и во всех последующих копиях, кроме найденого объекта.

# Примечание

“Минимум затрат на освоение, максимальная выгода!”

LasyDI служит для быстрого обучения, низкоуровневых разработчиков, которые впоследствии, могут продолжить работу на Zenject, так как основной функционал и подход схож.

LasyDI планируется расширяться и дополняться, через работу над будущими внутренними рабочими проектами.

# Проекты с LasyDI

- [Invaders Remake](https://play.google.com/store/apps/details?id=com.blackroomgame.spaceinvaders) 
- [Cute Zoo: 2048 Merge Game](https://play.google.com/store/apps/details?id=com.blackroomgame.cutezoo2048) 