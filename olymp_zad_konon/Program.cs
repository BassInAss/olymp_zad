using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

//Задание:

//«Соревнование на картингах».
//После очередного этапа чемпионата мира по кольцевым автогонкам на автомобилях с
//открытыми колесами Формула-А гонщики собрались вместе в кафе, чтобы обсудить
//полученные результаты. Они вспомнили, что в молодости соревновались не на больших
//болидах, а на картах — спортивных автомобилях меньших размеров.
//Друзья решили выяснить победителя в одной из гонок на картах. Победителем гонки
//являлся тот гонщик, у которого суммарное время прохождения всех кругов трассы было
//минимальным.

//Поскольку окончательные результаты не сохранились, то каждый из n участников той
//гонки вспомнил и выписал результаты прохождения каждого из m кругов трассы. К
//сожалению, по этой информации гонщикам было сложно вычислить победителя той
//гонки. В связи с этим они попросили сделать это вас.
//Требуется написать программу, которая вычислит победителя гонки на картах, о
//которой говорили гонщики.
//Формат ввода: Первая строка входного файла содержит два натуральных числа n и m
//(ков. Описание прохождения трассы участником состоит из двух строк. Первая строка
//содержитn, m 6100). Последующие 2 · n строк описывают прохождение трассы каждым из
//участниимя участника с использованием только латинских букв (строчных и заглавных).
//Имена всех участников различны, строчные и заглавные буквы в именах различаются.
//Вторая строка содержит m положительных целых чисел, где каждое число — это время
//прохождения данным участником каждого из m кругов трассы (каждое из этих чисел не
//превосходит 1000). Длина имени каждого участника не превышает 255 символов.
//Формат вывода: В выходной файл необходимо вывести имя победителя гонки на картах.
//Если победителей несколько, требуется вывести имя любого из них.

namespace olymp_zad_konon
{
    class Program
    {
        static void Main(string[] args)
        {
            //Запись участников мероприятия в файл
            StreamWriter sw = new StreamWriter("input.txt");
            sw.WriteLine("5 4");
            sw.WriteLine("Sumaher"); sw.WriteLine("2 1 1");
            sw.WriteLine("Barikelo"); sw.WriteLine("2 1 2");
            sw.WriteLine("Olonso"); sw.WriteLine("1 2 1");
            sw.WriteLine("Vasya"); sw.WriteLine("1 1 1");
            sw.WriteLine("Fedya"); sw.WriteLine("1 1 1");
            sw.Close();

            //Определение кол-ва участников и кругов
            StreamReader sr = new StreamReader("input.txt");
            string [] firt_line = sr.ReadLine().Split(' ');
            int n = int.Parse(firt_line[0]);
            int m = int.Parse(firt_line[1]);

            //Добавление участников в List
            List<string> members = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string member = $"{sr.ReadLine()} {sr.ReadLine()}";
                members.Add(member);
            }
            sr.Close();

            //Определение начальной суммы
            string[] mas_first_sum = members[0].Split(' ');
            int first_sum = int.Parse(mas_first_sum[1]) + int.Parse(mas_first_sum[2]) + int.Parse(mas_first_sum[3]);

            //Поиск участника с наименьшей суммой
            int temp_sum = 0; int sum_end = first_sum;
            string winner_name = null;
            foreach (var item in members)
            {
                string [] one_member = item.Split(' ');
                temp_sum = int.Parse(one_member[1]) + int.Parse(one_member[2]) + int.Parse(one_member[3]);
                if (temp_sum < sum_end)
                {
                    sum_end = temp_sum;
                    winner_name = one_member[0];
                }
            }
            //Запись результата в файл
            StreamWriter rez = new StreamWriter("output.txt");
            rez.WriteLine(winner_name);
            rez.Close();
        }
    }
}
