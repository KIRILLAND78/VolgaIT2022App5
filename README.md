VolgaIT2022App

Образ в Docker Hub:
https://hub.docker.com/repository/docker/kiri78/volgait2022

Инструкция по развертыванию:
Для функционирования приложения необходима база данных PostgreSQL. Впишите свои строки подключения к бд в config.json.
Приложение работает на порте 80/tcp, при развертке Docker образа необходимо это учитывать.
Развёртка через интерфейс (Docker Desktop):

![image](https://user-images.githubusercontent.com/55920722/161267351-77d2e73b-012e-4c4c-8c57-0497a9061e2d.png)

ИЛИ консоль:
docker run -it --rm -p <Удобный для вас порт>:80 --name <Название> kiri78/volgait2022

Для получения POST и GET запросов к приложениям есть API: /api/event/код_приложения

Пример http get запроса на windows:
curl -i -X "GET" "https://localhost:7179/api/event/YK2vU7"

Весь функционал (или почти весь, если я что-то упустил) соответствует требованию:
https://volga-it.org/wp-content/plugins/wp-olymp/files/7441d474702b269829f4b31fa2891e63.pdf
