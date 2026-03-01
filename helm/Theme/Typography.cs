using MudBlazor;

namespace helm.Theme;

/// <summary>
/// Typography configuration for the application theme.
/// </summary>
public static class Typography
{
    // ═══════════════════════════════════════════════════════════════════
    // SHARED CONSTANTS
    // ═══════════════════════════════════════════════════════════════════
    
    private static readonly string[] FontStack = ["Roboto", "Helvetica", "Arial", "sans-serif"];
    
    // Font weights
    private const string Light = "300";
    private const string Regular = "400";
    private const string Medium = "500";
    
    // Common letter spacing values
    private const string SpacingTight = "-0.01562em";
    private const string SpacingNormal = "0.00938em";
    private const string SpacingWide = "0.02857em";
    
    // ═══════════════════════════════════════════════════════════════════
    // TYPOGRAPHY CONFIGURATION
    // ═══════════════════════════════════════════════════════════════════
    
    public static MudBlazor.Typography Value { get; } = new()
    {
        // Base default
        Default = Create<DefaultTypography>("0.875rem", Regular, "1.5", SpacingNormal),
        
        // Headings - Large display text
        H1 = Create<H1Typography>("3rem", Light, "1.167", SpacingTight),
        H2 = Create<H2Typography>("2.25rem", Light, "1.2", "-0.00833em"),
        H3 = Create<H3Typography>("1.875rem", Regular, "1.167", "0em"),
        H4 = Create<H4Typography>("1.5rem", Regular, "1.235", "0.00735em"),
        H5 = Create<H5Typography>("1.25rem", Regular, "1.334", "0em"),
        H6 = Create<H6Typography>("1rem", Medium, "1.6", "0.0075em"),
        
        // Body text
        Body1 = Create<Body1Typography>("1rem", Regular, "1.5", SpacingNormal),
        Body2 = Create<Body2Typography>("0.875rem", Regular, "1.43", "0.01071em"),
        
        // UI elements
        Button = Create<ButtonTypography>("0.875rem", Medium, "1.75", SpacingWide, "uppercase"),
        Caption = Create<CaptionTypography>("0.75rem", Regular, "1.66", "0.03333em"),
        Overline = Create<OverlineTypography>("0.75rem", Regular, "2.66", "0.08333em"),
        
        // Subtitles
        Subtitle1 = Create<Subtitle1Typography>("1rem", Regular, "1.75", SpacingNormal),
        Subtitle2 = Create<Subtitle2Typography>("0.875rem", Medium, "1.57", "0.00714em"),
    };
    
    // ═══════════════════════════════════════════════════════════════════
    // FACTORY METHOD
    // ═══════════════════════════════════════════════════════════════════
    
    private static T Create<T>(string size, string weight, string lineHeight, string letterSpacing, string? textTransform = null) 
        where T : BaseTypography, new() =>
        new()
        {
            FontFamily = FontStack,
            FontSize = size,
            FontWeight = weight,
            LineHeight = lineHeight,
            LetterSpacing = letterSpacing,
            TextTransform = textTransform ?? "none"
        };
}
