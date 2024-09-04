namespace LunaTask.BLL.Dtos.Request
{
    public record GetTaskRequest(
        string? SortColumn,
        int PageNumber = 1,
        int PageSize = 15,
        string SortBy = "desc"
    );
}
