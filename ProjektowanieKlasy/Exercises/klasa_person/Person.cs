using System;
using System.Text.RegularExpressions;

namespace ProjektowanieKlasy.Exercises.klasa_person;

public class Person
{
    private string _firstName;
    private string _familyName;
    private DateTime _birthday;

    public Person(string familyName, string firstName, DateTime birthday)
    {
        FamilyName = familyName;
        FirstName = firstName;
        Birthday = birthday;
    }

    public string FamilyName
    {
        get => _familyName;
        set
        {
            string val = value?.Trim();
            string pattern = @"^\p{Lu}\p{Ll}{1,}(-\p{Lu}\p{Ll}{1,})?$";

            if (string.IsNullOrEmpty(val) || !Regex.IsMatch(val, pattern))
            {
                throw new ArgumentException("Incorrect data for FamilyName");
            }

            _familyName = val;
        }
    }
    
    public string FirstName
    {
        get => _firstName;
        set
        {
            string val = value?.Trim();
            string pattern = @"^\p{Lu}\p{Ll}{1,}$";

            if (string.IsNullOrEmpty(val) || !Regex.IsMatch(val, pattern))
            {
                throw new ArgumentException("Incorrect data for FirstName");
            }

            _firstName = val;
        }
    }

    public DateTime Birthday
    {
        get => _birthday;
        set
        {
            if (value.Date > DateTime.Now.Date)
            {
                throw new ArgumentException("Incorrect data for Birthday");
            }
            _birthday = value;
        }
    }

    public override string ToString()
    {
        return $"{FirstName} {FamilyName} ({Birthday:yyyy-MM-dd})";
    }
}