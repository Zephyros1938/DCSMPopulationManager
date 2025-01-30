using OpenTK.Mathematics;

namespace Zephyros1938.DCSM.Windowing
{
    readonly struct Resolutions
    {
        // Standard Resolutions
        public static readonly Vector2i Tiny_640x480 = new(640, 480); // 4:3
        public static readonly Vector2i Low_800x600 = new(800, 600); // 4:3
        public static readonly Vector2i VGA_1024x768 = new(1024, 768); // 4:3
        public static readonly Vector2i Medium_1280x720 = new(1280, 720); // 16:9
        public static readonly Vector2i HD_1280x1024 = new(1280, 1024); // 5:4
        public static readonly Vector2i WXGA_1366x768 = new(1366, 768); // 16:9
        public static readonly Vector2i HDPlus_1600x900 = new(1600, 900); // 16:9
        public static readonly Vector2i WUXGA_1920x1200 = new(1920, 1200); // 16:10
        public static readonly Vector2i FullHD_1920x1080 = new(1920, 1080); // 16:9
        public static readonly Vector2i QHD_2560x1440 = new(2560, 1440); // 16:9
        public static readonly Vector2i UHD4K_3840x2160 = new(3840, 2160); // 16:9
        public static readonly Vector2i UHD8K_7680x4320 = new(7680, 4320); // 16:9

        // Ultrawide Resolutions
        public static readonly Vector2i UWQHD_3440x1440 = new(3440, 1440); // 21:9
        public static readonly Vector2i UWUHD_5120x2160 = new(5120, 2160); // 21:9
        //public static readonly Vector2i UWQHDPlus_3840x1600 = new(3840, 1600); // 21:9

        // Legacy Resolutions
        public static readonly Vector2i SVGA_800x480 = new(800, 480); // 5:3
        public static readonly Vector2i XGA_1024x600 = new(1024, 600); // 17:10
        public static readonly Vector2i SXGA_1280x960 = new(1280, 960); // 4:3

        // Mobile/Tablet Resolutions
        public static readonly Vector2i HD720p_720x1280 = new(720, 1280); // 9:16
        public static readonly Vector2i FHD1080p_1080x1920 = new(1080, 1920); // 9:16
        public static readonly Vector2i QHD_1440x2560 = new(1440, 2560); // 9:16

        // Advanced and Rare Resolutions
        public static readonly Vector2i DCI4K_4096x2160 = new(4096, 2160); // 19:10
        public static readonly Vector2i DCI8K_8192x4320 = new(8192, 4320); // 19:10
        public static readonly Vector2i Cinema_2K_2048x1080 = new(2048, 1080); // 17:9

        // Square and Unique Aspect Ratios
        public static readonly Vector2i Square_1080x1080 = new(1080, 1080); // 1:1
        public static readonly Vector2i Panoramic_2560x1080 = new(2560, 1080); // 21:9
        public static readonly Vector2i SuperUltraWide_3840x1080 = new(3840, 1080); // 32:9
    }

    public class Resolution
    {

#pragma warning disable CS8605
        public static Vector2i GetBestResolution(Vector2i monitorResolution)
        {
            // Get all resolutions from the Resolutions class
            var resolutions = typeof(Resolutions)
                .GetFields()
                .Select(static f => (Vector2i)f.GetValue(null))
                .OrderByDescending(r => r.X * r.Y) // Sort by resolution area (width * height)
                .ToList();

            // Find the largest resolution that fits within the monitor dimensions
            foreach (var resolution in resolutions)
            {
                if (resolution.X <= monitorResolution.X && resolution.Y <= monitorResolution.Y)
                {
                    return resolution;
                }
            }

            // If no suitable resolution is found, return the smallest resolution as a fallback
            Console.WriteLine("No suitable resolution found. Using the smallest resolution as a fallback.");
            return resolutions.Last();
        }
#pragma warning restore CS8605
    }
}