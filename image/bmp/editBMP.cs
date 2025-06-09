namespace img_app;

public class EditBMP (InfoBMP _infoBMP)
{
    private InfoBMP infoBMP = _infoBMP;

    public void Inf()
    {
        Console.WriteLine($"{infoBMP.Width} {infoBMP.LenghtWord} {infoBMP.AppBytes}");
    }
}