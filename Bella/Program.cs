using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bela.Helpers;
namespace Bela
{
    class Program
    {
        static void Main(string[] args)
        {

            string Error = "Critical error";
            string Warning = "Warning";
            string Message = "Message";

            LogHelpers.WriteLog(Error, Bela.Helpers.Enumerations.LevelAudit.Error);
            LogHelpers.WriteLog(Warning, Bela.Helpers.Enumerations.LevelAudit.Warning);
            LogHelpers.WriteLog(Message, Bela.Helpers.Enumerations.LevelAudit.Message);

        }
    }
}
