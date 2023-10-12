# ToDoList2.0-GridForms-
+ инструкция для подключения БД

+ 001. Строка подключения.
Вид -> Обозреватель объектов SQL Server (CTRL + \, CTRL + S)

Data Source=EKB1764\SQL2014;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;

002. Установка NuGet-пакета
Проект -> Управление пакетами NuGet...
Microsoft.SqlServer.Server

003. В приложении должно присутствовать:
1) Вариативная строка подключения, вводимая пользователем;
2) Защита от краха программы (механизм обработки исключения);
3) Индикация установленного соединения / возможность его разорвать;
4)* Проверка существования сущности, перед её использованием.

