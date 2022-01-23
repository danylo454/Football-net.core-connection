using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Football.Models;

namespace Football.Date
{
    public class FootballRepository
    {
        private static void Print(Models.FootbalTeam football)
        {
            if (football != null)
            {
                Console.WriteLine(new string('=', 30));
                Console.WriteLine($"Id Team {{{football.Id}}}\n" +
                    $"Name Team {{{football.NameTeam}}}\n" +
                    $"City Team {{{football.City}}}\n" +
                    $"Count Won {{{football.CountWon}}}\n" +
                    $"Count Draw {{{football.CountDraw}}}\n" +
                    $"Count Lose {{{football.CountLose}}}\n" +
                    $"Count Heads Goals {{{football.CountHeadsGoals}}}\n" +
                    $"Count Missed Goals {{{football.CountMissedGoals}}}");
            }
            else
            {
                Console.WriteLine("Error!!!");
            }
        }
        public static void Menu()
        {
            int exit = -1;
            do
            {
                Console.Write("1)Отображение команды с самым большим количеством побед\n" +
                    "2)Отображение команды с самым большим количеством поражений\n" +
                    "3)Отображение команды с самым большим количеством ничьих\n" +
                    "4)Отображение команды с самым большим количеством забитых голов\n" +
                    "5)Отображение команды с самым большим количеством пропущенных голов\n" +
                    "6)Добавление новой команды. Перед добавлением нужно проверить не существует ли уже такая команда\n" +
                    "7)Изменение данных существующей команды. Пользователь может изменить любой параметр команды\n" +
                    "8)Удаление команды. Поиск удаляемой команды производится по названию и городу \n Перед удалением приложение должно спросить пользователя нужно ли удалять команду.\n" +
                    "0)Exit\n" +
                    "Enter: ");
                exit = int.Parse(Console.ReadLine());
                switch (exit)
                {
                    case 1: { Console.Clear(); ShowTeamBigCountWon(); break; }
                    case 2: { Console.Clear(); ShowBigLose(); break; }
                    case 3: { Console.Clear(); ShowBigDraw(); break; }
                    case 4: { Console.Clear(); ShowBigCountHeadsGoals(); break; }
                    case 5: { Console.Clear(); ShowBigCountMissedGoals(); break; }
                    case 6: { Console.Clear(); AddTeam(); break; }
                    case 7: { Console.Clear(); UpdateTeam(); break; }
                    case 8: { Console.Clear(); DeleteTeam(); break; }
                    default: { Console.Clear(); Console.WriteLine("Error!!!"); break; }
                }
            } while (exit != 0);
        }
        private static void ShowTeamBigCountWon()
        {
            using (AppDbContext context = new AppDbContext())
            {
                var team = (from t in context.Team
                            orderby t.CountWon descending
                            select t).FirstOrDefault();
                Print(team);
            }
        }
        private static void ShowBigLose()
        {
            using (AppDbContext context = new AppDbContext())
            {
                var team = (from t in context.Team
                            orderby t.CountLose descending
                            select t).FirstOrDefault();
                Print(team);
            }
        }
        private static void ShowBigDraw()
        {
            using (AppDbContext context = new AppDbContext())
            {
                var team = (from t in context.Team
                            orderby t.CountDraw descending
                            select t).FirstOrDefault();
                Print(team);
            }
        }
        private static void ShowBigCountHeadsGoals()
        {
            using (AppDbContext context = new AppDbContext())
            {
                var team = (from t in context.Team
                            orderby t.CountHeadsGoals descending
                            select t).FirstOrDefault();
                Print(team);
            }
        }
        private static void ShowBigCountMissedGoals()
        {
            using (AppDbContext context = new AppDbContext())
            {
                var team = (from t in context.Team
                            orderby t.CountMissedGoals descending
                            select t).FirstOrDefault();
                Print(team);
            }
        }
        private static void AddTeam()
        {
            Console.WriteLine(new string('=', 30));
            Console.Write("Enter Name Team: ");
            string nameTeam = Console.ReadLine();
            Console.Write("Enter Name City Team: ");
            string CityTeam = Console.ReadLine();
            Console.Write("Enter Count Won Team: ");
            int countWon = int.Parse(Console.ReadLine());
            Console.Write("Enter Count Draw Team: ");
            int countDraw = int.Parse(Console.ReadLine());
            Console.Write("Enter Count Lose Team: ");
            int countLose = int.Parse(Console.ReadLine());
            Console.Write("Enter Count Goals Scored: ");
            int countHeadsGoals = int.Parse(Console.ReadLine());
            Console.Write("Enter Count Goals Missed: ");
            int countMissedGoals = int.Parse(Console.ReadLine());
            FootbalTeam newTeam = new FootbalTeam
            {
                NameTeam = nameTeam,
                City = CityTeam,
                CountWon = countWon,
                CountDraw = countDraw,
                CountLose = countLose,
                CountHeadsGoals = countHeadsGoals,
                CountMissedGoals = countMissedGoals

            };
            using (AppDbContext context = new AppDbContext())
            {
                bool exist = context.Team.Any(t => t.NameTeam == nameTeam);
                if (exist == true)
                {
                    Console.WriteLine("This team already exists!!!");
                }
                else
                {
                    context.Team.Add(newTeam);
                    context.SaveChanges();
                    Console.Clear();
                    Console.WriteLine($"Team {nameTeam} has been added!!!");
                }
            }
        }
        private static void UpdateTeam()
        {
            Console.Write("Enter Id Team which you want to update: ");
            int idTeampUp = int.Parse(Console.ReadLine());
            using (AppDbContext context = new AppDbContext())
            {
                FootbalTeam team = context.Team.Where(t => t.Id == idTeampUp).FirstOrDefault();
                if (team != null)
                {
                    int input = -1;
                    Console.Clear();
                    Console.Write($"1)Change Name Team\n" +
                        $"2)Change City Team\n" +
                        $"3)Change Count Won Team\n" +
                        $"4)Change Count Draw\n" +
                        $"5)Change Count Lose\n" +
                        $"6)Change Count Heads Goals\n" +
                        $"7)Change Count Missed Goals\n" +
                        $"0)Exit\n" +
                        $"Enter: ");
                    input = int.Parse(Console.ReadLine());
                    switch (input)
                    {
                        case 1:
                            {
                                Console.Write("Enter new name: ");
                                string name = Console.ReadLine();
                                team.NameTeam = name;
                                context.SaveChanges();
                                break;
                            }
                        case 2:
                            {
                                Console.Write("Enter new city: ");
                                string name = Console.ReadLine();
                                team.City = name;
                                context.SaveChanges();
                                break;
                            }
                        case 3:
                            {
                                Console.Write("Enter new count won: ");
                                int name = int.Parse(Console.ReadLine());
                                team.CountWon = name;
                                context.SaveChanges();
                                break;
                            }
                        case 4:
                            {
                                Console.Write("Enter new count Draw: ");
                                int name = int.Parse(Console.ReadLine());
                                team.CountDraw = name;
                                context.SaveChanges();
                                break;
                            }
                        case 5:
                            {
                                Console.Write("Enter new count losse: ");
                                int name = int.Parse(Console.ReadLine());
                                team.CountLose = name;
                                context.SaveChanges();
                                break;
                            }
                        case 6:
                            {
                                Console.Write("Enter new count Heads Goals: ");
                                int name = int.Parse(Console.ReadLine());
                                team.CountHeadsGoals = name;
                                context.SaveChanges();
                                break;
                            }
                        case 7:
                            {
                                Console.Write("Enter new Count Missed Goals: ");
                                int name = int.Parse(Console.ReadLine());
                                team.CountMissedGoals = name;
                                context.SaveChanges();
                                break;
                            }
                        case 0: { Console.Clear(); break; }
                        default: { Console.Clear(); break; }
                    }
                }
                else
                {
                    Console.WriteLine($"Team with id {idTeampUp} not found.");
                }
            }
        }
        private static void DeleteTeam()
        {
            Console.Write("Enter the Name of the Team you want to delete: ");
            string nameTeam = Console.ReadLine();
            Console.Write("Enter the City of the Team you want to delete: ");
            string nameCity = Console.ReadLine();
            using (AppDbContext context = new AppDbContext())
            {
                FootbalTeam team = context.Team.Where(t => t.NameTeam == nameTeam && t.City == nameCity).FirstOrDefault();
                if (team != null)
                {
                    Console.Clear();
                    Console.WriteLine(new string('=', 50));
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("The Сommand Will Be Deleted You Are Sure");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("If Sure Enter");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" Yes ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("If not Sure Enter");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(" No\n ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Enter: ");
                    string coman = null;
                    do
                    {
                         coman = Console.ReadLine();
                        if (coman == "Yes")
                    {
                        Console.Clear();
                        context.Team.Remove(team);
                        context.SaveChanges();
                    }
                    else if (coman == "No")
                    {
                        Console.Clear();
                        Console.WriteLine("The Team was not removed!!!");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Enter Pls \"Yes\" OR \"No\"");
                    }

                    } while (coman != "Yes" || coman != "No");
                }
                else
                {
                    Console.WriteLine($"Team with Name {nameTeam} and City {nameCity} not found.");
                }
            }
        }


    }
}
