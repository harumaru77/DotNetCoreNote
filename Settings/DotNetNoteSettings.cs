namespace DotNetNote.Settings
{
    // POCO(Plain Old CLR Object) 클래스
    public class DotNetNoteSettings
    {
        public string SiteName { get; set; } = "DotNetNote";
        public string SiteUrl { get; set; } = "http://www.dotnetnote.com";
        public string SiteAdmin { get; set; } = "Admin";
    }
}