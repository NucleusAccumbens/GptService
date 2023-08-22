using GptResponseService.Common;
using offer.generator.Exceptions;
using OpenAI.ObjectModels.RequestModels;


namespace UpworkCoverLetterCreater.Services;

public class GptTgСhatMessageNormalizer : OpenAiApiConnectionService
{

    public GptTgСhatMessageNormalizer(string key, string instruction)
       : base(key, instruction) { }

    private readonly string _instruction =
        "Название компании: [название из сообщения, это значение может быть не указано]\n" +
        "Название вакансии: [название вакансии из сообщения]\n" +
        "Описание вакансии: [описание вакансии из сообщения]\n" +
        "Профессианальная сфера: [профессиональная сфера кандидата из сообщения. " +
        "выбери из этого списка: SoftwareDevelopment, ItManagement, TechSupport, Sales]\n" +
        "Специализация: [специализация кандидата из сообщения. " +
        "выбери из этого списка: BackEnd, FrontEnd, Fullstack, MobileAppDevelopment, GameDev, " +
        "UIUXDesigner, DevOps, QA, QAA, MobileQA, SDET, BlockchainCrypto, MachineLearningEngineer, " +
        "BigDataEngineer, DataAnalysts, DataScience, ScrumMaster, DatabaseAdministrator, DataEngineer, " +
        "WebDesigner, CTO, DeliveryManager, HR, ProductManagement, ProjectManagement, Recruitment, ScrumMaster, " +
        "TeamLead, TechLead, CAndCPlusPlus, FrontEnd, BackEnd, Unity, UnrealEngine, TwoDArtist, " +
        "ThreeDArtist, TechnicalArtist, GameDesigner, UiUxDesigner, ArtDirector, GameProducer,]\n" +
        "Технологии: [технологии, указанные в сообщении]\n" +
        "Страны:  [страны из сообщения.выбери из этого списка: " +
        "Armenia, Bulgaria, Canada, Czech, Estonia, Georgia, Germany, Hungary, Lithuania, " +
        "Montenegro, NorthernCyprus, Other, Poland, RepublicIsrael, Turkey, USA, Ukraine, Belarus, Russia]\n" +
        "Форматы работы: [форматы работы из сообщения. их может быть несколько. " +
        "выбери из этого списка: Remote, Project, Relocate, RemoteOffice, FullTime, PartTime, Freelance]\n" +
        "Опыт работы: [требуемый опыт работы кандидата из сообщения.выбери из этого списка: LessThanAYear, OneToTwoYears, ThreeToFourYears, FiveToSevenYears, EightToTenYears, MoreThanTenYears]\n" +
        "Грейд: [требуемый грейд кандидата из сообщения.выбери из этого списка: Junior, Middle, Senior, TeamLead, SeniorTeamLead]\n" +
        "Зарплата: [зарплата из сообщения в формате из списка.выбери из этого списка: " +
        "From500, From1000, From2000, From3000, From4000, From5000, From6000, From7000, From8000, From9000]\n";

    public override string Instruction => _instruction;

    public async Task<string> GetVacancyInformation(string message)
    {
        var chatMessages = new List<ChatMessage>();


        string promt = $"{_instruction}\n\n" +
            $"Message: \"{message}\"";

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
