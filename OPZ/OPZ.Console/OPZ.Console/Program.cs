﻿namespace OPZConsole
{
    using System;
    using System.Globalization;

    class Program
    {
        static void Main(string[] args)
        {
            string function = Drawer.AskFunction("Введите функцию: у= ");
            double step = Drawer.AskValue(1, "Введите шаг: ");
            double start = Drawer.AskValue(2, "Введите начало: ");
            double end = Drawer.AskValue(3, "Введите конец: ");

            Drawer.GiveTable(function, step, start, end);
        }
    }
}
