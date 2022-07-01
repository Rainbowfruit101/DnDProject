namespace Services.Filtration.Utils;

public interface IFilter<out TItem>
{
    IEnumerable<TItem> Finish();

    TContinuator ContinueWith<TContinuator>(Func<IEnumerable<TItem>, TContinuator> continuatorProducer) where TContinuator: class;
}