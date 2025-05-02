
using System.Text;

namespace img_app;

class Program
{
    static void Main(string[] args)
    {
        // test.bmp
        GetInfo test = new GetInfo("test.bmp");
        test.Info();
    }
}
