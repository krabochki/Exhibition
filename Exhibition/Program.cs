using System;
using System.Runtime.InteropServices;

namespace Exhibition
{

    class Program
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [DllImport("User32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        static void hall_option(List<Hall> halls)
        {
            bool isItHalls = true;
            while (isItHalls)
            {
                Console.Clear();

                full_line_text("─");
                center_text("В Ы С Т А В К А  >  З А Л Ы");
                Console.WriteLine();

                full_line_text("─");
                Console.WriteLine();
                center_text("Доступные опции:");

                center_text("Назад (0) * Просмотреть залы (1) * Добавить новый зал (2)");

                center_text("Удалить зал (3) * Сортировка залов (4) * Фильтрация залов (5)");
                Console.WriteLine();
                center_text("Здесь вы можете просмотреть и изменить данные о выставочных залах.");
                center_text("Нажмите на клавишу, соответствующую номеру нужной вам опции...");

                switch (Console.ReadKey(true).Key)
                {

                    case ConsoleKey.D0:
                        {
                            isItHalls = false;
                            return;
                        }
                    case ConsoleKey.D1:
                        {
                            try
                            {
                                Console.Clear();
                                halls.Clear();


                                full_line_text("─");
                                center_text("В Ы С Т А В К А  >  З А Л Ы  >  П Р О С М О Т Р  З А Л О В");
                                Console.WriteLine();

                                full_line_text("─");
                                Console.WriteLine();

                                center_text("Здесь вы можете просмотреть список существующих выставочных залов.");

                                StreamReader f = new StreamReader("halls.txt");
                                string s;
                                string[] buf;
                                while ((s = f.ReadLine()) != null)
                                {
                                    buf = s.Split(',');
                                    Hall hall = new Hall();
                                    for (int j = 0; j <= 4; ++j)
                                    {
                                        for (int i = 0; i < buf.Length; ++i)
                                        {


                                            switch (i)
                                            {
                                                case 0:
                                                    {
                                                        hall.number = int.Parse(buf[i]);
                                                        break;
                                                    }
                                                case 1:
                                                    {
                                                        hall.square = int.Parse(buf[i]);
                                                        break;
                                                    }
                                                case 2:
                                                    {
                                                        hall.caretaker = buf[i];
                                                        break;
                                                    }
                                                case 3:
                                                    {
                                                        hall.floor = int.Parse(buf[i]);
                                                        break;
                                                    }
                                                case 4:
                                                    {
                                                        hall.status = Convert.ToBoolean(buf[i]);
                                                        break;
                                                    }
                                                case 5:
                                                    {
                                                        hall.name = buf[i];
                                                        break;
                                                    }
                                            }
                                        }
                                    }
                                    halls.Add(hall);


                                }
                                Console.WriteLine();


                                Console.WriteLine();

                                if (halls.Count > 0)
                                {
                                    center_text("Список залов:");
                                    Console.WriteLine();

                                }
                                else
                                {
                                    center_text("Выставочных залов на данный момент нет.");
                                    Console.WriteLine();

                                }

                                showHalls(halls);


                                Console.WriteLine();
                                center_text("Нажмите любую клавишу, чтобы перейти обратно...");
                                Console.ReadKey();
                                
                                f.Close();

                            }
                            catch (FileNotFoundException e)
                            {
                                Console.WriteLine(e.Message);
                                Console.WriteLine("Проверьте правильность имени файла!");
                                return;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Error:" + e.Message);
                                return;
                            }
                            break;
                        }
                    case ConsoleKey.D2:
                        {
                            try
                            {
                                Console.Clear();

                                full_line_text("─");
                                center_text("В Ы С Т А В К А  >  З А Л Ы  >  Д О Б А В Л Е Н И Е  З А Л О В");
                                Console.WriteLine();

                                full_line_text("─");
                                Console.WriteLine();

                                center_text("Здесь вы можете добавить выставочные залы.");
                                Console.WriteLine();
                                Console.WriteLine();
                                center_text("Добавление выставочного зала: ");
                                Console.WriteLine("");

                                string bufer = "";
                                string bufer_data = "";
                                bool reset = true;
                                while (reset == true)
                                {
                                    Console.Write("Введите номер зала: ");

                                    bufer_data = Console.ReadLine();

                                    try
                                    {
                                        int.Parse(bufer_data);
                                        reset = false;
                                    }
                                    catch
                                    {
                                        right_text("Ошибка! Попробуйте ещё раз!");
                                    }
                                }
                                bufer += bufer_data + ',';
                                bufer_data = "";
                                reset = true;


                                while (reset == true)
                                {
                                    Console.Write("Введите площадь зала: ");

                                    bufer_data = Console.ReadLine();

                                    try
                                    {
                                        int.Parse(bufer_data);
                                        reset = false;
                                    }
                                    catch
                                    {
                                        right_text("Ошибка! Попробуйте ещё раз!");
                                    }
                                }
                                bufer += bufer_data + ',';
                                bufer_data = "";
                                reset = true;


                                Console.Write("Введите фамилию, имя и отчество смотрителя зала: ");
                                bufer += Console.ReadLine() + ',';



                                while (reset == true)
                                {
                                    Console.Write("Введите этаж, на котором расположен зал: ");

                                    bufer_data = Console.ReadLine();

                                    try
                                    {
                                        int.Parse(bufer_data);
                                        reset = false;
                                    }
                                    catch
                                    {
                                        right_text("Ошибка! Попробуйте ещё раз!");
                                    }
                                }
                                bufer += bufer_data + ',';
                                bufer_data = "";
                                reset = true;


                                while (reset == true)
                                {
                                    Console.Write("Открыт ли зал для выставок (Да/Нет): ");
                                    bool status;
                                    bufer_data = Console.ReadLine().ToLower();
                                    if (bufer_data == "нет")
                                    {
                                        bufer_data = "false";
                                        reset = false;


                                    }
                                    else if (bufer_data == "да")
                                    {

                                        bufer_data = "true";
                                        reset = false;

                                    }
                                    else
                                    {

                                        right_text("Ошибка! Попробуйте ещё раз!");
                                    }
                                }
                                bufer += bufer_data + ',';
                                bufer_data = "";
                                reset = true;


                                Console.Write("Введите название зала: ");
                                bufer += Console.ReadLine();

                                while (reset == true)
                                {
                                    Console.Write("Вы уверены, что хотите добавить зал (Да/Нет): ");
                                    string answer = Console.ReadLine().ToLower();
                                    if (answer == "нет")
                                    {
                                        right_text("Добавление зала отменено.");
                                        reset = false;


                                    }
                                    else if (answer == "да")
                                    {
                                        StreamWriter file = new StreamWriter("halls.txt", true);
                                        file.WriteLine(bufer);
                                        file.Close();
                                        reset = false;

                                        right_text("Зал успешно добавлен!");


                                    }
                                    else
                                    {

                                        right_text("Ошибка! Попробуйте ещё раз!");
                                    }
                                }
                                Console.WriteLine();
                                Console.WriteLine();

                                center_text("Нажмите любую клавишу, чтобы перейти обратно...");
                                Console.ReadKey();



                            }
                            catch (FileNotFoundException e)
                            {
                                Console.WriteLine(e.Message);
                                Console.WriteLine("Проверьте правильность имени файла!");
                                return;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Error:" + e.Message);
                                return;
                            }
                            break;

                        }
                    case ConsoleKey.D3:
                        {

                            Console.Clear();

                            full_line_text("─");
                            center_text("В Ы С Т А В К А  >  З А Л Ы  >  У Д А Л Е Н И Е  З А Л А");
                            Console.WriteLine();

                            full_line_text("─");
                            Console.WriteLine();

                            center_text("Здесь вы можете удалить один или несколько существующихх выставочных залов.");
                            Console.WriteLine();
                            Console.WriteLine();
                            center_text("Удаление зала");

                            string answer = "";
                                                        center_text("Параметры залов: номер, площадь, название, этаж, смотритель, статус");
                                                        Console.WriteLine();

                            int num = 0;
                            bool reset = true;
                            while (reset == true)
                            {
                                Console.Write("Параметр зала: ");
                                answer = Console.ReadLine().ToLower();
                                switch (answer)
                                {
                                    case "номер":
                                        {
                                            num = 0;
                                            reset = false;

                                            break;
                                        }
                                    case "площадь":
                                        {
                                            num = 1;
                                            reset = false;

                                            break;
                                        }
                                    case "смотритель":
                                        {
                                            num = 2; reset = false;

                                            break;
                                        }
                                    case "этаж":
                                        {
                                            num = 3;
                                            reset = false;

                                            break;
                                        }
                                    case "статус":
                                        {
                                            num = 4;
                                            reset = false;

                                            break;
                                        }
                                    case "название":
                                        {
                                            num = 5;
                                            reset = false;
                                            break;
                                        }
                                    default:
                                        {
                                            right_text("Ошибка! Попробуйте ещё раз!");
                                            break;
                                        }
                                }
                            }
                            bool allornot = true;
                            string value = "";
                            Console.Write("Введите значение параметра для удаления: ");
                            value = Console.ReadLine();
                            if (answer == "статус")
                            {
                                switch (value)
                                {
                                    case "Открыт":
                                        {
                                            value = "true";
                                            break;
                                        }
                                    case "Закрыт":
                                        {
                                            value = "false";

                                            break;
                                        }
                                }

                            }

                            reset = true;

                            while (reset == true)
                            {
                                Console.Write("Сколько залов удалить (Все залы/Первый зал): ");

                                string allornotanswer = Console.ReadLine().ToLower();
                                if (allornotanswer == "все залы")
                                {
                                    allornot = true;
                                    reset = false;
                                }
                                else if (allornotanswer == "первый зал")
                                {
                                    allornot = false;
                                    reset = false;

                                }
                                else
                                {

                                    right_text("Ошибка! Попробуйте ещё раз.");
                                }
                            }

                            int numdelete = 0;
                            StreamReader f = new StreamReader("halls.txt");
                            List<string> readtext = new List<string>();
                            while (!f.EndOfStream)
                            {
                                readtext.Add(f.ReadLine());
                            }
                            f.Close();
                            bool repeat = false;
                            do
                            {
                                if (readtext.Count != 0)
                                {
                                    for (var i = 0; i <= readtext.Count - 1; i++)
                                    {
                                        string[] buf;
                                        buf = readtext[i].Split(',');

                                        if (buf[num] == value)

                                        {
                                            numdelete++;
                                            readtext.RemoveAt(i);
                                            repeat = true;
                                            if (allornot == false)
                                            {
                                                repeat = false;
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            repeat = false;

                                        }

                                    }
                                }
                                else { repeat = false; }
                            }
                            while (repeat);
                            Console.WriteLine();

                            center_text("Был(-о) удален(-о) " + numdelete + " зала(-ов)");
                            Console.WriteLine();

                            StreamWriter file = new StreamWriter("halls.txt", false);

                            for (var i = 0; i <= readtext.Count - 1; i++)
                            {
                                file.WriteLine(readtext[i]);
                            }
                            file.Close();

                            Console.WriteLine();
                            Console.WriteLine();

                            center_text("Нажмите любую клавишу, чтобы перейти обратно...");
                            Console.ReadKey();
                            break;
                        }

                    case ConsoleKey.D4:

                        {

                            try
                            {
                                Console.Clear();

                                full_line_text("─");
                                center_text("В Ы С Т А В К А  >  З А Л Ы  >  С О Р Т И Р О В К А  З А Л О В");
                                Console.WriteLine();

                                halls.Clear();
                                full_line_text("─");
                                Console.WriteLine();

                                center_text("Здесь вы можете отсортировать список всех залов в нужном вам порядке.");

                                StreamReader f = new StreamReader("halls.txt");
                                string s;
                                string[] buf;
                                while ((s = f.ReadLine()) != null)
                                {
                                    buf = s.Split(',');
                                    Hall hall = new Hall();
                                    for (int j = 0; j <= 4; ++j)
                                    {
                                        for (int i = 0; i < buf.Length; ++i)
                                        {


                                            switch (i)
                                            {
                                                case 0:
                                                    {
                                                        hall.number = int.Parse(buf[i]);
                                                        break;
                                                    }
                                                case 1:
                                                    {
                                                        hall.square = int.Parse(buf[i]);
                                                        break;
                                                    }
                                                case 2:
                                                    {
                                                        hall.caretaker = buf[i];
                                                        break;
                                                    }
                                                case 3:
                                                    {
                                                        hall.floor = int.Parse(buf[i]);
                                                        break;
                                                    }
                                                case 4:
                                                    {
                                                        hall.status = Convert.ToBoolean(buf[i]);
                                                        break;
                                                    }
                                                case 5:
                                                    {
                                                        hall.name = buf[i];
                                                        break;
                                                    }
                                            }
                                        }
                                    }
                                    halls.Add(hall);


                                }


                                Console.WriteLine();
                                                                                        center_text("Параметры залов: номер, площадь, название, этаж, смотритель, статус");

                                Console.WriteLine();
                                IEnumerable<Hall> newlist = halls;

                                bool check = true;
                                while (check == true)
                                {
                                    Console.Write("Введите параметр для сортировки списка залов: ");
                                    string parameter = Console.ReadLine().ToLower();
                                    switch (parameter)
                                    {
                                        case "номер":
                                            {
                                                //   halls.Where(p => p.square == 2000);
                                                // newlist = halls.Where(p => p.square == 2000);
                                                halls.Sort(Hall.Number);

                                                check = false;
                                                break;
                                            }
                                        case "название":
                                            {
                                                halls.Sort(Hall.Name);
                                                check = false;
                                                break;
                                            }
                                        case "этаж":
                                            {
                                                halls.Sort(Hall.Floor);
                                                check = false;
                                                break;
                                            }
                                        case "статус":
                                            {
                                                halls.Sort(Hall.Status);
                                                check = false;
                                                break;
                                            }
                                        case "площадь":
                                            {
                                                halls.Sort(Hall.Square);
                                                check = false;
                                                break;
                                            }
                                        case "смотритель":
                                            {
                                                halls.Sort(Hall.Caretaker);
                                                check = false;
                                                break;
                                            }
                                        default:
                                            {
                                                right_text("Ошибка! Попробуйте ещё раз!");

                                                break;
                                            }
                                    }
                                }

                                check = true;

                                while (check == true)
                                {
                                    Console.Write("Сортировать от меньшего к большему (Да/Наоборот): ");
                                    string parameter = Console.ReadLine().ToLower();
                                    switch (parameter)
                                    {
                                        case "да":
                                            {


                                                check = false;
                                                break;
                                            }
                                        case "наоборот":
                                            {
                                                newlist = newlist.Reverse();
                                                check = false;
                                                break;
                                            }

                                        default:
                                            {
                                                right_text("Ошибка! Попробуйте ещё раз!");

                                                break;
                                            }
                                    }
                                }

                                Console.WriteLine();
                                showHalls(newlist);





                                Console.WriteLine();
                                center_text("Нажмите любую клавишу, чтобы перейти обратно...");
                                Console.ReadKey();
                                halls.Clear();
                                f.Close();

                            }
                            catch (FileNotFoundException e)
                            {
                                Console.WriteLine(e.Message);
                                Console.WriteLine("Проверьте правильность имени файла!");
                                return;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Error:" + e.Message);
                                return;
                            }
                            break;


                        }
                    case ConsoleKey.D5:
                        {

                            try 
                            {
                                Console.Clear();
                                halls.Clear();

                                full_line_text("─");
                                center_text("В Ы С Т А В К А  >  З А Л Ы  >  Ф И Л Ь Т Р А Ц И Я  З А Л О В");
                                Console.WriteLine();

                                full_line_text("─");
                                Console.WriteLine();

                                center_text("Здесь вы можете отфильтровать список всех залов по нужному вам значению.");

                                     StreamReader f = new StreamReader("halls.txt");
                                string s;
                                string[] buf;
                                while ((s = f.ReadLine()) != null)
                                {
                                    buf = s.Split(',');
                                    Hall hall = new Hall();
                                    for (int j = 0; j <= 4; ++j)
                                    {
                                        for (int i = 0; i < buf.Length; ++i)
                                        {


                                            switch (i)
                                            {
                                                case 0:
                                                    {
                                                        hall.number = int.Parse(buf[i]);
                                                        break;
                                                    }
                                                case 1:
                                                    {
                                                        hall.square = int.Parse(buf[i]);
                                                        break;
                                                    }
                                                case 2:
                                                    {
                                                        hall.caretaker = buf[i];
                                                        break;
                                                    }
                                                case 3:
                                                    {
                                                        hall.floor = int.Parse(buf[i]);
                                                        break;
                                                    }
                                                case 4:
                                                    {
                                                        hall.status = Convert.ToBoolean(buf[i]);
                                                        break;
                                                    }
                                                case 5:
                                                    {
                                                        hall.name = buf[i];
                                                        break;
                                                    }
                                            }
                                        }
                                    }
                                    halls.Add(hall);


                                }
                                Console.WriteLine();
                                                                                        center_text("Параметры залов: номер, площадь, название, этаж, смотритель, статус");

                                Console.WriteLine();
                                IEnumerable<Hall> newlist = halls;
                                string filtr = "";
                                bool check = true;
                                while (check == true)
                                {
                                    Console.Write("Введите параметр для фильтрации списка залов: ");

                                    filtr = Console.ReadLine().ToLower();
                                    switch (filtr)
                                    {
                                        case "номер":
                                            {
                                                // newlist = halls.Where(p => p.square == 2000);
                                                filtr = "number";
                                                                                                halls.Sort(Hall.Number);

                                                check = false;
                                                break;
                                            }
                                        case "название":
                                            {
                                                filtr = "name";

                                                halls.Sort(Hall.Name);
                                                check = false;
                                                break;
                                            }
                                        case "этаж":
                                            {
                                                filtr = "floor";

                                                halls.Sort(Hall.Floor);
                                                check = false;
                                                break;
                                            }
                                        case "статус":
                                            {
                                                filtr = "status";

                                                halls.Sort(Hall.Status);
                                                check = false;
                                                break;
                                            }
                                        case "площадь":
                                            {
                                                filtr = "square";

                                                halls.Sort(Hall.Square);
                                                check = false;
                                                break;
                                            }
                                        case "смотритель":
                                            {
                                                filtr = "caretaker";

                                                halls.Sort(Hall.Caretaker);
                                                check = false;
                                                break;
                                            }
                                        default:
                                            {

                                                right_text("Ошибка! Попробуйте ещё раз!");

                                                break;
                                            }
                                    }
                                }

                                Console.Write("Записи залов с каким значением параметра фильтрации нужно вывести: ");
                                string parameter = Console.ReadLine();

                                switch (filtr)
                                {
                                    case "number":
                                        {
                                            newlist = halls.Where(p => p.number == int.Parse(parameter));
                                            break;
                                        }
                                    case "name":
                                        {
                                            newlist = halls.Where(p => p.name == parameter);
                                            break;
                                        }
                                    case "floor":
                                        {
                                            newlist = halls.Where(p => p.floor == int.Parse(parameter));
                                            break;
                                        }
                                    case "square":
                                        {
                                            newlist = halls.Where(p => p.square == int.Parse(parameter));
                                            break;
                                        }
                                    case "status":
                                        {
                                            if (parameter == "открыт")
                                            {
                                                newlist = halls.Where(p => p.status == true);

                                            }
                                            else
                                            {

                                                newlist = halls.Where(p => p.status == false);


                                            }
                                            break;
                                        }
                                    case "caretaker":
                                        {
                                            newlist = halls.Where(p => p.caretaker == parameter);
                                            break;
                                        }
                                }

                                Console.WriteLine();

                                showHalls(newlist);
                                Console.WriteLine();
                                center_text("Нажмите любую клавишу, чтобы перейти обратно...");
                                Console.ReadKey();
                                halls.Clear();
                            }
                            catch (FileNotFoundException e)
                            {
                                Console.WriteLine(e.Message);
                                Console.WriteLine("Проверьте правильность имени файла!");
                                return;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Error:" + e.Message);
                                return;
                            }
                            break;




                        }
                }

            }
        }
        static void style_option()
        {
            bool isItStyle = true;
            while (isItStyle)
            {

                Console.Clear();

                full_line_text("─");
                center_text("В Ы С Т А В К А  >  О Ф О Р М Л Е Н И Е");
                Console.WriteLine();

                full_line_text("─");
                Console.WriteLine();
                center_text("Доступные опции:");

                center_text("Назад (0) * Поменять цвет текста (1) * Поменять цвет фона (2)");
                Console.WriteLine();
                center_text("Здесь вы можете изменить внешний вид и состояние консоли.");
                center_text("Нажмите на клавишу, соответствующую номеру нужной вам опции...");


                switch (Console.ReadKey(true).Key)
                {


                    case ConsoleKey.D0:
                        {
                            isItStyle = false;
                            break;
                        }
                    case ConsoleKey.D1:
                        {
                            bool isItForegroundColor = true;
                            while (isItForegroundColor)
                            {
                                Console.Clear();

                                full_line_text("─");
                                center_text("В Ы С Т А В К А  >  О Ф О Р М Л Е Н И Е >  И З М Е Н Е Н И Е  Т Е К С Т А");
                                Console.WriteLine();

                                full_line_text("─");
                                Console.WriteLine();
                                center_text("Доступные опции:");

                                center_text("Назад (0) * Черный (1)  * Серый (2) * Синий (3) * Зеленый (4)");
                                center_text("Бирюзовый (5) * Красный (6) * Фиолетовый (7) * Желтый (8) * Белый (9)");

                                Console.WriteLine();
                                center_text("Здесь вы можете изменить текст в консоли, а точнее его цвет.");
                                center_text("Нажмите на клавишу, соответствующую номеру нужной вам опции...");




                                switch (Console.ReadKey(true).Key)
                                {

                                    case ConsoleKey.D0:
                                        {
                                            isItForegroundColor = false;
                                            break;
                                        }

                                    case ConsoleKey.D1:
                                        {
                                            Console.ForegroundColor = ConsoleColor.Black;
                                            break;
                                        }
                                    case ConsoleKey.D2:
                                        {
                                            Console.ForegroundColor = ConsoleColor.Gray;
                                            break;
                                        }
                                    case ConsoleKey.D3:
                                        {
                                            Console.ForegroundColor = ConsoleColor.Blue;
                                            break;
                                        }
                                    case ConsoleKey.D4:
                                        {
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            break;
                                        }
                                    case ConsoleKey.D5:
                                        {
                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            break;
                                        }
                                    case ConsoleKey.D6:
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            break;
                                        }
                                    case ConsoleKey.D7:
                                        {
                                            Console.ForegroundColor = ConsoleColor.Magenta;
                                            break;
                                        }
                                    case ConsoleKey.D8:
                                        {
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            break;
                                        }
                                    case ConsoleKey.D9:
                                        {
                                            Console.ForegroundColor = ConsoleColor.White;
                                            break;
                                        }
                                }

                            }

                            break;
                        }
                    case ConsoleKey.D2:
                        {
                            bool isIt = true;
                            while (isIt)
                            {
                                Console.Clear();

                                full_line_text("─");
                                center_text("В Ы С Т А В К А  >  О Ф О Р М Л Е Н И Е >  И З М Е Н Е Н И Е  Ф О Н А");
                                Console.WriteLine();

                                full_line_text("─");
                                Console.WriteLine();
                                center_text("Доступные опции:");

                                center_text("Назад (0) * Черный (1)  * Серый (2) * Синий (3) * Зеленый (4)");
                                center_text("Бирюзовый (5) * Красный (6) * Фиолетовый (7) * Желтый (8) * Белый (9)");

                                Console.WriteLine();
                                center_text("Здесь вы можете изменить фон консоли, а точнее его цвет.");
                                center_text("Нажмите на клавишу, соответствующую номеру нужной вам опции...");



                                switch (Console.ReadKey(true).Key)
                                {

                                    case ConsoleKey.D0:
                                        {
                                            isIt = false;
                                            break;
                                        }

                                    case ConsoleKey.D1:
                                        {
                                            Console.BackgroundColor = ConsoleColor.Black;
                                            break;
                                        }
                                    case ConsoleKey.D2:
                                        {
                                            Console.BackgroundColor = ConsoleColor.Gray;
                                            break;
                                        }
                                    case ConsoleKey.D3:
                                        {
                                            Console.BackgroundColor = ConsoleColor.Blue;
                                            break;
                                        }
                                    case ConsoleKey.D4:
                                        {
                                            Console.BackgroundColor = ConsoleColor.Green;
                                            break;
                                        }
                                    case ConsoleKey.D5:
                                        {
                                            Console.BackgroundColor = ConsoleColor.Cyan;
                                            break;
                                        }
                                    case ConsoleKey.D6:
                                        {
                                            Console.BackgroundColor = ConsoleColor.Red;
                                            break;
                                        }
                                    case ConsoleKey.D7:
                                        {
                                            Console.BackgroundColor = ConsoleColor.Magenta;
                                            break;
                                        }
                                    case ConsoleKey.D8:
                                        {
                                            Console.BackgroundColor = ConsoleColor.Yellow;
                                            break;
                                        }
                                    case ConsoleKey.D9:
                                        {
                                            Console.BackgroundColor = ConsoleColor.White;
                                            break;
                                        }
                                }

                            }

                            break;
                        }
                }
            }
        }
        static void exhibit_option(List<Exhibit> exhibits)
        {
            bool isItExhibits = true;
            while (isItExhibits)
            {
                Console.Clear();
                 exhibits.Clear();

                full_line_text("─");
                center_text("В Ы С Т А В К А  >  Э К С П О Н А Т Ы");
                Console.WriteLine();

                full_line_text("─");
                Console.WriteLine();
                center_text("Доступные опции:");

                center_text("Назад (0) * Просмотреть экспонаты (1) * Добавить новый экспонат (2)");

                center_text("Удалить экспонат (3) * Сортировка экспонатов (4) * Фильтрация экспонатов (5)");
                Console.WriteLine();
                center_text("Здесь вы можете просмотреть и изменить данные об экспонатах.");
                center_text("Нажмите на клавишу, соответствующую номеру нужной вам опции...");

                switch (Console.ReadKey(true).Key)
                {

                    case ConsoleKey.D0:
                        {
                            isItExhibits = false;
                            return;
                        }
                    case ConsoleKey.D1:
                        {
                            try
                            {
                                Console.Clear();
                                exhibits.Clear();

                                full_line_text("─");
                                center_text("В Ы С Т А В К А  >  Э К С П О Н А Т Ы  >  П Р О С М О Т Р  Э К С П О Н А Т О В");
                                Console.WriteLine();

                                full_line_text("─");
                                Console.WriteLine();

                                center_text("Здесь вы можете просмотреть список существующих экспонатов.");

                                StreamReader f = new StreamReader("exhibits.txt");
                                string s;
                                string[] buf;
                                while ((s = f.ReadLine()) != null)
                                {
                                    buf = s.Split(',');
                                    Exhibit exhibit = new Exhibit();
                                    
                                        for (int i = 0; i < buf.Length; ++i)
                                        {


                                            switch (i)
                                            {
                                                case 0:
                                                    {
                                                        exhibit.code = int.Parse(buf[i]);
                                                        break;
                                                    }
                                                case 1:
                                                    {
                                                        exhibit.cost = decimal.Parse(buf[i]);
                                                        break;
                                                    }
                                                case 2:
                                                    {
                                                        exhibit.owner = buf[i];
                                                        break;
                                                    }
                                                case 3:
                                                    {
                                                        exhibit.name = buf[i];
                                                        break;
                                                    }
                                            }
                                    }

                                        exhibits.Add(exhibit);



                                }
                                Console.WriteLine();


                              
                                    showExhibits(exhibits);



                                Console.WriteLine();
                                center_text("Нажмите любую клавишу, чтобы перейти обратно...");
                                Console.ReadKey();
                                f.Close();

                            }
                            catch (FileNotFoundException e)
                            {
                                Console.WriteLine(e.Message);
                                Console.WriteLine("Проверьте правильность имени файла!");
                                return;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Error:" + e.Message);
                                return;
                            }
                            break;
                                             exhibits.Clear();

                        }
                    case ConsoleKey.D2:
                        {
                            try
                            {
                                Console.Clear();


                                full_line_text("─");
                                center_text("В Ы С Т А В К А  >  Э К С П О Н А Т Ы  >  Д О Б А В Л Е Н И Е  Э К С П О Н А Т О В");
                                Console.WriteLine();

                                full_line_text("─");
                                Console.WriteLine();

                                center_text("Здесь вы можете добавить экспонаты.");
                                Console.WriteLine();
                                Console.WriteLine();
                                center_text("Добавление экспоната: ");
                                Console.WriteLine("");

                                string bufer = "";
                                string bufer_data = "";
                                bool reset = true;
                                while (reset == true)
                                {
                                    Console.Write("Введите код экспоната: ");

                                    bufer_data = Console.ReadLine();

                                    try
                                    {
                                        int.Parse(bufer_data);
                                        reset = false;
                                    }
                                    catch
                                    {
                                        right_text("Ошибка! Попробуйте ещё раз!");
                                    }
                                }
                                bufer += bufer_data + ',';
                                bufer_data = "";
                                reset = true;


                                while (reset == true)
                                {
                                    Console.Write("Введите стоимость экспоната: ");

                                    bufer_data = Console.ReadLine();

                                    try
                                    {
                                        decimal.Parse(bufer_data);
                                        reset = false;
                                    }
                                    catch
                                    {
                                        right_text("Ошибка! Попробуйте ещё раз!");
                                    }
                                }
                                bufer += bufer_data + ',';
                                bufer_data = "";
                                reset = true;


                                Console.Write("Введите фамилию, имя и отчество владельца экспоната: ");
                                bufer += Console.ReadLine() + ',';
                                bufer_data = "";
                                reset = true;

                                Console.Write("Введите название экспоната: ");
                                bufer += Console.ReadLine();

                                while (reset == true)
                                {
                                    Console.Write("Вы уверены, что хотите добавить экспонат (Да/Нет): ");
                                    string answer = Console.ReadLine().ToLower();
                                    if (answer == "нет")
                                    {
                                        right_text("Добавление зала отменено.");
                                        reset = false;


                                    }
                                    else if (answer == "да")
                                    {
                                        StreamWriter file = new StreamWriter("exhibits.txt", true);
                                        file.WriteLine(bufer);
                                        file.Close();
                                        reset = false;

                                        right_text("Экспонат успешно добавлен!");


                                    }
                                    else
                                    {

                                        right_text("Ошибка! Попробуйте ещё раз!");
                                    }
                                }
                                Console.WriteLine();
                                Console.WriteLine();

                                center_text("Нажмите любую клавишу, чтобы перейти обратно...");
                                Console.ReadKey();



                            }
                            catch (FileNotFoundException e)
                            {
                                Console.WriteLine(e.Message);
                                Console.WriteLine("Проверьте правильность имени файла!");
                                return;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Error:" + e.Message);
                                return;
                            }
                            break;

                        }
                    case ConsoleKey.D3:
                        {

                            Console.Clear();

                            full_line_text("─");
                            Console.WriteLine();
                            center_text("В Ы С Т А В К А  >  Э К С П О Н А Т Ы  >  У Д А Л Е Н И Е  Э К С П О Н А Т А");
                            Console.WriteLine();

                            full_line_text("─");
                            Console.WriteLine();

                            center_text("Здесь вы можете удалить один или несколько существующих экспонатов.");
                            Console.WriteLine();
                                                                                    center_text("Параметры экспонатов: код, владелец, название, цена");

                            Console.WriteLine();
                            center_text("Удаление экспоната");
                            Console.WriteLine();

                            string answer = "";

                            int num = 0;
                            bool reset = true;
                            while (reset == true)
                            {
                                Console.Write("Значение экспоната: ");
                                answer = Console.ReadLine().ToLower();
                                switch (answer)
                                {
                                    case "код":
                                        {
                                            num = 0;
                                            reset = false;

                                            break;
                                        }
                                    case "стоимость":
                                        {
                                            num = 1;
                                            reset = false;

                                            break;
                                        }
                                    case "цена":
                                        {
                                            num = 1;
                                            reset = false;

                                            break;
                                        }
                                    case "владелец":
                                        {
                                            num = 2; reset = false;

                                            break;
                                        }
                                    case "название":
                                        {
                                            num = 3;
                                            reset = false;
                                            break;
                                        }
                                    default:
                                        {
                                            right_text("Ошибка! Попробуйте ещё раз!");
                                            break;
                                        }
                                }
                            }
                            bool allornot = true;
                            string value = "";
                            Console.Write("Введите значение характеристики для удаления: ");
                            value = Console.ReadLine();
                        

                            reset = true;

                            while (reset == true)
                            {
                                Console.Write("Сколько экспонатов удалить (Все экспонаты/Первый экспонат): ");

                                string allornotanswer = Console.ReadLine().ToLower();
                                if (allornotanswer == "все экспонаты")
                                {
                                    allornot = true;
                                    reset = false;
                                }
                                else if (allornotanswer == "первый экспонат")
                                {
                                    allornot = false;
                                    reset = false;

                                }
                                else
                                {

                                    right_text("Ошибка! Попробуйте ещё раз.");
                                }
                            }

                            int numdelete = 0;
                            StreamReader f = new StreamReader("exhibits.txt");
                            List<string> readtext = new List<string>();
                            while (!f.EndOfStream)
                            {
                                readtext.Add(f.ReadLine());
                            }
                            f.Close();
                            bool repeat = false;
                            do
                            {
                                if (readtext.Count != 0)
                                {
                                    for (var i = 0; i <= readtext.Count - 1; i++)
                                    {
                                        string[] buf;
                                        buf = readtext[i].Split(',');

                                        if (buf[num] == value)

                                        {
                                            numdelete++;
                                            readtext.RemoveAt(i);
                                            repeat = true;
                                            if (allornot == false)
                                            {
                                                repeat = false;
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            repeat = false;

                                        }

                                    }
                                }
                                else { repeat = false; }
                            }
                            while (repeat);
                            Console.WriteLine();

                            center_text("Был(-о) удален(-о) " + numdelete + " экспонат(-ов)");
                            Console.WriteLine();

                            StreamWriter file = new StreamWriter("exhibits.txt", false);

                            for (var i = 0; i <= readtext.Count - 1; i++)
                            {
                                file.WriteLine(readtext[i]);
                            }
                            file.Close();

                            Console.WriteLine();
                            Console.WriteLine();

                            center_text("Нажмите любую клавишу, чтобы перейти обратно...");
                            Console.ReadKey();
                            break;
                        }

                    case ConsoleKey.D4:

                        {

                            try
                            {
                                 Console.Clear();

                                full_line_text("─");
                                center_text("В Ы С Т А В К А  >  З А Л Ы  >  С О Р Т И Р О В К А  Э К С П О Н А Т О В");
                                Console.WriteLine();

                                exhibits.Clear();
                                full_line_text("─");
                                Console.WriteLine();

                                center_text("Здесь вы можете отсортировать список всех залов в нужном вам порядке.");
               StreamReader f = new StreamReader("exhibits.txt");
                                string s;
                                string[] buf;
                                while ((s = f.ReadLine()) != null)
                                {
                                    buf = s.Split(',');
                                    Exhibit exhibit = new Exhibit();
                                    
                                        for (int i = 0; i < buf.Length; ++i)
                                        {


                                            switch (i)
                                            {
                                                case 0:
                                                    {
                                                        exhibit.code = int.Parse(buf[i]);
                                                        break;
                                                    }
                                                case 1:
                                                    {
                                                        exhibit.cost = decimal.Parse(buf[i]);
                                                        break;
                                                    }
                                                case 2:
                                                    {
                                                        exhibit.owner = buf[i];
                                                        break;
                                                    }
                                                case 3:
                                                    {
                                                        exhibit.name = buf[i];
                                                        break;
                                                    }
                                            }
                                    }

                                        exhibits.Add(exhibit);



                                


                                }


                                Console.WriteLine();
                                                                                                                    center_text("Параметры экспонатов: код, владелец, название, цена");

                                Console.WriteLine();

                                bool check = true;
                                while (check == true)
                                {
                                    Console.Write("Введите параметр для сортировки списка залов: ");
                                    string parameter = Console.ReadLine().ToLower();
                                    switch (parameter)
                                    {
                                        case "код":
                                            {
                                                //   halls.Where(p => p.square == 2000);
                                                // newlist = halls.Where(p => p.square == 2000);
                                                exhibits.Sort(Exhibit.Code);
                                                check = false;
                                                break;
                                            }
                                        case "название":
                                            {
                                                exhibits.Sort(Exhibit.Name);
                                                check = false;
                                                break;
                                            }
                                        case "цена":
                                            {
                                                exhibits.Sort(Exhibit.Cost);
                                                check = false;
                                                break;
                                            }
                                        case "владелец":
                                            {
                                                exhibits.Sort(Exhibit.Owner);
                                                check = false;
                                                break;
                                            }
                                        default:
                                            {
                                                right_text("Ошибка! Попробуйте ещё раз!");
                                                break;
                                            }
                                    }
                                }

                                IEnumerable<Exhibit> newlist = exhibits;

                                check = true;

                                while (check == true)
                                {
                                    Console.Write("Сортировать от меньшего к большему (Да/Наоборот): ");
                                    string parameter = Console.ReadLine().ToLower();
                                    switch (parameter)
                                    {
                                        case "да":
                                            {


                                                check = false;
                                                break;
                                            }
                                        case "наоборот":
                                            {
                                                newlist = newlist.Reverse();
                                                check = false;
                                                break;
                                            }

                                        default:
                                            {
                                                right_text("Ошибка! Попробуйте ещё раз!");

                                                break;
                                            }
                                    }
                                }

                                Console.WriteLine();
                                showExhibits(newlist);





                                Console.WriteLine();
                                center_text("Нажмите любую клавишу, чтобы перейти обратно...");
                                Console.ReadKey();
                                exhibits.Clear();
                                f.Close();

                            }
                            catch (FileNotFoundException e)
                            {
                                Console.WriteLine(e.Message);
                                Console.WriteLine("Проверьте правильность имени файла!");
                                return;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Error:" + e.Message);
                                return;
                            }
                            break;


                        }
                    case ConsoleKey.D5:
                        {

                            try
                            {
                                Console.Clear();
                                                 exhibits.Clear();

                                full_line_text("─");
                                center_text("В Ы С Т А В К А  >  Э К С П О Н А Т Ы  >  Ф И Л Ь Т Р А Ц И Я  Э К С П О Н А Т О В");
                                Console.WriteLine();

                                full_line_text("─");
                                Console.WriteLine();

                                center_text("Здесь вы можете отфильтровать список всех экспонатов по нужному вам значению.");

                              StreamReader f = new StreamReader("exhibits.txt");
                                string s;
                                string[] buf;
                                while ((s = f.ReadLine()) != null)
                                {
                                    buf = s.Split(',');
                                    Exhibit exhibit = new Exhibit();
                                    
                                        for (int i = 0; i < buf.Length; ++i)
                                        {


                                            switch (i)
                                            {
                                                case 0:
                                                    {
                                                        exhibit.code = int.Parse(buf[i]);
                                                        break;
                                                    }
                                                case 1:
                                                    {
                                                        exhibit.cost = decimal.Parse(buf[i]);
                                                        break;
                                                    }
                                                case 2:
                                                    {
                                                        exhibit.owner = buf[i];
                                                        break;
                                                    }
                                                case 3:
                                                    {
                                                        exhibit.name = buf[i];
                                                        break;
                                                    }
                                            }
                                    }

                                        exhibits.Add(exhibit);



                                }
                                f.Close();

                                Console.WriteLine();
                                                                                                                    center_text("Параметры экспонатов: код, владелец, название, цена");

                                Console.WriteLine();
                               IEnumerable<Exhibit> newlist = exhibits;
                                string filtr = "";
                                bool check = true;
                                while (check == true)
                                {
                                    Console.Write("Введите параметр для фильтрации списка экспонатов: ");
                                    filtr = Console.ReadLine().ToLower();
                                    switch (filtr)
                                    {
                                        case "код":
                                            {
                                                filtr = "code";
                                                exhibits.Sort(Exhibit.Code);
                                                check = false;
                                                break;
                                            }
                                        case "название":
                                            {
                                                filtr = "name";
                                                exhibits.Sort(Exhibit.Name);
                                                check = false;
                                                break;
                                            }
                                        case "стоимость":
                                            {
                                                filtr = "cost";
                                                exhibits.Sort(Exhibit.Cost);
                                                check = false;
                                                break;
                                            }
                                        case "владелец":
                                            {
                                                filtr = "owner";
                                                exhibits.Sort(Exhibit.Owner);
                                                check = false;
                                                break;
                                            }
                                        default:
                                            {

                                                right_text("Ошибка! Попробуйте ещё раз!");

                                                break;
                                            }
                                    }
                                }

                                Console.Write("Записи залов с каким значением параметра фильтрации нужно вывести: ");
                                string parameter = Console.ReadLine();

                                switch (filtr)
                                {
                                    case "code":
                                        {
                                            newlist = exhibits.Where(p => p.code == int.Parse(parameter));
                                            break;
                                        }
                                    case "name":
                                        {
                                            newlist = exhibits.Where(p => p.name == parameter);
                                            break;
                                        }
                                    case "owner":
                                        {
                                            newlist = exhibits.Where(p => p.owner == parameter);
                                            break;
                                        }
                                    case "cost":
                                        {
                                            newlist = exhibits.Where(p => p.cost == decimal.Parse(parameter));
                                            break;
                                        }
                                }

                                Console.WriteLine();

                                showExhibits(newlist);
                                Console.WriteLine();
                                center_text("Нажмите любую клавишу, чтобы перейти обратно...");
                                Console.ReadKey();
                                exhibits.Clear();
                            }
                            catch (FileNotFoundException e)
                            {
                                Console.WriteLine(e.Message);
                                Console.WriteLine("Проверьте правильность имени файла!");
                                return;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Error:" + e.Message);
                                return;
                            }
                            break;




                        }
                }

            }
        }
        static void placement_scheme_option(List<Placement_scheme> placement_schemes, List<Hall> halls, List<Exhibit> exhibits)
        {
            bool isItHalls = true;
            while (isItHalls)
            {

                
                                StreamReader k = new StreamReader("exhibits.txt");
                                string s1;
                                string[] buf1;
                                while ((s1 = k.ReadLine()) != null)
                                {
                                    buf1 = s1.Split(',');
                                    Exhibit exhibit = new Exhibit();
                                    
                                        for (int i = 0; i < buf1.Length; ++i)
                                        {


                                            switch (i)
                                            {
                                                case 0:
                                                    {
                                                        exhibit.code = int.Parse(buf1[i]);
                                                        break;
                                                    }
                                                case 1:
                                                    {
                                                        exhibit.cost = decimal.Parse(buf1[i]);
                                                        break;
                                                    }
                                                case 2:
                                                    {
                                                        exhibit.owner = buf1[i];
                                                        break;
                                                    }
                                                case 3:
                                                    {
                                                        exhibit.name = buf1[i];
                                                        break;
                                                    }
                                            }
                                    }

                                        exhibits.Add(exhibit);



                                }


                Console.Clear();

                full_line_text("─");
                center_text("В Ы С Т А В К А  >  С Х Е М Ы  Р А З М Е Щ Е Н И Я");
                Console.WriteLine();

                full_line_text("─");
                Console.WriteLine();
                center_text("Доступные опции:");

                center_text("Назад (0) * Просмотреть схемы размещения (1) * Добавить новую схему размещения (2)");

                center_text("Удалить схему размещения (3) * Сортировка схем размещения (4) * Фильтрация схем размещения (5)");
                Console.WriteLine();
                center_text("Здесь вы можете просмотреть и изменить данные о схемах размещения.");
                center_text("Нажмите на клавишу, соответствующую номеру нужной вам опции...");

                switch (Console.ReadKey(true).Key)
                {

                    case ConsoleKey.D0:
                        {
                            isItHalls = false;
                            return;
                        }
                    case ConsoleKey.D1:
                        {
                            try
                            {
                                placement_schemes.Clear();

                                Console.Clear();

                                full_line_text("─");
                                center_text("В Ы С Т А В К А  >  С Х Е М Ы  >  П Р О С М О Т Р  С Х Е М");
                                Console.WriteLine();

                                full_line_text("─");
                                Console.WriteLine();
                                center_text("Здесь вы можете просмотреть список существующих схем размещения.");

                                StreamReader f = new StreamReader("placement_scheme.txt");
                                string s;
                                string[] buf;
                                
                                while ((s = f.ReadLine()) != null)
                                {
                                    buf = s.Split(',');
                                    Placement_scheme placement_scheme = new Placement_scheme();
                                    for (int j = 0; j <= 4; ++j)
                                    {
                                        for (int i = 0; i < buf.Length; ++i)
                                        {


                                            switch (i)
                                            {
                                                case 0:
                                                    {
                                                        var y = int.Parse(buf[i]);
                                                        foreach (var x in halls)

                                                        {
                                                            if (x.number == y)
                                                            {
                                                                placement_scheme.hall = x;
                                                            }
                                                        }
                                                        break;


                                                    }
                                                case 1:
                                                    {

                                                        var y = int.Parse(buf[i]);
                                                        foreach (var x in exhibits)

                                                        {
                                                            if (x.code == y)
                                                            {
                                                                placement_scheme.exhibit = x;
                                                            }
                                                        }
                                                        break;


                                                    }
                                                case 2:
                                                    {

                                                        placement_scheme.date_of_beggining = DateTime.ParseExact(buf[i], "yyyy-MM-dd HH:mm",
                                        System.Globalization.CultureInfo.InvariantCulture);

                                                        break;
                                                    }
                                                case 3:
                                                    {

                                                        placement_scheme.date_of_end = DateTime.ParseExact(buf[i], "yyyy-MM-dd HH:mm",
                                      System.Globalization.CultureInfo.InvariantCulture);

                                                        break;
                                                    }

                                            }
                                        }
                                    }
                                    placement_schemes.Add(placement_scheme);


                                }
                                Console.WriteLine();




                                Console.WriteLine();

                                if (placement_schemes.Count > 0)
                                {
                                    center_text("Список схем размещения:");
                                    Console.WriteLine();

                                }
                                else
                                {
                                    center_text("Схем размещения на данный момент нет.");
                                    Console.WriteLine();
                                }

                                showPlacementSchemes(placement_schemes);


                                Console.WriteLine();
                                center_text("Нажмите любую клавишу, чтобы перейти обратно...");
                                Console.ReadKey();
                                f.Close();

                            }
                            catch (FileNotFoundException e)
                            {
                                Console.WriteLine(e.Message);
                                Console.WriteLine("Проверьте правильность имени файла!");
                                return;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Error:" + e.Message);
                                return;
                            }
                            break;
                        }
                    case ConsoleKey.D2:
                        {
                            try
                            {

                                Console.Clear();

                                full_line_text("─");
                                center_text("В Ы С Т А В К А  >  С Х Е М Ы  >  Д О Б А В Л Е Н И Е  С Х Е М Ы");
                                Console.WriteLine();

                                full_line_text("─");
                                Console.WriteLine();

                                center_text("Здесь вы можете добавить схемы размещения.");
                                Console.WriteLine();
                                Console.WriteLine();
                                center_text("Добавление схемы размещения: ");
                                Console.WriteLine("");

                                string bufer = "";
                                string bufer_data = "";
                                bool reset = true;
                                while (reset)
                                {
                                    Console.Write("Введите номер зала схемы размещения: ");

                                    bufer_data = Console.ReadLine();

                                    try
                                    {
                                        int.Parse(bufer_data);
                                         bool check = false;
                                        foreach (Hall hall in halls)
                                        {

                                            if
                                            (hall.number == int.Parse(bufer_data))
                                            {
                                                check=true;
                                            }
                                            

                                        }
                                        if (check == false) {
                                                                                right_text("Ошибка! Такого зала нет в системе!");

                                        
                                        }
                                        else { 
                                        reset = false;
                                            }

                                       

                                    }
                                    catch
                                    {
                                        right_text("Ошибка! Попробуйте ещё раз!");
                                    }
                                }
                                bufer += bufer_data + ',';
                                bufer_data = "";
                                reset = true;


                                while (reset)
                                {
                                    Console.Write("Введите код экспоната схемы размещения: ");

                                    bufer_data = Console.ReadLine();

                                    try
                                    {
                                        int.Parse(bufer_data);
                                         bool check = false;
                                        foreach (Exhibit exhibit in exhibits)
                                        {

                                            if
                                            (exhibit.code == int.Parse(bufer_data))
                                            {
                                                check=true;
                                            }
                                            

                                        }
                                        if (check == false) {
                                                                                right_text("Ошибка! Такого экспоната нет в системе!");

                                        
                                        }
                                        else { 
                                        reset = false;
                                            }



                                    }
                                    catch
                                    {
                                        right_text("Ошибка! Попробуйте ещё раз!");
                                    }
                                }
                                bufer += bufer_data + ',';
                                bufer_data = "";
                                reset = true;

                                Console.WriteLine("Пример шаблона для ввода дат: 2005-08-06 02:00 ");
                                DateTime firstdate = new DateTime(2009, 8, 1, 0, 0, 0);

                                DateTime seconddate;

                                while (reset == true)
                                {
                                    Console.Write("Введите дату начала схемы размещения: ");

                                    bufer_data = Console.ReadLine();

                                    try
                                    {
                                        DateTime.ParseExact(bufer_data, "yyyy-MM-dd HH:mm",
                                      System.Globalization.CultureInfo.InvariantCulture);
                                        firstdate = DateTime.ParseExact(bufer_data, "yyyy-MM-dd HH:mm",
                                      System.Globalization.CultureInfo.InvariantCulture);
                                        reset = false;
                                    }
                                    catch
                                    {
                                        right_text("Ошибка! Попробуйте ещё раз!");
                                    }
                                }
                                bufer += bufer_data + ',';
                                bufer_data = "";
                                reset = true;

                                while (reset)
                                {
                                    Console.Write("Введите дату окончания схемы размещения: ");

                                    bufer_data = Console.ReadLine();

                                    try
                                    {
                                        seconddate = DateTime.ParseExact(bufer_data, "yyyy-MM-dd HH:mm",
                                      System.Globalization.CultureInfo.InvariantCulture);
                                        DateTime.ParseExact(bufer_data, "yyyy-MM-dd HH:mm",
                                      System.Globalization.CultureInfo.InvariantCulture);

                                        if (DateTime.Compare(firstdate, seconddate) < 0)
                                        {
                                            reset = false;


                                        }
                                        else
                                        {
                                            right_text("Ошибка! Попробуйте ещё раз!");
                                        }



                                    }
                                    catch
                                    {
                                        right_text("Ошибка! Попробуйте ещё раз!");
                                    }


                                }
                                bufer += bufer_data;
                                bufer_data = "";

                                reset = true;

                                while (reset == true)
                                {
                                    Console.Write("Вы уверены, что хотите добавить выставочную схему (Да/Нет): ");
                                    string answer = Console.ReadLine().ToLower();
                                    if (answer == "нет")
                                    {
                                        right_text("Добавление выставочной схемы отменено.");
                                        reset = false;


                                    }
                                    else if (answer == "да")
                                    {
                                        StreamWriter file = new StreamWriter("placement_scheme.txt", true);
                                        file.WriteLine(bufer);
                                        file.Close();
                                        reset = false;

                                        right_text("Выставочная схема успешно добавлена!");


                                    }
                                    else
                                    {

                                        right_text("Ошибка! Попробуйте ещё раз!");
                                    }
                                }
                                Console.WriteLine();
                                Console.WriteLine();

                                center_text("Нажмите любую клавишу, чтобы перейти обратно...");
                                Console.ReadKey();



                            }
                            catch (FileNotFoundException e)
                            {
                                Console.WriteLine(e.Message);
                                Console.WriteLine("Проверьте правильность имени файла!");
                                return;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Error:" + e.Message);
                                return;
                            }
                            break;

                        }
                    case ConsoleKey.D3:
                        {

                             Console.Clear();

                            full_line_text("─");
                            Console.WriteLine();
                            center_text("В Ы С Т А В К А  >  С Х Е М Ы  >  У Д А Л Е Н И Е  С Х Е М Ы");
                            Console.WriteLine();

                            full_line_text("─");
                            Console.WriteLine();

                            center_text("Здесь вы можете удалить одну или несколько существующих выставочных схем.");
                            Console.WriteLine();
                            Console.WriteLine();
                            center_text("Удаление схемы");
                                                                                                                center_text("Параметры схем: номер зала, код экспоната, дата начала, дата окончания");

                            Console.WriteLine();

                            string answer = "";

                            int num = 0;
                            bool reset = true;
                            while (reset == true)
                            {
                                Console.Write("Значение схемы: ");
                                answer = Console.ReadLine().ToLower();
                                switch (answer)
                                {
                                    case "код экспоната":
                                        {
                                            num = 1;
                                            reset = false;

                                            break;
                                        }
                                    case "номер зала":
                                        {
                                            num = 0;
                                            reset = false;

                                            break;
                                        }
                                    case "дата начала":
                                        {
                                            num = 2;
                                            reset = false;

                                            break;
                                        }
                                    case "дата окончания":
                                        {
                                            num = 3;
                                            reset = false; 
                                            break;
                                        }
                                                                            default:
                                        {
                                            right_text("Ошибка! Попробуйте ещё раз!");
                                            break;
                                        }

                                }
                            }
                            bool allornot = true;
                            string value = "";
                            Console.Write("Введите значение характеристики для удаления: ");
                            value = Console.ReadLine();
                        

                            reset = true;

                            while (reset == true)
                            {
                                Console.Write("Сколько схем удалить (Все схемы/Первую схему): ");

                                string allornotanswer = Console.ReadLine().ToLower();
                                if (allornotanswer == "все схемы")
                                {
                                    allornot = true;
                                    reset = false;
                                }
                                else if (allornotanswer == "первую схему")
                                {
                                    allornot = false;
                                    reset = false;

                                }
                                else
                                {

                                    right_text("Ошибка! Попробуйте ещё раз.");
                                }
                            }

                            int numdelete = 0;
                            StreamReader f = new StreamReader("placement_scheme.txt");
                            List<string> readtext = new List<string>();
                            while (!f.EndOfStream)
                            {
                                readtext.Add(f.ReadLine());
                            }
                            f.Close();
                            bool repeat = false;
                            do
                            {
                                if (readtext.Count != 0)
                                {
                                    for (var i = 0; i <= readtext.Count - 1; i++)
                                    {
                                        string[] buf;
                                        buf = readtext[i].Split(',');

                                        if (buf[num] == value)

                                        {
                                            numdelete++;
                                            readtext.RemoveAt(i);
                                            repeat = true;
                                            if (allornot == false)
                                            {
                                                repeat = false;
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            repeat = false;

                                        }

                                    }
                                }
                                else { repeat = false; }
                            }
                            while (repeat);
                            Console.WriteLine();

                            center_text("Был(-и) удален(-ы) " + numdelete + " схем(-ы)");
                            Console.WriteLine();

                            StreamWriter file = new StreamWriter("placement_scheme.txt", false);

                            for (var i = 0; i <= readtext.Count - 1; i++)
                            {
                                file.WriteLine(readtext[i]);
                            }
                            file.Close();

                            Console.WriteLine();
                            Console.WriteLine();

                            center_text("Нажмите любую клавишу, чтобы перейти обратно...");
                            Console.ReadKey();
                            break;
                        }

                    case ConsoleKey.D4:

                        {

                            try
                            {
                                Console.Clear();
                                                                                                placement_schemes.Clear();

                                full_line_text("─");
                                center_text("В Ы С Т А В К А  >  С Х Е М Ы  >  С О Р Т И Р О В К А  С Х Е М");
                                Console.WriteLine();

                                full_line_text("─");
                                Console.WriteLine();

                                center_text("Здесь вы можете отсортировать список всех схем размещения в нужном вам порядке.");

                                StreamReader f = new StreamReader("placement_scheme.txt");
                                string s;
                                string[] buf;
                                while ((s = f.ReadLine()) != null)
                                {
                                    buf = s.Split(',');
                                    Placement_scheme placement_scheme = new Placement_scheme();
                                    
                                        for (int i = 0; i < buf.Length; ++i)
                                        {


                                            switch (i)
                                            {
                                                case 0:
                                                    {
                                                        foreach (var x in halls)
                                                        {
                                                            if (x.number == int.Parse(buf[i]))
                                                            {
                                                                placement_scheme.hall = x;

                                                            }
                                                        }
                                                        break;
                                                    }
                                                case 1:
                                                    {
                                                        foreach (var x in exhibits)
                                                        {
                                                            if (x.code == int.Parse(buf[i]))
                                                            {
                                                                placement_scheme.exhibit = x;

                                                            }
                                                        }
                                                        break;
                                                    }
                                                case 2:
                                                    {
                                                        placement_scheme.date_of_beggining = DateTime.ParseExact(buf[i], "yyyy-MM-dd HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                                                        break;
                                                    }
                                                case 3:
                                                    {
                                                        placement_scheme.date_of_end = DateTime.ParseExact(buf[i], "yyyy-MM-dd HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                                                        break;
                                                    }
                                                
                                  
                                        }
                                    }
                                    placement_schemes.Add(placement_scheme);


                                }


                                Console.WriteLine();
                                                                                                                                                center_text("Параметры схем: номер зала, код экспоната, дата начала, дата окончания");

                                Console.WriteLine();
                                IEnumerable<Placement_scheme> newlist = placement_schemes;

                                bool check = true;
                                while (check == true)
                                {
                                    Console.Write("Введите параметр для сортировки списка схем размещения: ");
                                    string parameter = Console.ReadLine().ToLower();
                                    switch (parameter)
                                    {
                                        case "номер зала":
                                            {

                                                placement_schemes.Sort(Placement_scheme.HallNumber);
                                                check = false;
                                                break;
                                            }
                                        case "код экспоната":
                                            {
                                                placement_schemes.Sort(Placement_scheme.ExhibitCode);

                                                check = false;
                                                break;
                                            }
                                        case "дата начала":
                                            {
                                                placement_schemes.Sort(Placement_scheme.BeginningDate);
                                                check = false;
                                                break;
                                            }
                                        case "дата окончания":
                                            {
                                                placement_schemes.Sort(Placement_scheme.EndDate);
                                                check = false;
                                                break;
                                            }
                                        default:
                                            {
                                                right_text("Ошибка! Попробуйте ещё раз!");
                                                break;
                                            }
                                    }
                                }
                                check = true;

                                while (check == true)
                                {
                                    Console.Write("Сортировать от меньшего к большему (Да/Наоборот): ");
                                    string parameter = Console.ReadLine().ToLower();
                                    switch (parameter)
                                    {
                                        case "да":
                                            {
                                                check = false;
                                                break;
                                            }
                                        case "наоборот":
                                            {
                                                newlist = newlist.Reverse();
                                                check = false;
                                                break;
                                            }

                                        default:
                                            {
                                                right_text("Ошибка! Попробуйте ещё раз!");
                                                break;
                                            }
                                    }
                                }

                                Console.WriteLine();
                                showPlacementSchemes(newlist);





                                Console.WriteLine();
                                center_text("Нажмите любую клавишу, чтобы перейти обратно...");
                                Console.ReadKey();
                                placement_schemes.Clear();
                                f.Close();

                            }
                            catch (FileNotFoundException e)
                            {
                                Console.WriteLine(e.Message);
                                Console.WriteLine("Проверьте правильность имени файла!");
                                return;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Error:" + e.Message);
                                return;
                            }
                            break;


                        }
                    case ConsoleKey.D5:
                        {

                            try
                            {
                                Console.Clear();
                                                                placement_schemes.Clear();

                                full_line_text("─");
                                center_text("В Ы С Т А В К А  >  С Х Е М Ы  >  Ф И Л Ь Т Р А Ц И Я  С Х Е М");
                                Console.WriteLine();

                                full_line_text("─");
                                Console.WriteLine();

                                center_text("Здесь вы можете отфильтровать список всех залов по нужному вам значению.");

                                   StreamReader f = new StreamReader("placement_scheme.txt");
                                string s;
                                string[] buf;
                                
                                while ((s = f.ReadLine()) != null)
                                {
                                    buf = s.Split(',');
                                    Placement_scheme placement_scheme = new Placement_scheme();
                                    for (int j = 0; j <= 4; ++j)
                                    {
                                        for (int i = 0; i < buf.Length; ++i)
                                        {


                                            switch (i)
                                            {
                                                case 0:
                                                    {
                                                        var y = int.Parse(buf[i]);
                                                        foreach (var x in halls)

                                                        {
                                                            if (x.number == y)
                                                            {
                                                                placement_scheme.hall = x;
                                                            }
                                                        }
                                                        break;


                                                    }
                                                case 1:
                                                    {

                                                        var y = int.Parse(buf[i]);
                                                        foreach (var x in exhibits)

                                                        {
                                                            if (x.code == y)
                                                            {
                                                                placement_scheme.exhibit = x;
                                                            }
                                                        }
                                                        break;


                                                    }
                                                case 2:
                                                    {

                                                        placement_scheme.date_of_beggining = DateTime.ParseExact(buf[i], "yyyy-MM-dd HH:mm",
                                        System.Globalization.CultureInfo.InvariantCulture);

                                                        break;
                                                    }
                                                case 3:
                                                    {

                                                        placement_scheme.date_of_end = DateTime.ParseExact(buf[i], "yyyy-MM-dd HH:mm",
                                      System.Globalization.CultureInfo.InvariantCulture);

                                                        break;
                                                    }

                                            }
                                        }
                                    }
                                    placement_schemes.Add(placement_scheme);




                                }


                                Console.WriteLine();
                                                                                                                                                center_text("Параметры схем: номер зала, код экспоната, дата начала, дата окончания");

                                Console.WriteLine();
                                IEnumerable<Placement_scheme> newlist = placement_schemes;
                                string filtr = "";
                                bool check = true;
                                while (check == true)
                                {
                                    Console.Write("Введите параметр для фильтрации списка залов: ");
                                    filtr = Console.ReadLine().ToLower();
                                    switch (filtr)
                                    {
                                        case "номер зала":
                                            {
                                                filtr = "number";

                                                check = false;
                                                break;
                                            }
                                        case "код экспоната":
                                            {
                                                filtr = "code";

                                                check = false;
                                                break;
                                            }
                                        case "дата начала":
                                            {
                                                filtr = "date_of_beginning";

                                                check = false;
                                                break;
                                            }
                                        case "дата окончания":
                                            {
                                                filtr = "date_of_end";

                                                check = false;
                                                break;
                                            }
                                        default:
                                            {

                                                right_text("Ошибка! Попробуйте ещё раз!");

                                                break;
                                            }
                                    }
                                }


                                Console.Write("Записи залов с каким значением параметра фильтрации нужно вывести: ");
                                string parameter = Console.ReadLine();

                                

                                switch (filtr)
                                {
                                    case "number":
                                        {
                                            newlist = placement_schemes.Where(p => p.hall.number == int.Parse(parameter));
                                            break;
                                        }
                                    case "code":
                                        {
                                            newlist = placement_schemes.Where(p => p.exhibit.code == int.Parse(parameter));
                                            break;
                                        }
                                    case "date_of_end":
                                        {
                                            newlist = placement_schemes.Where(p => p.date_of_end == DateTime.Parse(parameter));
                                            break;
                                        }
                                    case "date_of_beginning":
                                        {
                                            newlist = placement_schemes.Where(p => p.date_of_beggining ==  DateTime.Parse(parameter));
                                            break;
                                        }
                                 
                                }

                                Console.WriteLine();
                                showPlacementSchemes(newlist);
                                placement_schemes.Clear();
                                Console.WriteLine();
                                center_text("Нажмите любую клавишу, чтобы перейти обратно...");
                                Console.ReadKey();
                                f.Close();
                            }
                            catch (FileNotFoundException e)
                            {
                                Console.WriteLine(e.Message);
                                Console.WriteLine("Проверьте правильность имени файла!");
                                return;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Error:" + e.Message);
                                return;
                            }
                            break;




                        }
                }

            }

        }
        static void showHalls(dynamic halls)
        {

            foreach (var hallprint in halls)
            {
                center_text("ЗАЛ " + hallprint.number);
                center_text("‹‹ " + hallprint.name.ToUpper() + " ››");
                center_text("─────────────────────────");
                center_left_text("Площадь: " + hallprint.square + " кв.м");
                center_left_text("Смотритель: " + hallprint.caretaker);
                center_left_text("Этаж: " + hallprint.floor);
                if (hallprint.status)
                {
                    center_left_text("Статус: открыт");

                }
                else
                {
                    center_left_text("Статус: закрыт");

                }
                Console.WriteLine();
            }

        }
        static void showExhibits(IEnumerable <Exhibit> exhibits)
        {

            foreach (var exhibitprint in exhibits)
            {
                
                    center_text("ЭКСПОНАТ " + exhibitprint.code);
                    center_text("‹‹ " + exhibitprint.name.ToUpper() + " ››");
                    center_text("─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─");
                    center_left_text("Цена: " + exhibitprint.cost + " $");
                    center_left_text("Владелец: " + exhibitprint.owner);
                    Console.WriteLine();
                
                
            }

        }
        static void showPlacementSchemes(dynamic placement_schemes)
        {
            foreach (var placementschemeprint in placement_schemes)
            {
                center_text("СХЕМА РАЗМЕЩЕНИЯ");
                center_text("─────────────────────────");
                if (placementschemeprint.hall != null)
                {

                    center_left_text("Название зала: " + placementschemeprint.hall.name+" (номер " + placementschemeprint.hall.number + ")");
                }

                if (placementschemeprint.exhibit != null)
                {

                    center_left_text("Название экспоната: " + placementschemeprint.exhibit.name+" (код " + placementschemeprint.exhibit.code + ")");

                }





                center_left_text("Дата начала: " + (placementschemeprint.date_of_beggining).ToLongDateString());
                center_left_text("Дата окончания: " + (placementschemeprint.date_of_end).ToLongDateString());
                DateTime date1 = placementschemeprint.date_of_end;
DateTime date2 = placementschemeprint.date_of_beggining;
                var span =(date1.Subtract(date2)).Days;
                center_left_text("Продолжительность: " + span + " д.");
                  


                Console.WriteLine();
            }

        }
        static void main_menu(List<Hall> halls, List<Placement_scheme> placement_schemes, List<Exhibit> exhibits)
        {

            StreamReader f = new StreamReader("halls.txt");
            string s;
            string[] buf;
            while ((s = f.ReadLine()) != null)
            {
                buf = s.Split(',');
                Hall hall = new Hall();
                for (int j = 0; j <= 4; ++j)
                {
                    for (int i = 0; i < buf.Length; ++i)
                    {


                        switch (i)
                        {
                            case 0:
                                {
                                    hall.number = int.Parse(buf[i]);
                                    break;
                                }
                            case 1:
                                {
                                    hall.square = int.Parse(buf[i]);
                                    break;
                                }
                            case 2:
                                {
                                    hall.caretaker = buf[i];
                                    break;
                                }
                            case 3:
                                {
                                    hall.floor = int.Parse(buf[i]);
                                    break;
                                }
                            case 4:
                                {
                                    hall.status = Convert.ToBoolean(buf[i]);
                                    break;
                                }
                            case 5:
                                {
                                    hall.name = buf[i];
                                    break;
                                }
                        }
                    }
                }
                halls.Add(hall);


            }

            f.Close();


            bool isItMenu = true;
            while (isItMenu)
            {

                Console.Clear();
                Console.WindowWidth = 100;
                Console.BufferWidth = 100;
                Console.WindowHeight = 35;
                Console.BufferHeight = 140;




                full_line_text("─");
                center_text("В Ы С Т А В К А");
                Console.WriteLine();

                full_line_text("─");
                Console.WriteLine();
                center_text("Доступные опции:");

                center_text("Выход (0) * Залы (1) * Экспонаты (2) * Схемы размещения (3) * Оформление (4)");
                Console.WriteLine();

                center_text("ДОБРО ПОЖАЛОВАТЬ");
                center_text("Здесь вы можете управлять выставкой и её компонентами.");
                center_text("Нажмите на клавишу, соответствующую номеру нужной вам опции...");
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D0:
                        {
                            isItMenu = false;
                            return;
                        }
                    case ConsoleKey.D1:
                        {
                            hall_option(halls);
                            break;
                        }
                    case ConsoleKey.D2:
                        {
                            exhibit_option(exhibits);

                            break;
                        }
                    case ConsoleKey.D3:
                        {
                            placement_scheme_option(placement_schemes, halls, exhibits);
                            break;
                        }
                    case ConsoleKey.D4:
                        {
                            style_option();
                            break;
                        }
                }

            }

        }
        static void center_text(string line)
        {
            int centerX = (Console.WindowWidth / 2) - (line.Length / 2);
            Console.SetCursorPosition(centerX, Console.CursorTop);
            Console.Write(line);
            Console.SetCursorPosition(0, Console.CursorTop + 1);
        }
        static void right_text(string line)
        {
            int rightX = (Console.WindowWidth - line.Length);
            Console.SetCursorPosition(rightX, Console.CursorTop - 1);
            Console.Write(line);
            Console.SetCursorPosition(0, Console.CursorTop);
        }

        static void center_left_text(string line)
        {
            int centerX = (Console.WindowWidth / 2 - 12);
            Console.SetCursorPosition(centerX, Console.CursorTop);
            Console.Write(line);
            Console.SetCursorPosition(0, Console.CursorTop + 1);
        }
        static void full_line_text(string line)
        {
            Console.WriteLine(String.Concat(Enumerable.Repeat(line, Console.WindowWidth)));
        }

        static void Main(string[] args)

        {
            List<Hall> halls = new List<Hall>();
            List<Placement_scheme> placement_schemes = new List<Placement_scheme>();
            List<Exhibit> exhibits = new List<Exhibit>();

            Console.Title = "Exhibition";
            var hWnd = FindWindow(null, Console.Title);
            var wndRect = new RECT();
            GetWindowRect(hWnd, out wndRect);
            var cWidth = wndRect.Right - wndRect.Left;
            var cHeight = wndRect.Bottom - wndRect.Top;
            var SWP_NOSIZE = 0x1;
            var HWND_TOPMOST = -1;
            var Width = 1920;
            var Height = 1000;
            SetWindowPos(hWnd, HWND_TOPMOST, Width / 2 - cWidth / 2, Height / 2 - cHeight / 2, 0, 0, SWP_NOSIZE);

            main_menu(halls, placement_schemes, exhibits);
        }
    }





}