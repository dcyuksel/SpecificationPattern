namespace SpecificationPattern.Specifications;
public class OrSpecification<T>(ISpecification<T> first, ISpecification<T> second) : ISpecification<T>
{
    public bool IsSatisfiedBy(T obj)
    {
        return first.IsSatisfiedBy(obj) || second.IsSatisfiedBy(obj);
    }
}
