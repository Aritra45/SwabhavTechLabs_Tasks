namespace MyFirstWwbApi.Model
{
    public class AddEmployeeDto
    {
        public required string Name { get; set; }
        public required string PhoneNumber { get; set; }
        public required string salary { get; set; }
        public bool IsActive { get;}

    }
}
