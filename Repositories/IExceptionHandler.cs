namespace CapitalPlacement.Repositories
{
    public interface IExceptionHandler
    {
        void HandleException(Exception ex, string errorMessage);
    }

    public class DefaultExceptionHandler : IExceptionHandler
    {
        public void HandleException(Exception ex, string errorMessage)
        {
            Console.WriteLine($"Error: {errorMessage}. Details: {ex.Message}");
        }
    }
}
