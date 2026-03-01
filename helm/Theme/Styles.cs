namespace helm.Theme;

using static helm.Theme.Colors;

/// <summary>
/// Centralized inline styles for MudBlazor components.
/// Reduces CSS file size by using component Style parameters.
/// </summary>
public static class Styles
{
    // ═══════════════════════════════════════════════════════════════════
    // TRANSPARENCY HELPERS (using MainTheme base colors)
    // ═══════════════════════════════════════════════════════════════════
    
    // rgba(240, 237, 228, x) = Parchment with transparency
    private const string BeigeTransparent50 = "rgba(240, 237, 228, 0.5)";
    private const string BeigeTransparent65 = "rgba(240, 237, 228, 0.65)";
    
    // rgba(166, 157, 138, x) = DustBeigeDark with transparency  
    private const string BorderBeige = "rgba(166, 157, 138, 0.4)";
    private const string BorderBeigeHover = "rgba(166, 157, 138, 0.6)";
    
    // rgba(58, 67, 53, x) = FieldOlive with transparency
    private const string OliveTransparent = "rgba(58, 67, 53, 0.85)";

    // ═══════════════════════════════════════════════════════════════════
    // SEMI-TRANSPARENT BACKGROUNDS
    // ═══════════════════════════════════════════════════════════════════
    
    /// <summary>Standard semi-transparent beige background for content elements</summary>
    public const string ContentBackground = $"background-color: {BeigeTransparent50};";
    
    /// <summary>Content background with border</summary>
    public const string ContentBackgroundBordered = $"background-color: {BeigeTransparent50}; border: 1px solid {BorderBeige};";
    
    /// <summary>Hover state for content elements</summary>
    public const string ContentBackgroundHover = $"background-color: {BeigeTransparent65}; border-color: {BorderBeigeHover};";

    // ═══════════════════════════════════════════════════════════════════
    // CARDS
    // ═══════════════════════════════════════════════════════════════════
    
    /// <summary>Card base style</summary>
    public const string Card = ContentBackgroundBordered;
    
    /// <summary>Semi-transparent detail card for collectible pages</summary>
    public const string DetailCard = "background-color: rgba(255, 255, 255, 0.5); border: 1px solid rgba(200, 195, 180, 0.3); border-radius: 8px; padding: 24px; box-shadow: 0 2px 8px rgba(0, 0, 0, 0.08);";
    
    /// <summary>Small card content container</summary>
    public const string SmallCardContent = "display: flex; flex-direction: column; align-items: flex-start;";
    
    /// <summary>Card text - truncated with ellipsis</summary>
    public const string CardTextTruncate = "display: block; width: 100%; text-align: left; white-space: nowrap; overflow: hidden; text-overflow: ellipsis;";
    
    /// <summary>Card secondary text (country/date)</summary>
    public const string CardSecondaryText = $"{CardTextTruncate} color: {WashedCanvas};";

    // ═══════════════════════════════════════════════════════════════════
    // TABLE
    // ═══════════════════════════════════════════════════════════════════
    
    /// <summary>Table container style</summary>
    public const string Table = ContentBackgroundBordered;

    // ═══════════════════════════════════════════════════════════════════
    // TOOLBAR
    // ═══════════════════════════════════════════════════════════════════
    
    /// <summary>Item count pill</summary>
    public const string ItemCountPill = $"background-color: {FieldOlive}; color: {OffWhite}; padding: 0 10px; border-radius: 12px; font-size: 0.8125rem; font-weight: 500; line-height: 24px; height: 24px; display: inline-flex; align-items: center; ";
    
    /// <summary>Toggle group container</summary>
    public const string ToggleGroup = $"background-color: rgba(240, 237, 228, 0.6);";
    
    
    /// <summary>Toggle item base</summary>
    public const string ToggleItem = $"color: {GunmetalSteel}; min-width: 40px";
    
    /// <summary>Toggle item selected</summary>
    public const string ToggleItemSelected = $"background-color: {OliveTransparent}; color: {OffWhite}";

    // ═══════════════════════════════════════════════════════════════════
    // ALERTS
    // ═══════════════════════════════════════════════════════════════════
    
    /// <summary>Alert/info message style</summary>
    public const string Alert = ContentBackgroundBordered;

    // ═══════════════════════════════════════════════════════════════════
    // DRAWER (Sidebar)
    // ═══════════════════════════════════════════════════════════════════
    
    /// <summary>Drawer header text</summary>
    public const string DrawerHeaderText = $"color: {OffWhite}; text-shadow: 0 1px 2px rgba(0, 0, 0, 0.4)";
    
    /// <summary>Drawer icon button</summary>
    public const string DrawerIconButton = $"color: {OffWhiteDim}";
    
    /// <summary>Drawer button</summary>
    public const string DrawerButton = $"color: {OffWhite}";
    
    /// <summary>Drawer input field</summary>
    public const string DrawerInput = $"color: {OffWhite}";
}
