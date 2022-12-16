namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            // Крестики-нолики:
            /*  TO-DO:
             *  Исправить ввод - DONE;
             *  Сделать определение победителя - DONE;
             *  Вывод победителей - DONE.
             */
            short cells_x;
            short cells_y;
            short min_win;
            short cell_x = 0;
            short cell_y = 0;
            short type;
            string? temp;

            // 1 - square, 2 - rectangle, 3 - circle [IN PROGRESS].
            do
            {
                Console.Write("Введите тип поля: ");
                temp = Console.ReadLine();
                if (temp != "1" && temp != "2" && temp != "3")
                {
                    Console.WriteLine("Ошибка: Неправильный тип поля!");
                }
            }
            while (temp != "1" && temp != "2" && temp != "3");
            type = Convert.ToInt16(temp);

            if (type == 1)
            {
                do
                {
                    Console.Write("Введите кол-во клеток: ");
                    temp = Console.ReadLine();
                    if (!short.TryParse(temp, out var aaa))
                    {
                        Console.WriteLine("Ошибка: Некорректное или слишком большое значение!");
                    }
                    else if (Convert.ToInt16(temp) < 3)
                    {
                        Console.WriteLine("Ошибка: Слишком маленькое значение!");
                    }
                }
                while (!short.TryParse(temp, out var bbb) || Convert.ToInt16(temp) < 3);
                cells_x = Convert.ToInt16(temp);
                cells_y = cells_x;
            }
            else
            {
                do
                {
                    Console.Write("Введите кол-во клеток по горизонтали: ");
                    temp = Console.ReadLine();
                    if (!short.TryParse(temp, out var aaa))
                    {
                        Console.WriteLine("Ошибка: Некорректное или слишком большое значение!");
                    }
                    else if (Convert.ToInt16(temp) < 3)
                    {
                        Console.WriteLine("Ошибка: Слишком маленькое значение!");
                    }
                }
                while (!short.TryParse(temp, out var bbb) || Convert.ToInt16(temp) < 3);
                cells_x = Convert.ToInt16(temp);
                do
                {
                    Console.Write("Введите кол-во клеток по вертикали: ");
                    temp = Console.ReadLine();
                    if (!short.TryParse(temp, out var aaa))
                    {
                        Console.WriteLine("Ошибка: Некорректное или слишком большое значение!");
                    }
                    else if (Convert.ToInt16(temp) < 3)
                    {
                        Console.WriteLine("Ошибка: Слишком маленькое значение!");
                    }
                }
                while (!short.TryParse(temp, out var bbb) || Convert.ToInt16(temp) < 3);
                cells_y = Convert.ToInt16(temp);
            }

            do
            {
                do
                {
                    Console.Write("Введите кол-во клеток в линии: ");
                    temp = Console.ReadLine();
                    if (!short.TryParse(temp, out var aaa))
                    {
                        Console.WriteLine("Ошибка: Некорректное или слишком большое значение!");
                    }
                }
                while (!short.TryParse(temp, out var bbb));

                min_win = Convert.ToInt16(temp);
                if (min_win > cells_x || min_win > cells_y || min_win < 3)
                {
                    Console.WriteLine("Ошибка: Кол-во клеток должно быть >= 3, а также <= клеткам по вертикали и горизонтали!");
                }
            }
            while (min_win > cells_x || min_win > cells_y || min_win < 3);

            char[,] squares = new char[cells_x, cells_y];
            for (int j = 0; j < cells_y; j++)
            {
                for (int i = 0; i < cells_x; i++)
                {
                    squares[i, j] = ' ';
                }
            }

            for (int j = 0; j < squares.GetLength(1); j++)
            {
                for (int i = 0; i < squares.GetLength(0) * 4 + 1; i++) Console.Write("─");
                Console.WriteLine("");

                Console.Write("| ");
                for (int i = 0; i < squares.GetLength(0); i++)
                {
                    Console.Write(squares[i, j] + " | ");
                }
                Console.WriteLine("");
            }
            for (int i = 0; i < squares.GetLength(0) * 4 + 1; i++) Console.Write("─");
            Console.WriteLine("");

            ushort register = 0;
            //ushort current_player = 0;
            ushort d1_matches;
            ushort d2_matches;
            ushort x_matches;
            ushort y_matches;

            Console.WriteLine("");
            while (register < cells_x * cells_y)
            {
                d1_matches = 1;
                d2_matches = 1;
                x_matches = 1;
                y_matches = 1;

                Console.WriteLine(register % 2 == 0 ? "Ход крестиков:" : "Ход ноликов:");
                //Console.WriteLine();
                //if (register % 2 == 0)
                //{
                //    Console.WriteLine("Ход крестиков:");
                //}
                //else
                //{
                //    Console.WriteLine("Ход ноликов:");
                //}

                do
                {
                    Console.Write("Укажите X-координату: ");
                    temp = Console.ReadLine();
                    if (short.TryParse(temp, out var aaa))
                    {
                        cell_x = Convert.ToInt16(temp);
                        if (cell_x > cells_x || cell_x < 1)
                        {
                            Console.WriteLine("Ошибка: Клетка не должна выходить за предел поля!");
                            Console.WriteLine($"Размер вашего поля: {cells_x}x{cells_y}");
                        }
                    }
                }
                while (!short.TryParse(temp, out var bbb) || Convert.ToInt16(temp) > cells_x || Convert.ToInt16(temp) < 1);
                do
                {
                    Console.Write("Укажите Y-координату: ");
                    temp = Console.ReadLine();
                    if (short.TryParse(temp, out var aaa))
                    {
                        cell_y = Convert.ToInt16(temp);
                        if (cell_y > cells_y || cell_y < 1)
                        {
                            Console.WriteLine("Ошибка: Клетка не должна выходить за предел поля!");
                            Console.WriteLine($"Размер вашего поля: {cells_x}x{cells_y}");
                        }
                    }
                }
                while (!short.TryParse(temp, out var bbb) || Convert.ToInt16(temp) > cells_y || Convert.ToInt16(temp) < 1);

                if (register % 2 == 0)
                {
                    if (squares[cell_x - 1, cell_y - 1] == ' ')
                    {
                        squares[cell_x - 1, cell_y - 1] = 'X';
                    }
                    else
                    {
                        Console.WriteLine("Клетка занята! Выберите другую!");
                        continue;
                    }
                }
                else
                {
                    if (squares[cell_x - 1, cell_y - 1] == ' ')
                    {
                        squares[cell_x - 1, cell_y - 1] = 'O';
                    }
                    else
                    {
                        Console.WriteLine("Клетка занята! Выберите другую!");
                        continue;
                    }
                }

                for (int j = 0; j < squares.GetLength(1); j++)
                {
                    for (int i = 0; i < squares.GetLength(0) * 4 + 1; i++) Console.Write("─");
                    Console.WriteLine("");

                    Console.Write("| ");
                    for (int i = 0; i < squares.GetLength(0); i++)
                    {
                        Console.Write(squares[i, j] + " | ");
                    }
                    Console.WriteLine("");
                }
                for (int i = 0; i < squares.GetLength(0) * 4 + 1; i++) Console.Write("─");
                Console.WriteLine("");

                for (int x = cell_x - 2; x <= cell_x; x++)
                {
                    for (int y = cell_y - 2; y <= cell_y; y++)
                    {
                        if (x > -1 && y > -1 && x < cells_x && y < cells_y && squares[x, y] == squares[cell_x - 1, cell_y - 1])//&& x != cell_x - 1 && y != cell_y - 1)
                        {
                            for (int i = x, j = y; i > -1 && j > -1 && i < cells_x && j < cells_y && squares[i, j] == squares[cell_x - 1, cell_y - 1]; i -= cell_x - 1 - x, j -= cell_y - 1 - y)
                            {
                                if (cell_x - 1 - x == 1)
                                {
                                    if (cell_y - 1 - y == 1)
                                    {
                                        d1_matches++;
                                    }
                                    else if (cell_y - 1 - y == -1)
                                    {
                                        d2_matches++;
                                    }
                                    else
                                    {
                                        x_matches++;
                                    }
                                }
                                else if (cell_x - 1 - x == -1)
                                {
                                    if (cell_y - 1 - y == 1)
                                    {
                                        d2_matches++;
                                    }
                                    else if (cell_y - 1 - y == -1)
                                    {
                                        d1_matches++;
                                    }
                                    else
                                    {
                                        x_matches++;
                                    }
                                }
                                else
                                {
                                    if (Math.Abs(cell_y - 1 - y) == 1)
                                    {
                                        y_matches++;
                                    }
                                    else
                                    {
                                        j += 1;
                                    }
                                }

                                Console.WriteLine(d1_matches);
                                Console.WriteLine(d2_matches);
                                Console.WriteLine(x_matches);
                                Console.WriteLine(y_matches);

                                if (d1_matches >= min_win || d2_matches >= min_win || x_matches >= min_win || y_matches >= min_win)
                                {
                                    Console.WriteLine("Победитель - " + squares[cell_x - 1, cell_y - 1]);
                                    return;
                                }
                            }
                        }
                    }
                }
                register++;
            }
            Console.WriteLine("Ничья!");
            return;
        }
    }
}