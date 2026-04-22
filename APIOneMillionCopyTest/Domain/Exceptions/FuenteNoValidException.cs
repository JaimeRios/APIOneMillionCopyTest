namespace APIOneMillionCopyTest.Domain.Exceptions
{
    public class FuenteNoValidException : Exception
    {
        public FuenteNoValidException(string fuente)
            : base($"Fuente '{fuente}' is not a valid value.")
        {
        }
    }
}
