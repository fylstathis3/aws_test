namespace aws_api.Helpers;

public static class InMemory
{
    public static int IntForCache { get; set; } = 0;
    public static string Message { get; set; } = string.Empty;
}