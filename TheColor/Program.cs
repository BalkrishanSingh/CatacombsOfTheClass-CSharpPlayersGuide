// See https://aka.ms/new-console-template for more information

Color magenta = new Color(255, 0, 255);

Console.WriteLine($"Magenta: {magenta}");
Console.WriteLine($"Purple: {Color.Purple}");

class Color
{
    public byte RedValue { get; }
    public byte GreenValue { get; }
    public byte BlueValue { get; }


    public static Color Black { get; } = new Color(0, 0, 0);
    public static Color White { get; } = new Color(255, 255, 255);
    public static Color Red { get; } = new Color(255, 0, 0);
    public static Color Green { get; } = new Color(0, 128, 0);
    public static Color Blue { get; } = new Color(0, 0, 255);
    public static Color Orange { get; } = new Color(255, 165, 0);
    public static Color Yellow { get; } = new Color(255, 225, 0);
    public static Color Purple { get; } = new Color(128, 0, 128);


    public Color(byte redValue, byte greenValue, byte blueValue)
    {
        RedValue = redValue;
        GreenValue = greenValue;
        BlueValue = blueValue;
    }

    public override string ToString()
    {
        return $"R:{RedValue}, G:{GreenValue}, B:{BlueValue}";
    }
}