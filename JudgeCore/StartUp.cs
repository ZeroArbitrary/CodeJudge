using System;
using Utilities;
using Utilities.Configs;
using Utilities.Tools;
using LocalQuestionService;
using Protocol;
namespace JudgeCore
{
   public class GeneralConfigOption
    {
        public bool DisplayConfigInfoMessageBox { get; set; }

        public string? WellComeString { get; set; }
    }

   public static class StartUp{
        public static Context StartUpProgram(UserInfo info)
        {
            var localQuestionOption =Configuaration
                .Get<LocalQuestionServiceOption>(nameof(LocalQuestionServiceOption));
            var questionService = new LocalQuestionServiceProvider(localQuestionOption);

            var generalConfigOption = Configuaration.Get<GeneralConfigOption>(nameof(GeneralConfigOption));

            return new
                Context(questionService,
                generalConfigOption,
                info);

        }
        
   }

    public class Context
    {
        public IQuestionServiceProvider QuestionService { get; }
        public GeneralConfigOption GeneralConfigOption { get;  }

        public UserInfo UserInfo { get;  }

        public Context(IQuestionServiceProvider sq, GeneralConfigOption generalConfigOption, UserInfo info)
        {
            QuestionService = sq;
            GeneralConfigOption = generalConfigOption;
            UserInfo = info;
        }
    }
    
}
