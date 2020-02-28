# 2RealLife

<b>Unity 2019.3.2f1</b>

Инструкция по изменению поведения кота:

Для создания <b>нового настроения</b> нужно создать новый ScriptableObject Mood (Пкм сверху "Mood") и добавить его в поле "Available Moods" на объекте "Cat". После этого в новом SO появятся записи в Dictionary "Consequences", которые надо проинициализировать скриптами, наследниками ActionScript.

Для создания <b>нового действия</b> нужно создать новый скрипт-наследник ActionScript, ScriptableObject Action (Пкм сверху "Action"), куда в поле "Script" задать новосозданный скрипт-наследник ActionScript. После этого добавить этот SO в лист "Available Actions" на объекте "Cat". Во всех SO настроений кота (ScriptableObject Mood), которые есть в листе "Available Moods" в словаре "Consequences" появится новая запись с только что добавленным действием, которые надо проинициализировать скриптами, наследниками ActionScript.

Листы "Available Moods" и "Available Actions" принимают уникальные не Null значения и автоматически добавляют/удаляют записи. О всех непроинициализированных записей словарей можно узнать из логов ошибок в консоли. Записи в словари можно добавить/удалить только через добавление/удаление соответствующих действий в листе "Available Actions".

![Mood](http://258215.selcdn.com/Filestorage/2RealLife.png)
