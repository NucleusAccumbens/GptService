using offer.generator.Enums;

namespace offer.generator.EnumParsers;

public static class TechnologyEnumParser
{
    public static string GetEnumStringValue(Technology? technology)
    {
        if (technology == null) return "Значение не указано";
        if (technology == Technology.HTML) return "HTML";
        if (technology == Technology.SQLCLR) return "SQL CLR";
        if (technology == Technology.BotDevelopment) return "Bot Development";
        if (technology == Technology.EntityFramework) return "Entity Framework";
        if (technology == Technology.ScraperSite) return "Scraper Site";
        if (technology == Technology.CSharp) return "C#";
        if (technology == Technology.ASPNETCore) return "ASP.NET Core";
        if (technology == Technology.ChartJs) return "Chart.js";
        if (technology == Technology.Chatbot) return "Chatbot";
        if (technology == Technology.Telegram) return "Telegram";
        if (technology == Technology.DataScraping) return "Data Scraping";
        if (technology == Technology.MicrosoftSQLServer) return "Microsoft SQL Server";
        if (technology == Technology.PostgreSQL) return "PostgreSQL";
        if (technology == Technology.WebScraping) return "Web Scraping";
        else return ".NET Core";
    }
}
