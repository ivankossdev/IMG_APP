namespace img_app;

class RGB_Pixel : Random
{

    private int Generate(int start = 0, int stop = 256)
    {
        if (start >= stop) throw new Exception("start >= stop parameter!!!");
        if (stop > 256) stop = 256;
        if (start < 0) start = 0;
        if (start >= 255) start = 254;
        
        return Next(start, stop);
    }

    public int RedPixel(int start = 0, int stop = 255)
    {
        return Generate(start, stop);
    }

    public int GreenPixel(int start = 0, int stop = 255)
    {
        return Generate(start, stop);
    }

    public int BluePixel(int start = 0, int stop = 255)
    {
        return Generate(start, stop);
    }
}