using GptResponseService.Services;
using Microsoft.AspNetCore.Mvc;
using offer.generator.Models;
using offer.generator.Services;
using UpworkCoverLetterCreater.Services;

namespace offer.generator.Controllers;

public class GptController : ControllerBase
{
    private GptCoverLetterGenerator? _coverLetterGenerator;

    private GptTgСhatMessageNormalizer? _gptChatMessageNormalizer;

    private GptRedditCommentGenerator? _redditCommentGenerator;


    [HttpPost]
    [Route("get-cover-letter")]
    public async Task<IResult> GetCoverLetter(string key, string instruction, СandidateInfoModel candidateInfo, JobInfoModel jobInfo)
    {
        try
        {
            _coverLetterGenerator = new(key, instruction);
            
            var res = await _coverLetterGenerator.GetCoverLetter(candidateInfo, jobInfo);

            Console.WriteLine($"{res}\n\n");

            var result = Results.Json(
                res,
                new(System.Text.Json.JsonSerializerDefaults.Web),
                "application/json; charset=utf-8",
                200);

            return result;
        }
        catch (Exception ex)
        {

            string answer = ex.Message;

            return Results.Json(answer,
                new(System.Text.Json.JsonSerializerDefaults.Web));
        }
    }

    [HttpGet]
    [Route("get-vacancy-info")]
    public async Task<IResult> GetVacancyInfo(string key, string messageFromChat)
    {
        try
        {
            _gptChatMessageNormalizer = new(key, "instruction");
            
            var res = await _gptChatMessageNormalizer.GetVacancyInformation(messageFromChat);

            Console.WriteLine($"{res}\n\n");

            var result = Results.Json(
                res,
                new(System.Text.Json.JsonSerializerDefaults.Web),
                "application/json; charset=utf-8",
                200);

            return result;
        }
        catch (Exception ex)
        {

            string answer = ex.Message;

            return Results.Json(answer,
                new(System.Text.Json.JsonSerializerDefaults.Web));
        }
    }

    [HttpGet]
    [Route("get-comment")]
    public async Task<IResult> GetRedditComment(string key, string threads, string instruction)
    {
        try
        {
            _redditCommentGenerator = new(key, instruction);
            
            var res = await _redditCommentGenerator.GetComment(threads);

            Console.WriteLine($"{res}\n\n");

            var result = Results.Json(
                res,
                new(System.Text.Json.JsonSerializerDefaults.Web),
                "application/json; charset=utf-8",
                200);

            return result;
        }
        catch (Exception ex)
        {

            string answer = ex.Message;

            return Results.Json(answer,
                new(System.Text.Json.JsonSerializerDefaults.Web));
        }
    }
}
