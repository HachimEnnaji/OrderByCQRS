using Domain.Order;

namespace CommonService;
public static class ResultExtensions
{
    public static Result<K> Bind<T, K>(this Result<T> result, Func<T, Result<K>> func)
    {
        return result.IsFailure ? Result<K>.Failure(result.ErrorMessage!) : func(result.Value!);
    }

    public static Result<K> Map<T, K>(this Result<T> result, Func<T, Result<K>> func)
    {
        return result.IsFailure ? Result<K>.Failure(result.ErrorMessage!) : func(result.Value!);
    }
}
