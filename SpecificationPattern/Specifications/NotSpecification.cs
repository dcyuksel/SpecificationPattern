namespace SpecificationPattern.Specifications;
public class NotSpecification<T>(ISpecification<T> specification) : ISpecification<T>
{
    public bool IsSatisfiedBy(T obj)
    {
        return !specification.IsSatisfiedBy(obj);
    }
}
