using System;
namespace LocalQuestionService
{


    public class LocalQuestionServiceOption
    {
        /// <summary>
        ///  Whether to seek problem and answer folders
        ///  from AppDomain.CurrentDomain.BaseDirectory;
        /// </summary>
        public bool UseBaseDiretoryQ { get; set; }

        /// <summary>
        /// use only when UseBaseDirectoryQ is false 
        /// </summary>
        public Uri? ServiceDirectory { get; set; }


        #region CompilerLocation 
        // similarly, don't really need to implement all.
        public Uri? PythonInterpreter { get; set; }

        public Uri? GCCCompiler { get; set; }

        public Uri? CsharpCompiler { get; set; }
        #endregion
    }


}
