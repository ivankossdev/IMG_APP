using System.Text;
namespace img_app;

class Program
{
    static void Main(string[] args)
    {
        ImagePBM imagePBM = new("image_640x480");
        Console.WriteLine(imagePBM.Name);
        imagePBM.Create(640, 480);
    }
}
