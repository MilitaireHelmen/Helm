using MudBlazor;
using static helm.Theme.Colors;

namespace helm.Theme;

/// <summary>
/// MudBlazor theme configuration using the military/vintage color palette.
/// </summary>
public static class MainTheme
{
    public static MudTheme Theme { get; } = new()
    {
        // ═══════════════════════════════════════════════════════════════════
        // LIGHT PALETTE - Aged paper/canvas feel
        // ═══════════════════════════════════════════════════════════════════
        PaletteLight = new PaletteLight
        {
            // Primary - Field Olive
            Primary = FieldOlive,
            PrimaryContrastText = White,
            PrimaryDarken = FieldOliveDark,
            PrimaryLighten = FieldOliveLight,
            
            // Secondary - Brass Tone (aged metal accents)
            Secondary = BrassTone,
            SecondaryContrastText = White,
            SecondaryDarken = BrassToneDark,
            SecondaryLighten = BrassToneLight,
            
            // Tertiary - Washed Canvas
            Tertiary = WashedCanvas,
            TertiaryContrastText = White,
            TertiaryDarken = WashedCanvasDark,
            TertiaryLighten = WashedCanvasLight,
            
            // Semantic Colors
            Info = SignalBlue,
            InfoContrastText = White,
            Success = CampaignGreen,
            SuccessContrastText = White,
            Warning = AlertAmber,
            WarningContrastText = White,
            Error = MutedRed,
            ErrorContrastText = White,
            
            // Dark accent
            Dark = GunmetalSteel,
            DarkContrastText = White,
            
            // Text
            TextPrimary = GunmetalSteel,
            TextSecondary = WashedCanvas,
            TextDisabled = FogGray,
            
            // Actions
            ActionDefault = WashedCanvas,
            ActionDisabled = FogGrayLight,
            ActionDisabledBackground = DustBeigeLighter,
            
            // Backgrounds - Aged paper feel
            Background = AgedPaper,
            BackgroundGray = AgedPaperDark,
            Surface = Parchment,
            
            // Drawer - Canvas tint with olive undertone
            DrawerBackground = CanvasTint,
            DrawerText = GunmetalSteel,
            DrawerIcon = FieldOlive,
            
            // Appbar - Gunmetal for contrast
            AppbarBackground = GunmetalSteel,
            AppbarText = DustBeigeLight,
            
            // Lines & Borders - Darker for definition
            LinesDefault = DustBeigeDark,
            LinesInputs = DustBeigeDark,
            TableLines = DustBeigeDark,
            TableStriped = WarmCream,
            TableHover = DustBeige,
            Divider = DustBeige,
            DividerLight = DustBeigeLighter,
            
            // Opacity
            HoverOpacity = 0.06,
            RippleOpacity = 0.12,
            RippleOpacitySecondary = 0.2,
        },

        // ═══════════════════════════════════════════════════════════════════
        // DARK PALETTE - Night operations / bunker feel
        // ═══════════════════════════════════════════════════════════════════════
        PaletteDark = new PaletteDark
        {
            // Primary - Lighter olive for visibility
            Primary = FieldOliveLighter,
            PrimaryContrastText = White,
            PrimaryDarken = FieldOlive,
            PrimaryLighten = "#7E8D74",
            
            // Secondary - Lighter brass
            Secondary = BrassToneLight,
            SecondaryContrastText = Black,
            SecondaryDarken = BrassTone,
            SecondaryLighten = "#C4AD6E",
            
            // Tertiary - Lighter canvas
            Tertiary = WashedCanvasLight,
            TertiaryContrastText = Black,
            TertiaryDarken = WashedCanvas,
            TertiaryLighten = "#A3A898",
            
            // Semantic Colors - Lighter for dark mode
            Info = SignalBlueLight,
            InfoContrastText = Black,
            Success = CampaignGreenLight,
            SuccessContrastText = Black,
            Warning = AlertAmberLight,
            WarningContrastText = Black,
            Error = MutedRedLight,
            ErrorContrastText = White,
            
            // Dark accent
            Dark = GunmetalSteelDark,
            DarkContrastText = White,
            
            // Text - Dust beige tones
            TextPrimary = DustBeigeLight,
            TextSecondary = FogGray,
            TextDisabled = FogGrayDark,
            
            // Actions
            ActionDefault = FogGray,
            ActionDisabled = FogGrayDark,
            ActionDisabledBackground = GunmetalSteelLight,
            
            // Backgrounds - Deep gunmetal
            Background = GunmetalSteelDark,
            BackgroundGray = GunmetalSteel,
            Surface = GunmetalSteel,
            
            // Drawer
            DrawerBackground = GunmetalSteel,
            DrawerText = DustBeigeLight,
            DrawerIcon = FogGray,
            
            // Appbar
            AppbarBackground = GunmetalSteelDark,
            AppbarText = DustBeigeLight,
            
            // Lines & Borders
            LinesDefault = GunmetalSteelLight,
            LinesInputs = FogGrayDark,
            TableLines = GunmetalSteelLight,
            TableStriped = "#323532",
            TableHover = "#3A3D38",
            Divider = GunmetalSteelLight,
            DividerLight = "#343734",
            
            // Opacity
            HoverOpacity = 0.08,
            RippleOpacity = 0.15,
            RippleOpacitySecondary = 0.25,
        },

        Typography = Typography.Value,

        LayoutProperties = new LayoutProperties
        {
            DefaultBorderRadius = "3px",
            DrawerWidthLeft = "280px",
            DrawerWidthRight = "280px",
            DrawerMiniWidthLeft = "56px",
            DrawerMiniWidthRight = "56px",
            AppbarHeight = "64px"
        },

        Shadows = new Shadow(),
        ZIndex = new ZIndex()
    };
}
