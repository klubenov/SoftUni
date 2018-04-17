using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Family
{
    private List<Person> members;

    public List<Person> Members
    {
        get { return this.members; }
        set { this.members = value; }
    }

    public Family()
    {
        this.members = new List<Person>();
    }

    public void AddMember(Person member)
    {
        this.members.Add(member);
    }

    public Person GetOldestMember()
    {
        return this.members.OrderByDescending(a => a.Age).First();
    }

    public List<Person> OlderThan30List()
    {
        return this.members.Where(a => a.Age > 30).OrderBy(n=>n.Name).ToList();
    }
}

