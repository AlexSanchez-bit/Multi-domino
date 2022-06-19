
public interface IKeyGenerator:IRule
{
    IEnumerable<IKey> GenerateKeyset();
}