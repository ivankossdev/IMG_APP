namespace img_app;

public class MathEx
{
    public static void GetAngle(int w, int h)
    {
        double angle = Math.Atan((double)h / (double)w) * 180 / Math.PI;
        angle = Math.Round(angle);
        Console.WriteLine(angle);
        Console.WriteLine(180 - 90 - angle);
    }
    // double degrees = 45;
    // double angle = Math.PI * degrees / 180.0;
}