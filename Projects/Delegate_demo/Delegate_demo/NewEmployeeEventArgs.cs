namespace Delegate_demo
{
    public class NewLeadEventArgs
    {
        public string Name;
        public string Sex;
        public int Age;

        public NewLeadEventArgs(string name, string sex, int age)
        {
            Name = name;
            Sex = sex;
            Age = age;
        }
    }

}