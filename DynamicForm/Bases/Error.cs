using System.Text;

namespace DynamicForm.Bases;

public record Error
{
    public string ErrorCode { get; init; }

    public string Message { get; }

    public bool IsTransient { get; }

    public Error? Inner { get; }

    public string FullMessage => Message + ((object)Inner != null ? Environment.NewLine + Inner!.FullMessage : "");

    public Error(string Message, string ErrorCode, bool IsTransient, Error? Inner = null)
    {
        this.ErrorCode = ErrorCode;
        this.Message = Message;
        this.IsTransient = IsTransient;
        this.Inner = Inner;
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("Error");
        stringBuilder.Append(" { ");
        if (PrintMembers(stringBuilder))
        {
            stringBuilder.Append(' ');
        }

        stringBuilder.Append('}');
        return stringBuilder.ToString();
    }
}
