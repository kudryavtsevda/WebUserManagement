namespace WebUserManagement.Api.Exceptions
{
    public class NotFoundException : CustomApiException
    {
        public NotFoundException(string message) : base(StatusCode.NotFound, message)
        {
        }
    }
}