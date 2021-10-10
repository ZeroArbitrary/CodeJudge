using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

/// <summary>
/// Dlls which have implemented this protocol can be regarded as a QuestionService, making it extendable in case we need an online judge in addition to a local judge.
/// </summary>
namespace Protocol
{

    public interface IQuestionServiceProvider
    {

        public IAsyncEnumerable<IQuestion> GetQuestions();


        /// <summary>
        /// 可以先不实现搜索功能
        /// </summary>
        /// <param name="ToBeMatched"></param>
        /// <returns></returns>
        public IAsyncEnumerable<IQuestion> GetQuestions(IQuestion ToBeMatched)
        {
            throw new NotImplementedException("SearchQuestion hasn't been Implemented");
        }

    }




    /// <summary>
    /// Should contain the metaData BUT NOT THE ACTUAL STRING CONTENT of the question.
    /// </summary>
    public interface IQuestion
    {
        public string Topic { get; }

        #region theProgrammingLanguageUsed
        public enum ProgrammingLanguageEnum
        {
            Multiple = -2,
            Others = -1,
            Undefined = 0,
            Cpp, Rust, C,
            Haskell, Racket, Scala, Ocaml, FSharp, CommonLisp, Scheme, StandardML,
            CSharp, Kotlin, D, Clojure, Java, Golang,
            Lua, Ruby, Python, Javascript, Powershell,
            Coq, Agda, Lean,
            Assembly,
            Verilog, VHDL,
            Bash,
        }
        public ProgrammingLanguageEnum PL { get; }
        public string PLString { get => PL.ToString(); }
        #endregion

        public (UInt32 Passed, UInt32 TotalSubmission) Statistic { get; }

        /// <summary>
        /// html, xaml, md, raw txt ... all is possible.
        /// </summary>
        public Uri? QuestionContentForDisplay { get; }

        /// <summary>
        /// Template answer file, student shall edit on its copy, that's why it shall be read only.
        /// </summary>
        public Uri? ReadOnlyAnswerTemplate { get; }

        public IAnswer? AnswerOnWorkingOrNewAnswer { get; }

        /// <summary>
        /// 如果未实现, 接口默认返回Unimplemented.
        /// </summary>
        /// <param name="answer"></param>
        /// <returns></returns>
        public ITestResult ExecuteTest(IAnswer answer)
        {
            return new TestResult(ITestResult.TestResultEnum.Unimplemented, "this Question doesn't provide ExecuteTest Service\n");
        }

    }


    public class QuestionToBeSearched : IQuestion
    {
        public string Topic { get; }
        public Uri? QuestionContentForDisplay { get; private set; }
        public Uri? ReadOnlyAnswerTemplate { get => null; }
        public IAnswer? AnswerOnWorkingOrNewAnswer { get => null; }
        public IQuestion.ProgrammingLanguageEnum PL { get; }

        public QuestionToBeSearched(IQuestion.ProgrammingLanguageEnum pl, string Topic) => (this.Topic, this.PL) = (Topic, pl);

        public QuestionToBeSearched SetQuestionContent(Uri? questionContent)
        {
            QuestionContentForDisplay = questionContent;
            return this;
        }

        public (uint, uint) Statistic { get;  }
    }


    /// <summary>
    /// should contain the metaData like uri of the answer
    /// </summary>
    public interface IAnswer
    {
        IQuestion CorrespondingQuestion { get; }

        /// <summary>
        /// the file student will edit on. 
        /// when initalized, its content shall be the same as 
        /// this.CorrespondingQuestion.ReadOnlyAnswerTemplate
        /// </summary>
        public Uri TobeEdit { get; }

        ITestResult TestMe()
        {
            return this.CorrespondingQuestion.ExecuteTest(this);
        }

        /// <summary>
        /// Reset the content of Uri to the original ReadOnlyAnswerTemplate.
        /// Note the difference between reset the view of user interface and reset the file.
        /// </summary>
        void ResetMe();

    }



    public interface ITestResult
    {
        public TestResultEnum TestResultKeyWord { get; }
        public enum TestResultEnum
        {
            Unimplemented = -2,

            Others = -1,

            Undefined = 0,
            /*AC*/
            Accepted,  /*CE*/ CompilerError,
            /*RE*/
            RuntimeError, /*TLE*/ TimeLimitExceeded, /*MLE*/ MemoryLimitExceeded,
            /*WA*/
            WrongAnswer, /*PE*/ PresentationError, /*OLE*/ OutputLimitExceeded,

        }

        public string TestResultString() => TestResultKeyWord.ToString();
        public string Hint { get; }
    }


    public class TestResult : ITestResult
    {
        public ITestResult.TestResultEnum TestResultKeyWord { get; }

        public string Hint { get; }

        public TestResult(ITestResult.TestResultEnum testResult, string hint) =>
            (this.TestResultKeyWord, this.Hint) = (testResult, hint);
    }

}
