using SpecificationPattern;

namespace SpecificationPatternTests.Specifications;
public class DiscountSpecification : ISpecification<Vehicle>
{
    public bool IsSatisfiedBy(Vehicle vehicle)
    {
        return vehicle.Price >= 20000 && vehicle.Year > 2022;
    }
}
