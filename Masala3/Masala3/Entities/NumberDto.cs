namespace Masala3.Entities
{
    public class NumberDto
    {
        [Validations.NumberFromInput]
        public string NumberFromInput { get; set; }
    }
}
