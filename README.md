# UserManagmentService

Сервис для сохранения настроек пользователей под проект WellReport

## Путь до файла БД (используется sqlite)

Database\UserManagmentDatabase.db
Сделать папку Database постоянной (persistent), чтобы она не удалялась при билде контейнера

# Миграции
## EF tools
https://docs.microsoft.com/ru-ru/ef/core/cli/dotnet

Установка:
```
dotnet tool install --global dotnet-ef
```
Обновление:
```
dotnet tool update --global dotnet-ef
```

## Создать миграцию
```
dotnet ef migrations add <MigrationName> UserManagment.Data
```
## Откатить миграцию
```
dotnet ef migrations remove --project UserManagment.Data
```
Удаляется последняя созданная миграция.

## Применить миграции
При старте проекта применяются автоматически
```
 dotnet ef database update --project UserManagment.Presentation
```
