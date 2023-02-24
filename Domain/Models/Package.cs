namespace Domain.Entities
{
    public class Package
    {
        public decimal Weight { get; set; }
        public Dimensions Dimensions { get; set; }
        public decimal Volume { get; set; }

        public Package(decimal weight, Dimensions dimensions)
        {
            Weight = weight;
            Dimensions = dimensions ?? throw new ArgumentNullException(nameof(dimensions));
            Volume = dimensions.Height * dimensions.Length * dimensions.Width;
        }

    }
}