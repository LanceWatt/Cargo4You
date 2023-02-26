namespace Domain
{
    public class Dimensions
    {
        public double LengthInCm { get; }
        public double WidthInCm { get; }
        public double HeightInCm { get; }
        public decimal VolumeInCubicCm { get; }
        public decimal VolumeInCubicMeters { get; }

        public Dimensions(decimal length, decimal width, decimal height)
        {
            if (length < 0)
                throw new ArgumentException("Length must be greater or equal to 0", nameof(length));
            if (width < 0)
                throw new ArgumentException("Width must be greater or equal to 0", nameof(width));
            if (height < 0)
                throw new ArgumentException("Height must be greater or equal to 0", nameof(height));

            LengthInCm = Convert.ToDouble(length);
            WidthInCm = Convert.ToDouble(width);
            HeightInCm = Convert.ToDouble(height);

            double volumeInCubicCm = LengthInCm * WidthInCm * HeightInCm;
            VolumeInCubicCm = Convert.ToDecimal(volumeInCubicCm);

            // Formula to transform cubic cm into cm:  by dividing by One Million
            VolumeInCubicMeters = VolumeInCubicCm / 1000000;

        }


    }
}