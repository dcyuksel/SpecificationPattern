using SpecificationPattern;

namespace SpecificationPatternTests.Specifications;
public class ElectiralVehiclesMadeInChinaSpecification : ISpecification<Vehicle>
{
    public bool IsSatisfiedBy(Vehicle vehicle)
    {
        return vehicle.MadeIn == "China" && vehicle.IsElectrical;
    }
}
