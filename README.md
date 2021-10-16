# LasyDI
Упрощенная версия Zenject с реализацией DI и IoC.

## Оглавление

<details>
<summary>Список глав</summary>

- [Введение](#введение)
- [Документация](#документация)
- [Знакомство с LasyDI API](#Знакомство-с-LasyDI-API)
    - [Project Context](#Project-Context)
    - [Scene Context](#Scene-Context)
    - [Installer](#Installer)
    - [Hello World](#Hello-World-Example)
    - [Связывание](#Связывание)


</details>

## Введение

LasyDI является упрощенной реализацией Zenject для работы с DI и IoC в среде Unity. Предназначена для быстрого “погружения” в разработку с использованием концепции DI и IoC. 

## Документация

- [LasyDI Общий концепт](https://drive.google.com/file/d/1OdIwK7-O2hIVJSBxtZjyR4al_4AqMZu3/view?usp=sharing) 
- [LasyDI Диаграмма Классов](https://drive.google.com/file/d/1sMltTYFAQrTW0ct4QIYRo5yYQsKM5a7i/view?usp=sharing)

## Установка

__GitHub Release[Releases Page]()__

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


## Связывание

LasyDI реализовано связывание через конструктор или метод помеченный атрибутом `[Inject]`

1 **.Net класс - конструктор**
```csharp
public class SomeClass
{
    // При таком способе связывания, поля могут быть readonly
    private readonly ITestLink _testLink;
    private Object1 _object1;

    public SomeClass(ITestLink testLink, Object1 object1)
    {
        _testLink = testLink;
        _object1 = object1;
    }
}
```

2 **.Net класс - метод с атрибутом `[Inject]`**
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

3 **MonoBehaviour классы - метод с атрибутом `[Inject]`**
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
