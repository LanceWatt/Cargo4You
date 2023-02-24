namespace Domain
{
    public class Dimensions
    {
        public decimal Length { get; }
        public decimal Width { get; }
        public decimal Height { get; }
        public decimal VolumeInCm { get; }

        public Dimensions(decimal length, decimal width, decimal height)
        {
            if (length < 0)
                throw new ArgumentException("Length must be greater or equal to 0");
            if (width < 0)
                throw new ArgumentException("Width must be greater or equal to 0");
            if (height < 0)
                throw new ArgumentException("Height must be greater or equal to 0");

            Length = length;
            Width = width;
            Height = height;
            VolumeInCm = length * height * width;
        }
    }
}