using CustomTypes;

TestMatrix();

void TestMatrix()
{
    Matrix one = new(3);
    one.FillRandom(10);
    one.PrintToConsole();

    Matrix two = new(3);
    two.FillRandom(10);
    two.PrintToConsole();

    Matrix result = one + two;
    result.PrintToConsole();
}
