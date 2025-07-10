using System.Text;
namespace img_app;

public class ImagePNG : DataInsertsPNG
{
    private string _name = "image.png";
    public string Name
    {
        get => _name;
        set => _name = value + ".png";
    }

    private const int lenArray = 4 * 16;
    public void Create(int width, int height)
    {
        byte[] res = HeaderFile(width, height);
        byte[] body = Body(ref res);
        File.BinWrite(ref body, Name);
    }
    
    private byte[] HeaderFile(int width, int height)
    {
        byte[] array = new byte[lenArray];

        // 0x89; 0x50; 0x4E; 0x47; 0x0D; 0x0A; 0x1A 0x0A заголовок файла png  
        array[0] = 0x89; array[1] = 0x50; array[2] = 0x4E; array[3] = 0x47;
        array[4] = 0x0D; array[5] = 0x0A; array[6] = 0x1A; array[7] = 0x0A;

        // Размер чанка
        InsertData(0x0d, ref array, 8, 11);
        // IHDR Заголовок изображения 0x49, 0x48, 0x44, 0x52
        byte[] typeHeader = new UTF8Encoding(true).GetBytes("IHDR");
        InsertData(ref typeHeader, ref array, 12, 15);
        // Ширина изображения 
        InsertData((uint)width, ref array, 16, 19);
        // Высота изображения 
        InsertData((uint)height, ref array, 20, 23);
        // Тип сжатия 
        byte[] type = [8, 6];
        InsertData(ref type, ref array, 24, 25);
        return array;
    }
    
    private byte[] Body(ref byte[] array)
    {
        return array;
    }
}