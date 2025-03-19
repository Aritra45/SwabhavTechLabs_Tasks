using Set;

internal class Program
{
    private static void Main(string[] args)
    {
        Sets sets1 = new Sets(1);
        Sets sets2 = new Sets(2);

        sets1.AddSetElement(1);
        sets1.AddSetElement(2);
        sets1.AddSetElement(3);

        sets1.DisplaySet();

        sets2.AddSetElement(3);
        sets2.AddSetElement(4);
        sets2.AddSetElement(5);

        sets2.DisplaySet();

        SetOp setOp = new SetOp();
        setOp.Union(sets1, sets2);
        setOp.Intersection(sets1, sets2);

        HashSets hashSets = new HashSets();
        hashSets.AddSets(0, sets1);
        hashSets.Display();

        hashSets.AddSets(1, sets2);
        hashSets.Display();
    }
}