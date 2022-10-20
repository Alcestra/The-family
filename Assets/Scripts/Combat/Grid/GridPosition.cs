public struct GridPosition
{
    public int X;
    public int z;

    public GridPosition(int x,int z)
    {
        this.X = x;
        this.z = z;
    }

    public override string ToString()
    {
        return "x:" + X + "; z:" + z;
    }
}