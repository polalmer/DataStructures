using CustomTypes;

TestMatrix();

void TestMatrix()
{
    Console.WriteLine("Matrix size:");
    int size = int.Parse(Console.ReadLine() ?? "3");

    Matrix one = new(size);
    one.FillRandom(10);
    one.PrintToConsole();

    Matrix two = new(size);
    two.FillRandom(10);
    two.PrintToConsole();

    Matrix result = one + two;
    result.PrintToConsole();
}
