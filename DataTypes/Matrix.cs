namespace CustomTypes;

public class Matrix
{
    private int[,] data;
    private int Size;

    public Matrix(int size)
    {
        Size = size;
        data = new int[size, size];
    }

    public int this[int row, int column]
    {
        get { return data[row, column]; }
        set { data[row, column] = value; }
    }

    public static Matrix operator +(Matrix one, Matrix two)
    {
        if(one.Size != two.Size) throw new Exception("unequal matrixes");

        int size = one.Size;
        Matrix result = new(size);
        for(int y = 0; y < size; y++)
        {
            for(int x = 0; x < size; x++)
            {
                result[x,y] = one[x,y] + two[x,y];
            }
        }
        return result;
    }

    public void FillRandom(int maxValue)
    {
        Random random = new();
        for(int y = 0; y < Size; y++)
        {
            for(int x = 0; x < Size; x++)
            {  
                data[x,y] = random.Next(maxValue);
            }
        }
    }
}