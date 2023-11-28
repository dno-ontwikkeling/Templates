namespace MyTemplate.UI.Options;

public class SupportedCulturesOptions
{
    public required List<SupportedCulture> SupportedCultures { get; set; }
}

public class SupportedCulture
{
    public required string Display { get; set; }
    public required string Culture { get; set; }

    public override bool Equals(object? obj)
    {
        var other = obj as SupportedCulture;
        return other?.Culture == Culture;
    }

    // ReSharper disable once NonReadonlyMemberInGetHashCode
    public override int GetHashCode()
    {
        return Culture.GetHashCode();
    }
}