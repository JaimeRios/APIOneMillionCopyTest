namespace APIOneMillionCopyTest.Domain.Exceptions
{
    public class EmailAlreadyExistsException : Exception
    {
        public EmailAlreadyExistsException(string email)
            : base($"There is another lead with the email : '{email}'.")
        {
        }
    }
}
