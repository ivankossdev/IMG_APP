using System.Text;
namespace img_app;

class Program
{
    static void Main(string[] args)
    {
        ImageBW_PBM imagePBM = new("imageBW_84x48");
        Console.WriteLine(imagePBM.Name);
        imagePBM.Create(84, 48);
    }
}
