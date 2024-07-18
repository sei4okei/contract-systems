# contact-systems
Test task for Contract Systems

Сайт доступен по ссылке - http://localhost:8088

Данные для подключения к PostgreSQL:
- DB: Passwords
- User: postgres
- Password: postgres

## Запуск
Для запуска необходимо:

1. Создать снимок приложения (в папке проекта)
```cmd
docker build . -t passwordservice
```
2. Запустить контейнеры
```cmd
docker-compose up
```
3. Всё готово!
