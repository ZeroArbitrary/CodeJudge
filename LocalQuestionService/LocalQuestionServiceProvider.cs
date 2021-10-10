
using System.Collections.Generic;
using System.Text;
using Protocol;
using System.Text.Json;
using System;

// https://docs.microsoft.com/zh-cn/dotnet/standard/data/sqlite/?tabs=netcore-cli
// ^^ is about sqlite, which might be useful.


namespace LocalQuestionService
{
    public class LocalQuestionServiceProvider : IQuestionServiceProvider
    {   

        public LocalQuestionServiceProvider(LocalQuestionServiceOption option)
        {
            // throw new NotImplementedException();
        }

        public IAsyncEnumerable<IQuestion> GetQuestions()
        {
            throw new NotImplementedException();
        }
    }
}
