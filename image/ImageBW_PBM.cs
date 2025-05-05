using System.Text;
namespace img_app;

class ImageBW_PBM : Image{

    private string _name = "image.pbm";

    public new string Name {
        get => _name;
        set => _name = value + ".pbm";
    }

    public void CreateRandomFile(int width, int height){
        StringBuilder sb = new ("P1\n");
        sb.Append($"{width} {height}\n");

        for(int i = 0; i < height; i++){
            sb.Append($"{RandValue(width)}\n");
        }

        Write(sb.ToString(), Name);
    }

    private string RandValue(int count){
        Random rnd = new();
        StringBuilder randString = new();

        for(int i = 0; i < count; i++){
            randString.Append($"{rnd.Next(0, 2)}");
        }

        return randString.ToString();
    }
}