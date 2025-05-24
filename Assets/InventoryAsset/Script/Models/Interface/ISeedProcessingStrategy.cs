
namespace Script.Models
{
    public interface ISeedProcessingStrategy
    {
        Plant ProcessSeed(Seed seed);
    }
}