using GptResponseService.Common;
using offer.generator.Exceptions;
using offer.generator.Models;
using OpenAI.ObjectModels.RequestModels;

namespace offer.generator.Services;

public class GptCoverLetterGenerator : OpenAiApiConnectionService
{
    public GptCoverLetterGenerator(string key, string instruction)
        : base(key, instruction) { }

    public async Task<string> GetCoverLetter(СandidateInfoModel candidateInfo, JobInfoModel jobInfo)
    {

        var chatMessages = new List<ChatMessage>();


        string promt = $"{Instruction}\n\n" +
            $"{candidateInfo.GetСandidateInfo()}\n\n" +
            $"{jobInfo.GetJobInfo()}";
        
        chatMessages.Add(ChatMessage.FromSystem(promt));

        var response = await MyOpenAiService.ChatCompletion.CreateCompletion(new ChatCompletionCreateRequest
        {
            Messages = chatMessages,
            Model = OpenAI.ObjectModels.Models.ChatGpt3_5Turbo,
        });

        if (response.Successful)
        {
            string res = response.Choices[0].Message.Content;
            chatMessages.Add(ChatMessage.FromAssistant(res));

            return res;
        }
        else
        {
            LogTheError(response);
            throw new OpenAiResponseException();
        }
    }
}
