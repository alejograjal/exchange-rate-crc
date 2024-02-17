using HtmlAgilityPack;

namespace AGS.EXCHANGE_RATE.SERVICES.External;

public class PageReader
{
    public string Url { internal get; set; } = null!;

    public PageReader()
    {
    }

    public PageReader(string url) => Url = url;

    private async Task<string> GetHTMLContent()
    {
        using var client = new HttpClient();
        client.DefaultRequestHeaders.Add("User-Agent", "C# custom exnchage web api");

        var content = await client.GetStringAsync(Url);

        return content;
    }

    public async Task<List<HtmlNode>> ExtractTablesFromHtml(string tableName = null!)
    {
        List<HtmlNode> tables = new List<HtmlNode>();

        var content = await GetHTMLContent();
        HtmlDocument document = new HtmlDocument();
        document.LoadHtml(content);

        string selectNodes = tableName == null ? "//table" : $"//table[@id='{tableName}']";
        HtmlNodeCollection nodes = document.DocumentNode.SelectNodes(selectNodes);

        foreach (HtmlNode node in nodes)
        {
            tables.Add(node);
        }

        return tables;
    }
}