namespace MASA.Framework.Admin.Contracts.Configuration.Request.Menu;

public class EditMenuRequest
{
    public Guid MenuId { get; set; }

    public string Name { get; set; }

    public string? Describe { get; set; }

    public string? Icon { get; set; }

    public Guid? ParentId { get; set; }

    public string? ParentName { get; set; }

    public string Url { get; set; }

    public int Sort { get; set; }

    public bool Disabled { get; set; }

    public EditMenuRequest(Guid menuId, string name, string url, int sort, bool disabled)
    {
        MenuId = menuId;
        Name = name;
        Url = url;
        Sort = sort;
        Disabled = disabled;
    }
}
