/*
 * Developed by Faridun Berdiev
 * Date: 04.04.2020
 * Second Task
*/
using System;

namespace Task_2
{
    class Employee
    {
        public enum Positions
        {
            Supervisor = 8000,
            Manager = 6000,
            Programmer = 5500,
            Cleaner = 2000
        }
        ///<summary>
        ///Имя сотрудника
        ///</summary>
        public string Name { get; set; } 
        ///<summary>
        ///Фамилия сотрудника
        ///</summary>
        public string Surname { get; set; }
        ///<summary>
        ///Должность и зар-плата сотрудника
        ///</summary>
        public Positions EmployeePosition { get; set; }
        ///<summary>
        ///Стаж работы сотрудника
        ///</summary>
        public int Experience { get; set; }
        ///<summary>
        ///Процент для пенсионого фонда
        ///</summary>
        public double Pension { get; set; }
        ///<summary>
        ///Процент для налоговой
        ///</summary>
        public double Tax { get; set; }
        ///<summary>
        ///Зарплата(К выдаче)
        ///</summary>
        public double SalaryReady { get; set; }
        ///<summary>
        ///Зарплата(Без выдачи)
        ///</summary>
        public double Salary{ get; set; }
        public Employee(string _name, string _surname)
        {
            Name = _name;
            Surname = _surname;
        }

        public double CalculateSalary()
        {
            double results = 0.0f;
            if(Experience > 5) //+ к зарплате от стажа работы
                results += 300;
            else if(Experience > 10)
                results += 600;
            else if(Experience > 15)
                results += 2200;

            Salary = (int)EmployeePosition;
            results += Salary;
            Pension = ((results * 13) / 100); // 13% - Налог
            Tax = (results / 100); // 1% - Пенсионый фонд
            
            results -= (Pension + Tax);
            SalaryReady = results;

            return SalaryReady;
        }

        public string PositionsToString()
        {
            if(EmployeePosition == Positions.Supervisor)
                return "Руководитель";
            else if(EmployeePosition == Positions.Programmer)
                return "Программист";
            else if(EmployeePosition == Positions.Manager)
                return "Менеджер";
            else
                return "Уборщик";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Employee empl = new Employee("Faridun", "Berdiev");
            empl.EmployeePosition = Employee.Positions.Supervisor;
            empl.Experience = 7;
            empl.CalculateSalary();
            Console.WriteLine($"Сотрудник: {empl.Name} {empl.Surname}: \n" + 
            $"Стаж: { empl.Experience }\n" + 
            $"Должность: { empl.PositionsToString() }\n" + 
            $"Зарплата(Без выдачи): { empl.Salary }\n" +
            $"Пенсионый фонд: { empl.Pension }\n" + 
            $"Налог: { empl.Tax }\n" +
            $"Зарплата(К выдаче): { empl.SalaryReady }");
        }
    }
}
