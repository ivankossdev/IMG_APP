using System.Text;
namespace img_app;

class Image_BMP : Image
{
    private string _name = "image.bmp";

    public new string Name {
        get => _name;
        set => _name = value + ".bmp";
    }

    public void CreateBMP(int width, int height)
    {
        
    }

    private StringBuilder Header(int width, int height)
    {
        StringBuilder header = new();
        return header;
    }

    private StringBuilder Info()
    {
        StringBuilder info = new();
        return info;
    }
}

