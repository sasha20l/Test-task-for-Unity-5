# Test-task-for-Unity-5
Тестовое задание что я получил от потенциального работадателя и выполнил.

Необходимо написать генератор раскладки плитками. Плитки укладываются рядами снизу-вверх, слева-направо с заданным швом и смещением.

Программа должна иметь UI, позволяющий задать:
1) величину шва между рядами и плитками в рядах
2) величину смещения рядов друг относительно друга
3) угол поворота всех рядов вокруг центра плоскости

При изменении любого из параметров программа должна немедленно отображать новый результат укладки и расчета.

Результат работы программы:
1) Визуальное отображение раскладки плитки 
2) Отображение суммарной площади видимых частей плиток м2

Размеры плоскости могут быть любыми, но они должны вмещать не менее 4 рядов плиток и не менее 4 плиток в каждом ряду.
Текстуру плитки можно взять любую, например такую https://kerama-marazzi.com/catalog/ceramic_tile/vt_a274_16000/

Важным моментом является тот факт, что плитки не должны "торчать" за пределы стены.

Тратить много времени на верстку UI тоже не следует - на этом этапе мы ее не оцениваем.

При решении задачи будет удобнее задавать плитки с помощью контуров и после всех манипуляций триангулировать их в Mesh.

Вы вправе использовать любые библиотеки, которые потребуются.

Результат принимается в виде ссылки на проект Unity в github с решением задачи.

Основная задача в этом задание посчитать площадь плитки, которая была использована для замощения плоскости, без учета размеров швов и отрезанных треугольников.