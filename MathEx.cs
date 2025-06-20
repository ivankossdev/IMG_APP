namespace img_app;

public class MathEx
{
    public static void Example()
    {
        Console.WriteLine(
            "This example of trigonometric " +
            "Math.Sin( double ), Math.Cos( double ), and Math.SinCos( double )\n" +
            "generates the following output.\n");
        Console.WriteLine(
            "Convert selected values for X to radians \n" +
            "and evaluate these trigonometric identities:");
        Console.WriteLine("   sin^2(X) + cos^2(X) == 1\n" +
                           "   sin(2 * X) == 2 * sin(X) * cos(X)");
        Console.WriteLine("   cos(2 * X) == cos^2(X) - sin^2(X)");
        Console.WriteLine("   cos(2 * X) == cos^2(X) - sin^2(X)");

        UseSineCosine(15.0);
        UseSineCosine(30.0);
        UseSineCosine(45.0);

        Console.WriteLine(
            "\nConvert selected values for X and Y to radians \n" +
            "and evaluate these trigonometric identities:");
        Console.WriteLine("   sin(X + Y) == sin(X) * cos(Y) + cos(X) * sin(Y)");
        Console.WriteLine("   cos(X + Y) == cos(X) * cos(Y) - sin(X) * sin(Y)");

        UseTwoAngles(15.0, 30.0);
        UseTwoAngles(30.0, 45.0);

        Console.WriteLine(
            "\nWhen you have calls to sin(X) and cos(X) they \n" +
            "can be replaced with a single call to sincos(x):");

        UseCombinedSineCosine(15.0);
        UseCombinedSineCosine(30.0);
        UseCombinedSineCosine(45.0);
    }
    static void UseCombinedSineCosine(double degrees)
    {
        double angle = Math.PI * degrees / 180.0;
        (double sinAngle, double cosAngle) = Math.SinCos(angle);

        // Evaluate sin^2(X) + cos^2(X) == 1.
        Console.WriteLine(
            "\n                           Math.SinCos({0} deg) == ({1:E16}, {2:E16})",
            degrees, sinAngle, cosAngle);
        Console.WriteLine(
            "(double sin, double cos) = Math.SinCos({0} deg)",
            degrees);
        Console.WriteLine(
            "sin^2 + cos^2 == {0:E16}",
            sinAngle * sinAngle + cosAngle * cosAngle);
    }
    static void UseSineCosine(double degrees)
    {
        double angle = Math.PI * degrees / 180.0;
        double sinAngle = Math.Sin(angle);
        double cosAngle = Math.Cos(angle);

        // Evaluate sin^2(X) + cos^2(X) == 1.
        Console.WriteLine(
            "\n                           Math.Sin({0} deg) == {1:E16}\n" +
            "                           Math.Cos({0} deg) == {2:E16}",
            degrees, Math.Sin(angle), Math.Cos(angle));
        Console.WriteLine(
            "(Math.Sin({0} deg))^2 + (Math.Cos({0} deg))^2 == {1:E16}",
            degrees, sinAngle * sinAngle + cosAngle * cosAngle);

        // Evaluate sin(2 * X) == 2 * sin(X) * cos(X).
        Console.WriteLine(
            "                           Math.Sin({0} deg) == {1:E16}",
            2.0 * degrees, Math.Sin(2.0 * angle));
        Console.WriteLine(
            "    2 * Math.Sin({0} deg) * Math.Cos({0} deg) == {1:E16}",
            degrees, 2.0 * sinAngle * cosAngle);

        // Evaluate cos(2 * X) == cos^2(X) - sin^2(X).
        Console.WriteLine(
            "                           Math.Cos({0} deg) == {1:E16}",
            2.0 * degrees, Math.Cos(2.0 * angle));
        Console.WriteLine(
            "(Math.Cos({0} deg))^2 - (Math.Sin({0} deg))^2 == {1:E16}",
            degrees, cosAngle * cosAngle - sinAngle * sinAngle);
    }
        // Evaluate trigonometric identities that are functions of two angles.
    static void UseTwoAngles(double degreesX, double degreesY)
    {
        double  angleX  = Math.PI * degreesX / 180.0;
        double  angleY  = Math.PI * degreesY / 180.0;

        // Evaluate sin(X + Y) == sin(X) * cos(Y) + cos(X) * sin(Y).
        Console.WriteLine(
            "\n        Math.Sin({0} deg) * Math.Cos({1} deg) +\n" +
            "        Math.Cos({0} deg) * Math.Sin({1} deg) == {2:E16}",
            degreesX, degreesY, Math.Sin(angleX) * Math.Cos(angleY) +
            Math.Cos(angleX) * Math.Sin(angleY));
        Console.WriteLine(
            "                           Math.Sin({0} deg) == {1:E16}",
            degreesX + degreesY, Math.Sin(angleX + angleY));

        // Evaluate cos(X + Y) == cos(X) * cos(Y) - sin(X) * sin(Y).
        Console.WriteLine(
            "        Math.Cos({0} deg) * Math.Cos({1} deg) -\n" +
            "        Math.Sin({0} deg) * Math.Sin({1} deg) == {2:E16}",
            degreesX, degreesY, Math.Cos(angleX) * Math.Cos(angleY) -
            Math.Sin(angleX) * Math.Sin(angleY));
        Console.WriteLine(
            "                           Math.Cos({0} deg) == {1:E16}",
            degreesX + degreesY, Math.Cos(angleX + angleY));
    }
}