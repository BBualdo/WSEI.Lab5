using System;
using System.Linq;

namespace DefiniowanieKlasDziedziczenie.Exercises;

public class Person {
    private string _firstName;
    public string FirstName {
        get => _firstName;
        protected set => _firstName = VerifyName(value);
    }

    private string _familyName;
    public string FamilyName {
        get => _familyName;
        protected set => _familyName = VerifyName(value);
    }

    protected int _age;
    public virtual int Age {
        get => _age;
        protected set {
            if (value < 0) throw new ArgumentException("Age must be positive!");
            _age = value;
        }
    }

    public Person(string firstName, string familyName, int age) {
        FirstName = firstName;
        FamilyName = familyName;
        Age = age;
    }

    public void modifyFirstName(string newFirstName) {
        FirstName = newFirstName;
    }

    public void modifyFamilyName(string newFamilyName) {
        FamilyName = newFamilyName;
    }

    public void modifyAge(int newAge) {
        Age = newAge;
    }

    public override string ToString() {
        return $"{_firstName} {_familyName} ({_age})";
    }

    private string VerifyName(string name) {
        string result = name.Trim();
        result = ClearWhiteSpaces(result);
        result = Capitalize(result);
        if (string.IsNullOrEmpty(result) || !result.All(c => char.IsLetter(c))) throw new ArgumentException("Wrong name!");

        return result;
    }

    private string Capitalize(string str) {
        if (string.IsNullOrEmpty(str)) return "";
        return char.ToUpper(str[0]) + str.Substring(1).ToLower();
    }

    private string ClearWhiteSpaces(string str) {
        string newStr = "";

        foreach (char c in str) {
            if (!char.IsWhiteSpace(c)) newStr += c;
        }
        
        return newStr;
    }
}

public class Child : Person {
    public override int Age {
        get => _age;
        protected set {
            if (value > 15) throw new ArgumentException("Child’s age must be less than 15!");
            base.Age = value;
        }
    }

    public Person Father { get; set; }
    public Person Mother { get; set; }
    
    public Child(string firstName, string familyName, int age, Person father = null, Person mother = null): base(firstName, familyName, age) {
        Father = father;
        Mother = mother;
    }
    
    public override string ToString() {
        string motherData = "mother: " + (Mother == null ? "No data" : Mother.ToString());
        string fatherData = "father: " + (Father == null ? "No data" : Father.ToString());
        return $"{base.ToString()}\n{motherData}\n{fatherData}";
    }
}