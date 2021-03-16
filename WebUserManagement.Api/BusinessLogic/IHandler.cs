namespace WebUserManagement.Api.BusinessLogic
{
    public interface IHandler<in TIn, out TOut>
    {
        TOut Handle(TIn input);
    }
}