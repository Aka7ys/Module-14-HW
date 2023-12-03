using System;

class Karta : IComparable<Karta>
{
    public string Mast { get; set; }
    public string Tip { get; set; }

    public Karta(string mast, string tip)
    {
        Mast = mast;
        Tip = tip;
    }

    public int CompareTo(Karta other)
    {
        if (Tip == other.Tip)
        {
            return Mast.CompareTo(other.Mast);
        }
        else
        {
            return Tip.CompareTo(other.Tip);
        }
    }
}
