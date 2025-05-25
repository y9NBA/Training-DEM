## Ссылка на записи

https://drive.google.com/drive/folders/1p4GtJ0HMel84kgSMbTbZ0ozs9w0_UGuI?usp=sharing

## Nuget для NET <= 4.8

- EntityFramework

## Nuget для NET <= 8.0

- Microsoft.EntityFrameworkCore 8.*
- Microsoft.EntityFrameworkCore.Tools 8.* (для миграций)
- Microsoft.EntityFrameworkCore.SqlServer 8.* (для подключения mssql)

## Команды для миграций (Core)

- add-migration название_миграции (создаёт миграцию по моделям)
- update-database (обновляет бд по миграциям)

## Вариант строки подключения для mssql (Core)

```
"Data Source=.;Initial Catalog=TestDEMNet;Integrated Security=True;TrustServerCertificate=True"
```

- Catalog - название бд в СУБД (бд без таблиц создаём ручками)
- Integrated Security - шифрование (True - шифрование есть)
- TrustServerCertificate - сертификат сервера (True - доверяем сертификату)