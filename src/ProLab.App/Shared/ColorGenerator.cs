using System.Drawing;

namespace ProLab.App.Shared;

public class ColorGenerator
{
    public static string GenerateRandomColor()
    {
        var random = new Random();
        var color = Color.FromArgb(
            random.Next(0, 164),
            random.Next(0, 164),
            random.Next(0, 164));

        return $"#{color.R:X2}{color.G:X2}{color.B:X2}";
    }
}
