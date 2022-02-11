namespace MASA.Framework.Admin.Contracts.User;

public class Routing
{
    public static string UserList = string.Format(UrlRule.DEFAULT_SERVICE, Const.UrlRule.USER_SERVICE, "items");

    public static string UserDetail = string.Format(UrlRule.DEFAULT_SERVICE, Const.UrlRule.USER_SERVICE, "{id}");

    public static string UserCreate = string.Format(UrlRule.DEFAULT_SERVICE, Const.UrlRule.USER_SERVICE, "create");

    public static string UserDelete = string.Format(UrlRule.DEFAULT_SERVICE, Const.UrlRule.USER_SERVICE, "delete");
}
