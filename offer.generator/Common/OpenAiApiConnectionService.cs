using OpenAI;
using OpenAI.Managers;
using OpenAI.ObjectModels.ResponseModels;

namespace GptResponseService.Common;

public abstract class OpenAiApiConnectionService
{
    private readonly string _apiKey;

    private readonly string _instruction;

    public OpenAiApiConnectionService(string apiKey, string instruction)
    {
        _apiKey = apiKey;
        _instruction = instruction;
    }

    public virtual string Instruction => _instruction;

    public OpenAIService MyOpenAiService => GetAIService();

    private OpenAIService GetAIService()
    {
        return new OpenAIService(new OpenAiOptions()
        {
            ApiKey = _apiKey
        });
    }

    public static void LogTheError(BaseResponse response)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n\n{response.Error?.Message}\n\n");
        Console.ResetColor();
    }
}
