# Тестовое задание

Версия Unity: 2022.3.14f1

## Описание
**В средней части экрана размещен инвентарь:**

Инвентарь состоит из 30 слотов по 6 ячеек в ряду

В слоте содержится следующая визуальная информация: иконка предмета, количество предметов в стаке (если один - не отображать количество)
 
**Виды предметов:**
1. патроны 9х18мм (пистолетные) 50 штук - макс стак 50, каждый весит 0.01 кг
2. патроны 5.45х39 (автоматные) 100 штук - макс стак 100, каждый весит 0.03 кг
3. аптечка - 6 штук - макс стак 6, восстанавливает 50 HP, весит 1кг
Одежда: Торс
4. куртка - 1 штука, макс стак 1, +3 к защите торса, весит 1кг
5. бронежилет- 1 штука, макс стак 1, +10 к защите торса, весит 10кг
Одежда: Голова
6. кепка - 1 штука, макс стак 1, +3 к защите головы, весит 0.1 кг
7. шлем - 1 штука, макс стак 1, +10 к защите головы, весит 1 кг

Предметы можно перетаскивать между слотами
При нажатии на предмет открывается окно с информацией о предмете с 2 кнопками:
 
Первая кнопка зависит от типа предмета:

1. Если это патроны, то кнопка “Купить” - заполняет стак патронов
2. Если это аптечка, то кнопка “Лечить” - восстанавливает HP героя и расходует одну аптечку
3. Если это одежда, то кнопка “Экипировать” - итем перемещается в соответствующий слот вверху экрана (описано дальше), если этот слот уже занят одеждой , то итемы взаимозаменяются
 
Вторая кнопка для всех предметов “Удалить” - удаляет предмет из инвентаря

**В верхней части экрана размещены:**
 
○ Две ячейки экипировки - голова и торс, в каждую ячейку помещается итем одежды соответствующего типа при нажатии кнопки “Экипировать” в попап окне.
○ Рядом с каждой ячейкой цифра, обозначающая защиту. По умолчанию 0, при экипировке одежды - соответствующее значение
○ Две шкалы HP: красная - героя и синяя - врага. В каждой по умолчанию 100 очков HP
 
**В нижней части экрана:**
 
○ Две кнопки переключения между пистолетом (DMG = 5) и автоматом (DMG = 9)
○ Между ними кнопка “выстрелить” (если выбран пистолет - тратится 1 патрон 9x18мм , если выбран автомат, то 3 патрона 5.45х39мм)



