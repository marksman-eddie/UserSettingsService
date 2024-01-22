namespace UserManagment.Application.Models.Requests
{
#nullable enable
    public record LayoutsRequest
    {
        public string? UserLogin { get; init; }
        public string? InterfaceType { get; init; }
    }
#nullable disable
}
