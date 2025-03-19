
using ReferenceClassParameter.Model;

internal class Program
{
    public static void TakeParentAsParameter(Parent p)
    {
        p.Show("Welcome");
    }
    private static void Main(string[] args)
    {
        Parent p1 = new Child1();
        Parent p2 = new Child2();
        //p1.Show("Hi");
        //p2.Show("Hello");
        TakeParentAsParameter(p1);
        TakeParentAsParameter(p2);
    }
}