using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class Program
{

    private List<Person> people = new List<Person>();
    private List<Table> tables = new List<Table>();

    static void Main(string[] args)
    {
        Console.CursorVisible = false;
        bool endApp = false;
        Program program = new Program();
        program.InitTables();

        while (!endApp)
        {
            Console.WriteLine("Выберите действие:\n1. Добавить посетителя\n" +
                "2. Показать информацию о столиках\n3. Завершить программу");

            int choice = int.Parse(Console.ReadLine());
            Console.Clear();

            switch (choice)
            {
                case 1:
                    program.AddVisitor();
                    break;
                case 2:
                    program.ShowTablesInfo();
                    break;
                case 3:
                    endApp = true;
                    break;
                default:
                    Console.WriteLine("Неверный выбор, попробуйте еще раз.");
                    break;
            }
        }
    }

    private void InitTables()
    {
        tables.Add(new Table(1, 4));
        tables.Add(new Table(2, 6));
        tables.Add(new Table(3, 2));
    }

    private void AddVisitor()
    {
        Person person = new Person();
        person.PrintQuastion();
        people.Add(person);
        AssignTable(person);
    }

    private void AssignTable(Person person)
    {
        foreach (var table in tables)
        {
            if (table.FreePlaces > 0)
            {
                table.FreePlaces--;
                Console.WriteLine();
                Console.WriteLine($"Посетителю {person.FirstName} {person.LastName} назначен столик №{table.Number}");
                Console.WriteLine();
                return;
            }
        }
        Console.WriteLine("Извините, все столики заняты.");
    }

    private void ShowTablesInfo()
    {
        Console.WriteLine();
        foreach (var table in tables)
        {
            table.ShowInfo();
        }
        Console.WriteLine();
    }
}

class Person
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public int Age { get; private set; }

    public Person(string firstName, string lastName, int age)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }

    public Person() { }

    public void PrintQuastion()
    {
        Console.Write("Введите имя поситителя: ");
        FirstName = Console.ReadLine();
        Console.Write("Введите фамилию поситителя: ");
        LastName = Console.ReadLine();
        Console.Write("Введите возраст поситителя: ");
        Age = int.Parse(Console.ReadLine());
    }
}
class Table
{
    public int Number { get; private set; }
    public int MaxPlaces { get; private set; }
    public int FreePlaces { get; set; }

    public Table(int number, int maxPlaces)
    {
        Number = number;
        MaxPlaces = maxPlaces;
        FreePlaces = maxPlaces;
    }
    public void ShowInfo()
    {
        Console.WriteLine($"Столик №{Number} имеет {MaxPlaces} мест, из них свободно {FreePlaces}");
    }
}
