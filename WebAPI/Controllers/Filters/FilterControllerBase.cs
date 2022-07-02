using Microsoft.AspNetCore.Mvc;
using Services.Filtration;
using Services.Filtration.FilterOptions;

namespace WebAPI.Controllers.Filters;

public abstract class FilterControllerBase<TEntity, TFilterOptions> : Controller
{
    private readonly IFilterService<TEntity, TFilterOptions> _entityFilterService;

    public FilterControllerBase(IFilterService<TEntity, TFilterOptions> entityFilterService)
    {
        _entityFilterService = entityFilterService;
    }

    [HttpGet("/filter")]
    public IActionResult Filter()
    {
        var options = GetFilterOptions();
        return Json(_entityFilterService.Filter(options));
    }

    protected abstract TFilterOptions GetFilterOptions();

    protected string? GetQueryString(string parameterName)
    {
        var firstLetter = char.ToLower(parameterName[0]);
        parameterName = firstLetter + parameterName[1..];

        var query = HttpContext.Request.Query;
        if (query.ContainsKey(parameterName))
            return query[parameterName];

        return null;
    }

    protected int? GetQueryInt(string parameterName)
    {
        var str = GetQueryString(parameterName);
        if (int.TryParse(str, out var result))
            return result;

        return null;
    }

    protected double? GetQueryDouble(string parameterName)
    {
        var str = GetQueryString(parameterName);
        if (double.TryParse(str, out var result))
            return result;

        return null;
    }

    protected bool? GetQueryBool(string parameterName)
    {
        var str = GetQueryString(parameterName);
        if (bool.TryParse(str, out var result))
            return result;

        return null;
    }

    protected TEnum? GetQueryEnum<TEnum>(string parameterName)
        where TEnum : Enum
    {
        var str = GetQueryString(parameterName);
        if (Enum.TryParse(typeof(TEnum), str, out var result))
            return (TEnum) (result!);

        return default;
    }

    protected List<TItem>? GetQueryArrayOf<TItem>(string parameterName, Func<string, TItem> convert)
    {
        var str = GetQueryString(parameterName);
        if (str == null)
            return null;

        var elements = str.Split(",", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        if (!elements.Any())
            return null;

        var convertedElements = elements
            .Select(convert)
            .Where(e => e != null)
            .ToArray();

        if (!convertedElements.Any())
            return null;

        return convertedElements.ToList()!;
    }
}