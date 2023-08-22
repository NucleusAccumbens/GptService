using Microsoft.AspNetCore.Mvc.RazorPages;
using offer.generator.EnumParsers;
using offer.generator.Enums;

namespace offer.generator.Models;

public class СandidateInfoModel 
{
    public string LinkToProfile { get; set; }
    public string CandidateName { get; set; }
    public string Title { get; set; }
    public decimal? HourlyRate { get; set; }
    public string Overview { get; set; }
    public List<ProjectInfoModel> Projects { get; set; }
    public List<string> Technologies { get; set; }


    public string GetСandidateInfo()
    {
        string candidateInfo =
            $"Link to profile: {LinkToProfile}" +
            $"Candidate name: {CandidateName}\n" +
            $"Title: {Title}\n\n" +
            $"Overview: {Overview}\n\n" +
            $"Projects: \n{GetProjectsDescription()}\n\n" +
            $"Technologies: {String.Join(' ', Technologies)}";

        return candidateInfo;
    }

    private string GetProjectsDescription()
    {
        string projDescript = string.Empty;

        foreach (var proj in Projects)
        {
            projDescript += $"{proj.GetProjectInfo()}\n\n";
        }

        return projDescript;
    }
}
