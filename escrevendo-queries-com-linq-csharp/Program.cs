using System.Collections.Generic;
using Student_Model;
public class Program
{
    private static void Main(string[] args)
    {
        System.Console.WriteLine("Digite um nome: ");
        var name = Console.ReadLine();

        IEnumerable<Student> studentsQuery =
            from student in students
                //where student.Scores[0] > 90 && student.Scores[3] > 20
            where student.Scores[3] < 20
            select student;

        IEnumerable<Student> studentsQuerySearchName =
            from student in students
            where student.First.Equals(name)
            select student;
            
        if (studentsQuerySearchName.Count()!=0)
        {
            foreach (var student in studentsQuerySearchName)
            {
                System.Console.WriteLine("{0}, {1}", student.Last, student.First);
            }
        }
        else
        {
            System.Console.WriteLine("Não possui nenhum aluno com esse nome");
        }

        System.Console.WriteLine("\nAlunos de pontução menor que 20: ");

        foreach (var student in studentsQuery)
        {
            System.Console.WriteLine("{0}, {1}", student.Last, student.First);
        }
    }

    // Create a data source by using a collection initializer.
    static List<Student> students = new List<Student>
        {
            new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores= new List<int> {97, 92, 81, 60}},
            new Student {First="Claire", Last="O'Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
            new Student {First="Sven", Last="Mortensen", ID=113, Scores= new List<int> {88, 94, 65, 91}},
            new Student {First="Cesar", Last="Garcia", ID=114, Scores= new List<int> {97, 89, 85, 82}},
            new Student {First="Debra", Last="Garcia", ID=115, Scores= new List<int> {35, 72, 91, 70}},
            new Student {First="Fadi", Last="Fakhouri", ID=116, Scores= new List<int> {99, 86, 90, 94}},
            new Student {First="Hanying", Last="Feng", ID=117, Scores= new List<int> {93, 92, 80, 87}},
            new Student {First="Hugo", Last="Garcia", ID=118, Scores= new List<int> {92, 90, 83, 78}},
            new Student {First="Lance", Last="Tucker", ID=119, Scores= new List<int> {68, 79, 88, 92}},
            new Student {First="Terry", Last="Adams", ID=120, Scores= new List<int> {99, 82, 81, 79}},
            new Student {First="Eugene", Last="Zabokritski", ID=121, Scores= new List<int> {96, 85, 91, 60}},
            new Student {First="Michael", Last="Tucker", ID=122, Scores= new List<int> {94, 92, 91, 91}},
            new Student {First="Claire", Last="O'Hioa", ID=112, Scores= new List<int> {76, 89, 61, 19}},
        };
}