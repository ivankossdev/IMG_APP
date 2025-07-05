using System.IO.Hashing;
// dotnet add package System.IO.Hashing

namespace img_app;

public static class HashHandler
{
    public static string GetCRC32(Crc32 crc32, string path)
    {
        using FileStream fs = System.IO.File.Open(path, FileMode.Open);
        crc32.Append(fs);
        byte[] checkSum = crc32.GetCurrentHash();
        Array.Reverse(checkSum);
        return BitConverter.ToString(checkSum).Replace("-", "").ToLower();
    }
    public static string GetCRC32(Crc32 crc32, Span<byte> b)
    {
        // Span<byte> b = [0, 0, 0, 0, 0];
        crc32.Append(b);
        byte[] checkSum = crc32.GetCurrentHash();
        Array.Reverse(checkSum);
        return BitConverter.ToString(checkSum).Replace("-", "").ToLower();
    }
}