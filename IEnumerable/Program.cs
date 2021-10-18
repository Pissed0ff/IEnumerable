using System;
using System.Collections;

namespace MYIEnumerable
{
    class Program
    {
        static void Main(string[] args)
        {
            Person[] persons = new Person[3]
            {
                new Person("alex","vagner"),
                new Person("vitya", "maloy"),
                new Person("kirill", "selegey")
            };

            People people = new People(persons);
            foreach (var el in people)
            {
                Console.WriteLine(el.FirstName);
            }
        }
    }

    public class Person
    {
        public string FirstName;
        public string LastName;

        public Person(string FName, string LName)
        {
            FirstName = FName;
            LastName = LName;
        }
    }

    public class People : IEnumerable
    {
        public Person[] PeopleArr;
        public People(Person[] arr)
        {
            PeopleArr = new Person[arr.Length];
            for (var i = 0; i < arr.Length; i++)
            {
                PeopleArr[i] = arr[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator) GetEnumerator();
        }
        public PeopleEnum GetEnumerator()
        {
            return new PeopleEnum(PeopleArr);
        }

    }

    public class PeopleEnum : IEnumerator
    {
        public Person[] people;
        int position = -1;

        public PeopleEnum(Person[] list)
        {
            people = list;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public Person Current
        {
            get
            {
                try
                {
                    return people[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
        public bool MoveNext()
        {
            position++;
            return (position < people.Length);
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
