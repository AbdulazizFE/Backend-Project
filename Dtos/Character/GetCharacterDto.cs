namespace Backend_Project.Dtos.Character
{
    public class GetCharacterDto
    {
          public int Id { get; set; }
        public string Name { get; set; } = "Abdulaziz";
        public int HitPoints { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intellingence { get; set; } = 10;
        public RpgClass Class { get; set; } = RpgClass.Knight;
    }
}