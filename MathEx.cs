namespace img_app;

public static class MathEx
{
    public static double GetAngle(uint w, uint h)
    {
        double angle = Math.Atan((double)h / (double)w) * 180 / Math.PI;
        return Math.Round(angle, 2);
    }
    public static double GetRadian(double degrees)
    {
        return Math.Round(Math.PI * degrees / 180.0, 1);  
    }
}