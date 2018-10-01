using System;
using System.Collections;
using System.Linq;
using System.Text;

class Current
{
    public string CompanyName { get; }
    public string TypeOfBusiness { get; }
    public string Website { get; }
    public string ContactName { get; }

    public Current(string CompanyName, string TypeOfBusiness, string Website, string ContactName)
    {
        this.CompanyName = CompanyName;
        this.TypeOfBusiness = TypeOfBusiness;
        this.Website = Website;
        this.ContactName = ContactName;
    }
    public override bool Equals(Object obj)
    {
        if (obj == null || !(obj is Current))
        {

            return false;
        }
        return (this.CompanyName == ((Current)obj).CompanyName);
    }

}

public class TestMain
{
    public static void Main()
    {
        //Console.WriteLine("Hello World");
        Current company1 = new Current("Mindtree", "Software", "www.mindtree.com", "Chaz");
        Current company2 = new Current("Mindtree", "Software", "www.mindtree.com", "Chaz");
        Console.WriteLine();
        if (company1.Equals(company2))
        {
            Console.WriteLine("they are the same");

        }
        else
        {
            Console.WriteLine("they are not the same");
        }
        //account1.storeData(account1);



    }
}

