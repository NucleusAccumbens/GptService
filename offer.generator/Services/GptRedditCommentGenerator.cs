using GptResponseService.Common;
using offer.generator.Exceptions;
using OpenAI.ObjectModels.RequestModels;

namespace GptResponseService.Services;

public class GptRedditCommentGenerator : OpenAiApiConnectionService
{
    public GptRedditCommentGenerator(string key, string instruction)
        : base(key, instruction) { }

    public async Task<string> GetComment(string threads)
    {
        
        var chatMessages = new List<ChatMessage>();

        string promt = $"{Instruction}\n\n" +
            $"Message: \"{threads}\"";

        chatMessages.Add(ChatMessage.FromSystem(promt));

        var response = await MyOpenAiService.ChatCompletion.CreateCompletion(new ChatCompletionCreateRequest
        {
            Messages = chatMessages,
            Model = OpenAI.ObjectModels.Models.ChatGpt3_5Turbo,
        });

        if (response.Successful)
        {
            string comment = response.Choices[0].Message.Content;
            chatMessages.Add(ChatMessage.FromAssistant(comment));

            return comment;
        }
        else
        {
            LogTheError(response);
            throw new OpenAiResponseException();
        }
    }
}
