using System;

public struct GridPosition : IEquatable<GridPosition>
{
    public int X;
    public int z;

    public GridPosition(int x, int z)
    {
        this.X = x;
        this.z = z;
    }

    public override bool Equals(object obj)
    {
        return obj is GridPosition position &&
               X == position.X &&
               z == position.z;
    }

    public bool Equals(GridPosition other)
    {
        throw new NotImplementedException();
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, z);
    }

    public override string ToString()
    {
        return "x:" + X + "; z:" + z;
    }


    public static bool operator == (GridPosition a, GridPosition b)
    {
        return a.X == b.X && a.z == b.z;
    }        
     
    public static bool operator != (GridPosition a, GridPosition b)
    {
        return !(a == b);
    }

    public static GridPosition operator + (GridPosition a, GridPosition b)
    {
        return new GridPosition(a.X + b.X, a.z + b.z); 
    }
    public static GridPosition operator -(GridPosition a, GridPosition b)
    {
        return new GridPosition(a.X - b.X, a.z - b.z);
    }
}