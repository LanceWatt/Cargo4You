namespace Domain.Entities
{
    public class Package
    {
        public decimal Weight { get; set; }
        public Dimensions Dimensions { get; set; }
        public decimal VolumeInCubicMeters { get; set; }
        public decimal VolumeInCubicCm { get; set; }

        public int OneMillion { get; } = 1000000;

        public Package(decimal weight, Dimensions dimensions)
        {
            Weight = weight;
            Dimensions = dimensions ?? throw new ArgumentNullException(nameof(dimensions));
            VolumeInCubicCm = dimensions.VolumeInCubicCm;
            VolumeInCubicMeters = dimensions.VolumeInCubicCm / OneMillion;
        }

    }
}