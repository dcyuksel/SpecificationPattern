using FluentAssertions;
using SpecificationPattern.Extensions;
using SpecificationPatternTests.Specifications;

namespace SpecificationPatternTests;

public class VehicleTests
{
    private readonly IReadOnlyList<Vehicle> vehicles =
    [
        new(1, "Toyota", 2023, "Japan", 21500m, true),
        new(2, "Toyota", 2022, "China", 20000m, true),
        new(3, "Toyota", 2021, "France", 19000m, false),
        new(4, "Hyundai", 2023, "Korea", 20000m, true),
        new(5, "Hyundai", 2024, "China", 22000m, true),
        new(6, "Hyundai", 2021, "France", 16000m, false),
    ];

    [Theory]
    [InlineData(1)]
    [InlineData(4)]
    [InlineData(5)]
    public void DiscountableTest(long id)
    {
        var discountables = vehicles.Where(v => new DiscountSpecification().IsSatisfiedBy(v));
        discountables.Any(v => v.Id == id).Should().BeTrue();
    }

    [Theory]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(6)]
    public void NotDiscountableTest(long id)
    {
        var notDiscountables = vehicles.Where(v => new DiscountSpecification().Not().IsSatisfiedBy(v));
        notDiscountables.Any(v => v.Id == id).Should().BeTrue();
    }

    [Theory]
    [InlineData(2)]
    [InlineData(5)]
    public void ElectiralMadeInChinaTest(long id)
    {
        var electiralMadeInChina = vehicles.Where(v => new ElectiralVehiclesMadeInChinaSpecification().IsSatisfiedBy(v));
        electiralMadeInChina.Any(v => v.Id == id).Should().BeTrue();
    }

    [Theory]
    [InlineData(5)]
    public void DiscountableElectiralMadeInChinaTest(long id)
    {
        var discountableElectiralMadeInChina = vehicles.Where(v => new DiscountSpecification().And(new ElectiralVehiclesMadeInChinaSpecification()).IsSatisfiedBy(v));
        discountableElectiralMadeInChina.Any(v => v.Id == id).Should().BeTrue();
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(6)]
    public void DiscountableOrNotDiscountableTest(long id)
    {
        var all = vehicles.Where(v => new DiscountSpecification().Or(new DiscountSpecification().Not()).IsSatisfiedBy(v));
        all.Any(v => v.Id == id).Should().BeTrue();
    }
}
