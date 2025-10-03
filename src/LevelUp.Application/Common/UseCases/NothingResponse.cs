namespace LevelUp.Application.Common.UseCases;

public class NothingResponse
{
    public static NothingResponse Value => new();

    private NothingResponse()
    {
    }
}