using offer.generator.Enums;

namespace offer.generator.Models;

public class ProjectInfoModel
{  
    public string ProjectName { get; set; }
    public string ProjectDescription { get; set; }
    public List<string> Technologies { get; set; }
    public string ProjectLink { get; set; }

    public string GetProjectInfo()
    {
        string projectInfo = $"Project name: {ProjectName}\n\n" +
            $"Project description: {ProjectDescription}\n\n" +
            $"Project link: {ProjectLink}" +
            $"Technologies: {String.Join(' ', Technologies)}";

        return projectInfo;
    }
}
