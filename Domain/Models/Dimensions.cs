namespace Domain
{
    public class Dimensions
    {
        public decimal LengthInCm { get; }
        public decimal WidthInCm { get; }
        public decimal HeightHeightInCm { get; }
        public decimal VolumeInCubicCm { get; }
        public decimal VolumeInCubicMeters { get; }

        public Dimensions(decimal length, decimal width, decimal height)
        {
            if (length < 0)
                throw new ArgumentException("Length must be greater or equal to 0");
            if (width < 0)
                throw new ArgumentException("Width must be greater or equal to 0");
            if (height < 0)
                throw new ArgumentException("Height must be greater or equal to 0");

            LengthInCm = length;
            WidthInCm = width;
            HeightHeightInCm = height;
            VolumeInCubicCm = LengthInCm * WidthInCm * HeightHeightInCm;
            VolumeInCubicMeters = VolumeInCubicCm / 1000000;
        }
    }
}