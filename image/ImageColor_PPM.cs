namespace img_app;

class ImageColor_PPM(string fileName) : Image(fileName){
    private readonly string _name = fileName + ".ppm";

    public new string Name => _name;
}