using MASA.Framework.Admin.Contracts.Authentication.Request.Roles;

namespace Masa.Framework.Admin.RCL.RBAC;

public class RolePage : ComponentPage
{
    public List<RoleItemResponse> Datas { get; set; } = new();

    public RoleItemResponse CurrentData { get; set; } = new();

    public List<AuthorizeItemResponse> AuthorizeDatas { get; set; } = new();

    public AuthorizeItemResponse CurrentAuthorizeData { get; set; } = new();

    private AuthenticationCaller AuthenticationCaller { get; set; }

    public int State { get; set; } = -1;

    public string? _search;

    public string? Search
    {
        get { return _search; }
        set
        {
            _search = value;
            QueryPageDatasAsync().ContinueWith(_ => Reload?.Invoke());
        }
    }

    public int _pageSize = 10;
    public int PageSize
    {
        get { return _pageSize; }
        set
        {
            _pageSize = value;
            QueryPageDatasAsync().ContinueWith(_ => Reload?.Invoke());
        }
    }

    public int PageIndex { get; set; } = 1;

    public int PageCount => (int)Math.Ceiling(CurrentCount / (double)PageSize);

    public bool Lodding { get; set; }

    public bool Error { get; set; }

    public string? Message { get; set; }

    public long CurrentCount { get; set; }

    public List<int> PageSizes = new() { 10, 25, 50, 100 };

    public List<DataTableHeader<RoleItemResponse>> Headers { get; set; }

    public bool IsAdd => CurrentData.Id != Guid.Empty;

    public RolePage(AuthenticationCaller authenticationCaller, I18n i18n)
    {
        AuthenticationCaller = authenticationCaller;
        Headers = new()
        {
            new() { Text = T("Role.Name"), Value = nameof(RoleItemResponse.Name) },
            new() { Text = T("Role.Number"), Value = nameof(RoleItemResponse.Number) },
            new() { Text = T("State"), Value = nameof(RoleItemResponse.State) },
            new() { Text = T("CreationTime"), Value = nameof(RoleItemResponse.CreationTime), Sortable = false },
            new() { Text = T("Describe"), Value = nameof(RoleItemResponse.Describe), Sortable = false },
            new() { Text = T("Action"), Value = "Action", Sortable = false }
        };

        string T(string key)
        {
            return i18n.T(key) ?? key;
        }
    }

    public async Task QueryPageDatasAsync()
    {
        Lodding = true;
        var result = await AuthenticationCaller.GetRoleItemsAsync(PageIndex, PageSize, State, Search);
        Error = !result.Success;
        Message = result.Message;
        if (result.Success)
        {
            var pageData = result.Data!;
            CurrentCount = pageData.Count;
            Datas = pageData.Items.ToList();
            Datas.Add(new RoleItemResponse
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                Describe = "Test",
                Number = 100,
                CreationTime = DateTime.Now,
                State = MASA.Framework.Admin.Contracts.Base.Enum.State.Enable,
            });
        }
        Lodding = false;
    }

    public async Task AddOrUpdateAsync()
    {
        Lodding = true;
        var result = default(ApiResultResponseBase);
        if (CurrentData.Id != Guid.Empty)
        {
            result = await AuthenticationCaller.AddRoleAsync(new AddRoleRequest()
            {
                Name = CurrentData.Name,
                Number = CurrentData.Number,
                Describe = CurrentData.Describe,
            });
        }
        else
        {
            result = await AuthenticationCaller.EditRoleAsync(new EditRoleRequest
            {
                RuleId = CurrentData.Id,
                Name = CurrentData.Name,
                Describe = CurrentData.Describe,
            });
        }
        Error = result.Success;
        Message = result.Message;
        Lodding = false;
    }

    public async Task DeleteAsync()
    {
        Lodding = true;
        var result = await AuthenticationCaller.DeleteRoleAsync(new DeleteRoleRequest
        {
            RuleId = CurrentData.Id,
        });
        Error = result.Success;
        Message = result.Message;
        Lodding = false;
    }

    public async Task QueryAuthorizeItemsAsync()
    {
        Lodding = true;
        var result = await AuthenticationCaller.GetAuthorizeItemsAsync(CurrentData.Id);
        Error = !result.Success;
        Message = result.Message;
        Lodding = false;
        AuthorizeDatas = result.Data ?? new();
    }
}

