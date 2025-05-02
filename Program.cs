using System.Text;
namespace img_app;

class Program
{
    static void Main(string[] args)
    {
        ImagePBM imagePBM = new ImagePBM("1");
        Console.WriteLine(imagePBM.Path());
        Console.WriteLine(imagePBM.Name);
        imagePBM.Create(4, 4, "1111\n1001\n1111\n1001");
    }
}
