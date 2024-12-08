using SpecificationPattern.Specifications;

namespace SpecificationPattern.Extensions;
public static class SpecificationExtensions
{
    public static ISpecification<T> And<T>(this ISpecification<T> first, ISpecification<T> second)
    {
        return new AndSpecification<T>(first, second);
    }

    public static ISpecification<T> Or<T>(this ISpecification<T> first, ISpecification<T> second)
    {
        return new OrSpecification<T>(first, second);
    }

    public static ISpecification<T> Not<T>(this ISpecification<T> specification)
    {
        return new NotSpecification<T>(specification);
    }
}
