namespace Logger.App.Models.Contracts
{
    public interface ILayout
    {
        string FormatError(IError error);
    }
}