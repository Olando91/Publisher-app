namespace Applikation.Porte.Indgående;

public interface IUseCase<TRequest, TResponse>
{
    TResponse Execute(TRequest request);
    Task<TResponse> ExecuteAsync(TRequest request);
}
