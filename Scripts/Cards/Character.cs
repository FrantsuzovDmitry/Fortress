public class Character : Card2
{
    protected byte _force;
    protected byte _weight;

    public byte Force { get => _force; }
    public byte Weight { get => _weight; }

    public Character(byte force, byte weight, string logoPath)
    {
        _force = force;
        _weight = weight;
        SetCardImage(logoPath);
    }
}
