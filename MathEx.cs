namespace img_app;

public class MathEx
{
    public static void GetAngle(int w, int h)
    {
        double angle = Math.Atan((double)h / (double)w) * 180 / Math.PI;
        System.Console.WriteLine(angle);
        System.Console.WriteLine(180 - 90 - angle);
        
    }
    // double degrees = 45;
    // double angle = Math.PI * degrees / 180.0;
}