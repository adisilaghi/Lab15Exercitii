using Lab15Exercitii;

    List<Student> students = new List<Student>
        {
            new Student { Id = 1, FirstName = "Alice", LastName = "Smith", Age = 22, Specialization = Specialization.ComputerScience },
            new Student { Id = 2, FirstName = "Bob", LastName = "Johnson", Age = 19, Specialization = Specialization.Literature },
            new Student { Id = 3, FirstName = "Charlie", LastName = "Brown", Age = 21, Specialization = Specialization.Engineering },
            new Student { Id = 4, FirstName = "David", LastName = "Williams", Age = 20, Specialization = Specialization.Literature },
            new Student { Id = 5, FirstName = "Eve", LastName = "Davis", Age = 18, Specialization = Specialization.ComputerScience },
            new Student { Id = 6, FirstName = "Frank", LastName = "Miller", Age = 25, Specialization = Specialization.Engineering }
        };

    
    Console.WriteLine("// 1. Display the oldest student from Computer Science");
    var oldestCSStudent = students
        .Where(s => s.Specialization == Specialization.ComputerScience)
        .OrderByDescending(s => s.Age)
        .FirstOrDefault();
    Console.WriteLine(oldestCSStudent);

    
    Console.WriteLine("// 2. Display the youngest student in multiple ways");
    var youngestStudent1 = students.OrderBy(s => s.Age).FirstOrDefault();
    var youngestStudent2 = students.Aggregate((s1, s2) => s1.Age < s2.Age ? s1 : s2);
    Console.WriteLine(youngestStudent1);
    Console.WriteLine(youngestStudent2);

    
    Console.WriteLine("// 3. Display all students from Literature in ascending order of age");
    var literatureStudents = students
        .Where(s => s.Specialization == Specialization.Literature)
        .OrderBy(s => s.Age);
    foreach (var student in literatureStudents)
    {
        Console.WriteLine(student);
    }

    
    Console.WriteLine("// 4. Display the first student from Engineering over 20 years old");
    var firstEngineeringStudentOver20 = students
        .Where(s => s.Specialization == Specialization.Engineering && s.Age > 20)
        .FirstOrDefault();
    Console.WriteLine(firstEngineeringStudentOver20);

    
    Console.WriteLine("// 5. Display students with age equal to the average age of all students");
    var averageAge = students.Average(s => s.Age);
    var studentsWithAverageAge = students.Where(s => s.Age == averageAge);
    foreach (var student in studentsWithAverageAge)
    {
        Console.WriteLine(student);
    }

    
    Console.WriteLine("// 6. Display students aged between 18 and 35, ordered by descending age and then alphabetically by last name and first name");
    var filteredStudents = students
        .Where(s => s.Age >= 18 && s.Age <= 35)
        .OrderByDescending(s => s.Age)
        .ThenBy(s => s.LastName)
        .ThenBy(s => s.FirstName);
    foreach (var student in filteredStudents)
    {
        Console.WriteLine(student);
    }

    
    Console.WriteLine("// 7. Display the last student in the list using LINQ");
    var lastStudent = students.LastOrDefault();
    Console.WriteLine(lastStudent);

    
    Console.WriteLine("// 8. Display 'There are minors' if there are students under 18, otherwise 'There are no minors'");
    var minorsExist = students.Any(s => s.Age < 18);
    if (minorsExist)
    {
        Console.WriteLine("There are minors");
    }
    else
    {
        Console.WriteLine("There are no minors");
    }

    
    Console.WriteLine("// 9. Display all students grouped by age using GroupBy");
    var groupedByAge = students.GroupBy(s => s.Age);
    foreach (var group in groupedByAge)
    {
        Console.WriteLine($"Students aged {group.Key}:");
        foreach (var student in group)
        {
            Console.WriteLine(student);
        }
    }
