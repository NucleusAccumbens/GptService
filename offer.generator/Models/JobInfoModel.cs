using offer.generator.EnumParsers;
using offer.generator.Enums;

namespace offer.generator.Models;

public class JobInfoModel
{
    public string JobTitle { get; set; }
    public string JobDescription { get; set; }
    public decimal JobPrice { get; set; }
    public List<string> Technologies { get; set; }

    public string GetJobInfo()
    {
        string jobInfo = $"Job title: {JobTitle}\n\n" +
            $"Description: {JobDescription}\n\n" +
            $"Technologies: {String.Join(' ', Technologies)}";

        return jobInfo;
    }
}
