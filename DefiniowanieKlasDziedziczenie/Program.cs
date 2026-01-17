using System;
using DefiniowanieKlasDziedziczenie.Exercises;

/* Test: tworzenie obiektu Child */
try
{
    Person o = new Person(familyName: "Molenda", firstName: "Krzysztof", age: 30);
    Person m = new Person(familyName: "Molenda", firstName: "Ewa", age: 29);
    Child d = new Child(familyName: "Molenda", firstName: "Anna", age: 10, 
        mother: m, father: o);
    Console.WriteLine(d);
}
catch( Exception e)
{
    Console.WriteLine(e.Message);
}