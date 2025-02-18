namespace SportsStore.Models.ViewModels;


// Es un modelo que almacena información sobre la paginación, como la página
// actual y el total de páginas.
public class PagingInfo
{
    public int TotalItems { get; set; }

    public int ItemsPerPage { get; set; }

    public int CurrentPage { get; set; }

    public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
}